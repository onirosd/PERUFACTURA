using System;
using System.Collections.Generic;
using System.Text;
using ent = Aplicacion.Entidades.Models;
using dato = Datos.Entidades.Models;
using AutoMapper;
using dom = Dominio;
using System.Linq;
using dto = Aplicacion.Entidades.DTO;

namespace Aplicacion
{
    public class DataRuc
    {
        public ent.DataRuc ObtenerDataClienteSunat(string ruc)
        {
            var objClienteSunat = new dom.DataRuc().BuscarPrimero(c => c.Ruc == ruc);
            var Resultado = Mapper.Map<dato.DataRuc, ent.DataRuc>(objClienteSunat);
            return Resultado;
        }
    }
}
