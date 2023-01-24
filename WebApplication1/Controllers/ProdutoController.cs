using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly Logger<ProdutoController> _logger;

        public ProdutoController (Logger<ProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("incluir-produto")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
