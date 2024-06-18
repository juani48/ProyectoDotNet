namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, 
                                            IServicioActualizacionEstado actualizacionEstado, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Tramite tramite)
    { 
        if(autorizacion.PoseeElPermiso(Permiso.TramiteModificacion))
        {
            TramiteValidador.ValidarTramite(tramite);
            tramite.ExpedienteId = tramiteRepositorio.ObtenerIdExpediente(tramite.Id); //busco su expedienteID
            if(tramite.ExpedienteId != -1)
            {
                tramiteRepositorio.ModificarTramite(tramite);
                Expediente? expediente = expedienteRepositorio.ObtenerExpediente(tramite.ExpedienteId);
                if(expediente != null)
                {
                    expediente.IdUsuario = tramite.IdUsuario;
                    actualizacionEstado.ActualizarEstadoExpediente(expediente);
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
            throw new AutorizacionException("El usuario no posee permisos para modificar un Tramite.");
        }

    }
}
