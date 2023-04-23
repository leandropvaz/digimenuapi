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

        public Guid AbrirComanda(ComandaModel objcomanda)
        {
            comanda entityComanda = _mapper.Map<comanda>(objcomanda);
            entityComanda.status = Guid.Parse("374E8939-37E9-4390-9F34-2D457479844C");
            _comandaRepository.Add(entityComanda);
            return entityComanda.id;
        }

        public ComandaModel FecharComanda(Guid id)
        {
            comanda entity = _comandaRepository.GetById(id, p => p.comanda_itens);
            entity.status = Guid.Parse("8BFDE2E8-6F77-454D-A66E-23A33FF2EDD6");
            _comandaRepository.Update(entity);
            var outputModel = _mapper.Map<ComandaModel>(entity);
            return outputModel;
        }

        public ComandaModel GetComanda(Guid id)        {
            var entity = _comandaRepository.GetById(id, p => p.comanda_itens);
            var outputModel = _mapper.Map<ComandaModel>(entity);
            return outputModel;
        }

        public ComandaModel IncluirItemComanda(List<Comanda_Itens_Model> comanda_Itens)
        {
            var entityComandaItens = _mapper.Map<IEnumerable<comanda_itens>>(comanda_Itens);
            _comanda_itensRepository.AddRange(entityComandaItens);

            var entity = _comandaRepository.GetById(Guid.Parse("BDCF5759-058B-440A-811D-03735C521F94"), p => p.comanda_itens);
            var outputModel = _mapper.Map<ComandaModel>(entity);
            return outputModel;
        }
    }
}
