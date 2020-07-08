using System;
using System.Collections.Generic;

namespace Aplicacion.Entidades.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string EmpresaId { get; set; }
        public string Serie1 { get; set; }
        public byte ComprobanteTipoId { get; set; }
        public long Correlativo { get; set; }
        public int Estado { get; set; }
        public bool? Proforma { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
