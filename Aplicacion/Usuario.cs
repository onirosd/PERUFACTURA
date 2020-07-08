using System;
using System.Collections.Generic;
using System.Text;
using ent = Aplicacion.Entidades.Models;
using dato = Datos.Entidades.Models;
using datoDto = Datos.Entidades.DTO;
using AutoMapper;
using dom = Dominio;
using System.Linq;
using dto = Aplicacion.Entidades.DTO;
using Ayuda;

namespace Aplicacion
{
    public class Usuario
    {
        public ent.Usuario ObtenerUsuario(ent.EmpresaRequest r)
        {
            var objusuario = new dom.Usuario().BuscarPrimero(c => c.Id == r.Id && c.EmpresaId == r.Empresa_id);
            var Resultado = Mapper.Map<dato.Usuario, ent.Usuario>(objusuario);
            return Resultado;
        }

        public List<dto.UsuarioGrilla> ObtenerUsuarios(dto.UsuarioGrillaRequest r)
        {
            var request = Mapper.Map<dto.UsuarioGrillaRequest, datoDto.UsuarioGrillaRequest>(r);
            var query = new dom.Usuario().BuscarUsuarios(request);
            var Resultado = Mapper.Map<IEnumerable<datoDto.UsuarioGrilla>, IEnumerable<dto.UsuarioGrilla>>(query);
            return Resultado.ToList();
        }

        public List<ent.AspNetRoles> ObtenerTipoUsuarios()
        {
            var query = new dom.AspNetRoles().ObtenerAllRoles();
            var Resultado = Mapper.Map<IEnumerable<dato.AspNetRoles>, IEnumerable<ent.AspNetRoles>>(query);
            return Resultado.ToList();
        }

        public bool NuevoUsuario(ent.UsuarioNuevo r)
        {
            try
            {
                return new dom.Usuario().InsertarUsuario(r.NombreUsuario, r.NombrePersona, r.EmpresaId, r.RoleId);
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public bool EditarUsuario(ent.UsuarioNuevo r)
        {
            try
            {
                var consulta = new dom.Usuario().BuscarPorId(r.IdUsuario);
                consulta.Nombre = r.NombrePersona;
                new dom.Usuario().EditarRol(consulta.Id, r.RoleId);
                new dom.Usuario().Modificar(consulta);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
    }
}
