using Component.UnitOfWork.EF.Extensions;
using Component.UnitOfWork.EF.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace Component.UnitOfWork.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        private bool _disposed;
        private Dictionary<Type, object> _repositories;
        private IDbContextTransaction _transaction;

        public DbContext GetContext()
        {
            return _dbContext;
        }

        public void SetContext(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_dbContext);
            }
            return (IRepository<TEntity>)_repositories[type];
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        #region Execute Procedures
        /// <summary>
        /// Executa de forma genérica, utilizando DataTableType caso exista na entidade
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameProcedure"></param>
        /// <param name="entity"></param>
        /// <param name="schemaDataTableType"></param>
        /// <returns></returns>
        public async Task<int> ExecuteProcedure<T>(string nameProcedure, T entity, string? schemaDataTableType = null)
        {

            StringBuilder sqlQuery = new StringBuilder();

            //Gera o nome dos parâmetros
            var stringParameters = GenerateParametersName<T>();

            //Gera os parametros
            var parameters = GenerateSqlParameters<T, object>(entity, null, schemaDataTableType);

            sqlQuery.AppendJoin(" ", "EXECUTE", nameProcedure, stringParameters);

            var r = await _dbContext.Database.ExecuteSqlRawAsync(sqlQuery.ToString(), parameters);

            return r;
        }


        public async Task<TOutput> ExecuteProcedureWithOutput<T, TOutput>(string nameProcedure, T entity, string schemaDataTableType = null)
        {

            StringBuilder sqlQuery = new StringBuilder();
            //Create object from generic
            var objGenericOutput = Activator.CreateInstance<TOutput>();

            //Gera o nome dos parâmetros
            var stringParameters = GenerateParametersName<T, TOutput>();

            //Gera os parametros
            var parameters = GenerateSqlParameters<T, object>(entity, objGenericOutput, schemaDataTableType);

            sqlQuery.AppendJoin(" ", "EXECUTE", nameProcedure, stringParameters);

            var r = await _dbContext.Database.ExecuteSqlRawAsync(sqlQuery.ToString(), parameters);


            if (objGenericOutput != null)
            {
                //Verifica os parâmetros de retorno
                foreach (SqlParameter parameter in parameters)
                {
                    var prop = objGenericOutput.GetType().GetProperty(parameter.ParameterName.Replace("@", ""));

                    if (prop != null)
                    {
                        if (!Convert.IsDBNull(parameter.Value))
                            prop.SetValue(objGenericOutput, parameter.Value, null);

                    }
                }
            }

            return objGenericOutput;
        }

        /// <summary>
        /// Executa procedure de forma genérica com retorno de dados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="nameProcedure"></param>
        /// <param name="entity"></param>
        /// <param name="schemaDataTableType"></param>
        /// <returns></returns>
        public async Task<List<TResult>> ExecuteProcedureWithReturn<T, TResult>(string nameProcedure, T entity, string schemaDataTableType = null) where TResult : new()
        {

            StringBuilder sqlQuery = new StringBuilder();

            //Gera o nome dos parâmetros
            var stringParameters = GenerateParametersName<T>();

            //Gera os parametros
            var parameters = GenerateSqlParameters<T, object>(entity, null, schemaDataTableType);

            sqlQuery.AppendJoin(" ", "EXECUTE", nameProcedure, stringParameters);

            List<TResult> tasks;
            using (_dbContext.Database.GetDbConnection())
            {
                _dbContext.Database.GetDbConnection().Open();
                DbCommand cmd = _dbContext.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = nameProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);


                using (var reader = cmd.ExecuteReader())
                {
                    tasks = reader.MapToList<TResult>();
                }
            }

            return tasks;

        }
        #endregion

        #region Métodos Helper
        private object FixDBNull(object? item) => item is null ? DBNull.Value : item;

        /// <summary>
        /// Verifica se o objeto genérico é do tipo LIST
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool IsGenericList(PropertyInfo o)
        {
            var oType = o.PropertyType;
            return (oType.IsGenericType && (oType.GetGenericTypeDefinition() == typeof(List<>)));
        }

        /// <summary>
        /// Gera uma string com o nome dos parametros a serem utilizados no SqlParameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string GenerateParametersName<T>()
        {
            var entity = Activator.CreateInstance<T>();

            PropertyInfo[] properties = entity.GetType().GetProperties();
            StringBuilder stringParameters = new StringBuilder();


            int i = 1;
            foreach (PropertyInfo property in properties)
            {

                if (i == properties.Length)
                    stringParameters.Append(string.Format("@{0} ", property.Name));
                else
                    stringParameters.Append(string.Format("@{0}, ", property.Name));

                ++i;

            }

            return stringParameters.ToString();
        }

        public string GenerateParametersName<T, TOutput>()
        {

            var entity = Activator.CreateInstance<T>();
            var entityOutput = Activator.CreateInstance<TOutput>();

            //Propriedades dos parametros comumns
            PropertyInfo[] properties = entity.GetType().GetProperties();

            //Propriedades dos parametros ouput
            PropertyInfo[] propertiesOutput = entityOutput.GetType().GetProperties();


            StringBuilder stringParameters = new StringBuilder();


            //--------------------------------------------------------------------------------
            //Gera parâmetros comuns
            int i = 1;
            foreach (PropertyInfo property in properties)
            {
                string textParameter = string.Empty;

                if (i == properties.Length)
                {
                    if (propertiesOutput.Length > 0)
                        textParameter = string.Format("@{0}, ", property.Name);
                    else
                        textParameter = string.Format("@{0} ", property.Name);
                }
                else
                    textParameter = string.Format("@{0}, ", property.Name);



                stringParameters.Append(string.Format(textParameter, property.Name));

                ++i;

            }
            //--------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------
            //Gera parâmetros output
            i = 1;
            foreach (PropertyInfo property in propertiesOutput)
            {
                string textParameterOutput = string.Empty;

                if (i == propertiesOutput.Length)
                    textParameterOutput = string.Format("@{0} OUTPUT", property.Name);

                else
                    textParameterOutput = string.Format("@{0} OUTPUT,", property.Name);

                //Se ja existir remover o parâmetro
                int index = stringParameters.ToString().IndexOf(string.Format("@{0},", property.Name));
                if (index >= 0)
                {
                    stringParameters.Remove(index, string.Format("@{0},", property.Name).Length);
                }

                stringParameters.Append(string.Format(textParameterOutput, property.Name));

                ++i;
            }
            //--------------------------------------------------------------------------------

            return stringParameters.ToString();
        }

        /// <summary>
        /// Gera os parametros sql da chamada de forma genérica com base na entidade
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public SqlParameter[] GenerateSqlParameters<T, TOutput>(T entity, TOutput? entityOutput = null, string? schemaDataTableType = null) where TOutput : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            SqlParameter[]? parameters = null;
            PropertyInfo[] properties = entity.GetType().GetProperties();

            //Monta os parâmetros e os valores conforme classe genérica
            List<SqlParameter> list = new List<SqlParameter>();
            foreach (var item in properties)
            {
                if (IsGenericList(item))
                {
                    var typeDatatable = item.PropertyType.GetGenericArguments().Single();
                    var methodGenerateDatatable = typeDatatable.GetMethod("CreateDataTable");

                    var objectItem = item.GetValue(entity);
                    //Check is null
                    if (objectItem == null)
                        objectItem = Activator.CreateInstance(item.PropertyType);


                    //Cria o Datatable
                    object?[] genericParameter = new object?[] { objectItem };

                    var datatable = methodGenerateDatatable.Invoke(typeDatatable, genericParameter);

                    string nameType = string.Empty;

                    if (schemaDataTableType != null)
                    {
                        nameType = $"{schemaDataTableType}.{item.PropertyType.GetGenericArguments().Single().Name}";
                    }
                    else
                        nameType = $"{item.PropertyType.GetGenericArguments().Single().Name}";

                    list.Add(new SqlParameter().AddDataTableSqlParameter(string.Format("@{0}", item.Name), (DataTable)datatable, nameType));
                }
                else
                {

                    list.Add(new SqlParameter(string.Format("@{0}", item.Name), FixDBNull(item.GetValue(entity))));
                }
            }

            //------------------------------------------------------------------------------------
            //Adiciona os parâmetros do tipo output
            if (entityOutput != null)
            {
                PropertyInfo[] propertiesOutput = entityOutput.GetType().GetProperties();

                foreach (var itemOutput in propertiesOutput)
                {

                    bool exists = list.Any(p => p.ParameterName == string.Format("@{0}", itemOutput.Name));
                    if (!exists)
                    {
                        list.Add(GetSqlParameterOutput(string.Format("@{0}", itemOutput.Name), itemOutput));
                    }
                }
            }
            //------------------------------------------------------------------------------------

            parameters = list.ToArray();

            return parameters;
        }

        public static SqlParameter GetSqlParameterOutput(string parameterName, PropertyInfo obj)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;
            parameter.Direction = ParameterDirection.Output;
            parameter.Size = 1024;

            Type type = obj.PropertyType;
            if (type == typeof(int) || type == typeof(Int32) || type == typeof(int?))
                parameter.Value = 0;
            else if (type == typeof(string) || type == typeof(String))
                parameter.Value = string.Empty;
            else if (type == typeof(float) || type == typeof(Single))
                parameter.Value = 0;
            else if (type == typeof(double) || type == typeof(Double))
                parameter.Value = 0;
            else if (type == typeof(decimal) || type == typeof(Decimal))
                parameter.Value = 0;
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
                parameter.Value = DateTime.Now;
            else if (type == typeof(bool) || type == typeof(Boolean))
                parameter.Value = false;
            else if (type == typeof(byte) || type == typeof(Byte))
                parameter.Value = 0;
            else if (type == typeof(long) || type == typeof(Int64))
                parameter.Value = 0;
            else if (type == typeof(short) || type == typeof(Int16))
                parameter.Value = 0;
            else if (type == typeof(Guid) || type == typeof(Guid?))
                parameter.Value = new Guid();
            else
                throw new Exception("Unsupported data type");

            return parameter;
        }

        public SqlDbType GetSqlDbType(object obj)
        {
            Type type = obj.GetType();
            if (type == typeof(int) || type == typeof(Int32) || type == typeof(int?))
                return SqlDbType.Int;
            else if (type == typeof(string) || type == typeof(String))
                return SqlDbType.NVarChar;
            else if (type == typeof(float) || type == typeof(Single))
                return SqlDbType.Real;
            else if (type == typeof(double) || type == typeof(Double))
                return SqlDbType.Float;
            else if (type == typeof(decimal) || type == typeof(Decimal))
                return SqlDbType.Decimal;
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
                return SqlDbType.DateTime;
            else if (type == typeof(bool) || type == typeof(Boolean))
                return SqlDbType.Bit;
            else if (type == typeof(byte) || type == typeof(Byte))
                return SqlDbType.TinyInt;
            else if (type == typeof(long) || type == typeof(Int64))
                return SqlDbType.BigInt;
            else if (type == typeof(short) || type == typeof(Int16))
                return SqlDbType.SmallInt;
            else if (type == typeof(Guid) || type == typeof(Guid?))
                return SqlDbType.UniqueIdentifier;
            else
                throw new Exception("Unsupported data type");
        }

        public SqlDbType GetSqlDbType(PropertyInfo obj)
        {
            Type type = obj.PropertyType;
            if (type == typeof(int) || type == typeof(Int32) || type == typeof(int?))
                return SqlDbType.Int;
            else if (type == typeof(string) || type == typeof(String))
                return SqlDbType.NVarChar;
            else if (type == typeof(float) || type == typeof(Single))
                return SqlDbType.Real;
            else if (type == typeof(double) || type == typeof(Double))
                return SqlDbType.Float;
            else if (type == typeof(decimal) || type == typeof(Decimal))
                return SqlDbType.Decimal;
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
                return SqlDbType.DateTime;
            else if (type == typeof(bool) || type == typeof(Boolean))
                return SqlDbType.Bit;
            else if (type == typeof(byte) || type == typeof(Byte))
                return SqlDbType.TinyInt;
            else if (type == typeof(long) || type == typeof(Int64))
                return SqlDbType.BigInt;
            else if (type == typeof(short) || type == typeof(Int16))
                return SqlDbType.SmallInt;
            else if (type == typeof(Guid) || type == typeof(Guid?))
                return SqlDbType.UniqueIdentifier;
            else
                throw new Exception("Unsupported data type");
        }

        #endregion

    }
}
