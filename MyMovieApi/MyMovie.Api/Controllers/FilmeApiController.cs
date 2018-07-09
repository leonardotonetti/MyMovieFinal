using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Api.Core.Filme;
using MyMovie.Api.Extensions;

namespace MyMovie.Api.Controllers
{
    [Authorize("Bearer")]
    [Route("Api/[controller]")]
    public class FilmeApiController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeApiController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet("Filme")]
        public IActionResult Get()
        {
            try
            {
                var filmeResponse = _filmeService.Get();

                return Ok(filmeResponse);
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

        [HttpGet("Filme/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var filmeResponse = _filmeService.Get(id);

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

                return Ok(filmeResponse);
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
        public IActionResult Post([FromBody] FilmeDto filme)
        {
            try
            {
                var novoFilme = new Filme(
                    filme.Nome,
                    filme.Descricao,
                    filme.CategoriaId,
                    filme.CadastroUsuarioId,
                    filme.Ativo
                );

                _filmeService.Post(novoFilme);

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
        public IActionResult Put([FromBody] FilmeDto filme)
        {
            try
            {
                var filmeAtualizado = new Filme(
                    filme.FilmeId,
                    filme.Nome,
                    filme.Descricao,
                    filme.CategoriaId,
                    filme.AlteracaoUsuarioId.Value,
                    filme.Ativo
                );

                _filmeService.Put(filmeAtualizado);

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
                _filmeService.Delete(id);

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
