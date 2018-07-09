namespace MyMovie.Api.Core.Usuario
{
    public interface IUsuarioService
    {
        Usuario Get(string usuario, string senha);
        Usuario Post(Usuario novoUsuario);
    }
}
