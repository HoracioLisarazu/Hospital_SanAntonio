
using SistemaHSAApi.Data.Models;

namespace SistemaHSAApi.Data.Interfaces.ActivosFijos;

public interface IParametroRepository
{
    //Obtener todos los parametros
    Task<IReadOnlyList<Parametro>> ObtenerTodosAsync(
        CancellationToken cancellationToken = default
    );

    //Obtener un parametro por su identificador
    Task<Parametro?> ObtenerPorIdAsync(
        int idParametro,
        CancellationToken cancellationToken = default
    );

    //Buscar un parametro por codigo
    Task<Parametro?> ObtenerPorCodigoAsync(
        string codigo,
        CancellationToken cancellationToken = default
    );

    // Obtener parametros hijos de un parametro padre
    Task<IReadOnlyList<Parametro>> ObtenerPorPadreAsync(
        int? idParametroPadre,
        CancellationToken cancellationToken = default
    );

    //Verificar si existe un codigo
    Task<bool> ExisteCodigoAsync(
        string codigo,
        int? idParametroExcluir = null,
        CancellationToken cancellationToken = default
    );

    //Registrar un parametro
    Task AgregarAsync(
        Parametro parametro,
        CancellationToken cancellationToken = default
    );

    //Actualizar un parametro
    Task ActualizarAsync(
        Parametro parametro,
        CancellationToken cancellationToken = default
    );

    //Activar o desactivar
    Task CambiarEstadoAsync(
        int idParametro,
        bool activo,
        CancellationToken cancellationToken = default
    );
}
