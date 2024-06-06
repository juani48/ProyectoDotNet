namespace SGE.Aplicacion;
public class ServicioActualizacionEstado (IExpedienteRepositorio _repositorioExpediente, ITramiteRepositorio _repositorioTramite) : IServicioActualizacionEstado
{
    public void ActualizarEstadoExpediente(Expediente expediente)
    {
        //actualizar el estado del expediente basado en el último trámite
        EtiquetaTramite etiquetaUltimoTramite = _repositorioTramite.ObtenerEtiquetaUltimoTramite(expediente.Id);
        EstadoExpediente estadoActual = expediente.EstadoExpediente;
        EstadoExpediente nuevoEstado = new EspecificacionCambioEstado().DeterminarNuevoEstado(etiquetaUltimoTramite,estadoActual); //va a buscar el nuevo estado que corresponde
        expediente.EstadoExpediente=nuevoEstado;
        if(!_repositorioExpediente.ActualizarEstadoExpediente(expediente)){
            throw new RepositorioException("No existe el expediente para actualizar estado.");
        }
    }
}
