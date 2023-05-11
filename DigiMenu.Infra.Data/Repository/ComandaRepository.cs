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
    public class ComandaRepository : Repository<EF.Models.comanda>
    {
        //private readonly DigiMenuContext _dbContext;

        public ComandaRepository(DigiMenuContext context) : base(context)
        {
            //_dbContext = context;
        }

    }
}
