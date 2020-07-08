var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Usuario = function () {
        this.grilla = '#grilla';
        this.$grilla = $('#grilla');
        this.$divGrilla = $("#divGrilla");
        this.$txtBuscarNombre = $('#txtBuscarNombre');
        this.$txtBuscarUsuario = $('#txtBuscarUsuario');
        this.$btnGuardarUsuario = $('#btnGuardarUsuario');
        this.btnGuardarUsuario = '#btnGuardarUsuario';
        this.btnBuscar = '#btnBuscar';
        this.$btnNuevo = $('#btnNuevo');
        this.btnNuevo = '#btnNuevo';
        this.$modalUsuario = $('#modalUsuario');
        this.$cboTipousuarioEdit = $('#cboTipousuarioEdit');
        this.$txtNombreEdit = $('#txtNombreEdit');
        this.$txtUsuarioEdit = $('#txtUsuarioEdit');
        this.$txtContrasenaEdit = $('#txtContrasenaEdit');
        this.$txtConfirmarContrasenaEdit = $('#txtConfirmarContrasenaEdit');
        this.$divConfirmaContrasena = $('#divConfirmaContrasena');
        this.$helperContrasena = $('#helperContrasena');
        this.$divMensajeError = $('#divMensajeError');
        this.$spanMensajeError = $('#spanMensajeError');
        this.idUsuario = 0;
        this.accion = 'agregar';
        this.dtUsuario = {};
        this.usuarioSeleccionado = {};
        this.inicio();
    }
    Usuario.prototype = {
        funciones: {
            buscarUsuarios: function (self) {
                C.Interfaz.bloquearDiv(self.$divGrilla);
                var r1 = self.funciones.obtenerUsuarios(self);
                $.when(r1).done(function (response) {
                    console.log(response);
                    C.Interfaz.llenarGrilla(self.$grilla, response);
                    C.Interfaz.desbloquearDiv(self.$divGrilla);
                });
            },
            obtenerUsuarios: function (self) {
                var request = {};
                request.Empresa_id = sessionStorage.getItem('empresa');
                request.NombrePersona = self.$txtBuscarNombre.val();
                request.NombreUsuario = self.$txtBuscarUsuario.val();

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Usuario/ObtenerUsuarios',
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
            nuevoUsuario: function (self) {
                var nuevoUsuario = {};
                nuevoUsuario.UserName = self.$txtUsuarioEdit.val();
                nuevoUsuario.Password = self.$txtContrasenaEdit.val();
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/account/create',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(nuevoUsuario),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                $.when(r1).done(function (response) {
                    console.log(response);
                    var nuevaPersona = {};
                    nuevaPersona.NombreUsuario = self.$txtUsuarioEdit.val();
                    nuevaPersona.NombrePersona = self.$txtNombreEdit.val();
                    nuevaPersona.EmpresaId = sessionStorage.getItem('empresa');
                    nuevaPersona.RoleId = self.$cboTipousuarioEdit.val();
                    var r2 = $.ajax({
                        url: C.Vars.rutaSERV + '/api/Usuario/NuevoUsuario',
                        type: 'post',
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(nuevaPersona),
                        headers: C.Base.auntenticar(),
                        statusCode: {
                            401: function () {
                                win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                            }
                        }
                    });
                    $.when(r2).done(function (response) {
                        self.funciones.buscarUsuarios(self);
                        self.$modalUsuario.modal('hide');
                    }).fail(function (response) {
                        alert('error al guardar usuario');
                    });
                }).fail(function (response) {
                    //console.log(response.responseJSON);
                    self.$spanMensajeError.html(response.responseJSON);
                    self.$divMensajeError.show();
                });
            },
            editarUsuario: function (self) {
                var request = self.usuarioSeleccionado;
                console.log(request);
                request.nombrePersona = self.$txtNombreEdit.val();
                request.RoleId = request.idRol;
                if (request.RoleId != self.$cboTipousuarioEdit.val())
                    request.RoleId = self.$cboTipousuarioEdit.val();

                if (self.$txtContrasenaEdit.val() != '' || self.$txtConfirmarContrasenaEdit.val() != '') {
                    if (self.$txtContrasenaEdit.val() != self.$txtConfirmarContrasenaEdit.val()) {
                        self.$spanMensajeError.html('Las contraseñas no coinciden');
                        self.$divMensajeError.show();
                    }
                    else {
                        self.$spanMensajeError.html('');
                        self.$divMensajeError.hide();
                        var updatePwd = {};
                        updatePwd.UserName = self.usuarioSeleccionado.nombreUsuario;
                        updatePwd.Password = self.$txtContrasenaEdit.val();
                        var tokenKey = 'accessToken';
                        updatePwd.token = sessionStorage.getItem(tokenKey);
                        var r1 = $.ajax({
                            url: C.Vars.rutaSERV + '/api/Account/UpdatePwd',
                            type: 'post',
                            contentType: "application/json; charset=utf-8",
                            data: JSON.stringify(updatePwd),
                            headers: C.Base.auntenticar(),
                            statusCode: {
                                401: function () {
                                    win.location.href = C_Vars.rutaAPP + "/seguridad/Login";
                                }
                            }
                        });
                        $.when(r1).done(function (response) {
                            var r2 = $.ajax({
                                url: C.Vars.rutaSERV + '/api/Usuario/EditarUsuario',
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
                            $.when(r2).done(function (r) {
                                self.funciones.buscarUsuarios(self);
                                self.$modalUsuario.modal('hide');
                            });
                            
                        }).fail(function (response) {
                            self.$spanMensajeError.html(response.responseJSON);
                            self.$divMensajeError.show();
                        });
                    }
                }
                else {
                    self.$spanMensajeError.html('');
                    self.$divMensajeError.hide();
                    request.RoleId = request.idRol;
                    var r2 = $.ajax({
                        url: C.Vars.rutaSERV + '/api/Usuario/EditarUsuario',
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
                    $.when(r2).done(function (r) {
                        self.funciones.buscarUsuarios(self);
                        self.$modalUsuario.modal('hide');
                    });
                }
                //request.Id = self.idUsuario;
                //request.Nombre = self.$txtNombreEdit.val();
                //request.PrecioCompra = self.$txtCostoEdit.val();
                //request.Precio = self.$txtPrecioEdit.val();
                //request.EmpresaId = sessionStorage.getItem('empresa');
                //var r1 = $.ajax({
                //    url: C.Vars.rutaSERV + '/api/Usuario/EditarUsuario',
                //    type: 'post',
                //    contentType: "application/json; charset=utf-8",
                //    data: JSON.stringify(request),
                //    headers: C.Base.auntenticar()
                //});
                //return r1;
            },
            obtenerTipoUsuario: function (self) {
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Usuario/ObtenerTipoUsuarios',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });

                $.when(r1).done(function (response) {
                    console.log(response);
                    $.each(response, function (index, item) {
                        self.$cboTipousuarioEdit.append($('<option>', {
                            value: item.id,
                            text: item.name
                        }));
                    });
                });

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
                        control: self.$txtUsuarioEdit,
                        reglas: [
                            { regla: 'required' },
                            //{ regla: 'minlength', minlength: 2 }
                        ],
                    }
                ];

                respuesta = C.Base.validarFormulario(controles);
                return respuesta;
            },
            limpiarControlesUsuario: function (self) {
                self.$cboTipousuarioEdit.prop('selectedIndex', 0);
                self.$txtNombreEdit.val('');
                self.$txtUsuarioEdit.val('');
                self.$txtContrasenaEdit.val('');
                self.$txtConfirmarContrasenaEdit.val('');
                self.idUsuario = 0;
            },
            obtenerById: function (self, obj) {
                console.log(obj);
                self.usuarioSeleccionado = obj;
                self.idUsuario = obj.id;
                self.$cboTipousuarioEdit.val(obj.idRol);
                self.$txtNombreEdit.val(obj.nombrePersona);
                self.$txtUsuarioEdit.val(obj.nombreUsuario);
            }
        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnBuscar, function (e) {
                    e.preventDefault();
                    self.funciones.buscarUsuarios(self);
                });

                $el.on('click', self.btnGuardarUsuario, function (e) {
                    e.preventDefault();
                    if (self.funciones.validarformulario(self)) {
                        if (self.accion == 'agregar') {
                            self.funciones.nuevoUsuario(self);
                        }
                        else {
                            self.funciones.editarUsuario(self);
                        }
                    }
                });

                $el.on('hidden.bs.modal', self.$modalUsuario, function (e) {
                    self.funciones.limpiarControlesUsuario(self);
                    self.$divMensajeError.hide();
                    $('.tiene-error').removeClass('tiene-error');
                });

                $el.on('click', self.btnNuevo, function (e) {
                    e.preventDefault();
                    self.accion = 'agregar';
                    self.$helperContrasena.hide();
                    self.$divConfirmaContrasena.hide();
                    self.$txtUsuarioEdit.removeAttr("disabled");
                });

                $el.on('click', '.editarUsuario', function (e) {
                    e.preventDefault();
                    self.accion = 'editar';
                    var data = self.dtUsuario.row($(this).parents('tr')).data();
                    self.funciones.obtenerById(self, data);
                    self.$helperContrasena.show();
                    self.$divConfirmaContrasena.show();
                    self.$txtUsuarioEdit.attr("disabled", "disabled");
                    self.$modalUsuario.modal('show');
                });
            }
        },
        inicio: function () {
            var self = this;
            $(win).on('load', function () {
                C.Base.validarToken();
                self.eventos.botones(self);
                self.dtUsuario = self.$grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    columns: [
                        { title: 'Id', data: 'idUsuario', visible: false },
                        { title: 'Nombre', data: 'nombrePersona', width: "50%" },
                        { title: 'Usuario', data: 'nombreUsuario' },
                        { title: 'Rol', data: 'nombreRol' }
                    ],
                    columnDefs: [{
                        targets: 4,
                        data: null,
                        className: 'dt-center',
                        defaultContent: '<a href="#" title="Editar" class="editarUsuario"><i class="fa fa-fw fa-edit"></i></a>' +
                            '<a href="#" title="Eliminar" class="eliminarUsuario"><i class="fa fa-fw fa-remove"></i></a>'
                    }]
                });
                self.funciones.buscarUsuarios(self);
                self.funciones.obtenerTipoUsuario(self);
                self.$divMensajeError.hide();
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new Usuario, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Usuario);
    } else {
        window.onload = new Usuario;
    }

})(APP, window, jQuery, _);