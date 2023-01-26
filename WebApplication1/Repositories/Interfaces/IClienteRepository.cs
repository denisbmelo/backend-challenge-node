using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<int> Add(Cliente cliente);
    }
}
