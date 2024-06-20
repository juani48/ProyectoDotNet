namespace SGE.Aplicacion;

public class CasoDeUsoCerrarSesionActual (ServicioSesionUsuario servicioSesionUsuario)
{
    public void Ejecutar (Usuario usuario){
        if(usuario == servicioSesionUsuario.UsuarioActual){
            servicioSesionUsuario.UsuarioActual = new Usuario();
        }
    }
}
