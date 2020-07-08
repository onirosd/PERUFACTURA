using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ruc = table.Column<string>(nullable: true),
                    Dni = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Telefono1 = table.Column<string>(nullable: true),
                    Telefono2 = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<string>(nullable: true),
                    TipoDocumentoId = table.Column<int>(nullable: true),
                    NroDocumento = table.Column<string>(nullable: true),
                    Correo1 = table.Column<string>(nullable: true),
                    Correo2 = table.Column<string>(nullable: true),
                    Correo3 = table.Column<string>(nullable: true),
                    Correo4 = table.Column<string>(nullable: true),
                    Correo5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "configuracion",
                columns: table => new
                {
                    Empresa_id = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    RazonSocial = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Ruc = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Ubigeo = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    Iva = table.Column<decimal>(type: "decimal(4, 2)", nullable: false),
                    Moneda_id = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    SBoleta = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    NBoleta = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SFactura = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    NFactura = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SCredito = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    NCredito = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SDebito = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    NDebito = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    BoletaFormato = table.Column<string>(type: "text", nullable: true),
                    FacturaFormato = table.Column<string>(type: "text", nullable: true),
                    CreditoFormato = table.Column<string>(type: "text", nullable: true),
                    DebitoFormato = table.Column<string>(type: "text", nullable: true),
                    BoletaFoto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FacturaFoto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreditoFoto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DebitoFoto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Lineas = table.Column<byte>(nullable: false, defaultValueSql: "((15))"),
                    Impresion = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    Zeros = table.Column<byte>(nullable: true, defaultValueSql: "((5))"),
                    Anio = table.Column<int>(nullable: true, defaultValueSql: "((2013))"),
                    LogoRuta = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Plantilla_id = table.Column<byte>(nullable: true),
                    ctadetraccion = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ctacorriente = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__configur__EAF7B53C7C92779D", x => x.Empresa_id);
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    id = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Estado = table.Column<byte>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Class = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Css = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Padre = table.Column<int>(nullable: false),
                    Orden = table.Column<byte>(nullable: true, defaultValueSql: "((1))"),
                    Separador = table.Column<byte>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UnidadMedida_id = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    Stock = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    StockMinimo = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    Marca = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Empresa_id = table.Column<string>(unicode: false, maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "servicio",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    UnidadMedida_id = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    Empresa_id = table.Column<string>(unicode: false, maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tabladato",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Relacion = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Value = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Orden = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabladato", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(nullable: false, defaultValueSql: "((2))"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Usuario = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Contrasena = table.Column<string>(unicode: false, maxLength: 32, nullable: true),
                    Empresa_id = table.Column<string>(unicode: false, maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "comprobante",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Empresa_id = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    Serie = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    Correlativo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Cliente_id = table.Column<int>(nullable: false),
                    ClienteIdentidad = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    ClienteNombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ClienteDireccion = table.Column<string>(type: "text", nullable: true),
                    ClienteCorreo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ComprobanteTipo_id = table.Column<byte>(nullable: false),
                    Estado = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    FechaRegistro = table.Column<DateTime>(type: "date", nullable: true),
                    FechaEmitido = table.Column<DateTime>(type: "date", nullable: true),
                    Iva = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    IvaTotal = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    SubTotal = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    Total = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    TotalCompra = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    Ganancia = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    Usuario_id = table.Column<int>(nullable: false),
                    Glosa = table.Column<string>(type: "text", nullable: true),
                    Impresion = table.Column<byte>(nullable: false),
                    UsuarioImprimiendo_id = table.Column<int>(nullable: true),
                    Devolucion = table.Column<byte>(nullable: false),
                    ComprobanteTipoRef_id = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    SerieRef = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    CorrelativoRef = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    TipoNota_id = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    TipoCambio = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    TipoMoneda_id = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MotiAnulacion = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    FechaAnulacion = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    TipoOperacion_id = table.Column<int>(nullable: true),
                    Detraccion_id = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    HoraEmision = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ValorDetraccion = table.Column<decimal>(type: "decimal(10, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comprobante", x => x.id);
                    table.ForeignKey(
                        name: "FK_comprobante_cliente",
                        column: x => x.Cliente_id,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comprobante_empresa",
                        column: x => x.Empresa_id,
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proforma",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Empresa_id = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    Serie = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    Correlativo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Cliente_id = table.Column<int>(nullable: false),
                    ClienteIdentidad = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    ClienteNombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ClienteDireccion = table.Column<string>(type: "text", nullable: true),
                    ClienteCorreo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ComprobanteTipo_id = table.Column<byte>(nullable: false),
                    Estado = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    FechaRegistro = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    FechaEmitido = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Iva = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    IvaTotal = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    SubTotal = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    Total = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    TotalCompra = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    Ganancia = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    Usuario_id = table.Column<int>(nullable: false),
                    Glosa = table.Column<string>(type: "text", nullable: true),
                    Impresion = table.Column<byte>(nullable: false),
                    UsuarioImprimiendo_id = table.Column<int>(nullable: true),
                    Devolucion = table.Column<byte>(nullable: false),
                    ComprobanteTipoRef_id = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    SerieRef = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    CorrelativoRef = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    TipoNota_id = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    TipoCambio = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    TipoMoneda_id = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MotiAnulacion = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    FechaAnulacion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proforma", x => x.id);
                    table.ForeignKey(
                        name: "FK_proforma_empresa",
                        column: x => x.Empresa_id,
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "serie",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Empresa_id = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    Serie = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    ComprobanteTipo_id = table.Column<byte>(nullable: false),
                    Correlativo = table.Column<long>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Proforma = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serie", x => x.id);
                    table.ForeignKey(
                        name: "FK_serie_empresa",
                        column: x => x.Empresa_id,
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menusuario",
                columns: table => new
                {
                    UsuarioTipo_id = table.Column<int>(nullable: false),
                    Menu_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__menusuar__6DFB602FB52CFCAF", x => new { x.UsuarioTipo_id, x.Menu_id });
                    table.ForeignKey(
                        name: "FK_menusuario_menu",
                        column: x => x.Menu_id,
                        principalTable: "menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "almacen",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<byte>(nullable: false),
                    Usuario_id = table.Column<int>(nullable: false),
                    Producto_id = table.Column<int>(nullable: false),
                    ProductoNombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UnidadMedida_id = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    Empresa_id = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    Comprobante_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_almacen", x => x.id);
                    table.ForeignKey(
                        name: "FK_almacen_producto",
                        column: x => x.Producto_id,
                        principalTable: "producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_almacen_usuario",
                        column: x => x.Usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comprobantedetalle",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<byte>(nullable: true),
                    Comprobante_Id = table.Column<long>(nullable: false),
                    Producto_id = table.Column<int>(nullable: false),
                    ProductoNombre = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    PrecioUnitarioCompra = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    PrecioTotalCompra = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    UnidadMedida_id = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    Devuelto = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    Ganancia = table.Column<decimal>(type: "decimal(10, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comprobantedetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_comprobantedetalle_comprobante",
                        column: x => x.Comprobante_Id,
                        principalTable: "comprobante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comprobantedetalle_producto",
                        column: x => x.Producto_id,
                        principalTable: "producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proformadetalle",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<byte>(nullable: true),
                    Comprobante_Id = table.Column<long>(nullable: false),
                    Producto_id = table.Column<int>(nullable: false),
                    ProductoNombre = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    PrecioUnitarioCompra = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    PrecioTotalCompra = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    UnidadMedida_id = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    Devuelto = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    Ganancia = table.Column<decimal>(type: "decimal(10, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proformadetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_proformadetalle_comprobante",
                        column: x => x.Comprobante_Id,
                        principalTable: "comprobante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proformadetalle_producto",
                        column: x => x.Producto_id,
                        principalTable: "producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_almacen_Producto_id",
                table: "almacen",
                column: "Producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_almacen_Usuario_id",
                table: "almacen",
                column: "Usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_Cliente_id",
                table: "comprobante",
                column: "Cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_Empresa_id",
                table: "comprobante",
                column: "Empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_comprobantedetalle_Comprobante_Id",
                table: "comprobantedetalle",
                column: "Comprobante_Id");

            migrationBuilder.CreateIndex(
                name: "IX_comprobantedetalle_Producto_id",
                table: "comprobantedetalle",
                column: "Producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_menusuario_Menu_id",
                table: "menusuario",
                column: "Menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_proforma_Empresa_id",
                table: "proforma",
                column: "Empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_proformadetalle_Comprobante_Id",
                table: "proformadetalle",
                column: "Comprobante_Id");

            migrationBuilder.CreateIndex(
                name: "IX_proformadetalle_Producto_id",
                table: "proformadetalle",
                column: "Producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_serie_Empresa_id",
                table: "serie",
                column: "Empresa_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "almacen");

            migrationBuilder.DropTable(
                name: "comprobantedetalle");

            migrationBuilder.DropTable(
                name: "configuracion");

            migrationBuilder.DropTable(
                name: "menusuario");

            migrationBuilder.DropTable(
                name: "proforma");

            migrationBuilder.DropTable(
                name: "proformadetalle");

            migrationBuilder.DropTable(
                name: "serie");

            migrationBuilder.DropTable(
                name: "servicio");

            migrationBuilder.DropTable(
                name: "tabladato");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "comprobante");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "empresa");
        }
    }
}
