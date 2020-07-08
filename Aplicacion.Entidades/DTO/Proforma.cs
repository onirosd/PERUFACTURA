using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades.DTO
{
    public class ProformaByIdRequest
    {
        public long IdProforma { get; set; }
    }

    public class ProformaGuardarResponse
    {
        public long IdProforma { get; set; }
    }
}
