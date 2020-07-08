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
    public class SerieController : ControllerBase
    {
        [HttpPost]
        [Route("ObtenerSerie")]
        public ent.Serie ObtenerSerie(dto.SerieRequest r) {
            return new app.Serie().ObtenerSerie(r);
        }

        [HttpPost]
        [Route("ObtenerSerieByTipoComprobante")]
        public IEnumerable<ent.Serie> ObtenerSerieByTipoComprobante(dto.SerieRequest r) {
            return new app.Serie().ObtenerSerieByTipoComprobante(r);
        }
    }
}