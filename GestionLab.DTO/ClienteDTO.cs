using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }

        public string? NombreCompleto { get; set; }

        public string? CorreoElectronico { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<PacienteDTO> Pacientes { get; } = new List<PacienteDTO>();

        public virtual ICollection<SolicitudDTO> Solicituds { get; } = new List<SolicitudDTO>();
    }
}
