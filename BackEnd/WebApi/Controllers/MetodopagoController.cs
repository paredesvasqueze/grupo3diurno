using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetodopagoController : ControllerBase
    {
        private readonly MetodopagoDomain _MetodopagoDomain;

        public MetodopagoController(MetodopagoDomain MetodopagoDomain)
        {
            _MetodopagoDomain = MetodopagoDomain;
        }

        [HttpGet("ObtenerMetodopagoTodos")]
        public IActionResult ObtenerMetodopagoTodos()
        {
            var Metodopagos = _MetodopagoDomain.ObtenerMetodopagoTodos();
            return Ok(Metodopagos);
        }

        [HttpPost("InsertarMetodopago")]
        public IActionResult InsertarMetodopago(Metodopago oMetodopago)
        {
            var id = _MetodopagoDomain.InsertarMetodopago(oMetodopago);
            return Ok(id);
        }

        [HttpPut("ActualizarMetodopago")]
        public IActionResult ActualizarMetodopago(Metodopago oMetodopago)
        {
            var id = _MetodopagoDomain.ActualizarMetodopago(oMetodopago);
            return Ok(id);
        }

        [HttpDelete("EliminarMetodopago")]
        public IActionResult EliminarMetodopago(Metodopago oMetodopago)
        {
            var id = _MetodopagoDomain.EliminarMetodopago(oMetodopago);
            return Ok(id);
        }
    }
}
