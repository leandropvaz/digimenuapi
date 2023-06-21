using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;

namespace DigiMenu.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Result<UsuarioModel> GetUsuario(int id);
        Result<UsuarioModel> CadastrarUsuario(CadastrarUsuarioRequest inputModel);
       
    }
}
