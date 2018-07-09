using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyMovie.Web.Extensions;

namespace MyMovie.Web.Application.Login
{
    public class LoginApplication : ILoginApplication
    {
        private readonly IConfiguration _config;
        private static string RequestPath => "api/LoginApi";


        public LoginApplication(IConfiguration config)
        {
            _config = config;
        }

        public HttpResponseMessage Entrar(Models.Usuario.Usuario usuario)
        {
            return new ApiRequest(_config)
                .AddPath(RequestPath)
                .Post(usuario);
        }
    }
}
