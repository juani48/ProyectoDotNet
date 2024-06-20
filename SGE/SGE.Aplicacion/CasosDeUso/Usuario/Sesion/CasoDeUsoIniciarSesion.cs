namespace SGE.Aplicacion;

public class CasoDeUsoIniciarSesion (IUsuarioRepositorio usuarioRepositorio, ServicioSesionUsuario servicioSesionUsuario , IServicioEncriptador servicioEncriptador)
{
     public void Ejecutar(string nombre, string contraseña)
    {
        if((nombre != "")&&(contraseña != "")){
            contraseña = servicioEncriptador.EncriptarSHA256(contraseña);
            
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
}
