using WebApplication1.Services.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<int> IncluirProduto(ProdutoModel model);
    }
}
