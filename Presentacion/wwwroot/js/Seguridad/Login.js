var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var tokenKey = 'accessToken';
    var usuario = 'usuario';

    var Login = function () {
        this.$Ruc = $('#txtRuc');
        this.$Usuario = $('#txtUsuario');
        this.$Clave = $('#txtClave');
        this.btnLogin = '#btnLogin';

        this.inicio();
    }
    Login.prototype = {
        funciones: {
            login: function (self) {
                var userInfo = {
                    UserName: self.$Usuario.val(),
                    Password: self.$Clave.val(),
                    Empresa: self.$Ruc.val()
                };
                var r1 = $.ajax({
                    type: 'post',
                    url: C.Vars.rutaSERV + '/api/account/login',  
                    data: userInfo
                });
                $.when(r1).done(function (response) {
                    console.log(response);
                    sessionStorage.setItem(tokenKey, response.token);
                    sessionStorage.setItem("role", response.role);
                    sessionStorage.setItem("empresa", response.empresa);
                    sessionStorage.setItem("userId", response.userId);
                    sessionStorage.setItem("userName", response.userName);
                    sessionStorage.setItem("email", response.email);
                    sessionStorage.setItem("nombreUsuario", response.nombreUsuario);
                    sessionStorage.setItem("nombreEmpresa", response.nombreEmpresa);
                    
                    C.Interfaz.enlace(C.Vars.rutaAPP + "/Index");
                });
            }
        },
        eventos: function () {
            var self = this;
            $el.on('submit', '#loginform', function (e) {
                e.preventDefault();
                self.funciones.login(self);
                //win.location.href = C.Vars.rutaAPP + '/Account/ResetPasswordEmail';
                //alert("asd");
                //$(".preloader").show();
            });     
            //$el.on("click", self.btnLogin, function (e) {
            //    e.preventDefault();
            //    C.Interfaz.mostrarLoader();
            //    var as = new Object;
            //    var loginData = {
            //        grant_type: 'password',
            //        username: self.$User.val(),
            //        password: self.$Pass.val()
            //    };
            //
            //    var $that = $(this);
            //    $.ajax({
            //        type: 'POST',
            //        url: C.Vars.rutaSERV + '/Token',
            //        data: loginData
            //    }).done(function (data) {
            //        sessionStorage.setItem(tokenKey, data.access_token);
            //        var headers = {};
            //        headers.Authorization = 'Bearer ' + data.access_token;
            //        $.ajax({
            //            type: 'POST',
            //            url: C.Vars.rutaSERV + '/api/Seguridad/ObtenerDatosUsuario',
            //            headers: headers,
            //            async: false,
            //            data: loginModule,
            //            success: function (data) {
            //                sessionStorage.setItem(usuario, JSON.stringify(data));
            //                console.dir(sessionStorage.getItem("usuario"));
            //                console.dir(data);
            //            },
            //            error: function (data) {
            //                console.log("error login");
            //                //console.log(data);
            //            }
            //        });
            //        C.Interfaz.enlace(C.Vars.rutaAPP + "/Home/HomePP");
            //
            //    }).fail(function (data) {
            //
            //        var error = JSON.parse(data.responseText);
            //        C.Interfaz.cerrarLoader();
            //        //alert("error login");
            //        if (error.error === "invalid_grant") {
            //            //alert("Usuario o clave incorrectos");
            //            self.$mensaje.show('fast').find('h3').html("Usuario o clave incorrectos");
            //            //$('.web_login__mensaje h3').show('fast').parent().html("Usuario o clave incorrectos");
            //            setTimeout(function () {
            //                self.$mensaje.hide('fast').find('h3').html("");
            //            }, 2000);
            //        }
            //        console.dir(error);
            //    });
            //});
            //$el.on("click", self.btnRecuperarPassword, function (e) {
            //    win.location.href = C.Vars.rutaAPP + '/Account/ResetPasswordEmail';
            //});
            //
        },
        inicio: function () {
            var self = this;
            $(win).on('load', function () {
                //self.funciones.login(self);
                self.eventos();
                //$('.preloader').show();
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new Login, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Login);
    } else {
        window.onload = new Login;
    }

})(APP, window, jQuery, _);