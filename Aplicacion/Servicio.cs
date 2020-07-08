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
    public class Servicio
    {
        public dto.ErrorClass GuardarMasivoServicios(dto.ServiciosGuardarMasivoRequest request)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                foreach (var item in request.Servicios)
                {
                    var entidad = Mapper.Map<ent.Servicio, dato.Servicio>(item);
                    new dom.Servicio().Adicionar(entidad);
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

        public List<ent.Servicio> ObtenerServicios(dto.ServiciosObtenerRequest r)
        {
            var query = new dom.Servicio().Buscar(c=> c.EmpresaId == r.Empresa_id && c.Nombre.Contains(r.Nombre));
            var Resultado = Mapper.Map<IEnumerable<dato.Servicio>, IEnumerable<ent.Servicio>>(query);
            return Resultado.ToList();
        }

        public bool NuevoServicio(ent.Servicio r)
        {
            try
            {
                var entidad = Mapper.Map<ent.Servicio, dato.Servicio>(r);
                new dom.Servicio().Adicionar(entidad);
                return true;
            }
            catch (Exception Ex)
            {
                //throw Ex;
                return false;
            }
        }

        public bool EditarServicio(ent.Servicio r)
        {
            try
            {

                var entidad = Mapper.Map<ent.Servicio, dato.Servicio>(r);
                new dom.Servicio().Modificar(entidad);
                return true;
            }
            catch (Exception Ex)
            {

                return false;
            }
        }

        public dto.ErrorClass EliminarServicio(ent.Servicio r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                var contarComprobantes = new dom.ComprobanteDetalles().Buscar(c => c.ProductoId == r.Id && c.Tipo == ConstantesAplicacion.TipoServicio);
                if (contarComprobantes.Count() > 0)
                {
                    error.Error = true;
                    error.Mensaje = ConstantesErrores.NoEliminar;
                }
                else
                {
                    var entidad = Mapper.Map<ent.Servicio, dato.Servicio>(r);
                    new dom.Servicio().Eliminar(entidad);
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
