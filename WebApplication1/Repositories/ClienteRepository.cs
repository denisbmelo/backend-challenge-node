using Dapper;
using System.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class ClienteRepository: IClienteRepository
    {
        IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var conn = _configuration.GetSection("ConnectionStrings").GetSection("TesteIdeal").Value;

            return conn;
        }

        public async Task<int> Add(Cliente cliente)
        {
            var conn = GetConnection();

            using (var conexao = new SqlConnection(conn))
            {
                try
                {
                    conexao.Open();

                    var query = $"Insert into {nameof(Cliente)} " +
                                            $"({nameof(Cliente.Nome)}," +
                                            $"{nameof(Cliente.Cpf)}," +
                                            $"{nameof(Cliente.DtNascimento)}, " +
                                            $"{nameof(Cliente.Ativo)}) " +
                                   $" VALUES (@{nameof(Cliente.Nome)}," +
                                            $"@{nameof(Cliente.Cpf)}," +
                                            $"@{nameof(Cliente.DtNascimento)}, " +
                                            $"@{nameof(Cliente.Ativo)})" +
                                "Select CAST(SCOPE_IDENTITY()as INT)";

                    var ret = conexao.Execute(query, cliente);

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
