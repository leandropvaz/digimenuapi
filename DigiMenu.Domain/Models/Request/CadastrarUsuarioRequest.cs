using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models.Request
{
    public class CadastrarUsuarioRequest
    {
        public string? nome { get; set; }
        public string? telefone { get; set; }
        public string? cpf { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; } = null!;

    }
}
