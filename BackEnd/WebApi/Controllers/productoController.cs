using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase  // Cambiado a ProductoController
    {
        private readonly productodomain _productoDomain;  // Cambiado a productodomain

        public ProductoController(productodomain productoDomain)  // Cambiado a ProductoController
        {
            _productoDomain = productoDomain;
        }

        [HttpGet("ObtenerProductoTodos")]
        public IActionResult ObtenerProductoTodos()
        {
            var productos = _productoDomain.ObtenerProductoTodos();
            return Ok(productos);
        }

        [HttpPost("InsertarProducto")]
        public IActionResult InsertarProducto([FromBody] producto oProducto)  // Cambiado a producto
        {
            var id = _productoDomain.InsertarProducto(oProducto);
            return Ok(id);
        }

        [HttpPut("ActualizarProducto")]
        public IActionResult ActualizarProducto([FromBody] producto oProducto)  // Cambiado a producto
        {
            var id = _productoDomain.ActualizarProducto(oProducto);
            return Ok(id);
        }

        [HttpDelete("EliminarProducto")]
        public IActionResult EliminarProducto(int id)
        {
            var resultado = _productoDomain.EliminarProducto(id);
            return Ok(resultado);
        }
    }
}
