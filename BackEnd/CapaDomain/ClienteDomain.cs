using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class clienteDomain
    {
        private readonly clienteRepository _clienteRepository;

        public clienteDomain(clienteRepository clienteRepository)
        {
           
                _clienteRepository = clienteRepository;     
        }

        public IEnumerable<cliente> ObtenerclienteTodos()
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

        public int Insertarcliente(cliente ocliente)
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


        public int actualizarcliente(cliente ocliente)
        {
            try
            {
                return _clienteRepository.actualizarcliente(ocliente);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int eliminarcliente(cliente ocliente)
        {
            try
            {
                return _clienteRepository.eliminarcliente(ocliente);
            }
            catch (Exception)
            {
                throw;
            }

        }




    }
}
