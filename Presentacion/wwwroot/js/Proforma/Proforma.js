var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Proforma = function () {
        var self = this;
        this.$txtBuscarNro = $('#txtBuscarNro');
        this.$txtBuscarCliente = $('#txtBuscarCliente');
        this.$txtBuscarUsuario = $('#txtBuscarUsuario');
        this.$txtBuscarFecha = $('#txtBuscarFecha');
        this.$cboEstado = $('#cboEstado');
        this.btnBuscar = '#btnBuscar';
        this.btnNuevo = '#btnNuevo';
        this.$grilla = $('#grilla');
        this.$divGrilla = $("#divGrilla");
        this.btnVerImpresion = '.verProforma';

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

        this.proforma = {};
        this.inicio();
    }
    Proforma.prototype = {
        funciones: {
            buscarProformas: function (self) {
                C.Interfaz.bloquearDiv(self.$divGrilla);
                var r1 = self.funciones.obtenerProformas(self);
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grilla, response);
                    C.Interfaz.desbloquearDiv(self.$divGrilla);
                });
            },
            obtenerProformas: function (self) {
                var request = {
                    EmpresaId: sessionStorage.getItem('empresa'),
                    Serie: self.$txtBuscarNro.val(),
                    ClienteNombre: self.$txtBuscarCliente.val(),
                    Usuario: self.$txtBuscarUsuario.val(),
                    FechaInicio: self.$txtBuscarFecha.data('daterangepicker').startDate,
                    FechaFin: self.$txtBuscarFecha.data('daterangepicker').endDate,
                    Estado: self.$cboEstado.val()
                };
                console.log(request);
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Proforma/ObtenerProformasGrilla',
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
                self.$txtBuscarFecha.daterangepicker({
                    buttonClasses: ['btn', 'btn-sm'],
                    applyClass: 'btn-danger',
                    cancelClass: 'btn-inverse',
                    dateLimit: {
                        months: 4
                    }
                });
                var fecha = new Date();
                fecha.setMonth(fecha.getMonth() - 1);
                self.$txtBuscarFecha.data('daterangepicker').setStartDate(fecha);
                self.$txtBuscarFecha.data('daterangepicker').setEndDate(new Date());

                self.dtProforma = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    columns: [
                        { title: "Id", data: 'id', visible: false },
                        { title: "Nro", data: 'codigo' },
                        { title: "Cliente", data: 'clienteNombre', width: '30%' },
                        { title: "Usuario", data: 'nombre' },
                        { title: "Creado", data: 'fechaEmitido' },
                        { title: "Estado", data: 'estadoNombre' },
                        { title: "Total", data: 'total' },
                        { title: "Ver", data: null }
                    ],
                    columnDefs: [{
                        targets: 2,
                        render: function (data, type, row) {
                            return '<a href="' + C.Vars.rutaAPP + '/Proformas/ver?idProf=' + row.id + '" title="Ver">' + data + '</a>';
                        }
                    },
                    {
                        targets: 7,
                        className: 'dt-right',
                        render: function (data, type, row) {
                            return '<a href="#" title="Ver Proforma" data="' + row.id + '" class="verProforma btn btn-primary btn-circle" data-toggle="modal" data-target="#myModalImpresion"><i class="fa fa-file-pdf-o"></i></a>';
                        }
                    }
                    ]
                });
            }
        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnBuscar, function (e) {
                    e.preventDefault();
                    self.funciones.buscarProformas(self);
                });

                $el.on('click', self.btnNuevo, function (e) {
                    e.preventDefault();
                    C.Interfaz.enlace(C.Vars.rutaAPP + '/Proformas/Nuevo');
                });

                $el.on('click', self.btnVerImpresion, function (e) {
                    e.preventDefault();
                    var proformaId = $(this).attr('data');
                    var r1 = self.funciones.obtenerProforma(proformaId);
                    $.when(r1).done(function (response) {
                        self.proforma = response;
                        self.funciones.llenarFormularioImpresion(self);
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
                self.funciones.buscarProformas(self);
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