using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;
using WebApplication1.Services.Models;

namespace WebApplication1.Services
{
    public class ClienteService :IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService (IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<int> IncluirCliente (ClienteModel model)
        {
            var cliente = new Cliente();

            var ret = 0;

            try
            {
                cliente.Cpf = model.Cpf;
                cliente.Ativo = true;
                cliente.Nome= model.Nome;
                cliente.DtNascimento= model.DtNascimento;

                var insert = await _clienteRepository.Add(cliente);

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
