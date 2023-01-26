using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;
using WebApplication1.Services.Models;

namespace WebApplication1.Services
{
    public class OrdemService : IOrdemService
    {
        private readonly IOrdensRepository _ordensRepository;

        public OrdemService(IOrdensRepository ordensRepository)
        {
            _ordensRepository = ordensRepository;
        }

        public async Task <Ordens> GetOrdem(int id)
        {
            var ret = new Ordens();

            try
            {
                var select = (await _ordensRepository.Get(id));

                ret = select;

                return ret;
            }
            catch (Exception e )
            {

                throw e;
            }
        }
        public async Task<int> IncluirOrdem(OrdemModel model)
        {
            var ordem = new Ordens();

            var ret = 0;

            try
            {
                ordem.TotalCompra = model.totalCompra;
                ordem.QtdCompra = model.qtdCompra;
                ordem.ValorCompra = model.valorCompra;
                ordem.DtOrdem = model.dtOrdem;
                ordem.IdCliente = model.idCliente;
                ordem.IdProduto= model.idProduto;

                var insert = await _ordensRepository.Add(ordem);

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
