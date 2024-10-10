using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class MetodopagoDomain
    {
        private readonly MetodopagoRepository _MetodopagoRepository;

        public MetodopagoDomain(MetodopagoRepository MetodopagoRepository)
        {
           
                _MetodopagoRepository = MetodopagoRepository;     
        }

        public IEnumerable<Metodopago> ObtenerMetodopagoTodos()
        {
            try
            {
                return _MetodopagoRepository.ObtenerMetodopagoTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarMetodopago(Metodopago oMetodopago)
        {
            try
            {
                return _MetodopagoRepository.InsertarMetodopago(oMetodopago);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int ActualizarMetodopago(Metodopago oMetodopago)
        {
            try
            {
                return _MetodopagoRepository.ActualizarMetodopago(oMetodopago);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int EliminarMetodopago(Metodopago oMetodopago)
        {
            try
            {
                return _MetodopagoRepository.EliminarMetodopago(oMetodopago);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
