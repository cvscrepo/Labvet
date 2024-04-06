using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class TipoMuestra
{
    public int IdTipoMuestra { get; set; }

    public string? NombreTipo { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
