﻿// <auto-generated />
using System;
using Datos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190702080012_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Datos.Entidades.Models.Almacen", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<long?>("ComprobanteId")
                        .HasColumnName("Comprobante_id");

                    b.Property<string>("EmpresaId")
                        .HasColumnName("Empresa_id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("date");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("ProductoId")
                        .HasColumnName("Producto_id");

                    b.Property<string>("ProductoNombre")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<byte>("Tipo");

                    b.Property<string>("UnidadMedidaId")
                        .HasColumnName("UnidadMedida_id")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("UsuarioId")
                        .HasColumnName("Usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("almacen");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo");

                    b.Property<string>("Correo1");

                    b.Property<string>("Correo2");

                    b.Property<string>("Correo3");

                    b.Property<string>("Correo4");

                    b.Property<string>("Correo5");

                    b.Property<string>("Direccion");

                    b.Property<string>("Dni");

                    b.Property<string>("EmpresaId");

                    b.Property<string>("Nombre");

                    b.Property<string>("NroDocumento");

                    b.Property<string>("Ruc");

                    b.Property<string>("Telefono1");

                    b.Property<string>("Telefono2");

                    b.Property<int?>("TipoDocumentoId");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Comprobante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClienteCorreo")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ClienteDireccion")
                        .HasColumnType("text");

                    b.Property<int>("ClienteId")
                        .HasColumnName("Cliente_id");

                    b.Property<string>("ClienteIdentidad")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("ClienteNombre")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<byte>("ComprobanteTipoId")
                        .HasColumnName("ComprobanteTipo_id");

                    b.Property<string>("ComprobanteTipoRefId")
                        .HasColumnName("ComprobanteTipoRef_id")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("Correlativo")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("CorrelativoRef")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("DetraccionId")
                        .HasColumnName("Detraccion_id")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<byte>("Devolucion");

                    b.Property<string>("EmpresaId")
                        .HasColumnName("Empresa_id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<byte>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("FechaAnulacion")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<DateTime?>("FechaEmitido")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("date");

                    b.Property<decimal>("Ganancia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<string>("Glosa")
                        .HasColumnType("text");

                    b.Property<byte[]>("HoraEmision")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<byte>("Impresion");

                    b.Property<decimal>("Iva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<decimal>("IvaTotal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<string>("MotiAnulacion")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Serie")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("SerieRef")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<decimal>("SubTotal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<decimal?>("TipoCambio")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("TipoMonedaId")
                        .HasColumnName("TipoMoneda_id")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("TipoNotaId")
                        .HasColumnName("TipoNota_id")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<int?>("TipoOperacionId")
                        .HasColumnName("TipoOperacion_id");

                    b.Property<decimal>("Total")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<decimal>("TotalCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<string>("UsuarioId")
                        .HasColumnName("Usuario_id");

                    b.Property<int?>("UsuarioImprimiendoId")
                        .HasColumnName("UsuarioImprimiendo_id");

                    b.Property<decimal?>("ValorDetraccion")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("comprobante");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Comprobantedetalle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Cantidad")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<long>("ComprobanteId")
                        .HasColumnName("Comprobante_Id");

                    b.Property<decimal?>("Devuelto")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Ganancia")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("PrecioTotal")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<decimal?>("PrecioTotalCompra")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<decimal?>("PrecioUnitario")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<decimal?>("PrecioUnitarioCompra")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<int>("ProductoId")
                        .HasColumnName("Producto_id");

                    b.Property<string>("ProductoNombre")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<byte?>("Tipo");

                    b.Property<string>("UnidadMedidaId")
                        .HasColumnName("UnidadMedida_id")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("ComprobanteId");

                    b.HasIndex("ProductoId");

                    b.ToTable("comprobantedetalle");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Configuracion", b =>
                {
                    b.Property<string>("EmpresaId")
                        .HasColumnName("Empresa_id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<int?>("Anio")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((2013))");

                    b.Property<string>("BoletaFormato")
                        .HasColumnType("text");

                    b.Property<string>("BoletaFoto")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("CreditoFormato")
                        .HasColumnType("text");

                    b.Property<string>("CreditoFoto")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Ctacorriente")
                        .HasColumnName("ctacorriente")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Ctadetraccion")
                        .HasColumnName("ctadetraccion")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("DebitoFormato")
                        .HasColumnType("text");

                    b.Property<string>("DebitoFoto")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("FacturaFormato")
                        .HasColumnType("text");

                    b.Property<string>("FacturaFoto")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<byte>("Impresion")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<byte>("Lineas")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((15))");

                    b.Property<string>("LogoRuta")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("MonedaId")
                        .HasColumnName("Moneda_id")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Nboleta")
                        .HasColumnName("NBoleta")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Ncredito")
                        .HasColumnName("NCredito")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Ndebito")
                        .HasColumnName("NDebito")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Nfactura")
                        .HasColumnName("NFactura")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<byte?>("PlantillaId")
                        .HasColumnName("Plantilla_id");

                    b.Property<string>("RazonSocial")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Ruc")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("Sboleta")
                        .HasColumnName("SBoleta")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("Scredito")
                        .HasColumnName("SCredito")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("Sdebito")
                        .HasColumnName("SDebito")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("Sfactura")
                        .HasColumnName("SFactura")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("Ubigeo")
                        .HasMaxLength(6)
                        .IsUnicode(false);

                    b.Property<byte?>("Zeros")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((5))");

                    b.HasKey("EmpresaId")
                        .HasName("PK__configur__EAF7B53C7C92779D");

                    b.ToTable("configuracion");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Empresa", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<byte>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("empresa");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Class")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Css")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<byte?>("Orden")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("Padre");

                    b.Property<byte?>("Separador")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("menu");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Menusuario", b =>
                {
                    b.Property<int>("UsuarioTipoId")
                        .HasColumnName("UsuarioTipo_id");

                    b.Property<int>("MenuId")
                        .HasColumnName("Menu_id");

                    b.HasKey("UsuarioTipoId", "MenuId")
                        .HasName("PK__menusuar__6DFB602FB52CFCAF");

                    b.HasIndex("MenuId");

                    b.ToTable("menusuario");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmpresaId")
                        .HasColumnName("Empresa_id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("Marca")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<decimal?>("PrecioCompra")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<decimal?>("Stock")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("StockMinimo")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UnidadMedidaId")
                        .HasColumnName("UnidadMedida_id")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("producto");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Proforma", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClienteCorreo")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ClienteDireccion")
                        .HasColumnType("text");

                    b.Property<int>("ClienteId")
                        .HasColumnName("Cliente_id");

                    b.Property<string>("ClienteIdentidad")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("ClienteNombre")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<byte>("ComprobanteTipoId")
                        .HasColumnName("ComprobanteTipo_id");

                    b.Property<string>("ComprobanteTipoRefId")
                        .HasColumnName("ComprobanteTipoRef_id")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("Correlativo")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("CorrelativoRef")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<byte>("Devolucion");

                    b.Property<string>("EmpresaId")
                        .HasColumnName("Empresa_id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<byte>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("FechaAnulacion")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("FechaEmitido")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("FechaRegistro")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<decimal>("Ganancia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<string>("Glosa")
                        .HasColumnType("text");

                    b.Property<byte>("Impresion");

                    b.Property<decimal>("Iva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<decimal>("IvaTotal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<string>("MotiAnulacion")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Serie")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("SerieRef")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<decimal>("SubTotal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<decimal?>("TipoCambio")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("TipoMonedaId")
                        .HasColumnName("TipoMoneda_id")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("TipoNotaId")
                        .HasColumnName("TipoNota_id")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<decimal>("Total")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<decimal>("TotalCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<string>("UsuarioId")
                        .HasColumnName("Usuario_id");

                    b.Property<int?>("UsuarioImprimiendoId")
                        .HasColumnName("UsuarioImprimiendo_id");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("proforma");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Proformadetalle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Cantidad")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<long>("ComprobanteId")
                        .HasColumnName("Comprobante_Id");

                    b.Property<decimal?>("Devuelto")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Ganancia")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("PrecioTotal")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<decimal?>("PrecioTotalCompra")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<decimal?>("PrecioUnitario")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<decimal?>("PrecioUnitarioCompra")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<int>("ProductoId")
                        .HasColumnName("Producto_id");

                    b.Property<string>("ProductoNombre")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<byte?>("Tipo");

                    b.Property<string>("UnidadMedidaId")
                        .HasColumnName("UnidadMedida_id")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("ComprobanteId");

                    b.HasIndex("ProductoId");

                    b.ToTable("proformadetalle");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("ComprobanteTipoId")
                        .HasColumnName("ComprobanteTipo_id");

                    b.Property<long>("Correlativo");

                    b.Property<string>("EmpresaId")
                        .HasColumnName("Empresa_id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<int>("Estado");

                    b.Property<bool?>("Proforma");

                    b.Property<string>("Serie1")
                        .HasColumnName("Serie")
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("serie");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmpresaId")
                        .IsRequired()
                        .HasColumnName("Empresa_id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<decimal?>("PrecioCompra")
                        .HasColumnType("decimal(10, 4)");

                    b.Property<string>("UnidadMedidaId")
                        .HasColumnName("UnidadMedida_id")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("servicio");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Tabladato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<byte>("Orden");

                    b.Property<string>("Relacion")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Value")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("tabladato");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrasena")
                        .HasMaxLength(32)
                        .IsUnicode(false);

                    b.Property<string>("EmpresaId")
                        .HasColumnName("Empresa_id")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("Tipo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((2))");

                    b.Property<string>("Usuario1")
                        .HasColumnName("Usuario")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Almacen", b =>
                {
                    b.HasOne("Datos.Entidades.Models.Producto", "Producto")
                        .WithMany("Almacen")
                        .HasForeignKey("ProductoId")
                        .HasConstraintName("FK_almacen_producto");

                    b.HasOne("Datos.Entidades.Models.Usuario", "Usuario")
                        .WithMany("Almacen")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_almacen_usuario");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Comprobante", b =>
                {
                    b.HasOne("Datos.Entidades.Models.Cliente", "Cliente")
                        .WithMany("Comprobante")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK_comprobante_cliente");

                    b.HasOne("Datos.Entidades.Models.Empresa", "Empresa")
                        .WithMany("Comprobante")
                        .HasForeignKey("EmpresaId")
                        .HasConstraintName("FK_comprobante_empresa");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Comprobantedetalle", b =>
                {
                    b.HasOne("Datos.Entidades.Models.Comprobante", "Comprobante")
                        .WithMany("Comprobantedetalle")
                        .HasForeignKey("ComprobanteId")
                        .HasConstraintName("FK_comprobantedetalle_comprobante");

                    b.HasOne("Datos.Entidades.Models.Producto", "Producto")
                        .WithMany("Comprobantedetalle")
                        .HasForeignKey("ProductoId")
                        .HasConstraintName("FK_comprobantedetalle_producto");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Menusuario", b =>
                {
                    b.HasOne("Datos.Entidades.Models.Menu", "Menu")
                        .WithMany("Menusuario")
                        .HasForeignKey("MenuId")
                        .HasConstraintName("FK_menusuario_menu");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Proforma", b =>
                {
                    b.HasOne("Datos.Entidades.Models.Empresa", "Empresa")
                        .WithMany("Proforma")
                        .HasForeignKey("EmpresaId")
                        .HasConstraintName("FK_proforma_empresa");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Proformadetalle", b =>
                {
                    b.HasOne("Datos.Entidades.Models.Comprobante", "Comprobante")
                        .WithMany("Proformadetalle")
                        .HasForeignKey("ComprobanteId")
                        .HasConstraintName("FK_proformadetalle_comprobante");

                    b.HasOne("Datos.Entidades.Models.Producto", "Producto")
                        .WithMany("Proformadetalle")
                        .HasForeignKey("ProductoId")
                        .HasConstraintName("FK_proformadetalle_producto");
                });

            modelBuilder.Entity("Datos.Entidades.Models.Serie", b =>
                {
                    b.HasOne("Datos.Entidades.Models.Empresa", "Empresa")
                        .WithMany("Serie")
                        .HasForeignKey("EmpresaId")
                        .HasConstraintName("FK_serie_empresa");
                });
#pragma warning restore 612, 618
        }
    }
}
