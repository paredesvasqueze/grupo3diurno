using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaDomain
{
    public class EmpleadoDomain
    {
        private readonly EmpleadoRepository _EmpleadoRepository;

        public EmpleadoDomain(EmpleadoRepository empleadoRepository)
        {
            _EmpleadoRepository = empleadoRepository;
        }

        public IEnumerable<Empleado> ObtenerEmpleadoTodos()
        {
            try
            {
                return _EmpleadoRepository.ObtenerEmpleadoTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener empleados: " + ex.Message);
            }
        }

        public int InsertarEmpleado(Empleado oEmpleado)
        {
            try
            {
                return _EmpleadoRepository.InsertarEmpleado(oEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar empleado: " + ex.Message);
            }
        }

        public int ActualizarEmpleado(Empleado oEmpleado)
        {
            try
            {
                return _EmpleadoRepository.ActualizarEmpleado(oEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar empleado: " + ex.Message);
            }
        }

        public int EliminarEmpleado(int idEmpleado)
        {
            try
            {
                return _EmpleadoRepository.EliminarEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar empleado: " + ex.Message);
            }
        }
    }
}
