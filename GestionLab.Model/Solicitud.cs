using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTipo { get; set; }

    public int? IdFormato { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Formato? IdFormatoNavigation { get; set; }

    public virtual TipoSolicitud? IdTipoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
