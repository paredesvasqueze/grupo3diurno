using FrontEnd.Filter;
using FrontEnd.Models;
using FrontEnd.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [TypeFilter(typeof(TokenAuthorizationFilter))]
    [ApiController]
    [Route("[controller]")]
    public class PagoController : Controller
    {

        private readonly PagoService _PagoService;
        private readonly MetodopagoService _MetodopagoService;
        private string _token;

        public PagoController(PagoService pagoService, MetodopagoService metodopagoService)
        {
            _MetodopagoService = metodopagoService;
            _PagoService = pagoService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var metodopagos = await _MetodopagoService.GetMetodopagosAsync(_token);
            ViewBag.Metodopago = metodopagos;
            var Pagos = await _PagoService.GetPagosAsync(_token);
            return View(Pagos);
        }

        [HttpGet("GetPagoById/{nidpago}")]
        public async Task<IActionResult> GetPagoById(Int32 nidpago)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var Pago = await _PagoService.GetPagoAsync(nidpago, _token);
            return Ok(Pago);
            //return View(Pagos);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Pago Pago)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _PagoService.CreatePagoAsync(Pago, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Pago Pago)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _PagoService.UpdatePagoAsync(Pago, _token);
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
            var result = await _PagoService.DeletePagoAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
