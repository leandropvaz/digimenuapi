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

                return result.Valor.ToString();
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

            return result.ToString();
            }
            catch (Exception)
            {
                return "0";
            }

        }

    }
}
