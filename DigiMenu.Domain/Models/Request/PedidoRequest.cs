using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models.Request
{
    public class PedidoRequest
    {
        public int comanda { get; set; }

        public int status { get; set; }

        public string? responsavel { get; set; }

        public string? observacao { get; set; }

        public List<PedidoItensRequest> pedido_itens { get; set; } = new List<PedidoItensRequest>();

    }
}
