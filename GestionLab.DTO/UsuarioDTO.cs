using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public int IdRol { get; set; }

        public int? IdSucursal { get; set; }

        public int IdTipoIdentificacion { get; set; }

        public int NumeroIdentificacion { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public string? UrlFoto { get; set; }

        public int? Estado { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
