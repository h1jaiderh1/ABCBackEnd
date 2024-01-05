using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ABC.BLL.Servicios.Contratos;
using ABC.DTO;
using ABC.API.Utilidad;

namespace ABC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoServicio;

        public PedidoController(IPedidoService pedidoServicio)
        {
            _pedidoServicio = pedidoServicio;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] PedidoDTO pedido)
        {
            var rsp = new Response<PedidoDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _pedidoServicio.Registrar(pedido);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
                throw;
            }
            return Ok(rsp);
        }
    }
}
