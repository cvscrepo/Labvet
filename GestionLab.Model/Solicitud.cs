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

    public int? IdVeterinario { get; set; }

    public string? TamanoFragmento { get; set; }

    public int? TipoMuestra { get; set; }

    public int? TipoExamen { get; set; }

    public DateTime? FechaRecoleccion { get; set; }

    public string? HoraRecoleccion { get; set; }

    public string? Obserevaciones { get; set; }

    public string? UrlFotoMuestra { get; set; }

    public virtual Usuario CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Formato> Formatos { get; } = new List<Formato>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    public virtual TipoSolicitud IdTipoSolicitudNavigation { get; set; } = null!;

    public virtual Veterinario? IdVeterinarioNavigation { get; set; }

    public virtual TipoFormato? TipoExamenNavigation { get; set; }

    public virtual TipoMuestra? TipoMuestraNavigation { get; set; }
}
