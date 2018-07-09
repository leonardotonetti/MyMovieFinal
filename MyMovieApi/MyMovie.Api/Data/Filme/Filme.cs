using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Data.Filme
{
    public class Filme
    {
        public int FilmeId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Required]
        [ForeignKey("CadastroUsuario")]
        public int CadastroUsuarioId { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("AlteracaoUsuario")]
        public int? AlteracaoUsuarioId { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Ativo { get; set; }

        [InverseProperty("FilmeCadastro")]
        public virtual Usuario.Usuario CadastroUsuario { get; set; }
        [InverseProperty("FilmeAlteracao")]
        public virtual Usuario.Usuario AlteracaoUsuario { get; set; }
        public virtual Categoria.Categoria Categoria { get; set; }
    }
}
