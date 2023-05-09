//using DigiMenu.Domain.Interfaces;
//using DigiMenu.Domain.Models;
//using DigiMenu.Infra.Data.EF.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace DigiMenu.Api.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class DigiMenuController : ControllerBase
//    {

//        private readonly ILogger<DigiMenuController> _logger;
//        private IDigiMenuService<comanda> _baseEstabelecimentoService;

//        public DigiMenuController(ILogger<DigiMenuController> logger, IDigiMenuService<comanda> baseEstabelecimentoService)
//        {
//            _logger = logger;
//            _baseEstabelecimentoService= baseEstabelecimentoService;
//        }

//        [HttpGet]
//        [Route("Estabelicimentos")]
//        public IActionResult GetEstabelicimentos()
//        {
//           // return Ok();
//             return Execute(() => _baseEstabelecimentoService.GetEstabelecimentos<EstabelecimentoModel>());            
//        }
//        //[HttpGet]
//        //[Route("Cardapio")]
//        //public IEnumerable<dynamic> GetCardapio()
//        //{
//        //    return null;
//        //}
        
//        private IActionResult Execute(Func<object> func)
//        {
//            try
//            {
//                var result = func();

//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex);
//            }
//        }
//    }
//}