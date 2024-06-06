namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    
    void agregarTramite(Tramite tramite);
    bool eliminarTramite(int id);
    Tramite? obtenerTramite(int id);
    void modificarTramite(Tramite tramite);
    List<Tramite> ListarTramitesPorEtiqueta(string etiqueta);
    EtiquetaTramite? obtenerEtiqueta(int id);
    List<Tramite> ListarTramitesPorExpedienteID(int idExpediente);
    void EliminarTramitesPorIdExpediente(int idExpediente);

    EtiquetaTramite ObtenerEtiquetaUltimoTramite(int idExpediente);
    int ObtenerIdExpediente(int id);

}
