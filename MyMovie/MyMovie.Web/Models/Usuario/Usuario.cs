using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Web.Models.Usuario
{
    public class Usuario
    {
        public Usuario()
        {
            
        }

        public Usuario(string user, string senha)
        {
            User = user;
            Senha = senha;
        }

        public Usuario(string user, string senha, string email)
        {
            User = user;
            Senha = senha;
            Email = email;
        }

        public int UsuarioId { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Token { get; set; }
    }
}
