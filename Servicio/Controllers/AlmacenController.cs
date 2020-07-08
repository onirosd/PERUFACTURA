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
    public class AlmacenController : ControllerBase
    {
        [HttpPost]
        [Route("TraerTodo")]
        public IEnumerable<ent.Almacen> TraerTodo()
        {
            return new app.Almacen().TraerTodo();
        }

        [HttpPost]
        [Route("Buscar")]
        public IEnumerable<dto.AlmacenGrilla> Buscar(ent.AlmacenRequest request)
        {
            return new app.Almacen().BuscarAlmacen(request);
        }

        [HttpPost]
        [Route("InsertarEntrada")]
        public dto.ErrorClass InsertarEntrada(ent.Almacen request)
        {
            //AspNetUserRoles request
            return new app.Almacen().InsertarEntrada(request);
        }

        [HttpPost]
        [Route("BuscarKardexByFecha")]
        public IEnumerable<dto.KardexGrilla> BuscarKardexByFecha(dto.KardexGrillaRequestByFecha r)
        {
            return new app.Almacen().BuscarKardexByFecha(r);
        }

        [HttpPost]
        [Route("BuscarKardexByRangoFecha")]
        public IEnumerable<dto.KardexGrilla> BuscarKardexByRangoFecha(dto.KardexGrillaRequestByRango r)
        {
            return new app.Almacen().BuscarKardexByRangoFecha(r);
        }
    }
}