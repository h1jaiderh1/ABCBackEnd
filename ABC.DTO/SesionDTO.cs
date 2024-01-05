using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.DTO
{
    public class SesionDTO
    {
        public int IdUsuario { get; set; }

        public string? Nombres { get; set; }

        public static implicit operator List<object>(SesionDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
