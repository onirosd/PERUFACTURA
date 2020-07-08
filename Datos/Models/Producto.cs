using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Almacen = new HashSet<Almacen>();
            Proformadetalle = new HashSet<Proformadetalle>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedidaId { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Stock { get; set; }
        public decimal? StockMinimo { get; set; }
        public string Marca { get; set; }
        public string EmpresaId { get; set; }

        public virtual ICollection<Almacen> Almacen { get; set; }
        public virtual ICollection<Proformadetalle> Proformadetalle { get; set; }
    }
}
