using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemController : ControllerBase
    {
        private readonly Logger<OrdemController> _logger;

        public OrdemController (Logger<OrdemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("obtem-ordem")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        [Route("incluir-ordem")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

     
    }
}
