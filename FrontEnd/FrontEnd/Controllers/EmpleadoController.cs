using FrontEnd.Filter;
using FrontEnd.Models;
using FrontEnd.Servicio;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace FrontEnd.Controllers
{
    [TypeFilter(typeof(TokenAuthorizationFilter))]
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoService _EmpleadoService;
        private string _token;

        public EmpleadoController(EmpleadoService EmpleadoService)
        {
            _EmpleadoService = EmpleadoService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var Empleados = await _EmpleadoService.GetEmpleadosAsync(_token);
            return View(Empleados);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Empleado Empleado)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _EmpleadoService.CreateEmpleadoAsync(Empleado, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Empleado Empleado)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _EmpleadoService.UpdateEmpleadoAsync(Empleado, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var result = await _EmpleadoService.DeleteEmpleadoAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
