using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Web.Extensions;
using Newtonsoft.Json;

namespace MyMovie.Web.Controllers
{
    public class CustomController : Controller
    {
        public ViewResult Error(string response, string view)
        {
            var errorContent = JsonConvert.DeserializeObject<ErrorContent>(response);
            ModelState.AddModelError("Error", errorContent.GetErrorMessage());
            return View(view);
        }
    }
}
