using System;
using System.Collections.Generic;

namespace Aplicacion.Entidades.Models
{
    public class Empresa
    {
        public Empresa()
        {
            Comprobante = new HashSet<Comprobante>();
            Proforma = new HashSet<Proforma>();
            Serie = new HashSet<Serie>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public byte Estado { get; set; }

        public virtual ICollection<Comprobante> Comprobante { get; set; }
        public virtual ICollection<Proforma> Proforma { get; set; }
        public virtual ICollection<Serie> Serie { get; set; }
    }

    public class EmpresaRequest
    {
        public string Id { get; set; }
        public string Empresa_id { get; set; }
    }
}
