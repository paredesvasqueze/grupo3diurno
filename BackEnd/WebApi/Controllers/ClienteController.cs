using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteDomain _clienteDomain;

        public ClienteController(ClienteDomain clienteDomain)
        {
            _clienteDomain = clienteDomain;
        }

        [HttpGet("ObtenerclienteTodos")]
        public IActionResult ObtenerclienteTodos()
        {
            var clientes = _clienteDomain.ObtenerclienteTodos();
            return Ok(clientes);
        }

        [HttpPut("actualizarcliente")]
        public IActionResult Actualizarcliente(Cliente ocliente)
        {
            var id = _clienteDomain.Actualizarcliente(ocliente);
            return Ok(id);
        }

        [HttpPost("Insertarcliente")]
        public IActionResult Insertarcliente(Cliente ocliente)
        {
            var id = _clienteDomain.Insertarcliente(ocliente);
            return Ok(id);
        }

        [HttpDelete("eliminarcliente/{nIdcliente}")]
        public IActionResult Eliminarcliente(Int32 nIdcliente)
        {
            Cliente cliente = new Cliente() { nidcliente = nIdcliente };
            var id = _clienteDomain.eliminarcliente(cliente);
            return Ok(id);
        }
    }
}
