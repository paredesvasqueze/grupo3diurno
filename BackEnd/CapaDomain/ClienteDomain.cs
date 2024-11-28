using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class ClienteDomain
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteDomain(ClienteRepository clienteRepository)
        {
           
                _clienteRepository = clienteRepository;     
        }

        public IEnumerable<Cliente> ObtenerclienteTodos()
        {
            try
            {
                return _clienteRepository.ObtenerclienteTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int Insertarcliente(Cliente ocliente)
        {
            try
            {
                return _clienteRepository.Insertarcliente(ocliente);
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        public int Actualizarcliente(Cliente ocliente)
        {
            try
            {
                return _clienteRepository.Actualizarcliente(ocliente);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int eliminarcliente(Cliente ocliente)
        {
            try
            {
                return _clienteRepository.eliminarcliente(ocliente.nidcliente);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
