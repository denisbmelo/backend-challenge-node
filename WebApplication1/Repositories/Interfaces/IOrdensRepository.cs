using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IOrdensRepository
    {
        Task<int> Add(Ordens ordem);
        Task<Ordens> Get(int idTransacao);
    }
}
