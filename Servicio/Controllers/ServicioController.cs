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
    public class ServicioController : ControllerBase
    {
        [HttpPost]
        [Route("GuardarMasivoServicios")]
        public dto.ErrorClass GuardarMasivoServicios(dto.ServiciosGuardarMasivoRequest request)
        {
            return new app.Servicio().GuardarMasivoServicios(request);
        }

        [HttpPost]
        [Route("ObtenerServicios")]
        public List<ent.Servicio> ObtenerServicios(dto.ServiciosObtenerRequest request)
        {
            //AspNetUserRoles request
            return new app.Servicio().ObtenerServicios(request);
        }

        [HttpPost]
        [Route("NuevoServicio")]
        public bool NuevoServicio(ent.Servicio request)
        {
            //AspNetUserRoles request
            return new app.Servicio().NuevoServicio(request);
        }

        [HttpPost]
        [Route("EditarServicio")]
        public bool EditarServicio(ent.Servicio request)
        {
            //AspNetUserRoles request
            return new app.Servicio().EditarServicio(request);
        }

        [HttpPost]
        [Route("EliminarServicio")]
        public dto.ErrorClass EliminarServicio(ent.Servicio request)
        {
            //AspNetUserRoles request
            return new app.Servicio().EliminarServicio(request);
        }
    }
}
