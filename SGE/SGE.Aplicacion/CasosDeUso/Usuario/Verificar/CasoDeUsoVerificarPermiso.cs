namespace SGE.Aplicacion;

public class CasoDeUsoVerificarPermiso (IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Permiso permiso){
        if(!servicioAutorizacion.PoseeElPermiso(permiso)){
            throw new AutorizacionException("El usuario no posee permisos para realizar esta accion.");
        }
    }
}
