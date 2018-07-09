using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyMovie.Api.Data
{
    public class MyMovieContext : DbContext
    {
        public MyMovieContext(DbContextOptions context) : base(context)
        {

        }

        public DbSet<Usuario.Usuario> Usuario { get; set; }
        public DbSet<Categoria.Categoria> Categoria { get; set; }
        public DbSet<Filme.Filme> Filme { get; set; }
    }
}
