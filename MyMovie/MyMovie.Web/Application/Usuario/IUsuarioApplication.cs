using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyMovie.Web.Application.Usuario
{
    public interface IUsuarioApplication
    {
        HttpResponseMessage Get(Models.Usuario.Usuario usuario);
        HttpResponseMessage Post(Models.Usuario.Usuario usuario);
    }
}
