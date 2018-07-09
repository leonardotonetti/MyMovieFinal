using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Data.Usuario
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(50)]
        public string User { get; set; }

        [Required]
        [MaxLength(50)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public virtual IEnumerable<Categoria.Categoria> CategoriaCadastro { get; set; }
        public virtual IEnumerable<Categoria.Categoria> CategoriaAlteracao { get; set; }
        public virtual IEnumerable<Filme.Filme> FilmeCadastro { get; set; }
        public virtual IEnumerable<Filme.Filme> FilmeAlteracao { get; set; }
    }
}
