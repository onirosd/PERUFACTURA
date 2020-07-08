using System;
using System.Collections.Generic;

namespace Aplicacion.Entidades.Models
{
    public class Tabladato
    {
        public int Id { get; set; }
        public string Relacion { get; set; }
        public string Value { get; set; }
        public string Nombre { get; set; }
        public byte Orden { get; set; }
        public decimal? Value2 { get; set; }
    }
    public class Tipo
    {
        public string Relacion { get; set; }
    }
}
