using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ventaController : ControllerBase
    {
        private readonly VentaDomain _ventaDomain;

        public ventaController(VentaDomain ventaDomain)
        {
            _ventaDomain = ventaDomain;
        }

        [HttpGet("ObtenerventaTodos")]
        public IActionResult ObtenerventaTodos()
        {
            var ventas = _ventaDomain.ObtenerventaTodos();
            return Ok(ventas);
        }

        [HttpPut("Actualizarventa")]
        public IActionResult Actualizarventa(venta oventa)
        {
            var id = _ventaDomain.Actualizarventa(oventa);
            return Ok(id);
        }
        [HttpPost("Insertarventa")]
        public IActionResult Insertarventa(venta oventa)
        {
            var id = _ventaDomain.Insertarventa(oventa);
            return Ok(id);
        }
        [HttpDelete("Eliminarventa/{nidVenta}")]
        public IActionResult Eliminarventa(Int32 nidVenta)
        {
            venta venta = new venta() { nidVenta = nidVenta };
            var id = _ventaDomain.Eliminarventa(venta);
            return Ok(id);
        }
    }
}
