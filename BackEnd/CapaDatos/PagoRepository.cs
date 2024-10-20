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
    public class PagoRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public PagoRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Pagos
        public IEnumerable<Pago> ObtenerPagoTodos()
        {
            var Pagos = new List<Pago>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Pago> lstFound = new List<Pago>();
                var query = "USP_GET_Pago_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Pago>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public int InsertarPago(Pago oPago)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
       
                var query = "USP_INSERT_Pago";
                var param = new DynamicParameters();
                param.Add("@nidventa", oPago.nidventa);
                param.Add("@dfechapago", oPago.dfechapago);
                param.Add("@nmonto", oPago.nmonto);
                param.Add("@nidmetodopago", oPago.nidmetodopago);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }


        }


        public int ActualizarPago(Pago oPago)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Pago";
                var param = new DynamicParameters();
                param.Add("@nidpago", oPago.nidpago);
                param.Add("@nidventa", oPago.nidventa);
                param.Add("@nmonto", oPago.nmonto);
                param.Add("@dfechapago", oPago.dfechapago);
                param.Add("@nidmetodopago", oPago.nidmetodopago);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

        }


        public int EliminarPago(Pago oPago)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_EliminarPago";
                var param = new DynamicParameters();
                param.Add("@nidpago", oPago.nidpago);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

        }

    }
}
