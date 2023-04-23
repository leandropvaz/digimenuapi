using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Infra.Data.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComandaController : ControllerBase
    {

        private readonly ILogger<ComandaController> _logger;
        private IComandaService _comandaService;

        public ComandaController(ILogger<ComandaController> logger, IComandaService comandaService)
        {
            _logger = logger;
            _comandaService = comandaService;
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Execute(() => _comandaService.GetComanda(id));
        }
        [HttpPost]
        [Route("AbrirComanda")]
        public IActionResult AbrirComanda([FromBody] ComandaModel comanda)
        {
            return Execute(() => _comandaService.AbrirComanda(comanda));
        }
        [HttpPost]
        [Route("IncluirItem")]
        public IActionResult IncluirItemComanda([FromBody] List<Comanda_Itens_Model> comandaItens)
        {
            return Execute(() => _comandaService.IncluirItemComanda(comandaItens));
        }
        [HttpPut]
        [Route("FecharComanda")]
        public IActionResult FecharComanda(Guid id)
        {
            return Execute(() => _comandaService.FecharComanda(id));
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