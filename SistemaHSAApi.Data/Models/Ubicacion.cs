using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class Ubicacion
{
    public int IdUbicacion { get; set; }

    public string CodigoUbicacion { get; set; } = null!;

    public int IdArea { get; set; }

    public string NombreUbicacion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public virtual ICollection<ActivoFijo> ActivoFijos { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<HistorialActivo> HistorialActivos { get; set; } = new List<HistorialActivo>();

    public virtual Area IdAreaNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }
}
