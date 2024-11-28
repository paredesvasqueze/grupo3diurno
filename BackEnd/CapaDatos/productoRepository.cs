using System.Collections.Generic;
using System.Data;
using Dapper;
using CapaEntidad;

namespace CapaDatos
{
    public class productorepository // Asegúrate de que este nombre esté en minúscula
    {
        private readonly ConexionSingleton _conexionSingleton;

        public productorepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Obtener todos los productos
        public IEnumerable<producto> ObtenerProductoTodos()
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                var query = "USP_GET_producto_Todos"; // Asegúrate de que este procedimiento almacenado exista
                var param = new DynamicParameters();
                return SqlMapper.Query<producto>(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        public producto GetProductoId(int nIdProducto)
        {
            var Productos = new List<producto>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                producto Item = new producto();
                var query = "GetProductoById";
                var param = new DynamicParameters();
                param.Add("@nIdProducto", nIdProducto);
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                Item = SqlMapper.QueryFirstOrDefault<producto>(connection, query, param, commandType: CommandType.StoredProcedure);
                return Item;

            }
        }

        // Insertar un nuevo producto
        public int InsertarProducto(producto oProducto)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insert_producto"; // Asegúrate de que este procedimiento almacenado exista
                var param = new DynamicParameters();
                param.Add("@cnombre", oProducto.cnombre);
                param.Add("@cdescripcion", oProducto.cdescripcion);
                param.Add("@npreciounitario", oProducto.npreciounitario);
                param.Add("@nstock", oProducto.nstock);
                param.Add("@nidcategoria", oProducto.nidcategoria);
                param.Add("@dfecharegistro", oProducto.dfecharegistro);

                try
                {
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar producto: " + ex.Message);
                }
            }
        }

        // Actualizar un producto existente
        public int ActualizarProducto(producto oProducto)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_producto"; // Asegúrate de que este procedimiento almacenado exista
                var param = new DynamicParameters();
                param.Add("@nidproducto", oProducto.nidproducto); // ID del producto
                param.Add("@cnombre", oProducto.cnombre);
                param.Add("@cdescripcion", oProducto.cdescripcion);
                param.Add("@npreciounitario", oProducto.npreciounitario);
                param.Add("@nstock", oProducto.nstock);
                param.Add("@nidcategoria", oProducto.nidcategoria);
                param.Add("@dfecharegistro", oProducto.dfecharegistro);

                try
                {
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar producto: " + ex.Message);
                }
            }
        }

        // Eliminar un producto por su ID
        public int EliminarProducto(int idProducto) // Recibiendo el ID del producto
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_producto"; // Asegúrate de que este procedimiento almacenado exista
                var param = new DynamicParameters();
                param.Add("@nidproducto", idProducto); // Usando el ID

                try
                {
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar producto: " + ex.Message);
                }
            }
        }
    }
}
