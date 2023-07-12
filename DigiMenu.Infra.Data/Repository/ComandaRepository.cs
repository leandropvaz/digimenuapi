using DigiMenu.Domain.Models.Response;
using DigiMenu.Infra.Data.EF;
using DigiMenu.Infra.Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

  

        public async Task<IEnumerable<comanda>> GetComandaById(int comanda)
        {
            var result = await base._context.comanda
              .Include(x => x.pedidos)
              .Where(x => x.id == comanda).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<PreviewComanda>> GetPreviewComanda(int comanda)
        {
            try
            {
                var resultado = (from pi in _context.pedido_itens
                                 join p in _context.pedidos on pi.pedido equals p.id
                                 join pr in _context.produtos on pi.produto equals pr.id
                                 join c in _context.comanda on p.comanda equals c.id
                                 where c.id == comanda
                                 select new { pi, p, pr, c })
                   .AsEnumerable()
                   .GroupBy(
                       x => new { x.pr.nome, x.pr.preco },
                       x => new { x.pi, x.pr })
                   .OrderBy(g => g.Key.nome)
                   .Select((g, index) => new PreviewComanda
                   {
                       item = (index + 1).ToString(),
                       descricao = g.Key.nome,
                       precoUnitario = g.Key.preco.ToString(),
                       quantidade = g.Sum(x => x.pi.quantidade).ToString(),
                       precoTotal = (g.Sum(x => x.pr.preco * x.pi.quantidade)).ToString("###,###,##0.00", CultureInfo.GetCultureInfo("pt-BR"))
                   })
                   .ToList();



                return resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<comanda>> GetComandasbyEstabelecimentos(int idestabelecimento)
        {
            var query = from c in _context.comanda
                        join m in _context.mesa on c.mesa equals m.id
                        where m.estabelecimento == idestabelecimento
                        select c;

            var result = await query.ToListAsync();

            return result;
        }

        public string ValorComanda(int comanda)
        {
            try
            {
                var result = (from pedItem in _context.pedido_itens
                              join ped in _context.pedidos on pedItem.pedido equals ped.id
                              join com in _context.comanda on ped.comanda equals com.id
                              join prd in _context.produtos on pedItem.produto equals prd.id
                              where com.id == comanda
                              group new { pedItem, prd } by com.id into g
                              select new
                              {
                                  Valor = g.Sum(x => x.prd.preco * Convert.ToDecimal(x.pedItem.quantidade))
                              }).FirstOrDefault();

                return result.Valor.ToString("###,###,##0.00", CultureInfo.GetCultureInfo("pt-BR"));
            }
            catch (Exception)
            {
                return "0";
            }

        }

        public string ValorCreditoComanda(int comanda)
        {
            try
            {
                var result = (from credito in _context.comanda_credito
                          where credito.comanda == comanda
                          select credito.valor).Sum();

            return result.ToString("###,###,##0.00", CultureInfo.GetCultureInfo("pt-BR"));
            }
            catch (Exception)
            {
                return "0";
            }

        }

    }
}
