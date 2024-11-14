using CIneData.Models.DTOs;
using CIneData.Models;
using CIneData.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private IConfiguration _config;
        private IClienteRepository _repo;

        public AutenticacionController(IConfiguration config, IClienteRepository repo)
        {
            _config = config;
            _repo = repo;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] SolicitudLogin login)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                
                //response = Ok(new { token = tokenString });
                SetTokenInsideCookie(tokenString, HttpContext);
                SetSessionCookie(user);
                response = Ok(tokenString);
            }

            return response;
        }

        private string GenerateJSONWebToken(Cliente userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim("admin" , userInfo.Admin.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
              _config["JwtSettings:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
 

        private async Task<Cliente> AuthenticateUser(SolicitudLogin login)
        {
            Cliente user = null;

            //Validate the User Credentials
            //Demo Purpose, I have Passed HardCoded User Information
            var isValid = await _repo.Verify(login);

            if (isValid)
            {
                user = await _repo.GetByEmail(login.Email);
            }

            return user;
        }


        private void SetTokenInsideCookie(string token, HttpContext context)
        {
            Response.Cookies.Append("accessToken", token,
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Path = "/"
                });

        }

        private void SetSessionCookie( Cliente userInfo)
        {
            var status = 0;
            if( userInfo.Admin == false)
            {
                status = userInfo.IdCliente;
            }
            
            Response.Cookies.Append("session", status.ToString(),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                    HttpOnly = false,
                    IsEssential = true,
                    Secure = false,
                    SameSite = SameSiteMode.None,
                    Path = "/"
                });
        }
    }
}
