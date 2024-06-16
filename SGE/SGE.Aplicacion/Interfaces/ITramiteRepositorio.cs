namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    
    void AgregarTramite(Tramite tramite);
    bool EliminarTramite(int id);
    Tramite? ObtenerTramite(int id);
    void ModificarTramite(Tramite tramite);
    List<Tramite> ListarTramitesPorEtiqueta(EtiquetaTramite etiqueta);

    //interaccion con expedientes
    EtiquetaTramite? ObtenerEtiqueta(int id);
    List<Tramite> ListarTramitesPorExpedienteID(int idExpediente);
    void EliminarTramitesPorIdExpediente(int idExpediente);
    int ObtenerIdExpediente (int idTramite);
    EtiquetaTramite ObtenerEtiquetaUltimoTramite(int idExpediente);
}
