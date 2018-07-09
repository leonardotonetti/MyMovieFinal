using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Web.Application.Login;
using MyMovie.Web.Extensions;
using MyMovie.Web.Models.Usuario;
using MyMovie.Web.ViewModel.Login;
using Newtonsoft.Json;

namespace MyMovie.Web.Controllers
{
    public class LoginController : CustomController
    {
        private readonly ILoginApplication _loginApplication;

        public LoginController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Entrar([FromForm] LoginViewModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index");

                var loginRequest = _loginApplication.Entrar(new Usuario(login.Usuario, login.Senha));
                if (!loginRequest.IsSuccessStatusCode)
                    return Error(loginRequest.Content.ReadAsStringAsync().Result, "Index");

                var usuario = JsonConvert.DeserializeObject<Usuario>(loginRequest.Content.ReadAsStringAsync().Result);
                HttpContext.Session.SetUsuario(usuario);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("Index");
            }
        }

        public ActionResult Sair()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
