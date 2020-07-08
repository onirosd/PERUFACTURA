using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Entidades.DTO
{
    public class ProformaGrilla
    {
        public int Id { get; set; }
        public string EmpresaId { get; set; }
        public int ComprobanteTipoId { get; set; }
        public string Serie { get; set; }
        public string Codigo { get; set; }
        public string ClienteNombre { get; set; }
        public int Estado { get; set; }
        public string EstadoNombre { get; set; }
        public string Tipo { get; set; }
        public string FechaEmitido { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int Impresion { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
    }

    public class ProformaGrillaRequest
    {
        public string EmpresaId { get; set; }
        public string Serie { get; set; }
        public string ClienteNombre { get; set; }
        public string Usuario { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int Estado { get; set; }
    }
}
