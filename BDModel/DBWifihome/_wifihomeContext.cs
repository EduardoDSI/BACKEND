using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BDModel.DBWifihome;

public partial class _wifihomeContext : DbContext
{
    public _wifihomeContext()
    {
    }

    public _wifihomeContext(DbContextOptions<_wifihomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencium> Asistencia { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<ContratoUsuario> ContratoUsuarios { get; set; }

    public virtual DbSet<Cronograma> Cronogramas { get; set; }

    public virtual DbSet<DetalleContrato> DetalleContratos { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<ProductoCliente> ProductoClientes { get; set; }

    public virtual DbSet<ProductoServicio> ProductoServicios { get; set; }

    public virtual DbSet<QuejasReclamo> QuejasReclamos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Ubigeo> Ubigeos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vpersona> Vpersonas { get; set; }

    public virtual DbSet<Vusuario> Vusuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-OIAVDFE6\\SQLEXPRESS;Initial Catalog=WIFIHOME;Integrated Security=True;Trusted_Connection=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencium>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PK__Asistenc__20240AC4382DC13E");

            entity.Property(e => e.IdAsistencia).HasColumnName("Id_Asistencia");
            entity.Property(e => e.FechaAsistencia).HasColumnType("date");
            entity.Property(e => e.FechaReali).HasColumnType("datetime");
            entity.Property(e => e.IdContrato).HasColumnName("Id_Contrato");
            entity.Property(e => e.Observaciones).HasColumnType("text");
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_Servicio");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("FK__Asistenci__Id_Co__4D94879B");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PK__Contrato__400B67708872EA59");

            entity.ToTable("Contrato");

            entity.Property(e => e.IdContrato).HasColumnName("Id_Contrato");
            entity.Property(e => e.Estado)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FechaContrato)
                .HasColumnType("date")
                .HasColumnName("Fecha_Contrato");
            entity.Property(e => e.FechaVenContrato)
                .HasColumnType("date")
                .HasColumnName("Fecha_VenContrato");
            entity.Property(e => e.ModoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modo_Pago");
            entity.Property(e => e.MontoPagado)
                .HasColumnType("money")
                .HasColumnName("Monto_Pagado");
            entity.Property(e => e.MontoTarifaPlana)
                .HasColumnType("money")
                .HasColumnName("Monto_TarifaPlana");
            entity.Property(e => e.TipoComprobante)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Tipo_Comprobante");
        });

        modelBuilder.Entity<ContratoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdContrUsuario).HasName("PK__Contrato__E44CA4F44ABECA9B");

            entity.ToTable("Contrato_Usuario");

            entity.Property(e => e.IdContrUsuario).HasColumnName("Id_Contr_Usuario");
            entity.Property(e => e.IdContrato).HasColumnName("Id_Contrato");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.ContratoUsuarios)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("FK__Contrato___Id_Co__47DBAE45");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ContratoUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Contrato___Id_Us__46E78A0C");
        });

        modelBuilder.Entity<Cronograma>(entity =>
        {
            entity.HasKey(e => e.IdCronograma).HasName("PK__Cronogra__CF2A4CAD716181F2");

            entity.ToTable("Cronograma");

            entity.Property(e => e.IdCronograma).HasColumnName("Id_Cronograma");
            entity.Property(e => e.Aniadido).HasColumnType("money");
            entity.Property(e => e.DeudaAnt).HasColumnType("money");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Estado_Pago");
            entity.Property(e => e.FechaPago)
                .HasColumnType("date")
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.FechaVenc).HasColumnType("date");
            entity.Property(e => e.IdContrato).HasColumnName("Id_Contrato");
            entity.Property(e => e.MesLetra)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.NroCuota)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Nro_Cuota");
            entity.Property(e => e.PenalidadMes).HasColumnType("money");
            entity.Property(e => e.TotalPago).HasColumnType("money");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Cronogramas)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("FK__Cronogram__Id_Co__4AB81AF0");
        });

        modelBuilder.Entity<DetalleContrato>(entity =>
        {
            entity.HasKey(e => e.IdDetalleContrato).HasName("PK__Detalle___F5A714A17B49A5C3");

            entity.ToTable("Detalle_Contrato");

            entity.Property(e => e.IdDetalleContrato).HasColumnName("Id_DetalleContrato");
            entity.Property(e => e.IdContrato).HasColumnName("Id_Contrato");
            entity.Property(e => e.IdProductoServicio).HasColumnName("Id_Producto_Servicio");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.DetalleContratos)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("FK__Detalle_C__Id_Co__5BE2A6F2");

            entity.HasOne(d => d.IdProductoServicioNavigation).WithMany(p => p.DetalleContratos)
                .HasForeignKey(d => d.IdProductoServicio)
                .HasConstraintName("FK__Detalle_C__Id_Pr__5AEE82B9");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__535FD6116942B34A");

            entity.ToTable("Direccion");

            entity.Property(e => e.IdDireccion).HasColumnName("Id_Direccion");
            entity.Property(e => e.Calle)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.Referencia).HasColumnType("text");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Direccion__Id_Pe__3C69FB99");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Error__3214EC0717B5DFD8");

            entity.ToTable("Error");

            entity.Property(e => e.ClassComponent)
                .HasMaxLength(100)
                .HasColumnName("Class_component");
            entity.Property(e => e.Controller).HasMaxLength(200);
            entity.Property(e => e.Error1).HasColumnName("Error");
            entity.Property(e => e.ErrorCode).HasColumnName("Error_code");
            entity.Property(e => e.FechaActualiza).HasColumnName("Fecha_actualiza");
            entity.Property(e => e.FechaCrea).HasColumnName("Fecha_crea");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .HasColumnName("Function_name");
            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.Ip).HasMaxLength(100);
            entity.Property(e => e.LineNumber).HasColumnName("Line_number");
            entity.Property(e => e.Method).HasMaxLength(20);
            entity.Property(e => e.UserAgent)
                .HasMaxLength(150)
                .HasColumnName("User_agent");
            entity.Property(e => e.UsuarioActualiza).HasColumnName("Usuario_Actualiza");
            entity.Property(e => e.UsuarioCrea).HasColumnName("Usuario_Crea");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Errors)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_Error_Persona");

            entity.HasOne(d => d.UsuarioActualizaNavigation).WithMany(p => p.ErrorUsuarioActualizaNavigations)
                .HasForeignKey(d => d.UsuarioActualiza)
                .HasConstraintName("FK_Error_Usuario_Actualiza");

            entity.HasOne(d => d.UsuarioCreaNavigation).WithMany(p => p.ErrorUsuarioCreaNavigations)
                .HasForeignKey(d => d.UsuarioCrea)
                .HasConstraintName("FK_Error_Usuario_Crea");
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__Imagen__B87925F682FCFE78");

            entity.ToTable("Imagen");

            entity.Property(e => e.IdImagen).HasColumnName("Id_Imagen");
            entity.Property(e => e.IdProductoServicio).HasColumnName("Id_ProductoServicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProductoServicioNavigation).WithMany(p => p.Imagens)
                .HasForeignKey(d => d.IdProductoServicio)
                .HasConstraintName("FK__Imagen__Id_Produ__5812160E");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__C95634AF5DE1AD2D");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Paterno");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("Id_TipoDocumento");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NroIdentificacion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Nro_Identificacion");
            entity.Property(e => e.NumeroCelular)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Numero_Celular");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Tipo_Persona");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("FK__Persona__Id_Tipo__398D8EEE");
        });

        modelBuilder.Entity<ProductoCliente>(entity =>
        {
            entity.HasKey(e => e.IdProducClien).HasName("PK__Producto__5F4B4090110D7F30");

            entity.ToTable("Producto_Cliente");

            entity.Property(e => e.IdProducClien).HasColumnName("Id_ProducClien");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdContrato).HasColumnName("Id_Contrato");
            entity.Property(e => e.Observacion).HasColumnType("text");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.ProductoClientes)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("FK__Producto___Id_Co__534D60F1");
        });

        modelBuilder.Entity<ProductoServicio>(entity =>
        {
            entity.HasKey(e => e.IdProdServ).HasName("PK__Producto__19A5E9A72A23CCE0");

            entity.ToTable("Producto_Servicio");

            entity.Property(e => e.IdProdServ).HasColumnName("Id_ProdServ");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StockActual).HasColumnName("Stock_Actual");
            entity.Property(e => e.StockMin).HasColumnName("Stock_Min");
        });

        modelBuilder.Entity<QuejasReclamo>(entity =>
        {
            entity.HasKey(e => e.IdQuejaReclamo).HasName("PK__Quejas_R__879B9A4B00AE527F");

            entity.ToTable("Quejas_Reclamos");

            entity.Property(e => e.IdQuejaReclamo).HasColumnName("Id_QuejaReclamo");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaQuejaReclamo)
                .HasColumnType("date")
                .HasColumnName("Fecha_QuejaReclamo");
            entity.Property(e => e.IdContrato).HasColumnName("Id_Contrato");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.QuejasReclamos)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("FK__Quejas_Re__Id_Co__5070F446");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__55932E86E477E293");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Funcion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Rols)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Rol__Id_Usuario__4222D4EF");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__Tipo_Doc__1878092DBCDC9E02");

            entity.ToTable("Tipo_Documento");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("Id_TipoDocumento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => e.IdUbigeo).HasName("PK__Ubigeo__99C3A0294A3339FC");

            entity.ToTable("Ubigeo");

            entity.Property(e => e.IdUbigeo).HasColumnName("Id_Ubigeo");
            entity.Property(e => e.Departamento)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Distrito)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__63C76BE29EE3CE6E");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Usuario__Id_Pers__3F466844");
        });

        modelBuilder.Entity<Vpersona>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VPERSONA");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Paterno");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NroIdentificacion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Nro_Identificacion");
            entity.Property(e => e.NumeroCelular)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Numero_Celular");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_Documento");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Tipo_Persona");
        });

        modelBuilder.Entity<Vusuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VUSUARIO");

            entity.Property(e => e.Contrasenia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NroIdentificacion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Nro_Identificacion");
            entity.Property(e => e.NumeroCelular)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Numero_Celular");
            entity.Property(e => e.RolFuncion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
