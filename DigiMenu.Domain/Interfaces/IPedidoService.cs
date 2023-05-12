using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;

namespace DigiMenu.Domain.Interfaces
{
    public interface IPedidoService
    {
        int FazerPedido(PedidoRequest pedido);
        IEnumerable<PedidoModel> GetPedidos(int id);     
    }
}
