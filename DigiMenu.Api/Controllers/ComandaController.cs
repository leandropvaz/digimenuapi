using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;
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
        public IActionResult Get(int id)
        {
            
            return Execute(() => _comandaService.GetComanda(id));
        }
        [HttpGet]
        [Route("GetStatusComanda")]
        public IActionResult GetStatusComanda(int id)
        {
            return Execute(() => _comandaService.GetStatusComanda(id));
        }
        [HttpGet]
        [Route("ValorComanda")]
        public IActionResult ValorComanda(int idComanda)
        {
            return Execute(() => _comandaService.ValorComanda(idComanda));
        }

        [HttpGet]
        [Route("ValorCreditoComanda")]
        public IActionResult ValorCreditoComanda(int idComanda)
        {
            return Execute(() => _comandaService.ValorCreditoComanda(idComanda));
        }
        [HttpPost]
        [Route("AbrirComanda")]
        public IActionResult AbrirComanda([FromBody] AbrirComandaRequest comanda)
        {
            return Execute(() => _comandaService.AbrirComanda(comanda));
        }


        [HttpPost]
        [Route("FecharComanda")]

        public IActionResult FecharComanda(int idComanda)
        {

            return Execute(() => _comandaService.FecharComanda(idComanda));
        }

        [HttpGet]
        [Route("GetPreviewComanda")]
        public IActionResult GetPreviewComanda(int idComanda)
        {
            return Execute(() => _comandaService.GetPreviewComanda(idComanda));
        }

        [HttpGet]
        [Route("admin/GetComandasbyEstabelecimentos")]
        public IActionResult GetComandasbyEstabelecimentos(int idestabelecimento)
        {
            return Execute(() => _comandaService.GetComandasbyEstabelecimentos(idestabelecimento));
        }

        [HttpGet]
        [Route("GetValoresComanda")]
        public IActionResult GetValoresComanda(int idcomanda)
        {
            return Execute(() => _comandaService.GetValoresComanda(idcomanda));
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