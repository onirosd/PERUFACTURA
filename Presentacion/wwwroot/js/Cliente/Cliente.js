var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Cliente = function () {
        var self = this;
        this.$txtBuscarNombre = $('#txtBuscarNombre');
        this.$txtBuscarNroDocumento = $('#txtBuscarNroDocumento');
        this.$btnBuscar = $('#btnBuscar');
        this.$btnBuscarClienteEdit = $('#btnBuscarClienteEdit');
        this.btnBuscarClienteEdit = '#btnBuscarClienteEdit';
        this.btnBuscar = '#btnBuscar';
        this.btnGuardar = '#btnEditCliente';
        this.btnNuevo = '#btnNuevo';
        this.btnCargaMasiva = '#btnCargaMasiva';
        this.$grilla = $("#grilla");
        this.$divGrilla = $("#divGrilla");
        this.accion = 'agregar';
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
        this.idCliente = 0;
        this.dtCliente = {};
        this.$fileExcel = $('#fileExcel');
        this.fileExcel = '#fileExcel';

        this.inicio();
    }
    Cliente.prototype = {
        funciones: {
            buscarClientes: function (self) {
                C.Interfaz.bloquearDiv(self.$divGrilla);
                var r1 = self.funciones.obtenerClientes(self);
                $.when(r1).done(function (response) {
                    console.log(response);
                    self.funciones.llenarGrilla(self, response);
                    C.Interfaz.desbloquearDiv(self.$divGrilla);
                });
            },
            obtenerClientes: function (self) {
                var request = {};
                request.Empresa_id = sessionStorage.getItem('empresa');;
                request.Nombre = self.$txtBuscarNombre.val();
                request.NroDocumento = self.$txtBuscarNroDocumento.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Cliente/ObtenerClientes',
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
            editarCliente: function (self) {
                var request = {};
                request.Id = self.idCliente;
                request.TipoDocumentoId = self.$ddlTipoDocumentoClienteEdit.val();
                request.NroDocumento = self.$txtNroDocumentoEdit.val();
                request.Nombre = self.$txtNombreClienteEdit.val();
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
                    url: C.Vars.rutaSERV + '/api/Cliente/EditarCliente',
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
            eliminarCliente: function (self, obj) {
                var request = {};
                request.Id = obj.id;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Cliente/EliminarCliente',
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
            llenarGrilla: function (self, response) {
                self.$grilla.dataTable().fnClearTable();
                if (response.length != 0) {
                    self.$grilla.dataTable().fnAddData(response);
                }
            },
            llenaDatosinicio: function (self) {
                self.dtCliente = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    columns: [
                        { title: 'Id', data: 'id', visible: false },
                        { title: 'Nombre', data: 'nombre', width: "40%" },
                        { title: 'Identidad', data: 'nroDocumento' },
                        { title: 'Correo', data: 'correo' },
                        { title: 'T.Principal', data: 'telefono1' },
                        { title: 'T.Adicional', data: 'telefono2' }
                    ],
                    "columnDefs": [{
                        'targets': 6,
                        'data': null,
                        'className': 'dt-center',
                        'defaultContent': '<a href="#" title="Editar" class="editarCliente"><i class="fa fa-fw fa-edit"></i></a>' +
                            '<a href="#" title="Eliminar" class="eliminarCliente"><i class="fa fa-fw fa-remove"></i></a>'
                    }]
                });
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
                self.idCliente = 0;
            },
            obtenerById: function (self, obj) {
                console.log(obj);
                self.idCliente = obj.id;
                self.$txtNombreClienteEdit.val(obj.nombre);
                self.$ddlTipoDocumentoClienteEdit.val(obj.tipoDocumentoId);
                self.$txtNroDocumentoEdit.val(obj.nroDocumento);
                self.$txtDireccionClienteEdit.val(obj.direccion);
                self.$txtTelefonoPrincipalClienteEdit.val(obj.telefono1);
                self.$txtTelefonoAdicionalClienteEdit.val(obj.telefono2);
                self.$txtCorreoPrincipalClienteEdit.val(obj.correo);
                self.$txtCorreoAdicional1ClienteEdit.val(obj.correo1);
                self.$txtCorreoAdicional2ClienteEdit.val(obj.correo2);
                self.$txtCorreoAdicional3ClienteEdit.val(obj.correo3);
                self.$txtCorreoAdicional4ClienteEdit.val(obj.correo4);
                self.$txtCorreoAdicional5ClienteEdit.val(obj.correo5);
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
            obtenerDatosExcel: function (self, data) {
                var clientes = [];
                for (var i = 1; i < data.length; i++) {
                    var obj = {
                        TipoDocumentoId: data[i][0],
                        NroDocumento: data[i][1],
                        Nombre: data[i][2],
                        Direccion: data[i][3],
                        Telefono1: data[i][4],
                        Telefono2: data[i][5],
                        Correo: data[i][6],
                        Correo1: data[i][7],
                        Correo2: data[i][8],
                        Correo3: data[i][9],
                        Correo4: data[i][10],
                        EmpresaId: sessionStorage.getItem('empresa')
                    };
                    clientes.push(obj);
                }
                var request = {
                    Clientes: clientes
                };
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Cliente/GuardarMasivoClientes',
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
            obtenerDataClienteSunat: function (self, nroDocumento) {
                var obj = {};
                obj.Ruc = nroDocumento;
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/DataRuc/ObtenerClienteSunat',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(obj),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });

                return r1;
            }

        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnBuscar, function (e) {
                    e.preventDefault();
                    self.funciones.buscarClientes(self);
                });

                $el.on('click', self.btnNuevo, function (e) {
                    e.preventDefault();
                    self.accion = 'agregar';
                    self.$ddlTipoDocumentoClienteEdit.removeAttr("disabled");
                    self.$txtNroDocumentoEdit.removeAttr("disabled");
                });

                $el.on('click', self.btnGuardar, function (e) {
                    e.preventDefault();
                    var r1 = null;
                    if (self.funciones.validarformulario(self))
                    {
                        if (self.accion == 'agregar') {
                            r1 = self.funciones.nuevoCliente(self);
                        }
                        else {
                            r1 = self.funciones.editarCliente(self);
                        }

                        $.when(r1).done(function (response) {
                            alert(response.mensaje);
                            if (!response.error) {
                                self.funciones.buscarClientes(self);
                                self.$modal.modal('hide');
                            }
                        });
                    }
                });
                $el.on('hidden.bs.modal', self.$modal, function (e) {
                    self.funciones.limpiarControlesCliente(self);
                });
                $el.on('click', '.editarCliente', function () {
                    self.accion = 'editar';
                    var data = self.dtCliente.row($(this).parents('tr')).data();
                    self.funciones.obtenerById(self, data);
                    self.$ddlTipoDocumentoClienteEdit.attr("disabled", "disabled");
                    self.$txtNroDocumentoEdit.attr("disabled", "disabled");
                    self.$modal.modal('show');
                });

                $el.on('click', '.eliminarCliente', function () {
                    var data = self.dtCliente.row($(this).parents('tr')).data();
                    var r1 = self.funciones.eliminarCliente(self, data);
                    $.when(r1).done(function (response) {
                        if (response.error) {
                            alert(response.mensaje);
                        }
                        else {
                            self.funciones.buscarClientes(self);
                        }
                        self.$modal.modal('hide');
                    });
                });

                $el.on('click', self.btnCargaMasiva, function (e) {
                    
                    e.preventDefault();
                    self.$fileExcel.trigger('click');
                    //document.getElementById("fileExcel").click();
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
                $el.on('click', self.btnBuscarClienteEdit, function (e) {

                    e.preventDefault();
                    var r1 = self.funciones.obtenerDataClienteSunat(self, self.$txtNroDocumentoEdit.val());
                    $.when(r1).done(function (response) {
                        console.log(response);
                        if (response === undefined) {
                            self.$txtNombreClienteEdit.val('');
                            alert('Cliente no encontrado');
                        }
                        else {
                            self.$txtNombreClienteEdit.val(response.razonSocial);
                        }
                    });
                    //document.getElementById("fileExcel").click();
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
                
            }
        },
        inicio: function () {
            var self = this;
            $(win).on('load', function () {
                C.Base.validarToken();
                self.eventos.botones(self);
                self.funciones.llenaDatosinicio(self);
                self.funciones.buscarClientes(self);
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new Cliente, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Cliente);
    } else {
        window.onload = new Cliente;
    }

})(APP, window, jQuery, _);