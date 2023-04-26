using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Infra.Data.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly ILogger<ProdutoController> _logger;
        private IProdutoService _produtoservice;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService)
        {
            _logger = logger;
            _produtoservice = produtoService;
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Execute(() => _produtoservice.GetProdutos(id));
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