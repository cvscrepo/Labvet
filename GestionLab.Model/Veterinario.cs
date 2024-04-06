using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Veterinario
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? TarjetaProfesional { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
