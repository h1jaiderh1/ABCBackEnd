using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.DTO;
namespace ABC.BLL.Servicios.Contratos
{
    public interface IPedidoService
    {
        Task<PedidoDTO> Registrar(PedidoDTO modelo);
        //Task<List<PedidoDTO>> Historial(string buscarPor, string numeroPedido, string fechaInicio, string fechaFin);
        

    }
}
