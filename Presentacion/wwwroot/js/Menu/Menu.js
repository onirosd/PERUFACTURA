var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Menu = function () {
        var self = this;
        this.$menu = $('#side-menu'); 
        this.inicio();
    }
    Menu.prototype = {
        funciones: {
            obtenerMenu: function (self) {
                var role = sessionStorage.getItem('role');
                if (role != '') {
                    var request = {};
                    request.RoleId = role;
                    var r1 = $.ajax({
                        url: C.Vars.rutaSERV + '/api/Menu/TraerMenu',
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
                    var resultado = '';
                    var menu = [];
                    $.when(r1).done(function (response) {
                        menu = _.where(response, { padre: 0 });
                        $.each(menu, function (index, obj) {
                            var subMenu = _.where(response, { padre: obj.id });
                            if (subMenu.length > 0) {
                                resultado += '<li><a href="#" class="waves-effect"><i class="' + obj.class + '"></i> <span class="hide-menu">' + obj.nombre + '<span class="fa arrow"></span></span></a>';
                                resultado += '<ul class="nav nav-second-level collapse" aria-expanded="false">';

                                $.each(subMenu, function (index, obj) {
                                    resultado += '<li>';
                                    resultado += '<a href="' + C.Vars.rutaAPP + obj.url + '" class="sidebar-link">';
                                    resultado += '<i class=""></i>';
                                    resultado += '<span class="hide-menu">' + obj.nombre + '</span>';
                                    resultado += '</a>';
                                    resultado += '</li>';
                                });

                                resultado += '</ul>';
                                resultado +='</li>';
                            }
                            else {
                                
                                resultado += '<li><a href="' + C.Vars.rutaAPP + obj.url +'" class="waves-effect"><i class="' + obj.class + '"></i> <span class="hide-menu">' + obj.nombre + '</span></a></li>';
                            }
                        });
                        self.$menu.html(resultado);
                        var sideMenu = self.$menu;
                        sideMenu.removeData("metisMenu");
                        sideMenu.metisMenu();
                    });
                }
                else {
                    alert('No tiene roles asignados');
                }
                
            }
        },
        inicio: function () {
            var self = this;
            $(win).on('load', function () {
                C.Base.validarToken();
                self.funciones.obtenerMenu(self);
            });
        }
    };

    C.Vars = new APP.Core.Vars();
    C.Base = new APP.Core.Base();
    C.Interfaz = new APP.Core.Interfaz();

    if (window.addEventListener) {
        window.addEventListener("load", new Menu, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Menu);
    } else {
        window.onload = new Menu;
    }

})(APP, window, jQuery, _);