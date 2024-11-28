using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaDomain _CategoriaDomain;

        public CategoriaController(CategoriaDomain CategoriaDomain)
        {
            _CategoriaDomain = CategoriaDomain;
        }

        [HttpGet("ObtenerCategoriaTodos")]
        public IActionResult ObtenerCategoriaTodos()
        {
            var Categorias = _CategoriaDomain.ObtenerCategoriaTodos();
            return Ok(Categorias);
        }

        [HttpPost("InsertCategoria")]
        public IActionResult InsertCategoria(Categoria oCategoria)
        {
            var id = _CategoriaDomain.InsertCategoria(oCategoria);
            return Ok(id);
        }

        [HttpPut("ActualizarCategoria")]
        public IActionResult ActualizarCategoria(Categoria oCategoria)
        {
            var id = _CategoriaDomain.ActualizarCategoria(oCategoria);
            return Ok(id);
        }

        [HttpDelete("EliminarCategoria/{nIdCategoria}")]
        public IActionResult EliminarCategoria(Int32 nIdCategoria)
        {
           // Categoria Categoria = new Categoria() { nidcategoria = nIdCategoria };
            var id = _CategoriaDomain.EliminarCategoria(nIdCategoria);
            return Ok(id);
        }
    }
}
