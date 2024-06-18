namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Expediente expediente){
        if(servicioAutorizacion.PoseeElPermiso(Permiso.ExpedienteAlta)){
            ExpedienteValidador.ValidarExpediente(expediente);
            expedienteRepositorio.AgregarExpediente(expediente);
        }
        else{
            throw new AutorizacionException("El usuario no posee permisos para realizar una alta de Expedientes.");
        }
    }
}
