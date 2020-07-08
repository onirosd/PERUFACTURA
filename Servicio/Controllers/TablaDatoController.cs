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

namespace ServicioWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TablaDatoController : ControllerBase
    {
        [HttpPost]
        [Route("ObtenerTipos")]
        public IEnumerable<ent.Tabladato> ObtenerTipos(ent.Tipo request)
        {
            return new app.TablaDato().ObtenerTipo(request.Relacion);
        }

        [HttpPost]
        [Route("ObtenerTipoByValue")]
        public ent.Tabladato ObtenerTipoByValue(ent.Tabladato request)
        {
            return new app.TablaDato().ObtenerTipoByValue(request.Relacion, request.Value);
        }
    }
}