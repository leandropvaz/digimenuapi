using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models.Request
{
    public class LoginRequest
    {
        public string? cpf { get; set; }
        public string? senha { get; set; } = null!;
    }
}
