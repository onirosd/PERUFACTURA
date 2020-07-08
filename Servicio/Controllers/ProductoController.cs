using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ent = Aplicacion.Entidades.Models;
using app = Aplicacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Datos.Entidades.Models;
using System.Security.Claims;
using dto = Aplicacion.Entidades.DTO;

namespace ServicioWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        [Route("GuardarMasivoProductos")]
        public dto.ErrorClass GuardarMasivoProductos(dto.ProductoGuardarMasivoRequest request)
        {
            return new app.Producto().GuardarMasivoProductos(request);
        }

        [HttpPost]
        [Route("BuscarProductosYServicios")]
        public List<dto.ProductoServicio> BuscarProductosYServicios(dto.ProductoServicioRequest request)
        {
            //AspNetUserRoles request
            return new app.Producto().BuscarProductosYServicios(request.EmpresaId, request.Nombre);
        }

        [HttpGet("ObtenerProductosPorAgotarse/{EmpresaId}")]
        public List<ent.Producto> ObtenerProductosPorAgotarse(string EmpresaId)
        {
            //AspNetUserRoles request
            return new app.Producto().ObtenerProductosPorAgotarse(EmpresaId);
        }

        [HttpPost]
        [Route("ObtenerProductos")]
        public List<ent.Producto> ObtenerProductos(dto.ProductoObtenerRequest request)
        {
            //AspNetUserRoles request
            return new app.Producto().ObtenerProductos(request);
        }

        [HttpPost]
        [Route("ObtenerProductosByNombre")]
        public List<ent.Producto> ObtenerProductosByNombre(dto.ProductoObtenerRequest request)
        {
            //AspNetUserRoles request
            return new app.Producto().ObtenerProductosByNombre(request);
        }

        [HttpPost]
        [Route("NuevoProducto")]
        public dto.ErrorClass NuevoProducto(ent.Producto request)
        {
            //AspNetUserRoles request
            return new app.Producto().NuevoProducto(request);
        }

        [HttpPost]
        [Route("EditarProducto")]
        public dto.ErrorClass EditarProducto(ent.Producto request)
        {
            //AspNetUserRoles request
            return new app.Producto().EditarProducto(request);
        }

        [HttpPost]
        [Route("EliminarProducto")]
        public dto.ErrorClass EliminarProducto(ent.Producto request)
        {
            //AspNetUserRoles request
            return new app.Producto().EliminarProducto(request);
        }

        [HttpPost]
        [Route("EditarStockProducto")]
        public dto.ErrorClass EditarStockProducto(ent.Producto request)
        {
            //AspNetUserRoles request
            return new app.Producto().EditarStockProducto(request);
        }
    }
}