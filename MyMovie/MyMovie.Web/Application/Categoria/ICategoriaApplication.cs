using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyMovie.Web.Application.Categoria
{
    public interface ICategoriaApplication
    {
        HttpResponseMessage Get(string token);
        HttpResponseMessage Get(string token, int id);
        HttpResponseMessage Post(string token, Models.Categoria.Categoria categoria);
        HttpResponseMessage Put(string token, Models.Categoria.Categoria categoria);
        HttpResponseMessage Delete(string token, int id);
    }
}
