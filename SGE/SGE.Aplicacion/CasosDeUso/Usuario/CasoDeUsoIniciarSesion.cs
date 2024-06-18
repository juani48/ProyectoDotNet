namespace SGE.Aplicacion;

public class CasoDeUsoIniciarSesion(IUsuarioRepositorio usuarioRepositorio, ServicioSesionUsuario servicioSesionUsuario)
{
    public void Ejecutar(string nombre, string contrasena)
    {
        Usuario? usuario = usuarioRepositorio.IniciarSesion(nombre, contrasena);
        if(usuario == null){
            throw new RepositorioException($"No existe un usuario con nombre: {nombre}");
        }
        servicioSesionUsuario.UsuarioActual = usuario;
    }
}