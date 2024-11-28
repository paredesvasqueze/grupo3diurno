using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoDomain _EmpleadoDomain;

        public EmpleadoController(EmpleadoDomain EmpleadoDomain)
        {
            _EmpleadoDomain = EmpleadoDomain;
        }

        [HttpGet("ObtenerEmpleadoTodos")]
        public IActionResult ObtenerEmpleadoTodos()
        {
            var empleados = _EmpleadoDomain.ObtenerEmpleadoTodos();
            return Ok(empleados);
        }

        [HttpPost("InsertarEmpleado")]
        public IActionResult InsertarEmpleado([FromBody] Empleado oEmpleado)
        {
            var id = _EmpleadoDomain.InsertarEmpleado(oEmpleado);
            return Ok(id);
        }

        [HttpPut("ActualizarEmpleado")]
        public IActionResult ActualizarEmpleado([FromBody] Empleado oEmpleado)
        {
            var id = _EmpleadoDomain.ActualizarEmpleado(oEmpleado);
            return Ok(id);
        }

        [HttpDelete("EliminarEmpleado/{id}")]
        public IActionResult EliminarEmpleado(int id)
        {
            var resultado = _EmpleadoDomain.EliminarEmpleado(id);
            return Ok(resultado);
        }
    }
}
