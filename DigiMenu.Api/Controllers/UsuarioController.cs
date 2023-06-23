using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;
using DigiMenu.Infra.Data.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        private IUsuarioService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _usuarioService.GetUsuario(id));
        }

        //[HttpGet]
        //[Route("GetStatusComanda")]
        //public IActionResult GetStatusComanda(int id)
        //{
        //    return Execute(() => _comandaService.GetStatusComanda(id));
        //}

        [HttpPost]
        [Route("CadastrarUsuario")]
        public IActionResult CadastrarUsuario([FromBody] CadastrarUsuarioRequest comanda)
        {
            return Execute(() => _usuarioService.CadastrarUsuario(comanda));
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUsuario([FromBody] LoginRequest comanda)
        {
            return Execute(() => _usuarioService.LoginUsuario(comanda));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}