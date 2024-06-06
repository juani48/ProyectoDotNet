namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    
    void agregarTramite(Tramite tramite);
    void eliminarTramite(int id);
    public Tramite obtenerTramite(int id);
    public void modificarTramite(Tramite tramite);
    List<Tramite> ListarTramitesPorEtiqueta(string etiqueta);
    public EtiquetaTramite obtenerEtiqueta(int id);
    List<Tramite> ListarTramitesPorExpedienteID(int idExpediente);
    public void EliminarTramitesPorIdExpediente(int idExpediente);

    public EtiquetaTramite ObtenerEtiquetaUltimoTramite(int idExpediente);
    public int ObtenerIdExpediente(int id);

}
