using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyMovie.Api.Core.Usuario;
using MyMovie.Api.Extensions;

namespace MyMovie.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginApiController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly SigningConfigurations _signingConfigurations;

        public LoginApiController(IUsuarioService usuarioService, TokenConfiguration tokenConfiguration, SigningConfigurations signingConfigurations)
        {
            _usuarioService = usuarioService;
            _tokenConfiguration = tokenConfiguration;
            _signingConfigurations = signingConfigurations;
        }

        [HttpPost]
        public IActionResult Entrar([FromBody] UsuarioDto usuario)
        {
            try
            {
                var usuarioResponse = _usuarioService.Get(usuario.User, usuario.Senha);
                if (usuarioResponse == null)
                    return NotFound(new
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        ErrorMessage = "Falha ao entrar! Usuário ou Senha incorretos"
                    });

                var identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.User, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.User)
                    }
                );

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfiguration.Issuer,
                    Audience = _tokenConfiguration.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = DateTime.Now,
                    Expires = DateTime.Now.AddSeconds(_tokenConfiguration.Seconds)
                });

                var token = handler.WriteToken(securityToken);
                usuarioResponse.Token = token;

                return Ok(usuarioResponse);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
    }
}
