using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class TipoSolicitud
{
    public int IdTipoSolicitud { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
