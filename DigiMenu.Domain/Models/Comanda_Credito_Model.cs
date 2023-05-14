using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models
{
    public class Comanda_Credito_Model
    {
        public int id { get; set; }

        public int comanda { get; set; }

        public decimal valor { get; set; }

        public string? responsavel { get; set; }

    }
}
