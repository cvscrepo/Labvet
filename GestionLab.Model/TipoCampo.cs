using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class TipoCampo
{
    public int IdTipoCampo { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Campo> Campos { get; } = new List<Campo>();
}
