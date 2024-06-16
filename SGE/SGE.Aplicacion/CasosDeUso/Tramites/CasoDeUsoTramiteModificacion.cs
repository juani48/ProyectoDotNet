namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo,IExpedienteRepositorio repoExpediente,IServicioActualizacionEstado servicio,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Tramite tramite)
    { 
        if(autorizacion.PoseeElPermiso(tramite.IdUsuario,Permiso.tramiteModificacion))
        {
            TramiteValidador.ValidarTramite(tramite);
            tramite.ExpedienteId = repo.ObtenerIdExpediente(tramite.Id); //busco su expedienteID
            if(tramite.ExpedienteId != -1)
            {
                repo.ModificarTramite(tramite);
                Expediente? expediente = repoExpediente.ObtenerExpediente(tramite.ExpedienteId);
                if(expediente != null)
                {
                    expediente.IdUsuario = tramite.IdUsuario;
                    servicio.ActualizarEstadoExpediente(expediente);
                }
                else
                {
                    throw new RepositorioException("No existe un expediente asociado.");
                }
            }
            else
            {
                throw new RepositorioException("No existe el tramite a modificar.");
            }
        }
        else
        {
            throw new AutorizacionException("No posee permiso.");
        }

    }
}
