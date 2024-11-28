using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DetalleVentaController : ControllerBase
    {
        private readonly DetalleVentaDomain _DetalleVentaDomain;

        public DetalleVentaController(DetalleVentaDomain DetalleVentaDomain)
        {
            _DetalleVentaDomain = DetalleVentaDomain;
        }

        [HttpGet("ObtenerDetalleVentaTodos")]
        public IActionResult ObtenerDetalleVentaTodos()
        {
            var DetalleVentas = _DetalleVentaDomain.ObtenerDetalleVentaTodos();
            return Ok(DetalleVentas);
        }

        [HttpPost("InsertDetalleVenta")]
        public IActionResult InsertDetalleVenta(DetalleVenta oDetalleVenta)
        {
            var id = _DetalleVentaDomain.InsertDetalleVenta(oDetalleVenta);
            return Ok(id);
        }

        [HttpPut("ActualizarDetalleVenta")]
        public IActionResult ActualizarDetalleVenta(DetalleVenta oDetalleVenta)
        {
            var id = _DetalleVentaDomain.ActualizarDetalleVenta(oDetalleVenta);
            return Ok(id);
        }

        [HttpDelete("EliminarDetalleVenta/{niddetalle}")]
        public IActionResult EliminarDetalleVenta(Int32 niddetalle)
        {
            DetalleVenta DetalleVenta = new DetalleVenta() { niddetalle = niddetalle };
            var id = _DetalleVentaDomain.EliminarDetalleVenta(DetalleVenta);
            return Ok(id);
        }
    }
}
