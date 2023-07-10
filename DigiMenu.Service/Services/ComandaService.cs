using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using AutoMapper;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using DigiMenu.Domain.Models.Request;
using DigiMenu.Domain;
using DigiMenu.Domain.Models.Response;

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

        public int FecharComanda(int id)
        {
            comanda entity = _comandaRepository.GetById(id);
            entity.status = 2;
            _comandaRepository.Update(entity);
            return 1;
        }
        public ComandaModel GetComanda(int id)
        {
            var entity = _comandaRepository.GetById(id, p => p.pedidos);
            var outputModel = _mapper.Map<ComandaModel>(entity);
            outputModel.valor = _comandaRepository.ValorComanda(id);
            outputModel.valorCredito = _comandaRepository.ValorCreditoComanda(id);

            return (outputModel);
        }
        public int GetStatusComanda(int id)
        {
            comanda entity = _comandaRepository.GetById(id);
            return entity.status;
        }
        public decimal ValorComanda(int comanda)
        {
            return Convert.ToDecimal(_comandaRepository.ValorComanda(comanda));
        }
        public decimal ValorCreditoComanda(int comanda)
        {
            return Convert.ToDecimal(_comandaRepository.ValorCreditoComanda(comanda));
        }

        public IEnumerable<PreviewComanda> GetPreviewComanda(int id)
        {
            var entity = _comandaRepository.GetPreviewComanda(id).GetAwaiter().GetResult();
            return entity;
            
        }

        public IEnumerable<ComandaModel> GetComandasbyEstabelecimentos(int idestabelecimento)
        {
            var entity = _comandaRepository.GetComandasbyEstabelecimentos(idestabelecimento).GetAwaiter().GetResult(); 
            var outputModel = _mapper.Map<IEnumerable<ComandaModel>>(entity);
            return outputModel;
        }
    }
}
