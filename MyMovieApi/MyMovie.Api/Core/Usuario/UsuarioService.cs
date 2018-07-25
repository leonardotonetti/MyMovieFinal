using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyMovie.Api.Data;
using MyMovie.Api.Extensions;
using MyMovie.Api.Repository.Usuario;

namespace MyMovie.Api.Core.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Get(string usuario, string senha)
        {
            try
            {
                var usuarioData = _usuarioRepository.Get(usuario, senha);
                if (usuarioData == null)
                {
                    Notification.SetNotification("Usuario", "Usuário não encontrado");
                    return null;
                }

                return new Usuario(usuarioData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Post(Usuario novoUsuario)
        {
            try
            {
                var usuarioData = _usuarioRepository.Get().FirstOrDefault(x => x.User == novoUsuario.User);
                if (usuarioData != null)
                {
                    Notification.SetNotification("Usuario", "Usuário já cadastrado");
                    return null;
                }

                var usuarioInserido = _usuarioRepository.Post(new Data.Usuario.Usuario
                {
                    User = novoUsuario.User,
                    Senha = novoUsuario.Senha,
                    Email = novoUsuario.Email,
                    DataCadastro = novoUsuario.DataCadastro
                });

                novoUsuario.SetUsuarioId(usuarioInserido.UsuarioId);

                return novoUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
