using Aplicacion.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades.DTO
{
    public class ServiciosObtenerRequest
    {
        public string Nombre { get; set; }
        public string Empresa_id { get; set; }
    }

    public class ServiciosGuardarMasivoRequest
    {
        public List<Servicio> Servicios { get; set; }
    }
}
