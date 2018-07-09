using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Core.Filme
{
    public class Filme
    {
        public Filme(int id, string nome, string descricao, int categoriaId, string nomeCategoria, int cadastroUsuarioId, DateTime dataCadastro, int? alteracaoUsuarioId,
            DateTime? dataAlteracao, bool ativo)
        {
            FilmeId = id;
            Nome = nome;
            Descricao = descricao;
            Categoria = new Categoria.Categoria(categoriaId, nomeCategoria);
            CadastroUsuarioId = cadastroUsuarioId;
            DataCadastro = dataCadastro;
            AlteracaoUsuarioId = alteracaoUsuarioId;
            DataAlteracao = dataAlteracao;
            Ativo = ativo;
        }

        public Filme(string nome, string descricao, int categoriaId, int cadastroUsuarioId, bool ativo)
        {
            Nome = nome;
            Descricao = descricao;
            CategoriaId = categoriaId;
            CadastroUsuarioId = cadastroUsuarioId;
            DataCadastro = DateTime.Now;
            Ativo = ativo;
        }

        public Filme(int id, string nome, string descricao, int categoriaId, int alteracaoUsuarioId, bool ativo)
        {
            FilmeId = id;
            Nome = nome;
            Descricao = descricao;
            CategoriaId = categoriaId;
            AlteracaoUsuarioId = alteracaoUsuarioId;
            DataAlteracao = DateTime.Now;
            Ativo = ativo;
        }

        public int FilmeId { get; }
        public string Nome { get; }
        public string Descricao { get; }
        public int CategoriaId { get; }
        public int CadastroUsuarioId { get; }
        public DateTime DataCadastro { get; }
        public int? AlteracaoUsuarioId { get; }
        public DateTime? DataAlteracao { get; }
        public bool Ativo { get; }

        public Usuario.Usuario CadastroUsuario { get; }
        public Usuario.Usuario AlteracaoUsuario { get; }
        public Categoria.Categoria Categoria { get; }
    }
}
