using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyMovie.Web.Extensions;
using Newtonsoft.Json;

namespace MyMovie.Web.Application.Usuario
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IConfiguration _config;
        private static string RequestPath => "api/UsuarioApi";

        public UsuarioApplication(IConfiguration config)
        {
            _config = config;
        }

        public HttpResponseMessage Get(Models.Usuario.Usuario usuario)
        {
            return new ApiRequest(_config)
                .AddPath(RequestPath)
                .Get();
        }

        public HttpResponseMessage Post(Models.Usuario.Usuario usuario)
        {
            return new ApiRequest(_config)
                .AddPath(RequestPath)
                .Post(usuario);
        }
    }
}
