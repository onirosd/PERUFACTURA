var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Reportes = function () {
        var self = this;
        self.$sltReporte = $('#sltReporte');
        self.sltReporte = '#sltReporte';
        self.reportes = '.reportes';

        self.$rptComprobantes = $('#controlReporteComprobantes');
        self.$grillaReporteComprobantes = $('#grillaReporteComprobantes');
        self.btnExportRptComprobantes = '#btnExportRptComprobantes';
        self.$cboMonedaRptComprobantes = $('#cboMonedaRptComprobantes');
        self.$cboMesesRptComprobantes = $('#cboMesesRptComprobantes');
        self.$cboAnioRptComprobantes = $('#cboAnioRptComprobantes');
        self.$spMonedaReporteMesDetallado = $('#spMonedaReporteMesDetallado');

        self.$rptProformas = $('#controlReporteProformas');
        self.$grillaReporteProformas = $('#grillaReporteProformas');
        self.btnExportRptProformas = '#btnExportRptProformas';
        self.$cboMonedaRptProformas = $('#cboMonedaRptProformas');
        self.$cboMesesRptProformas = $('#cboMesesRptProformas');
        self.$cboAnioRptProformas = $('#cboAnioRptProformas');
        self.$spMonedaReporteMesDetalladoProformas = $('#spMonedaReporteMesDetalladoProformas');

        self.$rptDiario = $('#controlReporteDiario');
        self.$grillaReporteVentaDiario = $('#grillaReporteVentaDiario');
        self.$cboMonedaRptDiario = $('#cboMonedaRptDiario');
        self.$cboMesesRptDiario = $('#cboMesesRptDiario');
        self.$cboAnioRptDiario = $('#cboAnioRptDiario');
        self.graficaRptDiario = '#graficaRptDiario';
        self.$spMonedaReporteDiario = $('#spMonedaReporteDiario');

        self.$rptMensual = $('#controlReporteMensual');
        self.$grillaReporteVentaMensual = $('#grillaReporteVentaMensual');
        self.$cboMonedaRptMensual = $('#cboMonedaRptMensual');
        self.$cboAnioRptMensual = $('#cboAnioRptMensual');
        self.graficaRptMensual = '#graficaRptMensual'; 
        self.$spMonedaReporteMensual = $('#spMonedaReporteMensual');

        self.$rptAnual = $('#controlReporteAnual');
        self.$grillaReporteVentaAnual = $('#grillaReporteVentaAnual');
        self.$cboMonedaRptAnual = $('#cboMonedaRptAnual');
        self.graficaRptAnual = '#graficaRptAnual';
        self.$spMonedaReporteAnual = $('#spMonedaReporteAnual');

        self.$rptTopClientes = $('#controlReporteTopClientes');
        self.$grillaReporteTopClientes = $('#grillaReporteTopClientes');
        self.$cboMonedaRptTopClientes = $('#cboMonedaRptTopClientes');
        self.$cboMesesRptTopClientes = $('#cboMesesRptTopClientes');
        self.$cboAnioRptTopClientes = $('#cboAnioRptTopClientes');
        self.$spMonedaReporteTopClientes = $('spMonedaReporteTopClientes');

        self.$rptTopEmpleados = $('#controlReporteTopEmpleados');
        self.$grillaReporteTopEmpleados = $('#grillaReporteTopEmpleados');
        self.$cboMonedaRptTopEmpleados = $('#cboMonedaRptTopEmpleados');
        self.$cboMesesRptTopEmpleados = $('#cboMesesRptTopEmpleados');
        self.$cboAnioRptTopEmpleados = $('#cboAnioRptTopEmpleados');
        self.$spMonedaReporteTopEmpleados = $('#spMonedaReporteTopEmpleados');

        self.$rptTopProductos = $('#controlReporteTopProductos');
        self.$grillaReporteTopProductos = $('#grillaReporteTopProductos');
        self.$cboMonedaRptTopProductos = $('#cboMonedaRptTopProductos');
        self.$cboMesesRptTopProductos = $('#cboMesesRptTopProductos');
        self.$cboAnioRptTopProductos = $('#cboAnioRptTopProductos');
        self.$spMonedaReporteTopProductos = $('#spMonedaReporteTopProductos');

        self.$rptProductoTrimestral = $('#controlReporteProductoTrimestral');
        self.monedas = [];
        self.configuracion = {};
        this.inicio();

    }
    Reportes.prototype = {
        funciones: {
            ExportToExcelComprobantes: function (self) {
                var htmltable = document.getElementById('grillaReporteComprobantes');
                var html = htmltable.outerHTML;
                window.open('data:application/vnd.ms-excel,' + encodeURIComponent(html));
            },
            ExportToExcelProformas: function (self) {
                var htmltable = document.getElementById('grillaReporteProformas');
                var html = htmltable.outerHTML.replace(/\width/g, 'dd');
                window.open('data:application/vnd.ms-excel,' + encodeURIComponent(html));
            },
            reporte: function (self) {
                var reporte = null;
                var titulo = '';

                $(self.reportes).hide();

                /* Reporte de Venta Diario */
                if (self.$sltReporte.val() == '1') {
                    self.$rptDiario.show();
                    reporte = self.funciones.reporteDiario(self);
                }

                /* Reporte de Venta Mensual */
                if (self.$sltReporte.val() == '2') {
                    self.$rptMensual.show();
                    reporte = self.funciones.reporteMensual(self);
                }

                /* Reporte de Venta Anual */
                if (self.$sltReporte.val() == '3') {
                    self.$rptAnual.show();
                    reporte = self.funciones.reporteAnual(self);
                }

                /* Productos mas vendidos */
                if (self.$sltReporte.val() == '4') {
                    self.$rptTopProductos.show();
                    reporte = self.funciones.productosMasVendidos(self);
                }

                /* Mejores Clientes */
                if (self.$sltReporte.val() == '5') {
                    self.$rptTopClientes.show();
                    reporte = self.funciones.mejoresClientes(self);
                }

                /* Rentabilidad de producto trimestral */
                if (self.$sltReporte.val() == '6') {
                    self.$rptProductoTrimestral.show();
                    reporte = self.funciones.productosRentablesPorTrimestre(self);
                }

                /* Mejores Empleados */
                if (self.$sltReporte.val() == '7') {
                    self.$rptTopEmpleados.show();
                    reporte = self.funciones.mejoresEmpleados(self);
                }

                /* Detallado Mes */
                if (self.$sltReporte.val() == '8') {
                    self.$rptComprobantes.show();
                    reporte = self.funciones.reporteMesDetallado(self);
                }

                /* Detallado Mes Proformas */
                if (self.$sltReporte.val() == '9') {
                    self.$rptProformas.show();
                    
                    reporte = self.funciones.reporteMesDetalladoProformas(self);
                }

            },
            reporteDiario: function (self) {
                var request = {};
                request.Anio = self.$cboAnioRptDiario.val();
                request.Mes = self.$cboMesesRptDiario.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.TipoMonedaId = self.$cboMonedaRptDiario.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerReporteDiario',
                    type: 'post',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                self.$spMonedaReporteDiario.html(self.$cboMonedaRptDiario.val());
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grillaReporteVentaDiario, response);
                    console.log(response);
                    var diasEnUnMes = new Date(self.$cboAnioRptDiario.val(), self.$cboMesesRptDiario.val(), 0).getDate();
                    var dias = [];
                    var vendido = [];
                    var ganancia = [];
                    for (var i = 1; i <= diasEnUnMes; i++) {
                        dias.push(i);
                        var encontrado = false;
                        $.each(response, function (index, value) {
                            var d = new Date(value.fechaEmitido);
                            if (d.getDate() == i) {
                                var v = { meta: 'Vendido', value: value.vendido };
                                vendido.push(v);
                                var g = { meta: 'Ganancia', value: value.ganancia };
                                ganancia.push(g);
                                encontrado = true;
                            }
                        });

                        if (!encontrado) {
                            var v = { meta: 'Vendido', value: 0 };
                            vendido.push(v);
                            var g = { meta: 'Ganancia', value: 0 };
                            ganancia.push(g);
                        }
                    }
                    new Chartist.Line(self.graficaRptDiario, {
                        labels: dias,
                        series: [
                            vendido,
                            ganancia
                        ]
                    }, {
                            top: 0,

                            low: 1,
                            showPoint: true,

                            fullWidth: true,
                            plugins: [
                                Chartist.plugins.tooltip()
                            ],
                            axisY: {
                                labelInterpolationFnc: function (value) {
                                    return (value / 1) + 'k';
                                }
                            },
                            showArea: true
                        });
                });
            },
            reporteMensual: function (self) {
                var request = {};
                request.Anio = self.$cboAnioRptMensual.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.TipoMonedaId = self.$cboMonedaRptMensual.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerReporteMensual',
                    type: 'post',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                self.$spMonedaReporteMensual.html(self.$cboMonedaRptMensual.val());
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grillaReporteVentaMensual, response);
                    console.log(response);
                    var meses = ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Set', 'Oct', 'Nov', 'Dic'];
                    var vendido = [];
                    var ganancia = [];
                    for (var i = 1; i <= 12; i++) {
                        var encontrado = false;
                        $.each(response, function (index, value) {
                            if (value.mesEmitido == i) {
                                var v = { meta: 'Vendido', value: value.vendido };
                                vendido.push(v);
                                var g = { meta: 'Ganancia', value: value.ganancia };
                                ganancia.push(g);
                                encontrado = true;
                            }
                        });

                        if (!encontrado) {
                            var v = { meta: 'Vendido', value: 0 };
                            vendido.push(v);
                            var g = { meta: 'Ganancia', value: 0 };
                            ganancia.push(g);
                        }
                    }
                    new Chartist.Line(self.graficaRptMensual, {
                        labels: meses,
                        series: [
                            vendido,
                            ganancia
                        ]
                    }, {
                            top: 0,

                            low: 1,
                            showPoint: true,

                            fullWidth: true,
                            plugins: [
                                Chartist.plugins.tooltip()
                            ],
                            axisY: {
                                labelInterpolationFnc: function (value) {
                                    return (value / 1) + 'k';
                                }
                            },
                            showArea: true
                        });
                });
            },
            reporteAnual: function (self) {
                var request = {};
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.TipoMonedaId = self.$cboMonedaRptAnual.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerReporteAnual',
                    type: 'post',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                self.$spMonedaReporteAnual.html(self.$cboMonedaRptAnual.val());
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grillaReporteVentaAnual, response);
                    var d = new Date();
                    var y = d.getFullYear();
                    var anios = C.Base.obtenerAnios(self.configuracion.anio - 1);
                    anios.push(y + 1);
                    var vendido = [];
                    var ganancia = [];
                    for (var i = anios[0]; i <= y + 1; i++) {
                        var encontrado = false;
                        $.each(response, function (index, value) {
                            if (value.anioEmitido == i) {
                                var v = { meta: 'Vendido', value: value.vendido };
                                vendido.push(v);
                                var g = { meta: 'Ganancia', value: value.ganancia };
                                ganancia.push(g);
                                encontrado = true;
                            }
                        });

                        if (!encontrado) {
                            var v = { meta: 'Vendido', value: 0 };
                            vendido.push(v);
                            var g = { meta: 'Ganancia', value: 0 };
                            ganancia.push(g);
                        }
                    }
                    new Chartist.Line(self.graficaRptAnual, {
                        labels: anios,
                        series: [
                            vendido,
                            ganancia
                        ]
                    }, {
                            top: 0,

                            low: 1,
                            showPoint: true,

                            fullWidth: true,
                            plugins: [
                                Chartist.plugins.tooltip()
                            ],
                            axisY: {
                                labelInterpolationFnc: function (value) {
                                    return (value / 1) + 'k';
                                }
                            },
                            showArea: true
                        });
                });
            },
            productosMasVendidos: function (self) {
                var request = {};
                request.Anio = self.$cboAnioRptTopProductos.val();
                request.Mes = self.$cboMesesRptTopProductos.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.TipoMonedaId = self.$cboMonedaRptTopProductos.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerReporteTopProductos',
                    type: 'post',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });

                self.$spMonedaReporteTopProductos.html(self.$cboMonedaRptTopProductos.val());
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grillaReporteTopProductos, response);
                });
            },
            mejoresClientes: function (self) {
                var request = {};
                request.Anio = self.$cboAnioRptTopClientes.val();
                request.Mes = self.$cboMesesRptTopClientes.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.TipoMonedaId = self.$cboMonedaRptTopClientes.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerReporteTopClientes',
                    type: 'post',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });

                self.$spMonedaReporteTopClientes.html(self.$cboMonedaRptTopClientes.val());
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grillaReporteTopClientes, response);
                });
            },
            productosRentablesPorTrimestre: function (self) {
                //var request = {};
                //request.Anio = self.$cboAnioRpt.val();
                //request.EmpresaId = sessionStorage.getItem('empresa');
                //request.TipoMonedaId = self.$cboMonedaRptTopClientes.val();
            },
            mejoresEmpleados: function (self) {
                var request = {};
                request.Anio = self.$cboAnioRptTopEmpleados.val();
                request.Mes = self.$cboMesesRptTopEmpleados.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.TipoMonedaId = self.$cboMonedaRptTopEmpleados.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerReporteTopEmpleados',
                    type: 'post',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });

                self.$spMonedaReporteTopEmpleados.html(self.$cboMonedaRptTopEmpleados.val());
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grillaReporteTopEmpleados, response);
                });
            },
            reporteMesDetallado: function (self) {
                var request = {};
                request.Anio = self.$cboAnioRptComprobantes.val();
                request.Mes = self.$cboMesesRptComprobantes.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.TipoMonedaId = self.$cboMonedaRptComprobantes.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerReporteMesDetallado',
                    type: 'post',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });

                self.$spMonedaReporteMesDetallado.html(self.$cboMonedaRptComprobantes.val());
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grillaReporteComprobantes, response);
                });
            },
            reporteMesDetalladoProformas: function (self) {
                var request = {};
                request.Anio = self.$cboAnioRptProformas.val();
                request.Mes = self.$cboMesesRptProformas.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.TipoMonedaId = self.$cboMonedaRptProformas.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerReporteMesDetalladoProforma',
                    type: 'post',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(request),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });

                self.$spMonedaReporteMesDetalladoProformas.html(self.$cboMonedaRptProformas.val());
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grillaReporteProformas, response);
                });
            },
            obtenerMonedas: function () {
                var request = {};
                request.Relacion = 'moneda';
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/TablaDato/ObtenerTipos',
                    type: 'post',
                    contentType: 'application/json; charset=utf-8',
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
                    contentType: 'application/json; charset=utf-8',
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
                
                //obtener los meses para los combos
                $.each(C.Vars.meses, function (Key, reg) {
                    self.$cboMesesRptComprobantes.append('<option value=' + reg.mes + '>' + reg.texto + '</option>');
                    self.$cboMesesRptProformas.append('<option value=' + reg.mes + '>' + reg.texto + '</option>');
                    self.$cboMesesRptDiario.append('<option value=' + reg.mes + '>' + reg.texto + '</option>');
                    self.$cboMesesRptTopClientes.append('<option value=' + reg.mes + '>' + reg.texto + '</option>');
                    self.$cboMesesRptTopEmpleados.append('<option value=' + reg.mes + '>' + reg.texto + '</option>');
                    self.$cboMesesRptTopProductos.append('<option value=' + reg.mes + '>' + reg.texto + '</option>');
                });

                //obtener monedas y configuracion
                var r1 = self.funciones.obtenerMonedas();
                var r2 = self.funciones.obtenerConfiguracion();
                $.when(r1, r2).done(function (response1, response2) {
                    self.monedas = response1[0];
                    self.configuracion = response2[0];
                    //console.log(self.monedas);
                    //console.log(self.configuracion);
                    $.each(self.monedas, function (index, value) {
                        self.$cboMonedaRptComprobantes.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                        self.$cboMonedaRptProformas.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                        self.$cboMonedaRptDiario.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                        self.$cboMonedaRptMensual.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                        self.$cboMonedaRptAnual.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                        self.$cboMonedaRptTopClientes.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                        self.$cboMonedaRptTopEmpleados.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                        self.$cboMonedaRptTopProductos.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                    });

                    var d = new Date();
                    var y = d.getFullYear();
                    var m = d.getMonth() + 1;
                    //selecciona el mes actual para los combos "mes"
                    self.$cboMesesRptComprobantes.val(m);
                    self.$cboMesesRptProformas.val(m);
                    self.$cboMesesRptDiario.val(m);
                    self.$cboMesesRptTopClientes.val(m);
                    self.$cboMesesRptTopEmpleados.val(m);
                    self.$cboMesesRptTopProductos.val(m);

                    //llena los combos de año
                    C.Base.llenaCboAnios(self.$cboAnioRptComprobantes, self.configuracion.anio);
                    C.Base.llenaCboAnios(self.$cboAnioRptProformas, self.configuracion.anio);
                    C.Base.llenaCboAnios(self.$cboAnioRptDiario, self.configuracion.anio);
                    C.Base.llenaCboAnios(self.$cboAnioRptMensual, self.configuracion.anio);
                    C.Base.llenaCboAnios(self.$cboAnioRptTopClientes, self.configuracion.anio);
                    C.Base.llenaCboAnios(self.$cboAnioRptTopEmpleados, self.configuracion.anio);
                    C.Base.llenaCboAnios(self.$cboAnioRptTopProductos, self.configuracion.anio);

                    //llama al reporte por primera vez con datos por defecto
                    self.funciones.reporte(self, y, m, 'S/');
                });

                //grilla Reporte Comprobantes
                self.$grillaReporteComprobantes.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: 'Documento', data: 'documento' },
                        { title: 'Serie', data: 'serie' },
                        { title: 'Correlativo', data: 'correlativo' },
                        { title: 'NroDocumento', data: 'nroDocumento' },
                        { title: 'Nombre Cliente', data: 'nombre' },
                        { title: 'Fec. Emisión', data: 'fecha' },
                        { title: 'Monto', data: 'importe' },
                        { title: 'Estado', data: 'estado' }
                    ],
                    columnDefs: [
                        {
                            targets: 5,
                            render: function (data) {
                                return moment(data).format('YYYY-MM-DD');
                            }
                        }
                    ]
                });

                self.$grillaReporteProformas.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: 'Serie', data: 'serie' },
                        { title: 'Correlativo', data: 'correlativo' },
                        { title: 'NroDocumento', data: 'nroDocumento' },
                        { title: 'Nombre Cliente', data: 'nombre' },
                        { title: 'Fec. Emisión', data: 'fecha' },
                        { title: 'Monto', data: 'importe' }
                    ],
                    columnDefs: [
                        {
                            targets: 4,
                            render: function (data) {
                                return moment(data).format('YYYY-MM-DD');
                            }
                        }
                    ]
                });

                //grilla Reporte Venta Diario
                self.$grillaReporteVentaDiario.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: '', data: 'fechaEmitido' },
                        { title: 'Boleta', data: 'boleta' },
                        { title: 'Factura', data: 'factura' },
                        { title: 'Menudeo', data: 'menudeo' },
                        { title: 'Ganado', data: 'ganancia' },
                        { title: 'Vendido', data: 'vendido' }
                    ], 
                    columnDefs: [
                        {
                            targets: 0,
                            render: function (data) {
                                return C.Base.dateFormat(data, 1);
                            }
                        }
                    ]

                });

                //grilla Reporte Venta Mensual
                self.$grillaReporteVentaMensual.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: '', data: 'mesEmitido' },
                        { title: 'Boleta', data: 'boleta' },
                        { title: 'Factura', data: 'factura' },
                        { title: 'Menudeo', data: 'menudeo' },
                        { title: 'Ganado', data: 'ganancia' },
                        { title: 'Vendido', data: 'vendido' }
                    ],
                    columnDefs: [
                        {
                            targets: 0,
                            render: function (data) {
                                return C.Base.monthToSpanish(data, true);
                            }
                        }
                    ],
                    order: [[0, "desc"]]
                });

                //grilla Reporte Venta Anual
                self.$grillaReporteVentaAnual.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: '', data: 'anioEmitido' },
                        { title: 'Boleta', data: 'boleta' },
                        { title: 'Factura', data: 'factura' },
                        { title: 'Menudeo', data: 'menudeo' },
                        { title: 'Ganado', data: 'ganancia' },
                        { title: 'Vendido', data: 'vendido' }
                    ],
                    order: [[0, "desc"]]
                });

                //grilla Reporte Top Clientes
                self.$grillaReporteTopClientes.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: 'Descripcion', data: 'nombre' },
                        { title: 'N de Veces', data: 'cantidad' },
                        { title: 'Ganado', data: 'ganancia' },
                        { title: 'Vendido', data: 'vendido' }
                    ]
                });

                //grilla Reporte Top Empleados
                self.$grillaReporteTopEmpleados.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: 'Descripcion', data: 'nombre' },
                        { title: 'N de Ventas', data: 'cantidad' },
                        { title: 'Ganado', data: 'ganado' },
                        { title: 'Vendido', data: 'vendido' }
                    ]
                });

                //grilla Reporte Top Productos
                self.$grillaReporteTopProductos.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: 'Descripcion', data: 'nombre' },
                        { title: 'Cantidades', data: 'cantidad' },
                        { title: 'Ganado', data: 'ganado' },
                        { title: 'Vendido', data: 'vendido' }
                    ],
                    columnDefs: [
                        {
                            targets: 1,
                            render: function (data, type, row, meta) {
                                return data + ' ' + row.unidadMedidaId;
                            }
                        }
                    ],
                });
            }
        },
        eventos: {
            botones: function (self) {
                
                $el.on('click', self.btnExportRptComprobantes, function (e) {
                    e.preventDefault();
                    self.funciones.ExportToExcelComprobantes(self);
                });

                $el.on('click', self.btnExportRptProformas, function (e) {
                    e.preventDefault();
                    self.funciones.ExportToExcelProformas(self);
                });

                $el.on('change', self.sltReporte, function (e) {
                    e.preventDefault();
                    self.funciones.reporte(self);
                });

                $('a[data-rpt="rptVentaDiario"]').on('shown.bs.tab', function (e) {
                    $(self.graficaRptDiario)[0].__chartist__.update();
                });

                $('a[data-rpt="rptVentaMensual"]').on('shown.bs.tab', function (e) {
                    $(self.graficaRptMensual)[0].__chartist__.update();
                });

                $('a[data-rpt="rptVentaAnual"]').on('shown.bs.tab', function (e) {
                    $(self.graficaRptAnual)[0].__chartist__.update();
                });

            }
        },
        inicio: function () {
            var self = this;
            $(win).on('load', function () {
                C.Base.validarToken();
                self.eventos.botones(self);
                self.funciones.llenaDatosinicio(self);
                //self.$divReporteComprobantes.show();
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener('load', new Reportes, false);
    } else if (window.attachEvent) {
        window.attachEvent('onload', new Reportes);
    } else {
        window.onload = new Reportes;
    }

})(APP, window, jQuery, _);