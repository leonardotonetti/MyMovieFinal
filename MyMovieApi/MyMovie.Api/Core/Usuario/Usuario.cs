using System;

namespace MyMovie.Api.Core.Usuario
{
    public class Usuario
    {
        public Usuario(Data.Usuario.Usuario usuario)
        {
            UsuarioId = usuario.UsuarioId;
            User = usuario.User;
            Senha = usuario.Senha;
            Email = usuario.Email;
            DataCadastro = usuario.DataCadastro;
        }

        public Usuario(string user, string senha, string email)
        {
            User = user;
            Senha = senha;
            Email = email;
            DataCadastro = DateTime.Now;
        }

        public int UsuarioId { get; private set; }
        public string User { get; }
        public string Senha { get; }
        public string Email { get; }
        public DateTime DataCadastro { get; }
        public string Token { get; set; }

        public void SetUsuarioId(int usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}
