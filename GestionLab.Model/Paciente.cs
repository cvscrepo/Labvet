using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public int? IdCliente { get; set; }

    public string? NombrePaciente { get; set; }

    public string? Raza { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UptadetAt { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
