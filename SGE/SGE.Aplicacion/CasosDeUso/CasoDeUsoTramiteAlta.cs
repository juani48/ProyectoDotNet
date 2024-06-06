using System.Net;

namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoTramite,IExpedienteRepositorio repoExpediente,IServicioActualizacionEstado servicio,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Tramite tramite) //id tramite, id expediente, id usuario
    {     
          if(autorizacion.PoseeElPermiso(tramite.IdUsuario,Permiso.TramiteAlta))
          {
                TramiteValidador.ValidarTramite(tramite);
                Expediente? expediente= repoExpediente.obtenerExpediente(tramite.ExpedienteId);
                if( expediente !=null ){
                    repoTramite.agregarTramite(tramite);
                    expediente.IdUsuario= tramite.IdUsuario;
                    servicio.ActualizarEstadoExpediente(expediente);
                }
                else
                {
                    throw new RepositorioException("no se encuentra un expediente relacionado con este tramite.");
                }
          }
          else
          {
            throw new AutorizacionException("No posee los permisos.");
          }    
    }
}
