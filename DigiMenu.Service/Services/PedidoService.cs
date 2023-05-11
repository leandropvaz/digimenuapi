using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using AutoMapper;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using DigiMenu.Domain.Models.Request;

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
    }
}
