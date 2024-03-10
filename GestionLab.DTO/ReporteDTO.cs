using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DTO
{
    public class ReporteDTO
    {
        public string? NumeroFormato { get; set; }
        public string? FechaRegistro { get; set; }
        public string? TipoPago { get; set; }
        public SolicitudDTO? Solicitud { get; set;}
        public string? Precio {  get; set; }
        public string? Descuento { get; set; }
        public string? Total { get; set; }

    }
}
