using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Repository.Usuario
{
    public interface IUsuarioRepository
    {
        IEnumerable<Data.Usuario.Usuario> Get();
        Data.Usuario.Usuario Get(string usuario, string senha);
        Data.Usuario.Usuario Post(Data.Usuario.Usuario novoUsuario);
    }
}
