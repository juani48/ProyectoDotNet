namespace SGE.Aplicacion;

public class CasoDeUsoVerificarUsuario(IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorizacion, ServicioSesionUsuario servicioSesionUsuario)
{
    public void Ejecutar(string nombre, string contrasena)
    {
        if(!usuarioRepositorio.VerificarUsuario(servicioSesionUsuario.UsuarioActual, nombre, contrasena))
           throw new RepositorioException("El nombre y la contraseña ingresados no coinciden con el usuario que inicio sesion anteriormente.");
    }

    public void Ejecutar(PermisoAdministrador permisoAdministrador){
        if(!servicioAutorizacion.PoseePermisoAdministrador(permisoAdministrador)){
            throw new AutorizacionException("El usuario no posee permisos de administrador.");
        }
    }
    public void Ejecutar(Permiso permiso){
        if(!servicioAutorizacion.PoseeElPermiso(permiso)){
            throw new AutorizacionException("El usuario no posee permisos para realizar esta accion.");
        }
    }
}