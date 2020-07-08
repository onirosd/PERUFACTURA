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
    public class Comprobante
    {
        public void AnularComprobante(dto.ComprobanteAnulacionElectronicaRequest request, byte estado)
        {
            var comprobante = new dom.Comprobante().BuscarPorId(request.IdComprobante);
            comprobante.Estado = estado;
            comprobante.MotiAnulacion = request.MotivoAnulacion;
            new dom.Comprobante().Modificar(comprobante);
            byte tipodete = 1;
            if (comprobante.ComprobanteTipoId == 7) {
                tipodete = 2;
            }
            var detalle = new dom.ComprobanteDetalles().Buscar(c => c.ComprobanteId == comprobante.Id).ToList();
            dato.Almacen objAlmacen;
            foreach (var item in detalle)
            {
                var producto = new dom.Producto().BuscarPorId(item.ProductoId);
                if (item.Tipo == 1) {

                    if (tipodete == 2)
                    {
                        if (producto.Stock - item.Cantidad > 0)
                        {
                            producto.Stock = producto.Stock - item.Cantidad;
                        }
                        else
                        {
                            producto.Stock = 0;
                        }
                    }
                    else {
                        producto.Stock = producto.Stock + item.Cantidad;
                    }
                    new dom.Producto().Modificar(producto);
                    objAlmacen = new dato.Almacen();
                    objAlmacen.Tipo = tipodete;
                    objAlmacen.UsuarioId = request.UsuarioId;
                    objAlmacen.ProductoId = item.ProductoId;
                    objAlmacen.ProductoNombre = item.ProductoNombre;
                    objAlmacen.UnidadMedidaId = item.UnidadMedidaId;
                    objAlmacen.Cantidad = (decimal)item.Cantidad;
                    objAlmacen.Fecha = DateTime.Now;
                    objAlmacen.EmpresaId = comprobante.EmpresaId;
                    objAlmacen.ComprobanteId = comprobante.Id;
                    objAlmacen.Precio = item.PrecioTotal;
                    new dom.Almacen().Adicionar(objAlmacen);
                }
            }
        }

        public void ActualizarEstadoComprobante(dto.ComprobanteByIdRequest request, byte estado) {
            var comprobante = new dom.Comprobante().BuscarPorId(request.IdComprobante);
            comprobante.Estado = estado;
            new dom.Comprobante().Modificar(comprobante);
        }

        public ent.Comprobante ObtenerComprobanteById(dto.ComprobanteByIdRequest request) {
            var comprobante = new dom.Comprobante().BuscarPorId(request.IdComprobante);
            comprobante.Comprobantedetalle = new dom.ComprobanteDetalles().Buscar(c => c.ComprobanteId == request.IdComprobante);
            var Resultado = Mapper.Map<dato.Comprobante, ent.Comprobante>(comprobante);
            Resultado.ComprobanteTipoNombre = new dom.TablaDato().BuscarPrimero(c => c.Relacion == "comprobantetipo" && c.Value == Resultado.ComprobanteTipoId.ToString()).Nombre;
            Resultado.EstadoNombre = new dom.TablaDato().BuscarPrimero(c => c.Relacion == "comprobanteestado" && c.Value == Resultado.Estado.ToString()).Nombre;
            Resultado.MedioPagoNombre = new dom.TablaDato().BuscarPrimero(c => c.Relacion == "MedioPago" && c.Value == Resultado.MedioPago.ToString()).Nombre;
            if (comprobante.TipoOperacionId.HasValue) Resultado.TipoOperacionNombre = new dom.TablaDato().BuscarPrimero(c => c.Relacion == "TipoOperacion" && Convert.ToInt32(c.Value) == Resultado.TipoOperacionId).Nombre;
            if (!String.IsNullOrEmpty(comprobante.DetraccionId)) Resultado.DetraccionNombre = new dom.TablaDato().BuscarPrimero(c => c.Relacion == "Detraccion" && c.Value == Resultado.DetraccionId).Nombre;

            
            if (!String.IsNullOrEmpty(comprobante.TipoNotaId)) {
                string relacionTipoNota = string.Empty;
                if (Resultado.ComprobanteTipoId == 7) relacionTipoNota = "tiponotacredito";
                if (Resultado.ComprobanteTipoId == 8) relacionTipoNota = "tiponotadebito";
                Resultado.TipoNotaNombre = new dom.TablaDato().BuscarPrimero(c => c.Relacion == relacionTipoNota && c.Value == comprobante.TipoNotaId).Nombre;
            }
            Resultado.HoraEmisionDate = DateTime.Now;
            return Resultado;
        }


        public List<dto.ComprobanteGrilla> ObtenerComprobantes(dto.ComprobantesObtenerRequest request)
        {
            var query = new dom.Comprobante().BuscarComprobantes(request.Empresa_id, request.Serie, request.ClienteNombre, request.ComprobanteTipo_id, request.Estado, request.FechaEmitidoInicio, request.FechaEmitidoFin);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ComprobanteGrilla>, IEnumerable<dto.ComprobanteGrilla>>(query);
            return Resultado.ToList();
        }

        public dto.ComprobanteGuardarResponse GuardarComprobante(dto.ComprobanteGuardarRequest r)
        {
            dto.ComprobanteGuardarResponse response = new dto.ComprobanteGuardarResponse();
            try
            {
                byte tipodete = 2;
                var cabecera = Mapper.Map<ent.Comprobante, dato.Comprobante>(r.ComprobanteCabecera);
                var detalle = Mapper.Map<IEnumerable<ent.Comprobantedetalle>, IEnumerable<dato.Comprobantedetalle>>(r.ComprobanteDetalle);
                if (cabecera.ComprobanteTipoId == 7)
                {
                    tipodete = 1;
                }
                if (cabecera.Id == 0)
                {
                    var serieServ = new dom.Serie().Buscar(c => c.EmpresaId == r.ComprobanteCabecera.EmpresaId && c.Serie1 == r.ComprobanteCabecera.Serie && c.ComprobanteTipoId == r.ComprobanteCabecera.ComprobanteTipoId && c.Proforma == false).FirstOrDefault();
                    cabecera.Correlativo = (serieServ.Correlativo + 1).ToString();
                    new dom.Comprobante().Adicionar(cabecera);
                    foreach (var item in detalle)
                    {
                        item.ComprobanteId = cabecera.Id;
                        new dom.ComprobanteDetalles().Adicionar(item);
                        var producto = new dom.Producto().BuscarPorId(item.ProductoId);
                        if (item.Tipo == 1)
                        {
                            if (cabecera.ComprobanteTipoId == 1 || cabecera.ComprobanteTipoId == 3 || cabecera.ComprobanteTipoId == 8)
                            {
                                if (producto.Stock - item.Cantidad > 0)
                                {
                                    producto.Stock = producto.Stock - item.Cantidad;
                                }
                                else
                                {
                                    producto.Stock = 0;
                                }
                                
                            }
                            else
                            {
                                producto.Stock = producto.Stock + item.Cantidad;
                            }
                            new dom.Producto().Modificar(producto);
                            dato.Almacen objAlmacen = new dato.Almacen();
                            objAlmacen.Tipo = tipodete;
                            objAlmacen.UsuarioId = cabecera.UsuarioId;
                            objAlmacen.ProductoId = item.ProductoId;
                            objAlmacen.ProductoNombre = item.ProductoNombre;
                            objAlmacen.UnidadMedidaId = item.UnidadMedidaId;
                            objAlmacen.Cantidad = (decimal)item.Cantidad;
                            objAlmacen.Fecha = DateTime.Now;
                            objAlmacen.EmpresaId = cabecera.EmpresaId;
                            objAlmacen.ComprobanteId = cabecera.Id;
                            objAlmacen.Precio = item.PrecioTotal;
                            new dom.Almacen().Adicionar(objAlmacen);
                        }
                    }

                    var serie = new dom.Serie().BuscarPrimero(c => c.EmpresaId == cabecera.EmpresaId && c.Serie1 == cabecera.Serie && c.ComprobanteTipoId == cabecera.ComprobanteTipoId);
                    serie.Correlativo = Convert.ToInt64(cabecera.Correlativo);
                    new dom.Serie().Modificar(serie);


                    response.IdComprobante = cabecera.Id;
                }
                else {
                    new dom.Comprobante().Modificar(cabecera);
                    var comprobanteDetalles = new dom.ComprobanteDetalles();
                    var detalleEdicion = comprobanteDetalles.Buscar(c => c.ComprobanteId == cabecera.Id).ToList();
                    foreach (var item in detalleEdicion)
                    {
                        var productoEdicion = new dom.Producto().BuscarPorId(item.ProductoId);
                        if (item.Tipo == 1)
                        {
                            if (cabecera.ComprobanteTipoId == 1 || cabecera.ComprobanteTipoId == 3 || cabecera.ComprobanteTipoId == 8)
                            {
                                //devolucion
                                productoEdicion.Stock = productoEdicion.Stock + item.Cantidad;

                            }
                            else {
                                productoEdicion.Stock = productoEdicion.Stock - item.Cantidad;
                            }
                            new dom.Producto().Modificar(productoEdicion);

                            dato.Almacen objAlmacen = new dato.Almacen();
                            objAlmacen.Tipo = 3;
                            objAlmacen.UsuarioId = cabecera.UsuarioId;
                            objAlmacen.ProductoId = item.ProductoId;
                            objAlmacen.ProductoNombre = item.ProductoNombre;
                            objAlmacen.UnidadMedidaId = item.UnidadMedidaId;
                            objAlmacen.Cantidad = (decimal)item.Cantidad;
                            objAlmacen.Fecha = DateTime.Now;
                            objAlmacen.EmpresaId = cabecera.EmpresaId;
                            objAlmacen.ComprobanteId = cabecera.Id;
                            objAlmacen.Precio = item.PrecioTotal;
                            new dom.Almacen().Adicionar(objAlmacen);
                        }
                        comprobanteDetalles.Eliminar(item);
                    }

                    foreach (var item in detalle)
                    {
                        item.ComprobanteId = cabecera.Id;
                        new dom.ComprobanteDetalles().Adicionar(item);
                        var producto = new dom.Producto().BuscarPorId(item.ProductoId);
                        if (item.Tipo == 1)
                        {
                            if (cabecera.ComprobanteTipoId == 1 || cabecera.ComprobanteTipoId == 3 || cabecera.ComprobanteTipoId == 8)
                            {
                                
                                if (producto.Stock - item.Cantidad > 0)
                                {
                                    producto.Stock = producto.Stock - item.Cantidad;
                                }
                                else
                                {
                                    producto.Stock = 0;
                                }
                            }
                            else
                            {
                                producto.Stock = producto.Stock + item.Cantidad;
                            }
                            new dom.Producto().Modificar(producto);

                            dato.Almacen objAlmacen = new dato.Almacen();
                            objAlmacen.Tipo = tipodete;
                            objAlmacen.UsuarioId = cabecera.UsuarioId;
                            objAlmacen.ProductoId = item.ProductoId;
                            objAlmacen.ProductoNombre = item.ProductoNombre;
                            objAlmacen.UnidadMedidaId = item.UnidadMedidaId;
                            objAlmacen.Cantidad = (decimal)item.Cantidad;
                            objAlmacen.Fecha = DateTime.Now;
                            objAlmacen.EmpresaId = cabecera.EmpresaId;
                            objAlmacen.ComprobanteId = cabecera.Id;
                            objAlmacen.Precio = item.PrecioTotal;
                            new dom.Almacen().Adicionar(objAlmacen);
                        }
                    }
                    response.IdComprobante = cabecera.Id;
                }
                
            }
            catch (Exception Ex)
            {
                response.IdComprobante = 0;
            }
            return response;
        }

        public List<dto.ReporteMesDetalladoResponse> ObtenerReporteMesDetallado(dto.ReporteMesDetalladoRequest r)
        {
            var Entidad = Mapper.Map<dto.ReporteMesDetalladoRequest, datoDto.ReporteMesDetalladoRequest>(r);
            var DetalleQuery = new dom.Comprobante().ObtenerReporteMesDetallado(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ReporteMesDetalladoResponse>, IEnumerable<dto.ReporteMesDetalladoResponse>>(DetalleQuery);
            return Resultado.ToList();
        }

        public List<dto.ReporteTopProductosResponse> ObtenerReporteTopProductos(dto.ReporteTopProductosRequest r)
        {
            var Entidad = Mapper.Map<dto.ReporteTopProductosRequest, datoDto.ReporteTopProductosRequest>(r);
            var DetalleQuery = new dom.Comprobante().ObtenerReporteTopProductos(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ReporteTopProductosResponse>, IEnumerable<dto.ReporteTopProductosResponse>>(DetalleQuery);
            return Resultado.ToList();
        }

        public List<dto.ReporteTopEmpleadosResponse> ObtenerReporteTopEmpleados(dto.ReporteTopEmpleadosRequest r)
        {
            var Entidad = Mapper.Map<dto.ReporteTopEmpleadosRequest, datoDto.ReporteTopEmpleadosRequest>(r);
            var DetalleQuery = new dom.Comprobante().ObtenerReporteTopEmpleados(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ReporteTopEmpleadosResponse>, IEnumerable<dto.ReporteTopEmpleadosResponse>>(DetalleQuery);
            return Resultado.ToList();
        }

        public List<dto.ReporteTopClientesResponse> ObtenerReporteTopClientes(dto.ReporteTopClientesRequest r)
        {
            var Entidad = Mapper.Map<dto.ReporteTopClientesRequest, datoDto.ReporteTopClientesRequest>(r);
            var DetalleQuery = new dom.Comprobante().ObtenerReporteTopClientes(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ReporteTopClientesResponse>, IEnumerable<dto.ReporteTopClientesResponse>>(DetalleQuery);
            return Resultado.ToList();
        }

        public List<dto.ReporteAnualResponse> ObtenerReporteAnual(dto.ReporteAnualRequest r)
        {
            var Entidad = Mapper.Map<dto.ReporteAnualRequest, datoDto.ReporteAnualRequest>(r);
            var DetalleQuery = new dom.Comprobante().ObtenerReporteAnual(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ReporteAnualResponse>, IEnumerable<dto.ReporteAnualResponse>>(DetalleQuery);
            return Resultado.ToList();
        }

        public List<dto.ReporteMensualResponse> ObtenerReporteMensual(dto.ReporteMensualRequest r)
        {
            var Entidad = Mapper.Map<dto.ReporteMensualRequest, datoDto.ReporteMensualRequest>(r);
            var DetalleQuery = new dom.Comprobante().ObtenerReporteMensual(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ReporteMensualResponse>, IEnumerable<dto.ReporteMensualResponse>>(DetalleQuery);
            return Resultado.ToList();
        }

        public List<dto.ReporteDiarioResponse> ObtenerReporteDiario(dto.ReporteDiarioRequest r)
        {
            var Entidad = Mapper.Map<dto.ReporteDiarioRequest, datoDto.ReporteDiarioRequest>(r);
            var DetalleQuery = new dom.Comprobante().ObtenerReporteDiario(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ReporteDiarioResponse>, IEnumerable<dto.ReporteDiarioResponse>>(DetalleQuery);
            return Resultado.ToList();
        }
    }
}
