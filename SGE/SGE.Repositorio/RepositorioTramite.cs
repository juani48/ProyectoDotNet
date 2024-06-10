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
        using var db = new Context();
        db.Tramites.Add(tramite);
        db.SaveChanges();
    }

    public bool eliminarTramite(int id)
    {
        using var db = new Context();
        var query = db.Tramites.Where(T => T.Id == id).SingleOrDefault();
        if(query != null){
            db.Tramites.Remove(query);
            return true;
        }
        else{
            return false;
        }
    }

    public void EliminarTramitesPorIdExpediente(int idExpediente)
    {
        using var db = new Context();
        var query = db.Tramites.Where(t => t.ExpedienteId == idExpediente);
        foreach(var tramite in query){
            db.Tramites.Remove(tramite);
        }
        db.SaveChanges();
    }

    public List<Tramite> ListarTramitesPorEtiqueta(string etiqueta)
    {
        throw new NotImplementedException();
    }

    public List<Tramite> ListarTramitesPorExpedienteID(int idExpediente)
    {
        using var db = new Context();
        return db.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList();
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
        using var db = new Context();
        return db.Tramites.Where(t => t.Id == id).SingleOrDefault();
    }
}
