using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;

namespace DigiMenu.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Result<UsuarioModel> GetUsuario(int id);
        IEnumerable<UsuarioModel> CadastrarUsuario(CadastrarUsuarioRequest inputModel);
        IEnumerable<UsuarioModel> LoginSistema(LoginRequest inputModel);
        IEnumerable<UsuarioModel> LoginGoogle(LoginRequestGoogle inputModel);

        

    }
}
