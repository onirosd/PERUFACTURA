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
    public class Producto
    {
        public dto.ErrorClass GuardarMasivoProductos(dto.ProductoGuardarMasivoRequest request)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                foreach (var item in request.Productos)
                {
                    var entidad = Mapper.Map<ent.Producto, dato.Producto>(item);
                    new dom.Producto().Adicionar(entidad);
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

        public List<dto.ProductoServicio> BuscarProductosYServicios(string Empresaid, string Nombre)
        {
            var query = new dom.Producto().BuscarProductosYServicios(Empresaid, Nombre);
            var Resultado = Mapper.Map<IEnumerable<datoDto.ProductoServicio>, IEnumerable<dto.ProductoServicio>>(query);
            return Resultado.ToList();
        }

        public List<ent.Producto> ObtenerProductosPorAgotarse(string EmpresaId)
        {
            var query = new dom.Producto().Buscar(c => c.EmpresaId == EmpresaId && c.StockMinimo >= c.Stock).OrderBy(c => Guid.NewGuid()).Take(ConstantesAplicacion.CantidadProdSinStock);
            var Resultado = Mapper.Map<IEnumerable<dato.Producto>, IEnumerable<ent.Producto>>(query);
            return Resultado.ToList();
        }

        public List<ent.Producto> ObtenerProductosByNombre(dto.ProductoObtenerRequest r)
        {
            var query = new dom.Producto().Buscar(c => c.EmpresaId == r.Empresa_id && c.Nombre.Contains(r.Nombre));
            var Resultado = Mapper.Map<IEnumerable<dato.Producto>, IEnumerable<ent.Producto>>(query);
            return Resultado.ToList();
        }

        public List<ent.Producto> ObtenerProductos(dto.ProductoObtenerRequest r)
        {
            var query = new dom.Producto().Buscar(c => c.EmpresaId == r.Empresa_id && c.Nombre.Contains(r.Nombre) && c.Marca.Contains(r.Marca));
            var Resultado = Mapper.Map<IEnumerable<dato.Producto>, IEnumerable<ent.Producto>>(query);
            return Resultado.ToList();
        }

        public dto.ErrorClass NuevoProducto(ent.Producto r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                var entidad = Mapper.Map<ent.Producto, dato.Producto>(r);
                new dom.Producto().Adicionar(entidad);
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

        public dto.ErrorClass EditarProducto(ent.Producto r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                var entidad = Mapper.Map<ent.Producto, dato.Producto>(r);
                new dom.Producto().Modificar(entidad);
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

        public dto.ErrorClass EliminarProducto(ent.Producto r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                var contarComprobantes = new dom.ComprobanteDetalles().Buscar(c => c.ProductoId == r.Id && c.Tipo == ConstantesAplicacion.TipoProducto);
                if (contarComprobantes.Count() > 0)
                {
                    error.Error = true;
                    error.Mensaje = ConstantesErrores.NoEliminar;
                }
                else
                {
                    var entidad = Mapper.Map<ent.Producto, dato.Producto>(r);
                    new dom.Producto().Eliminar(entidad);
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

        public dto.ErrorClass EditarStockProducto(ent.Producto r)
        {
            dto.ErrorClass error = new dto.ErrorClass();
            try
            {
                var producto = new dom.Producto().BuscarPorId(r.Id);
                producto.Stock = r.Stock;
                new dom.Producto().Modificar(producto);
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
