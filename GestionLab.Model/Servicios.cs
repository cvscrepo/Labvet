using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.Model
{
    public class Servicios
    {
        public int IdServicios { get; set; }
        public string NombreServicio { get; set; }
        public string Descripcion { get; set; }
        public string? ImgReferenced { get; set; }
    }
}
