var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Comprobantes = function () {
        var self = this;
        this.$txtBuscarSerie = $('#txtBuscarSerie');
        this.$txtBuscarCliente = $('#txtBuscarCliente');
        this.$txtBuscarUsuario = $('#txtBuscarUsuario');
        this.$cboBuscarTipo = $('#cboBuscarTipo');
        this.$txtBuscarEmitido = $('#txtBuscarEmitido');
        this.$cboBuscarEstado = $('#cboBuscarEstado');
        this.$btnBuscar = $('#btnBuscar');
        this.btnBuscar = '#btnBuscar';
        this.btnNuevo = '#btnNuevo';
        this.$grilla = $('#grilla');
        this.$divGrilla = $('#divGrilla');
        this.modal = '#myModal';

        this.dtComprobante = {};
        this.inicio();
    }
    Comprobantes.prototype = {
        funciones: {
            obtenerComprobantes: function (self) {
                var request = {};
                request.Empresa_id = sessionStorage.getItem('empresa');
                request.Serie = self.$txtBuscarSerie.val();
                request.ClienteNombre = self.$txtBuscarCliente.val();
                request.Usuario = self.$txtBuscarUsuario.val();
                request.ComprobanteTipo_id = self.$cboBuscarTipo.val();
                request.FechaEmitidoInicio = self.$txtBuscarEmitido.data('daterangepicker').startDate;
                request.FechaEmitidoFin = self.$txtBuscarEmitido.data('daterangepicker').endDate;
                request.Estado = self.$cboBuscarEstado.val();
                console.log(request);
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerComprobantes',
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
                self.$txtBuscarEmitido.daterangepicker({
                    buttonClasses: ['btn', 'btn-sm'],
                    applyClass: 'btn-danger',
                    cancelClass: 'btn-inverse',
                    dateLimit: {
                        months: 4
                    }
                });
                var fecha = new Date();
                fecha.setMonth(fecha.getMonth() - 1);
                self.$txtBuscarEmitido.data('daterangepicker').setStartDate(fecha);
                self.$txtBuscarEmitido.data('daterangepicker').setEndDate(new Date());

                self.dtComprobante = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,

                    columns: [
                        { title: 'Id', data: 'id', visible: false },
                        { title: 'Serie', data: 'codigo' },
                        { title: 'Cliente', data: 'clienteNombre', width: '30%' },
                        { title: 'Usuario', data: 'nombreUsuario', width: '10%' },
                        { title: 'Tipo', data: 'tipo' },
                        { title: 'Emitido', data: 'fechaEmitido' },
                        { title: 'Estado', data: 'estadoNombre', width: '15%' },
                        { title: 'Total', data: 'total' },
                        { title: 'EstadoId', data: 'estado', visible: false },
                        { title: 'ClienteIdentidad', data: 'clienteIdentidad', visible: false }
                    ],
                    columnDefs: [
                        {
                            targets: 2,
                            data: null,
                            render: function (data, type, row) {
                                return '<a href="' + C.Vars.rutaAPP + '/Comprobantes/ver?idComp=' + row.id + '" title="Ver">' + data + '</a>';
                            }
                        },
                        {
                            targets: 5,
                            render: function (data) {
                                return moment(data).format('YYYY-MM-DD');
                            }
                        },
                        {
                            targets: 6,
                            render: function (data, type, row) {
                                if (row.estado == 1) return '<span style="color:#D15600;font-weight:bold;">' + row.estadoNombre + '</span>';
                                if (row.estado == 2) return '<span style="color:#006E2E;font-weight:bold;">' + row.estadoNombre + '</span>';
                                if (row.estado == 3) return '<span style="color:#CC0000;font-weight:bold;">' + row.estadoNombre + '</span>';
                                if (row.estado == 4) return '<span style="color:purple;font-weight:bold;">' + row.EstadoNombre + '</span>';
                                if (row.estado == 5) return '<span style="color:blue;font-weight:bold;">' + row.estadoNombre + '</span>';
                                if (row.estado == 6) return '<span style="color:green;font-weight:bold;">' + row.EstadoNombre + '</span>';
                                return moment(data).format('YYYY-MM-DD');
                            }
                        },
                        {
                            targets: 10,
                            data: null,
                            className: 'dt-center',
                            render: function (data, type, row) {
                                return '<a href="#" class="verPDF" title="Ver"><i class="fa fa-file-pdf-o" aria-hidden="true"></i></a>';
                            }
                        },
                        {
                            targets: 11,
                            data: null,
                            className: 'dt-center',
                            render: function (data, type, row) {
                                return '<a href="#" class="verXML" title="Ver"><i class="fa fa-file-archive-o" aria-hidden="true"></i></a>';
                            }
                        },
                    ],
                    order: [[5, 'desc']]
                });

            }
        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnBuscar, function (e) {
                    e.preventDefault();
                    C.Interfaz.bloquearDiv(self.$divGrilla);
                    var r1 = self.funciones.obtenerComprobantes(self);
                    $.when(r1).done(function (response) {
                        C.Interfaz.llenarGrilla(self.$grilla, response);
                        C.Interfaz.desbloquearDiv(self.$divGrilla);
                    });
                });

                $el.on('click', self.btnNuevo, function (e) {
                    e.preventDefault();
                    C.Interfaz.enlace(C.Vars.rutaAPP + '/Comprobantes/Nuevo');
                });

                $el.on('click', '.verPDF', function () {
                    var data = self.dtComprobante.row($(this).parents('tr')).data();
                    var ruc = data.clienteIdentidad;
                    var correlativo = data.correlativo;
                    var tipoDTE = data.comprobanteTipoId;
                    var serie = data.serie;
                    var fechaDTE = data.fechaEmitido.substring(0, 10);
                    var monTotal = data.total;
                    var request = {};
                    request.xml = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:dbn="http://www.dbnet.cl">' +
                    '<soapenv:Header/>' +
                    '<soapenv:Body>' +
                    '<dbn:getDocumentoPDF>' +
                    '<!--Optional:-->' +
                    '<dbn:_ruttEmpr>' + ruc + '</dbn:_ruttEmpr>' +
                    '<!--Optional:-->' +
                    '<dbn:_folioDTE>' + correlativo + '</dbn:_folioDTE>' +
                    '<!--Optional:-->' +
                    '<dbn:_tipoDTE>' + tipoDTE + '</dbn:_tipoDTE>' +
                    '<!--Optional:-->' +
                    '<dbn:_serieInte>' + serie + '</dbn:_serieInte>' +
                    '<!--Optional:-->' +
                    '<dbn:_fechaDTE>' + fechaDTE + '</dbn:_fechaDTE>' +
                    '<!--Optional:-->' +
                    '<dbn:_monTotal>' + monTotal + '</dbn:_monTotal>' +
                    '</dbn:getDocumentoPDF>' +
                    '</soapenv:Body>' +
                    '</soapenv:Envelope>';

                    var r1 = $.ajax({
                        url: C.Vars.rutaSERV + '/api/Comprobante/GenerarPDF',
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
                        if (response.nombreArchivo != '') {
                            const linkSource = 'data:application/pdf;base64,' + response.fichero;
                            const downloadLink = document.createElement("a");
                            const fileName = response.nombreArchivo;

                            downloadLink.href = linkSource;
                            downloadLink.download = fileName;
                            downloadLink.click();
                        }
                        else {
                            alert('El documento no fue encontrado por favor intente mas tarde');
                        }
                    });
                });

                $el.on('click', '.verXML', function () {
                    var data = self.dtComprobante.row($(this).parents('tr')).data();
                    var ruc = data.clienteIdentidad;
                    var correlativo = data.correlativo;
                    var tipoDTE = data.comprobanteTipoId;
                    var serie = data.serie;
                    var fechaDTE = data.fechaEmitido.substring(0, 10);
                    var monTotal = data.total;
                    var request = {};
                    request.xml = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:dbn="http://www.dbnet.cl">' +
                    '<soapenv:Header/>' +
                    '<soapenv:Body>' +
                    '<dbn:getDocumentoXML>' +
                    '<!--Optional:-->' +
                    '<dbn:_ruttEmpr>' + ruc + '</dbn:_ruttEmpr>' +
                    '<!--Optional:-->' +
                    '<dbn:_folioDTE>' + correlativo + '</dbn:_folioDTE>' +
                    '<!--Optional:-->' +
                    '<dbn:_tipoDTE>' + tipoDTE + '</dbn:_tipoDTE>' +
                    '<!--Optional:-->' +
                    '<dbn:_serieInte>' + serie + '</dbn:_serieInte>' +
                    '<!--Optional:-->' +
                    '<dbn:_fechaDTE>' + fechaDTE + '</dbn:_fechaDTE>' +
                    '<!--Optional:-->' +
                    '<dbn:_monTotal>' + monTotal + '</dbn:_monTotal>' +
                    '</dbn:getDocumentoXML>' +
                    '</soapenv:Body>' +
                    '</soapenv:Envelope>';

                    var r1 = $.ajax({
                        url: C.Vars.rutaSERV + '/api/Comprobante/GenerarXML',
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
                        if (response.nombreArchivo != '') {
                            const linkSource = 'data:application/octet-stream,' + encodeURIComponent(response.fichero);
                            const downloadLink = document.createElement("a");
                            const fileName = response.nombreArchivo;

                            downloadLink.href = linkSource;
                            downloadLink.download = fileName;
                            downloadLink.click();
                        }
                        else {
                            alert('El documento no fue encontrado por favor intente mas tarde');
                        }
                    });
                });

            }
        },
        inicio: function () {
            var self = this;
            $(win).on('load', function () {
                C.Base.validarToken();
                self.eventos.botones(self);
                self.funciones.llenaDatosinicio(self);
                C.Interfaz.bloquearDiv(self.$divGrilla);
                var r1 = self.funciones.obtenerComprobantes(self);
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grilla, response);
                    C.Interfaz.desbloquearDiv(self.$divGrilla);
                });
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new Comprobantes, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Comprobantes);
    } else {
        window.onload = new Comprobantes;
    }

})(APP, window, jQuery, _);