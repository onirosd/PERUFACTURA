using System;
using System.Collections.Generic;
using System.Text;
using ent = Aplicacion.Entidades.Models;

namespace Aplicacion.Entidades.DTO
{
    public class GenerarPDFRequest {

    }

    

    public class ComprobanteAnulacionElectronicaRequest
    {
        public long IdComprobante { get; set; }
        public string Ruc { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string Xml { get; set; }
        public string MotivoAnulacion { get; set; }
        public string UsuarioId { get; set; }
    }

    public class ComprobanteElectronicoResponse
    {
        public string NombreArchivo { get; set; }
        public string Fichero { get; set; }
    }

    public class ComprobanteElectronicoRequest
    {
        public long IdComprobante { get; set; }
        public string Ruc { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string Xml { get; set; }
    }

    public class ComprobantesObtenerRequest
    {
        public string Empresa_id { get; set; }
        public string Serie { get; set; }
        public string ClienteNombre { get; set; }
        public int? ComprobanteTipo_id { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaEmitidoInicio { get; set; }
        public DateTime? FechaEmitidoFin { get; set; }
    }

    public class ComprobanteGuardarRequest
    {
        public ent.Comprobante ComprobanteCabecera { get; set; }
        public IEnumerable<ent.Comprobantedetalle> ComprobanteDetalle { get; set; }
    }

    public class ComprobanteGuardarResponse
    {
        public long IdComprobante { get; set; }
    }

    public class ComprobanteByIdRequest
    {
        public long IdComprobante { get; set; }
    }

    public class ReporteMesDetalladoRequest
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string EmpresaId { get; set; }
        public string TipoMonedaId { get; set; }
    }

    public class ReporteMesDetalladoResponse
    {
        public string Documento { get; set; }
        public string Serie { get; set; }
        public int Correlativo { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public string Estado { get; set; }
    }

    public class ReporteTopProductosRequest
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string EmpresaId { get; set; }
        public string TipoMonedaId { get; set; }
    }

    public class ReporteTopProductosResponse
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Ganado { get; set; }
        public decimal Vendido { get; set; }
        public string UnidadMedidaId { get; set; }
    }

    public class ReporteTopEmpleadosRequest
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string EmpresaId { get; set; }
        public string TipoMonedaId { get; set; }
    }

    public class ReporteTopEmpleadosResponse
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Ganado { get; set; }
        public decimal Vendido { get; set; }
    }

    public class ReporteTopClientesRequest
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string EmpresaId { get; set; }
        public string TipoMonedaId { get; set; }
    }

    public class ReporteTopClientesResponse
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Ganancia { get; set; }
        public decimal Vendido { get; set; }
    }

    public class ReporteAnualRequest
    {
        public string EmpresaId { get; set; }
        public string TipoMonedaId { get; set; }
    }

    public class ReporteAnualResponse
    {
        public int AnioEmitido { get; set; }
        public decimal Boleta { get; set; }
        public decimal Factura { get; set; }
        public decimal Menudeo { get; set; }
        public decimal Debito { get; set; }
        public decimal Ganancia { get; set; }
        public decimal Vendido { get; set; }
    }

    public class ReporteMensualRequest
    {
        public int Anio { get; set; }
        public string EmpresaId { get; set; }
        public string TipoMonedaId { get; set; }
    }

    public class ReporteMensualResponse
    {
        public int MesEmitido { get; set; }
        public decimal Boleta { get; set; }
        public decimal Factura { get; set; }
        public decimal Menudeo { get; set; }
        public decimal Debito { get; set; }
        public decimal Ganancia { get; set; }
        public decimal Vendido { get; set; }
    }

    public class ReporteDiarioRequest
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string EmpresaId { get; set; }
        public string TipoMonedaId { get; set; }
    }

    public class ReporteDiarioResponse
    {
        public DateTime FechaEmitido { get; set; }
        public decimal Boleta { get; set; }
        public decimal Factura { get; set; }
        public decimal Menudeo { get; set; }
        public decimal Debito { get; set; }
        public decimal Ganancia { get; set; }
        public decimal Vendido { get; set; }
    }

    public class ComprobanteGrilla
    {
        public long Id { get; set; }
        public string EmpresaId { get; set; }
        public byte ComprobanteTipoId { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public string Codigo { get; set; }
        public string ClienteNombre { get; set; }
        public byte Estado { get; set; }
        public string EstadoNombre { get; set; }
        public string Tipo { get; set; }
        public DateTime? FechaEmitido { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public byte Impresion { get; set; }
        public string NombreUsuario { get; set; }
        public string UsuarioId { get; set; }
        public string ClienteIdentidad { get; set; }
    }
}
