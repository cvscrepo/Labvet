using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class TipoFormato
{
    public int IdTipoFormato { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Formato> Formatos { get; } = new List<Formato>();

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
