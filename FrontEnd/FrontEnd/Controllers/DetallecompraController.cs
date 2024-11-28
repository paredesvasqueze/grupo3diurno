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
    public class DetallecompraController : Controller
    {
        private readonly DetallecompraService _DetallecompraService;
        private string _token;

        public DetallecompraController(DetallecompraService DetallecompraService)
        {
            _DetallecompraService = DetallecompraService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var Detallecompras = await _DetallecompraService.GetDetallecomprasAsync(_token);
            return View(Detallecompras);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Detallecompra Detallecompra)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _DetallecompraService.CreateDetallecompraAsync(Detallecompra, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Detallecompra Detallecompra)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _DetallecompraService.UpdateDetallecompraAsync(Detallecompra, _token);
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
            var result = await _DetallecompraService.DeleteDetallecompraAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
