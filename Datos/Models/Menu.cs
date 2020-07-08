using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Menusuario = new HashSet<Menusuario>();
        }

        public int Id { get; set; }
        public string Class { get; set; }
        public string Css { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public int Padre { get; set; }
        public byte? Orden { get; set; }
        public byte? Separador { get; set; }

        public virtual ICollection<Menusuario> Menusuario { get; set; }
    }
}
