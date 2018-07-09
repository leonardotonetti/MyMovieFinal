using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Web.Models.Filme
{
    public class Filme
    {
        public Filme()
        {
            
        }

        public Filme(string nome, string descricao, int categoriaId, int cadastroUsuarioId, bool ativo)
        {
            Nome = nome;
            Descricao = descricao;
            CategoriaId = categoriaId;
            CadastroUsuarioId = cadastroUsuarioId;
            Ativo = ativo;
        }

        public Filme(int id, string nome, string descricao, int categoriaId, int alteracaoUsuarioId, bool ativo)
        {
            FilmeId = id;
            Nome = nome;
            Descricao = descricao;
            CategoriaId = categoriaId;
            AlteracaoUsuarioId = alteracaoUsuarioId;
            Ativo = ativo;
        }

        public int FilmeId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public int CadastroUsuarioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? AlteracaoUsuarioId { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        public Categoria.Categoria Categoria { get; set; }
    }
}
