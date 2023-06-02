using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;

namespace DigiMenu.Domain.Interfaces
{
    public interface IComandaService
    {
        ComandaModel GetComanda(int id);
        int AbrirComanda(AbrirComandaRequest inputModel);
        decimal ValorComanda(int comanda);
        decimal ValorCreditoComanda(int comanda);


        //ComandaModel FecharComanda(int id);
        //ComandaModel IncluirItemComanda(List<Comanda_Itens_Model> comandaItens);

    }
}
