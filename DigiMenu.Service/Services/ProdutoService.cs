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


        public IEnumerable<ProdutoModel> GetProdutos(Guid id)
        {
            var entity = _produtoRepository.GetByProdutosEstabelecimento(id).GetAwaiter().GetResult();
            var outputModel = _mapper.Map<IEnumerable<ProdutoModel>>(entity);
            return outputModel;
        }
    }
}
