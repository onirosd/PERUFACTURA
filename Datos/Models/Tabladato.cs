using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class Tabladato
    {
        public int Id { get; set; }
        public string Relacion { get; set; }
        public string Value { get; set; }
        public string Nombre { get; set; }
        public byte Orden { get; set; }
        public decimal? Value2 { get; set; }
    }
}
