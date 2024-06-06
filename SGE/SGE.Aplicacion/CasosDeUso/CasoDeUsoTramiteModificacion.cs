namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo,ServicioActualizacionEstado servicio)
{
    public void Ejecutar(Tramite tramite) { 
        //consultar por id=1
        //validacion de tramite
            repo.modificarTramite(tramite);
            servicio.ActualizarEstadoExpediente(tramite.ExpedienteId);

        //trow no tiene autorizacion
    }
}
