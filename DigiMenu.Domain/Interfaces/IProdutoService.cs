using DigiMenu.Domain.Models;

namespace DigiMenu.Domain.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoModel> GetProdutoById(int id);

        IEnumerable<ProdutoModel> GetProdutosByEstabelecimento(int id);

        IEnumerable<ProdutoModel> GetProdutosByTipo(int idEstabelcimento,int idTipoProduto);

        IEnumerable<TipoProdutoModel> GetTipoProdutos();   
    }
}
