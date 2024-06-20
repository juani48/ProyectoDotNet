namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioActivo (ServicioSesionUsuario servicioSesionUsuario)
{
    public void Ejecutar(out bool error){
        if(servicioSesionUsuario.UsuarioActual.Id == 0){
            error = true;
            throw new ValidacionException("Se debe iniciar sesion para acceder al sistema.");
        }
        error = false;
    }
}
