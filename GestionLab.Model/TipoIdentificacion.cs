using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class TipoIdentificacion
{
    public int IdTipoIdentificacion { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
