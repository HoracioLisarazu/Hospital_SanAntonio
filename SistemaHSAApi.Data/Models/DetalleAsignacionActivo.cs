using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class DetalleAsignacionActivo
{
    public int IdDetalleAsignacion { get; set; }

    public int IdAsignacion { get; set; }

    public string CodigoInstitucional { get; set; } = null!;

    public DateTime? FechaDevolucionPrevista { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public int? IdUsuarioDevolucion { get; set; }

    public int IdUsuarioRegistro { get; set; }

    public string EstadoDetalle { get; set; } = null!;

    public string? Observaciones { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public virtual ActivoFijo CodigoInstitucionalNavigation { get; set; } = null!;

    public virtual AsignacionActivo IdAsignacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioDevolucionNavigation { get; set; }

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }

    public virtual Usuario IdUsuarioRegistroNavigation { get; set; } = null!;
}
