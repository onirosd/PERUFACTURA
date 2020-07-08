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
    public class Empresa
    {
        public ent.Empresa ObtenerEmpresaUsuario(ent.EmpresaRequest r)
        {
            var objEmpresa = new dom.Empresa().BuscarPrimero(c => c.Id == r.Empresa_id);
            var Resultado = Mapper.Map<dato.Empresa, ent.Empresa>(objEmpresa);
            return Resultado;
        }
    }
}
