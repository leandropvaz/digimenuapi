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
    public class EstabelecimentoRepository : Repository<EF.Models.estabelecimento>
    {
        //private readonly DigiMenuContext _dbContext;

        public EstabelecimentoRepository(DigiMenuContext context) : base(context)
        {
            //_dbContext = context;
        }

        public async Task<IEnumerable<estabelecimento>> GetEstabelecimentoById(int estabelecimentoId)
        {
            var result = await base._context.estabelecimento
                .Where(x => x.id == estabelecimentoId).ToListAsync();

            return result;
        }
    }
}
