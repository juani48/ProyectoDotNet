namespace SGE.Aplicacion;
public class ServicioActualizacionEstado (IExpedienteRepositorio _repositorioExpediente, ITramiteRepositorio _repositorioTramite) : IServicioActualizacionEstado
{
    public void ActualizarEstadoExpediente(Expediente expediente)
    {
        //actualizar el estado del expediente basado en el último trámite
        EtiquetaTramite etiquetaUltimoTramite = _repositorioTramite.ObtenerEtiquetaUltimoTramite(expediente.Id);
        
        expediente.EstadoExpediente = new EspecificacionCambioEstado().DeterminarNuevoEstado(etiquetaUltimoTramite, expediente.EstadoExpediente); //va a buscar el nuevo estado que corresponde
        
        if(!_repositorioExpediente.ModificarExpediente(expediente)){
            throw new RepositorioException("No existe el expediente para actualizar estado.");
        }
    }
}
