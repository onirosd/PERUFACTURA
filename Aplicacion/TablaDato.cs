using System;
using System.Collections.Generic;
using System.Text;
using ent = Aplicacion.Entidades.Models;
using dato = Datos.Entidades.Models;
using AutoMapper;
using dom = Dominio;
using System.Linq;
using dto = Aplicacion.Entidades.DTO;
using Ayuda;

namespace Aplicacion
{
    public class TablaDato
    {
        public List<ent.Tabladato> ObtenerTipo(string relacion)
        {
            var query = new dom.TablaDato().Buscar(c => c.Relacion == relacion).ToList();
            var Resultado = Mapper.Map<List<dato.Tabladato>, List<ent.Tabladato>>(query);
            return Resultado;
        }

        public ent.Tabladato ObtenerTipoByValue(string relacion, string value)
        {
            var query = new dom.TablaDato().Buscar(c => c.Relacion == relacion && c.Value == value).FirstOrDefault();
            var Resultado = Mapper.Map<dato.Tabladato, ent.Tabladato>(query);
            return Resultado;
        }

        public ent.Tabladato ObtenerMoneda(string id)
        {
            var query = new dom.TablaDato().BuscarPrimero(c => c.Relacion == id);
            var Resultado = Mapper.Map<dato.Tabladato, ent.Tabladato>(query);
            return Resultado;
        }

    }
}
