using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyMovie.Web.ViewModel.Categoria;

namespace MyMovie.Web.ViewModel.Filme
{
    public class FilmeViewModel
    {
        public FilmeViewModel()
        {
            ComboCategoria = new SelectList(Enumerable.Empty<object>());
        }

        public int FilmeId { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [MaxLength(30, ErrorMessage = "O Tamanho maxímo do campo Nome é de 30 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição")]
        [MaxLength(100, ErrorMessage = "O Tamanho maxímo do campo Nome é de 100 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a Categoria")]
        public int CategoriaId { get; set; }
        public int CadastroUsuarioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? AlteracaoUsuarioId { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        public CategoriaViewModel Categoria { get; set; }

        public SelectList ComboCategoria { get; set; }
    }
}
