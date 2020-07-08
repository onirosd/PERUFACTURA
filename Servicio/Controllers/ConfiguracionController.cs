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
    public class ConfiguracionController : ControllerBase
    {
        [HttpPost]
        [Route("ObtenerConfiguracion")]
        public ent.Configuracion ObtenerConfiguracion(dto.ConfiguracionRequest request)
        {
            return new app.Configuracion().ObtenerConfiguracion(request);
        }

        [HttpPost]
        [Route("GuardarConfiguracion")]
        public dto.ErrorClass GuardarConfiguracion(ent.Configuracion request)
        {
            return new app.Configuracion().EditarConfiguracion(request);
        }
    }
}