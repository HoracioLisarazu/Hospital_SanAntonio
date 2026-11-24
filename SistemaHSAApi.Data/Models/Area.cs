using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class Area
{
    public int IdArea { get; set; }

    public int IdServicio { get; set; }

    public string NombreArea { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public virtual ServicioHospitalario IdServicioNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }

    public virtual ICollection<Ubicacion> Ubicacions { get; set; } = new List<Ubicacion>();
}
