using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class proveedorController : ControllerBase
    {
        private readonly proveedorDomain _proveedorDomain;

        public proveedorController(proveedorDomain proveedorDomain)
        {
            _proveedorDomain = proveedorDomain;
        }

        [HttpGet("ObtenerproveedorTodos")]
        public IActionResult ObtenerproveedorTodos()
        {
            var proveedors = _proveedorDomain.ObtenerproveedorTodos();
            return Ok(proveedors);
        }

        [HttpPut("Actualizarproveedor")]
        public IActionResult Actualizarproveedor(proveedor oproveedor)
        {
            var id = _proveedorDomain.Actualizarproveedor(oproveedor);
            return Ok(id);
        }
        [HttpPost("Insertarproveedor")]
        public IActionResult Insertarproveedor(proveedor oproveedor)
        {
            var id = _proveedorDomain.Insertarproveedor(oproveedor);
            return Ok(id);
        }
        [HttpDelete("Eliminarproveedor/{nIdproveedor}")]
        public IActionResult Eliminarproveedor(Int32 nIdproveedor)
        {
            proveedor proveedor = new proveedor() { nidProveedor = nIdproveedor };
            var id = _proveedorDomain.Eliminarproveedor(proveedor);
            return Ok(id);
        }
    }
}
