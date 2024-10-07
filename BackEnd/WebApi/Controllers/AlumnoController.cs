using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly Alumnodomain _alumnoDomain;

        public AlumnoController(Alumnodomain alumnoDomain)
        {
            _alumnoDomain = alumnoDomain;
        }

        [HttpGet("ObtenerAlumnoTodos")]
        public IActionResult ObtenerAlumnoTodos()
        {
            var alumnos = _alumnoDomain.ObtenerAlumnoTodos();
            return Ok(alumnos);
        }

        [HttpPost("InsertarAlumno")]
        public IActionResult InsertarAlumno(Alumno oAlumno)
        {
            var id = _alumnoDomain.InsertarAlumno(oAlumno);
            return Ok(id);
        }
    }
}
