
using Microsoft.EntityFrameworkCore;
using SistemaHSAApi.Data.Data;
using SistemaHSAApi.Data.Interfaces.ActivosFijos;
using SistemaHSAApi.Data.Models;

namespace SistemaHSAApi.Data.Repositories.ActivosFijos;

public class ParametroRepository : IParametroRepository
{
    private readonly SistemaHSAContext _context;

    public ParametroRepository(SistemaHSAContext context)
    {
        _context = context;
    }

    // Obtener todos los parametros
    public async Task<IReadOnlyList<Parametro>> ObtenerTodosAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Parametros
            .AsNoTracking()
            .OrderBy(p => p.Orden)
            .ThenBy(p => p.Nombre)
            .ToListAsync(cancellationToken);
    }

    // Obtener parametro por identificador
    public async Task<Parametro?> ObtenerPorIdAsync(
        int idParametro,
        CancellationToken cancellationToken = default)
    {
        return await _context.Parametros
            .AsNoTracking()
            .FirstOrDefaultAsync(
                p => p.IdParametro == idParametro,
                cancellationToken
            );
    }

    // Buscar parametro por codigo
    public async Task<Parametro?> ObtenerPorCodigoAsync(
        string codigo,
        CancellationToken cancellationToken = default)
    {
        return await _context.Parametros
            .AsNoTracking()
            .FirstOrDefaultAsync(
                p => p.Codigo == codigo,
                cancellationToken
            );
    }

    // Obtener parametros por padre
    public async Task<IReadOnlyList<Parametro>> ObtenerPorPadreAsync(
        int? idParametroPadre,
        CancellationToken cancellationToken = default)
    {
        return await _context.Parametros
            .AsNoTracking()
            .Where(p => p.IdParametroPadre == idParametroPadre)
            .OrderBy(p => p.Orden)
            .ThenBy(p => p.Nombre)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ExisteCodigoAsync(
        string codigo,
        int? idParametroExcluir = null,
        CancellationToken cancellationToken = default)
    {
        var consulta = _context.Parametros
            .AsNoTracking()
            .Where(p => p.Codigo == codigo);

        if (idParametroExcluir.HasValue)
        {
            consulta = consulta.Where(
                p => p.IdParametro != idParametroExcluir.Value
            );
        }

        return await consulta.AnyAsync(cancellationToken);
    }

    // Registrar parametro
    public async Task AgregarAsync(
        Parametro parametro,
        CancellationToken cancellationToken = default)
    {
        await _context.Parametros.AddAsync(
            parametro,
            cancellationToken
        );

        await _context.SaveChangesAsync(cancellationToken);
    }

    // Actualizar parametro
    public async Task ActualizarAsync(
        Parametro parametro,
        CancellationToken cancellationToken = default)
    {
        var parametroExistente = await _context.Parametros.FindAsync(
            new object[] { parametro.IdParametro },
            cancellationToken
        );

        if (parametroExistente == null)
        {
            throw new KeyNotFoundException(
                $"No se encontro el parametro con ID {parametro.IdParametro}."
            );
        }

        parametroExistente.IdParametroPadre = parametro.IdParametroPadre;
        parametroExistente.Codigo = parametro.Codigo;
        parametroExistente.Nombre = parametro.Nombre;
        parametroExistente.Descripcion = parametro.Descripcion;
        parametroExistente.Orden = parametro.Orden;
        parametroExistente.Activo = parametro.Activo;

        await _context.SaveChangesAsync(cancellationToken);
    }

    // Activar o desactivar parametro
    public async Task CambiarEstadoAsync(
        int idParametro,
        bool activo,
        CancellationToken cancellationToken = default)
    {
        var parametro = await _context.Parametros.FindAsync(
            new object[] { idParametro },
            cancellationToken
        );

        if (parametro == null)
        {
            throw new KeyNotFoundException(
                $"No se encontro el parametro con ID {idParametro}."
            );
        }

        parametro.Activo = activo;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
