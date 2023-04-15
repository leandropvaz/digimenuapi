using Microsoft.Data.SqlClient;
using System.Data;

namespace Component.UnitOfWork.EF.Extensions
{
    public static class SqlParameterExtensions
    {
        public static SqlParameter AddDataTableSqlParameter(this SqlParameter sqlParameter, string parameterName, DataTable value, string typeName)
        {
            return new SqlParameter(parameterName, SqlDbType.Structured)
            {
                Value = value,
                TypeName = typeName,
                Direction = ParameterDirection.Input
            };
        }
    }
}
