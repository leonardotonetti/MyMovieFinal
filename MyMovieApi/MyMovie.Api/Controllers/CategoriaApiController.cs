using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Api.Core.Categoria;
using MyMovie.Api.Extensions;

namespace MyMovie.Api.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class CategoriaApiController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaApiController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("Categoria")]
        public IActionResult Get()
        {
            try
            {
                var categoriaResponse = _categoriaService.Get();

                return Ok(categoriaResponse);
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

        [HttpGet("Categoria/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var categoriaResponse = _categoriaService.Get(id);

                if (Notification.GetNotification() != null)
                {
                    var notificationMessage = Notification.GetNotification().Message;
                    Notification.SetEmpty();

                    return NotFound(new
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        ErrorMessage = notificationMessage
                    });
                }

                return Ok(categoriaResponse);
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

        [HttpPost("Cadastrar")]
        public IActionResult Post([FromBody] CategoriaDto categoria)
        {
            try
            {
                var novaCategoria = new Categoria(
                    categoria.Nome,
                    categoria.CadastroUsuarioId,
                    categoria.Ativo
                );

                _categoriaService.Post(novaCategoria);

                if (Notification.GetNotification() != null)
                {
                    var notificationMessage = Notification.GetNotification().Message;
                    Notification.SetEmpty();

                    return StatusCode((int)HttpStatusCode.Conflict, new
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        ErrorMessage = notificationMessage
                    });
                }

                return Ok();
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

        [HttpPut("Editar")]
        public IActionResult Put([FromBody] CategoriaDto categoria)
        {
            try
            {
                var categoriaAtualizada = new Categoria(
                    categoria.CategoriaId,
                    categoria.Nome,
                    categoria.AlteracaoUsuarioId.Value,
                    categoria.Ativo
                );

                _categoriaService.Put(categoriaAtualizada);

                if (Notification.GetNotification() != null)
                {
                    var notificationMessage = Notification.GetNotification().Message;
                    Notification.SetEmpty();

                    return NotFound(new
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        ErrorMessage = notificationMessage
                    });
                }

                return Ok();
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

        [HttpDelete("Excluir/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoriaService.Delete(id);

                if (Notification.GetNotification() != null)
                {
                    var notificationMessage = Notification.GetNotification().Message;
                    Notification.SetEmpty();

                    return NotFound(new
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        ErrorMessage = notificationMessage
                    });
                }

                return Ok();
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
