using DigiMenu.Domain.Models;

namespace DigiMenu.Domain.Interfaces
{
    public interface IComandaService
    {
        int AbrirComanda(ComandaModel inputModel);
        ComandaModel FecharComanda(int id);
        ComandaModel IncluirItemComanda(List<Comanda_Itens_Model> comandaItens);
        ComandaModel GetComanda(int id);        
    }
}
