﻿using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaDomain
{
    public class productodomain
    {
        private readonly productorepository _productoRepository;

        public productodomain(productorepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public IEnumerable<producto> ObtenerProductoTodos()  // Asegúrate de que el tipo de retorno sea IEnumerable<producto>
        {
            try
            {
                return _productoRepository.ObtenerProductoTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message);
            }
        }

        public producto GetProductoId(int nIdProducto)
        {
            try
            {
                return _productoRepository.GetProductoId(nIdProducto);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int InsertarProducto(producto oProducto)  // Asegúrate de que el tipo de retorno sea int
        {
            try
            {
                return _productoRepository.InsertarProducto(oProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto: " + ex.Message);
            }
        }

        public int ActualizarProducto(producto oProducto)  // Asegúrate de que el tipo de retorno sea int
        {
            try
            {
                return _productoRepository.ActualizarProducto(oProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto: " + ex.Message);
            }
        }

        public int EliminarProducto(Int32 idproducto)
        {
            try
            {
                return _productoRepository.EliminarProducto(idproducto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
