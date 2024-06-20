namespace SGE.Aplicacion;

public class CasoDeUsoVerificarIdentidad (IUsuarioRepositorio usuarioRepositorio, ServicioSesionUsuario servicioSesionUsuario, IServicioEncriptador servicioEncriptador)
{
    public void Ejecutar(string nombre, string contraseña)
    {   
        if((nombre == "")||(contraseña == "")){
            throw new ValidacionException("Los datos ingresados no pueden estar vacios.");
        }
        contraseña = servicioEncriptador.EncriptarSHA256(contraseña);
        if(!usuarioRepositorio.VerificarUsuario(servicioSesionUsuario.UsuarioActual, nombre, contraseña)){
                throw new RepositorioException("El nombre y la contraseña ingresados no coinciden con el usuario que inicio sesion.");
        }        
    }
}
