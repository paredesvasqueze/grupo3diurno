using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly clienteDomain _clienteDomain;

        public ClienteController(clienteDomain clienteDomain)
        {
            _clienteDomain = clienteDomain;
        }

        [HttpGet("ObtenerclienteTodos")]
        public IActionResult ObtenerclienteTodos()
        {
            var clientes = _clienteDomain.ObtenerclienteTodos();
            return Ok(clientes);
        }

        [HttpPost("Insertarcliente")]
        public IActionResult Insertarcliente(cliente ocliente)
        {
            var id = _clienteDomain.Insertarcliente(ocliente);
            return Ok(id);
        }


        [HttpPut("actualizarcliente")]
        public IActionResult actualizarcliente(cliente ocliente)
        {
            var id = _clienteDomain.actualizarcliente(ocliente);
            return Ok(id);
        }

        [HttpDelete("eliminarcliente")]
        public IActionResult eliminarcliente(cliente ocliente)
        {
            var id = _clienteDomain.eliminarcliente(ocliente);
            return Ok(id);
        }

    }
}
