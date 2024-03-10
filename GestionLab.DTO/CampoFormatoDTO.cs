using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DTO
{
    public class CampoFormatoDTO
    {
        public int IdCampo { get; set; }

        public int? IdFormato { get; set; }

        public string? TipoCampo { get; set; } // editado

        public string? Nombre { get; set; }

        public string? Valor { get; set; }

        public string? UrlFoto { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
