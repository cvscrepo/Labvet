using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DTO
{
    public class PacienteDTO
    {
        public int IdPaciente { get; set; }

        public int? IdCliente { get; set; }

        public string? NombrePaciente { get; set; }

        public string? Raza { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UptadetAt { get; set; }
    }
}
