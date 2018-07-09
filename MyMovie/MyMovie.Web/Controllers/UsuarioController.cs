using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyMovie.Web.Application.Usuario;
using MyMovie.Web.Extensions;
using MyMovie.Web.Models.Usuario;
using MyMovie.Web.ViewModel.Usuario;
using Newtonsoft.Json;

namespace MyMovie.Web.Controllers
{
    public class UsuarioController : CustomController
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Registrar([FromForm] UsuarioViewModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index");

                var novoUsuario = new Usuario(
                    usuario.User,
                    usuario.Senha,
                    usuario.Email
                );

                var usuarioRequest = _usuarioApplication.Post(novoUsuario);
                if (!usuarioRequest.IsSuccessStatusCode)
                    return Error(usuarioRequest.Content.ReadAsStringAsync().Result, "Index");

                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("Index");
            }
        }
    }
}
