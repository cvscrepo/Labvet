using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UptadedAt { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
