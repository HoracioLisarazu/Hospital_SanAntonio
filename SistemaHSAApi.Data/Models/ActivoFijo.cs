using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class ActivoFijo
{
    public string CodigoInstitucional { get; set; } = null!;

    public string TokenQr { get; set; } = null!;

    public DateOnly FechaAdquisicion { get; set; }

    public string? NumeroSerie { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Capacidad { get; set; }

    public int IdCategoria { get; set; }

    public int? IdTipoMobiliario { get; set; }

    public int IdEstado { get; set; }

    public int IdUbicacion { get; set; }

    public int? IdFuenteFinanciamiento { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public virtual ICollection<DetalleAsignacionActivo> DetalleAsignacionActivos { get; set; }
     = new List<DetalleAsignacionActivo>();

    public virtual ICollection<HistorialActivo> HistorialActivos { get; set; } = new List<HistorialActivo>();

    public virtual Parametro IdCategoriaNavigation { get; set; } = null!;

    public virtual Parametro IdEstadoNavigation { get; set; } = null!;

    public virtual Parametro? IdFuenteFinanciamientoNavigation { get; set; }

    public virtual Parametro? IdTipoMobiliarioNavigation { get; set; }

    public virtual Ubicacion IdUbicacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }
}
