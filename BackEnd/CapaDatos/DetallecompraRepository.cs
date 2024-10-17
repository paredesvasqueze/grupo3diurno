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
    public class DetallecompraRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public DetallecompraRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Detallecompras
        public IEnumerable<Detallecompra> ObtenerDetallecompraTodos()
        {
            var Detallecompras = new List<Detallecompra>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Detallecompra> lstFound = new List<Detallecompra>();
                var query = "USP_Seleccionar_Detallecompra";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Detallecompra>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int InsertDetallecompra(Detallecompra oDetallecompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insert_Detallecompra";
                var param = new DynamicParameters();
                param.Add("@nidproducto", oDetallecompra.nidproducto);
                param.Add("@ncantidad", oDetallecompra.ncantidad);
                param.Add("@npreciounitario", oDetallecompra.npreciounitario);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int ActualizarDetallecompra(Detallecompra oDetallecompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Detallecompra";
                var param = new DynamicParameters();
                param.Add("@niddetallecompra", oDetallecompra.niddetallecompra);
                param.Add("@nidproducto", oDetallecompra.nidproducto);
                param.Add("@ncantidad", oDetallecompra.ncantidad);
                param.Add("@npreciounitario", oDetallecompra.npreciounitario);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int EliminarDetallecompra(Detallecompra oDetallecompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Detallecompra";
                var param = new DynamicParameters();
                param.Add("@niddetalle", oDetallecompra.niddetallecompra);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
    }
}