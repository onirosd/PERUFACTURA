using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades.DTO
{
    public class KardexGrilla
    {
        public long Id { get; set; }
        public byte Tipo { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string UnidadMedidaId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Stock { get; set; }
        public long? ComprobanteId { get; set; }
    }

    public class KardexGrillaRequestByFecha
    {
        public DateTime Fecha { get; set; }
        public string EmpresaId { get; set; }
    }
    public class KardexGrillaRequestByRango
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EmpresaId { get; set; }
    }
}
