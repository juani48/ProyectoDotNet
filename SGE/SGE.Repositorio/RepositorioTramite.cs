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
#region Tramite
    public void AgregarTramite(Tramite tramite)
    {
        using var db = new Context();
        db.Tramites.Add(tramite);
        db.SaveChanges();
    }
    public bool EliminarTramite(int id)
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
    public Tramite? ObtenerTramite(int id)
    {
        using var db = new Context();
        return db.Tramites.Where(t => t.Id == id).SingleOrDefault();
    }
    public void ModificarTramite(Tramite tramite)
    {
        using var db = new Context();
        var query = db.Tramites.Where(t => t.Id == tramite.Id).SingleOrDefault();
        if(query != null){
            query.ExpedienteId = tramite.ExpedienteId;
            query.EtiquetaTramite = tramite.EtiquetaTramite;
            query.Contenido = tramite.Contenido;
            query.FechaModificacion = DateTime.Now;
            query.IdUsuario = tramite.IdUsuario;
            db.SaveChanges();
        }
    }
    public List<Tramite> ListarTramitesPorEtiqueta(string etiqueta)
    {
        throw new NotImplementedException();
    }
#endregion Tramite

#region InteraccionExpediente
    public EtiquetaTramite? ObtenerEtiqueta(int id)
    {
        throw new NotImplementedException();
    }
    public List<Tramite> ListarTramitesPorExpedienteID(int idExpediente)
    {
        using var db = new Context();
        return db.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList();
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
    public EtiquetaTramite ObtenerEtiquetaUltimoTramite(int idExpediente)
    {
        throw new NotImplementedException();
    }
    public int ObtenerIdExpediente(int idTramite){
        throw new NotImplementedException();
    }
#endregion InteraccionExpediente
}
