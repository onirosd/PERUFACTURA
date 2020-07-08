using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Datos.Models
{
    public partial class dev_ventorContext : DbContext
    {
        public dev_ventorContext()
        {
        }

        public dev_ventorContext(DbContextOptions<dev_ventorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Almacen> Almacen { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comprobante> Comprobante { get; set; }
        public virtual DbSet<Comprobantedetalle> Comprobantedetalle { get; set; }
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<DataRuc> DataRuc { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Menusuario> Menusuario { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proforma> Proforma { get; set; }
        public virtual DbSet<Proformadetalle> Proformadetalle { get; set; }
        public virtual DbSet<Serie> Serie { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Tabladato> Tabladato { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=dev-cloudperufactura.database.windows.net;Database=dev_ventor;User Id=admin_db; Password=D!giflow2019;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.ToTable("almacen");

                entity.HasIndex(e => e.ProductoId);

                entity.HasIndex(e => e.UsuarioId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ComprobanteId).HasColumnName("Comprobante_id");

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("Empresa_id")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_id");

                entity.Property(e => e.ProductoNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadMedidaId)
                    .HasColumnName("UnidadMedida_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId)
                    .IsRequired()
                    .HasColumnName("Usuario_id");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Almacen)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_almacen_producto");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Almacen)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_almacen_usuario");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.ToTable("comprobante");

                entity.HasIndex(e => e.ClienteId);

                entity.HasIndex(e => e.EmpresaId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClienteCorreo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClienteDireccion).HasColumnType("text");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_id");

                entity.Property(e => e.ClienteIdentidad)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComprobanteTipoId).HasColumnName("ComprobanteTipo_id");

                entity.Property(e => e.ComprobanteTipoRefId)
                    .HasColumnName("ComprobanteTipoRef_id")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Correlativo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CorrelativoRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DetraccionId)
                    .HasColumnName("Detraccion_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("Empresa_id")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaAnulacion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEmitido).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.FechaVencimiento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ganancia)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Glosa).HasColumnType("text");

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IvaTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MotiAnulacion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NroOc)
                    .HasColumnName("NroOC")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Serie)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SerieRef)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TipoCambio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TipoMonedaId)
                    .HasColumnName("TipoMoneda_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoNotaId)
                    .HasColumnName("TipoNota_id")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TipoOperacionId).HasColumnName("TipoOperacion_id");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalCompra)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UsuarioId)
                    .IsRequired()
                    .HasColumnName("Usuario_id")
                    .HasMaxLength(450);

                entity.Property(e => e.UsuarioImprimiendoId).HasColumnName("UsuarioImprimiendo_id");

                entity.Property(e => e.ValorDetraccion).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Comprobante)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_comprobante_cliente");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Comprobante)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_comprobante_empresa");
            });

            modelBuilder.Entity<Comprobantedetalle>(entity =>
            {
                entity.ToTable("comprobantedetalle");

                entity.HasIndex(e => e.ComprobanteId);

                entity.HasIndex(e => e.ProductoId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ComprobanteId).HasColumnName("Comprobante_Id");

                entity.Property(e => e.Devuelto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Ganancia).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioTotal).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PrecioTotalCompra).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PrecioUnitarioCompra).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_id");

                entity.Property(e => e.ProductoNombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadMedidaId)
                    .HasColumnName("UnidadMedida_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Comprobante)
                    .WithMany(p => p.Comprobantedetalle)
                    .HasForeignKey(d => d.ComprobanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_comprobantedetalle_comprobante");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasKey(e => e.EmpresaId)
                    .HasName("PK__configur__EAF7B53C7C92779D");

                entity.ToTable("configuracion");

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("Empresa_id")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Anio).HasDefaultValueSql("((2013))");

                entity.Property(e => e.BoletaFormato).HasColumnType("text");

                entity.Property(e => e.BoletaFoto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreditoFormato).HasColumnType("text");

                entity.Property(e => e.CreditoFoto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ctacorriente)
                    .HasColumnName("ctacorriente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ctadetraccion)
                    .HasColumnName("ctadetraccion")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DebitoFormato).HasColumnType("text");

                entity.Property(e => e.DebitoFoto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion).HasColumnType("text");

                entity.Property(e => e.FacturaFormato).HasColumnType("text");

                entity.Property(e => e.FacturaFoto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Impresion).HasDefaultValueSql("((1))");

                entity.Property(e => e.Iva).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Lineas).HasDefaultValueSql("((15))");

                entity.Property(e => e.LogoRuta)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MonedaId)
                    .HasColumnName("Moneda_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nboleta)
                    .HasColumnName("NBoleta")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ncredito)
                    .HasColumnName("NCredito")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ndebito)
                    .HasColumnName("NDebito")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nfactura)
                    .HasColumnName("NFactura")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PlantillaId).HasColumnName("Plantilla_id");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ruc)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Sboleta)
                    .HasColumnName("SBoleta")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Scredito)
                    .HasColumnName("SCredito")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Sdebito)
                    .HasColumnName("SDebito")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Sfactura)
                    .HasColumnName("SFactura")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Ubigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Zeros).HasDefaultValueSql("((5))");
            });

            modelBuilder.Entity<DataRuc>(entity =>
            {
                entity.HasKey(e => e.Ruc);

                entity.ToTable("data_ruc");

                entity.Property(e => e.Ruc)
                    .HasColumnName("ruc")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodigoZona)
                    .HasColumnName("codigo_zona")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CondicionDomicilio)
                    .HasColumnName("condicion_domicilio")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoContribuyente)
                    .HasColumnName("estado_contribuyente")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Interior)
                    .HasColumnName("interior")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Kilometro)
                    .HasColumnName("kilometro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lote)
                    .HasColumnName("lote")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Manzana)
                    .HasColumnName("manzana")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreVia)
                    .HasColumnName("nombre_via")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("razon_social")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoVia)
                    .HasColumnName("tipo_via")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoZona)
                    .HasColumnName("tipo_zona")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ubigeo)
                    .HasColumnName("ubigeo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresa");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Css)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Orden).HasDefaultValueSql("((1))");

                entity.Property(e => e.Separador).HasDefaultValueSql("((0))");

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menusuario>(entity =>
            {
                entity.ToTable("menusuario");

                entity.HasIndex(e => e.MenuId);

                entity.Property(e => e.MenuId).HasColumnName("Menu_id");

                entity.Property(e => e.UsuarioTipoId)
                    .IsRequired()
                    .HasColumnName("UsuarioTipo_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Menusuario)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_menusuario_menu");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("Empresa_id")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Stock).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StockMinimo).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UnidadMedidaId)
                    .HasColumnName("UnidadMedida_id")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proforma>(entity =>
            {
                entity.ToTable("proforma");

                entity.HasIndex(e => e.EmpresaId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClienteCorreo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClienteDireccion).HasColumnType("text");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_id");

                entity.Property(e => e.ClienteIdentidad)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComprobanteTipoId).HasColumnName("ComprobanteTipo_id");

                entity.Property(e => e.ComprobanteTipoRefId)
                    .HasColumnName("ComprobanteTipoRef_id")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Correlativo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CorrelativoRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("Empresa_id")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaAnulacion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEmitido)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ganancia)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Glosa).HasColumnType("text");

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IvaTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MotiAnulacion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Serie)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SerieRef)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TipoCambio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TipoMonedaId)
                    .HasColumnName("TipoMoneda_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoNotaId)
                    .HasColumnName("TipoNota_id")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalCompra)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UsuarioId)
                    .IsRequired()
                    .HasColumnName("Usuario_id")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioImprimiendoId).HasColumnName("UsuarioImprimiendo_id");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Proforma)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_proforma_empresa");
            });

            modelBuilder.Entity<Proformadetalle>(entity =>
            {
                entity.ToTable("proformadetalle");

                entity.HasIndex(e => e.ComprobanteId);

                entity.HasIndex(e => e.ProductoId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ComprobanteId).HasColumnName("Comprobante_Id");

                entity.Property(e => e.Devuelto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Ganancia).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioTotal).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PrecioTotalCompra).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PrecioUnitarioCompra).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_id");

                entity.Property(e => e.ProductoNombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadMedidaId)
                    .HasColumnName("UnidadMedida_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Comprobante)
                    .WithMany(p => p.Proformadetalle)
                    .HasForeignKey(d => d.ComprobanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_proformadetalle_proforma");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Proformadetalle)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_proformadetalle_producto");
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("serie");

                entity.HasIndex(e => e.EmpresaId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ComprobanteTipoId).HasColumnName("ComprobanteTipo_id");

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("Empresa_id")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Serie1)
                    .HasColumnName("Serie")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Serie)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_serie_empresa");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("servicio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpresaId)
                    .IsRequired()
                    .HasColumnName("Empresa_id")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.UnidadMedidaId)
                    .HasColumnName("UnidadMedida_id")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tabladato>(entity =>
            {
                entity.ToTable("tabladato");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Relacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Value2).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId)
                    .HasColumnName("Empresa_id")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo).HasDefaultValueSql("((2))");

                entity.Property(e => e.Usuario1)
                    .HasColumnName("Usuario")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
