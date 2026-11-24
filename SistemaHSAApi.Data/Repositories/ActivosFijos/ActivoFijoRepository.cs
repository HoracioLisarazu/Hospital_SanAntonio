
using Microsoft.EntityFrameworkCore;
using SistemaHSAApi.Data.Data;
using SistemaHSAApi.Data.Interfaces.ActivosFijos;
using SistemaHSAApi.Data.Models;

namespace SistemaHSAApi.Data.Repositories.ActivosFijos;

public class ActivoFijoRepository : IActivoFijoRepository
{
    private readonly SistemaHSAContext _context;

    public ActivoFijoRepository(SistemaHSAContext context)
    {
        _context = context;
    }

    // Obtener todos los activos con sus relaciones
    public async Task<IReadOnlyList<ActivoFijo>> ObtenerTodosAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.ActivoFijos
            .AsNoTracking()
            .Include(a => a.IdCategoriaNavigation)
            .Include(a => a.IdTipoMobiliarioNavigation)
            .Include(a => a.IdEstadoNavigation)
            .Include(a => a.IdUbicacionNavigation)
            .Include(a => a.IdFuenteFinanciamientoNavigation)
            .OrderBy(a => a.CodigoInstitucional)
            .ToListAsync(cancellationToken);
    }

    // Buscar un activo por codigo institucional
    public async Task<ActivoFijo?> ObtenerPorCodigoAsync(
        string codigoInstitucional,
        CancellationToken cancellationToken = default)
    {
        return await _context.ActivoFijos
            .AsNoTracking()
            .Include(a => a.IdCategoriaNavigation)
            .Include(a => a.IdTipoMobiliarioNavigation)
            .Include(a => a.IdEstadoNavigation)
            .Include(a => a.IdUbicacionNavigation)
            .Include(a => a.IdFuenteFinanciamientoNavigation)
            .FirstOrDefaultAsync(
                a => a.CodigoInstitucional == codigoInstitucional,
                cancellationToken
            );
    }

    // Verificar si existe un activo
    public async Task<bool> ExisteAsync(
        string codigoInstitucional,
        CancellationToken cancellationToken = default)
    {
        return await _context.ActivoFijos
            .AnyAsync(
                a => a.CodigoInstitucional == codigoInstitucional,
                cancellationToken
            );
    }

    //Registrar un nuevo activo
    public async Task AgregarAsync(
        ActivoFijo activo,
        CancellationToken cancellationToken = default)
    {
        await _context.ActivoFijos.AddAsync(
            activo,
            cancellationToken
        );

        await _context.SaveChangesAsync(cancellationToken);
    }

    //Actualizar un activo existente
    public async Task ActualizarAsync(
        ActivoFijo activo,
        CancellationToken cancellationToken = default)
    {
        var activoExistente = await _context.ActivoFijos.FindAsync(
            new object[] { activo.CodigoInstitucional },
            cancellationToken
        );

        if (activoExistente == null)
        {
            throw new KeyNotFoundException(
                $"No se encontro el activo con codigo {activo.CodigoInstitucional}."
            );
        }

        _context.Entry(activoExistente)
            .CurrentValues.SetValues(activo);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
