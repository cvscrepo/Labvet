using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class TipoCampo
{
    public int IdTipoCampo { get; set; }

    public string? Nombre { get; set; }

    public string? TipoCampo1 { get; set; }

    public string? ValorReferencia { get; set; }

    public virtual ICollection<CampoFormato> CampoFormatos { get; } = new List<CampoFormato>();
}
