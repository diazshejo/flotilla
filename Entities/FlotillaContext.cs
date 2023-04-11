using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace flotilla.Entities;

public partial class FlotillaContext : DbContext
{
    public FlotillaContext()
    {
    }

    public FlotillaContext(DbContextOptions<FlotillaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Camione> Camiones { get; set; }

    public virtual DbSet<Combustible> Combustibles { get; set; }

    public virtual DbSet<Conductore> Conductores { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Ruta> Rutas { get; set; }

    public virtual DbSet<Seguro> Seguros { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=44.201.161.76;port=3306;user=flotilla;password=Umganalisi!23;persistsecurityinfo=True;database=flotilla");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Camione>(entity =>
        {
            entity.HasKey(e => e.Id_Camion).HasName("PRIMARY");

            entity.Property(e => e.Id_Camion).HasColumnName("id_camion");
            entity.Property(e => e.Anio_Fabricacion).HasColumnName("anio_fabricacion");
            entity.Property(e => e.Capacidad_Carga)
                .HasPrecision(10)
                .HasColumnName("capacidad_carga");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha_Compra)
                .HasColumnType("date")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.Marca_Modelo)
                .HasMaxLength(255)
                .HasColumnName("marca_modelo");
        });

        modelBuilder.Entity<Combustible>(entity =>
        {
            entity.HasKey(e => e.IdCombustible).HasName("PRIMARY");

            entity.ToTable("Combustible");

            entity.HasIndex(e => e.Id_Camion, "id_camion");

            entity.HasIndex(e => e.IdConductor, "id_conductor");

            entity.Property(e => e.IdCombustible).HasColumnName("id_combustible");
            entity.Property(e => e.Cantidad)
                .HasPrecision(10)
                .HasColumnName("cantidad");
            entity.Property(e => e.Costo)
                .HasPrecision(10)
                .HasColumnName("costo");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Id_Camion).HasColumnName("id_camion");
            entity.Property(e => e.IdConductor).HasColumnName("id_conductor");

            entity.HasOne(d => d.Id_CamionNavigation).WithMany(p => p.Combustibles)
                .HasForeignKey(d => d.Id_Camion)
                .HasConstraintName("Combustible_ibfk_2");

            entity.HasOne(d => d.IdConductorNavigation).WithMany(p => p.Combustibles)
                .HasForeignKey(d => d.IdConductor)
                .HasConstraintName("Combustible_ibfk_1");
        });

        modelBuilder.Entity<Conductore>(entity =>
        {
            entity.HasKey(e => e.IdConductor).HasName("PRIMARY");

            entity.Property(e => e.IdConductor).HasColumnName("id_conductor");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(20)
                .HasColumnName("identificacion");
            entity.Property(e => e.LicenciaConducir)
                .HasMaxLength(20)
                .HasColumnName("licencia_conducir");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.IdMantenimiento).HasName("PRIMARY");

            entity.ToTable("Mantenimiento");

            entity.HasIndex(e => e.Id_Camion, "id_camion");

            entity.Property(e => e.IdMantenimiento).HasColumnName("id_mantenimiento");
            entity.Property(e => e.Costo)
                .HasPrecision(10)
                .HasColumnName("costo");
            entity.Property(e => e.FechaServicio)
                .HasColumnType("date")
                .HasColumnName("fecha_servicio");
            entity.Property(e => e.Id_Camion).HasColumnName("id_camion");
            entity.Property(e => e.Kilometraje).HasColumnName("kilometraje");
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(255)
                .HasColumnName("tipo_servicio");

            entity.HasOne(d => d.Id_CamionNavigation).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.Id_Camion)
                .HasConstraintName("Mantenimiento_ibfk_1");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PRIMARY");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Cantidad)
                .HasPrecision(10)
                .HasColumnName("cantidad");
            entity.Property(e => e.Cliente)
                .HasMaxLength(255)
                .HasColumnName("cliente");
            entity.Property(e => e.FechaPedido)
                .HasColumnType("date")
                .HasColumnName("fecha_pedido");
            entity.Property(e => e.Peso)
                .HasPrecision(10)
                .HasColumnName("peso");
            entity.Property(e => e.TipoCarga)
                .HasMaxLength(255)
                .HasColumnName("tipo_carga");
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.IdRuta).HasName("PRIMARY");

            entity.Property(e => e.IdRuta).HasColumnName("id_ruta");
            entity.Property(e => e.Destino)
                .HasMaxLength(255)
                .HasColumnName("destino");
            entity.Property(e => e.Distancia)
                .HasPrecision(10)
                .HasColumnName("distancia");
            entity.Property(e => e.Origen)
                .HasMaxLength(255)
                .HasColumnName("origen");
            entity.Property(e => e.RestriccionesHorario)
                .HasMaxLength(255)
                .HasColumnName("restricciones_horario");
            entity.Property(e => e.TiempoEstimadoLlegada)
                .HasColumnType("time")
                .HasColumnName("tiempo_estimado_llegada");
        });

        modelBuilder.Entity<Seguro>(entity =>
        {
            entity.HasKey(e => e.IdSeguro).HasName("PRIMARY");

            entity.HasIndex(e => e.Id_Camion, "id_camion");

            entity.Property(e => e.IdSeguro).HasColumnName("id_seguro");
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Id_Camion).HasColumnName("id_camion");
            entity.Property(e => e.MontoAsegurado)
                .HasPrecision(10)
                .HasColumnName("monto_asegurado");
            entity.Property(e => e.Poliza)
                .HasMaxLength(20)
                .HasColumnName("poliza");
            entity.Property(e => e.TipoCobertura)
                .HasMaxLength(255)
                .HasColumnName("tipo_cobertura");

            entity.HasOne(d => d.Id_CamionNavigation).WithMany(p => p.Seguros)
                .HasForeignKey(d => d.Id_Camion)
                .HasConstraintName("Seguros_ibfk_1");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.IdViaje).HasName("PRIMARY");

            entity.HasIndex(e => e.Id_Camion, "id_camion");

            entity.HasIndex(e => e.IdConductor, "id_conductor");

            entity.HasIndex(e => e.IdRuta, "id_ruta");

            entity.Property(e => e.IdViaje).HasColumnName("id_viaje");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Id_Camion).HasColumnName("id_camion");
            entity.Property(e => e.IdConductor).HasColumnName("id_conductor");
            entity.Property(e => e.IdRuta).HasColumnName("id_ruta");
            entity.Property(e => e.PedidosEntregados)
                .HasMaxLength(255)
                .HasColumnName("pedidos_entregados");
            entity.Property(e => e.TiempoLlegada)
                .HasColumnType("time")
                .HasColumnName("tiempo_llegada");
            entity.Property(e => e.TiempoSalida)
                .HasColumnType("time")
                .HasColumnName("tiempo_salida");

            entity.HasOne(d => d.Id_CamionNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.Id_Camion)
                .HasConstraintName("Viajes_ibfk_2");

            entity.HasOne(d => d.IdConductorNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdConductor)
                .HasConstraintName("Viajes_ibfk_1");

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdRuta)
                .HasConstraintName("Viajes_ibfk_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
