using System;
using System.Collections.Generic;

namespace Aplicacion.Entidades.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? Precio { get; set; }
        public string UnidadMedidaId { get; set; }
        public string EmpresaId { get; set; }
    }
}
