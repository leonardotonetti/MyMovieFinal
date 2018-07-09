using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Core.Usuario
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
