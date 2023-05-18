using AutoMapper;
using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;
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
            services.AddScoped<ComandaRepository>();
            //services.AddScoped<IRepository<comanda>, Repository<comanda>>();


            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ProdutoRepository>();

            services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
            services.AddScoped<EstabelecimentoRepository>();

            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<PedidoRepository>();


            //services.AddScoped<ILoginService, LoginService>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<estabelecimento, EstabelecimentoModel>().ReverseMap();
                config.CreateMap<comanda, ComandaModel>().ReverseMap();
                config.CreateMap<comanda, AbrirComandaRequest>().ReverseMap();

                config.CreateMap<produtos, ProdutoModel>().ReverseMap();
                config.CreateMap<tipoProduto, TipoProdutoModel>().ReverseMap();
                config.CreateMap<pedidos, PedidoModel>().ReverseMap();
                config.CreateMap<pedido_itens, Pedido_Itens_Model>().ReverseMap();
                config.CreateMap<pedidos, PedidoRequest>().ReverseMap();
                config.CreateMap<pedido_itens, PedidoItensRequest>().ReverseMap();

                //config.CreateMap<produtos_estabelecimento, Produto_Estabelecimento_Model>().ReverseMap();
            }).CreateMapper());
        }
    }
}
