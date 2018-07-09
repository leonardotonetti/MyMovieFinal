using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovie.Api.Data;

namespace MyMovie.Api.Repository.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyMovieContext _myMovieContext;

        public UsuarioRepository(MyMovieContext myMovieContext)
        {
            _myMovieContext = myMovieContext;
        }

        public Data.Usuario.Usuario Get(string usuario, string senha)
        {
            return _myMovieContext.Usuario.FirstOrDefault(x => x.User == usuario && x.Senha == senha);
        }

        public Data.Usuario.Usuario Post(Data.Usuario.Usuario novoUsuario)
        {
            var usuarioInserido = _myMovieContext.Usuario.Add(novoUsuario);
            _myMovieContext.SaveChanges();

            return usuarioInserido.Entity;
        }
    }
}
