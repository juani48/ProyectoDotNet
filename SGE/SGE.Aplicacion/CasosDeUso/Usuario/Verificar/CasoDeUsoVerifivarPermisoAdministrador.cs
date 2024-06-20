namespace SGE.Aplicacion;

public class CasoDeUsoVerifivarPermisoAdministrador (IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(PermisoAdministrador permisoAdministrador){
        if(!servicioAutorizacion.PoseePermisoAdministrador(permisoAdministrador)){
            throw new AutorizacionException("El usuario no posee permisos de administrador.");
        }
    }
}
