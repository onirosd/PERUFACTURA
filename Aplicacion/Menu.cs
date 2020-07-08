using System;
using System.Collections.Generic;
using System.Text;
using ent = Aplicacion.Entidades.Models;
using dato = Datos.Entidades.Models;
using AutoMapper;
using dom = Dominio;
using System.Linq;

namespace Aplicacion
{
    public class Menu
    {
        public List<ent.Menu> ObtenerPermisos(string rolName)
        {
            var menu = new dom.Menu().BuscarByNombreRol(rolName);
            var Resultado = Mapper.Map<IEnumerable<dato.Menu>, IEnumerable<ent.Menu>>(menu);
            return Resultado.ToList();
            //return null;
        }
    }
}
