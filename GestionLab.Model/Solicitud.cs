using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public int CreatedBy { get; set; }

    public int IdTipoSolicitud { get; set; }

    public int IdCliente { get; set; }

    public int IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Usuario CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Formato> Formatos { get; } = new List<Formato>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual TipoSolicitud IdTipoSolicitudNavigation { get; set; } = null!;
}
