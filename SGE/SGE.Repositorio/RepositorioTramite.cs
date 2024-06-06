using SGE.Aplicacion;

namespace SGE.Repositorio;

public class RepositorioTramite : ITramiteRepositorio
{
    public static void Inicializar(){
        using var db = new Context();
        if(db.Database.EnsureCreated()){
            db.SetJournalModeToDelete();
        } 
    }

    public void agregarTramite(Tramite tramite)
    {
        throw new NotImplementedException();
    }

    public bool eliminarTramite(int id)
    {
        throw new NotImplementedException();
    }

    public void EliminarTramitesPorIdExpediente(int idExpediente)
    {
        throw new NotImplementedException();
    }

    public List<Tramite> ListarTramitesPorEtiqueta(string etiqueta)
    {
        throw new NotImplementedException();
    }

    public List<Tramite> ListarTramitesPorExpedienteID(int idExpediente)
    {
        throw new NotImplementedException();
    }

    public void modificarTramite(Tramite tramite)
    {
        throw new NotImplementedException();
    }

    public EtiquetaTramite? obtenerEtiqueta(int id)
    {
        throw new NotImplementedException();
    }

    public EtiquetaTramite ObtenerEtiquetaUltimoTramite(int idExpediente)
    {
        throw new NotImplementedException();
    }

    public int ObtenerIdExpediente(int id)
    {
        throw new NotImplementedException();
    }

    public Tramite? obtenerTramite(int id)
    {
        throw new NotImplementedException();
    }
}
