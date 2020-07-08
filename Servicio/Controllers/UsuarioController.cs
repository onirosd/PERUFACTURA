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
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("ObtenerUsuarios")]
        public List<dto.UsuarioGrilla> ObtenerUsuarios(dto.UsuarioGrillaRequest request)
        {
            return new app.Usuario().ObtenerUsuarios(request);
        }

        [HttpPost]
        [Route("ObtenerTipoUsuarios")]
        public List<ent.AspNetRoles> ObtenerTipoUsuarios()
        {
            return new app.Usuario().ObtenerTipoUsuarios();
        }

        [HttpPost]
        [Route("EditarUsuario")]
        public bool EditarUsuario(ent.UsuarioNuevo request)
        {
            return new app.Usuario().EditarUsuario(request);
        }

        [HttpPost]
        [Route("NuevoUsuario")]
        public bool NuevoUsuario(ent.UsuarioNuevo request)
        {
            return new app.Usuario().NuevoUsuario(request);
        }


    }
}