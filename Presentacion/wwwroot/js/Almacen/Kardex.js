var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Kardex = function () {
        var self = this;
        this.$grilla = $("#grilla");
        this.$divGrilla = $("#divGrilla");
        this.$cboTipoFecha = $('#cboTipoFecha');
        this.cboTipoFecha = '#cboTipoFecha';
        this.$txtBuscarFecha = $('#txtBuscarFecha');
        this.$txtBuscarRangoFecha = $('#txtBuscarRangoFecha');
        this.$divFecha = $('#divFecha');
        this.$divRangoFechas = $('#divRangoFechas');
        this.$btnBuscarReporte = $('#btnBuscarReporte');
        this.btnBuscarReporte = '#btnBuscarReporte';
        this.$footerTotales = $('#footerTotales');
        this.conf = {};
        this.inicio();
    }
    Kardex.prototype = {
        funciones: {
            buscarKardexByFecha: function (self) {
                var request = {};
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.Fecha = self.$txtBuscarFecha.data('datepicker').getFormattedDate('yyyy-mm-dd');

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Almacen/BuscarKardexByFecha',
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
            buscarKardexByRangoFecha: function (self) {
                var request = {};
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.FechaInicio = self.$txtBuscarRangoFecha.data('daterangepicker').startDate;//.format('yyyy-mm-dd');
                request.FechaFin = self.$txtBuscarRangoFecha.data('daterangepicker').endDate;//.format('yyyy-mm-dd');
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Almacen/BuscarKardexByRangoFecha',
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
            obtenerConfiguracion: function () {
                var request = {};
                request.Empresa_id = sessionStorage.getItem('empresa');
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Configuracion/ObtenerConfiguracion',
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
                self.$txtBuscarFecha.datepicker({
                    todayHighlight: true
                });

                self.$txtBuscarFecha.datepicker('setDate', new Date());
                self.$txtBuscarRangoFecha.daterangepicker({
                    buttonClasses: ['btn', 'btn-sm'],
                    applyClass: 'btn-danger',
                    cancelClass: 'btn-inverse',
                    dateLimit: {
                        months: 4
                    }
                });
                
                self.dtKardex = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    columns: [
                        { title: 'Item', data: 'productoNombre', width: '30%' },
                        { title: 'Cantidad', data: 'cantidad' },
                        { title: 'Compra', data: 'precio' },
                        { title: 'Cantidad', data: 'cantidad' },
                        { title: 'Venta', data: 'precio' },
                        { title: 'Stock', data: 'stock', class: 'dt-right' },
                        { title: 'Destino', data: 'tipo' },
                        { title: 'Tipo', data: 'tipo', visible: false }
                    ],
                    columnDefs: [
                        {
                            "targets": 1,
                            "render": function (data, type, row) {
                                if (row.tipo == 1)
                                    return data + ' ' + row.unidadMedidaId;
                                else
                                    return '';
                            },
                            "class": 'colorAzul dt-right'
                        },
                        {
                            targets: 2,
                            render: function (data, type, row) {
                                if (row.tipo == 1)
                                    return self.conf.monedaId + ' ' + C.Base.formatoNumero(data, 2);
                                else
                                    return '';
                            },
                            class: 'colorAzul dt-right'
                        },
                        {
                            targets: 3,
                            render: function (data, type, row) {
                                if (row.tipo == 2)
                                    return data + ' ' + row.unidadMedidaId;
                                else
                                    return '';
                            },
                            
                            class: 'colorAmarillo dt-right'
                        },
                        {
                            targets: 4,
                            render: function (data, type, row) {
                                if (row.tipo == 2)
                                    return self.conf.monedaId + ' ' + C.Base.formatoNumero(data, 2);
                                else
                                    return '';
                            },
                            class: 'colorAmarillo dt-right'
                        },
                        {
                            targets: 5,
                            render: function (data, type, row) {
                                return data + ' ' + row.unidadMedidaId;
                            },
                            class: 'dt-right'

                        },
                        {
                            targets: 6,
                            render: function (data, type, row) {
                                if (data == 1)
                                    return '<i>Entrada</i>';
                                else
                                    return '<i>Salida</i>';
                            },
                            class: 'dt-right'
                            
                        }

                    ],
                    footerCallback: function (row, data, start, end, display) {
                        var api = this.api(), data;

                        // Remove the formatting to get integer data for summation
                        var intVal = function (i) {
                            return typeof i === 'string' ?
                                i.replace(/[\$,]/g, '') * 1 :
                                typeof i === 'number' ?
                                    i : 0;
                        };

                        var salidas = 0;
                        var entradas = 0;

                        api
                            .data()
                            .reduce(function (a, b) {
                                if (b.tipo == 1)
                                    entradas += intVal(b.precio);
                                else
                                    salidas += intVal(b.precio);
                            }, 0);

                        if (entradas == 0 && salidas == 0) {
                            self.$footerTotales.hide();
                        }
                        else {
                            self.$footerTotales.show();
                            $(api.column(2).footer()).html(
                                self.conf.monedaId + ' ' + C.Base.formatoNumero(entradas, 2)
                            );

                            $(api.column(4).footer()).html(
                                self.conf.monedaId + ' ' + C.Base.formatoNumero(salidas, 2)
                            );
                        }
                    }
                });

                //$(self.dtKardex.table().footer()).addClass('sinColor');
            },
        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnBuscarReporte, function (e) {
                    e.preventDefault();
                    C.Interfaz.bloquearDiv(self.$divGrilla);
                    if (self.$cboTipoFecha.val() == '1') {
                        var r1 = self.funciones.buscarKardexByFecha(self);
                        $.when(r1).done(function (response) {
                            console.log(response);
                            C.Interfaz.llenarGrilla(self.$grilla, response);
                            C.Interfaz.desbloquearDiv(self.$divGrilla);
                        });
                    }
                    else {
                        var r2 = self.funciones.buscarKardexByRangoFecha(self);
                        $.when(r2).done(function (response) {
                            C.Interfaz.llenarGrilla(self.$grilla, response);
                            C.Interfaz.desbloquearDiv(self.$divGrilla);
                        });
                    }
                });

                $el.on('change', self.cboTipoFecha, function (e) {
                    e.preventDefault();
                    if (self.$cboTipoFecha.val() == 1) {
                        self.$divFecha.show();
                        self.$txtBuscarFecha.datepicker('setDate', new Date());
                        self.$divRangoFechas.hide();
                    }
                    else {
                        self.$divFecha.hide();
                        self.$txtBuscarRangoFecha.data('daterangepicker').setStartDate(new Date());
                        self.$txtBuscarRangoFecha.data('daterangepicker').setEndDate(new Date());
                        self.$divRangoFechas.show();
                    }
                });
            }
        },
        inicio: function () {
            var self = this;

            $(win).on('load', function () {
                C.Base.validarToken();
                self.$divRangoFechas.hide();
                self.eventos.botones(self);
                var r1 = self.funciones.obtenerConfiguracion();
                $.when(r1).done(function (response) {
                    self.conf = response;
                    console.log(response);
                    self.funciones.llenaDatosinicio(self);
                    self.$btnBuscarReporte.click();
                });
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new Kardex, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Kardex);
    } else {
        window.onload = new Kardex;
    }

})(APP, window, jQuery, _);