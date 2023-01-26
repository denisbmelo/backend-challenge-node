using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;
using WebApplication1.Services.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly Logger<ProdutoController> _logger;
        private readonly IProdutoService _service;

        public ProdutoController (Logger<ProdutoController> logger , IProdutoService produtoService)
        {
            _logger = logger;
            _service = produtoService;
        }

        [HttpGet]
        [Route("incluir-produto")]
        public async Task<ActionResult<int>> IncluirCliente(ProdutoModel produto)
        {
            return StatusCode(await _service.IncluirProduto(produto));
        }

       
       
    }
}
