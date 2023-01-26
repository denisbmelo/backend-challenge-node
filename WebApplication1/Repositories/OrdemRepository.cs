using Dapper;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class OrdemRepository :IOrdensRepository
    {
        IConfiguration _configuration;

        public OrdemRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var conn = _configuration.GetSection("ConnectionStrings").GetSection("TesteIdeal").Value;

            return conn;
        }

        public async Task<int> Add(Ordens ordem)
        {
            var conn = GetConnection();

            using (var conexao = new SqlConnection(conn))
            {
                try
                {
                    conexao.Open();

                    var query = $"Insert into {nameof(Ordens)} " +
                                            $"({nameof(Ordens.IdCliente)}, " +
                                            $"{nameof(Ordens.IdProduto)} , " +
                                            $"{nameof(Ordens.ValorCompra)} , " +
                                            $"{nameof(Ordens.QtdCompra)} , " +
                                            $"{nameof(Ordens.TotalCompra)}, " +
                                            $"{nameof(Ordens.DtOrdem)}) " +
                                $" VALUES ( @{nameof(Ordens.IdCliente)}, " +
                                            $"@{nameof(Ordens.IdProduto)} , " +
                                            $"@{nameof(Ordens.ValorCompra)} , " +
                                            $"@{nameof(Ordens.QtdCompra)} , " +
                                            $"@{nameof(Ordens.TotalCompra)}, " +
                                            $"@{nameof(Ordens.DtOrdem)}); " +
                                "Select CAST(SCOPE_IDENTITY()as INT)";

                    var ret = conexao.Execute(query, ordem);

                    return ret;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

           
        }
    
        public async Task <Ordens> Get (int idTransacao)
        {
            var conn = GetConnection();

            var ret = new Ordens();

            using (var conexao = new SqlConnection(conn))
            {
                try
                {
                    conexao.Open();

                    var query = $"Select   {nameof(Ordens.IdTransacao)}," +
                                            $"{nameof(Ordens.IdCliente)}, " +
                                            $"{nameof(Ordens.IdProduto)} , " +
                                            $"{nameof(Ordens.ValorCompra)} , " +
                                            $"{nameof(Ordens.QtdCompra)} , " +
                                            $"{nameof(Ordens.TotalCompra)}, " +
                                            $"{nameof(Ordens.DtOrdem)} " +
                              $"FROM {nameof(Ordens)}" +
                              $"Where {nameof(Ordens)}.{nameof(Ordens.IdTransacao)}  = {idTransacao}";

                     ret =  conexao.Query<Ordens>(query).FirstOrDefault();
                }
                catch (Exception e)
                {

                    throw e;
                }

                return ret;
            }
        }
    }
}
