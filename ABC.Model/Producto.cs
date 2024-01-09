using System;
using System.Collections.Generic;

namespace ABC.Model { };

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public decimal? ValorUnitario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int? Cantidad { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<PedidoProducto> PedidoProductos { get; } = new List<PedidoProducto>();
}
