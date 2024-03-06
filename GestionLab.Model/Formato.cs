using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Formato
{
    public int IdFormato { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTipoFormato { get; set; }

    public int? IdSolicitud { get; set; }

    public string? Nombre { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CampoFormato> CampoFormatos { get; } = new List<CampoFormato>();

    public virtual Solicitud? IdSolicitudNavigation { get; set; }

    public virtual TipoFormato? IdTipoFormatoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
