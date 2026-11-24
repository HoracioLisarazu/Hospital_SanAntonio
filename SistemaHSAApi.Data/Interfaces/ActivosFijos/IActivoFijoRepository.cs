
using SistemaHSAApi.Data.Models;

namespace SistemaHSAApi.Data.Interfaces.ActivosFijos;

public interface IActivoFijoRepository
{
    // Obtener todos los activos
    Task<IReadOnlyList<ActivoFijo>> ObtenerTodosAsync(
        CancellationToken cancellationToken = default
    );

    // Buscar un activo por codigo institucional
    Task<ActivoFijo?> ObtenerPorCodigoAsync(
        string codigoInstitucional,
        CancellationToken cancellationToken = default
    );

    // Verificar si existe un activo
    Task<bool> ExisteAsync(
        string codigoInstitucional,
        CancellationToken cancellationToken = default
    );

    // Registrar un nuevo activo
    Task AgregarAsync(
        ActivoFijo activo,
        CancellationToken cancellationToken = default
    );

    // Actualizar un activo existente
    Task ActualizarAsync(
        ActivoFijo activo,
        CancellationToken cancellationToken = default
    );
}
