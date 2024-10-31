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
    public class clienteRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public clienteRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de clientes
        public IEnumerable<cliente> ObtenerclienteTodos()
        {
            var clientes = new List<cliente>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<cliente> lstFound = new List<cliente>();
                var query = "USP_GET_cliente_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<cliente>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public int Insertarcliente(cliente ocliente)
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


        public int actualizarcliente(cliente ocliente)
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


        public int eliminarcliente(cliente ocliente)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_cliente";
                var param = new DynamicParameters();
                param.Add("@nidcliente", ocliente.nidcliente);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

        }

    }
}
