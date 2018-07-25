using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Api.Core.Usuario;
using MyMovie.Api.Extensions;

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
                if (Notification.GetNotification() != null)
                {
                    var notificationMessage = Notification.GetNotification().Message;
                    Notification.SetEmpty();

                    return StatusCode((int)HttpStatusCode.NotFound, new
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        ErrorMessage = notificationMessage
                    });
                }

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
                if (Notification.GetNotification() != null)
                {
                    var notificationMessage = Notification.GetNotification().Message;
                    Notification.SetEmpty();

                    return StatusCode((int)HttpStatusCode.Conflict, new
                    {
                        StatusCode = (int)HttpStatusCode.Conflict,
                        ErrorMessage = notificationMessage
                    });
                }

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
