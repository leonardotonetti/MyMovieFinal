using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Api.Core.Usuario;

namespace MyMovie.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioApiController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioApiController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get(string usuario, string senha)
        {
            try
            {
                var usuarioResponse = _usuarioService.Get(usuario, senha);
                if (usuarioResponse == null)
                    return NotFound(new
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        ErrorMessage = "Usuario não encontrado"
                    });

                return Ok(usuarioResponse);
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, new
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDto usuario)
        {
            try
            {
                var novoUsuario = new Usuario(
                        usuario.User,
                        usuario.Senha,
                        usuario.Email
                    );

                var usuarioResponse = _usuarioService.Post(novoUsuario);
                if (usuarioResponse == null)
                    return StatusCode((int)HttpStatusCode.Conflict, new
                    {
                        StatusCode = (int)HttpStatusCode.Conflict,
                        ErrorMessage = "Usuario já cadastrado"
                    });

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
