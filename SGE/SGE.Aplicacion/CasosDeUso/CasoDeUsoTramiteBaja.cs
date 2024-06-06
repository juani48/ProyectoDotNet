namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repotramite,IExpedienteRepositorio repoExpediente,IServicioActualizacionEstado servicio,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(tramite.IdUsuario,Permiso.TramiteBaja)){

                int? num = repotramite.obtenerTramite(tramite.Id).ExpedienteId;
                if(num != null){
                    tramite.ExpedienteId = num;
                    repotramite.eliminarTramite(tramite.Id);
                    Expediente? expediente= repoExpediente.obtenerExpediente(tramite.ExpedienteId);
                    if(expediente != null){
                        expediente.IdUsuario=tramite.IdUsuario;
                        servicio.ActualizarEstadoExpediente(expediente);
                    }
                    else{
                        throw new RepositorioException("no existe un expediente aso");
                    }
                }
                      
            }else{
                throw new RepositorioException("no existe el tramite a eliminar");
            }
        }else{
            throw new AutorizacionException("No posee los permisos");
        }
    }

}