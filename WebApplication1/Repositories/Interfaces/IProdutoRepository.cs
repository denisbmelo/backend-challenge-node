using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<int> Add(Produtos produto);
    }
}
