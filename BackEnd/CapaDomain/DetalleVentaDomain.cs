using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class DetalleVentaDomain
    {
        private readonly DetalleVentaRepository _DetalleVentaRepository;

        public DetalleVentaDomain(DetalleVentaRepository DetalleVentaRepository)
        {

            _DetalleVentaRepository = DetalleVentaRepository;
        }

        public IEnumerable<DetalleVenta> ObtenerDetalleVentaTodos()
        {
            try
            {
                return _DetalleVentaRepository.ObtenerDetalleVentaTodos();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int InsertDetalleVenta(DetalleVenta oDetalleVenta)
        {
            try
            {
                return _DetalleVentaRepository.InsertDetalleVenta(oDetalleVenta);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int ActualizarDetalleVenta(DetalleVenta oDetalleVenta)
        {
            try
            {
                return _DetalleVentaRepository.ActualizarDetalleVenta(oDetalleVenta);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int EliminarDetalleVenta(DetalleVenta oDetalleVenta)
        {
            try
            {
                return _DetalleVentaRepository.EliminarDetalleVenta(oDetalleVenta);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
