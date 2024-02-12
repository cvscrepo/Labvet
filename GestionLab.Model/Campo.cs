using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Campo
{
    public int IdCampo { get; set; }

    public int? IdFormato { get; set; }

    public int? IdTipoCampo { get; set; }

    public string? Nombre { get; set; }

    public string? Valor { get; set; }

    public virtual Formato? IdFormatoNavigation { get; set; }

    public virtual TipoCampo? IdTipoCampoNavigation { get; set; }
}
