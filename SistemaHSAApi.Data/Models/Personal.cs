using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class Personal
{
    public int IdPersonal { get; set; }

    public string Ci { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Cargo { get; set; }

    public string? Especialidad { get; set; }

    public int? IdServicio { get; set; }

    public string? Estado { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public string? CodigoBiometrico { get; set; }

    public virtual ICollection<AsignacionActivo> AsignacionActivos { get; set; } = new List<AsignacionActivo>();

    public virtual ServicioHospitalario? IdServicioNavigation { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
