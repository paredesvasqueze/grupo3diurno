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
    public class MetodopagoRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public MetodopagoRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Metodopagos
        public IEnumerable<Metodopago> ObtenerMetodopagoTodos()
        {
            var Metodopagos = new List<Metodopago>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Metodopago> lstFound = new List<Metodopago>();
                var query = "ObtenerMetodopagoTodos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Metodopago>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public int InsertarMetodopago(Metodopago oMetodopago)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                
                var query = "InsertarMetodopago";
                var param = new DynamicParameters();
                param.Add("@cmetodopago", oMetodopago.cmetodopago);             
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }


        }
        public int ActualizarMetodopago(Metodopago oMetodopago)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "ActualizarMetodopago";
                var param = new DynamicParameters();
                param.Add("@nidmetodopago", oMetodopago.nidmetodopago);
                param.Add("@cmetodopago", oMetodopago.cmetodopago);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
        public int EliminarMetodopago(int nidmetodopago) 
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "EliminarMetodopago"; 
                var param = new DynamicParameters();
                param.Add("@nidmetodopago", nidmetodopago); 

                try
                {
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar Metodo Pago: " + ex.Message);
                }
            }
        }

    }
}
