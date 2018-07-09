using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Core.Filme
{
    public class FilmeDto
    {
        public int FilmeId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public int CadastroUsuarioId { get; set; }
        public int? AlteracaoUsuarioId { get; set; }
        public bool Ativo { get; set; }
    }
}
