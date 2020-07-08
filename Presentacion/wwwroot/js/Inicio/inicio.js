var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var InicioReporte = function () {
        var self = this;
        this.$divVendido = $('#divVendido');
        this.$divGanado = $('#divGanado');
        this.$divComprobantes = $('#divComprobantes');
        this.$divClientes = $('#divClientes');
        this.$divProductos = $('#divProductos');
        this.$divServicios = $('#divServicios');
        this.dtProducto = [];
        this.$grilla = $('#grilla');
        this.$divGrilla = $('#divGrilla');
        this.$indicadores = $('.indicadores');

        /*Stock Abastecer*/
        this.modalAbastecer = '#myModalAbastecer';
        this.$modalAbastecer = $('#myModalAbastecer');
        this.$txtStockActualAbastecer = $('#txtStockActualAbastecer');
        this.$ddlUDMAbastecer = $('#ddlUDMAbastecer');
        this.$txtPrecioCompraAbastecer = $('#txtPrecioCompraAbastecer');
        this.$txtCantidadAbastecer = $('#txtCantidadAbastecer');
        this.$txtNombreProdAbastecer = $('#txtNombreProdAbastecer');
        this.btnGuardarAbastecer = '#btnGuardarAbastecer'; 

        this.inicio();
    }
    InicioReporte.prototype = {
        funciones: {
            obtenerReporteResumenBasico: function () {
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/ReporteResumenBasico/' + sessionStorage.getItem('empresa'),
                    type: 'get',
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                return r1;
            },
            obtenerProductosPorAgotarse: function () {
                var request = {};
                request.Empresa_id = sessionStorage.getItem('empresa');
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/producto/ObtenerProductosPorAgotarse/' + sessionStorage.getItem('empresa'),
                    type: 'get',
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                return r1;
            },
            limpiarControlesEntrada: function (self) {
                self.$txtCantidadAbastecer.val('');
                self.$txtPrecioCompraAbastecer.val('');
                self.$txtCantidadAbastecer.removeClass('tiene-error');
                self.$txtPrecioCompraAbastecer.removeClass('tiene-error');
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
            llenaDatosinicio: function (self) {

                self.dtProducto = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    ordering: false,
                    info: false,
                    paging: false,
                    searching: false,
                    columns: [
                        { title: 'Id', data: 'id', visible: false },
                        { title: 'Nombre Producto', data: 'nombre', width: "80%" },
                        { title: 'Stock', data: 'stock', class: 'font-bold' },
                        { title: 'udm', data: 'unidadMedidaId', class: 'font-bold' },
                        { title: 'accion', data: 'null' }
                    ],
                    "columnDefs": [{
                        'targets': 4,
                        'data': null,
                        'className': 'dt-center',
                        'defaultContent': '<a href="#" title="Abastecer" class="abastecer"><span class="label label-table label-success"><i class="fa fa-fw fa-plus"></i>Abastecer</span></a>'
                    }]
                });
                //self.funciones.bloquearDvi(self.$div);
                C.Interfaz.bloquearDiv(self.$indicadores);
                var r1 = self.funciones.obtenerReporteResumenBasico();
                $.when(r1).done(function (response) {
                    self.$divVendido.html(response.vendido);
                    self.$divGanado.html(response.ganado);
                    self.$divComprobantes.html(response.comprobantes);
                    self.$divClientes.html(response.clientes);
                    self.$divProductos.html(response.productos);
                    self.$divServicios.html(response.servicios);
                    C.Interfaz.desbloquearDiv(self.$indicadores);
                });

                C.Interfaz.bloquearDiv(self.$divGrilla);
                var r2 = self.funciones.obtenerProductosPorAgotarse();
                $.when(r2).done(function (response) {
                    console.log(response);
                    C.Interfaz.llenarGrilla(self.$grilla, response);
                    C.Interfaz.desbloquearDiv(self.$divGrilla);
                });
            },
        },
        eventos: {
            botones: function (self) {
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
                            self.$modalAbastecer.modal('hide');
                            C.Interfaz.bloquearDiv(self.$divGrilla);
                            var r2 = self.funciones.obtenerProductosPorAgotarse();
                            $.when(r2).done(function (response) {
                                console.log(response);
                                C.Interfaz.llenarGrilla(self.$grilla, response);
                                C.Interfaz.desbloquearDiv(self.$divGrilla);
                            });
                        });
                    }
                });

                $el.on('hidden.bs.modal', self.$modalAbastecer, function (e) {
                    self.funciones.limpiarControlesEntrada(self);
                });
            }
        },
        inicio: function () {
            var self = this;
            $(win).on('load', function () {
                C.Base.validarToken();
                self.eventos.botones(self);

                self.funciones.llenaDatosinicio(self);
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new InicioReporte, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new InicioReporte);
    } else {
        window.onload = new InicioReporte;
    }

})(APP, window, jQuery, _);