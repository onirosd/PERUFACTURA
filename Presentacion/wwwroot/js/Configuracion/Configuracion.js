var APP = APP || {};
(function (APP, win, $, _, undefined) {
        'use strict';
    var C = {};
    var $el = $('body');
    var Configuracion = function () {
        var self = this;
        this.btnGuardar = '#btnGuardarConfig';
        this.$divBloquearForm = $("#divBloquearForm");
        this.configuracion = {};
        this.$txtEmpresa = $('#txtEmpresa');
        this.$txtRuc = $('#txtRuc');
        this.$txtIGV = $('#txtIGV');
        this.$txtMonedaActual = $('#txtMonedaActual');
        this.$txtDireccion = $('#txtDireccion');
        this.$txtCTADetraccion = $('#txtCTADetraccion');
        
        this.inicio();
    };
    Configuracion.prototype = {
        funciones: {
            guardarConfiguracion: function (self) {
                var request = {};
                request = self.configuracion;
                request.direccion = self.$txtDireccion.val();
                request.ctadetraccion = self.$txtCTADetraccion.val();
                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/Configuracion/GuardarConfiguracion',
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
            obtenerConfiguracion: function (self) {
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
                self.funciones.bloquearForm(self);
                var r1 = self.funciones.obtenerConfiguracion(self);
                $.when(r1).done(function (response) {
                    self.configuracion = response;
                    self.$txtEmpresa.val(response.razonSocial);
                    self.$txtRuc.val(response.ruc);
                    self.$txtIGV.val(response.iva);
                    self.$txtMonedaActual.val(response.monedaId + ' ' + response.nombreMoneda);
                    self.$txtDireccion.val(response.direccion);
                    self.$txtCTADetraccion.val(response.ctadetraccion);
                    self.funciones.desbloquearForm(self);
                });
            },
            bloquearForm: function (self) {
                self.$divBloquearForm.block({
                    message: '<img src="' + C.Vars.rutaAPP + '/images/load.gif" width="50px" height="28px" />',
                    css: {
                        border: '0px',
                        'background-color': 'transparent'
                    }
                });
            },
            desbloquearForm: function (self) {
                self.$divBloquearForm.unblock();
            }

        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnGuardar, function (e) {
                    e.preventDefault();
                    if ($formularioServicio.valid()) {   // test for validity
                        C.Interfaz.bloquearDiv(self.$divBloquearForm);
                        var r1 = self.funciones.guardarConfiguracion(self);
                        $.when(r1).done(function (response) {
                            C.Interfaz.desbloquearDiv(self.$divBloquearForm);
                        });
                    } else {
                        alert('no pasa la validacion');
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
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new Configuracion, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Configuracion);
    } else {
        window.onload = new Configuracion;
    }

})(APP, window, jQuery, _);