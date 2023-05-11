using DigiMenu.Domain.Models;

namespace DigiMenu.Domain.Interfaces
{
    public interface IPedidoService
    {
        int FazerPedido(PedidoModel pedido);
   

        //ComandaModel FecharComanda(int id);
        //ComandaModel IncluirItemComanda(List<Comanda_Itens_Model> comandaItens);
        //ComandaModel GetComanda(int id);        
    }
}
