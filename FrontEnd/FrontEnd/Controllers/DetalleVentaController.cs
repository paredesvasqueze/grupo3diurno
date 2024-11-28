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
    public class DetalleVentaController : Controller
    {
        private readonly DetalleVentaService _DetalleVentaService;
        private string _token;

        public DetalleVentaController(DetalleVentaService DetalleVentaService)
        {
            _DetalleVentaService = DetalleVentaService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var DetalleVentas = await _DetalleVentaService.GetDetalleVentasAsync(_token);
            return View(DetalleVentas);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] DetalleVenta DetalleVenta)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _DetalleVentaService.CreateDetalleVentaAsync(DetalleVenta, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DetalleVenta DetalleVenta)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _DetalleVentaService.UpdateDetalleVentaAsync(DetalleVenta, _token);
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
            var result = await _DetalleVentaService.DeleteDetalleVentaAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
