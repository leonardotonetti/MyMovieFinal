using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Core.Filme
{
    public interface IFilmeService
    {
        IEnumerable<Filme> Get();
        Filme Get(int id);
        void Post(Filme novoFilme);
        void Put(Filme filme);
        void Delete(int id);
    }
}
