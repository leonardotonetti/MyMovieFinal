using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Core.Categoria
{
    public class Categoria
    {
        public Categoria()
        {
            
        }

        public Categoria(string nome, int idUsuario, bool ativo)
        {
            Nome = nome;
            CadastroUsuarioId = idUsuario;
            DataCadastro = DateTime.Now;
            Ativo = ativo;
        }

        public Categoria(int id, string nome, int idUsuario, bool ativo)
        {
            CategoriaId = id;
            Nome = nome;
            AlteracaoUsuarioId = idUsuario;
            DataAlteracao = DateTime.Now;
            Ativo = ativo;
        }

        public Categoria(int id, string nome)
        {
            CategoriaId = id;
            Nome = nome;
        }

        public int CategoriaId { get; }
        public string Nome { get; }
        public int CadastroUsuarioId { get; }
        public DateTime DataCadastro { get; }
        public int? AlteracaoUsuarioId { get; }
        public DateTime? DataAlteracao { get; }
        public bool Ativo { get; }

        public Usuario.Usuario UsuarioCadastro { get; }
        public Usuario.Usuario UsuarioAlteracao { get; }
    }
}
