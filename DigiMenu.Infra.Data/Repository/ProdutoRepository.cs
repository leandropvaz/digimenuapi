﻿using DigiMenu.Infra.Data.EF;
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

        public async Task<IEnumerable<produtos>> GetByProdutosEstabelecimento(int estabelecimentoId)
        {
            var result = await base._context.produtos
                .Where(x => x.estabelecimento == estabelecimentoId).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<produtos>> GetProdutoById(int produtoId)
        {
            var result = await base._context.produtos
                .Include(x => x.TipoNavigation)
                .Where(x => x.id == produtoId).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<produtos>> GetProdutosByTipoProdutos(int idEstabelcimento, int idTipoProduto)
        {
            var result = await base._context.produtos
                .Where(x => x.estabelecimento == idEstabelcimento && x.Tipo==idTipoProduto).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<tipoProduto>> GetTipoProdutos()
        {
            var result = await base._context.tipoProduto.ToListAsync();

            return result;
        }
    }
}
