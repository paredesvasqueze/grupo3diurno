using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Dapper;

namespace CapaDatos
{
    public class ClienteRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public ClienteRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de clientes
        public IEnumerable<Cliente> ObtenerclienteTodos()
        {
            var clientes = new List<Cliente>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Cliente> lstFound = new List<Cliente>();
                var query = "USP_GET_cliente_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Cliente>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public int Insertarcliente(Cliente ocliente)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
       
                var query = "USP_Insert_cliente";
                var param = new DynamicParameters();
                param.Add("@cnombre", ocliente.cnombre);
                param.Add("@capellido", ocliente.capellido);
                param.Add("@cemail", ocliente.cemail);
                param.Add("@ctelefono", ocliente.ctelefono);
                param.Add("@cdni", ocliente.cdni);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }


        }

        public int Actualizarcliente(Cliente ocliente)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_cliente";
                var param = new DynamicParameters();
                param.Add("@nidcliente", ocliente.nidcliente);
                param.Add("@cnombre", ocliente.cnombre);
                param.Add("@capellido", ocliente.capellido);
                param.Add("@cemail", ocliente.cemail);
                param.Add("@ctelefono", ocliente.ctelefono);
                param.Add("@cdni", ocliente.cdni);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

        }

        public int eliminarcliente(int nidcliente) // Recibiendo el ID del Proveedor
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_cliente"; // Asegúrate de que este procedimiento almacenado exista
                var param = new DynamicParameters();
                param.Add("@nidcliente", nidcliente); // Usando el ID

                try
                {
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar Cliente: " + ex.Message);
                }
            }
        }
    }
}
