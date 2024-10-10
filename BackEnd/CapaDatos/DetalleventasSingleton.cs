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
    public class detalleventaRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public detalleventaRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de detalleventas
        public IEnumerable<detalleventa> ObtenerdetalleventaTodos()
        {
            var detalleventas = new List<detalleventa>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<detalleventa> lstFound = new List<detalleventa>();
                var query = "USP_GET_detalleventa_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<detalleventa>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public int Insertardetalleventa(detalleventa odetalleventa)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
       
                var query = "USP_Insert_detalleventa";
                var param = new DynamicParameters();
                param.Add("@nidventa", odetalleventa.nidventa);
                param.Add("@nidproducto", odetalleventa.nidproducto);
                param.Add("@ncantidad", odetalleventa.ncantidad);
                param.Add("@npreciounitario", odetalleventa.npreciounitario);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }


        }


        public int actualizardetalleventa(detalleventa odetalleventa)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_detalleventa";
                var param = new DynamicParameters();
                param.Add("@nidproducto", odetalleventa.nidproducto);
                param.Add("@ncantidad", odetalleventa.ncantidad);
                param.Add("@npreciounitario", odetalleventa.npreciounitario);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

        }


        public int eliminardetalleventa(detalleventa odetalleventa)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_detalleventa";
                var param = new DynamicParameters();
                param.Add("@nidventa", odetalleventa.niddetalle);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

        }

    }
}
