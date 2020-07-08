using System;
using System.Collections.Generic;

namespace Aplicacion.Entidades.Models
{
    public class Comprobante
    {
        public Comprobante()
        {
            Comprobantedetalle = new HashSet<Comprobantedetalle>();
            Proformadetalle = new HashSet<Proformadetalle>();
        }

        public long Id { get; set; }
        public string EmpresaId { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public int ClienteId { get; set; }
        public string ClienteIdentidad { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClienteCorreo { get; set; }
        public byte ComprobanteTipoId { get; set; }
        public byte Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaEmitido { get; set; }
        public decimal Iva { get; set; }
        public decimal IvaTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalCompra { get; set; }
        public decimal Ganancia { get; set; }
        public string UsuarioId { get; set; }
        public string Glosa { get; set; }
        public byte Impresion { get; set; }
        public int? UsuarioImprimiendoId { get; set; }
        public byte Devolucion { get; set; }
        public string ComprobanteTipoRefId { get; set; }
        public string SerieRef { get; set; }
        public string CorrelativoRef { get; set; }
        public string TipoNotaId { get; set; }
        public decimal? TipoCambio { get; set; }
        public string TipoMonedaId { get; set; }
        public string MotiAnulacion { get; set; }
        public string FechaAnulacion { get; set; }
        public int? TipoOperacionId { get; set; }
        public string DetraccionId { get; set; }
        public TimeSpan? HoraEmision { get; set; }
        public decimal? ValorDetraccion { get; set; }
        public string Codigo { get; set; }
        public string EstadoNombre { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string FechaVencimiento { get; set; }
        public string NroOC { get; set; }

        public string ComprobanteTipoNombre { get; set; }
        public string TipoOperacionNombre { get; set; }
        public string DetraccionNombre { get; set; }
        public string TipoNotaNombre { get; set; }
        public DateTime HoraEmisionDate { get; set; }
        public string MedioPago { get; set; }
        public string MedioPagoNombre { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Comprobantedetalle> Comprobantedetalle { get; set; }
        public virtual ICollection<Proformadetalle> Proformadetalle { get; set; }
    }
}
