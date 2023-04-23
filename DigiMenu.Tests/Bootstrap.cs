using DigiMenu.Domain.Interfaces;
using DigiMenu.Infra.Data.EF;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using DigiMenu.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigiMenu.Tests
{
    public class Bootstrap
    {
        public static ServiceCollection Start()
        {
            //var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var services = new ServiceCollection();

            services.AddDbContext<DigiMenuContext>(options =>
            {
                options.UseSqlServer("Server=coretech.database.windows.net;Database=digimenu;User ID=coretech;Password=Babi2505;");
                options.EnableSensitiveDataLogging(false);
                options.EnableDetailedErrors(false);
            });

            services.AddScoped<IRepository<estabelecimento>, Repository<estabelecimento>>();
            services.AddScoped<IRepository<mesa>, Repository<mesa>>();
            services.AddScoped<IRepository<mesa_estabelecimento>, Repository<mesa_estabelecimento>>();
            services.AddScoped<IRepository<comanda>, Repository<comanda>>();
            services.AddScoped<IRepository<comanda_itens>, Repository<comanda_itens>>();
            services.AddScoped<IRepository<produtos>, Repository<produtos>>();
            services.AddScoped<IRepository<produtos_estabelecimento>, Repository<produtos_estabelecimento>>();


            services.AddScoped<IDigiMenuService<estabelecimento>, DigiMenuService<estabelecimento>>();
            // services.AddDatabaseMetadataService(config.GetSection(nameof(DatabaseMetadataSettings)).GetSection("ConnectionString").Value);
            return services;
        }
    }
}
