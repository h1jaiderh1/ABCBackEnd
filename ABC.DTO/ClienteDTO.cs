using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }

        public string? Tipo { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string? Departamento { get; set; }

        public string? Ciudad { get; set; }

        public string? Barrio { get; set; }

        public string? FechaCreacion { get; set; }

        public string? FechaActualizacion { get; set; }

        public int? IsActive { get; set; }

        public virtual ICollection<PedidoDTO> Pedidos { get; set; } 
    }
}
