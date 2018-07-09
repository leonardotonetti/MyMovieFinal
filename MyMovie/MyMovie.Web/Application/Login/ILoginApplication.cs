using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyMovie.Web.Application.Login
{
    public interface ILoginApplication
    {
        HttpResponseMessage Entrar(Models.Usuario.Usuario usuario);
    }
}
