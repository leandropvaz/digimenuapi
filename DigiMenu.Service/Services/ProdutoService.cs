using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using AutoMapper;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;

namespace DigiMenu.Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private ProdutoRepository _produtoRepository;

        public ProdutoService(IMapper mapper, ProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }


        public IEnumerable<ProdutoModel> GetProdutoById(int id)
        {
            var entity = _produtoRepository.GetProdutoById(id).GetAwaiter().GetResult();
            var outputModel = _mapper.Map<IEnumerable<ProdutoModel>>(entity);
            return outputModel;
        }

        public IEnumerable<ProdutoModel> GetProdutosByEstabelecimento(int idEstabelecimento)
        {
            var entity = _produtoRepository.GetByProdutosEstabelecimento(idEstabelecimento).GetAwaiter().GetResult();
            var outputModel = _mapper.Map<IEnumerable<ProdutoModel>>(entity);
            return outputModel;
        }

        public IEnumerable<ProdutoModel> GetProdutosByTipo(int idEstabelecimento, int idTipoProduto)
        {
            var entity = _produtoRepository.GetProdutosByTipoProdutos(idEstabelecimento, idTipoProduto).GetAwaiter().GetResult();
            var outputModel = _mapper.Map<IEnumerable<ProdutoModel>>(entity);
            return outputModel;
        }
    }
}
