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
    public class ReporteResumenBasico
    {
        public dto.ReporteResumenBasico ObtenerReporteResumenBasico(string EmpresaId)
        {
            var query = new dom.ReporteResumenBasico().ObtenerReporteResumenBasico(EmpresaId);
            var Resultado = Mapper.Map<datoDto.ReporteResumenBasico, dto.ReporteResumenBasico>(query);
            return Resultado;
        }
    }
}
