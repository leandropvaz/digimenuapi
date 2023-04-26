using DigiMenu.Domain.Models;

namespace DigiMenu.Domain.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoModel> GetProdutos(Guid id);        
    }
}
