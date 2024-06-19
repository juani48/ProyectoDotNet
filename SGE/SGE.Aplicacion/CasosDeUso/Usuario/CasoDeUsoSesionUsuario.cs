namespace SGE.Aplicacion;

public class CasoDeUsoSesionUsuario (IUsuarioRepositorio usuarioRepositorio, ServicioSesionUsuario servicioSesionUsuario)
{
    public void IniciarSesion(string nombre, string contraseña)
    {
        if((nombre != "")&&(contraseña != "")){
            Usuario? usuario = usuarioRepositorio.IniciarSesion(nombre, contraseña);
            if(usuario == null){
                throw new RepositorioException($"No existe un usuario con nombre: {nombre}");
            }
            servicioSesionUsuario.UsuarioActual = usuario;
        }
        else{
            throw new ValidacionException("Los datos ingresados no pueden estar vacios.");
        }
        
    }

    public void RegistrarUsuario(Usuario usuario, string contrasena)
    {   
        if((usuario.Nombre == "")||(contrasena == "")||(usuario.Correo == "")||(usuario.Apellido == "")){
            throw new ValidacionException("Los datos ingresados no pueden estar vacios.");
        }
        if(!usuarioRepositorio.RegistrarUsuario(usuario, contrasena)){
            throw new RepositorioException("Ya existe un usuario con ese nombre y contraseña");
        }
        servicioSesionUsuario.UsuarioActual = usuario;
    }

    public Usuario SesionActual(){
        return servicioSesionUsuario.UsuarioActual;
    }

    public void CerrarSesion (Usuario usuario){
        if(usuario == servicioSesionUsuario.UsuarioActual){
            servicioSesionUsuario.UsuarioActual = new Usuario();
        }
    }
}
