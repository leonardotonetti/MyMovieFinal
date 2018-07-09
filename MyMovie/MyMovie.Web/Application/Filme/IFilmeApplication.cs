using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyMovie.Web.Application.Filme
{
    public interface IFilmeApplication
    {
        HttpResponseMessage Get(string token);
        HttpResponseMessage Get(string token, int id);
        HttpResponseMessage Post(string token, Models.Filme.Filme filme);
        HttpResponseMessage Put(string token, Models.Filme.Filme filme);
        HttpResponseMessage Delete(string token, int id);
    }
}
