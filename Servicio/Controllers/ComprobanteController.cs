using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ent = Aplicacion.Entidades.Models;
using app = Aplicacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Datos.Entidades.Models;
using System.Security.Claims;
using dto = Aplicacion.Entidades.DTO;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;

namespace ServicioWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ComprobanteController : ControllerBase
    {
        [HttpPost]
        [Route("GenerarPDF")]
        public dto.ComprobanteElectronicoResponse GenerarPDF(dto.ComprobanteElectronicoRequest req)
        {
            dto.ComprobanteElectronicoResponse respuesta = new dto.ComprobanteElectronicoResponse();
            string URL_BASE = "http://comprobantes.perufactura.pe/wssconsultadocperu/consultaDocumentosPeru.asmx";
            //string url = URL_BASE + "/" + NombreMetodo;
            string url = URL_BASE;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8;";
            string postData = req.Xml;
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = byteArray.Length;

            using (var writeStream = request.GetRequestStream())
            {
                writeStream.Write(byteArray, 0, byteArray.Length);
            }

            string responseFromServer = string.Empty;
            string CodigoError = string.Empty;
            string NombreArchivo = string.Empty;
            string documento64 = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var respuestita = response.GetResponseStream();
                StreamReader reader = new StreamReader(respuestita);
                responseFromServer = reader.ReadToEnd();
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseFromServer);
                NombreArchivo = xmlDoc.GetElementsByTagName("string")[0].InnerText;
                documento64 = xmlDoc.GetElementsByTagName("string")[1].InnerText;
            }

            if (documento64 != string.Empty)
            {
                respuesta.Fichero = documento64;
                respuesta.NombreArchivo = NombreArchivo;
            }
            else
            {
                respuesta.Fichero = string.Empty;
                respuesta.NombreArchivo = string.Empty;
            }
            
            return respuesta;
        }

        [HttpPost]
        [Route("GenerarXML")]
        public dto.ComprobanteElectronicoResponse GenerarXML(dto.ComprobanteElectronicoRequest req)
        {
            dto.ComprobanteElectronicoResponse respuesta = new dto.ComprobanteElectronicoResponse();
            string URL_BASE = "http://comprobantes.perufactura.pe/wssconsultadocperu/consultaDocumentosPeru.asmx";
            //string url = URL_BASE + "/" + NombreMetodo;
            string url = URL_BASE;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8;";
            string postData = req.Xml;
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = byteArray.Length;

            using (var writeStream = request.GetRequestStream())
            {
                writeStream.Write(byteArray, 0, byteArray.Length);
            }

            string responseFromServer = string.Empty;
            string CodigoError = string.Empty;
            string NombreArchivo = string.Empty;
            string documento64 = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var respuestita = response.GetResponseStream();
                StreamReader reader = new StreamReader(respuestita);
                responseFromServer = reader.ReadToEnd();
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseFromServer);
                NombreArchivo = xmlDoc.GetElementsByTagName("string")[0].InnerText;
                documento64 = xmlDoc.GetElementsByTagName("string")[1].InnerText;
            }

            if (documento64 != string.Empty)
            {
                respuesta.Fichero = documento64;
                respuesta.NombreArchivo = NombreArchivo;
            }
            else
            {
                respuesta.Fichero = string.Empty;
                respuesta.NombreArchivo = string.Empty;
            }

            return respuesta;
        }

        [HttpPost]
        [Route("GenerarAnulacionComprobanteElectronicoPago")]
        public string GenerarAnulacionComprobanteElectronicoPago(dto.ComprobanteAnulacionElectronicaRequest req)
        {
            string URL_BASE = "http://13.68.199.98/wssCargaBajas/cargaBajas.asmx";
            string url = URL_BASE;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8;";
            string postData = req.Xml;
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = byteArray.Length;

            using (var writeStream = request.GetRequestStream())
            {
                writeStream.Write(byteArray, 0, byteArray.Length);
            }

            string responseFromServer = string.Empty;
            string CodigoError = string.Empty;
            string Mensajes = string.Empty;
            string TrackId = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var respuestita = response.GetResponseStream();
                StreamReader reader = new StreamReader(respuestita);
                responseFromServer = reader.ReadToEnd();
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseFromServer);
                CodigoError = xmlDoc.GetElementsByTagName("Codigo")[0].InnerText;
                Mensajes = xmlDoc.GetElementsByTagName("Mensajes")[0].InnerText;
                TrackId = xmlDoc.GetElementsByTagName("TrackId")[0].InnerText;
                var nombreArchivo = "Logs/" + req.Ruc + "_" + req.Serie + "_" + req.Folio + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".log";
                System.IO.File.WriteAllText(nombreArchivo, Mensajes);
            }

            string respuesta = string.Empty;
            //if (CodigoError.IndexOf("Error") == -1)
            //{
                dto.ComprobanteByIdRequest requestComprobante = new dto.ComprobanteByIdRequest();
                requestComprobante.IdComprobante = req.IdComprobante;
                new app.Comprobante().AnularComprobante(req, 5);
                respuesta = "El documento ha sido procesado con exito";
            //}
            //else
            //{
            //    respuesta.Mensaje = "Ha ocurrido un problema con el envio del documento.\nInfo:" + Mensajes;
            //}

            return respuesta;
        }
        [HttpPost]
        
        [HttpPost]
        [Route("GenerarComprobanteElectronicoPago")]
        public string GenerarComprobanteElectronicoPago(dto.ComprobanteElectronicoRequest req)
        {
            string URL_BASE = "http://13.68.199.98/wssCustomerETDLoadASPUBL21/CustomerETDLoadASP.asmx";
            //string url = URL_BASE + "/" + NombreMetodo;
            string url = URL_BASE;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8;";
            string postData = req.Xml;
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = byteArray.Length;

            using (var writeStream = request.GetRequestStream())
            {
                writeStream.Write(byteArray, 0, byteArray.Length);
            }
            var xmlDocRequest = new XmlDocument();
            xmlDocRequest.LoadXml(req.Xml);
            var nombreArchivo = "Archivos/ruc_" + req.Ruc + "_" + req.Serie + "_" + req.Folio + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".xml";
            xmlDocRequest.Save(nombreArchivo);

            string responseFromServer = string.Empty;
            string CodigoError = string.Empty;
            string Mensajes = string.Empty;
            string TrackId = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var respuestita = response.GetResponseStream();
                StreamReader reader = new StreamReader(respuestita);
                responseFromServer = reader.ReadToEnd();
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseFromServer);
                CodigoError = xmlDoc.GetElementsByTagName("Codigo")[0].InnerText;
                Mensajes = xmlDoc.GetElementsByTagName("Mensajes")[0].InnerText;
                TrackId = xmlDoc.GetElementsByTagName("TrackId")[0].InnerText;
                
            }

            string respuesta = string.Empty;
            if (CodigoError == "DOK")
            {
                dto.ComprobanteByIdRequest requestComprobante = new dto.ComprobanteByIdRequest();
                requestComprobante.IdComprobante = req.IdComprobante;
                new app.Comprobante().ActualizarEstadoComprobante(requestComprobante, 2);
                respuesta = "El documento ha sido procesado con exito";
            }
            else
            {
                respuesta = "Ha ocurrido un problema con el envio del documento.\nInfo:" + Mensajes;
            }

            return respuesta;
        }
        

        [HttpPost]
        [Route("ObtenerComprobanteById")]
        public ent.Comprobante ObtenerComprobanteById(dto.ComprobanteByIdRequest request)
        {
            return new app.Comprobante().ObtenerComprobanteById(request);
        }

        [HttpPost]
        [Route("ObtenerComprobantes")]
        public List<dto.ComprobanteGrilla> TraerTodo(dto.ComprobantesObtenerRequest request)
        {
            //AspNetUserRoles request
            return new app.Comprobante().ObtenerComprobantes(request);
        }

        [HttpPost]
        [Route("GuardarComprobante")]
        public dto.ComprobanteGuardarResponse GuardarComprobante(dto.ComprobanteGuardarRequest r)
        {
            return new app.Comprobante().GuardarComprobante(r);
        }

        [HttpPost]
        [Route("ObtenerReporteMesDetallado")]
        public List<dto.ReporteMesDetalladoResponse> ObtenerReporteMesDetallado(dto.ReporteMesDetalladoRequest r)
        {
            return new app.Comprobante().ObtenerReporteMesDetallado(r);
        }

        [HttpPost]
        [Route("ObtenerReporteMesDetalladoProforma")]
        public List<dto.ReporteMesDetalladoResponse> ObtenerReporteMesDetalladoProforma(dto.ReporteMesDetalladoRequest r)
        {
            return new app.Proforma().ObtenerReporteMesDetalladoProforma(r);
        }

        [HttpPost]
        [Route("ObtenerReporteTopProductos")]
        public List<dto.ReporteTopProductosResponse> ObtenerReporteTopProductos(dto.ReporteTopProductosRequest r)
        {
            return new app.Comprobante().ObtenerReporteTopProductos(r);
        }

        [HttpPost]
        [Route("ObtenerReporteTopEmpleados")]
        public List<dto.ReporteTopEmpleadosResponse> ObtenerReporteTopEmpleados(dto.ReporteTopEmpleadosRequest r)
        {
            return new app.Comprobante().ObtenerReporteTopEmpleados(r);
        }

        [HttpPost]
        [Route("ObtenerReporteTopClientes")]
        public List<dto.ReporteTopClientesResponse> ObtenerReporteTopClientes(dto.ReporteTopClientesRequest r)
        {
            return new app.Comprobante().ObtenerReporteTopClientes(r);
        }

        [HttpPost]
        [Route("ObtenerReporteAnual")]
        public List<dto.ReporteAnualResponse> ObtenerReporteAnual(dto.ReporteAnualRequest r)
        {
            return new app.Comprobante().ObtenerReporteAnual(r);
        }

        [HttpPost]
        [Route("ObtenerReporteMensual")]
        public List<dto.ReporteMensualResponse> ObtenerReporteMensual(dto.ReporteMensualRequest r)
        {
            return new app.Comprobante().ObtenerReporteMensual(r);
        }

        [HttpPost]
        [Route("ObtenerReporteDiario")]
        public List<dto.ReporteDiarioResponse> ObtenerReporteDiario(dto.ReporteDiarioRequest r)
        {
            return new app.Comprobante().ObtenerReporteDiario(r);
        }
    }
}