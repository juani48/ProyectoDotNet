namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repotramite,IExpedienteRepositorio repoExpediente,IServicioActualizacionEstado servicio,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Tramite tramite) //recibo tramite con su id y idusuario
    {
        if (autorizacion.PoseeElPermiso(tramite.IdUsuario,Permiso.TramiteBaja))
        {
                tramite.ExpedienteId = repotramite.ObtenerIdExpediente(tramite.Id); //busco su expedienteID
                if(tramite.ExpedienteId != -1 )
                {
                        repotramite.EliminarTramite(tramite.Id);
                        Expediente? expediente= repoExpediente.ObtenerExpediente(tramite.ExpedienteId); //le paso iExpediente
                        if(expediente != null)
                        {
                            expediente.IdUsuario=tramite.IdUsuario;
                            servicio.ActualizarEstadoExpediente(expediente);
                        }
                        else
                        {
                            throw new RepositorioException("no existe un expediente asociado.");
                        }
                    }
                    else
                    {
                        throw new RepositorioException("no existe el tramite a eliminar.");
                    
                    }
        }
        else
        {
            throw new AutorizacionException("No posee los permisos.");
        }
    }

}