using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Web.Models.Categoria
{
    public class Categoria
    {
        public Categoria()
        {
            
        }

        public Categoria(string nome, int cadastroUsuarioId, bool ativo)
        {
            Nome = nome;
            CadastroUsuarioId = cadastroUsuarioId;
            Ativo = ativo;
        }

        public Categoria(int id, string nome, int alteracaoUsuarioId, bool ativo)
        {
            CategoriaId = id;
            Nome = nome;
            AlteracaoUsuarioId = alteracaoUsuarioId;
            Ativo = ativo;
        }

        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public int CadastroUsuarioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? AlteracaoUsuarioId { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
