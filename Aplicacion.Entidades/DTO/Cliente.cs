using Aplicacion.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades.DTO
{
    public class ClienteObtenerRequest
    {
        public string Empresa_id { get; set; }
        public string Nombre { get; set; }
        public string NroDocumento { get; set; }
    }

    public class ClienteGuardarMasivoRequest
    {
        public List<Cliente> Clientes { get; set; }
    }
}
