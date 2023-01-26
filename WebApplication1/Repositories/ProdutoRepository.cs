using Dapper;
using System.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        IConfiguration  _configuration;

        public ProdutoRepository (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var conn = _configuration.GetSection("ConnectionStrings").GetSection("TesteIdeal").Value;

            return conn;
        }

        public async Task <int> Add( Produtos produto)
        {
            var conn = GetConnection();

            using (var conexao = new SqlConnection(conn))
            {
                try
                {
                    conexao.Open();

                    var query = $"Insert into {nameof(Produtos)} ({nameof(Produtos.Nome)}, {nameof(Produtos.Ativo)}) " +
                                $" VALUES (@{nameof(Produtos.Nome)}, @{nameof(Produtos.Ativo)}); " +
                                "Select CAST(SCOPE_IDENTITY()as INT)";

                    var ret = conexao.Execute(query, produto);

                    return ret;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

        }
    }
}
