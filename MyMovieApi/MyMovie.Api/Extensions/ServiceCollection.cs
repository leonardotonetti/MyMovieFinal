using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyMovie.Api.Core;
using MyMovie.Api.Core.Categoria;
using MyMovie.Api.Core.Filme;
using MyMovie.Api.Core.Usuario;
using MyMovie.Api.Data;
using MyMovie.Api.Repository.Categoria;
using MyMovie.Api.Repository.Filme;
using MyMovie.Api.Repository.Usuario;

namespace MyMovie.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();

            services.AddTransient<IFilmeService, FilmeService>();
            services.AddTransient<IFilmeRepository, FilmeRepository>();

            services.AddDbContext<MyMovieContext>(options => options.UseSqlServer(config.GetConnectionString("MyMovie")));
            return services;
        }
    }
}
