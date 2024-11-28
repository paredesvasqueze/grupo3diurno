using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly PagoDomain _PagoDomain;

        public PagoController(PagoDomain PagoDomain)
        {
            _PagoDomain = PagoDomain;
        }

        [HttpGet("ObtenerPagoTodos")]
        public IActionResult ObtenerPagoTodos()
        {
            var Pagos = _PagoDomain.ObtenerPagoTodos();
            return Ok(Pagos);
        }
        [HttpGet("GetPagoId/{nIdPago}")]
        public IActionResult GetPagoId(int nidpago)
        {
            var pago = _PagoDomain.GetPagoId(nidpago);
            return Ok(pago);
        }

        [HttpPost("InsertarPago")]
        public IActionResult InsertarPago(Pago oPago)
        {
            var id = _PagoDomain.InsertarPago(oPago);
            return Ok(id);
        }


        [HttpPut("ActualizarPago")]
        public IActionResult ActualizarPago(Pago oPago)
        {
            var id = _PagoDomain.ActualizarPago(oPago);
            return Ok(id);
        }

        [HttpDelete("EliminarPago/{nidpago}")]
        public IActionResult EliminarPago(Int32 nidpago)
        {
            Pago Pago = new Pago() { nidpago = nidpago };
            var id = _PagoDomain.EliminarPago(Pago);
            return Ok(id);
        }

    }
}
