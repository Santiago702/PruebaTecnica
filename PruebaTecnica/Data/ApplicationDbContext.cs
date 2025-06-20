using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Entities;

namespace PruebaTecnica.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alojamiento> Alojamientos { get; set; }

    public virtual DbSet<DetalleReserva> DetalleReservas { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    public virtual DbSet<Temporadum> Temporada { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alojamiento>(entity =>
        {
            entity.HasKey(e => e.IdAlojamiento);

            entity.ToTable("alojamiento");

            entity.Property(e => e.IdAlojamiento).HasColumnName("id_alojamiento");
            entity.Property(e => e.CapacidadPersonas).HasColumnName("capacidad_personas");
            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdSede).HasColumnName("id_sede");

            entity.HasOne(d => d.IdSedeNavigation).WithMany(p => p.Alojamientos)
                .HasForeignKey(d => d.IdSede)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_alojamiento_sede");
        });

        modelBuilder.Entity<DetalleReserva>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("detalle_reserva");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.DetalleReservas)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_reserva_habitacion");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.DetalleReservas)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_reserva_reserva");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion);

            entity.ToTable("habitacion");

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.BanoPrivado).HasColumnName("bano_privado");
            entity.Property(e => e.IdAlojamiento).HasColumnName("id_alojamiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroCamas).HasColumnName("numero_camas");

            entity.HasOne(d => d.IdAlojamientoNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdAlojamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_habitacion_alojamiento");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva);

            entity.ToTable("reserva");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaReserva)
                .HasColumnType("datetime")
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(20)
                .HasColumnName("id_usuario");
            entity.Property(e => e.NumeroPersonas).HasColumnName("numero_personas");
            entity.Property(e => e.TotalPagar)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_pagar");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reserva_usuario");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede);

            entity.ToTable("sede");

            entity.Property(e => e.IdSede).HasColumnName("id_sede");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(200)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.HasKey(e => e.IdTarifa);

            entity.ToTable("tarifa");

            entity.Property(e => e.IdTarifa).HasColumnName("id_tarifa");
            entity.Property(e => e.IdAlojamiento).HasColumnName("id_alojamiento");
            entity.Property(e => e.IdTemporada).HasColumnName("id_temporada");
            entity.Property(e => e.PrecioBase)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_base");
            entity.Property(e => e.PrecioPersona)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_persona");

            entity.HasOne(d => d.IdAlojamientoNavigation).WithMany(p => p.Tarifas)
                .HasForeignKey(d => d.IdAlojamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tarifa_alojamiento");

            entity.HasOne(d => d.IdTemporadaNavigation).WithMany(p => p.Tarifas)
                .HasForeignKey(d => d.IdTemporada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tarifa_temporada");
        });

        modelBuilder.Entity<Temporadum>(entity =>
        {
            entity.HasKey(e => e.IdTemporada);

            entity.ToTable("temporada");

            entity.Property(e => e.IdTemporada).HasColumnName("id_temporada");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario)
                .HasMaxLength(20)
                .HasColumnName("id_usuario");
            entity.Property(e => e.Celular).HasColumnName("celular");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .HasColumnName("clave");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
