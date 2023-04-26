using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models
{
    public class Produto_Estabelecimento_Model
    {
        public Guid id { get; set; }

        public Guid produto { get; set; }

        public Guid estabelecimento { get; set; }

        public bool ativo { get; set; }

        public virtual ProdutoModel produtoNavigation { get; set; } = null!;
    }
}
