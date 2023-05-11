using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;

namespace DigiMenu.Domain.Interfaces
{
    public interface IPedidoService
    {
        int FazerPedido(PedidoRequest pedido);
   

        //ComandaModel FecharComanda(int id);
        //ComandaModel IncluirItemComanda(List<Comanda_Itens_Model> comandaItens);
        //ComandaModel GetComanda(int id);        
    }
}
