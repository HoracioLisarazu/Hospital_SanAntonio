using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class HistorialActivo
{
    public int IdHistorial { get; set; }

    public string CodigoInstitucional { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdTipoMovimiento { get; set; }

    public int? IdTipoMantenimiento { get; set; }

    public int? IdEstado { get; set; }

    public int? IdUbicacion { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public string? Descripcion { get; set; }

    public string? ResponsableMantenimiento { get; set; }

    public decimal? Costo { get; set; }

    public string? Observaciones { get; set; }

    public virtual ActivoFijo CodigoInstitucionalNavigation { get; set; } = null!;

    public virtual Parametro? IdEstadoNavigation { get; set; }

    public virtual Parametro? IdTipoMantenimientoNavigation { get; set; }

    public virtual Parametro IdTipoMovimientoNavigation { get; set; } = null!;

    public virtual Ubicacion? IdUbicacionNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
