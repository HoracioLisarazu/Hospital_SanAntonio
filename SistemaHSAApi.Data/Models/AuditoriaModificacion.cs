using System;
using System.Collections.Generic;

namespace SistemaHSAApi.Data.Models;

public partial class AuditoriaModificacion
{
    public int IdModificacion { get; set; }

    public int IdUsuario { get; set; }

    public string NombreTabla { get; set; } = null!;

    public string IdentificadorRegistro { get; set; } = null!;

    public string TipoOperacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public string? ValoresAnteriores { get; set; }

    public string? ValoresNuevos { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
