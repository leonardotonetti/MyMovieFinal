using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyMovie.Web.Models.Usuario;
using Newtonsoft.Json;

namespace MyMovie.Web.Extensions
{
    public static class Session
    {
        public static void SetUsuario(this ISession session, Usuario usuario)
        {
            session.SetString("Usuario", JsonConvert.SerializeObject(usuario));
        }

        public static Usuario GetUsuario(this ISession session)
        {
            var value = session.GetString("Usuario");
            return value == null ? null : JsonConvert.DeserializeObject<Usuario>(value);
        }
    }
}
