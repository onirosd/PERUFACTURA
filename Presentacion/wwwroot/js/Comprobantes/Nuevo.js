var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var NuevoComprobante = function () {
        var self = this;
        this.btnGuardar = '#btnGuardarConfig';
        this.$cboTipoDocumento = $('#cboTipoDocumento');
        this.cboTipoDocumento = '#cboTipoDocumento';
        this.$cboCliente = $('#cboCliente');
        this.cboCliente = '#cboCliente';
        this.$txtRuc = $('#txtRuc');
        this.$txtFecha = $('#txtFecha');
        this.$txtEstado = $('#txtEstado');
        this.$cboSerie = $('#cboSerie');
        this.cboSerie = '#cboSerie';
        this.$txtEmail = $('#txtEmail');
        this.$txtDireccion = $('#txtDireccion');
        this.$txtFechaVencimiento = $('#txtFechaVencimiento');
        this.$cboMoneda = $('#cboMoneda');
        this.cboMoneda = '#cboMoneda';
        this.$txtTipoCambio = $('#txtTipoCambio');
        this.$divTipoCambio = $('.divTipoCambio');
        this.$divTipoOperacion = $('#divTipoOperacion');
        this.$cboTipoOperacion = $('#cboTipoOperacion');
        this.cboTipoOperacion = '#cboTipoOperacion';
        this.$txtNroOC = $('#txtNroOC');
        this.$divReferencia = $('#divReferencia');
        this.$divDetraccion = $('#divDetraccion');
        this.$cboDetraccion = $('#cboDetraccion');
        this.cboDetraccion = '#cboDetraccion';
        this.$spMoneda = $('.spMoneda');
        this.$cboTipoNota = $('#cboTipoNota');
        this.$spCorreoRequerido = $('#spCorreoRequerido');
        this.$spDireccionRequerido = $('#spDireccionRequerido');
        this.$spClienteRequerido = $('#spClienteRequerido');
        this.$spIdentidad = $('#spIdentidad');
        this.$spRucRequerido = $('#spRucRequerido');
        this.$trSubTotal = $('#trSubTotal');
        this.$trIva = $('#trIva');
        this.$txtSerieRef = $('#txtSerieRef');
        this.$txtCorrelativoRef = $('#txtCorrelativoRef');
        this.$txtIva = $('#txtIva');
        this.$txtSubTotal = $('#txtSubTotal');
        this.$txtIvaSubTotal = $('#txtIvaSubTotal');
        this.$txtTotal = $('#txtTotal');
        this.$txtGlosa = $('#txtGlosa');
        this.clientes = [];
        this.dtComprobante = {};
        this.$grilla = $('#grilla');
        this.btnGuardarComprobante = '#btnGuardarComprobante';
        this.$divMsg = $('#divMsg');
        this.$listaMsg = $('#listaMsg');
        this.fila = 0;
        this.ComprobanteTipo_id = 0;
        this.conf = {};
        this.$cboMedioPago = $('#cboMedioPago');

        /* Agregar Cliente */
        this.modal = '#myModalEditCliente';
        this.$modal = $('#myModalEditCliente');
        this.$ddlTipoDocumentoClienteEdit = $('#ddlTipoDocumentoClienteEdit');
        this.ddlTipoDocumentoClienteEdit = '#ddlTipoDocumentoClienteEdit';
        this.$txtNroDocumentoEdit = $('#txtNroDocumentoEdit');
        this.$txtNombreClienteEdit = $('#txtNombreClienteEdit');
        this.$txtDireccionClienteEdit = $('#txtDireccionClienteEdit');
        this.$txtTelefonoPrincipalClienteEdit = $('#txtTelefonoPrincipalClienteEdit');
        this.$txtTelefonoAdicionalClienteEdit = $('#txtTelefonoAdicionalClienteEdit');
        this.$txtCorreoPrincipalClienteEdit = $('#txtCorreoPrincipalClienteEdit');
        this.$txtCorreoAdicional1ClienteEdit = $('#txtCorreoAdicional1ClienteEdit');
        this.$txtCorreoAdicional2ClienteEdit = $('#txtCorreoAdicional2ClienteEdit');
        this.$txtCorreoAdicional3ClienteEdit = $('#txtCorreoAdicional3ClienteEdit');
        this.$txtCorreoAdicional4ClienteEdit = $('#txtCorreoAdicional4ClienteEdit');
        this.$txtCorreoAdicional5ClienteEdit = $('#txtCorreoAdicional5ClienteEdit');
        this.btnGuardarCliente = '#btnEditCliente';

        /* Agregar Producto */
        this.modalProducto = '#myModalEditProducto';
        this.$modalProducto = $('#myModalEditProducto');
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
        this.btnNuevoProducto = '.btnNuevoProducto';
        this.btnGuardarProducto = '#btnEditProducto';

        /* Agregar Servicio */
        this.modalServicio = '#myModalEditServicio';
        this.$modalServicio = $('#myModalEditServicio');
        this.$txtNombreEdit = $('#txtNombreEdit');
        this.$txtCostoEdit = $('#txtCostoEdit');
        this.$txtPrecioEdit = $('#txtPrecioEdit');
        this.$helperPorcentaje = $('#helperPorcentaje');
        this.$divGanancia = $('#divGanancia');
        this.$txtGananciaServicio = $('#txtGananciaServicio');
        this.btnNuevoServicio = '.btnNuevoServicio';
        this.btnGuardarServicio = '#btnEditServicio';
        this.idServicio = 0;
        
        //campos para edicion antes de enviar a la sunat
        self.codComprobante = C.Base.obtenerParametrosUrl('idComp');
        self.codProforma = C.Base.obtenerParametrosUrl('idProf');
        console.log(self.codProforma);
        self.idTipoComp = C.Base.obtenerParametrosUrl('idTipoComp');
        self.$botonesAccion = $('#botonesAccion'); //el div se encuentra en el layout y se debe generar en tiempo de ejecución
        self.$btnaddCliente = $('#addCliente');
        self.ComprobanteTipo_id = 0;
        
        this.inicio();
    }
    NuevoComprobante.prototype = {
        funciones: {
            obtenerComprobante: function (comprobanteId) {
                var request = {};
                request.IdComprobante = comprobanteId;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Comprobante/ObtenerComprobanteById',
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
            llenarFormulario: function (self) {
                if (self.codComprobante == '0') {
                    var r1 = self.funciones.obtenerProforma(self.codProforma);
                    $.when(r1).done(function (response) {
                        console.log(response);
                        self.ComprobanteTipo_id = self.idTipoComp;
                        self.$cboTipoDocumento.val(self.idTipoComp);
                        self.$cboTipoDocumento.attr("Disabled", "Disabled");
                        self.funciones.cboTipoDocumentoTriggerProforma(self, '0');
                        var newOption = new Option(response.clienteNombre, response.clienteId, false, false);
                        self.$cboCliente.select2({
                            minimumInputLength: 3,
                            width: '100%',
                            language: "es",
                            theme: 'bootstrap4',
                            allowClear: false
                        });
                        self.$cboCliente.append(newOption).trigger('change');
                        self.$btnaddCliente.attr('Disabled', 'Disabled');
                        self.$txtRuc.val(response.clienteIdentidad);
                        self.$txtEmail.val(response.clienteCorreo);
                        self.$txtDireccion.val(response.clienteDireccion);
                        self.funciones.eliminarProductosVacios(self);
                        $.each(response.proformadetalle, function (index, item) {
                            self.funciones.agregarFila(self, item);
                        });
                        self.funciones.agregarFila(self, null);
                        self.funciones.validarCampos(self);
                    });
                }
                else {
                    var r1 = self.funciones.obtenerComprobante(self.codComprobante);
                    $.when(r1).done(function (response) {
                        console.log(response);
                        self.objComprobante = response;
                        self.ComprobanteTipo_id = response.comprobanteTipoId;
                        let r2 = self.funciones.obtenerTablaDato('comprobanteestado');
                        let estados = [];
                        $.when(r2).done(function (tdresponse) {
                            estados = tdresponse;

                            if (response.estado == 6) {
                                //self.txtEstado.val(response.estadoNombre);
                                self.$txtEstado.val('Anulado');
                                self.$txtEstado.css('color', 'red');
                                self.$botonesAccion.hide();
                                //self.divComboEstados.hide();
                                //self.divTxtEstado.show();
                            }
                            else if (response.estado == 1) {
                                self.$txtEstado.val('Pendiente');
                                self.$txtEstado.css('color', 'orange');
                                self.$botonesAccion.show();
                                //self.divComboEstados.hide();
                                //self.divTxtEstado.show();
                            }
                            else if (response.estado == 3) {
                                estados.length = 2; // solo dejar los dos primeros ( si cambia el orden en la BD se va a la MMMM)
                                self.funciones.llenaComboEstados(self, estados, '3');
                                self.$botonesAccion.hide();
                                //self.divComboEstados.show();
                                //self.divTxtEstado.hide();
                            }
                            else if (response.estado == 2 && response.comprobanteTipoId == '3') {
                                estados.length = 2;
                                self.funciones.llenaComboEstados(self, estados, '2');
                                self.$botonesAccion.hide();
                                //self.divComboEstados.show();
                                //self.divTxtEstado.hide();
                            }
                            else if (response.estado == 2) {
                                self.$txtEstado.val('Enviado a la Suite');
                                self.$txtEstado.css('color', 'orange');
                                self.$botonesAccion.hide();
                                //self.divComboEstados.hide();
                                self.$divAnulacion.hide();
                                //self.divTxtEstado.show();
                            }
                            else if (response.estado == 5) {
                                self.$txtEstado.val('Enviado Anular a Suite');
                                self.$txtEstado.css('color', 'orange');
                                self.$botonesAccion.hide();
                                self.divComboEstados.hide();
                                //self.divTxtEstado.show();
                            }
                            else {
                                estados.splice(2, 1);
                                self.funciones.llenaComboEstados(self, estados, response.estado + '');
                                self.$botonesAccion.hide();
                                self.divComboEstados.show();
                                self.divTxtEstado.hide();
                            }

                            self.$cboTipoDocumento.val(response.comprobanteTipoId);
                            self.$cboTipoDocumento.attr("Disabled", "Disabled");
                            self.funciones.cboTipoDocumentoTrigger(self, response.serie);
                            //self.txtNombreCliente.val(response.clienteNombre);
                            var newOption = new Option(response.clienteNombre, response.clienteId, false, false);
                            //self.$cboCliente.select2({
                            //    minimumInputLength: 3,
                            //    width: '100%',
                            //    language: "es",
                            //    theme: 'bootstrap4',
                            //    allowClear: false
                            //});
                            self.$cboCliente.append(newOption).trigger('change');
                            self.$btnaddCliente.attr('Disabled', 'Disabled');
                            self.$txtRuc.val(response.clienteIdentidad);
                            var fechaEm = response.fechaEmitido;
                            self.$txtFecha.val(fechaEm.substr(8, 2) + '/' + fechaEm.substr(5, 2) + '/' + fechaEm.substr(0, 4));
                            self.$txtFecha.attr('Disabled', 'Disabled');
                            //self.$cboSerie.val(response.serie);

                            self.$txtEmail.val(response.clienteCorreo);
                            self.$txtDireccion.val(response.clienteDireccion);
                            var fechaVen = response.fechaVencimiento;
                            self.$txtFechaVencimiento.val(fechaVen.substr(8, 2) + '/' + fechaVen.substr(5, 2) + '/' + fechaVen.substr(0, 4));
                            self.$txtFechaVencimiento.attr('Disabled', 'Disabled');
                            self.$cboMoneda.val(response.tipoMonedaId);
                            self.$cboMoneda.attr('Disabled', 'Disabled');
                            if (self.$cboMoneda.val() == 'US$') {
                                self.$divTipoCambio.show();
                            }
                            else {
                                self.$divTipoCambio.hide();
                            }
                            self.$txtTipoCambio.val(response.tipoCambio);

                            var tipoOpId = C.Base.PadLeft(response.tipoOperacionId, 4);
                            self.$cboTipoOperacion.val(C.Base.PadLeft(tipoOpId, 4));
                            //self.$cboTipoOperacion.attr('Disabled', 'Disabled');
                            if (tipoOpId == '1001') {
                                self.$divDetraccion.show();
                            }
                            else {
                                self.$divDetraccion.hide();
                            }
                            self.$cboDetraccion.val(response.detraccionId == null ? "0" : response.detraccionId);
                            self.$txtNroOC.val(response.nroOC);
                            //self.$txtNroOC.attr('Disabled', 'Disabled');
                            self.$cboTipoNota.val(response.tipoNotaId);
                            self.$txtSerieRef.val(response.serieRef);
                            self.$txtCorrelativoRef.val(response.correlativoRef);
                            self.$txtSubTotal.val(response.subTotal);
                            self.$txtIva.val(response.iva);
                            self.$txtIvaSubTotal.val(response.ivaTotal);
                            self.$txtTotal.val(response.total);
                            self.$txtGlosa.html(response.glosa);
                            self.$txtGlosa.attr('Disabled', 'Disabled');
                            if (response.comprobanteTipoId == '7' || response.comprobanteTipoId == '8') {
                                self.$divReferencia.show();
                                self.$divTipoOperacion.hide();
                            }
                            else if (response.comprobanteTipoId == '1') {
                                self.$trSubTotal.show();
                                self.$trIva.show();
                                self.$spIdentidad.html('RUC');
                                self.$txtRuc.attr('placeholder', 'RUC');
                                self.$divReferencia.hide();
                                self.$divTipoOperacion.show();
                            }
                            else if (response.comprobanteTipoId == '3') {
                                self.$trSubTotal.hide();
                                self.$trIva.hide();
                                self.$spIdentidad.html('DNI');
                                self.$txtRuc.attr('placeholder', 'DNI');
                                self.$divReferencia.hide();
                                self.$divTipoOperacion.show();
                            }
                            else {
                                self.$spIdentidad.html('DNI');
                                self.$txtRuc.attr('placeholder', 'DNI');
                                self.$divReferencia.remove();
                                self.$divTipoOperacion.hide();
                            }

                            if (response.tipoMonedaId == 'S/') self.$divTipoCambio.remove();
                            self.funciones.eliminarProductosVacios(self);
                            $.each(response.comprobantedetalle, function (index, item) {
                                self.funciones.agregarFila(self, item);
                            });
                            self.funciones.agregarFila(self, null);
                            //C.Interfaz.llenarGrilla(self.$grilla, response.comprobantedetalle);
                            self.funciones.validarCampos(self);
                        });
                    });
                }
            },
            validarCampos: function (self) {
                var v = self.ComprobanteTipo_id != 0 ? self.ComprobanteTipo_id : self.$cboTipoDocumento.val();

                self.$cboCliente.prop("disabled", false);
                self.$divReferencia.hide();


                if (v == '1') {
                    self.$cboCliente.prop("disabled", false);
                    self.$txtRuc.addClass('required');
                    self.$txtDireccion.addClass('required');
                    
                    //agrego esto
                    
                    self.$spClienteRequerido.show();
                    self.$spRucRequerido.show();
                    /***** agregué esto*****/
                    self.$spCorreoRequerido.show();
                    
                    self.$spDireccionRequerido.show();
                    self.$trSubTotal.show();
                    self.$trIva.show();
                    self.$spIdentidad.text('RUC');
                    self.$txtRuc.attr('placeholder', 'RUC');
                    
                    self.$divReferencia.hide();

                } else if (v == '0') {
                    self.$cboCliente.prop("disabled", true);
                    self.$spRucRequerido.hide();
                    self.$spIdentidad.text('DNI');
                    self.$txtRuc.attr('placeholder', 'DNI');
                }
                else if (v == '3') {
                    self.$cboCliente.prop("disabled", false);
                    self.$txtRuc.removeClass('required');
                    self.$txtDireccion.removeClass('required');
                    /***** agregué esto*****/
                    self.$spCorreoRequerido.hide();


                    self.$spClienteRequerido.hide();
                    self.$spRucRequerido.hide();
                    self.$spDireccionRequerido.hide();
                    self.$trSubTotal.hide();
                    self.$trIva.hide();
                    self.$spIdentidad.text('DNI');
                    self.$txtRuc.attr('placeholder', 'DNI');

                    self.$divReferencia.hide();
                }
                else if (v == '7' || v == '8') {
                    self.$divReferencia.show();
                }
            },
            obtenerSerieByTipoComprobante: function (ComprobanteTipoId) {
                var request = {};
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.ComprobanteTipoId = ComprobanteTipoId;
                request.Proforma = false;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Serie/ObtenerSerieByTipoComprobante',
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
            obtenerSerie: function (ComprobanteTipo_id, serie) {
                var request = {};
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.Serie = serie;
                request.ComprobanteTipoId = ComprobanteTipo_id;
                request.Proforma = false;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Serie/ObtenerSerie',
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
            obtenerClientes: function (self) {
                var request = {};
                request.Empresa_id = sessionStorage.getItem('empresa');
                self.$cboCliente.select2({
                    placeholder: 'Escriba el nombre del cliente',
                    minimumInputLength: 3,
                    width: '100%',
                    language: "es",
                    theme: 'bootstrap4',
                    allowClear: true,
                    ajax: {
                        url: C.Vars.rutaSERV + '/api/Cliente/ObtenerClientesByNombre',
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
                        processResults: function (data, page) {
                            self.clientes = data;
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
                    }
                });

            },
            limpiarDatosCliente: function (self) {
                self.$txtDireccion.val('');
                self.$txtEmail.val('');
                self.$txtRuc.val('');
            },
            limpiarTodo: function (self) {
                self.$txtDireccion.val('');
                self.$txtEmail.val('');
                self.$txtRuc.val('');
            },
            agregarFila: function (self, item) {
                var filaTemp = 0;
                $(".txtProducto").each(function () {

                    var tr = $(this).closest('tr');

                    if ($(this).attr('data-id') != '0') {
                        var comboProd = $('#row-' + $(this).attr('data-id') + '-item').select2('data')[0];

                        if (comboProd != undefined) {
                            filaTemp++;
                        }
                    }
                });
                self.fila = filaTemp;
                if (self.fila < 25) {
                    self.fila++;
                    self.dtComprobante.row.add([
                        '<div class="input-group">' +
                        '<select id="row-' + self.fila + '-item" data-id="' + self.fila + '" name="' + self.fila + '" class="form-control select2 txtProducto"></select>' +
                        '<span class="input-group-btn">' +
                        '<button type="button" data-toggle="dropdown" class="btn waves-effect waves-light btn-primary dropdown-toggle"><i class="fa fa-plus"></i></button>' +
                        '<ul role="menu" class="dropdown-menu">' +
                        '<li><a data-toggle="modal" data-target="#myModalEditProducto" class="btnNuevoProducto">Producto</a></li>' +
                        '<li><a data-toggle="modal" data-target="#myModalEditServicio" class="btnNuevoServicio">Servicio</a></li>' +
                        '</ul>' +
                        '</span>' +
                        '</div>',
                        '<input type="text" id="row-' + self.fila + '-cantidad" name="' + self.fila + '" value="" class="form-control txtCantidad" disabled>',
                        '<input type="text" id="row-' + self.fila + '-UDM" name="' + self.fila + '" value="" class="form-control" disabled>',
                        '<input type="text" id="row-' + self.fila + '-PU" name="' + self.fila + '" value="" class="form-control txtPrecioUnitario" disabled>',
                        '<input type="text" id="row-' + self.fila + '-PT" name="' + self.fila + '" value="" class="form-control txtTotal" disabled>'
                    ]).draw(true);

                    var request = {};
                    request.Empresa_id = sessionStorage.getItem('empresa');
                    $('#row-' + self.fila + '-item').select2({
                        placeholder: 'Escriba el nombre del Producto o Servicio',
                        minimumInputLength: 3,
                        width: '100%',
                        language: "es",
                        theme: 'bootstrap4',
                        allowClear: true,
                        ajax: {
                            url: C.Vars.rutaSERV + '/api/Producto/BuscarProductosYServicios',
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
                                    EmpresaId: sessionStorage.getItem('empresa')
                                }
                                return JSON.stringify(query);
                            },
                            processResults: function (data, page) {
                                //self.clientes = data;
                                var parsed = [];
                                try {
                                    parsed = _.map(data, function (item) {
                                        return {
                                            id: item.id,
                                            text: item.nombre.replace('[S/M] - ', ''),
                                            und: item.unidadMedidaId,
                                            compra: (parseFloat(item.precioCompra) / parseFloat(self.$txtTipoCambio.val())).toFixed(4),
                                            precio: (parseFloat(item.precio) / parseFloat(self.$txtTipoCambio.val())).toFixed(4),
                                            marca: item.marca,
                                            stock: item.stock,
                                            tipo: item.tipo
                                        };
                                    });
                                    //console.log(parsed);
                                } catch (e) { alert('Error en la búsqueda'); }

                                return {
                                    results: parsed
                                };
                            }
                        }
                    }).on('select2:select', function (e) {
                        e.preventDefault();
                        var data = e.params.data;
                        console.log(data);
                        var filaSel = $(e.currentTarget).attr('name');

                        $('#row-' + filaSel + '-UDM').val(data.und);
                        $('#row-' + filaSel + '-cantidad').removeAttr('disabled', false).val('1.00');
                        $('#row-' + filaSel + '-PU').removeAttr('disabled', false).val(data.precio);
                        $('#row-' + filaSel + '-PU').attr('title', 'PC: ' + self.$cboMoneda.val() + ' ' + data.compra);
                        if (data.stock == 0 && data.tipo == 1) {
                            alert('Esta agregando un producto que no contiene stock, de todas formas lo puede vender si es que se tratara de un error.\nLuego de esto es recomendable ajustar el Stock. ')
                        }
                        self.funciones.calcularComprobante(self);
                        self.funciones.eliminarProductosVacios(self);
                        self.funciones.agregarFila(self, null);
                    }).on('select2:unselecting', function (e) {
                        e.preventDefault();
                        self.funciones.calcularComprobante(self);
                        self.funciones.eliminarProductosVacios(self);
                        self.funciones.agregarFila(self, null);
                    });
                    $('b[role="presentation"]').hide();
                    if (item != null) {
                        var data = {
                            id: item.productoId,
                            text: item.productoNombre,
                            und: item.unidadMedidaId
                        };
                        var newOption = new Option(item.productoNombre, item.productoId, item.unidadMedidaId, false);

                        $('#row-' + self.fila + '-item').append(newOption).trigger('change');
                        var comboProd = $('#row-' + self.fila + '-item').select2('data')[0];
                        comboProd.und = item.unidadMedidaId;
                        comboProd.tipo = item.tipo;
                        comboProd.compra = (parseFloat(item.precioUnitarioCompra) / parseFloat(self.$txtTipoCambio.val())).toFixed(4);
                        comboProd.precio = (parseFloat(item.precioUnitario) / parseFloat(self.$txtTipoCambio.val())).toFixed(4);
                        $('#row-' + self.fila + '-item').trigger('change');
                        $('#row-' + self.fila + '-UDM').val(item.unidadMedidaId);
                        $('#row-' + self.fila + '-cantidad').removeAttr('disabled', false).val(item.cantidad);
                        $('#row-' + self.fila + '-PU').removeAttr('disabled', false).val(item.precioUnitario);
                        $('#row-' + self.fila + '-PU').attr('title', 'PC: ' + self.$cboMoneda.val() + ' ' + item.precioUnitarioCompra);
                        self.funciones.calcularComprobante(self);
                    }
                }
            },
            eliminarProductosVacios: function (self) {
                $(".txtProducto").each(function () {
                    var tr = $(this).closest('tr');
                    var comboProd = $('#row-' + $(this).attr('data-id') + '-item').select2('data')[0];
                    if ($(this).attr('data-id') != '0') {
                        if (comboProd === undefined) {
                            self.dtComprobante.row(tr).remove().draw();
                        }

                    }
                });
                
            },
            calcularComprobante: function (self) {
                var total = 0;
                $(".txtProducto").each(function () {
                    var tr = $(this).closest('tr');
                    if ($(this).attr('data-id') != '0') {
                        var comboProd = $('#row-' + $(this).attr('data-id') + '-item').select2('data')[0];

                        if (comboProd != undefined) {
                            var p = parseFloat(tr.find('.txtPrecioUnitario').val());
                            var c = parseFloat(tr.find('.txtCantidad').val());
                            var st = parseFloat(p * c);

                            tr.find('.txtTotal').val(st.toFixed(4));
                            total += st;
                        }
                        else {
                            tr.find('.txtTotal').val('');

                        }
                    }
                });

                total = (total).toFixed(4);
                var iva = ((parseFloat(self.$txtIva.val()) / 100) + 1).toFixed(4);
                var SubTotal = (total / iva).toFixed(4);
                var IvaSubTotal = (total - SubTotal).toFixed(4);

                
                self.$txtSubTotal.val(SubTotal);
                self.$txtIvaSubTotal.val(IvaSubTotal);
                self.$txtTotal.val(total);
            },
            validarComprobante: function (self) {
                var cantDetalle = 0;
                var pasaValidacion = true;
                var mensajes = '';

                //validación de cantidad de productos, por lo menos un item
                $(".txtProducto").each(function (index, obj) {
                    var idFila = obj.name;
                    var comboProd = $('#row-' + idFila + '-item').select2('data')[0];
                    if (comboProd != undefined) {
                        cantDetalle++;
                    }
                });
                if (cantDetalle == 0) {
                    pasaValidacion = false;
                    mensajes += '<li>El comprobante debe tener <b>un item</b> por lo menos.</li>';
                }

                //validación de seleccion de cliente, debe seleccionar al cliente
                var comboCliente = self.$cboCliente.select2('data')[0];
                if (comboCliente == undefined) {
                    pasaValidacion = false;
                    mensajes += '<li>Debe seleccionar al cliente.</li>';
                }

                //validacion de detracción
                if (self.conf.ctadetraccion == null && self.$cboTipoOperacion.val() == "1001" )
                {
                    pasaValidacion = false;
                    mensajes += 'Ud. no ha registrado su Cuenta para la Detracción <b><a href="' + C.Vars.rutaAPP + '/configuracion" target="_blank">Aqui</a></b> para actualizar.';
                }

                if (pasaValidacion) {
                    self.$divMsg.hide();
                }
                else {
                    self.$listaMsg.html(mensajes);

                    self.$divMsg.show();
                }

                return pasaValidacion;
            },
            registrarComprobante: function (self) {
                var comprobante = {};
                
                var r1 = self.funciones.obtenerTablaDatoByValue('Detraccion', self.$cboDetraccion.val());
                var r2 = self.funciones.obtenerSerie(self.$cboTipoDocumento.val(), self.$cboSerie.find("option:selected").text());
                $.when(r1, r2).done(function (detraccion, serie) {
                    var glosa_add = '';
                    if (self.$cboTipoDocumento.val() == 1) {
                        if (self.conf.ctadetraccion != "") {
                            glosa_add = '&#13;&#10; - CTA Detración: ' + self.conf.ctadetraccion;
                        }

                        if (self.conf.ctacorriente != "") {
                            glosa_add += ' &#13;&#10; - CTA/CTE: ' + self.conf.ctacorriente;
                        }
                    }

                    var total = 0;
                    var totalC = 0;
                    var detalle = [];
                    $(".txtProducto").each(function (index, obj) {
                        var idFila = obj.name;
                        var comboProd = $('#row-' + idFila + '-item').select2('data')[0];
                        if (comboProd != undefined) {
                            var producto = {
                                Tipo: comboProd.tipo,
                                ProductoId: comboProd.id,
                                ProductoNombre: comboProd.text,
                                UnidadMedidaId: comboProd.und,
                                Cantidad: $('#row-' + idFila + '-cantidad').val(),
                                PrecioUnitarioCompra: comboProd.compra,
                                PrecioTotalCompra: comboProd.compra * $('#row-' + idFila + '-cantidad').val(),
                                PrecioUnitario: $('#row-' + idFila + '-PU').val(),
                                PrecioTotal: $('#row-' + idFila + '-PU').val() * $('#row-' + idFila + '-cantidad').val(),
                                Ganancia: ($('#row-' + idFila + '-PU').val() - comboProd.compra) * $('#row-' + idFila + '-cantidad').val()
                            };
                            total += $('#row-' + idFila + '-PU').val() * $('#row-' + idFila + '-cantidad').val();
                            totalC += comboProd.compra * $('#row-' + idFila + '-cantidad').val();
                            detalle.push(producto);
                        }
                    });

                    var validarTotal = total * self.$txtTipoCambio.val();

                    if (validarTotal <= 400 && self.$cboTipoOperacion.val() == "1001") {
                        self.$listaMsg.html('La detracción aplica para montos de operación mayores a <b>S/. 400</b> .');
                        return;
                    }

                    var cabecera = {};
                    if (self.codComprobante != '') {
                        cabecera.Id = self.codComprobante * 1;
                    }

                    if (self.$cboDetraccion.val == "0") {
                        cabecera.Detraccion_Id = null;
                    }

                    //var iva = self.$cboTipoDocumento.val() == (3 || 5) ? self.$txtIva.val() : 0;
                    //var SubTotal = self.$cboTipoDocumento.val() == (3 || 5) ? total / (iva / 100 + 1) : 0;
                    //var IvaTotal = self.$cboTipoDocumento.val() == (3 || 5) ? total - SubTotal : 0;

                    var iva = self.$txtIva.val();
                    var SubTotal = total / (iva / 100 + 1);
                    var IvaTotal = total - SubTotal;

                    var cliente = self.$cboCliente.select2('data')[0];
                    cabecera.ComprobanteTipoId = self.$cboTipoDocumento.val();
                    cabecera.ClienteId = cliente.id;
                    cabecera.ClienteIdentidad = self.$txtRuc.val();
                    cabecera.ClienteNombre = cliente.text;
                    cabecera.ClienteDireccion = self.$txtDireccion.val();
                    cabecera.ClienteCorreo = self.$txtEmail.val();
                    cabecera.Estado = 1;
                    cabecera.FechaEmitido = self.$txtFecha.data('datepicker').getFormattedDate('yyyy-mm-dd');
                    var today = new Date();
                    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
                    cabecera.HoraEmision = time;
                    cabecera.Iva = iva;
                    cabecera.IvaTotal = IvaTotal;
                    cabecera.SubTotal = SubTotal;
                    cabecera.Total = total;
                    cabecera.TotalCompra = totalC;
                    cabecera.UsuarioId = sessionStorage.getItem('userId');
                    cabecera.Glosa = self.$txtGlosa.val() + glosa_add;
                    cabecera.Ganancia = (total - totalC) * self.$txtTipoCambio.val();
                    cabecera.FechaRegistro = moment(new Date()).format("YYYY-MM-DD");
                    cabecera.EmpresaId = sessionStorage.getItem('empresa');
                    cabecera.TipoMonedaId = self.$cboMoneda.val();
                    cabecera.TipoCambio = self.$txtTipoCambio.val();
                    cabecera.FechaVencimiento = self.$txtFechaVencimiento.data('datepicker').getFormattedDate('yyyy-mm-dd');
                    cabecera.NroOC = self.$txtNroOC.val();

                    if (self.$cboTipoOperacion.val() != '0') {
                        cabecera.TipoOperacionId = self.$cboTipoOperacion.val();
                        if (self.$cboDetraccion.val() != '0') {
                            cabecera.DetraccionId = self.$cboDetraccion.val();
                        }
                    }

                    cabecera.Serie = serie[0].serie1;
                    cabecera.Correlativo = serie[0].correlativo + 1;
                    cabecera.Mediopago = self.$cboMedioPago.val();
                    var comodinTipo = '99';

                    if (self.$cboTipoDocumento.val() == (7 || 8)) {
                        if (cabecera.Serie.substr(0, 2) == 'BC') { comodinTipo = '03'; }
                        else if (cabecera.Serie.substr(0, 2) == 'BD') { comodinTipo = '03'; }
                        else if (cabecera.Serie.substr(0, 2) == 'FC') { comodinTipo = '01'; }
                        else if (cabecera.Serie.substr(0, 2) == 'FD') { comodinTipo = '01'; }

                        cabecera.ComprobanteTipoRefId = comodinTipo;
                        cabecera.SerieRef = self.$txtSerieRef.val();
                        cabecera.CorrelativoRef = self.$txtCorrelativoRef.val();
                        cabecera.TipoNotaId = self.$cboTipoNota.val();
                    }

                    if (detraccion[0] != undefined) {
                        cabecera.ValorDetraccion = cabecera.Total * (detraccion[0].Value2 / 100);
                    }

                    comprobante = {
                        ComprobanteCabecera: cabecera,
                        ComprobanteDetalle: detalle
                    };
                    //console.log(comprobante);
                    var r1 = $.ajax({
                        url: C.Vars.rutaSERV + '/api/Comprobante/GuardarComprobante',
                        type: 'post',
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify(comprobante),
                        headers: C.Base.auntenticar(),
                        statusCode: {
                            401: function () {
                                win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                            }
                        }
                    });



                    $.when(r1).done(function (response) {
                        var idComprobanteResponse = response.idComprobante;
                        if (self.codProforma == '') {
                            C.Interfaz.enlace(C.Vars.rutaAPP + '/Comprobantes/Ver?idComp=' + idComprobanteResponse);
                        }
                        else {
                            var r1 = self.funciones.cerrarProforma(self.codProforma);
                            $.when(r1).done(function (response) {
                                C.Interfaz.enlace(C.Vars.rutaAPP + '/Comprobantes/Ver?idComp=' + idComprobanteResponse);
                            });
                        }
                    });
                });
            },
            llenaDatosinicio: function (self) {
                self.funciones.obtenerClientes(self);
                self.$txtEstado.val('Pendiente');
                var r1 = self.funciones.obtenerConfiguracion();
                $.when(r1).done(function (response) {
                    self.conf = response;
                    self.$txtIva.val(response.iva);
                });

                var r1 = self.funciones.obtenerTablaDato('comprobantetipo');
                self.$cboTipoDocumento.append('<option value="0">Sin Selección</option>');
                $.when(r1).done(function (response) {
                    $.each(response, function (index, value) {
                        self.$cboTipoDocumento.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                    });
                });

                self.$cboSerie.append('<option value="0">Sin Selección</option>');

                var r1 = self.funciones.obtenerTablaDato('moneda');
                $.when(r1).done(function (response) {
                    $.each(response, function (index, value) {
                        self.$cboMoneda.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                    });
                });

                var r1 = self.funciones.obtenerTablaDato('MedioPago');
                $.when(r1).done(function (response) {
                    $.each(response, function (index, value) {
                        self.$cboMedioPago.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                    });
                });

                self.$txtFecha.datepicker({
                    todayHighlight: true
                });

                var hoy = new Date();
                self.$txtFecha.datepicker('setDate', hoy);

                self.$txtFechaVencimiento.datepicker({
                    todayHighlight: true
                });
                
                hoy.setMonth(hoy.getMonth() + 1);
                self.$txtFechaVencimiento.datepicker('setDate', hoy);

                if (self.$cboMoneda.val() == 'US$') {
                    self.$divTipoCambio.show();
                }
                else {
                    self.$divTipoCambio.hide();
                }
                self.dtComprobante = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false
                });

                self.funciones.agregarFila(self, null);

                $('b[role="presentation"]').hide();

                self.$divTipoOperacion.hide();
                self.$divDetraccion.hide();
                
                if (self.codComprobante != '') {
                    $('.page-title').html('Editar Comprobante');
                    self.funciones.llenarFormulario(self);
                }
                else {
                    $('.page-title').html('Nuevo Comprobante');
                    self.funciones.validarCampos(self);
                }
                
            },
            limpiarControlesCliente: function (self) {
                self.$ddlTipoDocumentoClienteEdit.prop('selectedIndex', 0);
                self.$txtNombreClienteEdit.val('');
                self.$txtNroDocumentoEdit.val('');
                self.$txtDireccionClienteEdit.val('');
                self.$txtTelefonoPrincipalClienteEdit.val('');
                self.$txtTelefonoAdicionalClienteEdit.val('');
                self.$txtCorreoPrincipalClienteEdit.val('');
                self.$txtCorreoAdicional1ClienteEdit.val('');
                self.$txtCorreoAdicional2ClienteEdit.val('');
                self.$txtCorreoAdicional3ClienteEdit.val('');
                self.$txtCorreoAdicional4ClienteEdit.val('');
                self.$txtCorreoAdicional5ClienteEdit.val('');
            },
            nuevoCliente: function (self) {
                var request = {};
                request.Nombre = self.$txtNombreClienteEdit.val();
                request.TipoDocumentoId = self.$ddlTipoDocumentoClienteEdit.val();
                request.NroDocumento = self.$txtNroDocumentoEdit.val();
                request.Direccion = self.$txtDireccionClienteEdit.val();
                request.Telefono1 = self.$txtTelefonoPrincipalClienteEdit.val();
                request.Telefono2 = self.$txtTelefonoAdicionalClienteEdit.val();
                request.Correo = self.$txtCorreoPrincipalClienteEdit.val();
                request.Correo1 = self.$txtCorreoAdicional1ClienteEdit.val();
                request.Correo2 = self.$txtCorreoAdicional2ClienteEdit.val();
                request.Correo3 = self.$txtCorreoAdicional3ClienteEdit.val();
                request.Correo4 = self.$txtCorreoAdicional4ClienteEdit.val();
                request.Correo5 = self.$txtCorreoAdicional5ClienteEdit.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Cliente/NuevoCliente',
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
            validarformulario: function (self) {
                var respuesta = true;
                var controles = [
                    {
                        control: self.$ddlTipoDocumentoClienteEdit,
                        reglas: [
                            { regla: 'required' },
                        ],
                    },
                    {
                        control: self.$txtNroDocumentoEdit,
                        reglas: [
                            { regla: 'required' },
                        ],
                    },
                    {
                        control: self.$txtCorreoPrincipalClienteEdit,
                        reglas: [
                            { regla: 'required' },
                        ],
                    },
                    {
                        control: self.$txtDireccionClienteEdit,
                        reglas: [
                            { regla: 'required' },
                        ],
                    }
                ];

                respuesta = C.Base.validarFormulario(controles);
                return respuesta;
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
            validarProducto: function (self) {
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
            limpiarControlesProducto: function (self) {
                self.$txtNombreProductoEdit.val('');
                self.$txtMarcaProductoEdit.val('');
                self.$ddlUDMEdit.prop('selectedIndex', 0);
                self.$txtStockActualEdit.val('');
                self.$txtStockInicialEdit.val('');
                self.$txtStockMinimoEdit.val('');
                self.$txtCostoProductoEdit.val('');
                self.$txtPrecioVentaEdit.val('');
                self.$txtGanancia.val('');
                self.idProducto = 0;
            },
            nuevoServicio: function (self) {

                var request = {};
                request.Nombre = self.$txtNombreEdit.val();
                request.PrecioCompra = self.$txtCostoEdit.val();
                request.Precio = self.$txtPrecioEdit.val();
                request.UnidadMedidaId = 'NIU';
                request.EmpresaId = sessionStorage.getItem('empresa');
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Servicio/NuevoServicio',
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
            limpiarControlesServicio: function (self) {
                self.$txtCostoEdit.val('');
                self.$txtNombreEdit.val('');
                self.$txtPrecioEdit.val('');
                self.idServicio = 0;
            },
            validarServicio: function (self) {
                var respuesta = true;
                var controles = [
                    {
                        control: self.$txtNombreEdit,
                        reglas: [
                            { regla: 'required' },
                            //{ regla: 'minlength', minlength: 2 }
                        ],
                    },
                    {
                        control: self.$txtCostoEdit,
                        reglas: [
                            { regla: 'required' },
                            //{ regla: 'minlength', minlength: 2 }
                        ],
                    }, {
                        control: self.$txtPrecioEdit,
                        reglas: [
                            { regla: 'required' },
                            //{ regla: 'minlength', minlength: 2 }
                        ],
                    },
                ];

                respuesta = C.Base.validarFormulario(controles);
                return respuesta;
            },
            cboTipoDocumentoTrigger: function (self, serie) {
                if (self.$cboTipoDocumento.val() == '1' || self.$cboTipoDocumento.val() == '3') {
                    self.$divTipoOperacion.show();
                    self.$cboTipoOperacion.addClass('required');
                } else {
                    self.$divTipoOperacion.hide();
                    self.$cboTipoOperacion.removeClass('required');
                }

                var select = self.$cboTipoDocumento;
                var id = select.val();

                var $serie = self.$cboSerie;
                $serie.empty();

                var r1 = self.funciones.obtenerSerieByTipoComprobante(id);
                $.when(r1).done(function (response) {
                    $.each(response, function (index, value) {
                        if (value.serie1 == serie)
                        self.$cboSerie.append('<option value="' + value.id + ' selected">' + value.serie1 + '</option>');
                    });
                });
                self.$cboSerie.attr('Disabled', 'Disabled');

                //self.funciones.validarCampos(self);
            },
            cboTipoDocumentoTriggerProforma: function (self, serie) {
                if (self.$cboTipoDocumento.val() == '1' || self.$cboTipoDocumento.val() == '3') {
                    self.$divTipoOperacion.show();
                    self.$cboTipoOperacion.addClass('required');
                } else {
                    self.$divTipoOperacion.hide();
                    self.$cboTipoOperacion.removeClass('required');
                }

                var select = self.$cboTipoDocumento;
                var id = select.val();

                var $serie = self.$cboSerie;
                $serie.empty();

                var r1 = self.funciones.obtenerSerieByTipoComprobante(id);
                $.when(r1).done(function (response) {
                    self.$cboSerie.append('<option value="0">Sin Selección</option>');
                    $.each(response, function (index, value) {
                        self.$cboSerie.append('<option value="' + value.id + ' selected">' + value.serie1 + '</option>');
                    });
                });
                //self.$cboSerie.attr('Disabled', 'Disabled');

                //self.funciones.validarCampos(self);
            },
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

        },
        eventos: {
            botones: function (self) {
                $el.on('select2:select', self.cboCliente, function (e) {
                    e.preventDefault();
                    var id = $(e.currentTarget).val() * 1;
                    var seleccionado = _.where(self.clientes, { id: id });
                    console.log(seleccionado[0]);
                    self.$txtRuc.val(seleccionado[0].nroDocumento);
                    self.$txtEmail.val(seleccionado[0].correo);
                    self.$txtDireccion.val(seleccionado[0].direccion);

                });

                $el.on('select2:unselecting', self.cboCliente, function (e) {
                    e.preventDefault();
                    self.funciones.limpiarDatosCliente(self);
                    self.$cboCliente.val(null).trigger("change");
                    self.$cboCliente.find('option').remove();
                });

                $el.on('keyup', '.txtCantidad,.txtPrecioUnitario', function (e) {
                    e.preventDefault();
                    if (e.which == 13) return false;
                    var n = $(this).val();
                    if (n >= 0) {
                        self.funciones.calcularComprobante(self);
                    }
                    else {
                        $(this).val('');
                    }
                });

                $el.on('click', self.btnGuardarComprobante, function (e) {
                    e.preventDefault();
                    if (self.funciones.validarComprobante(self)) {
                        self.funciones.registrarComprobante(self);
                    }

                });

                $el.on('change', self.cboTipoDocumento, function (e) {

                    e.preventDefault();
                    if (self.$cboTipoDocumento.val() == '1' || self.$cboTipoDocumento.val() == '3') {
                        self.$divTipoOperacion.show();
                        self.$cboTipoOperacion.addClass('required');
                    } else {
                        self.$divTipoOperacion.hide();
                        self.$cboTipoOperacion.removeClass('required');
                    }

                    var select = self.$cboTipoDocumento;
                    var id = select.val();

                    var $serie = self.$cboSerie;
                    $serie.empty();

                    var r1 = self.funciones.obtenerSerieByTipoComprobante(id);
                    self.$cboSerie.append('<option value="0">Sin Selección</option>');
                    $.when(r1).done(function (response) {
                        $.each(response, function (index, value) {
                            self.$cboSerie.append('<option value="' + value.id + '">' + value.serie1 + '</option>');
                        });
                    });

                    self.funciones.validarCampos(self);
                });

                $el.on('change', self.cboTipoOperacion, function (e) {
                    e.preventDefault();
                    if ($(this).val() == '1001') {
                        self.$divDetraccion.show();
                        self.$cboDetraccion.addClass('required');

                    } else {
                        self.$divDetraccion.hide();
                        self.$cboDetraccion.removeClass('required');
                    }

                });

                $el.on('change', self.cboMoneda, function (e) {
                    e.preventDefault();
                    if ($(e.currentTarget).val() == 'US$') {
                        self.$divTipoCambio.show();
                        self.$spMoneda.html('US$');
                    }
                    else {
                        self.$spMoneda.html('S/');
                        self.$divTipoCambio.hide();
                        self.$txtTipoCambio.val('1.0');
                    }
                    self.dtComprobante.clear().draw();
                    self.funciones.agregarFila(self, null);
                    self.funciones.calcularComprobante(self);

                });

                $el.on('change', self.cboSerie, function (e) {
                    e.preventDefault();
                    var select = $(this);
                    var serie = select.val();

                    var v = self.ComprobanteTipo_id != 0 ? self.ComprobanteTipo_id : self.$cboTipoDocumento.val();

                    var $comprobante = self.$cboTipoDocumento;

                    if (v == '7' || v == '8') {
                        self.$divReferencia.show();
                    }

                    var id = $comprobante.val();

                    if (id == 7 || id == 8) {
                        self.$cboTipoNota.empty();
                        var tipoNotaTexto = id == 7 ? 'tiponotacredito' : 'tiponotadebito';
                        var r1 = self.funciones.obtenerTablaDato(tipoNotaTexto);
                        self.$cboTipoNota.append('<option value="0" selected="selected">Sin Selección</option>');
                        $.when(r1).done(function (response) {
                            $.each(response, function (index, value) {
                                self.$cboTipoNota.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                            });
                        });

                        if (serie.substring(0, 1) == 'B') {
                            self.$cboCliente.removeClass('required');
                            self.$txtRuc.removeClass('required');
                            self.$txtDireccion.removeClass('required');
                            /***** agregué esto*****/
                            self.$spCorreoRequerido.hide();

                            self.$spClienteRequerido.hide();
                            self.$spRucRequerido.hide();
                            self.$spDireccionRequerido.hide();
                            self.$trSubTotal.hide();
                            self.$trIva.hide();
                            self.$spIdentidad.text('DNI');
                            self.$txtRuc.attr('placeholder', 'DNI')

                            self.$cboTipoNota.addClass('required');
                            self.$txtSerieRef.addClass('required');
                            self.$txtCorrelativoRef.addClass('required');
                        }
                        else if (serie.substring(0, 1) == 'F') {
                            self.$cboCliente.addClass('required');
                            self.$txtRuc.addClass('required');
                            self.$txtDireccion.addClass('required');

                            //agrego esto
                            self.$spClienteRequerido.show();
                            self.$spRucRequerido.show();
                            /***** agregué esto*****/
                            self.$spCorreoRequerido.show();

                            self.$spDireccionRequerido.show();
                            self.$trSubTotal.show();
                            self.$trIva.show();
                            self.$spIdentidad.text('RUC');
                            self.$txtRuc.attr('placeholder', 'RUC');
                        }
                    }

                });

                $el.on('hidden.bs.modal', self.$modal, function (e) {
                    self.funciones.limpiarControlesCliente(self);
                });

                $el.on('click', self.btnGuardarCliente, function (e) {
                    e.preventDefault();
                    var r1 = null;
                    if (self.funciones.validarformulario(self)) {
                        r1 = self.funciones.nuevoCliente(self);

                        $.when(r1).done(function (response) {
                            alert(response.mensaje);
                            if (!response.error) {
                                //self.funciones.buscarClientes(self);
                                self.$modal.modal('hide');
                            }
                        });
                    }
                });

                $el.on('change', self.ddlTipoDocumentoClienteEdit, function (e) {
                    e.preventDefault();
                    self.$txtNroDocumentoEdit.val('');
                    let tipodoc = self.$ddlTipoDocumentoClienteEdit.val();
                    switch (tipodoc) {
                        case '6':
                            self.$txtNroDocumentoEdit.attr('maxlength', '11');
                            break;
                        case '1':
                            self.$txtNroDocumentoEdit.attr('maxlength', '8');
                            break;
                        case '4':
                            self.$txtNroDocumentoEdit.attr('maxlength', '9');
                            break;
                        case '7':
                            self.$txtNroDocumentoEdit.attr('maxlength', '9');
                            break;
                        default:
                            self.$txtNroDocumentoEdit.attr('maxlength', '11');
                    }
                });

                $el.on('click', self.btnNuevoProducto, function (e) {
                    e.preventDefault();
                    self.$divStockActual.hide();
                    self.$divStockInicial.show();
                    self.$divStockMinimo.hide();
                    self.$divGananciaProducto.hide();
                    self.$helperPrecioVenta.hide();
                    self.$ddlUDMEdit.removeAttr("disabled");
                    self.$txtStockActualEdit.removeAttr("disabled");
                });

                $el.on('click', self.btnGuardarProducto, function (e) {
                    e.preventDefault();
                    var r1 = null;
                    if (self.funciones.validarProducto(self))    // test for validity
                    {
                        r1 = self.funciones.nuevoProducto(self);

                        $.when(r1).done(function (response) {
                            if (!response) {
                                alert('Error');
                            }
                            self.$modalProducto.modal('hide');
                        });
                    }
                });

                $el.on('hidden.bs.modal', self.$modalProducto, function (e) {
                    self.funciones.limpiarControlesProducto(self);
                });

                $el.on('click', self.btnNuevoServicio, function (e) {
                    e.preventDefault();
                    self.$divGanancia.hide();
                    self.$helperPorcentaje.hide();
                });

                $el.on('click', self.btnGuardarServicio, function (e) {
                    e.preventDefault();
                    var r1 = null;
                    if (self.funciones.validarServicio(self))    // test for validity
                    {
                        r1 = self.funciones.nuevoServicio(self);

                        $.when(r1).done(function (response) {
                            if (!response) {
                                alert('Error');
                            }
                            self.$modalServicio.modal('hide');
                        });
                    }
                });

                $el.on('hidden.bs.modal', self.$modalServicio, function (e) {
                    self.funciones.limpiarControlesServicio(self);
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
        window.addEventListener("load", new NuevoComprobante, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new NuevoComprobante);
    } else {
        window.onload = new NuevoComprobante;
    }

})(APP, window, jQuery, _);