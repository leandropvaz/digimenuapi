using DigiMenu.Domain.Models;
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
    public class PedidoRepository : Repository<EF.Models.pedidos>
    {
        //private readonly DigiMenuContext _dbContext;

        public PedidoRepository(DigiMenuContext context) : base(context)
        {
            //_dbContext = context;
        }

        public async Task<IEnumerable<pedidos>> GetPedidoByComanda(int comanda)
        {
            var result = await base._context.pedidos
              .Include(x => x.pedido_itens)
              .Where(x => x.comanda == comanda)
              .OrderByDescending(x => x.id).ToListAsync();

            return result;

        }
        public string GetNomeUsuario(int idusuario)
        {
            var nome = _context.usuario
                        .Where(u => u.id == idusuario)
                        .Select(u => u.nome)
                        .FirstOrDefault();
            return nome;
        }
    }
}
