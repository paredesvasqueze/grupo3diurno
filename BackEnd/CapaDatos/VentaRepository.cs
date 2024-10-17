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
    public class VentaRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public VentaRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de ventas
        public IEnumerable<venta> ObtenerventaTodos()
        {
            var ventas = new List<venta>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<venta> lstFound = new List<venta>();
                var query = "USP_GET_venta_todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<venta>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int Insertarventa(venta oventa)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_INSERT_venta";
                var param = new DynamicParameters();
                param.Add("@nidcliente", oventa.nidcliente);
                param.Add("@nidempleado", oventa.nidempleado);
                param.Add("@dfechaventa", oventa.dfechaventa);
                param.Add("@ntotal", oventa.ntotal);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        public int Actualizarventa(venta oventa)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_ActualizarVenta";
                var param = new DynamicParameters();
                param.Add("@nidVenta", oventa.nidVenta);
                param.Add("@nidcliente", oventa.nidcliente);
                param.Add("@nidempleado", oventa.nidempleado);
                param.Add("@dfechaventa", oventa.dfechaventa);
                param.Add("@ntotal", oventa.ntotal);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        public int Eliminarventa(venta oventa)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_EliminarVenta";
                var param = new DynamicParameters();
                param.Add("@nidVenta", oventa.nidVenta);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
