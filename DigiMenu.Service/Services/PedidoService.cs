using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using AutoMapper;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using DigiMenu.Domain.Models.Request;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DigiMenu.Service.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IMapper _mapper;
        private PedidoRepository _pedidoRepository;

        public PedidoService(PedidoRepository pedidoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
        }

        public int FazerPedido(PedidoRequest pedido)
        {
            pedidos entity = _mapper.Map<pedidos>(pedido);
            _pedidoRepository.Add(entity);
            return entity.id;
        }

        public IEnumerable<PedidoModel> GetPedidos(int comanda)
        {
            var entity = _pedidoRepository.GetPedidoByComanda(comanda).GetAwaiter().GetResult();
            var outputModel = _mapper.Map<IEnumerable<PedidoModel>>(entity);

            foreach (var pedido in outputModel)
            {
                pedido.dataPedidoFeito = Convert.ToDateTime(pedido.dataPedidoFeito).ToString("dd/MM/yyyy HH:mm:ss", new CultureInfo("pt-BR"));
                pedido.responsavel = _pedidoRepository.GetNomeUsuario(Convert.ToInt32(pedido.responsavel));
            }
            return outputModel;
        }
    }
}
