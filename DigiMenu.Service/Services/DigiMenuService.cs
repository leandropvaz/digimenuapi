
using AutoMapper;
using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;

namespace DigiMenu.Service.Services
{
    public class DigiMenuService<TEntity> : IDigiMenuService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public DigiMenuService(IRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        //public IEnumerable<TOutputModel> GetEstabelecimentos<TOutputModel>() where TOutputModel : class
        //{
        //    //var entities = _baseRepository.Select();

        //    //var outputModels = entities.Select(s => _mapper.Map<TOutputModel>(s));

        //    //return outputModels;
        //}

      
    }
}
