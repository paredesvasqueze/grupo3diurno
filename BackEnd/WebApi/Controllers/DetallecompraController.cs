using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetallecompraController : ControllerBase
    {
        private readonly DetallecompraDomain _DetallecompraDomain;

        public DetallecompraController(DetallecompraDomain DetallecompraDomain)
        {
            _DetallecompraDomain = DetallecompraDomain;
        }

        [HttpGet("ObtenerDetallecompraTodos")]
        public IActionResult ObtenerDetallecompraTodos()
        {
            var Detallecompras = _DetallecompraDomain.ObtenerDetallecompraTodos();
            return Ok(Detallecompras);
        }

        [HttpPost("InsertDetallecompra")]
        public IActionResult InsertDetallecompra(Detallecompra oDetallecompra)
        {
            var id = _DetallecompraDomain.InsertDetallecompra(oDetallecompra);
            return Ok(id);
        }

        [HttpPut("ActualizarDetallecompra")]
        public IActionResult ActualizarDetallecompra(Detallecompra oDetallecompra)
        {
            var id = _DetallecompraDomain.ActualizarDetallecompra(oDetallecompra);
            return Ok(id);
        }

        [HttpDelete("EliminarDetallecompra/{niddetallecompra}")]
        public IActionResult EliminarDetallecompra(Int32 niddetallecompra)
        {
            Detallecompra Detallecompra = new Detallecompra() { niddetallecompra = niddetallecompra };
            var id = _DetallecompraDomain.EliminarDetallecompra(Detallecompra);
            return Ok(id);
        }
    }
}
