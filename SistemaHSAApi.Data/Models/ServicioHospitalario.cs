using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class ServicioHospitalario
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
