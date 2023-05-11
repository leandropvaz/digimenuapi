using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models.Request
{
    public class PedidoItensRequest
    {
        public int pedido { get; set; }

        public int produto { get; set; }

        public int quantidade { get; set; }

        public int status { get; set; }
    }
}
