using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Infra.Data.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstabelecimentoController : ControllerBase
    {

        private readonly ILogger<EstabelecimentoController> _logger;
        private IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentoController(ILogger<EstabelecimentoController> logger, IEstabelecimentoService estabelecimentoService)
        {
            _logger = logger;
            _estabelecimentoService = estabelecimentoService;
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
             return Execute(() => _estabelecimentoService.GetEstabelecimento(id));
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