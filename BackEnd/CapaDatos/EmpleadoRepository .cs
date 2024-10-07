using System.Collections.Generic;
using System.Data;
using Dapper;
using CapaEntidad;

namespace CapaDatos
{
    public class EmpleadoRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        public EmpleadoRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        public IEnumerable<Empleado> ObtenerEmpleadoTodos()
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                var query = "USP_GET_Empleado_Todos";
                var param = new DynamicParameters();
                return SqlMapper.Query<Empleado>(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        public int InsertarEmpleado(Empleado oEmpleado)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insert_Empleado";
                var param = new DynamicParameters();
                param.Add("@cnombre", oEmpleado.cnombre);
                param.Add("@capellido", oEmpleado.capellido);
                param.Add("@cpuesto", oEmpleado.cpuesto);
                param.Add("@nsalario", oEmpleado.nsalario);
                param.Add("@dfechacontratacion", oEmpleado.dfechacontratacion);

                try
                {
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar empleado: " + ex.Message);
                }
            }
        }

        public int ActualizarEmpleado(Empleado oEmpleado)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Empleado";
                var param = new DynamicParameters();
                param.Add("@nidempleado", oEmpleado.nidempleado); // Agregado ID
                param.Add("@cnombre", oEmpleado.cnombre);
                param.Add("@capellido", oEmpleado.capellido);
                param.Add("@cpuesto", oEmpleado.cpuesto);
                param.Add("@nsalario", oEmpleado.nsalario);
                param.Add("@dfechacontratacion", oEmpleado.dfechacontratacion);

                try
                {
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar empleado: " + ex.Message);
                }
            }
        }

        public int EliminarEmpleado(int idEmpleado) // Cambiado para recibir ID
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Empleado";
                var param = new DynamicParameters();
                param.Add("@nidempleado", idEmpleado); // Usando ID

                try
                {
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar empleado: " + ex.Message);
                }
            }
        }
    }
}
