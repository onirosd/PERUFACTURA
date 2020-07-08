var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Servicio = function () {
        var self = this;
        this.$txtBuscarNombre = $('#txtBuscarNombre');
        this.$txtNombreEdit = $('#txtNombreEdit');
        this.$txtCostoEdit = $('#txtCostoEdit');
        this.$txtPrecioEdit = $('#txtPrecioEdit');
        this.$btnBuscar = $('#btnBuscar');
        this.btnBuscar = '#btnBuscar';
        this.btnGuardar = '#btnEditServicio';
        this.btnNuevo = '#btnNuevo';
        this.$grilla = $("#grilla");
        this.$divGrilla = $("#divGrilla");
        this.accion = 'agregar';
        this.modal = '#myModalEditServicio';
        this.$modal = $('#myModalEditServicio');
        this.$helperPorcentaje = $('#helperPorcentaje');
        this.$divGanancia = $('#divGanancia');
        this.$txtGananciaServicio = $('#txtGananciaServicio');
        this.idServicio = 0;
        this.dtServicio = {};

        this.btnCargaMasiva = '#btnCargaMasiva';
        this.$fileExcel = $('#fileExcel');
        this.fileExcel = '#fileExcel';

        this.inicio();
    }
    Servicio.prototype = {
        funciones: {
            buscarServicios: function (self) {
                C.Interfaz.bloquearDiv(self.$divGrilla);
                var r1 = self.funciones.obtenerServicios(self);
                $.when(r1).done(function (response) {
                    C.Interfaz.llenarGrilla(self.$grilla, response);
                    C.Interfaz.desbloquearDiv(self.$divGrilla);
                });
            },
            obtenerServicios: function (self) {
                var request = {};
                request.Empresa_id = sessionStorage.getItem('empresa');;
                request.Nombre = self.$txtBuscarNombre.val();
                console.log(request);

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Servicio/ObtenerServicios',
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
            editarServicio: function (self) {
                var request = {};
                request.Id = self.idServicio;
                request.Nombre = self.$txtNombreEdit.val();
                request.PrecioCompra = self.$txtCostoEdit.val();
                request.Precio = self.$txtPrecioEdit.val();
                request.EmpresaId = sessionStorage.getItem('empresa');
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Servicio/EditarServicio',
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
            eliminarServicio: function (self, obj) {
                var request = {};
                request.Id = obj.id;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Servicio/EliminarServicio',
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
            obtenerDatosExcel: function (self, data) {
                var servicios = [];
                for (var i = 1; i < data.length; i++) {
                    var obj = {
                        Nombre: data[i][0],
                        PrecioCompra: data[i][1],
                        Precio: data[i][2],
                        UnidadMedidaId: 'NIU',
                        EmpresaId: sessionStorage.getItem('empresa')
                    };
                    servicios.push(obj);
                }
                var request = {
                    Servicios: servicios
                };
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Cliente/GuardarMasivoServicios',
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
                    self.funciones.buscarClientes(self);
                    alert(response.mensaje);
                    self.$modal.modal('hide');
                });
                
            },
            llenaDatosinicio: function (self) {
                self.dtServicio = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    columns: [
                        { title: "Id", data: 'id', visible: false },
                        { title: "Nombre", data: 'nombre', width: "70%" },
                        { title: "Precio", data: 'precio' }
                    ],
                    columnDefs: [{
                        targets: 3,
                        data: null,
                        className: 'dt-center',
                        defaultContent: '<a href="#" title="Editar" class="editar"><i class="fa fa-fw fa-edit"></i></a>' +
                         '<a href="#" title="Eliminar" class="eliminar"><i class="fa fa-fw fa-remove"></i></a>'
                    }]
                });
            },
            limpiarControlesServicio: function (self) {
                self.$txtCostoEdit.val('');
                self.$txtNombreEdit.val('');
                self.$txtPrecioEdit.val('');
                self.idServicio = 0;
            },
            obtenerById: function (self, obj) {
                self.idServicio = obj.id;
                self.$txtNombreEdit.val(obj.nombre);
                self.$txtPrecioEdit.val(obj.precio);
                self.$txtCostoEdit.val(obj.precioCompra);
                var ganancia = (obj.precio - obj.precioCompra) * 100 / obj.precioCompra;
                var mensaje = 'Existe un margen de ganancia aproximadamente del ' + ganancia + ' %';
                self.$txtGananciaServicio.val(obj.precio - obj.precioCompra);
                self.$helperPorcentaje.html(mensaje);
            },
            
            validarformulario: function (self) {
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
                $el.on('click', self.btnBuscar, function (e) {
                    e.preventDefault();
                    self.funciones.buscarServicios(self);
                });

                $el.on('click', self.btnNuevo, function (e) {
                    e.preventDefault();
                    self.accion = 'agregar';
                    self.$divGanancia.hide();
                    self.$helperPorcentaje.hide();
                });

                $el.on('click', self.btnGuardar, function (e) {
                    e.preventDefault();
                    var r1 = null;
                    if (self.funciones.validarformulario(self))    // test for validity
                    {
                        if (self.accion == 'agregar') {
                            r1 = self.funciones.nuevoServicio(self);
                        }
                        else {
                            r1 = self.funciones.editarServicio(self);
                        }

                        $.when(r1).done(function (response) {
                            if (response) {
                                self.funciones.buscarServicios(self);
                            }
                            else {
                                alert('Error');
                            }
                            self.$modal.modal('hide');
                        });
                    }
                });
                $el.on('hidden.bs.modal', self.$modal, function (e) {
                    self.funciones.limpiarControlesServicio(self);
                });
                $el.on('click', '.editar', function () {
                    self.accion = 'editar';
                    var data = self.dtServicio.row($(this).parents('tr')).data();
                    self.funciones.obtenerById(self, data);
                    self.$divGanancia.show();
                    self.$helperPorcentaje.show();
                    self.$modal.modal('show');
                });

                $el.on('click', '.eliminar', function () {
                    var data = self.dtServicio.row($(this).parents('tr')).data();
                    var r1 = self.funciones.eliminarServicio(self, data);
                    $.when(r1).done(function (response) {
                        if (response.error) {
                            alert(response.mensaje);
                        }
                        else {
                            self.funciones.buscarServicios(self);
                        }
                    });
                });

                $el.on('click', self.btnCargaMasiva, function (e) {

                    e.preventDefault();
                    self.$fileExcel.trigger('click');
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
                self.funciones.buscarServicios(self);
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new Servicio, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Servicio);
    } else {
        window.onload = new Servicio;
    }

})(APP, window, jQuery, _);