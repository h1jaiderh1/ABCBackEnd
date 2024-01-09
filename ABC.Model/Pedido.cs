using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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

    public virtual ICollection<PedidoProducto> PedidoProductos { get; } = new List<PedidoProducto>();
}
