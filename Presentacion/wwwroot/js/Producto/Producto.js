var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Producto = function () {
        var self = this;
        this.$txtBuscarNombre = $('#txtBuscarNombre');
        this.$txtBuscarMarca = $('#txtBuscarMarca');
        this.$btnBuscar = $('#btnBuscar');
        this.btnBuscar = '#btnBuscar';
        this.btnGuardar = '#btnEditProducto';
        this.btnNuevo = '#btnNuevo';
        this.btnCargaMasiva = '#btnCargaMasiva';
        this.$grilla = $("#grilla");
        this.$divGrilla = $("#divGrilla");
        this.accion = 'agregar';
        this.modal = '#myModalEditProducto';
        this.$modal = $('#myModalEditProducto');
        this.modalAbastecer = '#myModalAbastecer';
        this.$modalAbastecer = $('#myModalAbastecer');
        this.$txtNombreProductoEdit = $('#txtNombreProductoEdit');
        this.$txtMarcaProductoEdit = $('#txtMarcaProductoEdit');
        this.$ddlUDMEdit = $('#ddlUDMEdit');
        this.$txtStockActualEdit = $('#txtStockActualEdit');
        this.$txtStockInicialEdit = $('#txtStockInicialEdit');
        this.$txtStockMinimoEdit = $('#txtStockMinimoEdit');
        this.$txtCostoProductoEdit = $('#txtCostoProductoEdit');
        this.$txtPrecioVentaEdit = $('#txtPrecioVentaEdit');
        this.$txtGananciaProducto = $('#txtGananciaProducto');
        this.$helperPrecioVenta = $('#helperPrecioVenta');
        this.$divStockActual = $('#divStockActual');
        this.$divStockInicial = $('#divStockInicial');
        this.$divStockMinimo = $('#divStockMinimo');
        this.$divGananciaProducto = $('#divGananciaProducto');

        /*Stock Abastecer*/
        this.$txtStockActualAbastecer = $('#txtStockActualAbastecer');
        this.$ddlUDMAbastecer = $('#ddlUDMAbastecer');
        this.$txtPrecioCompraAbastecer = $('#txtPrecioCompraAbastecer');
        this.$txtCantidadAbastecer = $('#txtCantidadAbastecer');
        this.$txtNombreProdAbastecer = $('#txtNombreProdAbastecer');
        this.btnGuardarAbastecer = '#btnGuardarAbastecer';

        this.$fileExcel = $('#fileExcel');
        this.fileExcel = '#fileExcel';

        this.idProducto = 0;
        this.dtProducto = {};
        this.inicio();
    }
    Producto.prototype = {
        funciones: {
            buscarProductos: function (self) {
                C.Interfaz.bloquearDiv(self.$divGrilla);
                var r1 = self.funciones.obtenerProductos(self);
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grilla, response);
                    C.Interfaz.desbloquearDiv(self.$divGrilla);
                });
            },
            obtenerProductos: function (self) {
                var request = {};
                request.Empresa_id = sessionStorage.getItem('empresa');;
                request.Nombre = self.$txtBuscarNombre.val();
                request.Marca = self.$txtBuscarMarca.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Producto/ObtenerProductos',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                return r1;
            },
            nuevoProducto: function (self) {
                debugger;
                var request = {};
                request.Nombre = self.$txtNombreProductoEdit.val();
                request.UnidadMedidaId = self.$ddlUDMEdit.val();
                request.PrecioCompra = self.$txtCostoProductoEdit.val();
                request.Precio = self.$txtPrecioVentaEdit.val();
                request.Stock = self.$txtStockInicialEdit.val();
                request.StockMinimo = 0;
                request.Marca = self.$txtMarcaProductoEdit.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Producto/NuevoProducto',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                return r1;
            },
            editarProducto: function (self) {
                var request = {};
                request.Id = self.idProducto;
                request.Nombre = self.$txtNombreProductoEdit.val();
                request.UnidadMedidaId = self.$ddlUDMEdit.val();
                request.PrecioCompra = self.$txtCostoProductoEdit.val();
                request.Precio = self.$txtPrecioVentaEdit.val();
                request.Stock = self.$txtStockInicialEdit.val();
                request.StockMinimo = self.$txtStockMinimoEdit.val();
                request.Marca = self.$txtMarcaProductoEdit.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Producto/EditarProducto',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                return r1;
            },
            eliminarProducto: function (self, obj) {
                var request = {};
                request.Id = obj.id;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Producto/EliminarProducto',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                return r1;
            },
            llenaDatosinicio: function (self) {
                self.dtProducto = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    columns: [
                        { title: "Id", data: 'id', visible: false },
                        { title: "Nombre", data: 'nombre', width: "40%" },
                        { title: "Marca", data: 'marca' },
                        { title: "Stock", data: 'stock' },
                        { title: "UDM", data: 'unidadMedidaId' },
                        { title: "P.C", data: 'precioCompra' },
                        { title: "P.V", data: 'precio' }
                    ],
                    "columnDefs": [
                        {
                            'targets': 3,
                            'className': 'dt-right',
                            'render': function (data, type, row) {
                                return '<span class="m-r-5">' + data + '</span>' + '<a href="#" title="Abastecer" class="abastecer"><i class="fa fa-fw fa-plus"></i></a>';
                            }
                        },
                        {
                            'targets': 7,
                            'data': null,
                            'className': 'dt-center',
                            'defaultContent': '<a href="#" title="Editar" class="editarProducto"><i class="fa fa-fw fa-edit"></i></a>' +
                                '<a href="#" title="Eliminar" class="eliminarProducto"><i class="fa fa-fw fa-remove"></i></a>'
                        }
                    ]
                });
            },
            limpiarControlesProducto: function (self) {
                self.$txtNombreProductoEdit.val('');
                self.$txtMarcaProductoEdit.val('');
                self.$ddlUDMEdit.prop('selectedIndex', 0);
                self.$txtStockActualEdit.val('');
                self.$txtStockInicialEdit.val('');
                self.$txtStockMinimoEdit.val('');
                self.$txtCostoProductoEdit.val('');
                self.$txtPrecioVentaEdit.val('');
                self.$txtGananciaProducto.val('');
                self.idProducto = 0;
            },
            obtenerById: function (self, obj) {
                console.log(obj);
                self.idProducto = obj.id;
                self.$txtNombreProductoEdit.val(obj.nombre);
                self.$txtMarcaProductoEdit.val(obj.marca);
                self.$ddlUDMEdit.val(obj.unidadMedidaId);
                self.$txtStockActualEdit.val(obj.stock);
                self.$txtStockInicialEdit.val(obj.stock);
                self.$txtStockMinimoEdit.val(obj.stockMinimo);
                self.$txtCostoProductoEdit.val(obj.precioCompra);
                self.$txtPrecioVentaEdit.val(obj.precio);
                var ganancia = (obj.precio - obj.precioCompra) * 100 / obj.precioCompra;
                self.$txtGananciaProducto.val(obj.precio - obj.precioCompra);
                var mensaje = 'Existe un margen de ganancia aproximadamente del ' + ganancia + ' %';
                self.$helperPrecioVenta.html(mensaje);
            }, 
            validarformulario: function (self) {
                var respuesta = true;
                var controles = [
                    {
                        control: self.$txtNombreProductoEdit,
                        reglas: [
                            { regla: 'required' },
                            //{ regla: 'minlength', minlength: 2 }
                        ],
                    },
                    {
                        control: self.$txtCostoProductoEdit,
                        reglas: [
                            { regla: 'required' },
                            //{ regla: 'minlength', minlength: 2 }
                        ],
                    }, {
                        control: self.$txtPrecioVentaEdit,
                        reglas: [
                            { regla: 'required' },
                            //{ regla: 'minlength', minlength: 2 }
                        ],
                    },
                ];

                respuesta = C.Base.validarFormulario(controles);
                return respuesta;
            },
            guardarEntrada: function (self) {
                var request = {};
                request.ProductoId = self.idProducto;
                request.Cantidad = self.$txtCantidadAbastecer.val();
                request.Precio = self.$txtPrecioCompraAbastecer.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.UsuarioId = sessionStorage.getItem('userId');
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Almacen/InsertarEntrada',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                return r1;
            },
            validarEntrada: function (self) {
                var respuesta = true;
                var controles = [
                    {
                        control: self.$txtPrecioCompraAbastecer,
                        reglas: [
                            { regla: 'required' },
                        ],
                    },
                    {
                        control: self.$txtCantidadAbastecer,
                        reglas: [
                            { regla: 'required' },
                        ],
                    }
                ];

                respuesta = C.Base.validarFormulario(controles);
                return respuesta;
            },
            limpiarControlesEntrada: function (self) {
                self.$txtCantidadAbastecer.val('');
                self.$txtPrecioCompraAbastecer.val('');
                self.$txtCantidadAbastecer.removeClass('tiene-error');
                self.$txtPrecioCompraAbastecer.removeClass('tiene-error');
            },
            obtenerDatosExcel: function (self, data) {
                var productos = [];
                for (var i = 1; i < data.length; i++) {
                    var obj = {
                        Nombre: data[i][0],
                        UnidadMedidaId: data[i][1],
                        PrecioCompra: data[i][2],
                        Precio: data[i][3],
                        Stock: data[i][4],
                        StockMinimo: data[i][5],
                        Marca: data[i][6],
                        EmpresaId: sessionStorage.getItem('empresa')
                    };
                    productos.push(obj);
                }
                var request = {
                    Productos: productos
                };
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Producto/GuardarMasivoProductos',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });

                $.when(r1).done(function (response) {
                    self.funciones.buscarProductos(self);
                    alert(response.mensaje);
                    self.$modal.modal('hide');
                });

            },

        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnBuscar, function (e) {
                    e.preventDefault();
                    self.funciones.buscarProductos(self);
                });

                $el.on('click', self.btnNuevo, function (e) {
                    e.preventDefault();
                    self.accion = 'agregar';
                    self.$divStockActual.hide();
                    self.$divStockInicial.show();
                    self.$divStockMinimo.hide();
                    self.$divGananciaProducto.hide();
                    self.$helperPrecioVenta.hide();
                    self.$ddlUDMEdit.removeAttr("disabled");
                    self.$txtStockActualEdit.removeAttr("disabled");
                });

                $el.on('click', self.btnGuardar, function (e) {
                    e.preventDefault();
                    var r1 = null;
                    if (self.funciones.validarformulario(self))    // test for validity
                    {
                        if (self.accion == 'agregar') {
                            r1 = self.funciones.nuevoProducto(self);
                        }
                        else {
                            r1 = self.funciones.editarProducto(self);
                        }

                        $.when(r1).done(function (response) {
                            if (response) {
                                self.funciones.buscarProductos(self);
                            }
                            else {
                                alert('Error');
                            }
                            self.$modal.modal('hide');
                        });
                    }
                });
                $el.on('hidden.bs.modal', self.$modal, function (e) {
                    self.funciones.limpiarControlesProducto(self);
                });
                $el.on('click', '.editarProducto', function () {
                    self.accion = 'editar';
                    var data = self.dtProducto.row($(this).parents('tr')).data();
                    self.funciones.obtenerById(self, data);
                    self.$divStockActual.show();
                    self.$divStockInicial.hide();
                    self.$divStockMinimo.show();
                    self.$divGananciaProducto.show();
                    self.$ddlUDMEdit.attr("disabled", "disabled");
                    self.$txtStockActualEdit.attr("disabled", "disabled");
                    self.$helperPrecioVenta.show();
                    self.$modal.modal('show');
                });

                $el.on('click', '.eliminarProducto', function () {
                    var data = self.dtProducto.row($(this).parents('tr')).data();
                    var r1 = self.funciones.eliminarProducto(self, data);
                    $.when(r1).done(function (response) {
                        if (response.error) {
                            alert(response.mensaje);
                        }
                        else {
                            self.funciones.buscarProductos(self);
                        }
                        self.$modal.modal('hide');
                    });
                });

                $el.on('click', '.abastecer', function () {
                    var data = self.dtProducto.row($(this).parents('tr')).data();
                    self.idProducto = data.id;
                    self.$txtNombreProdAbastecer.val('[' + data.marca + '] - ' + data.nombre);
                    self.$txtPrecioCompraAbastecer.val(data.precioCompra);
                    self.$ddlUDMAbastecer.val(data.unidadMedidaId);
                    self.$txtStockActualAbastecer.val(data.stock);
                    console.log(data);
                    self.$modalAbastecer.modal('show');
                });

                $el.on('click', self.btnGuardarAbastecer, function () {
                    var r1 = null;
                    if (self.funciones.validarEntrada(self))    // test for validity
                    {
                        r1 = self.funciones.guardarEntrada(self);

                        $.when(r1).done(function (response) {
                            self.funciones.buscarProductos(self);
                            self.$modalAbastecer.modal('hide');
                        });
                    }
                });

                $el.on('hidden.bs.modal', self.$modalAbastecer, function (e) {
                    self.funciones.limpiarControlesEntrada(self);
                });

                $el.on('click', self.btnCargaMasiva, function (e) {

                    e.preventDefault();
                    self.$fileExcel.trigger('click');
                    //document.getElementById("fileExcel").click();
                });

                $el.on('change', self.fileExcel, function (e) {
                    var respuesta = C.Base.checkfileExcel(this);
                    if (!respuesta)
                        $(this).val('');
                    else {

                        var reader = new FileReader();
                        reader.readAsDataURL($(this)[0].files[0]);
                        var fileContent = reader.result;
                        readXlsxFile($(this)[0].files[0]).then((data) => {
                            self.funciones.obtenerDatosExcel(self, data);
                        }, (error) => {
                            console.log(error);
                            alert('Error al leer el fichero');
                        });
                        $(this).val('');
                    }
                });
                
            }
        },
        inicio: function () {
            var self = this;
            $(win).on('load', function () {
                C.Base.validarToken();
                self.eventos.botones(self);
                self.funciones.llenaDatosinicio(self);
                self.funciones.buscarProductos(self);
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new Producto, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Producto);
    } else {
        window.onload = new Producto;
    }

})(APP, window, jQuery, _);