var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Almacen = function () {
        var self = this;
        this.$cboBuscarTipo = $('#cboBuscarTipo');
        this.$btnBuscar = $('#btnBuscar');
        this.btnBuscar = '#btnBuscar';
        this.$grilla = $("#grilla");
        this.$divGrilla = $("#divGrilla");
        this.idProducto = 0;
        this.dtAlmacen = {};
        this.productos = [];

        //ModalAjustarStock
        this.$cboProductoAS = $('#cboProductoAS');
        this.cboProductoAS = '#cboProductoAS';
        this.$txtCantidadAS = $('#txtCantidadAS');
        this.$txtUDMAS = $('#txtUDMAS');
        this.$txtStockActualAS = $('#txtStockActualAS');
        this.$btnGuardarAjustarStock = $('#btnGuardarAjustarStock');
        this.btnGuardarAjustarStock = '#btnGuardarAjustarStock';
        this.modalAjustarStock = '#modalAjustarStock';
        this.$modalAjustarStock = $('#modalAjustarStock');

        //Entrada
        this.$cboProductoEntrada = $('#cboProductoEntrada');
        this.cboProductoEntrada = '#cboProductoEntrada';
        this.$txtCantidadEntrada = $('#txtCantidadEntrada');
        this.$txtPrecioCompraEntrada = $('#txtPrecioCompraEntrada');
        this.$txtUDMEntrada = $('#txtUDMEntrada');
        this.$txtStockActualEntrada = $('#txtStockActualEntrada');
        this.$btnGuardarEntrada = $('#btnGuardarEntrada');
        this.btnGuardarEntrada = '#btnGuardarEntrada';
        this.$modalEntrada = $('#modalEntrada');
        this.inicio();
    }
    Almacen.prototype = {
        funciones: {
            guardarAjustarStock: function (self) {
                var request = {};
                request.Id = self.$cboProductoAS.val();
                request.Stock = self.$txtCantidadAS.val();
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Producto/EditarStockProducto',
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
            guardarEntrada: function (self) {
                var request = {};
                request.ProductoId = self.$cboProductoEntrada.val();
                request.Cantidad = self.$txtCantidadEntrada.val();
                request.Precio = self.$txtPrecioCompraEntrada.val();
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
            obtenerProductos: function (self) {
                var request = {};
                request.Empresa_id = sessionStorage.getItem('empresa');
                self.$cboProductoAS.select2({
                    dropdownParent: self.$modalAjustarStock,
                    placeholder: 'Escriba el nombre del producto para registrar la entrada',
                    minimumInputLength: 3,
                    width: '100%',
                    language: "es",
                    theme: 'bootstrap4',
                    ajax: {
                        url: C.Vars.rutaSERV + '/api/Producto/ObtenerProductosByNombre',
                        type: 'post',
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",
                        headers: C.Base.auntenticar(),
                        statusCode: {
                            401: function () {
                                win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                            }
                        },
                        delay: 250,
                        data: function (params) {
                            if (!params.term) params.term = '';
                            var query = {
                                Nombre: params.term,
                                Empresa_id: sessionStorage.getItem('empresa')
                            }
                            return JSON.stringify(query);
                        },
                        processResults: function (data, page) { // parse the results into the format expected by Select2.
                            self.productos = data;
                            var parsed = [];
                            try {
                                parsed = _.map(data, function (item) {
                                    return {
                                        id: item.id,
                                        text: item.nombre
                                    };
                                });
                                console.log(parsed);
                            } catch (e) { alert('errror');}

                            return {
                                results: parsed
                            };
                        }
                        // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
                    }
                });

                self.$cboProductoEntrada.select2({
                    dropdownParent: self.$modalEntrada,
                    placeholder: 'Escriba el nombre del producto para registrar la entrada',
                    minimumInputLength: 3,
                    width: '100%',
                    language: "es",
                    theme: 'bootstrap4',
                    ajax: {
                        url: C.Vars.rutaSERV + '/api/Producto/ObtenerProductosByNombre',
                        type: 'post',
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",
                        headers: C.Base.auntenticar(),
                        statusCode: {
                            401: function () {
                                win.location.href = C_Vars.rutaAPP + "/seguridad/Login";
                            }
                        },
                        delay: 250,
                        data: function (params) {
                            if (!params.term) params.term = '';
                            var query = {
                                Nombre: params.term,
                                Empresa_id: sessionStorage.getItem('empresa')
                            }
                            return JSON.stringify(query);
                        },
                        processResults: function (data, page) { // parse the results into the format expected by Select2.
                            self.productos = data;
                            var parsed = [];
                            try {
                                parsed = _.map(data, function (item) {
                                    return {
                                        id: item.id,
                                        text: item.nombre
                                    };
                                });
                                console.log(parsed);
                            } catch (e) { alert('errror'); }

                            return {
                                results: parsed
                            };
                        }
                        // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
                    }
                });
            },
            obtenerTipos: function (self) {
                var request = {};
                request.Relacion = 'almacentipo';
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/TablaDato/ObtenerTipos',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C_Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                return r1;
                
            },
            buscarAlmacen: function (self) {
                C.Interfaz.bloquearDiv(self.$divGrilla);
                var r1 = self.funciones.obtenerAlmacen(self);
                $.when(r1).done(function (response) {
                    console.log(response);
                    C.Interfaz.llenarGrilla(self.$grilla, response);
                    C.Interfaz.desbloquearDiv(self.$divGrilla);
                });
            },
            obtenerAlmacen: function (self) {
                var request = {};
                request.EmpresaId = sessionStorage.getItem('empresa');;
                request.Tipo = self.$cboBuscarTipo.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Almacen/Buscar',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C_Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                return r1;
            },
            llenaDatosinicio: function (self) {
                var r1 = self.funciones.obtenerTipos(self);
                $.when(r1).done(function (response) {
                    self.$cboBuscarTipo.append('<option value="0">Todos</option>');
                    $.each(response, function (index, value) {
                        self.$cboBuscarTipo.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                    });
                    self.dtAlmacen = self.$grilla.DataTable({
                        language: C.Vars.lenguajeGrilla,
                        order: [[0, 'desc']],
                        columns: [
                            { title: "Id", data: 'id', visible: false },
                            { title: "Tipo", data: 'tipoNombre' },
                            { title: "Producto", data: 'productoNombre', width: '70%'},
                            {
                                title: "Fecha",
                                data: 'fecha',
                                type: 'date',
                                render: function (data, type, row) { return data ? moment(data).format('DD/MM/YYYY') : ''; }
                            },
                            { title: "cantidad", data: 'cantidad' },
                            { title: "UDM", data: 'unidadMedidaId' },
                            { title: "Comprobante", data: 'comprobanteId' }
                        ],
                        "columnDefs": [
                            {
                                'targets': 6,
                                'className': 'dt-center',
                                'render': function (data, type, row) {
                                    if (data != 0)
                                        return '<a href="' + C.Vars.rutaAPP + '/Comprobantes/ver?idComp=' + data + '" title="Ver"><i class="fa fa-search" aria-hidden="true"></i></a>';
                                    else
                                        return '';
                                }
                            }
                        ]
                    });

                    self.funciones.buscarAlmacen(self);
                });

                self.funciones.obtenerProductos(self);
                
            },
            validarAjustarStock: function (self) {
                var respuesta = true;
                var controles = [
                    {
                        control: self.$cboProductoAS,
                        reglas: [
                            { regla: 'required' },
                        ],
                    },
                    {
                        control: self.$txtCantidadAS,
                        reglas: [
                            { regla: 'required' },
                        ],
                    }
                ];

                respuesta = C.Base.validarFormulario(controles);
                return respuesta;
            },
            validarEntrada: function (self) {
                var respuesta = true;
                var controles = [
                    {
                        control: self.$cboProductoEntrada,
                        reglas: [
                            { regla: 'required' },
                        ],
                    },
                    {
                        control: self.$txtPrecioCompraEntrada,
                        reglas: [
                            { regla: 'required' },
                        ],
                    },
                    {
                        control: self.$txtCantidadEntrada,
                        reglas: [
                            { regla: 'required' },
                        ],
                    }
                ];

                respuesta = C.Base.validarFormulario(controles);
                return respuesta;
            },
            limpiarControlesAjustarStock: function (self) {
                self.$cboProductoAS.val(null).trigger('change');
                self.$txtStockActualAS.val('');
                self.$txtCantidadAS.val('');
                self.$txtUDMAS.val('');
                self.$txtCantidadAS.removeClass('tiene-error');
                self.$cboProductoAS.removeClass('tiene-error'); 
            },
            limpiarControlesEntrada: function (self) {
                self.$cboProductoEntrada.val(null).trigger('change');
                self.$txtCantidadEntrada.val('');
                self.$txtPrecioCompraEntrada.val('');
                self.$txtStockActualEntrada.val('');
                self.$txtUDMEntrada.val('');
                self.$txtCantidadEntrada.removeClass('tiene-error');
                self.$txtPrecioCompraEntrada.removeClass('tiene-error');
                self.$cboProductoEntrada.removeClass('tiene-error');
            }
        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnBuscar, function (e) {
                    e.preventDefault();
                    self.funciones.buscarAlmacen(self);
                });

                $el.on('change', self.cboProductoAS, function (e) {
                    if (self.$cboProductoAS.val() != null) {
                        var item = _.where(self.productos, { id: parseInt(self.$cboProductoAS.val()) });
                        self.$txtUDMAS.val(item[0].unidadMedidaId);
                        self.$txtStockActualAS.val(item[0].stock);
                    }
                });

                $el.on('change', self.cboProductoEntrada, function (e) {
                    if (self.$cboProductoEntrada.val() != null) {
                        var item = _.where(self.productos, { id: parseInt(self.$cboProductoEntrada.val()) });
                        self.$txtPrecioCompraEntrada.val(item[0].precioCompra)
                        self.$txtUDMEntrada.val(item[0].unidadMedidaId);
                        self.$txtStockActualEntrada.val(item[0].stock);
                    }
                });

                $el.on('click', self.btnGuardarAjustarStock, function (e) {
                    e.preventDefault();
                    var r1 = null;
                    if (self.funciones.validarAjustarStock(self))    // test for validity
                    {
                        r1 = self.funciones.guardarAjustarStock(self);
                        
                        $.when(r1).done(function (response) {
                            self.$modalAjustarStock.modal('hide');
                        });
                    }
                });

                $el.on('click', self.btnGuardarEntrada, function (e) {
                    e.preventDefault();
                    var r1 = null;
                    if (self.funciones.validarEntrada(self))    // test for validity
                    {
                        r1 = self.funciones.guardarEntrada(self);

                        $.when(r1).done(function (response) {
                            self.funciones.buscarAlmacen(self);
                            self.$modalEntrada.modal('hide');
                        });
                    }
                });

                $el.on('hidden.bs.modal', self.$modalAjustarStock, function (e) {
                    self.funciones.limpiarControlesAjustarStock(self);
                });

                $el.on('hidden.bs.modal', self.$modalEntrada, function (e) {
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
        window.addEventListener("load", new Almacen, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Almacen);
    } else {
        window.onload = new Almacen;
    }

})(APP, window, jQuery, _);