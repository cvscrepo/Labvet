using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DTO
{
    public class VeterinarioDTO
    {
        public int Id { get; set; }

        public int? IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? TarjetaProfesional { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
