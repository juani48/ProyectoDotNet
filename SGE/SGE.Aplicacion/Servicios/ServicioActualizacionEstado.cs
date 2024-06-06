namespace SGE.Aplicacion;
public class ServicioActualizacionEstado (IExpedienteRepositorio _repositorioExpediente, ITramiteRepositorio _repositorioTramite)
{
    public void ActualizarEstadoExpediente(Expediente expediente)
    {
        // Lógica para actualizar el estado del expediente basado en el último trámite
        EtiquetaTramite etiquetaTramite = _repositorioTramite.ObtenerEtiquetaUltimoTramite(expediente.Id);
        expediente.EstadoExpediente = new EspecificacionCambioEstado().DeterminarNuevoEstado(etiquetaTramite, expediente.EstadoExpediente); //va a buscar el nuevo estado que corresponde
        _repositorioExpediente.ActualizarEstadoExpediente(expediente);
    }
}
