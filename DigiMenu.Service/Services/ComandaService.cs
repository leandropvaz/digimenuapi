using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using AutoMapper;
using DigiMenu.Infra.Data.EF.Models;

namespace DigiMenu.Service.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<comanda> _comandaRepository;
        private readonly IRepository<comanda_itens> _comanda_itensRepository;

        public ComandaService(IRepository<comanda> comandaRepository, IRepository<comanda_itens> comanda_itensRepository, IMapper mapper)
        {
            _mapper = mapper;
            _comandaRepository = comandaRepository;
            _comanda_itensRepository= comanda_itensRepository;
        }

        public int AbrirComanda(ComandaModel objcomanda)
        {
            comanda entityComanda = _mapper.Map<comanda>(objcomanda);
            entityComanda.status = 1;
            _comandaRepository.Add(entityComanda);
            return entityComanda.id;
        }

        public ComandaModel FecharComanda(int id)
        {
            comanda entity = _comandaRepository.GetById(id, p => p.comanda_itens);
            entity.status = 2;
            _comandaRepository.Update(entity);
            var outputModel = _mapper.Map<ComandaModel>(entity);
            return outputModel;
        }

        public ComandaModel GetComanda(int id)        {
            var entity = _comandaRepository.GetById(id, p => p.comanda_itens);
            var outputModel = _mapper.Map<ComandaModel>(entity);
            return outputModel;
        }

        public ComandaModel IncluirItemComanda(List<Comanda_Itens_Model> comanda_Itens)
        {
            var entityComandaItens = _mapper.Map<IEnumerable<comanda_itens>>(comanda_Itens);
            _comanda_itensRepository.AddRange(entityComandaItens);

            var entity = _comandaRepository.GetById(1, p => p.comanda_itens);
            var outputModel = _mapper.Map<ComandaModel>(entity);
            return outputModel;
        }
    }
}
