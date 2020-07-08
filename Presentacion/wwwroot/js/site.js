var APP = APP || {};

APP.Core = (function (Core, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Vars = function () {
        //this.rutaAPP = 'https://perufactura-dev-web.azurewebsites.net/ventor';
        this.rutaSERV = 'https://perufactura-prod-web.azurewebsites.net/apiventor';
        //this.rutaSERV = 'http://localhost:53583';
        this.rutaAPP = 'http://localhost:54976';
        this.lenguajeGrilla = { "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json" };
        this.meses = [{ mes: 1, texto: 'Enero' },
            { mes: 2, texto: 'Febrero' },
            { mes: 3, texto: 'Marzo' },
            { mes: 4, texto: 'Abril' },
            { mes: 5, texto: 'Mayo' },
            { mes: 6, texto: 'Junio' },
            { mes: 7, texto: 'Julio' },
            { mes: 8, texto: 'Agosto' },
            { mes: 9, texto: 'Setiembre' },
            { mes: 10, texto: 'Octubre' },
            { mes: 11, texto: 'Noviembre' },
            { mes: 12, texto: 'Diciembre' }
        ];
    }
    var Base = function (obj) {
        this.datos = {
            btnCerrarSesion: '#btnCerrarSesion',
            fichaEmail: '#fichaEmail',
            fichaNombre: '#fichaNombre',
            fichaNombrePrinc: '#fichaNombrePrinc',
            fichaEmpresa: '#fichaEmpresa'
        };
        this.cerrarSesion(this.datos);
    };

    Base.prototype = {
        ajax: function (opc) {
            var self = this;
            var opciones = {};
            opciones.type = opc.type || "post";
            opciones.url = opc.url;
            opciones.headers = self.auntenticar();
            if (typeof (opc.beforeSend) == "function") {
                opciones.beforeSend = opc.beforeSend;
            } else {
                opciones.beforeSend = function () {
                    //console.log("cargando desde base el ajax...");
                    //C_Interfaz.mostrarLoader();
                }
            }
            opciones.error = function (req, status, err) {
                //C_Interfaz.mensaje(0, "tc", "Error:", '<p>Parece que hubo un error, por favor comuníquese con el administrador del sistema.</p>', 4000);
                //C_Interfaz.cerrarLoader();
            }
            if (opc.crossDomain) opciones.crossDomain = true;
            if (opc.async) opciones.async = opc.async;
            //else opciones.async = false;
            //opciones.async = true;
            if (opc.cache) opciones.cache = true;
            if (opc.global) opciones.global = true;
            if (opc.data) opciones.data = opc.data;
            if (opc.dataType) opciones.dataType = opc.dataType;
            //opciones.dataType = 'application/json; charset=utf-8';
            if (opc.multipart) {
                opciones.mimeType = "multipart/form-data";
                opciones.contentType = false;
                opciones.processData = false;
                opciones.cache = false;
            }

            return $.ajax(opciones);

        },
        ajaxDatos: function (opc) {
            var self = this;
            var datos;

            $.ajax({
                type: opc.type || "get",
                url: opc.url,
                async: false,
                data: opc.data || false,
                //crossDomain: true,
                //cache: false
                headers: self.auntenticar(),
                success: function (data) {
                    datos = data;
                },
                beforeSend: function () {
                    if (opc.loader) {
                        C_Interfaz.mostrarLoader();
                    }

                }
            });

            return datos;
        },
        auntenticar: function () {
            var tokenKey = 'accessToken';
            var token = sessionStorage.getItem(tokenKey);
            var headers = {};
            if (token) {
                headers.Authorization = 'Bearer ' + token;
                return headers;
            } else {
                win.location.href = C_Vars.rutaAPP + "/seguridad/Login";
            }
        },
        validarToken: function () {
            var tokenKey = 'accessToken'
            var token = sessionStorage.getItem(tokenKey);
            var headers = {};
            headers.Authorization = 'Bearer ' + token;
            var r1 = $.ajax({
                url: C_Vars.rutaSERV + '/api/account/ValidaToken',
                type: 'post',
                async: false,
                contentType: "application/json; charset=utf-8",
                headers: headers,
                statusCode: {
                    401: function () {
                        win.location.href = C_Vars.rutaAPP + "/seguridad/Login";
                    }
                }
            });

            $.when(r1).done(function (response) {
                $(".preloader").fadeOut();
            });
        },
        cerrarSesion(datos) {
            var userName = sessionStorage.getItem('nombreUsuario');
            var email = sessionStorage.getItem('email');
            var nombreEmpresa = sessionStorage.getItem('nombreEmpresa');
            $(datos.fichaNombre).html(userName);
            $(datos.fichaNombrePrinc).html(userName);
            $(datos.fichaEmail).html(email);
            $(datos.fichaEmpresa).html(nombreEmpresa);
            $el.on('click', datos.btnCerrarSesion, function () {
                sessionStorage.clear();
                win.location.href = C_Vars.rutaAPP + "/seguridad/Login";
            });
        },
        validarFormulario: function (controles) {
            var validado = true;
            $.each(controles, function (key, obj) {
                var controlValidado = true;
                $.each(obj.reglas, function (key, objRegla) {
                    switch (objRegla.regla) {
                        case 'required':
                            if (obj.control.val() == '') {
                                controlValidado = false;
                            }
                            break;
                        case 'minlength':
                            if (obj.control.val().length < objRegla.minlength) {
                                controlValidado = false;
                            }
                            break;
                        default:
                            break;
                    }
                });
                if (!controlValidado) {
                    validado = controlValidado;
                    obj.control.addClass('tiene-error');
                }
                else {
                    obj.control.removeClass('tiene-error');
                }
            });
            return validado;
        },
        checkfileExcel: function (sender) {
            var validExts = new Array(".xlsx", ".xls", ".csv");
            var fileExt = sender.value;
            fileExt = fileExt.substring(fileExt.lastIndexOf('.'));
            if (validExts.indexOf(fileExt) < 0) {
                alert("Invalid file selected, valid files are of " +
                    validExts.toString() + " types.");
                return false;
            }
            else return true;
        },
        obtenerParametrosUrl: function (name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        },
        llenaCboAnios: function (cbo, inicio) {
            var d = new Date();
            var y = d.getFullYear();
            for (var i = inicio; i <= y; i++) {
                if (i === y)
                    cbo.append('<option value="' + i + '" selected="selected">' + i + '</option>');
                else
                    cbo.append('<option value="' + i + '">' + i + '</option>');
            }
        },
        obtenerAnios: function (inicio) {
            var d = new Date();
            var y = d.getFullYear();
            let response = [];
            for (var i = inicio; i <= y; i++) {
                response.push(i);
            }
            return response;
        },
        dateFormat: function ($date, $t) {
            let $_date = $date.split('/');
            let $d = new Date($date);
            if ($_date.length > 1) $d = new Date($_date[2] + '/' + $_date[1] + '/' + $_date[0]);

            let $dia = C_Base.dayToSpanish($d.getDay(), true);
            let $mes = C_Base.monthToSpanish($d.getMonth(), true);

            if ($t == 1) return $dia + ' ' + ("0" + $d.getDate()).slice(-2);
            if ($t == 2) return $mes;
            if ($t == 3) return $d.getFullYear();
            if ($t == 4) return ("0" + $d.getDate()).slice(-2) + ' de ' + $mes + ' del ' + $d.getFullYear();
            if ($t == 5) return ("0" + $d.getDate()).slice(-2) + ' de ' + $mes + ' del ' + $d.getFullYear() + ', ' + C_Base.formatAMPM($d);
        },
        dayToSpanish: function (dia, corto) {
            let dias = ["Domingo", "Lunes", "Mártes", "Miercoles", "Jueves", "Viernes", "Sábado"];
            if (!corto) return dias[dia];
            else return C_Base.quitarTildes(dias[dia]).substring(0, 3);
        },
        monthToSpanish: function ($x, $short) {
            let $meses = ["", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
            $x = $x * 1;

            if (!$short) return $meses[$x];
            else return $meses[$x].substring(0, 3);
        },
        quitarTildes: function (cadena) {
            let no_permitidas = ["á", "é", "í", "ó", "ú", "Á", "É", "Í", "Ó", "Ú", "ñ", "À", "Ã", "Ì", "Ò", "Ù", "Ã™", "Ã ", "Ã¨", "Ã¬", "Ã²", "Ã¹", "ç", "Ç", "Ã¢", "ê", "Ã®", "Ã´", "Ã»", "Ã‚", "ÃŠ", "ÃŽ", "Ã”", "Ã›", "ü", "Ã¶", "Ã–", "Ã¯", "Ã¤", "«", "Ò", "Ã", "Ã„", "Ã‹"];
            let permitidas = ["a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "n", "N", "A", "E", "I", "O", "U", "a", "e", "i", "o", "u", "c", "C", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "u", "o", "O", "i", "a", "e", "U", "I", "A", "E"];
            let texto = C_Base.str_replace(no_permitidas, permitidas, cadena);
            return texto;
        },
        str_replace: function ($f, $r, $s) {
            return $s.replace(new RegExp("(" + (typeof ($f) == "string" ? $f.replace(/[.?*+^$[\]\\(){}|-]/g, "\\") :
                $f.map(function (i) { return i.replace(/[.?*+^$[\]\\(){}|-]/g, "\\") }).join("|")) + ")", "g"), typeof ($r) == "string" ? $r : typeof ($f) == "string" ? $r[0] : function (i) {
                    return $r[$f.indexOf(i)]
                });
        },
        ReplaceStringFrom: function (x, OldWrd, NewWrd, Ptr) {
            x = x.substr(0, Ptr) + NewWrd + x.substr(OldWrd.length + Ptr);
        },
        formatAMPM: function (date) {
            var hours = date.getHours();
            var minutes = date.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am';
            hours = hours % 12;
            hours = hours ? hours : 12; // the hour '0' should be '12'
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes + ' ' + ampm;
            return strTime;
        },
        parseXml: function (xmlStr) {
            return new window.DOMParser().parseFromString(xmlStr, "text/xml");
        },
        formatoNumero(amount, decimals) {
            amount += ''; // por si pasan un numero en vez de un string
            amount = parseFloat(amount.replace(/[^0-9\.]/g, '')); // elimino cualquier cosa que no sea numero o punto
            decimals = decimals || 0; // por si la variable no fue fue pasada
            // si no es un numero o es igual a cero retorno el mismo cero
            if (isNaN(amount) || amount === 0)
                return parseFloat(0).toFixed(decimals);

            // si es mayor o menor que cero retorno el valor formateado como numero
            amount = '' + amount.toFixed(decimals);
            var amount_parts = amount.split('.'),
                regexp = /(\d+)(\d{3})/;
            while (regexp.test(amount_parts[0]))
                amount_parts[0] = amount_parts[0].replace(regexp, '$1' + ',' + '$2');
            return amount_parts.join('.');
        },

        mod: function (dividendo, divisor) {
            var resDiv = dividendo / divisor;
            var parteEnt = Math.floor(resDiv);            // Obtiene la parte Entera de resDiv 
            var parteFrac = resDiv - parteEnt;      // Obtiene la parte Fraccionaria de la división
            var modulo = Math.round(parteFrac * divisor);  // Regresa la parte fraccionaria * la división (modulo) 
            return modulo;
        }, // Fin de función mod

        // Función ObtenerParteEntDiv, regresa la parte entera de una división
        ObtenerParteEntDiv: function (dividendo, divisor) {
            var resDiv = dividendo / divisor;
            var parteEntDiv = Math.floor(resDiv);
            return parteEntDiv;
        }, // Fin de función ObtenerParteEntDiv

        // function fraction_part, regresa la parte Fraccionaria de una cantidad
        fraction_part: function (dividendo, divisor) {
            var resDiv = dividendo / divisor;
            var f_part = Math.floor(resDiv);
            return f_part;
        }, // Fin de función fraction_part

        // function string_literal conversion is the core of this program 
        // converts numbers to spanish strings, handling the general special 
        // cases in spanish language. 
        string_literal_conversion: function (number) {
            // first, divide your number in hundreds, tens and units, cascadig 
            // trough subsequent divisions, using the modulus of each division 
            // for the next. 

            var centenas = C_Base.ObtenerParteEntDiv(number, 100);

            number = C_Base.mod(number, 100);

            var decenas = C_Base.ObtenerParteEntDiv(number, 10);
            number = C_Base.mod(number, 10);

            var unidades = C_Base.ObtenerParteEntDiv(number, 1);
            number = C_Base.mod(number, 1);
            var string_hundreds = "";
            var string_tens = "";
            var string_units = "";
            // cascade trough hundreds. This will convert the hundreds part to 
            // their corresponding string in spanish.
            if (centenas == 1) {
                string_hundreds = "Ciento ";
            }


            if (centenas == 2) {
                string_hundreds = "Doscientos ";
            }

            if (centenas == 3) {
                string_hundreds = "Trescientos ";
            }

            if (centenas == 4) {
                string_hundreds = "Cuatrocientos ";
            }

            if (centenas == 5) {
                string_hundreds = "Quinientos ";
            }

            if (centenas == 6) {
                string_hundreds = "Seiscientos ";
            }

            if (centenas == 7) {
                string_hundreds = "Setecientos ";
            }

            if (centenas == 8) {
                string_hundreds = "Ochocientos ";
            }

            if (centenas == 9) {
                string_hundreds = "Novecientos ";
            }

            // end switch hundreds 

            // casgade trough tens. This will convert the tens part to corresponding 
            // strings in spanish. Note, however that the strings between 11 and 19 
            // are all special cases. Also 21-29 is a special case in spanish. 
            if (decenas == 1) {
                //Special case, depends on units for each conversion
                if (unidades == 1) {
                    string_tens = "Once";
                }

                if (unidades == 2) {
                    string_tens = "Doce";
                }

                if (unidades == 3) {
                    string_tens = "Trece";
                }

                if (unidades == 4) {
                    string_tens = "Catorce";
                }

                if (unidades == 5) {
                    string_tens = "Quince";
                }

                if (unidades == 6) {
                    string_tens = "Dieciseis";
                }

                if (unidades == 7) {
                    string_tens = "Diecisiete";
                }

                if (unidades == 8) {
                    string_tens = "Dieciocho";
                }

                if (unidades == 9) {
                    string_tens = "Diecinueve";
                }
            }
            //alert("STRING_TENS ="+string_tens);

            if (decenas == 2) {
                string_tens = "Veinti";
            }
            if (decenas == 3) {
                string_tens = "Treinta";
            }
            if (decenas == 4) {
                string_tens = "Cuarenta";
            }
            if (decenas == 5) {
                string_tens = "Cincuenta";
            }
            if (decenas == 6) {
                string_tens = "Sesenta";
            }
            if (decenas == 7) {
                string_tens = "Setenta";
            }
            if (decenas == 8) {
                string_tens = "Ochenta";
            }
            if (decenas == 9) {
                string_tens = "Noventa";
            }

            // Fin de swicth decenas

            if (decenas == 1) {
                string_units = "";  // empties the units check, since it has alredy been handled on the tens switch 
            }
            else {
                if (unidades == 1) {
                    string_units = "Un";
                }
                if (unidades == 2) {
                    string_units = "Dos";
                }
                if (unidades == 3) {
                    string_units = "Tres";
                }
                if (unidades == 4) {
                    string_units = "Cuatro";
                }
                if (unidades == 5) {
                    string_units = "Cinco";
                }
                if (unidades == 6) {
                    string_units = "Seis";
                }
                if (unidades == 7) {
                    string_units = "Siete";
                }
                if (unidades == 8) {
                    string_units = "Ocho";
                }
                if (unidades == 9) {
                    string_units = "Nueve";
                }
                // end switch units 
            } // end if-then-else 

            if (centenas == 1 && decenas == 0 && unidades == 0) {
                string_hundreds = "Cien ";
            }

            // when you've got 10, you don't say any of the 11-19 special 
            // cases.. just say 'diez' 
            if (decenas == 1 && unidades == 0) {
                string_tens = "Diez ";
            }

            // when you've got 20, you don't say 'veinti', which is used 
            // only for [21 >= number > 29] 
            if (decenas == 2 && unidades == 0) {
                string_tens = "Veinte ";
            }

            // for numbers >= 30, you don't use a single word such as veintiuno 
            // (twenty one), you must add 'y' (and), and use two words. v.gr 31 
            // 'treinta y uno' (thirty and one) 
            if (decenas >= 3 && unidades >= 1) {
                string_tens = string_tens + " y ";
            }

            // this line gathers all the hundreds, tens and units into the final string 
            // and returns it as the function value.
            var final_string = string_hundreds + string_tens + string_units;


            return final_string;

        }, //end of function C_Base.string_literal_conversion()================================ 

        valorEnLetras: function (number, Moneda) {

            //number = number_format (number, 2);
            var number1 = number.toString();
            //settype (number, "integer");
            var cent = number1.split('.');
            var centavos = cent[1];

            var descriptor = '';
            var centenas_final_string = '';
            var cad = '';

            if (centavos == 0 || centavos == undefined) {
                centavos = "00";
            }

            if (number == 0 || number == "") { // if amount = 0, then forget all about conversions, 
                centenas_final_string = " Cero "; // amount is zero (cero). handle it externally, to 
                // function breakdown 
            }
            else {

                var millions = C_Base.ObtenerParteEntDiv(number, 1000000); // first, send the millions to the string 
                number = C_Base.mod(number, 1000000);           // conversion function 

                if (millions != 0) {
                    // This condition handles the plural case 
                    if (millions == 1) {              // if only 1, use 'millon' (million). if 
                        descriptor = " Millón ";  // > than 1, use 'millones' (millions) as 
                    }
                    else {                           // a descriptor for this triad. 
                        descriptor = " Millones ";
                    }
                }
                else {
                    descriptor = " ";                 // if 0 million then use no descriptor. 
                }
                var millions_final_string = C_Base.string_literal_conversion(millions) + descriptor;


                var thousands = C_Base.ObtenerParteEntDiv(number, 1000);  // now, send the thousands to the string 
                number = C_Base.mod(number, 1000);            // conversion function. 
                //print "Th:".thousands;
                var thousands_final_string = '';
                if (thousands != 1) {                   // This condition eliminates the descriptor 
                    thousands_final_string = C_Base.string_literal_conversion(thousands) + " Mil ";
                    //  descriptor = " mil ";          // if there are no thousands on the amount 
                }
                if (thousands == 1) {
                    thousands_final_string = " Mil ";
                }
                if (thousands < 1) {
                    thousands_final_string = " ";
                }

                // this will handle numbers between 1 and 999 which 
                // need no descriptor whatsoever. 

                var centenas = number;
                centenas_final_string = C_Base.string_literal_conversion(centenas);

            } //end if (number ==0) 

            /*if (ereg("un",centenas_final_string))
            {
              centenas_final_string = ereg_replace("","o",centenas_final_string); 
            }*/
            //finally, print the output. 

            /* Concatena los millones, miles y cientos*/
            cad = millions_final_string + thousands_final_string + centenas_final_string;

            /* Convierte la cadena a Mayúsculas*/
            //cad = cad.toUpperCase();

            if (centavos.length > 2) {
                if (centavos.substring(2, 3) >= 5) {
                    centavos = centavos.substring(0, 1) + (parseInt(centavos.substring(1, 2)) + 1).toString();
                } else {
                    centavos = centavos.substring(0, 2);
                }
            }

            /* Concatena a los centavos la cadena "/100" */
            if (centavos.length == 1) {
                centavos = centavos + "0";
            }
            centavos = centavos + "/100";

            return cad + ' Con ' + centavos + ' ' + Moneda;
            /* Regresa el número en cadena entre paréntesis y con tipo de moneda y la fase M.N.*/
        },
        PadLeft: function (number, width) {
            width -= number.toString().length;
            if (width > 0) {
                return new Array(width + (/\./.test(number) ? 2 : 1)).join('0') + number;
            }
            return number + ""; // siempre devuelve tipo cadena
        }
    }

    var Interfaz = function (obj) {
        this.ENTER_KEY = 13;
        this.ESCAPE_KEY = 27;
    }

    Interfaz.prototype = {
        enlace: function (enlace, mostrar) {

            var accion = mostrar || true;
            //if (accion == true) this.mostrarLoader();
            win.location.href = enlace;

        },
        bloquearDiv: function (div) {
            div.block({
                message: '<img src="' + C_Vars.rutaAPP + '/images/load.gif" width="50px" height="28px" />',
                css: {
                    border: '0px',
                    'background-color': 'transparent'
                }
            });
        },
        desbloquearDiv: function (div) {
            div.unblock();
        },
        llenarGrilla: function (grilla, response) {
            grilla.dataTable().fnClearTable();
            if (response.length != 0) {
                grilla.dataTable().fnAddData(response);
            }
        },

        
    }

    Core.Vars = Vars;
    Core.Base = Base;
    Core.Interfaz = Interfaz;
    var C_Vars = new Vars();
    var C_Base = new Base();
    var C_Interfaz = new Interfaz();
    return Core;
}) (APP.Core || {}, window, jQuery, _);