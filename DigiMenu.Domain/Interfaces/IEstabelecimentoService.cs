using DigiMenu.Domain.Models;

namespace DigiMenu.Domain.Interfaces
{
    public interface IEstabelecimentoService
    {
        IEnumerable<EstabelecimentoModel> GetEstabelecimento(int id);        
    }
}
