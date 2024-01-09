using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.DTO
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public string? FechaCreacion { get; set; }
        public string? FechaActualizacion { get; set; }
        public string? FechaCierre { get; set; }
        public string? FechaFacturacion { get; set; }
        public int? IdCliente { get; set; }
        public int? IsActive { get; set; }
        public string? Total { get; set; }
        public virtual ICollection<PedidoProductoDTO> PedidoProductos { get; set; }

    }
}
