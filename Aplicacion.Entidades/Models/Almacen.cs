using System;
using System.Collections.Generic;

namespace Aplicacion.Entidades.Models
{
    public class Almacen
    {
        public long Id { get; set; }
        public byte Tipo { get; set; }
        public string UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string UnidadMedidaId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? Fecha { get; set; }
        public string EmpresaId { get; set; }
        public long? ComprobanteId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }

    public class AlmacenRequest
    {
        public byte Tipo { get; set; }
        public string EmpresaId { get; set; }
    }
}
