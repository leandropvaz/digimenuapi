using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models
{
    public class ProdutoModel
    {
        public Guid id { get; set; }

        public string descricao { get; set; } = null!;

        public decimal preco { get; set; }

        public bool ativo { get; set; }

    }
}
