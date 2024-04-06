using System;
using System.Collections.Generic;

namespace GestionLab.Model;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    public int? IdSucursal { get; set; }

    public int IdTipoIdentificacion { get; set; }

    public int NumeroIdentificacion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? UrlFoto { get; set; }

    public bool Estado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Formato> Formatos { get; } = new List<Formato>();

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Sucursal? IdSucursalNavigation { get; set; }

    public virtual TipoIdentificacion IdTipoIdentificacionNavigation { get; set; } = null!;

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();

    public virtual ICollection<Veterinario> Veterinarios { get; } = new List<Veterinario>();
}
