using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? IdentificacionCiudadania { get; set; }

        public string? Usuario1 { get; set; }

        public string? Contrasena { get; set; }

        public int? IsActive { get; set; }
    }
}
