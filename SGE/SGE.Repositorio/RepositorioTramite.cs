using System.Data.Common;
using System.Runtime.InteropServices;
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
    public void AgregarTramite(Tramite tramite) //Alta de tramites
    {
        using var db = new Context();
        db.Tramites.Add(tramite);
        db.SaveChanges();
    }
    public bool EliminarTramite(int id)
    {
        using var db = new Context();
        var query = db.Tramites.Where(T => T.Id == id).SingleOrDefault(); //Busca si existe el tramite a eliminar
        if(query != null){
            db.Tramites.Remove(query); //Elimina el trmaite
            db.SaveChanges();
            return true;
        }
        else{
            return false;
        }
    }
    public Tramite? ObtenerTramite(int id) //Retorna null si el tramite no existe
    {
        using var db = new Context();
        return db.Tramites.Where(t => t.Id == id).SingleOrDefault();
    }
    public void ModificarTramite(Tramite tramite)
    {
        using var db = new Context();
        var query = db.Tramites.Where(t => t.Id == tramite.Id).SingleOrDefault(); //Busca el tramite a modificar
        if(query != null){
            query.ExpedienteId = tramite.ExpedienteId; //Cambia el tramite alamcenado (query) por los datos del tramite ingresado (tramite)
            query.Etiqueta = tramite.Etiqueta;
            query.Contenido = tramite.Contenido;
            query.FechaModificacion = DateTime.Now;
            query.IdUsuario = tramite.IdUsuario;
            db.SaveChanges();
        }
    }
    public List<Tramite> ListarTramitesPorEtiqueta(EtiquetaTramite etiqueta) //Retorna lista de tramites egun un etiqueta
    {
        using var db = new Context();
        return db.Tramites.Where(tramite => tramite.Etiqueta == etiqueta).ToList();
    }
#endregion Tramite

#region InteraccionExpediente
    public EtiquetaTramite? ObtenerEtiqueta(int idExpediente) //Devuelve null si no existe el trmaite asocicado al expedientes - sino la etiqueta
    {
        using var db = new Context();
        return db.Tramites.Where(tramite => tramite.ExpedienteId == idExpediente).FirstOrDefault()?.Etiqueta;
    }
    public List<Tramite> ListarTramitesPorExpedienteID(int idExpediente) //Lista de todos los tramites asociados a un expediente
    {
        using var db = new Context();
        return db.Tramites.Where(t => t.ExpedienteId == idExpediente).OrderBy(tramite => tramite.FechaModificacion).ToList();
    }
    public void EliminarTramitesPorIdExpediente(int idExpediente)
    {
        using var db = new Context();
        var query = db.Tramites.Where(t => t.ExpedienteId == idExpediente); // IEnumerator de todos tramites asociados a un expediente
        foreach(var tramite in query){ //Elimina de la base de datos cada tramite
            db.Tramites.Remove(tramite);
        }
        db.SaveChanges();
    }
    public EtiquetaTramite ObtenerEtiquetaUltimoTramite(int idExpediente)
    {
        using var db = new Context();
        var query = db.Tramites.Where(tramite => tramite.ExpedienteId == idExpediente); // IEnumerator de todos tramites asociados a un expediente
        DateTime fecha = DateTime.MinValue;
        EtiquetaTramite etiquetaTramite = EtiquetaTramite.EscritoPresentado;
        foreach(Tramite tramite in query){ //Busco la ultima etiqueta en modificarce
            if(tramite.FechaModificacion < fecha){
                fecha = tramite.FechaModificacion;
                etiquetaTramite = tramite.Etiqueta;
            }
        }
        return etiquetaTramite; // Y retorno el primer valor en caso de que el expediente no tenga trmaites asociados
    }
    public int ObtenerIdExpediente(int idTramite){ //Devuelve el id de un expediente segun el id de un tramite o 0 en caso de que no exista (no deberia pasar)
        using var db = new Context();
        return db.Tramites.Where(tramite => tramite.Id == idTramite).SingleOrDefault()?.ExpedienteId ?? 0;
    }
#endregion InteraccionExpediente
}
