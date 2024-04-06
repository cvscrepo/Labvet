using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DTO
{
    public class SolicitudDTO
    {
        public int IdSolicitud { get; set; }

        public int CreatedBy { get; set; }

        public int IdTipoSolicitud { get; set; }

        public int IdCliente { get; set; }

        public int IdPaciente { get; set; }

        public string Nombre { get; set; } = null!;

        public bool Estado { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? IdVeterinario { get; set; }

        public string? TamanoFragmento { get; set; }

        public int? TipoMuestra { get; set; }

        public int? TipoExamen { get; set; }

        public DateTime? FechaRecoleccion { get; set; }

        public string? HoraRecoleccion { get; set; }

        public string? Obserevaciones { get; set; }

        public string? UrlFotoMuestra { get; set; }

        public virtual UsuarioDTO CreatedByNavigation { get; set; } = null!;

        public virtual ClienteDTO IdClienteNavigation { get; set; } = null!;

        public virtual PacienteDTO IdPacienteNavigation { get; set; } = null!;

    }
}
