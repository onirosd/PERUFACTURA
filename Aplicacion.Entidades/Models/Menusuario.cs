using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion.Entidades.Models
{
    public class Menusuario
    {
        
        public int UsuarioTipoId { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
