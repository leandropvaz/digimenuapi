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
    public class ProdutoRepository: Repository<EF.Models.produtos>
    {
        //private readonly DigiMenuContext _dbContext;

        public ProdutoRepository(DigiMenuContext context) : base(context)
        {
            //_dbContext = context;
        }

        public async Task<IEnumerable<produtos>> GetByProdutosEstabelecimento(Guid estabelecimentoId)
        {
            var result = await base._context.produtos_estabelecimento
                .Include(x => x.produtoNavigation)
                .Where(x => x.estabelecimento == estabelecimentoId)
                .Select(x=>x.produtoNavigation).ToListAsync();

            return result;
        }
    }
}
