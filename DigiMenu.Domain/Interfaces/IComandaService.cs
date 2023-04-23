using DigiMenu.Domain.Models;

namespace DigiMenu.Domain.Interfaces
{
    public interface IComandaService
    {
        Guid AbrirComanda(ComandaModel inputModel);
        ComandaModel FecharComanda(Guid id);
        ComandaModel IncluirItemComanda(List<Comanda_Itens_Model> comandaItens);
        ComandaModel GetComanda(Guid id);        
    }
}
