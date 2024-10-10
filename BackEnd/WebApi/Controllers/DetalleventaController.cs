using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class detalleventaController : ControllerBase
    {
        private readonly detalleventaDomain _detalleventaDomain;

        public detalleventaController(detalleventaDomain detalleventaDomain)
        {
            _detalleventaDomain = detalleventaDomain;
        }

        [HttpGet("ObtenerdetalleventaTodos")]
        public IActionResult ObtenerdetalleventaTodos()
        {
            var detalleventas = _detalleventaDomain.ObtenerdetalleventaTodos();
            return Ok(detalleventas);
        }

        [HttpPost("Insertardetalleventa")]
        public IActionResult Insertardetalleventa(detalleventa odetalleventa)
        {
            var id = _detalleventaDomain.Insertardetalleventa(odetalleventa);
            return Ok(id);
        }


        [HttpPut("actualizardetalleventa")]
        public IActionResult actualizardetalleventa(detalleventa odetalleventa)
        {
            var id = _detalleventaDomain.actualizardetalleventa(odetalleventa);
            return Ok(id);
        }

        [HttpDelete("eliminardetalleventa")]
        public IActionResult eliminardetalleventa(detalleventa odetalleventa)
        {
            var id = _detalleventaDomain.eliminardetalleventa(odetalleventa);
            return Ok(id);
        }

    }
}
