using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Caso2.Models;

public partial class ServiciosDbContext : DbContext
{
    public ServiciosDbContext()
    {
    }

    public ServiciosDbContext(DbContextOptions<ServiciosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Informesprogreso> Informesprogresos { get; set; }

    public virtual DbSet<Interaccione> Interacciones { get; set; }

    public virtual DbSet<Presupuesto> Presupuestos { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=servicios_db;user=root;password=admin123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.CorreoContacto).HasMaxLength(100);
            entity.Property(e => e.NombreContacto).HasMaxLength(100);
            entity.Property(e => e.NombreEmpresa).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Informesprogreso>(entity =>
        {
            entity.HasKey(e => e.InformeId).HasName("PRIMARY");

            entity.ToTable("informesprogreso");

            entity.HasIndex(e => e.ProyectoId, "ProyectoId");

            entity.Property(e => e.Descripcion).HasColumnType("text");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Informesprogresos)
                .HasForeignKey(d => d.ProyectoId)
                .HasConstraintName("informesprogreso_ibfk_1");
        });

        modelBuilder.Entity<Interaccione>(entity =>
        {
            entity.HasKey(e => e.InteraccionId).HasName("PRIMARY");

            entity.ToTable("interacciones");

            entity.HasIndex(e => e.ClienteId, "ClienteId");

            entity.HasIndex(e => e.ProyectoId, "ProyectoId");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("interacciones_ibfk_1");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.ProyectoId)
                .HasConstraintName("interacciones_ibfk_2");
        });

        modelBuilder.Entity<Presupuesto>(entity =>
        {
            entity.HasKey(e => e.PresupuestoId).HasName("PRIMARY");

            entity.ToTable("presupuestos");

            entity.HasIndex(e => e.ProyectoId, "ProyectoId");

            entity.Property(e => e.MontoEstimado).HasPrecision(12, 2);
            entity.Property(e => e.MontoReal).HasPrecision(12, 2);

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Presupuestos)
                .HasForeignKey(d => d.ProyectoId)
                .HasConstraintName("presupuestos_ibfk_1");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.ProyectoId).HasName("PRIMARY");

            entity.ToTable("proyectos");

            entity.HasIndex(e => e.ResponsableId, "ResponsableId");

            entity.Property(e => e.DescripcionObjetivos).HasColumnType("text");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Responsable).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.ResponsableId)
                .HasConstraintName("proyectos_ibfk_1");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PRIMARY");

            entity.ToTable("tareas");

            entity.HasIndex(e => e.EmpleadoId, "EmpleadoId");

            entity.HasIndex(e => e.ProyectoId, "ProyectoId");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("tareas_ibfk_2");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.ProyectoId)
                .HasConstraintName("tareas_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
