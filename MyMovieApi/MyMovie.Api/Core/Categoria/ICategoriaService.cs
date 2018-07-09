using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Core.Categoria
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        Categoria Get(int id);
        void Post(Categoria novaCategoria);
        void Put(Categoria categoria);
        void Delete(int id);
    }
}
