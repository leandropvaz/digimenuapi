using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using AutoMapper;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;

namespace DigiMenu.Service.Services
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly IMapper _mapper;
        private EstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoService(IMapper mapper, EstabelecimentoRepository estabelecimentoRepository)
        {
            _mapper = mapper;
            _estabelecimentoRepository = estabelecimentoRepository;
        }


        public IEnumerable<EstabelecimentoModel> GetEstabelecimento(int id)
        {
            var entity = _estabelecimentoRepository.GetEstabelecimentoById(id).GetAwaiter().GetResult();
            var outputModel = _mapper.Map<IEnumerable<EstabelecimentoModel>>(entity);
            return outputModel;
        }
    }
}
