using System;
using System.Collections.Generic;

namespace ABC.Model;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? IdentificacionCiudadania { get; set; }

    public string? Usuario1 { get; set; }

    public string? Contrasena { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? IsActive { get; set; }
}
