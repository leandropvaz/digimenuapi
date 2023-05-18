using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;

namespace DigiMenu.Domain.Interfaces
{
    public interface IComandaService
    {
        ComandaModel GetComanda(int id);
        int AbrirComanda(AbrirComandaRequest inputModel);
   

        //ComandaModel FecharComanda(int id);
        //ComandaModel IncluirItemComanda(List<Comanda_Itens_Model> comandaItens);
          
    }
}
