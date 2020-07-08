using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Entidades.DTO
{
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
