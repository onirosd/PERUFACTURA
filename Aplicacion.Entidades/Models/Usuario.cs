using System;
using System.Collections.Generic;

namespace Aplicacion.Entidades.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Almacen = new HashSet<Almacen>();
        }

        public string Id { get; set; }
        public int Tipo { get; set; }
        public string Nombre { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
        public string EmpresaId { get; set; }

        public virtual ICollection<Almacen> Almacen { get; set; }
    }

    public class UsuarioNuevo
    {
        public string NombreUsuario { get; set; }
        public string NombrePersona { get; set; }
        public string EmpresaId { get; set; }
        public string RoleId { get; set; }
        public string IdUsuario { get; set; }

    }
}
