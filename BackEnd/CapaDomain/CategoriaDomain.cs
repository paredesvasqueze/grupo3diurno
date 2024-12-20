﻿using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class CategoriaDomain
    {
        private readonly CategoriaRepository _CategoriaRepository;

        public CategoriaDomain(CategoriaRepository CategoriaRepository)
        {
           
                _CategoriaRepository = CategoriaRepository;     
        }

        public IEnumerable<Categoria> ObtenerCategoriaTodos()
        {
            try
            {
                return _CategoriaRepository.ObtenerCategoriaTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertCategoria(Categoria oCategoria)
        {
            try
            {
                return _CategoriaRepository.InsertCategoria(oCategoria);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int ActualizarCategoria(Categoria oCategoria)
        {
            try
            {
                return _CategoriaRepository.ActualizarCategoria(oCategoria);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int EliminarCategoria(Int32 oCategoria)
        {
            try
            {
                return _CategoriaRepository.EliminarCategoria(oCategoria);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
