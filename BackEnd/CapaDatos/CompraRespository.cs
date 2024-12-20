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
    public class CompraRepository
    {
        private readonly ConexionSingleton _conexionSingleton;
        private string _connectionString;

        // Constructor que recibe el singleton de conexión
        public CompraRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Compras
        public IEnumerable<Compra> ObtenerCompraTodos()
        {
            var Compras = new List<Compra>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Compra> lstFound = new List<Compra>();
                var query = "ObtenerCompraTodos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Compra>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public int InsertarCompra(Compra oCompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                
                var query = "InsertarCompra";
                var param = new DynamicParameters();
                param.Add("@nidproveedor", oCompra.nidproveedor);
                param.Add("@dfechacompra", oCompra.dfechacompra);
                param.Add("@ntotal", oCompra.ntotal);             
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }


        }
        public int ActualizarCompra(Compra oCompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "ActualizarCompra";
                var param = new DynamicParameters();
                param.Add("@nidcompra", oCompra.nidcompra);
                param.Add("@nidproveedor", oCompra.nidproveedor);
                param.Add("@dfechacompra", oCompra.dfechacompra);
                param.Add("@ntotal", oCompra.ntotal);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }
        public int EliminarCompra(Compra oCompra)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Compra";
                var param = new DynamicParameters();
                param.Add("@nidcompra", oCompra.nidcompra);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

    }
}
