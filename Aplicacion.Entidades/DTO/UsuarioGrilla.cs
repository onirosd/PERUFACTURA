using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades.DTO
{
    public class UsuarioGrilla
    {
        public string IdUsuario { get; set; }
        public string NombrePersona { get; set; }
        public string NombreUsuario { get; set; }
        public string IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Empresa_id { get; set; }
    }

    public class UsuarioGrillaRequest
    {
        public string NombrePersona { get; set; }
        public string NombreUsuario { get; set; }
        public string Empresa_id { get; set; }
    }
}
