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
    public class MetodopagoController : Controller
    {
        private readonly MetodopagoService _MetodopagoService;
        private string _token;

        public MetodopagoController(MetodopagoService MetodopagoService)
        {
            _MetodopagoService = MetodopagoService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var Metodopagos = await _MetodopagoService.GetMetodopagosAsync(_token);
            return View(Metodopagos);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Metodopago Metodopago)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _MetodopagoService.CreateMetodopagoAsync(Metodopago, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Metodopago Metodopago)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _MetodopagoService.UpdateMetodopagoAsync(Metodopago, _token);
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
            var result = await _MetodopagoService.DeleteMetodopagoAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
