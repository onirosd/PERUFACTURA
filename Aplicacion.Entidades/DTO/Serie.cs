using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades.DTO
{
    public class SerieRequest
    {
        public string EmpresaId { get; set; }
        public string Serie { get; set; }
        public byte ComprobanteTipoId { get; set; }
        public bool? Proforma { get; set; }
    }
}
