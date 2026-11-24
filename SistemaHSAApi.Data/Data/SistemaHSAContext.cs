using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaHSAApi.Data.Models;

namespace SistemaHSAApi.Data.Data;

public partial class SistemaHSAContext : DbContext
{
    public SistemaHSAContext(DbContextOptions<SistemaHSAContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivoFijo> ActivoFijos { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<AsignacionActivo> AsignacionActivos { get; set; }

    public virtual DbSet<AuditoriaModificacion> AuditoriaModificacions { get; set; }

    public virtual DbSet<DetalleAsignacionActivo> DetalleAsignacionActivos { get; set; }

    public virtual DbSet<HistorialActivo> HistorialActivos { get; set; }

    public virtual DbSet<Parametro> Parametros { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<ServicioHospitalario> ServicioHospitalarios { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivoFijo>(entity =>
        {
            entity.HasKey(e => e.CodigoInstitucional);

            entity.ToTable("ACTIVO_FIJO");

            entity.HasIndex(e => e.IdUbicacion, "IX_ACTIVO_UBICACION");

            entity.HasIndex(e => e.TokenQr, "UQ_ACTIVO_TOKENQR").IsUnique();

            entity.Property(e => e.CodigoInstitucional)
                .HasMaxLength(30)
                .HasColumnName("codigoInstitucional");
            entity.Property(e => e.Capacidad)
                .HasMaxLength(100)
                .HasColumnName("capacidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaAdquisicion).HasColumnName("fechaAdquisicion");
            entity.Property(e => e.FechaModificacion).HasColumnName("fechaModificacion");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdFuenteFinanciamiento).HasColumnName("idFuenteFinanciamiento");
            entity.Property(e => e.IdTipoMobiliario).HasColumnName("idTipoMobiliario");
            entity.Property(e => e.IdUbicacion).HasColumnName("idUbicacion");
            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("idUsuarioModificacion");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .HasColumnName("modelo");
            entity.Property(e => e.NumeroSerie)
                .HasMaxLength(100)
                .HasColumnName("numeroSerie");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .HasColumnName("observaciones");
            entity.Property(e => e.TokenQr)
                .HasMaxLength(100)
                .HasDefaultValueSql("(CONVERT([nvarchar](36),newid()))")
                .HasColumnName("tokenQR");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.ActivoFijoIdCategoriaNavigations)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACTIVO_CATEGORIA");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.ActivoFijoIdEstadoNavigations)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACTIVO_ESTADO");

            entity.HasOne(d => d.IdFuenteFinanciamientoNavigation).WithMany(p => p.ActivoFijoIdFuenteFinanciamientoNavigations)
                .HasForeignKey(d => d.IdFuenteFinanciamiento)
                .HasConstraintName("FK_ACTIVO_FINANCIAMIENTO");

            entity.HasOne(d => d.IdTipoMobiliarioNavigation).WithMany(p => p.ActivoFijoIdTipoMobiliarioNavigations)
                .HasForeignKey(d => d.IdTipoMobiliario)
                .HasConstraintName("FK_ACTIVO_TIPO_MOBILIARIO");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.ActivoFijos)
                .HasForeignKey(d => d.IdUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACTIVO_UBICACION");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.ActivoFijos)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_ACTIVO_USUARIO");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea);

            entity.ToTable("AREA");

            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaModificacion).HasColumnName("fechaModificacion");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("idUsuarioModificacion");
            entity.Property(e => e.NombreArea)
                .HasMaxLength(100)
                .HasColumnName("nombreArea");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Areas)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AREA_SERVICIO");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.Areas)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_AREA_USUARIO");
        });

        modelBuilder.Entity<AsignacionActivo>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion);

            entity.ToTable("ASIGNACION_ACTIVO");

            entity.HasIndex(e => e.NumeroAsignacion, "UQ_ASIGNACION_NUMERO").IsUnique();

            entity.HasIndex(e => e.NumeroActa, "UX_ASIGNACION_NUMERO_ACTA")
                .IsUnique()
                .HasFilter("([numeroActa] IS NOT NULL)");

            entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");
            entity.Property(e => e.ArchivoActaPdf)
                .HasMaxLength(500)
                .HasColumnName("archivoActaPDF");
            entity.Property(e => e.EstadoAsignacion)
                .HasMaxLength(40)
                .HasColumnName("estadoAsignacion");
            entity.Property(e => e.FechaActa).HasColumnName("fechaActa");
            entity.Property(e => e.FechaAsignacion).HasColumnName("fechaAsignacion");
            entity.Property(e => e.FechaModificacion).HasColumnName("fechaModificacion");
            entity.Property(e => e.IdPersonal).HasColumnName("idPersonal");
            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("idUsuarioModificacion");
            entity.Property(e => e.IdUsuarioRegistro).HasColumnName("idUsuarioRegistro");
            entity.Property(e => e.NumeroActa)
                .HasMaxLength(30)
                .HasColumnName("numeroActa");
            entity.Property(e => e.NumeroAsignacion)
                .HasMaxLength(30)
                .HasColumnName("numeroAsignacion");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .HasColumnName("observaciones");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.AsignacionActivos)
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ASIGNACION_PERSONAL");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.AsignacionActivoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_ASIGNACION_USUARIO_MODIFICACION");

            entity.HasOne(d => d.IdUsuarioRegistroNavigation).WithMany(p => p.AsignacionActivoIdUsuarioRegistroNavigations)
                .HasForeignKey(d => d.IdUsuarioRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ASIGNACION_USUARIO_REGISTRO");
        });

        modelBuilder.Entity<AuditoriaModificacion>(entity =>
        {
            entity.HasKey(e => e.IdModificacion);

            entity.ToTable("AUDITORIA_MODIFICACION");

            entity.HasIndex(e => new { e.IdUsuario, e.FechaModificacion }, "IX_AUDITORIA_USUARIO_FECHA");

            entity.Property(e => e.IdModificacion).HasColumnName("idModificacion");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.IdentificadorRegistro)
                .HasMaxLength(150)
                .HasColumnName("identificadorRegistro");
            entity.Property(e => e.NombreTabla)
                .HasMaxLength(100)
                .HasColumnName("nombreTabla");
            entity.Property(e => e.TipoOperacion)
                .HasMaxLength(20)
                .HasColumnName("tipoOperacion");
            entity.Property(e => e.ValoresAnteriores).HasColumnName("valoresAnteriores");
            entity.Property(e => e.ValoresNuevos).HasColumnName("valoresNuevos");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AuditoriaModificacions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AUDITORIA_USUARIO");
        });

        modelBuilder.Entity<DetalleAsignacionActivo>(entity =>
        {
            entity.HasKey(e => e.IdDetalleAsignacion);

            entity.ToTable("DETALLE_ASIGNACION_ACTIVO");

            entity.HasIndex(e => e.IdAsignacion, "IX_DETALLE_ASIGNACION");

            entity.HasIndex(e => new { e.IdAsignacion, e.CodigoInstitucional }, "UQ_DETALLE_ASIGNACION_ACTIVO").IsUnique();

            entity.HasIndex(e => e.CodigoInstitucional, "UX_ACTIVO_CUSTODIA_VIGENTE")
                .IsUnique()
                .HasFilter("([estadoDetalle]='ENTREGADO' AND [fechaDevolucion] IS NULL)");

            entity.Property(e => e.IdDetalleAsignacion).HasColumnName("idDetalleAsignacion");
            entity.Property(e => e.CodigoInstitucional)
                .HasMaxLength(30)
                .HasColumnName("codigoInstitucional");
            entity.Property(e => e.EstadoDetalle)
                .HasMaxLength(40)
                .HasColumnName("estadoDetalle");
            entity.Property(e => e.FechaDevolucion).HasColumnName("fechaDevolucion");
            entity.Property(e => e.FechaDevolucionPrevista).HasColumnName("fechaDevolucionPrevista");
            entity.Property(e => e.FechaModificacion).HasColumnName("fechaModificacion");
            entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");
            entity.Property(e => e.IdUsuarioDevolucion).HasColumnName("idUsuarioDevolucion");
            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("idUsuarioModificacion");
            entity.Property(e => e.IdUsuarioRegistro).HasColumnName("idUsuarioRegistro");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .HasColumnName("observaciones");


            entity.HasOne(d => d.CodigoInstitucionalNavigation)
                .WithMany(p => p.DetalleAsignacionActivos)
                .HasForeignKey(d => d.CodigoInstitucional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_ACTIVO");


            entity.HasOne(d => d.IdAsignacionNavigation).WithMany(p => p.DetalleAsignacionActivos)
                .HasForeignKey(d => d.IdAsignacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_ASIGNACION");

            entity.HasOne(d => d.IdUsuarioDevolucionNavigation).WithMany(p => p.DetalleAsignacionActivoIdUsuarioDevolucionNavigations)
                .HasForeignKey(d => d.IdUsuarioDevolucion)
                .HasConstraintName("FK_DETALLE_USUARIO_DEVOLUCION");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.DetalleAsignacionActivoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_DETALLE_USUARIO_MODIFICACION");

            entity.HasOne(d => d.IdUsuarioRegistroNavigation).WithMany(p => p.DetalleAsignacionActivoIdUsuarioRegistroNavigations)
                .HasForeignKey(d => d.IdUsuarioRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_USUARIO_REGISTRO");
        });

        modelBuilder.Entity<HistorialActivo>(entity =>
        {
            entity.HasKey(e => e.IdHistorial);

            entity.ToTable("HISTORIAL_ACTIVO");

            entity.HasIndex(e => e.CodigoInstitucional, "IX_HISTORIAL_ACTIVO");

            entity.Property(e => e.IdHistorial).HasColumnName("idHistorial");
            entity.Property(e => e.CodigoInstitucional)
                .HasMaxLength(30)
                .HasColumnName("codigoInstitucional");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("fechaMovimiento");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdTipoMantenimiento).HasColumnName("idTipoMantenimiento");
            entity.Property(e => e.IdTipoMovimiento).HasColumnName("idTipoMovimiento");
            entity.Property(e => e.IdUbicacion).HasColumnName("idUbicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .HasColumnName("observaciones");
            entity.Property(e => e.ResponsableMantenimiento)
                .HasMaxLength(150)
                .HasColumnName("responsableMantenimiento");

            entity.HasOne(d => d.CodigoInstitucionalNavigation).WithMany(p => p.HistorialActivos)
                .HasForeignKey(d => d.CodigoInstitucional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIAL_ACTIVO");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.HistorialActivoIdEstadoNavigations)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK_HISTORIAL_ESTADO");

            entity.HasOne(d => d.IdTipoMantenimientoNavigation).WithMany(p => p.HistorialActivoIdTipoMantenimientoNavigations)
                .HasForeignKey(d => d.IdTipoMantenimiento)
                .HasConstraintName("FK_HISTORIAL_TIPO_MANTENIMIENTO");

            entity.HasOne(d => d.IdTipoMovimientoNavigation).WithMany(p => p.HistorialActivoIdTipoMovimientoNavigations)
                .HasForeignKey(d => d.IdTipoMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIAL_TIPO_MOVIMIENTO");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.HistorialActivos)
                .HasForeignKey(d => d.IdUbicacion)
                .HasConstraintName("FK_HISTORIAL_UBICACION");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialActivos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIAL_USUARIO");
        });

        modelBuilder.Entity<Parametro>(entity =>
        {
            entity.HasKey(e => e.IdParametro);

            entity.ToTable("PARAMETRO");

            entity.HasIndex(e => e.Codigo, "UQ_PARAMETRO_CODIGO").IsUnique();

            entity.Property(e => e.IdParametro).HasColumnName("idParametro");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdParametroPadre).HasColumnName("idParametroPadre");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Orden).HasColumnName("orden");

            entity.HasOne(d => d.IdParametroPadreNavigation).WithMany(p => p.InverseIdParametroPadreNavigation)
                .HasForeignKey(d => d.IdParametroPadre)
                .HasConstraintName("FK_PARAMETRO_PADRE");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal);

            entity.ToTable("PERSONAL");

            entity.HasIndex(e => e.Ci, "UQ_PERSONAL_CI").IsUnique();

            entity.HasIndex(e => e.CodigoBiometrico, "UX_PERSONAL_CODIGO_BIOMETRICO")
                .IsUnique()
                .HasFilter("([codigoBiometrico] IS NOT NULL)");

            entity.Property(e => e.IdPersonal).HasColumnName("idPersonal");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cargo)
                .HasMaxLength(100)
                .HasColumnName("cargo");
            entity.Property(e => e.Ci)
                .HasMaxLength(20)
                .HasColumnName("CI");
            entity.Property(e => e.CodigoBiometrico)
                .HasMaxLength(50)
                .HasColumnName("codigoBiometrico");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(150)
                .HasColumnName("especialidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK_PERSONAL_SERVICIO");
        });

        modelBuilder.Entity<ServicioHospitalario>(entity =>
        {
            entity.HasKey(e => e.IdServicio);

            entity.ToTable("SERVICIO_HOSPITALARIO");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(100)
                .HasColumnName("nombreServicio");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion);

            entity.ToTable("UBICACION");

            entity.HasIndex(e => e.CodigoUbicacion, "UQ_UBICACION_CODIGO").IsUnique();

            entity.Property(e => e.IdUbicacion).HasColumnName("idUbicacion");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.CodigoUbicacion)
                .HasMaxLength(30)
                .HasColumnName("codigoUbicacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaModificacion).HasColumnName("fechaModificacion");
            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("idUsuarioModificacion");
            entity.Property(e => e.NombreUbicacion)
                .HasMaxLength(100)
                .HasColumnName("nombreUbicacion");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Ubicacions)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UBICACION_AREA");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.Ubicacions)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_UBICACION_USUARIO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.NombreUsuario, "UQ_USUARIO_NOMBRE").IsUnique();

            entity.HasIndex(e => e.IdPersonal, "UQ_USUARIO_PERSONAL").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.ClaveHash)
                .HasMaxLength(255)
                .HasColumnName("claveHash");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdPersonal).HasColumnName("idPersonal");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasColumnName("rol");

            entity.HasOne(d => d.IdPersonalNavigation).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_PERSONAL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
