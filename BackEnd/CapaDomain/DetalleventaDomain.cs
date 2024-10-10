using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class detalleventaDomain
    {
        private readonly detalleventaRepository _detalleventaRepository;

        public detalleventaDomain(detalleventaRepository detalleventaRepository)
        {
           
                _detalleventaRepository = detalleventaRepository;     
        }

        public IEnumerable<detalleventa> ObtenerdetalleventaTodos()
        {
            try
            {
                return _detalleventaRepository.ObtenerdetalleventaTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int Insertardetalleventa(detalleventa odetalleventa)
        {
            try
            {
                return _detalleventaRepository.Insertardetalleventa(odetalleventa);
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        public int actualizardetalleventa(detalleventa odetalleventa)
        {
            try
            {
                return _detalleventaRepository.actualizardetalleventa(odetalleventa);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int eliminardetalleventa(detalleventa odetalleventa)
        {
            try
            {
                return _detalleventaRepository.eliminardetalleventa(odetalleventa);
            }
            catch (Exception)
            {
                throw;
            }

        }




    }
}
