namespace SGE.Aplicacion;

public class CasoDeUsoVerificarUsuario(IUsuarioRepositorio usuarioRepositorio)
{
    public void Ejecutar(Usuario usuario, string nombre, string contrasena)
    {
        if(!usuarioRepositorio.VerificarUsuario(usuario, nombre, contrasena))
           throw new RepositorioException("El nombre y la contraseña ingresados no coinciden con el usuario que inicio sesion anteriormente.");
    }
}