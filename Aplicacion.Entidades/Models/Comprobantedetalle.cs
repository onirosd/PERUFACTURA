using System;
using System.Collections.Generic;

namespace Aplicacion.Entidades.Models
{
    public class Comprobantedetalle
    {
        public long Id { get; set; }
        public byte? Tipo { get; set; }
        public long ComprobanteId { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public decimal? PrecioUnitarioCompra { get; set; }
        public decimal? PrecioTotalCompra { get; set; }
        public string UnidadMedidaId { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? PrecioTotal { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Devuelto { get; set; }
        public decimal? Ganancia { get; set; }

        public virtual Comprobante Comprobante { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
