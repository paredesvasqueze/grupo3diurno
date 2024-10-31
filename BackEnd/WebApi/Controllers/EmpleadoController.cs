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
        private readonly EmpleadoDomain _empleadoDomain;

        public EmpleadoController(EmpleadoDomain empleadoDomain)
        {
            _empleadoDomain = empleadoDomain;
        }

        [HttpGet("ObtenerEmpleadoTodos")]
        public IActionResult ObtenerEmpleadoTodos()
        {
            var empleados = _empleadoDomain.ObtenerEmpleadoTodos();
            return Ok(empleados);
        }

        [HttpPost("InsertarEmpleado")]
        public IActionResult InsertarEmpleado([FromBody] Empleado oEmpleado)
        {
            var id = _empleadoDomain.InsertarEmpleado(oEmpleado);
            return Ok(id);
        }

        [HttpPut("ActualizarEmpleado")]
        public IActionResult ActualizarEmpleado([FromBody] Empleado oEmpleado)
        {
            var id = _empleadoDomain.ActualizarEmpleado(oEmpleado);
            return Ok(id);
        }

        [HttpDelete("EliminarEmpleado/{id}")]
        public IActionResult EliminarEmpleado(int id)
        {
            var resultado = _empleadoDomain.EliminarEmpleado(id);
            return Ok(resultado);
        }
    }
}
