using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using AutoMapper;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using DigiMenu.Domain.Models.Request;
using DigiMenu.Domain;

namespace DigiMenu.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public Result<UsuarioModel> CadastrarUsuario(CadastrarUsuarioRequest usuarioRequest)
        {
            usuario entity = _mapper.Map<usuario>(usuarioRequest);
            _usuarioRepository.Add(entity);
            var outputModel = _mapper.Map<UsuarioModel>(entity);
            return Result.Ok(outputModel);
        }
        public Result<UsuarioModel> GetUsuario(int id)
        {
            throw new NotImplementedException();
        }
        public UsuarioModel LoginUsuario(LoginRequest user)
        {
            var entity = _usuarioRepository.Login(user.cpf, user.senha);
            var outputModel = _mapper.Map<UsuarioModel>(entity);
            return outputModel;
        }
    }
}
