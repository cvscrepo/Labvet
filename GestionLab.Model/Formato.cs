using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Formato
{
    public int IdFormato { get; set; }

    public int? IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Campo> Campos { get; } = new List<Campo>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
