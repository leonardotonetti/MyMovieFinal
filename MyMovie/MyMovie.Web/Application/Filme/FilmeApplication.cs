using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyMovie.Web.Extensions;

namespace MyMovie.Web.Application.Filme
{
    public class FilmeApplication : IFilmeApplication
    {
        private readonly IConfiguration _config;
        private static string RequestPath => "api/FilmeApi";

        public FilmeApplication(IConfiguration config)
        {
            _config = config;
        }

        public HttpResponseMessage Get(string token)
        {
            return new ApiRequest(_config)
                .AddHeader(token)
                .AddPath($"{RequestPath}/Filme")
                .Get();
        }

        public HttpResponseMessage Get(string token, int id)
        {
            return new ApiRequest(_config)
                .AddHeader(token)
                .AddPath($"{RequestPath}/Filme/{id}")
                .Get();
        }

        public HttpResponseMessage Post(string token, Models.Filme.Filme filme)
        {
            return new ApiRequest(_config)
                .AddHeader(token)
                .AddPath($"{RequestPath}/Cadastrar")
                .Post(filme);
        }

        public HttpResponseMessage Put(string token, Models.Filme.Filme filme)
        {
            return new ApiRequest(_config)
                .AddHeader(token)
                .AddPath($"{RequestPath}/Editar")
                .Put(filme);
        }

        public HttpResponseMessage Delete(string token, int id)
        {
            return new ApiRequest(_config)
                .AddHeader(token)
                .AddPath($"{RequestPath}/Excluir/{id}")
                .Delete();
        }
    }
}
