using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models
{
    public class EstabelecimentoModel
    {
        public Guid id { get; set; }

        public string nome { get; set; } = null!;

        public string endereco { get; set; } = null!;

        public string cidade { get; set; } = null!;

        public string estado { get; set; } = null!;

        public string telefone { get; set; } = null!;

        public string email { get; set; } = null!;
    }
}
