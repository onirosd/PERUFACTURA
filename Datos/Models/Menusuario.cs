using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class Menusuario
    {
        public int Id { get; set; }
        public string UsuarioTipoId { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
