var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Impresion = function () {
        var self = this;
        self.btnEjecutaImpresion = '#btnEjecutaImpresion';
        this.inicio();
    }
    Impresion.prototype = {
        funciones: {
            llenaDatosinicio: function (self) {
                $(".absoluteImpresion").draggable();
                $(".rowImpresion").resizable({
                    resize: function (event, ui) {
                        ui.size.width = ui.originalSize.width;
                    }
                });
            }
        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnEjecutaImpresion, function (e) {
                    e.preventDefault();
                    //var mywindow = window.open(C.Vars.rutaAPP + '/Impresion/Impresion', 'PRINT', 'height=400,width=600');
                    var mywindow = window.open('', 'PRINT', 'height=400,width=600');
                    var primera = APP.Plantilla.primeraParte.replace(/RAIZCHANGE/g, C.Vars.rutaAPP);
                    var segunda = APP.Plantilla.segundaParte.replace(/RAIZCHANGE/g, C.Vars.rutaAPP);
                    mywindow.document.write(primera);
                    mywindow.document.write(document.getElementById("containerImpresion").innerHTML);
                    mywindow.document.write(segunda);

                    mywindow.document.close(); // necessary for IE >= 10
                    mywindow.focus(); // necessary for IE >= 10*/
                    setTimeout(function () { mywindow.print(); }, 1000);
                    //mywindow.print();
                    //mywindow.close();
                    return true;

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
        window.addEventListener("load", new Impresion, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Impresion);
    } else {
        window.onload = new Impresion;
    }

})(APP, window, jQuery, _);

APP.Plantilla = {
    primeraParte: '<!DOCTYPE html>' +
        '<html>' +
        '<head>' +
        '<meta charset="utf-8" />' +
        '<meta http-equiv="X-UA-Compatible" content="IE=edge">' +
        '<meta name="viewport" content="width=device-width, initial-scale=1.0" />' +
        '<meta name="description" content="">' +
        '<meta name="author" content="">' +
        '<link rel="icon" type="image/png" sizes="16x16" href="RAIZCHANGE/favicon.ico">' +
        '<title>@ViewData["Title"] - Presentacion</title>' +
        '<link href="RAIZCHANGE/css/bootstrap.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/sidebar-nav.min.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/animate.css" rel="stylesheet">' +
        '<link href="RAIZCHANGE/css/chartist.min.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/chartist-plugin-tooltip.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/style.css" rel="stylesheet">' +
        '<link href="RAIZCHANGE/css/jquery.dataTables.min.css" rel="stylesheet">' +
        '<link href="RAIZCHANGE/css/red-dark.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/site.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/sweetalert.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/Select2.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/custom-select.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/bootstrap-select.min.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/select2-bootstrap4.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/bootstrap-datepicker.min.css" rel="stylesheet" />' +
        '<link href="RAIZCHANGE/css/daterangepicker.css" rel="stylesheet" />' +
        '</head>' +
        '<body>',
    segundaParte: 
        '<script src="RAIZCHANGE/plugin/jquery.js"></script>' +
        '<script src="RAIZCHANGE/plugin/bootstrap.js"></script>' +
        '<script src="RAIZCHANGE/plugin/underscore.js"></script>' +
        '<script src="RAIZCHANGE/plugin/moment.js"></script>' +
        '<script src="RAIZCHANGE/plugin/chartist.min.js"></script>' +
        '<script src="RAIZCHANGE/plugin/chartist-plugin-tooltip.min.js"></script>' +
        '<script src="RAIZCHANGE/js/site.js"></script>' +
        '<script src="RAIZCHANGE/js/Menu/Menu.js"></script>' +
        '<script src="RAIZCHANGE/plugin/sidebar-nav.js"></script>' +
        '<script src="RAIZCHANGE/plugin/jquery.slimscroll.js"></script>' +
        '<script src="RAIZCHANGE/plugin/waves.js"></script>' +
        '<script src="RAIZCHANGE/plugin/jasny-bootstrap.js"></script>' +
        '<script src="RAIZCHANGE/plugin/jquery.dataTables.min.js"></script>' +
        '<script src="RAIZCHANGE/plugin/sweetalert.min.js"></script>' +
        '<script src="RAIZCHANGE/plugin/jquery.sweet-alert.custom.js"></script>' +
        '<script src="RAIZCHANGE/plugin/custom.js"></script>' +
        '<script src="RAIZCHANGE/plugin/jQuery.style.switcher.js"></script>' +
        '<script src="RAIZCHANGE/plugin/jquery.blockUI.js"></script>' +
        '<script src="RAIZCHANGE/plugin/excel-read.js"></script>' +
        '<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.10/js/select2.min.js"></script>' +
        '<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.10/js/i18n/es.js" integrity="sha256-o58EJjcGCuL+n5cnMcbODIRjTJzGClj/BEvTSUwhdq0=" crossorigin="anonymous"></script>' +
        '<script src="RAIZCHANGE/plugin/custom-select.js"></script>' +
        '<script src="RAIZCHANGE/plugin/bootstrap-select.min.js"></script>' +
        '<script src="RAIZCHANGE/plugin/bootstrap-datepicker.min.js"></script>' +
        '<script src="RAIZCHANGE/plugin/daterangepicker.js"></script>' +
        '<script src="RAIZCHANGE/plugin/jquery-ui-1.9.2.custom.js"></script>' +
        '</body>' +
        '</html>'

};