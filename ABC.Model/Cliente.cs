using System;
using System.Collections.Generic;

namespace ABC.Model;

public partial class Cliente
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

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
