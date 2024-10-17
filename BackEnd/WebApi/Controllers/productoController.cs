using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
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

        [HttpDelete("EliminarProducto/{id}")]
        public IActionResult EliminarProducto(int id)
        {
            var resultado = _productoDomain.EliminarProducto(id);
            return Ok(resultado);
        }
    }
}