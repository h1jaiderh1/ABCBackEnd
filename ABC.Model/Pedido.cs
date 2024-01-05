using System;
using System.Collections.Generic;

namespace ABC.Model;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? FechaCierre { get; set; }

    public DateTime? FechaFacturacion { get; set; }

    public int? IdCliente { get; set; }

    public bool? IsActive { get; set; }
    public decimal? Total { get; set; }


    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<PedidoProducto> PedidoProductos { get; } = new List<PedidoProducto>();
}
