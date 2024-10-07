using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaDomain
{
    public class EmpleadoDomain
    {
        private readonly EmpleadoRepository _empleadoRepository;

        public EmpleadoDomain(EmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public IEnumerable<Empleado> ObtenerEmpleadoTodos()
        {
            try
            {
                return _empleadoRepository.ObtenerEmpleadoTodos();
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
                return _empleadoRepository.InsertarEmpleado(oEmpleado);
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
                return _empleadoRepository.ActualizarEmpleado(oEmpleado);
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
                return _empleadoRepository.EliminarEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar empleado: " + ex.Message);
            }
        }
    }
}
