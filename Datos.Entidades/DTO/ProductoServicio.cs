using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Entidades.DTO
{
    public class ProductoServicio
    {
        public int Id { get; set; }
        public string UnidadMedidaId { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? Precio { get; set; }
        public string Marca { get; set; }
        public string Nombre { get; set; }
        public decimal? Stock { get; set; }
        public int Tipo { get; set; }
    }
}
