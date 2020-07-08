var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var NuevaProforma = function () {
        var self = this;

        this.codProforma = C.Base.obtenerParametrosUrl('idProf');
        this.btnGuardar = '#btnGuardarConfig';
        this.$cboCliente = $('#cboCliente');
        this.cboCliente = '#cboCliente';
        this.$txtRuc = $('#txtRuc');
        this.$txtFecha = $('#txtFecha');
        this.$txtEmail = $('#txtEmail');
        this.$txtDireccion = $('#txtDireccion');
        this.$cboMoneda = $('#cboMoneda');
        this.cboMoneda = '#cboMoneda';
        this.$txtTipoCambio = $('#txtTipoCambio');
        this.$divTipoCambio = $('.divTipoCambio');
        this.clientes = [];
        this.dtProforma = {};
        this.$grilla = $('#grilla');
        this.btnGuardarProforma = '#btnGuardarProforma';
        this.$divMsg = $('#divMsg');
        this.$listaMsg = $('#listaMsg');
        this.fila = 0;
        this.ComprobanteTipo_id = 1;

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
        self.proforma = {};

        self.$btnaddCliente = $('#addCliente');

        this.inicio();
    }
    NuevaProforma.prototype = {
        funciones: {
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
                var r1 = self.funciones.obtenerProforma(self.codProforma);
                $.when(r1).done(function (response) {
                    console.log(response);
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
                    self.$cboCliente.prop("disabled", false);
                    self.$txtRuc.val(response.clienteIdentidad);
                    self.$txtEmail.val(response.clienteCorreo);
                    self.$txtDireccion.val(response.clienteDireccion);
                    self.$txtFecha.attr('disabled', 'disabled');
                    self.$cboMoneda.prop("disabled", true);
                    self.funciones.eliminarProductosVacios(self);
                    $.each(response.proformadetalle, function (index, item) {
                        self.funciones.agregarFila(self, item);
                    });
                    self.funciones.agregarFila(self, null);
                });
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
            obtenerSerie: function (ComprobanteTipo_id) {
                var request = {};
                request.EmpresaId = sessionStorage.getItem('empresa');
                request.Serie = 'PROF';
                request.ComprobanteTipoId = ComprobanteTipo_id;
                request.Proforma = true;
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
            obtenerMonedas: function () {
                var request = {};
                request.Relacion = 'moneda';
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
                    self.dtProforma.row.add([
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
                        self.funciones.calcularComprobante();
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
                            self.dtProforma.row(tr).remove().draw();
                        }

                    }
                })
            },
            calcularComprobante: function () {
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

                    } else {
                        //tr.find('.hdProducto_id').val('');
                        //tr.find('.hdPrecioUnitarioCompra').val('');
                        //tr.find('.txtProducto').val('').attr('data-name', '');
                        //tr.find('.txtCantidad').val('').attr('readonly', true);
                        //tr.find('.txtUnidad').val('');
                        //tr.find('.txtPrecioUnitario').val('').attr('readonly', true);
                        //tr.find('.txtPrecioUnitario').attr('title', '');
                        //tr.find('.txtPrecioUnitario').attr('data-compra', '0.0000');
                        //tr.find('.txtTotal').val('');
                        //
                        //tr.find('.btnProductoQuitar').attr('disabled', true);
                    }
                })

                total = (total).toFixed(4);
                var iva = ((parseFloat($("#txtIva").val()) / 100) + 1).toFixed(4);
                var SubTotal = (total / iva).toFixed(4);
                var IvaSubTotal = (total - SubTotal).toFixed(4);

                //$("#txtSubTotal").val(SubTotal);
                //$("#txtIvaSubTotal").val(IvaSubTotal);
                $("#txtTotal").val(total);
            },
            validarProforma: function (self) {
                var cantDetalle = 0;
                var pasaValidacion = true;
                var mensajes = '';
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

                var comboCliente = self.$cboCliente.select2('data')[0];
                if (comboCliente == undefined) {
                    pasaValidacion = false;
                    mensajes += '<li>Debe seleccionar al cliente.</li>';
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
            guardarProforma: function (self) {
                var proforma = {};
                var r1 = self.funciones.obtenerSerie(self.ComprobanteTipo_id);
                $.when(r1).done(function (serie) {
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


                    var cabecera = {};
                    var cliente = self.$cboCliente.select2('data')[0];
                    if (self.codProforma != '') {
                        cabecera.ComprobanteId = self.codProforma;
                    }
                    cabecera.ComprobanteTipoId = self.ComprobanteTipo_id;
                    cabecera.ClienteId = cliente.id;
                    cabecera.ClienteIdentidad = self.$txtRuc.val();
                    cabecera.ClienteNombre = cliente.text;
                    cabecera.ClienteDireccion = self.$txtDireccion.val();
                    cabecera.ClienteCorreo = self.$txtEmail.val();
                    cabecera.Estado = 1;
                    cabecera.FechaEmitido = self.$txtFecha.data('datepicker').getFormattedDate('yyyy-mm-dd');
                    cabecera.Iva = 0;
                    cabecera.IvaTotal = 0;
                    cabecera.SubTotal = 0;
                    cabecera.Total = total;
                    cabecera.TotalCompra = totalC;
                    cabecera.UsuarioId = sessionStorage.getItem('userId');
                    cabecera.Glosa = '';
                    cabecera.Ganancia = (total - totalC) * self.$txtTipoCambio.val();
                    cabecera.FechaRegistro = moment(new Date()).format("YYYY-MM-DD");
                    cabecera.EmpresaId = sessionStorage.getItem('empresa');
                    cabecera.TipoMonedaId = self.$cboMoneda.val();
                    cabecera.TipoCambio = self.$txtTipoCambio.val();
                    cabecera.Serie = serie.serie1;
                    cabecera.Correlativo = serie.correlativo + 1;
                    proforma = {
                        ProformaCabecera: cabecera,
                        ProformaDetalle: detalle
                    };
                    var r1 = $.ajax({
                        url: C.Vars.rutaSERV + '/api/Proforma/GuardarProforma',
                        type: 'post',
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(proforma),
                        headers: C.Base.auntenticar(),
                        statusCode: {
                            401: function () {
                                win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                            }
                        }
                    });

                    $.when(r1).done(function (response) {
                        C.Interfaz.enlace(C.Vars.rutaAPP + '/Proformas/Ver?idProf=' + response.idProforma);
                    });
                });
            },
            llenaDatosinicio: function (self) {
                self.funciones.obtenerClientes(self);
                var r1 = self.funciones.obtenerMonedas();
                $.when(r1).done(function (response) {
                    $.each(response, function (index, value) {
                        self.$cboMoneda.append('<option value="' + value.value + '">' + value.nombre + '</option>');
                    });
                });
                self.$cboMoneda.select2({
                    theme: 'bootstrap4',
                    language: "es",
                    minimumResultsForSearch: -1
                });
                self.$txtFecha.datepicker({
                    todayHighlight: true
                });

                self.$txtFecha.datepicker('setDate', new Date());
                if (self.$cboMoneda.val() == 'US$') {
                    self.$divTipoCambio.show();
                }
                else {
                    self.$divTipoCambio.hide();
                }
                self.dtProforma = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false
                });

                if (self.codProforma != '') {
                    self.funciones.llenarFormulario(self);
                }
                self.funciones.agregarFila(self);

                $('b[role="presentation"]').hide();
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
                self.$txtGananciaProducto.val('');
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
            }
        },
        eventos: {
            botones: function (self) {
                $el.on('select2:select', self.cboMoneda, function (e) {
                    e.preventDefault();

                    if ($(e.currentTarget).val() == 'US$') {
                        self.$divTipoCambio.show();
                    }
                    else {
                        self.$divTipoCambio.hide();
                    }

                });

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
                        self.funciones.calcularComprobante();
                    }
                    else {
                        $(this).val('');
                    }
                });

                $el.on('click', self.btnGuardarProforma, function (e) {
                    e.preventDefault();
                    if (self.funciones.validarProforma(self)) {
                        self.funciones.guardarProforma(self);
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
                    self.$divGanancia.hide();
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
        window.addEventListener("load", new NuevaProforma, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new NuevaProforma);
    } else {
        window.onload = new NuevaProforma;
    }

})(APP, window, jQuery, _);