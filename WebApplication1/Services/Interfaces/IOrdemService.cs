using WebApplication1.Models;
using WebApplication1.Services.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IOrdemService
    {
        Task<Ordens> GetOrdem(int id);
        Task<int> IncluirOrdem(OrdemModel model);
    }
}
