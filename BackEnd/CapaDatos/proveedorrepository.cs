﻿using System;
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
    public class proveedorrepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public proveedorrepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de proveedors
        public IEnumerable<proveedor> ObtenerproveedorTodos()
        {
            var proveedors = new List<proveedor>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<proveedor> lstFound = new List<proveedor>();
                var query = "USE_GET_proveedor_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<proveedor>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int Insertarproveedor(proveedor oproveedor)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_INSERT_proveedor";
                var param = new DynamicParameters();
                param.Add("@cnombreProveedor", oproveedor.cnombreProveedor);
                param.Add("@ccontacto", oproveedor.ccontacto);
                param.Add("@ctelefono", oproveedor.ctelefono);
                param.Add("@cemail", oproveedor.cemail);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
        public int Actualizarproveedor(proveedor oproveedor)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizarproveedor";
                var param = new DynamicParameters();
                param.Add("@nidProveedor", oproveedor.nidProveedor);
                param.Add("@cnombreProveedor", oproveedor.cnombreProveedor);
                param.Add("@ccontacto", oproveedor.ccontacto);
                param.Add("@ctelefono", oproveedor.ctelefono);
                param.Add("@cemail", oproveedor.cemail);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }
        public int EliminarProveedor(int idProveedor) // Recibiendo el ID del Proveedor
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminarproveedor"; // Asegúrate de que este procedimiento almacenado exista
                var param = new DynamicParameters();
                param.Add("@nidproveedor", idProveedor); // Usando el ID

                try
                {
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar Proveedor: " + ex.Message);
                }
            }
        }
    }
}
