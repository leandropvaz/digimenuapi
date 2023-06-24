using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using AutoMapper;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Infra.Data.Repository;
using DigiMenu.Domain.Models.Request;
using DigiMenu.Domain;
using System.Collections.Generic;

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

        public IEnumerable<UsuarioModel> CadastrarUsuario(CadastrarUsuarioRequest usuarioRequest)
        {
            if (!_usuarioRepository.GetUsuarioByCPF(usuarioRequest.cpf).GetAwaiter().GetResult().Any())
            {
                usuario entity = _mapper.Map<usuario>(usuarioRequest);
                _usuarioRepository.Add(entity);
                var outputModel = _mapper.Map<IEnumerable<UsuarioModel>>(new List<usuario> { entity });

                return outputModel;
            }
            else
            {
                
                return null;
            }

        }
        public Result<UsuarioModel> GetUsuario(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<UsuarioModel> LoginSistema(LoginRequest user)
        {
            var entity = _usuarioRepository.LoginSistema(user.cpf, user.senha).GetAwaiter().GetResult();
            var outputModel = _mapper.Map<IEnumerable<UsuarioModel>>(entity);
            return outputModel;
        }

        public IEnumerable<UsuarioModel> LoginGoogle(LoginRequestGoogle user)
        {
            var entity = _usuarioRepository.LoginGoogle(user.email).GetAwaiter().GetResult();
            var outputModel = _mapper.Map<IEnumerable<UsuarioModel>>(entity);
            return outputModel;
        }
    }
}
