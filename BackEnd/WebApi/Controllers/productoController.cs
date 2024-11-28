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

        [HttpGet("GetProductoId/{nIdProducto}")]
        public IActionResult GetProductoId(int nIdProducto)
        {
            var ordenesCompra = _productoDomain.GetProductoId(nIdProducto);
            return Ok(ordenesCompra);
        }

        [HttpPost("InsertarProducto")]
        public IActionResult InsertarProducto([FromBody] producto oProducto)
        {
            var id = _productoDomain.InsertarProducto(oProducto);
            return Ok(id);
        }

        [HttpPut("ActualizarProducto")]
        public IActionResult ActualizarProducto([FromBody] producto oProducto)
        {
            var id = _productoDomain.ActualizarProducto(oProducto);
            return Ok(id);
        }

        [HttpDelete("EliminarProducto/{nidproducto}")]
        public IActionResult EliminarProducto(Int32 nidproducto)
        {
            //producto Producto = new producto() { nidproducto = nidproducto};
            var id = _productoDomain.EliminarProducto(nidproducto);
            return Ok(id);
        }
    }
}
