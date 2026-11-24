using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class AsignacionActivo
{
    public int IdAsignacion { get; set; }

    public string NumeroAsignacion { get; set; } = null!;

    public int IdPersonal { get; set; }

    public int IdUsuarioRegistro { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public DateTime? FechaActa { get; set; }

    public string? NumeroActa { get; set; }

    public string? ArchivoActaPdf { get; set; }

    public string EstadoAsignacion { get; set; } = null!;

    public string? Observaciones { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public virtual ICollection<DetalleAsignacionActivo> DetalleAsignacionActivos { get; set; } = new List<DetalleAsignacionActivo>();

    public virtual Personal IdPersonalNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }

    public virtual Usuario IdUsuarioRegistroNavigation { get; set; } = null!;
}
