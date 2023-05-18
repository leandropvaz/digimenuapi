using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models.Request
{
    public class AbrirComandaRequest
    {
        public int mesa { get; set; }

        public string? anfitriao { get; set; }

    }
}
