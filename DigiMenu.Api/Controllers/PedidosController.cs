using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;
using DigiMenu.Infra.Data.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {

        private readonly ILogger<PedidosController> _logger;
        private IPedidoService _pedidoService;

        public PedidosController(ILogger<PedidosController> logger, IPedidoService pedidoService)
        {
            _logger = logger;
            _pedidoService = pedidoService;
        }

        
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Execute(() => _comandaService.GetComanda(id));
        //}
        [HttpPost]
        [Route("FazerPedido")]
        public IActionResult FazerPedido([FromBody] PedidoRequest pedido)
        {
            return Execute(() => _pedidoService.FazerPedido(pedido));
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