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
    }
}
