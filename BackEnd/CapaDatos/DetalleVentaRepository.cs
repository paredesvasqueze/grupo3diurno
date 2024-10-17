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
    public class DetalleVentaRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public DetalleVentaRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de DetalleVentas
        public IEnumerable<DetalleVenta> ObtenerDetalleVentaTodos()
        {
            var DetalleVentas = new List<DetalleVenta>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<DetalleVenta> lstFound = new List<DetalleVenta>();
                var query = "USP_Seleccionar_DetalleVenta";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<DetalleVenta>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int InsertDetalleVenta(DetalleVenta oDetalleVenta)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insert_DetalleVenta";
                var param = new DynamicParameters();
                param.Add("@nidproducto", oDetalleVenta.nidproducto);
                param.Add("@nidventa", oDetalleVenta.nidventa);
                param.Add("@ncantidad", oDetalleVenta.ncantidad);
                param.Add("@npreciounitario", oDetalleVenta.npreciounitario);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int ActualizarDetalleVenta(DetalleVenta oDetalleVenta)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_DetalleVenta";
                var param = new DynamicParameters();
                param.Add("@niddetalle", oDetalleVenta.niddetalle);
                param.Add("@nidproducto", oDetalleVenta.nidproducto);
                param.Add("@nidventa", oDetalleVenta.nidventa);
                param.Add("@ncantidad", oDetalleVenta.ncantidad);
                param.Add("@npreciounitario", oDetalleVenta.npreciounitario);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int EliminarDetalleVenta(DetalleVenta oDetalleVenta)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_DetalleVenta";
                var param = new DynamicParameters();
                param.Add("@niddetalle", oDetalleVenta.niddetalle);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
    }
}