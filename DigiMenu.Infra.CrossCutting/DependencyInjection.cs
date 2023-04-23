using AutoMapper;
using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Infra.Data.EF;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using DigiMenu.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DigiMenu.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddDbContext<DigiMenuContext>(options =>
            {
                options.UseSqlServer("Server=coretech.database.windows.net;Database=digimenu;User ID=coretech;Password=Babi2505;");
                options.EnableSensitiveDataLogging(false);
                options.EnableDetailedErrors(false);
            });
            services.AddScoped<IRepository<estabelecimento>, Repository<estabelecimento>>();
            services.AddScoped<IDigiMenuService<estabelecimento>, DigiMenuService<estabelecimento>>();
            
            services.AddScoped<IComandaService, ComandaService>();
            services.AddScoped<IRepository<comanda>, Repository<comanda>>();
            services.AddScoped<IRepository<comanda_itens>, Repository<comanda_itens>>();
            //services.AddScoped<ILoginService, LoginService>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<estabelecimento, EstabelecimentoModel>().ReverseMap();
                config.CreateMap<comanda, ComandaModel>().ReverseMap();
                config.CreateMap<comanda_itens, Comanda_Itens_Model>().ReverseMap();
            }).CreateMapper());
        }
    }
}
