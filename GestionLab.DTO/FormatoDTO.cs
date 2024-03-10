using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DTO
{
    public class FormatoDTO
    {
        public int IdFormato { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdTipoFormato { get; set; }

        public int? IdSolicitud { get; set; }

        public string? Nombre { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<CampoFormatoDTO> CampoFormatos { get; } = new List<CampoFormatoDTO>();
    }
}
