using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.DTO
{
    public class SucursalDTO
    {
        public int IdSucursal { get; set; }

        public string Nombre { get; set; } = null!;

        public string Pais { get; set; } = null!;

        public string Ciudad { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UptadedAt { get; set; }
    }
}
