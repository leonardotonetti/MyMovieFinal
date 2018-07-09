using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MyMovie.Web.Application.Categoria;
using MyMovie.Web.Application.Filme;
using MyMovie.Web.Application.Login;
using MyMovie.Web.Application.Usuario;

namespace MyMovie.Web.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ILoginApplication, LoginApplication>();
            services.AddTransient<IUsuarioApplication, UsuarioApplication>();
            services.AddTransient<ICategoriaApplication, CategoriaApplication>();
            services.AddTransient<IFilmeApplication, FilmeApplication>();

            return services;
        }
    }
}
