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
    public class Almacen
    {
        public IEnumerable<dto.KardexGrilla> BuscarKardexByFecha(dto.KardexGrillaRequestByFecha r)
        {
            var Entidad = Mapper.Map<dto.KardexGrillaRequestByFecha, datoDto.KardexGrillaRequestByFecha>(r);
            var DetalleQuery = new dom.Almacen().BuscarKardexByFecha(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.KardexGrilla>, IEnumerable<dto.KardexGrilla>>(DetalleQuery);
            return Resultado;
        }

        public IEnumerable<dto.KardexGrilla> BuscarKardexByRangoFecha(dto.KardexGrillaRequestByRango r)
        {
            var Entidad = Mapper.Map<dto.KardexGrillaRequestByRango, datoDto.KardexGrillaRequestByRango>(r);
            var DetalleQuery = new dom.Almacen().BuscarKardexByRangoFecha(Entidad);
            var Resultado = Mapper.Map<IEnumerable<datoDto.KardexGrilla>, IEnumerable<dto.KardexGrilla>>(DetalleQuery);
            return Resultado;
        }

        public IEnumerable<ent.Almacen> TraerTodo()
        {
            var DetalleQuery = new dom.Almacen().TraerTodo();
            var Resultado = Mapper.Map<IEnumerable<dato.Almacen>, IEnumerable<ent.Almacen>>(DetalleQuery);
            return Resultado;
            //return null;
        }

        public IEnumerable<dto.AlmacenGrilla> BuscarAlmacen(ent.AlmacenRequest request)
        {
            var DetalleQuery = new dom.Almacen().BuscarAlmacen(request.EmpresaId, request.Tipo);
            var Resultado = Mapper.Map<IEnumerable<datoDto.AlmacenGrilla>, IEnumerable<dto.AlmacenGrilla>>(DetalleQuery);
            return Resultado;
            //return null;
        }

        public dto.ErrorClass InsertarEntrada(ent.Almacen r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                var objProducto = new dom.Producto().BuscarPorId(r.ProductoId);
                objProducto.Stock += r.Cantidad;
                objProducto.PrecioCompra = r.Precio;
                new dom.Producto().Modificar(objProducto);
                var objAlmacen = Mapper.Map<ent.Almacen, dato.Almacen>(r);
                objAlmacen.ComprobanteId = 0;
                objAlmacen.Fecha = DateTime.Now;
                objAlmacen.Tipo = 1;
                objAlmacen.ProductoNombre = objProducto.Nombre;
                objAlmacen.UnidadMedidaId = objProducto.UnidadMedidaId;
                new dom.Almacen().Adicionar(objAlmacen);
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
    }
}
