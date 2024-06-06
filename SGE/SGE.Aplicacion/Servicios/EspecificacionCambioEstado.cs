namespace SGE.Aplicacion;

public class EspecificacionCambioEstado
{
    public EstadoExpediente DeterminarNuevoEstado(EtiquetaTramite etiquetaUltimoTramite, EstadoExpediente estadoExpediente)
    {
        // Lógica para determinar el nuevo estado basado en la etiqueta del último trámite
        switch (etiquetaUltimoTramite)
        {
            case EtiquetaTramite.Resolucion:
                return EstadoExpediente.ConResolucion;
            case EtiquetaTramite.PaseAEstudio:
                return EstadoExpediente.ParaResolver;
            case EtiquetaTramite.PaseAlArchivo:
                return EstadoExpediente.Finalizado;
            default:
                return estadoExpediente;
        }
    }
}