using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Web.Extensions;
using MyMovie.Web.Models;
using MyMovie.Web.Models.Usuario;

namespace MyMovie.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var usuario = HttpContext.Session.GetUsuario();

            ViewBag.Usuario = usuario.User.ToUpper();

            return View();
        }

        public string GetSessionUserName()
        {
            return HttpContext.Session.GetUsuario().User.ToUpper();
        }
    }
}
