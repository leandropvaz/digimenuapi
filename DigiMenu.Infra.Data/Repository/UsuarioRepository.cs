using DigiMenu.Infra.Data.EF;
using DigiMenu.Infra.Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<EF.Models.usuario>
    {
        public UsuarioRepository(DigiMenuContext context) : base(context)
        {
        }

        public async Task<IEnumerable<usuario>> Login(string cpf, string senha)
        {
            var resultado = await (from usuario in _context.usuario
                                   where usuario.cpf == cpf && usuario.senha == senha
                                   select usuario).ToListAsync();

            return resultado;
        }

    }
}
