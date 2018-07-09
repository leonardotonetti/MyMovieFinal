using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyMovie.Api.Core.Categoria
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public int CadastroUsuarioId { get; set; }
        public int? AlteracaoUsuarioId { get; set; }
        public bool Ativo { get; set; }
    }
}
