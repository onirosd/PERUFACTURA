using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Entidades.DTO
{
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
}
