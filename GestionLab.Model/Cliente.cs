using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NombreCompleto { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; } = new List<Paciente>();

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
