using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Repository.Filme
{
    public interface IFilmeRepository
    {
        IEnumerable<Data.Filme.Filme> Get();
        Data.Filme.Filme Get(int id);
        void Post(Data.Filme.Filme filme);
        void Put(Data.Filme.Filme filme);
        void Delete(Data.Filme.Filme filme);
    }
}
