using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class CampoFormato
{
    public int IdCampo { get; set; }

    public int? IdFormato { get; set; }

    public int? IdTipoCampo { get; set; }

    public string? Nombre { get; set; }

    public string? Valor { get; set; }

    public string? UrlFoto { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Formato? IdFormatoNavigation { get; set; }

    public virtual TipoCampo? IdTipoCampoNavigation { get; set; }
}
