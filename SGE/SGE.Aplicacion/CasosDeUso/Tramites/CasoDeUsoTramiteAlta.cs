using System.Net;

namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoTramite,IExpedienteRepositorio repoExpediente,IServicioActualizacionEstado servicio,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Tramite tramite) //id tramite, id expediente, id usuario
    {     
          if(autorizacion.PoseeElPermiso(Permiso.TramiteAlta))
          {
                TramiteValidador.ValidarTramite(tramite);
                Expediente? expediente= repoExpediente.ObtenerExpediente(tramite.ExpedienteId);
                if( expediente !=null ){
                    repoTramite.AgregarTramite(tramite);
                    expediente.IdUsuario= tramite.IdUsuario;
                    servicio.ActualizarEstadoExpediente(expediente);
                }
                else
                {
                    throw new RepositorioException("No se encuentra un expediente relacionado con este tramite.");
                }
          }
          else
          {
            throw new AutorizacionException("El usuario no posee permisos para realizar un alta de Tramites.");
          }    
    }
}
