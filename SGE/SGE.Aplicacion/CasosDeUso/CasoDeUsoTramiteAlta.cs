namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo,ServicioActualizacionEstado servicio)
{
    public void Ejecutar(Tramite tramite)
    {     //consultar por id =1
          //validacion de tramite
            repo.agregarTramite(tramite);
            servicio.ActualizarEstadoExpediente(tramite.ExpedienteId);
    
    }
}
