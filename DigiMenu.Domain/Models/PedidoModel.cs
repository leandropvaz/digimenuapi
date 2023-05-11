using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models
{
    public class PedidoModel
    {
        public int comanda { get; set; }

        public int status { get; set; }

        public DateTime dataPedidoFeito { get; set; }

        public string? responsavel { get; set; }

        public string? observacao { get; set; }

        public DateTime? dataPedidoEntregue { get; set; }


        public virtual ICollection<Pedido_Itens_Model> pedido_itens { get; set; } = new List<Pedido_Itens_Model>();
    }
}
