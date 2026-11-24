using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class Parametro
{
    public int IdParametro { get; set; }

    public int? IdParametroPadre { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Orden { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<ActivoFijo> ActivoFijoIdCategoriaNavigations { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<ActivoFijo> ActivoFijoIdEstadoNavigations { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<ActivoFijo> ActivoFijoIdFuenteFinanciamientoNavigations { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<ActivoFijo> ActivoFijoIdTipoMobiliarioNavigations { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<HistorialActivo> HistorialActivoIdEstadoNavigations { get; set; } = new List<HistorialActivo>();

    public virtual ICollection<HistorialActivo> HistorialActivoIdTipoMantenimientoNavigations { get; set; } = new List<HistorialActivo>();

    public virtual ICollection<HistorialActivo> HistorialActivoIdTipoMovimientoNavigations { get; set; } = new List<HistorialActivo>();

    public virtual Parametro? IdParametroPadreNavigation { get; set; }

    public virtual ICollection<Parametro> InverseIdParametroPadreNavigation { get; set; } = new List<Parametro>();
}
