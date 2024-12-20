using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly CompraDomain _CompraDomain;

        public CompraController(CompraDomain CompraDomain)
        {
            _CompraDomain = CompraDomain;
        }

        [HttpGet("ObtenerCompraTodos")]
        public IActionResult ObtenerCompraTodos()
        {
            var Compras = _CompraDomain.ObtenerCompraTodos();
            return Ok(Compras);
        }

        [HttpPost("InsertarCompra")]
        public IActionResult InsertarCompra(Compra oCompra)
        {
            var id = _CompraDomain.InsertarCompra(oCompra);
            return Ok(id);
        }

        [HttpPut("ActualizarCompra")]
        public IActionResult ActualizarCompra(Compra oCompra)
        {
            var id = _CompraDomain.ActualizarCompra(oCompra);
            return Ok(id);
        }

        [HttpDelete("EliminarCompra/{nidcompra}")]
        public IActionResult EliminarCompra(Int32 nidcompra)
        {
            Compra Compra = new Compra() { nidcompra = nidcompra };
            var id = _CompraDomain.EliminarCompra(Compra);
            return Ok(id);
        }
    }
}
