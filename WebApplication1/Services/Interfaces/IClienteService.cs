using WebApplication1.Services.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IClienteService
    {
        Task<int> IncluirCliente(ClienteModel model);
    }
}
