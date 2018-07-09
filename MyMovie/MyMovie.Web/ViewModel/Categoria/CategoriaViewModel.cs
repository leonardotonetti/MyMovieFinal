using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Web.ViewModel.Categoria
{
    public class CategoriaViewModel
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Informe o Nome")]
        [MaxLength(30, ErrorMessage = "O tamanho maxímo do campo Nome é de 30 caracteres")]
        public string Nome { get; set; }
        public int CadastroUsuarioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? AlteracaoUsuarioId { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
