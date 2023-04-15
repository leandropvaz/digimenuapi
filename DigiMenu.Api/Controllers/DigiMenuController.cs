using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DigiMenuController : ControllerBase
    {

        private readonly ILogger<DigiMenuController> _logger;

        public DigiMenuController(ILogger<DigiMenuController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Estabelicimentos")]
        public IEnumerable<dynamic> GetEstabelicimentos()
        {
            return null;
        }
        [HttpGet]
        [Route("Cardapio")]
        public IEnumerable<dynamic> GetCardapio()
        {
            return null;
        }
        [HttpGet]
        [Route("ParcialConta")]
        public IEnumerable<dynamic> GetParcialConta()
        {
            return null;
        }
        [HttpPost]
        [Route("AbreConta")]
        public IEnumerable<dynamic> AbreConta()
        {
            return null;
        }

        [HttpPost]
        [Route("EnviaPedido")]
        public IEnumerable<dynamic> EnviaPedido()
        {
            return null;
        }
        [HttpPost]
        [Route("FechaConta")]
        public IEnumerable<dynamic> FechaConta()
        {
            return null;
        }
    }
}