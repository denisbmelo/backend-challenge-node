using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;
using WebApplication1.Services.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
        private readonly IClienteService _clienteService;

        public ClienteController (IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("incluir-cliente")]
        public async Task<ActionResult<int>> IncluirCliente( ClienteModel cliente)
        {
            return StatusCode(await _clienteService.IncluirCliente(cliente));
        }

     
    }
}
