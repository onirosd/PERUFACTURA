using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Datos.Entidades.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Datos.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Comprobante> Comprobante { get; set; }
        public DbSet<Comprobantedetalle> Comprobantedetalle { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Menusuario> Menusuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proforma> Proforma { get; set; }
        public DbSet<Proformadetalle> Proformadetalle { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Tabladato> Tabladato { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<DataRuc> DataRuc { get; set; }
        //public DbSet<AspNetUsers> AspNetUsersC { get; set; }
        //public DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public DbSet<AspNetRoles1> AspNetRolesC { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);//("Server=.;user id = sa; password=12345+;Database=Ventor;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<AspNetRoles1>(entity =>
            //{
            //    entity.ToTable("AspNetRoles");
            //
            //    entity.Property(e => e.Id).HasColumnName("Id");
            //    entity.Property(e => e.Name).HasColumnName("Name");
            //    entity.Property(e => e.NormalizedName).HasColumnName("NormalizedName");
            //    entity.Property(e => e.ConcurrencyStamp).HasColumnName("ConcurrencyStamp");
            //    entity.HasKey("Id");
            //});

            //modelBuilder.Entity<AspNetUsers>(entity =>
            //{
            //    entity.ToTable("AspNetUsers");
            //    entity.Property(e => e.Id).HasColumnName("Id");
            //    entity.HasKey("Id");
            //    entity.Property(e => e.UserName);
            //    entity.Property(e => e.TwoFactorEnabled);
            //    entity.Property(e => e.AccessFailedCount);
            //    entity.Property(e => e.ConcurrencyStamp);
            //    entity.Property(e => e.Email);
            //    entity.Property(e => e.EmailConfirmed);
            //    entity.Property(e => e.EmailSecurityStamp);
            //    entity.Property(e => e.LockOutEnabled);
            //    entity.Property(e => e.LockOutEnd);
            //    entity.Property(e => e.NormalizedEmail);
            //    entity.Property(e => e.NormalizedUserName);
            //    entity.Property(e => e.PasswordHash);
            //    entity.Property(e => e.PhoneNumber);
            //    entity.Property(e => e.PhoneNumberConfirmed);
            //    
            //});
            ////
            //modelBuilder.Entity<AspNetUserRoles>(entity =>
            //{
            //    entity.ToTable("AspNetUserRoles");
            //
            //    entity.Property(e => e.RoleId).HasColumnName("RoleId");
            //    entity.Property(e => e.UserId).HasColumnName("UserId");
            //    string[] keys = { "RoleId", "UserId" };
            //    entity.HasKey(keys);
            //});

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.ToTable("almacen");

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

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

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

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.ToTable("comprobante");

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

                entity.Property(e => e.Ganancia)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Glosa).HasColumnType("text");

                entity.Property(e => e.HoraEmision).HasColumnType("time(7)");

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

                entity.Property(e => e.TipoOperacionId).HasColumnName("TipoOperacion_id");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalCompra)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

                entity.Property(e => e.UsuarioImprimiendoId).HasColumnName("UsuarioImprimiendo_id");

                entity.Property(e => e.ValorDetraccion).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnName("FechaVencimiento").HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NroOC)
                    .HasColumnName("NroOC").HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MedioPago)
                    .HasColumnName("MedioPago")
                    .HasMaxLength(2)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Comprobantedetalle)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_comprobantedetalle_producto");
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
                entity.HasKey(e => new { e.UsuarioTipoId, e.MenuId })
                    .HasName("PK__menusuar__6DFB602FB52CFCAF");

                entity.ToTable("menusuario");

                entity.Property(e => e.UsuarioTipoId).HasColumnName("UsuarioTipo_id");

                entity.Property(e => e.MenuId).HasColumnName("Menu_id");

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

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

                entity.Property(e => e.UsuarioImprimiendoId).HasColumnName("UsuarioImprimiendo_id");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Proforma)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_proforma_empresa");
                entity.Property(e => e.ComprobanteId).HasColumnName("ComprobanteId");
            });

            modelBuilder.Entity<Proformadetalle>(entity =>
            {
                entity.ToTable("proformadetalle");

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
                    .HasConstraintName("FK_proformadetalle_comprobante");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Proformadetalle)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_proformadetalle_producto");
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("serie");

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
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

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

            modelBuilder.Entity<DataRuc>(entity =>
            {
                entity.ToTable("data_ruc");

                entity.Property(e => e.Ruc).HasColumnName("ruc");

                entity.HasKey(e => e.Ruc)
                   .HasName("PK__ruc__EAF7B53C7C92779A");

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("razon_social")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("razon_social")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoContribuyente)
                    .HasColumnName("estado_contribuyente")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CondicionDomicilio)
                    .HasColumnName("condicion_domicilio")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ubigeo)
                    .HasColumnName("ubigeo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoVia)
                    .HasColumnName("tipo_via")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreVia)
                    .HasColumnName("nombre_via")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoZona)
                    .HasColumnName("codigo_zona")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoZona)
                    .HasColumnName("tipo_zona")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
