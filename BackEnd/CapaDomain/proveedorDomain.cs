using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class proveedorDomain
    {
        private readonly proveedorrepository _proveedorRepository;

        public proveedorDomain(proveedorrepository proveedorRepository)
        {

            _proveedorRepository = proveedorRepository;
        }

        public IEnumerable<proveedor> ObtenerproveedorTodos()
        {
            try
            {
                return _proveedorRepository.ObtenerproveedorTodos();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int Insertarproveedor(proveedor oproveedor)
        {
            try
            {
                return _proveedorRepository.Insertarproveedor(oproveedor);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int Actualizarproveedor(proveedor oproveedor)
        {
            try
            {
                return _proveedorRepository.Actualizarproveedor(oproveedor);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int Eliminarproveedor(proveedor oproveedor)
        {
            try
            {
                return _proveedorRepository.Eliminarproveedor(oproveedor);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
