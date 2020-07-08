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
    public class Configuracion
    {
        public ent.Configuracion ObtenerConfiguracion(dto.ConfiguracionRequest r)
        {
            var objEmpresa = new dom.Configuracion().BuscarPrimero(c => c.EmpresaId == r.Empresa_id);
            var Resultado = Mapper.Map<dato.Configuracion, ent.Configuracion>(objEmpresa);
            Resultado.NombreMoneda = new dom.TablaDato().BuscarPrimero(c => c.Value == Resultado.MonedaId).Nombre;
            return Resultado;
        }

        public dto.ErrorClass EditarConfiguracion(ent.Configuracion r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {

                var entidad = Mapper.Map<ent.Configuracion, dato.Configuracion>(r);
                new dom.Configuracion().Modificar(entidad);
                error.Error = false;
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
