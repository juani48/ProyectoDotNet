namespace SGE.Aplicacion;

public class CasoDeUsoRegistrarUsuario(IUsuarioRepositorio usuarioRepositorio, ServicioSesionUsuario servicioSesionUsuario)
{
    public void Ejecutar(Usuario usuario, string contrasena)
    {   
        if(!usuarioRepositorio.RegistrarUsuario(usuario, contrasena)){
            throw new RepositorioException("Ya existe un usuario con ese nombre y contraseña");
        }
        servicioSesionUsuario.UsuarioActual = usuario;
    }
}