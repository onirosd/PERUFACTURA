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
    public class ProformaController : ControllerBase
    {
        [HttpPost]
        [Route("ObtenerProformaById")]
        public ent.Proforma ObtenerProformaById(dto.ProformaByIdRequest request)
        {
            return new app.Proforma().ObtenerProformaById(request);
        }

        [HttpPost]
        [Route("ObtenerProformasGrilla")]
        public IEnumerable<dto.ProformaGrilla> ObtenerProformasGrilla(dto.ProformaGrillaRequest request)
        {
            return new app.Proforma().ObtenerProformasGrilla(request);
        }

        [HttpPost]
        [Route("GuardarProforma")]
        public dto.ProformaGuardarResponse GuardarProforma(dto.ProformaGuardarRequest r)
        {
            return new app.Proforma().GuardarProforma(r);
        }

        [HttpPost]
        [Route("CerrarProforma")]
        public bool CerrarProforma(dto.ProformaCerrarRequest r)
        {
            return new app.Proforma().CerrarProforma(r);
        }

    }
}