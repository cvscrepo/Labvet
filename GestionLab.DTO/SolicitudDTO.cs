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
    }
}
