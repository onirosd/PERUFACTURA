var APP = APP || {};
(function (APP, win, $, _, undefined) {
    'use strict';
    var C = {};
    var $el = $('body');
    var Comprobante = function () {
        var self = this;
        self.codComprobante = C.Base.obtenerParametrosUrl('idComp');
        self.txtTipoDocumento = $('#txtTipoDocumento');
        self.txtNombreCliente = $('#txtNombreCliente');
        self.txtRuc = $('#txtRuc');
        self.txtFecha = $('#txtFecha');
        self.txtEstado = $('#txtEstado');
        self.txtSerie = $('#txtSerie');
        self.txtEmail = $('#txtEmail');
        self.txtDireccion = $('#txtDireccion');
        self.txtFechaVencimiento = $('#txtFechaVencimiento');
        self.txtMoneda = $('#txtMoneda');
        self.txtTipoCambio = $('#txtTipoCambio');
        self.txtTipoOperacion = $('#txtTipoOperacion');
        self.txtDetraccion = $('#txtDetraccion');
        self.txtNroOC = $('#txtNroOC');
        self.txtTipoNota = $('#txtTipoNota');
        self.txtSerieRef = $('#txtSerieRef');
        self.txtCorrelativoRef = $('#txtCorrelativoRef');
        self.txtGlosa = $('#txtGlosa');
        self.txtSubTotal = $('#txtSubTotal');
        self.txtIva = $('#txtIva');
        self.txtIvaSubTotal = $('#txtIvaSubTotal');
        self.txtTotal = $('#txtTotal');
        self.grilla = $('#grilla');
        self.trGlosa = $('#trGlosa');
        self.trSubTotal = $('#trSubTotal');
        self.trIva = $('#trIva');
        self.divReferencia = $('#divReferencia');
        self.divTipoCambio = $('.divTipoCambio');
        self.spIdentidad = $('#spIdentidad');
        self.divDetraccion = $('#divDetraccion');
        self.divTipoOperacion = $('#divTipoOperacion');
        self.$ddlEstados = $('#ddlEstados');
        self.ddlEstados = '#ddlEstados';
        self.divTxtEstado = $('#divTxtEstado');
        self.divComboEstados = $('#divComboEstados');
        self.btnEnvioSunat = '#btnEnvioSunat';
        self.$txtFechaAnulacion = $('#txtFechaAnulacion');
        self.$txtMotivoAnulacion = $('#txtMotivoAnulacion');
        self.$botonesAccion = $('#botonesAccion'); //el div se encuentra en el layout y se debe generar en tiempo de ejecución
        self.$divAnulacion = $('#divAnulacion');
        self.btnAnulacion = '#btnAnulacion';
        self.objComprobante = {};
        self.btnEditarComprobante = '#btnEditarComprobante';
        self.$txtMedioPago = $('#txtMedioPago');
        this.inicio();
    }
    Comprobante.prototype = {
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
            llenaComboEstados: function (self, estados, estadoActual) {
                let selected = '';
                $.each(estados, function (index, value) {
                    if (value.value == estadoActual)
                        selected = 'selected';
                    else
                        selected = '';

                    self.$ddlEstados.append('<option value="' + value.value + '" ' + selected + '>' + value.nombre + '</option>');
                });
            },
            GenerarComprobanteElectronicoPago: function (self) {
                var c = self.objComprobante;

                var ruc = sessionStorage.getItem('empresa');
                var razon_social = c.clienteNombre;
                var direccion = c.clienteDireccion;
                var serie = c.serie;
                var correlativo = c.correlativo;
                var tipomonedaId = c.tipoMonedaId == 'S/' ? 'PEN': 'USD';

                var tipoDocumento = '';
                var cont = c.clienteIdentidad.length;
                if (cont == 8) {
                    tipoDocumento = '1';
                } else {
                    tipoDocumento = '6';
                }

                //moment(c.fechaEmitido).format("YYYY-MM-DD");
                var newDate = moment(c.fechaEmitido).format("YYYY-MM-DD");

                var newDateVenci = moment(c.fechaVencimiento).format("YYYY-MM-DD");

                var notas = [7, 8];
                var TipoNota = '';
                var Sustento = '';
                var referencia = '';
                var adicionales = '';
                var detraccion = '';
                var leyenda = '';

                if (c.nroOC != '') {
                    referencia = '<!--Optional:-->' +
                        '<dbn:Referencias>' +
                        '<!--Zero or more repetitions:-->' +
                        '<dbn:Referencias>' +
                        '<!--Optional:-->' +
                        '<dbn:NroLinRef>1</dbn:NroLinRef>' +
                        '<!--Optional:-->' +
                        '<dbn:TpoDocRef>801</dbn:TpoDocRef>' +
                        '<!--Optional:-->' +
                        '<dbn:SerieRef>-</dbn:SerieRef>' +
                        '<!--Optional:-->' +
                        '<dbn:FolioRef>' + c.nroOC + '</dbn:FolioRef>' +
                        '</dbn:Referencias>' +
                        '</dbn:Referencias>';
                }

                if ($.inArray(c.comprobanteTipoId, notas) != -1) {

                    TipoNota = c.tipoNota_id;
                    Sustento = c.TipoNota.Nombre;

                    referencia = '<!--Optional:-->' +
                        '<dbn:Referencias>' +
                        '<!--Zero or more repetitions:-->' +
                        '<dbn:Referencias>' +
                        '<!--Optional:-->' +
                        '<dbn:NroLinRef>1</dbn:NroLinRef>' +
                        '<!--Optional:-->' +
                        '<dbn:TpoDocRef>' + c.comprobanteTipoRef_id + '</dbn:TpoDocRef>' +
                        '<!--Optional:-->' +
                        '<dbn:SerieRef>' + c.serieRef + '</dbn:SerieRef>' +
                        '<!--Optional:-->' +
                        '<dbn:FolioRef>' + c.correlativoRef + '</dbn:FolioRef>' +
                        '</dbn:Referencias>' +
                        '</dbn:Referencias>';
                }

                if (c.glosa) {
                    adicionales = '<dbn:DatosAdicionales>' +
                        '<dbn:DatosAdicionales>' +
                        '<dbn:TipoAdicSunat>01</dbn:TipoAdicSunat>' +
                        '<dbn:NmrLineasAdicSunat>2</dbn:NmrLineasAdicSunat>' +
                        '<dbn:DescripcionAdicsunat><![CDATA[' + c.glosa + ']]>.</dbn:DescripcionAdicsunat>' +
                        '</dbn:DatosAdicionales>' +
                        '</dbn:DatosAdicionales>';
                }

                var xmlrequest = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:dbn="http://www.dbnet.cl">' +
                    '<soapenv:Header />' +
                    '<soapenv:Body>' +
                    '<dbn:putCustomerETDLoad>';

                if (c.clienteCorreo) {
                    xmlrequest += '<!--Optional:-->' +
                        '<dbn:Extras>' +
                        '<!--Optional:-->' +
                        '<dbn:EnvioPdf>' +
                        '<!--Zero or more repetitions:-->' +
                        '<dbn:EnvioPdf>' +
                        '<!--Optional:-->' +
                        '<dbn:CamposEnvioPdf>' +
                        '<!--Optional:-->' +
                        '<dbn:MailEnvi>' + c.clienteCorreo + '</dbn:MailEnvi>' +
                        '</dbn:CamposEnvioPdf>' +
                        '</dbn:EnvioPdf>' +
                        '</dbn:EnvioPdf>' +
                        '</dbn:Extras>';
                }

                if (c.detraccionId) {
                    detraccion = '<!--Optional:-->' +
                        '<dbn:DetaDetraccion>' +
                        '<!--Zero or more repetitions:-->' +
                        '<dbn:DetaDetraccion>' +
                        '<!--Optional:-->' +
                        '<dbn:codiDetraccion>' + c.detraccionId + '</dbn:codiDetraccion>' +
                        '<dbn:ValorDetraccion>' + c.valorDetraccion + '</dbn:ValorDetraccion>' +
                        '</dbn:DetaDetraccion>' +
                        '</dbn:DetaDetraccion>';

                    leyenda = '<dbn:CodigoLeyenda>2006</dbn:CodigoLeyenda>';
                }
                if (c.TipoOperacionId == '1003') {
                    xmlrequest += '<!--Optional:-->' +
                    '<dbn:Encabezado>' +
                    '<!--Optional:-->' +
                    '<dbn:camposEncabezado>' +
                    '<!--Optional:-->' +
                    '<dbn:TipoDTE>' + c.comprobanteTipoId + '</dbn:TipoDTE>' +
                    '<!--Optional:-->' +
                    '<dbn:RUTEmis>' + ruc + '</dbn:RUTEmis>' +
                    '<!--Optional:-->' +
                    '<dbn:Serie>' + serie + '</dbn:Serie>' +
                    '<!--Optional:-->' +
                    '<dbn:Correlativo>' + correlativo + '</dbn:Correlativo>' +
                    '<!--Optional:--> ' +
                    '<dbn:RznSocEmis><![CDATA[' + razon_social + ']]></dbn:RznSocEmis>' +
                    '<!--Optional:-->' +
                    '<dbn:DirEmis><![CDATA[' + direccion + ']]></dbn:DirEmis>' +
                    '<!--Optional:-->' +
                    '<dbn:CodiComu>150141</dbn:CodiComu>' +
                    '<!--Optional:-->' +
                    '<dbn:NomComer><![CDATA[' + razon_social + ']]></dbn:NomComer>' +
                    '<!--Optional:-->' +
                    '<dbn:RUTRecep>' + c.clienteIdentidad + '</dbn:RUTRecep >' +
                    '<!--Optional:-->' +
                    '<dbn:TipoRutReceptor>' + tipoDocumento + '</dbn:TipoRutReceptor>' +
                    '<!--Optional:-->' +
                    '<dbn:RznSocRecep><![CDATA[' + c.clienteNombre + ']]></dbn:RznSocRecep>' +
                    '<!--Optional:-->' +
                    '<dbn:DirRecep><![CDATA[' + c.clienteDireccion + ']]></dbn:DirRecep>' +
                    '<!--Optional:-->' +
                    '<dbn:TipoMoneda>' + tipomonedaId + '</dbn:TipoMoneda>' +
                    '<!--Optional:-->' +
					'<dbn:MntNeto>0.00</dbn:MntNeto>' +
                    '<!--Optional:-->' +
                    '<dbn:MntExe>0.00</dbn:MntExe>' +
                    '<!--Optional:-->' +
                    '<dbn:MntExo>' + c.total + '</dbn:MntExo>' +
                    '<!--Optional:-->' +
                    '<dbn:MntTotal>' + c.total + '</dbn:MntTotal>' +
                    '<!--Optional:-->' +
                    '<dbn:FchEmis>' + newDate + '</dbn:FchEmis>' +
                    '<!--Optional:-->' +
                    '<dbn:FechVencFact>' + newDateVenci + '</dbn:FechVencFact>' +
                    '<!--Optional:-->' +
                    '<dbn:Sustento>' + Sustento + '</dbn:Sustento>' +
                    '<!--Optional:-->' +
                    '<dbn:TipoNotaCredito>' + TipoNota + '</dbn:TipoNotaCredito>' +
                    '<!--Optional:-->' +
                    '<dbn:CodigoLocalAnexo>0000</dbn:CodigoLocalAnexo>' +
                    '<dbn:HoraEmision>' + c.horaEmisionDate.substr(11, 8) + '</dbn:HoraEmision> ' + leyenda +
                    '</dbn:camposEncabezado>' + detraccion +
                    '</dbn:Encabezado>' +
                    '<!--Optional:-->' +
                    '<dbn:Detalles>';
                }
                else if (c.TipoOperacionId == '1002') {
                    xmlrequest += '<!--Optional:-->' +
                        '<dbn:Encabezado>' +
                        '<!--Optional:-->' +
                        '<dbn:camposEncabezado>' +
                        '<!--Optional:-->' +
                        '<dbn:TipoDTE>' + c.comprobanteTipoId + '</dbn:TipoDTE>' +
                        '<!--Optional:-->' +
                        '<dbn:RUTEmis>' + ruc + '</dbn:RUTEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:Serie>' + serie + '</dbn:Serie>' +
                        '<!--Optional:-->' +
                        '<dbn:Correlativo>' + correlativo + '</dbn:Correlativo>' +
                        '<!--Optional:--> ' +
                        '<dbn:RznSocEmis><![CDATA[' + razon_social + ']]></dbn:RznSocEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:DirEmis><![CDATA[' + direccion + ']]></dbn:DirEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:CodiComu>150141</dbn:CodiComu>' +
                        '<!--Optional:-->' +
                        '<dbn:NomComer><![CDATA[' + razon_social + ']]></dbn:NomComer>' +
                        '<!--Optional:-->' +
                        '<dbn:RUTRecep>' + c.clienteIdentidad + '</dbn:RUTRecep >' +
                        '<!--Optional:-->' +
                        '<dbn:TipoRutReceptor>' + tipoDocumento + '</dbn:TipoRutReceptor>' +
                        '<!--Optional:-->' +
                        '<dbn:RznSocRecep><![CDATA[' + c.clienteNombre + ']]></dbn:RznSocRecep>' +
                        '<!--Optional:-->' +
                        '<dbn:DirRecep><![CDATA[' + c.clienteDireccion + ']]></dbn:DirRecep>' +
                        '<!--Optional:-->' +
                        '<dbn:TipoMoneda>' + tipomonedaId + '</dbn:TipoMoneda>' +
                        '<!--Optional:-->' +
                        '<dbn:MntNeto>0.00</dbn:MntNeto>' +
                        '<!--Optional:-->' +
                        '<dbn:MntExe>' + c.total + '</dbn:MntExe>' +
                        '<!--Optional:-->' +
                        '<dbn:MntExo>0.00</dbn:MntExo>' +
                        '<!--Optional:-->' +
                        '<dbn:MntTotal>' + c.total + '</dbn:MntTotal>' +
                        '<!--Optional:-->' +
                        '<dbn:FchEmis>' + newDate + '</dbn:FchEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:CodigoLocalAnexo>0000</dbn:CodigoLocalAnexo>' +
                        '<dbn:HoraEmision>' + c.horaEmisionDate.substr(11, 8) + '</dbn:HoraEmision> ' + leyenda +
                        '</dbn:camposEncabezado>' +
                        '</dbn:Encabezado>' +
                        '<!--Optional:-->' +
                        '<dbn:Detalles>';
                }
                else if (c.TipoOperacionId == '1004') {
                    xmlrequest += '<!--Optional:-->' +
                        '<dbn:Encabezado>' +
                        '<!--Optional:-->' +
                        '<dbn:camposEncabezado>' +
                        '<!--Optional:-->' +
                        '<dbn:TipoDTE>' + c.comprobanteTipoId + '</dbn:TipoDTE>' +
                        '<!--Optional:-->' +
                        '<dbn:RUTEmis>' + ruc + '</dbn:RUTEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:Serie>' + serie + '</dbn:Serie>' +
                        '<!--Optional:-->' +
                        '<dbn:Correlativo>' + correlativo + '</dbn:Correlativo>' +
                        '<!--Optional:--> ' +
                        '<dbn:RznSocEmis><![CDATA[' + razon_social + ']]></dbn:RznSocEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:DirEmis><![CDATA[' + direccion + ']]></dbn:DirEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:CodiComu>150141</dbn:CodiComu>' +
                        '<!--Optional:-->' +
                        '<dbn:NomComer><![CDATA[' + razon_social + ']]></dbn:NomComer>' +
                        '<!--Optional:-->' +
                        '<dbn:RUTRecep>' + c.clienteIdentidad + '</dbn:RUTRecep >' +
                        '<!--Optional:-->' +
                        '<dbn:TipoRutReceptor>' + tipoDocumento + '</dbn:TipoRutReceptor>' +
                        '<!--Optional:-->' +
                        '<dbn:RznSocRecep><![CDATA[' + c.clienteNombre + ']]></dbn:RznSocRecep>' +
                        '<!--Optional:-->' +
                        '<dbn:DirRecep><![CDATA[' + c.clienteDireccion + ']]></dbn:DirRecep>' +
                        '<!--Optional:-->' +
                        '<dbn:TipoMoneda>' + tipomonedaId + '</dbn:TipoMoneda>' +
                        '<!--Optional:-->' +
                        '<dbn:MntNeto>0.00</dbn:MntNeto>' +
                        '<!--Optional:-->' +
                        '<dbn:MntExe>0.00</dbn:MntExe>' +
                        '<!--Optional:-->' +
                        '<dbn:MntExo>0.00</dbn:MntExo>' +
                        '<!--Optional:-->' +
					    '<dbn:MntTotGrat>' + c.total + '</dbn:MntTotGrat>' +
                        '<!--Optional:-->' +
                        '<dbn:MntTotal>0.00</dbn:MntTotal>' +
                        '<!--Optional:-->' +
                        '<dbn:FchEmis>' + newDate + '</dbn:FchEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:Sustento>' + Sustento + '</dbn:Sustento>' +
                        '<!--Optional:-->' +
                        '<dbn:CodigoLocalAnexo>0000</dbn:CodigoLocalAnexo>' +
                        '<dbn:HoraEmision>' + c.horaEmisionDate.substr(11, 8) + '</dbn:HoraEmision> ' + leyenda +
                        '</dbn:camposEncabezado>' +
                        '<!--Optional:-->' +
					    '<dbn:ImptoReten>' +
					    '<!--Zero or more repetitions:-->' +
                        '</dbn:Encabezado>' +
                        '<!--Optional:-->' +
                        '<dbn:Detalles>';
                }
                else if (c.TipoOperacionId == '1005') {
                    xmlrequest += '<!--Optional:-->' +
                        '<dbn:Encabezado>' +
                        '<!--Optional:-->' +
                        '<dbn:camposEncabezado>' +
                        '<!--Optional:-->' +
                        '<dbn:TipoDTE>' + c.comprobanteTipoId + '</dbn:TipoDTE>' +
                        '<!--Optional:-->' +
                        '<dbn:RUTEmis>' + ruc + '</dbn:RUTEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:Serie>' + serie + '</dbn:Serie>' +
                        '<!--Optional:-->' +
                        '<dbn:Correlativo>' + correlativo + '</dbn:Correlativo>' +
                        '<!--Optional:--> ' +
                        '<dbn:RznSocEmis><![CDATA[' + razon_social + ']]></dbn:RznSocEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:DirEmis><![CDATA[' + direccion + ']]></dbn:DirEmis>' +
                        '<!--Optional:-->' +
					    '<dbn:TipoOperacion>0200</dbn:TipoOperacion>' +
                        '<!--Optional:-->' +
                        '<dbn:CodiComu>150141</dbn:CodiComu>' +
                        '<!--Optional:-->' +
                        '<dbn:NomComer><![CDATA[' + razon_social + ']]></dbn:NomComer>' +
                        '<!--Optional:-->' +
                        '<dbn:RUTRecep>' + c.clienteIdentidad + '</dbn:RUTRecep >' +
                        '<!--Optional:-->' +
                        '<dbn:TipoRutReceptor>' + tipoDocumento + '</dbn:TipoRutReceptor>' +
                        '<!--Optional:-->' +
                        '<dbn:RznSocRecep><![CDATA[' + c.clienteNombre + ']]></dbn:RznSocRecep>' +
                        '<!--Optional:-->' +
                        '<dbn:DirRecep><![CDATA[' + c.clienteDireccion + ']]></dbn:DirRecep>' +
                        '<!--Optional:-->' +
                        '<dbn:TipoMoneda>' + tipomonedaId + '</dbn:TipoMoneda>' +
                        '<!--Optional:-->' +
                        '<dbn:MntNeto>' + c.subTotal + '</dbn:MntNeto>' +
                        '<!--Optional:-->' +
                        '<dbn:MntExe>0.00</dbn:MntExe>' +
                        '<!--Optional:-->' +
                        '<dbn:MntExo>0.00</dbn:MntExo>' +
                        '<!--Optional:-->' +
                        '<dbn:MntTotal>' + c.total + '</dbn:MntTotal>' +
                        '<!--Optional:-->' +
                        '<dbn:FchEmis>' + newDate + '</dbn:FchEmis>' +
                        '<!--Optional:-->' +
                        '<dbn:Sustento>' + Sustento + '</dbn:Sustento>' +
                        '<!--Optional:-->' +
                        '<dbn:CodigoLocalAnexo>0000</dbn:CodigoLocalAnexo>' +
                        '<dbn:HoraEmision>' + c.horaEmisionDate.substr(11, 8) + '</dbn:HoraEmision> ' + leyenda +
                        '</dbn:camposEncabezado>' +
                        '</dbn:Encabezado>' +
                        '<!--Optional:-->' +
                        '<dbn:Detalles>';
                }
                else {
                    xmlrequest += '<!--Optional:-->' +
                    '<dbn:Encabezado>' +
                    '<!--Optional:-->' +
                    '<dbn:camposEncabezado>' +
                    '<!--Optional:-->' +
                    '<dbn:TipoDTE>' + c.comprobanteTipoId + '</dbn:TipoDTE>' +
                    '<!--Optional:-->' +
                    '<dbn:RUTEmis>' + ruc + '</dbn:RUTEmis>' +
                    '<!--Optional:-->' +
                    '<dbn:Serie>' + serie + '</dbn:Serie>' +
                    '<!--Optional:-->' +
                    '<dbn:Correlativo>' + correlativo + '</dbn:Correlativo>' +
                    '<!--Optional:--> ' +
                    '<dbn:RznSocEmis><![CDATA[' + razon_social + ']]></dbn:RznSocEmis>' +
                    '<!--Optional:-->' +
                    '<dbn:DirEmis><![CDATA[' + direccion + ']]></dbn:DirEmis>' +
                    '<!--Optional:-->' +
                    '<dbn:CodiComu>150141</dbn:CodiComu>' +
                    '<!--Optional:-->' +
                    '<dbn:NomComer><![CDATA[' + razon_social + ']]></dbn:NomComer>' +
                    '<!--Optional:-->' +
                    '<dbn:RUTRecep>' + c.clienteIdentidad + '</dbn:RUTRecep >' +
                    '<!--Optional:-->' +
                    '<dbn:TipoRutReceptor>' + tipoDocumento + '</dbn:TipoRutReceptor>' +
                    '<!--Optional:-->' +
                    '<dbn:RznSocRecep><![CDATA[' + c.clienteNombre + ']]></dbn:RznSocRecep>' +
                    '<!--Optional:-->' +
                    '<dbn:DirRecep><![CDATA[' + c.clienteDireccion + ']]></dbn:DirRecep>' +
                    '<!--Optional:-->' +
                    '<dbn:TipoMoneda>' + tipomonedaId + '</dbn:TipoMoneda>' +
                    '<!--Optional:-->' +
                    '<dbn:MntNeto>' + c.subTotal + '</dbn:MntNeto>' +
                    '<!--Optional:-->' +
                    '<dbn:MntExe>0.00</dbn:MntExe>' +
                    '<!--Optional:-->' +
                    '<dbn:MntExo>0.00</dbn:MntExo>' +
                    '<!--Optional:-->' +
                    '<dbn:MntTotalIgv>' + c.ivaTotal + '</dbn:MntTotalIgv>' +
                    '<!--Optional:-->' +
                    '<dbn:MntTotal>' + c.total + '</dbn:MntTotal>' +
                    '<!--Optional:-->' +
                    '<dbn:FchEmis>' + newDate + '</dbn:FchEmis>' +
                    '<!--Optional:-->' +
                    '<dbn:FechVencFact>' + newDateVenci + '</dbn:FechVencFact>' +
                    '<!--Optional:-->' +
                    '<dbn:Sustento>' + Sustento + '</dbn:Sustento>' +
                    '<!--Optional:-->' +
                    '<dbn:TipoNotaCredito>' + TipoNota + '</dbn:TipoNotaCredito>' +
                    '<!--Optional:-->' +
                    '<dbn:CodigoLocalAnexo>0000</dbn:CodigoLocalAnexo>' +
                    '<dbn:HoraEmision>' + c.horaEmisionDate.substr(11, 8) + '</dbn:HoraEmision> ' + leyenda +
                    '</dbn:camposEncabezado>' +
                    '<!--Optional:-->' +
                    '<dbn:ImptoReten>' +
                    '<!--Zero or more repetitions:-->' +
                    '<dbn:ImptoReten>' +
                    '<!--Optional:-->' +
                    '<dbn:CodigoImpuesto>1000</dbn:CodigoImpuesto>' +
                    '<!--Optional:-->' +
                    '<dbn:TasaImpuesto>18</dbn:TasaImpuesto>' +
                    '<!--Optional:-->' +
                    '<dbn:MontoImpuesto>' + c.ivaTotal + '</dbn:MontoImpuesto>' +
                    '</dbn:ImptoReten>' +
                    '</dbn:ImptoReten>' + detraccion +
                    '</dbn:Encabezado>' +
                    '<!--Optional:-->' +
                    '<dbn:Detalles>';
                }
                
                var i = 0;

                $.each(c.comprobantedetalle, function (index, d) {
                    i += 1;

                    let montoItem = parseFloat(d.precioUnitario * d.cantidad, 2);
                    let PrecioUnitarioSinIGV = parseFloat(d.precioUnitario / 1.18, 4);
                    let PrecioItemSinIGV = parseFloat((PrecioUnitarioSinIGV * d.cantidad), 2);
                    let PrecioTotalSinIGV = parseFloat(d.precioTotal / 1.18, 2);
                    let IGVLinea = parseFloat((d.precioTotal - PrecioTotalSinIGV), 2);
                    if (c.TipoOperacionId == '1003') {
                        xmlrequest += '<!--Zero or more repetitions:-->' +
						'<dbn:Detalle>' +
						'<!--Optional:-->' +
						'<dbn:Detalles>' +
							'<!--PRODUCTO 1:-->' +
							'<dbn:NroLinDet>' + i + '</dbn:NroLinDet>' +
							'<!--Optional:-->' +
							'<dbn:QtyItem>' + d.cantidad + '</dbn:QtyItem>' +
							'<!--Optional:-->' +
							'<dbn:UnmdItem>' + d.unidadMedidaId + '</dbn:UnmdItem>' +
							'<!--Optional:-->' +
							'<dbn:VlrCodigo>' + d.productoId + '</dbn:VlrCodigo>' +
							'<!--Optional:-->' +
							'<dbn:NmbItem><![CDATA[' + d.productoNombre + ']]></dbn:NmbItem>' +
							'<!--Optional:-->' +
							'<dbn:PrcItem>' + d.precioUnitario + '</dbn:PrcItem>' +
							'<!--Optional:-->' +
							'<dbn:PrcItemSinIgv>' + PrecioUnitarioSinIGV +'</dbn:PrcItemSinIgv>' +
							'<!--Optional:-->' +
							'<dbn:MontoItem>' + PrecioItemSinIGV + '</dbn:MontoItem>' +
							'<!--Optional:-->' +
							'<dbn:IndExe>20</dbn:IndExe>' +
							'<!--Optional:-->' +
							'<dbn:CodigoTipoIgv>9997</dbn:CodigoTipoIgv>' +
							'<!--Optional:-->' +
							'<dbn:TasaIgv>0</dbn:TasaIgv>' +
							'<!--Optional:-->' +
							'<dbn:ImpuestoIgv>0.00</dbn:ImpuestoIgv>' +
							'<dbn:MontoBaseImp>' + PrecioItemSinIGV +'</dbn:MontoBaseImp>' +
							'</dbn:Detalles>' +
						'</dbn:Detalle>';
                    }
                    else if (c.TipoOperacionId == '1002') {
                        xmlrequest += '<!--Zero or more repetitions:-->' +
                        '<dbn:Detalle>' +
                        '<!--Optional:-->' +
                        '<dbn:Detalles>' +
                            '<!--PRODUCTO 1:-->' +
                            '<dbn:NroLinDet>' + i + '</dbn:NroLinDet>' +
                            '<!--Optional:-->' +
                            '<dbn:QtyItem>' + d.cantidad + '</dbn:QtyItem>' +
                            '<!--Optional:-->' +
                            '<dbn:UnmdItem>' + d.unidadMedidaId + '</dbn:UnmdItem>' +
                            '<!--Optional:-->' +
                            '<dbn:VlrCodigo>' + d.productoId + '</dbn:VlrCodigo>' +
                            '<!--Optional:-->' +
                            '<dbn:NmbItem><![CDATA[' + d.productoNombre + ']]></dbn:NmbItem>' +
                            '<!--Optional:-->' +
                            '<dbn:PrcItem>' + d.precioUnitario + '</dbn:PrcItem>' +
                            '<!--Optional:-->' +
                            '<dbn:PrcItemSinIgv>' + PrecioUnitarioSinIGV + '</dbn:PrcItemSinIgv>' +
                            '<!--Optional:-->' +
                            '<dbn:MontoItem>' + PrecioItemSinIGV + '</dbn:MontoItem>' +
                            '<!--Optional:-->' +
                            '<dbn:IndExe>30</dbn:IndExe>' +
                            '<!--Optional:-->' +
                            '<dbn:CodigoTipoIgv>9998</dbn:CodigoTipoIgv>' +
                            '<!--Optional:-->' +
                            '<dbn:TasaIgv>0</dbn:TasaIgv>' +
                            '<!--Optional:-->' +
							'<dbn:ImpuestoIgv>' + IGVLinea + '</dbn:ImpuestoIgv>' +
                            '<!--Optional:-->' +
                            '<dbn:MontoBaseImp>' + PrecioItemSinIGV + '</dbn:MontoBaseImp>' +
                            '</dbn:Detalles>' +
                        '</dbn:Detalle>';
                    }
                    else if (c.TipoOperacionId == '1004') {
                        xmlrequest += '<!--Zero or more repetitions:-->' +
                        '<dbn:Detalle>' +
                        '<!--Optional:-->' +
                        '<dbn:Detalles>' +
                            '<!--PRODUCTO 1:-->' +
                            '<dbn:NroLinDet>' + i + '</dbn:NroLinDet>' +
                            '<!--Optional:-->' +
                            '<dbn:QtyItem>' + d.cantidad + '</dbn:QtyItem>' +
                            '<!--Optional:-->' +
                            '<dbn:UnmdItem>' + d.unidadMedidaId + '</dbn:UnmdItem>' +
                            '<!--Optional:-->' +
                            '<dbn:VlrCodigo>' + d.productoId + '</dbn:VlrCodigo>' +
                            '<!--Optional:-->' +
                            '<dbn:NmbItem><![CDATA[' + d.productoNombre + ']]></dbn:NmbItem>' +
                            '<!--Optional:-->' +
                            '<dbn:PrcItem>' + d.precioUnitario + '</dbn:PrcItem>' +
                            '<!--Optional:-->' +
                            '<dbn:PrcItemSinIgv>' + PrecioUnitarioSinIGV + '</dbn:PrcItemSinIgv>' +
                            '<!--Optional:-->' +
                            '<dbn:MontoItem>' + PrecioItemSinIGV + '</dbn:MontoItem>' +
                            '<!--Optional:-->' +
                            '<dbn:IndExe>40</dbn:IndExe>' +
                            '<!--Optional:-->' +
                            '<dbn:CodigoTipoIgv>9995</dbn:CodigoTipoIgv>' +
                            '<!--Optional:-->' +
                            '<dbn:TasaIgv>0</dbn:TasaIgv>' +
                            '<!--Optional:-->' +
							'<dbn:ImpuestoIgv>' + IGVLinea + '</dbn:ImpuestoIgv>' +
                            '</dbn:Detalles>' +
                        '</dbn:Detalle>';
                    }
                    else if (c.TipoOperacionId == '1005') {
                        xmlrequest += '<!--Zero or more repetitions:-->' +
                        '<dbn:Detalle>' +
                        '<!--Optional:-->' +
                        '<dbn:Detalles>' +
                            '<!--PRODUCTO 1:-->' +
                            '<dbn:NroLinDet>' + i + '</dbn:NroLinDet>' +
                            '<!--Optional:-->' +
                            '<dbn:QtyItem>' + d.cantidad + '</dbn:QtyItem>' +
                            '<!--Optional:-->' +
                            '<dbn:UnmdItem>' + d.unidadMedidaId + '</dbn:UnmdItem>' +
                            '<!--Optional:-->' +
                            '<dbn:VlrCodigo>' + d.productoId + '</dbn:VlrCodigo>' +
                            '<!--Optional:-->' +
                            '<dbn:NmbItem><![CDATA[' + d.productoNombre + ']]></dbn:NmbItem>' +
                            '<!--Optional:-->' +
                            '<dbn:PrcItem>' + d.precioUnitario + '</dbn:PrcItem>' +
                            '<!--Optional:-->' +
                            '<dbn:PrcItemSinIgv>' + PrecioUnitarioSinIGV + '</dbn:PrcItemSinIgv>' +
                            '<!--Optional:-->' +
                            '<dbn:MontoItem>' + PrecioItemSinIGV + '</dbn:MontoItem>' +
                            '<!--Optional:-->' +
                            '<dbn:IndExe>13</dbn:IndExe>' +
                            '<!--Optional:-->' +
                            '<dbn:CodigoTipoIgv>9996</dbn:CodigoTipoIgv>' +
                            '<!--Optional:-->' +
                            '<dbn:TasaIgv>18</dbn:TasaIgv>' +
                            '<!--Optional:-->' +
							'<dbn:ImpuestoIgv>' + IGVLinea + '</dbn:ImpuestoIgv>' +
                            '</dbn:Detalles>' +
                        '</dbn:Detalle>';
                    }
                    else {
                        xmlrequest += '<!--Zero or more repetitions:-->' +
                        '<dbn:Detalle>' +
                        '<!--Optional:-->' +
                        '<dbn:Detalles>' +
                        '<!--PRODUCTO 1:-->' +
                        '<dbn:NroLinDet>' + i + '</dbn:NroLinDet>' +
                        '<!--Optional:-->' +
                        '<dbn:QtyItem>' + d.cantidad + '</dbn:QtyItem>' +
                        '<!--Optional:-->' +
                        '<dbn:UnmdItem>' + d.unidadMedidaId + '</dbn:UnmdItem>' +
                        '<!--Optional:-->' +
                        '<dbn:VlrCodigo>' + d.productoId + '</dbn:VlrCodigo>' +
                        '<!--Optional:-->' +
                        '<dbn:NmbItem><![CDATA[' + d.productoNombre + ']]></dbn:NmbItem>' +
                        '<!--Optional:-->' +
                        '<dbn:PrcItem>' + d.precioUnitario + '</dbn:PrcItem>' +
                        '<!--Optional:-->' +
                        '<dbn:PrcItemSinIgv>' + PrecioUnitarioSinIGV + '</dbn:PrcItemSinIgv>' +
                        '<!--Optional:-->' +
                        '<dbn:MontoItem>' + PrecioItemSinIGV + '</dbn:MontoItem>' +
                        '<!--Optional:-->' +
                        '<dbn:IndExe>10</dbn:IndExe>' +
                        '<!--Optional:-->' +
                        '<dbn:CodigoTipoIgv>1000</dbn:CodigoTipoIgv>' +
                        '<!--Optional:-->' +
                        '<dbn:TasaIgv>18</dbn:TasaIgv>' +
                        '<!--Optional:-->' +
                        '<dbn:ImpuestoIgv>' + IGVLinea + '</dbn:ImpuestoIgv>' +
                        '</dbn:Detalles>' +
                        '</dbn:Detalle > ';
                    }
                    
                });
                xmlrequest += '</dbn:Detalles>' +
                    '<!--Optional:-->' +
                    '<dbn:DescuentosRecargosyOtros>';
                
                xmlrequest += adicionales;
                
                xmlrequest += referencia;
                
                xmlrequest += '</dbn:DescuentosRecargosyOtros>' +
                    '</dbn:putCustomerETDLoad>' +
                    '</soapenv:Body>' +
                    '</soapenv:Envelope>';

                var req = {
                    Xml: xmlrequest,
                    Ruc: ruc,
                    Serie: serie,
                    Folio: correlativo,
                    IdComprobante: c.id
                };

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/comprobante/GenerarComprobanteElectronicoPago',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(req),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });
                
                $.when(r1).done(function (response) {
                    alert(response);
                    self.funciones.llenarFormulario(self);
                    console.log(response);
                });
            },
            GenerarAnulacionComprobanteElectronicoPago: function (self) {
                var fech = self.$txtFechaAnulacion.val();//aqui poner las cajas de texto
                var moti = self.$txtMotivoAnulacion.val();//aqui poner las cajas de texto
                var c = self.objComprobante;
                var ruc = sessionStorage.getItem('empresa');
                var serie = c.serie;
                var correlativo = c.correlativo;
                //moment(new Date()).format("YYYY-MM-DD");
                var fechaEmi = c.fechaEmitido;

                //var oldDate = ToDate(fech); //esta variable no se usa
                var newDate = c.fechaEmitido;

                var notas = [7, 8];
                var TipoNota = '';
                var Sustento = '';

                var referencia = '';

                var xmlrequest = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:dbn="http://www.dbnet.cl">' +
                    '<soapenv:Header/>' +
                    '<soapenv:Body>' +
                    '<dbn:cargaBajas>' +
                    '<dbn:RUC>' + ruc + '</dbn:RUC>';

                xmlrequest += '<!--Optional:-->' +
                    '<dbn:ArchivoBajas>' +
                    '<dbn:bajas>' +
                    '<dbn:Tipo_Docu>' + c.comprobanteTipoId + '</dbn:Tipo_Docu>' +
                    '<!--Optional: -->' +
                    '<dbn:Serie_Inte>' + serie + '</dbn:Serie_Inte>' +
                    '<!--Optional:-->' +
                    '<dbn:Foli_Inte>' + correlativo + '</dbn:Foli_Inte>' +
                    '<!--Optional:-->' +
                    '<dbn:Fech_Emis>' + newDate + '</dbn:Fech_Emis>' +
                    '<!--Optional:-->' +
                    '<dbn:Motiv_Anul>' + moti + '</dbn:Motiv_Anul>' +
                    '</dbn:bajas>' +
                    '</dbn:ArchivoBajas>';

                var i = 0;

                xmlrequest += '</dbn:cargaBajas>' +
                    '</soapenv:Body>' +
                    '</soapenv:Envelope>';

                var req = {
                    Xml: xmlrequest,
                    Ruc: ruc,
                    Serie: serie,
                    Folio: correlativo,
                    MotivoAnulacion: moti,
                    IdComprobante: c.id,
                    UsuarioId: sessionStorage.getItem('userId')
                };

                var r1 = $.ajax({
                    url: C.Vars.rutaSERV + '/api/comprobante/GenerarAnulacionComprobanteElectronicoPago',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(req),
                    headers: C.Base.auntenticar(),
                    statusCode: {
                        401: function () {
                            win.location.href = C.Vars.rutaAPP + "/seguridad/Login";
                        }
                    }
                });

                $.when(r1).done(function (response) {
                    alert(response);
                    self.funciones.llenarFormulario(self);
                    console.log(response);
                });
                    
            },
            llenarFormulario: function (self) {
                var r1 = self.funciones.obtenerComprobante(self.codComprobante);
                $.when(r1).done(function (response) {
                    console.log(response);
                    var tituloPagina = 'COMPROBANTE NRO: &nbsp;&nbsp;&nbsp;<label style="color:red;">' + response.serie + ' - 0000' + response.correlativo + '</label>';
                    $('.page-title').html(tituloPagina);
                    self.objComprobante = response;
                    let r2 = self.funciones.obtenerTablaDato('comprobanteestado');
                    let estados = [];
                    $.when(r2).done(function (tdresponse) {
                        estados = tdresponse;
                        var botones = ''
                        botones = '<button id="btnEnvioSunat" class="btn btn-danger pull-right m-r-30">' +
                            '<i class="fa fa-send m-r-5"></i><span>Envio Sunat</span>' +
                            '</button>';
                        
                        if (response.estado == 6) {
                            //self.txtEstado.val(response.estadoNombre);
                            self.txtEstado.val('Anulado');
                            self.txtEstado.css('color', 'red');
                            self.$botonesAccion.hide();
                            self.divComboEstados.hide();
                            self.divTxtEstado.show();
                        }
                        else if (response.estado == 1) {
                            self.txtEstado.val('Pendiente');
                            self.txtEstado.css('color', 'orange');
                            self.$botonesAccion.show();
                            self.divComboEstados.hide();
                            self.divTxtEstado.show();
                            botones = '<div class="row">';
                            botones += '<div class="col-md-6">';
                            botones += '<button id="btnEnvioSunat" class="btn btn-danger pull-right m-r-30">' +
                                '<i class="fa fa-send m-r-5"></i><span>Envio Sunat</span>' +
                                '</button>';
                            botones += '</div><div class="col-md-6">';
                            botones += '<button id="btnEditarComprobante" class="btn btn-primary pull-right">' +
                                '<i class="fa fa-edit m-r-5"></i><span>Editar Comprobante</span>' +
                                '</button>';
                            botones += '</div></div>';
                            
                        }
                        else if (response.estado == 3) {
                            estados.length = 2; // solo dejar los dos primeros ( si cambia el orden en la BD se va a la MMMM)
                            self.funciones.llenaComboEstados(self, estados, '3');
                            self.$botonesAccion.hide();
                            self.divComboEstados.show();
                            self.divTxtEstado.hide();
                        }
                        else if (response.estado == 2 && response.comprobanteTipoId == '3') {
                            estados.length = 2;
                            self.funciones.llenaComboEstados(self, estados, '2');
                            self.$botonesAccion.hide();
                            self.divComboEstados.show();
                            self.divTxtEstado.hide();
                        }
                        else if (response.estado == 2) {
                            self.txtEstado.val('Enviado a la Suite');
                            self.txtEstado.css('color', 'orange');
                            self.$botonesAccion.hide();
                            self.divComboEstados.hide();
                            self.$divAnulacion.hide();
                            self.divTxtEstado.show();
                        }
                        else if (response.estado == 5) {
                            self.txtEstado.val('Enviado Anular a Suite');
                            self.txtEstado.css('color', 'orange');
                            self.$botonesAccion.hide();
                            self.divComboEstados.hide();
                            self.divTxtEstado.show();
                        }
                        else {
                            estados.splice(2, 1);
                            self.funciones.llenaComboEstados(self, estados, response.estado + '');
                            self.$botonesAccion.hide();
                            self.divComboEstados.show();
                            self.divTxtEstado.hide();
                        }

                        self.$botonesAccion.html(botones);

                        self.txtTipoDocumento.val(response.comprobanteTipoNombre);
                        self.txtNombreCliente.val(response.clienteNombre);
                        self.txtRuc.val(response.clienteIdentidad);
                        var fechaEm = response.fechaEmitido;
                        self.txtFecha.val(fechaEm.substr(8, 2) + '/' + fechaEm.substr(5, 2) + '/' + fechaEm.substr(0, 4));

                        self.txtSerie.val(response.serie);
                        self.txtEmail.val(response.clienteCorreo);
                        self.txtDireccion.val(response.clienteDireccion);
                        var fechaVen = response.fechaVencimiento;
                        self.txtFechaVencimiento.val(fechaVen.substr(8, 2) + '/' + fechaVen.substr(5, 2) + '/' + fechaVen.substr(0, 4));
                        self.txtMoneda.val(response.tipoMonedaId);
                        self.txtTipoCambio.val(response.tipoCambio);
                        self.txtTipoOperacion.val(response.tipoOperacionNombre);
                        self.txtDetraccion.val(response.detraccionNombre);
                        self.txtNroOC.val(response.nroOC);
                        self.txtTipoNota.val(response.tipoNotaNombre);
                        self.txtSerieRef.val(response.serieRef);
                        self.txtCorrelativoRef.val(response.correlativoRef);
                        self.txtSubTotal.val(response.subTotal);
                        self.txtIva.val(response.iva);
                        self.txtIvaSubTotal.val(response.ivaTotal);
                        self.txtTotal.val(response.total);
                        self.$txtMedioPago.val(response.medioPagoNombre);
                        if (response.glosa != '') {
                            self.trGlosa.show();
                            self.txtGlosa.html(response.glosa);
                        }
                        if (response.comprobanteTipoId == '7' || response.comprobanteTipoId == '8') {
                            self.divReferencia.show();
                            self.divTipoOperacion.hide();
                        }
                        else if (response.comprobanteTipoId == '1') {
                            self.trSubTotal.show();
                            self.trIva.show();
                            self.spIdentidad.html('RUC');
                            self.txtRuc.attr('placeholder', 'RUC');
                            self.divReferencia.hide();
                            self.divTipoOperacion.show();
                        }
                        else if (response.comprobanteTipoId == '3') {
                            self.trSubTotal.hide();
                            self.trIva.hide();
                            self.spIdentidad.html('DNI');
                            self.txtRuc.attr('placeholder', 'DNI');
                            self.divReferencia.hide();
                            self.divTipoOperacion.show();
                        }
                        else {
                            self.spIdentidad.html('DNI');
                            self.txtRuc.attr('placeholder', 'DNI');
                            self.divReferencia.remove();
                            self.divTipoOperacion.hide();
                        }

                        if (response.tipoMonedaId == 'S/') self.divTipoCambio.remove();

                        if (response.TipoOperacionId == '1001') {
                            self.divDetraccion.show();
                        }
                        else {
                            self.divDetraccion.hide();
                        }
                        C.Interfaz.llenarGrilla(self.grilla, response.comprobantedetalle);
                    });
                });
            },
            llenaDatosinicio: function (self) {
                
                var hoy = new Date();
                self.$txtFechaAnulacion.datepicker('setDate', hoy);

                self.grilla.DataTable({
                    language: C.Vars.lenguajeGrilla,
                    searching: false,
                    lengthChange: false,
                    paging: false,
                    info: false,
                    columns: [
                        { title: "Item", data: 'productoNombre' },
                        { title: "Cantidad", data: 'cantidad' },
                        { title: "UND", data: 'unidadMedidaId' },
                        { title: "P.U", data: 'precioUnitario' },
                        { title: "P.T", data: 'precioTotal' },
                    ]
                });

                if (self.codComprobante != '') {
                    self.funciones.llenarFormulario(self);
                }
                else {
                    alert('no se encontró el comprobante');
                }
                
            }
        },
        eventos: {
            botones: function (self) {
                $el.on('click', self.btnEnvioSunat, function (e) {
                    e.preventDefault();
                    self.funciones.GenerarComprobanteElectronicoPago(self);
                });

                $el.on('click', self.btnEditarComprobante, function (e) {
                    e.preventDefault();
                    win.location.href = C.Vars.rutaAPP + '/Comprobantes/Nuevo?idComp=' + self.codComprobante;
                });

                $el.on('click', self.btnAnulacion, function (e) {
                    e.preventDefault();
                    if (self.$txtMotivoAnulacion.val() != '') {
                        self.funciones.GenerarAnulacionComprobanteElectronicoPago(self);
                    }
                    else {
                        alert("Ingrese el motivo de anulación");
                    }
                });
                
                $el.on('click', self.ddlEstados, function (e) {
                    e.preventDefault();
                    if (self.$ddlEstados.val() == 5) {
                        self.$divAnulacion.show();
                    }
                    else {
                        self.$divAnulacion.hide();
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
        window.addEventListener("load", new Comprobante, false);
    } else if (window.attachEvent) {
        window.attachEvent("onload", new Comprobante);
    } else {
        window.onload = new Comprobante;
    }

})(APP, window, jQuery, _);