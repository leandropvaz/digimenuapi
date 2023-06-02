using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using AutoMapper;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using DigiMenu.Domain.Models.Request;

namespace DigiMenu.Service.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IMapper _mapper;
        private ComandaRepository _comandaRepository;

        public ComandaService(ComandaRepository comandaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _comandaRepository = comandaRepository;
        }

        public int AbrirComanda(AbrirComandaRequest objcomanda)
        {
            comanda entityComanda = _mapper.Map<comanda>(objcomanda);
            entityComanda.status = 1;
            _comandaRepository.Add(entityComanda);
            return entityComanda.id;
        }

        public bool FecharComanda(int id)
        {
            comanda entity = _comandaRepository.GetById(id);
            entity.status = 2;
            _comandaRepository.Update(entity);
            return true;
        }

        public ComandaModel GetComanda(int id)
        {
            var entity = _comandaRepository.GetById(id, p => p.pedidos);
            var outputModel = _mapper.Map<ComandaModel>(entity);
            outputModel.valor = _comandaRepository.ValorComanda(id);
            outputModel.valorCredito = _comandaRepository.ValorCreditoComanda(id);

            return outputModel;
        }
        public decimal ValorComanda(int comanda)
        {
            return Convert.ToDecimal(_comandaRepository.ValorComanda(comanda));
        }
        public decimal ValorCreditoComanda(int comanda)
        {
            return Convert.ToDecimal(_comandaRepository.ValorCreditoComanda(comanda));
        }
    }
}
