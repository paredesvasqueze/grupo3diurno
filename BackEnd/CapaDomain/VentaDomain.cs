using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class VentaDomain
    {
        private readonly VentaRepository _VentaRepository;

        public VentaDomain(VentaRepository VentaRepository)
        {

            _VentaRepository = VentaRepository;
        }

        public IEnumerable<venta> ObtenerventaTodos()
        {
            try
            {
                return _VentaRepository.ObtenerventaTodos();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int Insertarventa(venta oventa)
        {
            try
            {
                return _VentaRepository.Insertarventa(oventa);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int Actualizarventa(venta oventa)
        {
            try
            {
                return _VentaRepository.Actualizarventa(oventa);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int Eliminarventa(venta oventa)
        {
            try
            {
                return _VentaRepository.Eliminarventa(oventa);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
