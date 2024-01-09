using System;
using System.Collections.Generic;

namespace ABC.Model { };

public partial class PedidoProducto
{
    public int IdPedidoProducto { get; set; }
    public int? IdPedido { get; set; }
    public int? IdProducto { get; set; }
    public int? Cantidad { get; set; }
    public decimal? PrecioUnitario { get; set; }
    public decimal? PrecioTotal { get; set; }
    public virtual Pedido? IdPedidoNavigation { get; set; }
    public virtual Producto? IdProductoNavigation { get; set; }
}
