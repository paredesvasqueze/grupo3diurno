using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class DetallecompraDomain
    {
        private readonly DetallecompraRepository _DetallecompraRepository;

        public DetallecompraDomain(DetallecompraRepository DetallecompraRepository)
        {

            _DetallecompraRepository = DetallecompraRepository;
        }

        public IEnumerable<Detallecompra> ObtenerDetallecompraTodos()
        {
            try
            {
                return _DetallecompraRepository.ObtenerDetallecompraTodos();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int InsertDetallecompra(Detallecompra oDetallecompra)
        {
            try
            {
                return _DetallecompraRepository.InsertDetallecompra(oDetallecompra);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int ActualizarDetallecompra(Detallecompra oDetallecompra)
        {
            try
            {
                return _DetallecompraRepository.ActualizarDetallecompra(oDetallecompra);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int EliminarDetallecompra(Detallecompra oDetallecompra)
        {
            try
            {
                return _DetallecompraRepository.EliminarDetallecompra(oDetallecompra);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
