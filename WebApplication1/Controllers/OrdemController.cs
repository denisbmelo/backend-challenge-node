using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;
using WebApplication1.Services.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemController : ControllerBase
    {
        private readonly Logger<OrdemController> _logger;
        private readonly IOrdemService _ordemService;

        public OrdemController (Logger<OrdemController> logger, IOrdemService ordemService)
        {
            _logger = logger;
            _ordemService = ordemService;

        }

        [HttpGet]
        [Route("obtem-ordem")]
        public async Task<Ordens> GetOrdem ([FromQuery] int id)
        {
            return (await _ordemService.GetOrdem(id));
        }
        [HttpPost]
        [Route("incluir-ordem")]
        public async Task<ActionResult<int>> IncluirCliente(OrdemModel ordem)
        {
            return StatusCode(await _ordemService.IncluirOrdem(ordem));
        }


    }
}
