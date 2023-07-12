using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;
using DigiMenu.Domain.Models.Response;

namespace DigiMenu.Domain.Interfaces
{
    public interface IComandaService
    {
        ComandaModel GetComanda(int id);
        int AbrirComanda(AbrirComandaRequest inputModel);
        decimal ValorComanda(int comanda);
        decimal ValorCreditoComanda(int comanda);
        int FecharComanda(int id);
        int GetStatusComanda(int id);
        IEnumerable<PreviewComanda> GetPreviewComanda(int comanda);
        IEnumerable<ComandaModel> GetComandasbyEstabelecimentos(int idestabelecimento);

        ValoresComanda GetValoresComanda(int comanda);
    }
}
