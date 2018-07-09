using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyMovie.Api.Data.Categoria
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("CadastroUsuario")]
        public int CadastroUsuarioId { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("AlteracaoUsuario")]
        public int? AlteracaoUsuarioId { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Ativo { get; set; }

        [InverseProperty("CategoriaCadastro")]
        public virtual Usuario.Usuario CadastroUsuario { get; set; }
        [InverseProperty("CategoriaAlteracao")]
        public virtual Usuario.Usuario AlteracaoUsuario { get; set; }
        public virtual Filme.Filme Filme { get; set; }
    }
}
