using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models.Response
{
    public class PreviewComanda
    {
        public string item { get; set; }
        public string descricao { get; set; }
        public string precoUnitario { get; set; }
        public string quantidade { get; set; }
        public string precoTotal { get; set; }

    }
}
