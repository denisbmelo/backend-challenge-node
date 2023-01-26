using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;
using WebApplication1.Services.Models;

namespace WebApplication1.Services
{
    public class ProdutosService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosService (IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ;
        }

        public async Task<int> IncluirProduto(ProdutoModel model)
        {
            var produto = new Produtos();

            var ret = 0;

            try
            {
                produto.Ativo = true;
                produto.Nome = model.NomeProduto;

                var insert = await _produtoRepository.Add(produto);

                ret = insert;
            }

            catch (Exception e)
            {

                throw e;
            }

            return ret;
        }
    
    }
}
