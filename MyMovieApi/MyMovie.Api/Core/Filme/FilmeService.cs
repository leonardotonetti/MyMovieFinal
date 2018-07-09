using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovie.Api.Extensions;
using MyMovie.Api.Repository.Filme;

namespace MyMovie.Api.Core.Filme
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public IEnumerable<Filme> Get()
        {
            try
            {
                var filme = _filmeRepository.Get();

                return filme.Select(x => new Filme(
                    x.FilmeId,
                    x.Nome,
                    x.Descricao,
                    x.Categoria.CategoriaId,
                    x.Categoria.Nome,
                    x.CadastroUsuarioId,
                    x.DataCadastro,
                    x.AlteracaoUsuarioId,
                    x.DataAlteracao,
                    x.Ativo
                ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Filme Get(int id)
        {
            try
            {
                var filme = _filmeRepository.Get(id);
                if (filme == null)
                {
                    Notification.SetNotification("Filme", "Filme não encontrado");
                    return null;
                }

                return new Filme(
                    filme.FilmeId,
                    filme.Nome,
                    filme.Descricao,
                    filme.Categoria.CategoriaId,
                    filme.Categoria.Nome,
                    filme.CadastroUsuarioId,
                    filme.DataCadastro,
                    filme.AlteracaoUsuarioId,
                    filme.DataAlteracao,
                    filme.Ativo
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Post(Filme novoFilme)
        {
            try
            {
                var categoria = _filmeRepository.Get().FirstOrDefault(x => x.Nome == novoFilme.Nome);
                if (categoria != null)
                {
                    Notification.SetNotification("Filme", "Filme já cadastrado");
                    return;
                }

                _filmeRepository.Post(new Data.Filme.Filme
                {
                    Nome = novoFilme.Nome,
                    Descricao = novoFilme.Descricao,
                    CategoriaId = novoFilme.CategoriaId,
                    CadastroUsuarioId = novoFilme.CadastroUsuarioId,
                    DataCadastro = novoFilme.DataCadastro,
                    Ativo = novoFilme.Ativo
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Put(Filme filme)
        {
            try
            {
                var filmeExistente = _filmeRepository.Get(filme.FilmeId);
                if (filmeExistente == null)
                {
                    Notification.SetNotification("Filme", "Filme não encontrado");
                    return;
                }

                var filmes = _filmeRepository.Get().Where(x => x.FilmeId != filme.FilmeId);
                if (filmes.Any(x => x.Nome == filme.Nome))
                {
                    Notification.SetNotification("Filme", "Filme já cadastrado");
                    return;
                }

                filmeExistente.FilmeId = filme.FilmeId;
                filmeExistente.Nome = filme.Nome;
                filmeExistente.Descricao = filme.Descricao;
                filmeExistente.CategoriaId = filme.CategoriaId;
                filmeExistente.AlteracaoUsuarioId = filme.AlteracaoUsuarioId;
                filmeExistente.DataAlteracao = filme.DataAlteracao;
                filmeExistente.Ativo = filme.Ativo;

                _filmeRepository.Put(filmeExistente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var filmeExistente = _filmeRepository.Get(id);
                if (filmeExistente == null)
                {
                    Notification.SetNotification("Filme", "Filme não encontrado");
                    return;
                }

                filmeExistente.FilmeId = id;

                _filmeRepository.Delete(filmeExistente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
