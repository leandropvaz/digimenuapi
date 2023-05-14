
using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;
using DigiMenu.Infra.Data.EF;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using DigiMenu.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DigiMenu.Tests
{
    public class DigiMenuTests
    {

        private IRepository<estabelecimento> _baseRepository;
        private IRepository<mesa> _mesaRepository;
        private IRepository<produtos> _produtoRepository;
        private IRepository<comanda> _comandaRepository;
        private IPedidoService _pedidoService;
        public DigiMenuTests()
        {
            var services = Bootstrap.Start();

            var _digiMenuContext = services.BuildServiceProvider().GetService<DigiMenuContext>();

            _baseRepository = services.BuildServiceProvider().GetRequiredService<IRepository<estabelecimento>>();
            _mesaRepository = services.BuildServiceProvider().GetRequiredService<IRepository<mesa>>();
          
            _comandaRepository = services.BuildServiceProvider().GetRequiredService<IRepository<comanda>>();
            
            _produtoRepository = services.BuildServiceProvider().GetRequiredService<IRepository<produtos>>();
            

            _pedidoService = services.BuildServiceProvider().GetRequiredService<IPedidoService>();
        }

        [Fact]
        public void GetEstabelecimento()
        {
           //var x =  _baseRepository.Select(Guid.Parse("881BB5E3-06B4-4AF6-B586-028971ECDDE9"));
        }

        [Fact]
        public void InsertEstabelecimento()
        {
            estabelecimento estabelecimento = new(){
          
            nome = "Bar do Leandro",
            cidade= "Contagem",
            endereco = "Rua da Pedra",
            email = "teste@gmail.com",
            estado = "MG",
            telefone = "31-9999-9999"
            };
            _baseRepository.Add(estabelecimento);
        }

        [Fact]
        public void InsertMesa()
        {
            for (int i = 1; i <= 10; i++)
            {
                mesa mesa = new()
                {
                    numero = i.ToString(),
                    ativo = true,
                    estabelecimento= 1

                };
                _mesaRepository.Add(mesa);
            }
        }

      

        [Fact]
        public void InsertComanda()
        {
            comanda comanda = new()
            {

                mesa = 1,
                anfitriao = "Alexandre",
                status = 1,
            };
            _comandaRepository.Add(comanda);
        }

        //[Fact]
        //public void InsertComandaItens()
        //{
        //    comanda_itens comandaItens = new()
        //    {

        //        produto=2,
        //        comanda = 1,
        //    };
        //    _comandaItensRepository.Add(comandaItens);
        //}

        [Fact]
        public void InsertProdutos()
        {

            produtos produto = new()
            {
                
                ativo = true,
                descricao = "Coca Cola 350 ML ",
                preco = (decimal)5,
                Tipo = 1,
                estabelecimento = 1

            };
            _produtoRepository.Add(produto);

        }



        [Fact]
        public void InserePedido()
        {
            PedidoItensRequest itens = new PedidoItensRequest();
            itens.status = 1;
            itens.produto = 2;
            itens.quantidade = 10;



            PedidoRequest pedido = new()
            {

                comanda = 1,
                observacao = "Teste",
                responsavel = "Leandro",
                status = 1,
                pedido_itens = new() { itens}
            };

            _pedidoService.FazerPedido(pedido);
        }
    }
}