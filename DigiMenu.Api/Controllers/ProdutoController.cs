using DigiMenu.Domain.Interfaces;
using DigiMenu.Domain.Models;
using DigiMenu.Domain.Models.Request;
using DigiMenu.Infra.Data.EF.Models;
using DigiMenu.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Get(int id)
        {
             return Execute(() => _produtoservice.GetProdutoById(id));
        }

        [HttpGet]
        [Route("ProdutosByEstabelecimento")]
        public IActionResult GetProdutosByEstabelecimento(int idEstabelecimento)
        {
            return Execute(() => _produtoservice.GetProdutosByEstabelecimento(idEstabelecimento));
        }


        [HttpGet]
        [Route("ProdutosByTipo")]
        public IActionResult GetProdutosByTipo(int idEstabelecimento, int idTipoProduto)
        {
            return Execute(() => _produtoservice.GetProdutosByTipo(idEstabelecimento, idTipoProduto));
        }

        [HttpGet]
        [Route("TipoProdutos")]
        public IActionResult GetTipoProdutos()
        {
            return Execute(() => _produtoservice.GetTipoProdutos());
        }

        [HttpPost]
        [Route("admin/CadastrarProduto")]
        public IActionResult CadastrarProduto([FromBody] ProdutoModel produto)
        {
            return Execute(() => _produtoservice.CadastrarProduto(produto));
        }

        [HttpDelete]
        [Route("admin/DeletarProduto")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            return Execute(() => _produtoservice.DeletarProduto(id));
        }

        [HttpPut]
        [Route("admin/AlterarProduto")]
        public async Task<IActionResult> AlterarProduto([FromBody] ProdutoModel produto)
        {
            return Execute(() => _produtoservice.AlterarProduto(produto));
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