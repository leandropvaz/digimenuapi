using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;

namespace DigiMenu.Domain.Interfaces
{
    public interface IComandaService
    {
        Result<ComandaModel> GetComanda(int id);
        int AbrirComanda(AbrirComandaRequest inputModel);
        decimal ValorComanda(int comanda);
        decimal ValorCreditoComanda(int comanda);
        int FecharComanda(int id);
        int GetStatusComanda(int id);
    }
}
