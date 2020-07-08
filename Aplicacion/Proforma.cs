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
using System.Collections;

namespace Aplicacion
{
    public class Proforma
    {
        public List<dto.ReporteMesDetalladoResponse> ObtenerReporteMesDetalladoProforma(dto.ReporteMesDetalladoRequest r)
        {
            var Entidad = Mapper.Map<dto.ReporteMesDetalladoRequest, datoDto.ReporteMesDetalladoRequest>(r);
            var DetalleQuery = new dom.Proforma().ObtenerReporteMesDetalladoProforma(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ReporteMesDetalladoResponse>, IEnumerable<dto.ReporteMesDetalladoResponse>>(DetalleQuery);
            return Resultado.ToList();
        }

        public bool CerrarProforma(dto.ProformaCerrarRequest r)
        {
            var proforma = new dom.Proforma().BuscarPorId(r.Id);
            proforma.Estado = Ayuda.EstadosProforma.cerrado;
            new dom.Proforma().Modificar(proforma);
            return true;
        }

        public ent.Proforma ObtenerProformaById(dto.ProformaByIdRequest request)
        {
            var comprobante = new dom.Proforma().BuscarPorId(request.IdProforma);
            comprobante.Proformadetalle = new dom.ProformaDetalle().Buscar(c => c.ComprobanteId == request.IdProforma);
            var Resultado = Mapper.Map<dato.Proforma, ent.Proforma>(comprobante);
            Resultado.EstadoNombre = new dom.TablaDato().BuscarPrimero(c => c.Relacion == "comprobanteestado" && c.Value == Resultado.Estado.ToString()).Nombre;
            return Resultado;
        }

        public IEnumerable<dto.ProformaGrilla> ObtenerProformasGrilla(dto.ProformaGrillaRequest r)
        {
            var Entidad = Mapper.Map<dto.ProformaGrillaRequest, datoDto.ProformaGrillaRequest>(r);
            var DetalleQuery = new dom.Proforma().ObtenerProformasGrilla(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ProformaGrilla>, IEnumerable<dto.ProformaGrilla>>(DetalleQuery);
            return Resultado;
        }

        public dto.ProformaGuardarResponse GuardarProforma(dto.ProformaGuardarRequest r)
        {
            dto.ProformaGuardarResponse response = new dto.ProformaGuardarResponse();
            try
            {
                var detalleEliminar = new dom.ProformaDetalle().Buscar(c => c.ComprobanteId == r.ProformaCabecera.ComprobanteId).ToList();
                foreach (var item in detalleEliminar)
                {
                    new dom.ProformaDetalle().Eliminar(item);
                }

                var cabecera = Mapper.Map<ent.Proforma, dato.Proforma>(r.ProformaCabecera);
                var detalle = Mapper.Map<IEnumerable<ent.Proformadetalle>, IEnumerable<dato.Proformadetalle>>(r.ProformaDetalle);
                if (r.ProformaCabecera.ComprobanteId != null)
                {
                    cabecera.Id = (int)r.ProformaCabecera.ComprobanteId;
                    new dom.Proforma().Modificar(cabecera);

                }
                else {
                    new dom.Proforma().Adicionar(cabecera);
                }

                foreach (var item in detalle)
                {
                    item.ComprobanteId = cabecera.Id;
                    new dom.ProformaDetalle().Adicionar(item);
                }
                response.IdProforma = cabecera.Id;
            }
            catch (Exception Ex)
            {
                response.IdProforma = 0;
            }
            return response;
        }
    }
}
