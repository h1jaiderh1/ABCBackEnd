using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? ValorUnitario { get; set; }
        public int? Cantidad { get; set; }
        public int? IsActive { get; set; }
        public string? FechaActualizacion { get; set; }
    }
}
