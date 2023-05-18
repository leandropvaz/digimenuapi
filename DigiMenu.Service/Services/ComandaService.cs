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

        //public ComandaModel FecharComanda(int id)
        //{
        //    comanda entity = _comandaRepository.GetById(id, p => p.comanda_itens);
        //    entity.status = 2;
        //    _comandaRepository.Update(entity);
        //    var outputModel = _mapper.Map<ComandaModel>(entity);
        //    return outputModel;
        //}

        public ComandaModel GetComanda(int id)
        {
            var entity = _comandaRepository.GetById(id, p => p.pedidos);
            var outputModel = _mapper.Map<ComandaModel>(entity);
            return outputModel;
        }
    }
}
