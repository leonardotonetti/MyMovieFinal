using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyMovie.Api.Data;

namespace MyMovie.Api.Repository.Filme
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly MyMovieContext _myMvieContext;

        public FilmeRepository(MyMovieContext myMovieContext)
        {
            _myMvieContext = myMovieContext;
        }

        public IEnumerable<Data.Filme.Filme> Get()
        {
            return _myMvieContext.Filme.Include(c => c.Categoria);    
        }

        public Data.Filme.Filme Get(int id)
        {
            return _myMvieContext.Filme.Include(c => c.Categoria).FirstOrDefault(x => x.FilmeId == id);
        }

        public void Post(Data.Filme.Filme filme)
        {
            _myMvieContext.Add(filme);
            _myMvieContext.SaveChanges();
        }

        public void Put(Data.Filme.Filme filme)
        {
            _myMvieContext.Update(filme);
            _myMvieContext.SaveChanges();
        }

        public void Delete(Data.Filme.Filme filme)
        {
            _myMvieContext.Remove(filme);
            _myMvieContext.SaveChanges();
        }
    }
}
