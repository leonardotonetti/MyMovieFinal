using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MyMovie.Api.Extensions;
using MyMovie.Api.Repository.Categoria;
using MyMovie.Api.Repository.Filme;

namespace MyMovie.Api.Core.Categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IFilmeRepository _filmeRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository, IFilmeRepository filmeRepository)
        {
            _categoriaRepository = categoriaRepository;
            _filmeRepository = filmeRepository;
        }

        public IEnumerable<Categoria> Get()
        {
            try
            {
                var lstCategoria = _categoriaRepository.Get();
                return lstCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categoria Get(int id)
        {
            try
            {
                var categoria = _categoriaRepository.Get(id);

                if (categoria == null)
                {
                    Notification.SetNotification("Categoria", "Categoria não encontrada");
                    return null;
                }

                return categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Post(Categoria novaCategoria)
        {
            try
            {
                var categoria = _categoriaRepository.Get().FirstOrDefault(x => x.Nome == novaCategoria.Nome);
                if (categoria != null)
                {
                    Notification.SetNotification("Categoria", "Categoria já cadastrada");
                    return;
                }

                _categoriaRepository.Post(novaCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Put(Categoria categoria)
        {
            try
            {
                var categoriaExistente = _categoriaRepository.Get(categoria.CategoriaId);
                if (categoriaExistente == null)
                {
                    Notification.SetNotification("Categoria", "Categoria não encontrada");
                    return;
                }

                var categorias = _categoriaRepository.Get().Where(x => x.CategoriaId != categoria.CategoriaId);
                if (categorias.Any(x => x.Nome == categoria.Nome))
                {
                    Notification.SetNotification("Categoria", "Categoria já cadastrada");
                    return;
                }

                _categoriaRepository.Put(categoria);
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
                var categoriaExistente = _categoriaRepository.Get(id);
                if (categoriaExistente == null)
                {
                    Notification.SetNotification("Categoria", "Categoria não encontrada");
                    return;
                }

                var filmes = _filmeRepository.Get();
                if (filmes.Any(x => x.Categoria.CategoriaId == id))
                {
                    Notification.SetNotification("Categoria", "Não foi possível excluir a Categoria, pois está relacionada à um Filme");
                    return;
                }

                _categoriaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
