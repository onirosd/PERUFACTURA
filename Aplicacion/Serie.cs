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
    public class Serie
    {
        public ent.Serie ObtenerSerie(dto.SerieRequest r)
        {
            var query = new dom.Serie().Buscar(c => c.EmpresaId == r.EmpresaId && c.Serie1 == r.Serie && c.ComprobanteTipoId == r.ComprobanteTipoId && c.Proforma == r.Proforma).FirstOrDefault();
            var Resultado = Mapper.Map<dato.Serie, ent.Serie>(query);
            return Resultado;
        }

        public IEnumerable<ent.Serie> ObtenerSerieByTipoComprobante(dto.SerieRequest r)
        {
            var query = new dom.Serie().Buscar(c => c.EmpresaId == r.EmpresaId && c.ComprobanteTipoId == r.ComprobanteTipoId && c.Proforma == r.Proforma);
            var Resultado = Mapper.Map<IEnumerable<dato.Serie>, IEnumerable<ent.Serie>>(query);
            return Resultado;
        }
    }
}
