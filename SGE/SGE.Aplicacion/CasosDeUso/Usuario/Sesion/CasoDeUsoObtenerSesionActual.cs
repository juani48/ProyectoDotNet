namespace SGE.Aplicacion;

public class CasoDeUsoObtenerSesionActual (ServicioSesionUsuario servicioSesionUsuario)
{
    public Usuario Ejecutar(){
        return servicioSesionUsuario.UsuarioActual;
    } 
}
