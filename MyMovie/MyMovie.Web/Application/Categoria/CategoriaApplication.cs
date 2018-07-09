using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyMovie.Web.Extensions;

namespace MyMovie.Web.Application.Categoria
{
    public class CategoriaApplication : ICategoriaApplication
    {
        private readonly IConfiguration _config;
        private static string RequestPath => "api/CategoriaApi";

        public CategoriaApplication(IConfiguration config)
        {
            _config = config;
        }

        public HttpResponseMessage Get(string token)
        {
            return new ApiRequest(_config)
                .AddHeader(token)
                .AddPath($"{RequestPath}/Categoria")
                .Get();
        }

        public HttpResponseMessage Get(string token, int id)
        {
            return new ApiRequest(_config)
                .AddHeader(token)
                .AddPath($"{RequestPath}/Categoria/{id}")
                .Get();
        }

        public HttpResponseMessage Post(string token, Models.Categoria.Categoria categoria)
        {
            return new ApiRequest(_config)
                .AddHeader(token)
                .AddPath($"{RequestPath}/Cadastrar")
                .Post(categoria);
        }

        public HttpResponseMessage Put(string token, Models.Categoria.Categoria categoria)
        {
            return new ApiRequest(_config)
                .AddHeader(token)
                .AddPath($"{RequestPath}/Editar")
                .Put(categoria);
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
