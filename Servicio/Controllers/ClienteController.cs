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
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("GuardarMasivoClientes")]
        public dto.ErrorClass GuardarMasivoClientes(dto.ClienteGuardarMasivoRequest request)
        {
            return new app.Cliente().GuardarMasivoClientes(request);
        }

        [HttpPost]
        [Route("ObtenerClientesByNombre")]
        public List<ent.Cliente> ObtenerClientesByNombre(dto.ClienteObtenerRequest request)
        {
            return new app.Cliente().ObtenerClientesByNombre(request);
        }

        [HttpPost]
        [Route("ObtenerClientes")]
        public List<ent.Cliente> ObtenerClientes(dto.ClienteObtenerRequest request)
        {
            return new app.Cliente().ObtenerClientes(request);
        }

        [HttpPost]
        [Route("NuevoCliente")]
        public dto.ErrorClass NuevoCliente(ent.Cliente request)
        {
            return new app.Cliente().NuevoCliente(request);
        }

        [HttpPost]
        [Route("EditarCliente")]
        public dto.ErrorClass EditarCliente(ent.Cliente request)
        {
            return new app.Cliente().EditarCliente(request);
        }

        [HttpPost]
        [Route("EliminarCliente")]
        public dto.ErrorClass EliminarCliente(ent.Cliente request)
        {
            return new app.Cliente().EliminarCliente(request);
        }
    }
}