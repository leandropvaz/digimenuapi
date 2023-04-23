using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models
{
    public class Comanda_Itens_Model
    {
        public Guid id { get; set; }

        public Guid comanda { get; set; }

        public Guid produto { get; set; }

    }
}
