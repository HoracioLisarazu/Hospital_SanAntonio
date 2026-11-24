using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdPersonal { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ClaveHash { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<ActivoFijo> ActivoFijos { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    public virtual ICollection<AsignacionActivo> AsignacionActivoIdUsuarioModificacionNavigations { get; set; } = new List<AsignacionActivo>();

    public virtual ICollection<AsignacionActivo> AsignacionActivoIdUsuarioRegistroNavigations { get; set; } = new List<AsignacionActivo>();

    public virtual ICollection<AuditoriaModificacion> AuditoriaModificacions { get; set; } = new List<AuditoriaModificacion>();

    public virtual ICollection<DetalleAsignacionActivo> DetalleAsignacionActivoIdUsuarioDevolucionNavigations { get; set; } = new List<DetalleAsignacionActivo>();

    public virtual ICollection<DetalleAsignacionActivo> DetalleAsignacionActivoIdUsuarioModificacionNavigations { get; set; } = new List<DetalleAsignacionActivo>();

    public virtual ICollection<DetalleAsignacionActivo> DetalleAsignacionActivoIdUsuarioRegistroNavigations { get; set; } = new List<DetalleAsignacionActivo>();

    public virtual ICollection<HistorialActivo> HistorialActivos { get; set; } = new List<HistorialActivo>();

    public virtual Personal IdPersonalNavigation { get; set; } = null!;

    public virtual ICollection<Ubicacion> Ubicacions { get; set; } = new List<Ubicacion>();
}
