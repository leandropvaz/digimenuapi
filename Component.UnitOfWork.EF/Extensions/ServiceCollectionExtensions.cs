
using Component.UnitOfWork.EF;
using Component.UnitOfWork.EF.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Component.Database.Aviso.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWorkService(this IServiceCollection services)
        {
            ////UnitOfWork
            //services.AddScoped<IUnitOfWork, UnitOfWork.EF.UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }

        


    }
}
