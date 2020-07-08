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
    public class Cliente
    {
        public dto.ErrorClass GuardarMasivoClientes(dto.ClienteGuardarMasivoRequest request)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                foreach (var item in request.Clientes)
                {
                    var entidad = Mapper.Map<ent.Cliente, dato.Cliente>(item);
                    new dom.Cliente().Adicionar(entidad);
                }
                error.Error = false;
                error.Mensaje = Mensajes.Guardado;
            }
            catch (Exception Ex)
            {
                error.Error = true;
                error.Mensaje = ConstantesErrores.NoControlado;
            }
            return error;
        }

        public List<ent.Cliente> ObtenerClientesByNombre(dto.ClienteObtenerRequest r)
        {
            var query = new dom.Cliente().Buscar(c => c.EmpresaId == r.Empresa_id && c.Nombre.Contains(r.Nombre));
            var Resultado = Mapper.Map<IEnumerable<dato.Cliente>, IEnumerable<ent.Cliente>>(query);
            return Resultado.ToList();
        }

        public List<ent.Cliente> ObtenerClientes(dto.ClienteObtenerRequest r)
        {
            var query = new dom.Cliente().Buscar(c => c.EmpresaId == r.Empresa_id && c.Nombre.Contains(r.Nombre) && c.NroDocumento.Contains(r.NroDocumento));
            var Resultado = Mapper.Map<IEnumerable<dato.Cliente>, IEnumerable<ent.Cliente>>(query);
            return Resultado.ToList();
        }

        public dto.ErrorClass NuevoCliente(ent.Cliente r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                var entidad = Mapper.Map<ent.Cliente, dato.Cliente>(r);
                var existe = new dom.Cliente().Buscar(c => c.NroDocumento == r.NroDocumento && c.TipoDocumentoId == r.TipoDocumentoId).Count();
                if (existe > 0)
                {
                    error.Error = true;
                    error.Mensaje = Mensajes.ClienteDuplicado;
                }
                else {
                    new dom.Cliente().Adicionar(entidad);
                    error.Error = false;
                    error.Mensaje = Mensajes.Guardado;
                }
                
            }
            catch (Exception Ex)
            {
                error.Error = true;
                error.Mensaje = ConstantesErrores.NoControlado;
            }
            return error;
        }

        public dto.ErrorClass EditarCliente(ent.Cliente r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                var entidad = Mapper.Map<ent.Cliente, dato.Cliente>(r);
                new dom.Cliente().Modificar(entidad);
                error.Error = false;
                error.Mensaje = Mensajes.Guardado;
            }
            catch (Exception Ex)
            {
                error.Error = true;
                error.Mensaje = ConstantesErrores.NoControlado;
            }
            return error;
        }

        public dto.ErrorClass EliminarCliente(ent.Cliente r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                var contarComprobantes = new dom.Comprobante().Buscar(c => c.ClienteId == r.Id);
                if (contarComprobantes.Count() > 0)
                {
                    error.Error = true;
                    error.Mensaje = ConstantesErrores.NoEliminar;
                }
                else
                {
                    var entidad = Mapper.Map<ent.Cliente, dato.Cliente>(r);
                    new dom.Cliente().Eliminar(entidad);
                    error.Error = false;
                }
            }
            catch (Exception Ex)
            {
                error.Error = true;
                error.Mensaje = ConstantesErrores.NoControlado;
            }
            return error;
        }
    }
}
