using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Repository.Categoria
{
    public interface ICategoriaRepository
    {
        IEnumerable<Core.Categoria.Categoria> Get();
        Core.Categoria.Categoria Get(int id);
        void Post(Core.Categoria.Categoria categoria);
        void Put(Core.Categoria.Categoria categoria);
        void Delete(int id);
    }
}
