
using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Infra.Data.EF;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DigiMenu.Tests
{
    public class DigiMenuTests
    {

        private IRepository<estabelecimento> _baseRepository;
        private IRepository<mesa> _mesaRepository;
        private IRepository<produtos> _produtoRepository;
        private IRepository<produtos_estabelecimento> _produtoEstabelecimentoRepository;
        private IRepository<mesa_estabelecimento> _mesaEstabelecimentoRepository;
        private IRepository<comanda> _comandaRepository;
        private IRepository<comanda_itens> _comandaItensRepository;
        public DigiMenuTests()
        {
            var services = Bootstrap.Start();

            var _digiMenuContext = services.BuildServiceProvider().GetService<DigiMenuContext>();
            _baseRepository = services.BuildServiceProvider().GetRequiredService<IRepository<estabelecimento>>();
            _mesaRepository = services.BuildServiceProvider().GetRequiredService<IRepository<mesa>>();
            _mesaEstabelecimentoRepository = services.BuildServiceProvider().GetRequiredService<IRepository<mesa_estabelecimento>>();
            _comandaRepository = services.BuildServiceProvider().GetRequiredService<IRepository<comanda>>();
            _comandaItensRepository = services.BuildServiceProvider().GetRequiredService<IRepository<comanda_itens>>();
            _produtoRepository = services.BuildServiceProvider().GetRequiredService<IRepository<produtos>>();
            _produtoEstabelecimentoRepository = services.BuildServiceProvider().GetRequiredService<IRepository<produtos_estabelecimento>>();
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
            id= Guid.NewGuid(),
            nome = "Bar do Thiago",
            cidade= "Contagem",
            endereco = "Rua da Pedra",
            email = "thiago@gmail.com",
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
                    id = Guid.NewGuid(),
                    numero = i.ToString(),
                    ativo = true,

                };
                _mesaRepository.Add(mesa);
            }
        }

        [Fact]
        public void InsertMesaEstabelecimento()
        {

                mesa_estabelecimento mesa = new()
                {
                    id = Guid.NewGuid(),
                    mesa = Guid.Parse("78FCD34C-13A5-4076-BB62-DAE1F26F7DD0"),
                    estabelecimento = Guid.Parse("881BB5E3-06B4-4AF6-B586-028971ECDDE9"),
                    status = Guid.Parse("374E8939-37E9-4390-9F34-2D457479844C"),
                    ativo = true,

                };
                _mesaEstabelecimentoRepository.Add(mesa);

        }

        [Fact]
        public void InsertComanda()
        {
            comanda comanda = new()
            {
                id = Guid.NewGuid(),
                mesa_estabelecimento = Guid.Parse("50ACC4A2-4D8F-49CB-9EDC-4718F114728F"),
                anfitriao = "Alexandre",
                status = Guid.Parse("374E8939-37E9-4390-9F34-2D457479844C"),
            };
            _comandaRepository.Add(comanda);
        }

        [Fact]
        public void InsertComandaItens()
        {
            comanda_itens comandaItens = new()
            {
                id = Guid.NewGuid(),
                produto= Guid.Parse("E41A8916-42BC-4AE4-8EFC-2ADE8E2CEC71"),
                comanda = Guid.Parse("BDCF5759-058B-440A-811D-03735C521F94"),
            };
            _comandaItensRepository.Add(comandaItens);
        }

        [Fact]
        public void InsertProdutos()
        {

            produtos produto = new()
            {
                id = Guid.NewGuid(),
                ativo = true,
                descricao = "Batata Frita",
                preco = (decimal)12.00

            };
            _produtoRepository.Add(produto);

        }

        [Fact]
        public void InsertProdutosEstabelecimento()
        {
            produtos_estabelecimento produto = new()
            {
                id = Guid.NewGuid(),
                ativo = true,
                estabelecimento = Guid.Parse("881BB5E3-06B4-4AF6-B586-028971ECDDE9"),
                produto = Guid.Parse("DDCF449E-2502-4DB1-9D93-C180154312CA"),
            };
            _produtoEstabelecimentoRepository.Add(produto);
        }
    }
}