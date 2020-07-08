var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Proforma = function () {
        var self = this;
        self.codProforma = C.Base.obtenerParametrosUrl('idProf');
        self.$txtCliente = $('#txtCliente');
        self.$txtRuc = $('#txtRuc');
        self.$txtFecha = $('#txtFecha');
        self.$txtEmail = $('#txtEmail');
        self.$txtDireccion = $('#txtDireccion');
        self.$txtMoneda = $('#txtMoneda');
        self.divTipoCambio = $('.divTipoCambio');
        self.$txtTipoCambio = $('#txtTipoCambio');
        self.$txtEstado = $('#txtEstado');
        self.$grilla = $('#grilla');
        self.$divBtnCerrarProforma = $('#divBtnCerrarProforma');
        self.$divBtnImprimirProforma = $('#divBtnImprimirProforma');
        self.$btnCerrarProforma = $('#btnCerrarProforma');
        self.btnCerrarProforma = '#btnCerrarProforma';
        self.$btnImprimirProforma = $('#btnImprimirProforma');
        self.btnImprimirProforma = '#btnImprimirProforma';
        self.$ddlTipoComprobanteSelect = $('#ddlTipoComprobanteSelect');
        self.btnTipoComprobanteSelect = '#btnTipoComprobanteSelect';

        /*Impresion*/
        self.$ImpTotalLetras = $('#TotalLetras');
        self.$ImpFecha = $('#fecha');
        self.$ImpCliente = $('#cliente');
        self.$ImpRuc = $('#ruc');
        self.$ImpDireccion = $('#direccion');
        self.$ImpSerie = $('#serie');
        //self.$ImpSubTotal = $('#SubTotal'); //está comentado en Demo
        self.$ImpTotal = $('#total');
        self.$ImpCantidadProducto = $('#CantidadProducto');
        self.$ImpNombreProducto = $('#NombreProducto');
        self.$ImpPrecioUnitario = $('#PrecioUnitario');
        self.$ImpPrecioCantidad = $('#PrecioCantidad');

        self.btnEditarProforma = '#btnEditarProforma';

        self.proforma = {};
        this.inicio();
    }
    Proforma.prototype = {
        funciones: {
            cerrarProforma: function (proformaId) {
                var request = {};
                request.Id = proformaId;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Proforma/CerrarProforma',
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
            obtenerProforma: function (proformaId) {
                var request = {};
                request.IdProforma = proformaId;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Proforma/ObtenerProformaById',
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
            obtenerTablaDato: function (relacion) {
                var request = {};
                request.Relacion = relacion;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/TablaDato/ObtenerTipos',
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
            obtenerTablaDatoByValue: function (relacion, value) {
                var request = {};
                request.Relacion = relacion;
                request.Value = value;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/TablaDato/ObtenerTipoByValue',
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
            llenarFormulario: function (self) {
                var r1 = self.funciones.obtenerProforma(self.codProforma);
                $.when(r1).done(function (response) {
                    self.proforma = response;
                    console.log(response);
                    let r2 = self.funciones.obtenerTablaDato('proformaestado');
                    let estados = [];
                    $.when(r2).done(function (tdresponse) {
                        estados = tdresponse;
                        self.$txtCliente.val(response.clienteNombre);
                        self.$txtRuc.val(response.clienteIdentidad);
                        self.$txtFecha.val(response.fechaEmitido)
                        if (response.estado == 1) {
                            //self.txtEstado.val(response.estadoNombre);
                            self.$txtEstado.val('Creado');
                            self.$txtEstado.css('color', 'orange');
                            self.$divBtnCerrarProforma.show();
                            self.$divBtnImprimirProforma.hide();
                        }
                        else if (response.estado == 2) {
                            self.$txtEstado.val('Cerrado');
                            self.$txtEstado.css('color', 'blue');
                            self.$divBtnCerrarProforma.hide();
                            self.$divBtnImprimirProforma.show();
                        }
                        self.$txtMoneda.val(response.tipoMonedaId);
                        self.$txtEmail.val(response.clienteCorreo);
                        self.$txtDireccion.val(response.clienteDireccion);
                        C.Interfaz.llenarGrilla(self.$grilla, response.proformadetalle);
                    });
                });
            },
            llenarFormularioImpresion: function (self) {
                var r1 = self.funciones.obtenerTablaDatoByValue('moneda', self.proforma.tipoMonedaId);
                $.when(r1).done(function (moneda) {
                    var totalLetras = C.Base.valorEnLetras(self.proforma.total, moneda.nombre);
                    self.$ImpTotalLetras.html(totalLetras);
                    var fechaEmision = 'Fecha de Emisión: ' + moment(self.proforma.fechaEmitido).format("DD/MM/YYYY");
                    self.$ImpFecha.html(fechaEmision);
                    var nombreCliente = 'Nombre del Cliente: ' + self.proforma.clienteNombre;
                    self.$ImpCliente.html(nombreCliente);
                    var rucCliente = (self.proforma.comprobanteTipoId == 3 ? 'RUC' : 'DNI') + ' del Cliente: ' + self.proforma.clienteIdentidad
                    self.$ImpRuc.html(rucCliente);
                    var direccionCliente = 'Dirección: ' + self.proforma.clienteDireccion;
                    self.$ImpDireccion.html(direccionCliente);
                    var serie = sessionStorage.getItem('empresa') + '-' + sessionStorage.getItem('nombreEmpresa') + '<br/>' + self.proforma.serie + '-' + self.proforma.correlativo;
                    self.$ImpSerie.html(serie);
                    var total = 'Total sin IGV: ' + C.Base.formatoNumero(self.proforma.total, 4);
                    self.$ImpTotal.html(total);
                    var cantidadProducto = '';
                    var nombreProducto = '';
                    var precioUnitario = '';
                    var precioCantidad = '';
                    $.each(self.proforma.proformadetalle, function (index, value) {
                        cantidadProducto += '<div>' + value.cantidad + ' ' + value.unidadMedidaId + '</div>';
                        nombreProducto += '<div>' + value.productoNombre + '</div>';
                        precioUnitario += '<div>' + C.Base.formatoNumero(value.precioUnitario, 4) + '</div>';
                        precioCantidad += '<div>' + C.Base.formatoNumero(value.precioUnitario * value.cantidad, 4) + '</div>';
                    });
                    self.$ImpCantidadProducto.html(cantidadProducto);
                    self.$ImpNombreProducto.html(nombreProducto);
                    self.$ImpPrecioUnitario.html(precioUnitario);
                    self.$ImpPrecioCantidad.html(precioCantidad);
                });
            },
            llenaDatosinicio: function (self) {
                self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: "Item", data: 'productoNombre' },
                        { title: "Cantidad", data: 'cantidad' },
                        { title: "UND", data: 'unidadMedidaId' },
                        { title: "P.U", data: 'precioUnitario' },
                        { title: "P.T", data: 'precioTotal' },
                    ]
                });
                if (self.codProforma != '') {
                    self.funciones.llenarFormulario(self);
                }
                else {
                    alert('no se encontró la proforma');
                }

            }
        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnTipoComprobanteSelect, function (e) {
                    e.preventDefault();
                    C.Interfaz.enlace(C.Vars.rutaAPP + '/Comprobantes/Nuevo?idComp=0&idProf=' + self.codProforma + '&idTipoComp=' + self.$ddlTipoComprobanteSelect.val());
                    //var r1 = self.funciones.cerrarProforma(self.codProforma);
                    //$.when(r1).done(function (response) {
                    //    if (response) {
                    //        self.funciones.llenarFormulario(self);
                    //    }
                    //    else {
                    //        alert("Ocurrió un error");
                    //    }
                    //});
                });

                $el.on('click', self.btnImprimirProforma, function (e) {
                    e.preventDefault();
                    self.funciones.llenarFormularioImpresion(self);
                });

                $el.on('click', self.btnEditarProforma, function (e) {
                    e.preventDefault();
                    C.Interfaz.enlace(C.Vars.rutaAPP + '/Proformas/Nuevo?idProf=' + self.codProforma);
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
        window.addEventListener("load", new Proforma, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Proforma);
    } else {
        window.onload = new Proforma;
    }

})(APP, window, jQuery, _);