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

namespace ServicioWeb.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MenuController : ControllerBase
    {
        [HttpPost]
        [Route("TraerMenu")]
        public List<ent.Menu> TraerTodo(AspNetUserRoles request)
        {
            //AspNetUserRoles request
            return new app.Menu().ObtenerPermisos(request.RoleId);
        }
    }

}