using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
//using ServicioWeb.Models;
using Datos.Entidades.Models;
using ent = Aplicacion.Entidades.Models;
using app = Aplicacion;
using System.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace ServicioWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            //PasswordHasher<ApplicationUser> passwordHasher,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_passwordHasher = passwordHasher;
            this._configuration = configuration;

        }

        [Route("ValidaToken")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public bool ValidaToken() {
            return true;
        }

        [Route("Create")]
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateUser([FromBody] UserInfo model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return BuildTokenLogin(model);
                }
                else
                {
                    return BadRequest(result.Errors.ToList()[0].Description);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserInfo userInfo)
        {
            DateTime fecha = new DateTime(2020, 12, 31);
            if (fecha > DateTime.Now)
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(userInfo.UserName, userInfo.Password, isPersistent: false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByNameAsync(userInfo.UserName);
                        var role = await _userManager.GetRolesAsync(user);
                        ent.EmpresaRequest objEmpresa = new ent.EmpresaRequest();
                        objEmpresa.Id = user.Id;
                        objEmpresa.Empresa_id = userInfo.Empresa;
                        var usuario = new app.Usuario().ObtenerUsuario(objEmpresa);
                        var empresa = new app.Empresa().ObtenerEmpresaUsuario(objEmpresa);
                        if (usuario == null)
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return BadRequest(ModelState);
                        }
                        else
                        {
                            return BuildToken(userInfo, role, userInfo.Empresa, user.Id, usuario.Nombre, empresa.Nombre);
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else {
                return BadRequest(ModelState);
            }
        }

        [Route("UpdatePwd")]
        [HttpPost]
        public async Task<IActionResult> UpdatePwd([FromBody] UserInfo model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
                if(model.Password.Length < 5)
                    return BadRequest("");
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return BuildTokenLogin(model);
                }
                else
                {
                    return BadRequest(result.Errors.ToList()[0].Description);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private IActionResult BuildToken(UserInfo userInfo, IList<string> role, string empresaID, string userId, string nombreUsuario, string nombreEmpresa)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserName),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_super_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(24);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration,
                role,
                empresa = empresaID,
                userId,
                userName = userInfo.UserName,
                nombreUsuario,
                email = userInfo.UserName,
                nombreEmpresa
            });

        }

        private IActionResult BuildTokenLogin(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserName),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_super_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(24);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration
            });

        }

        private string BuildTokenAlternativo(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserName),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_super_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(24);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


    }
}