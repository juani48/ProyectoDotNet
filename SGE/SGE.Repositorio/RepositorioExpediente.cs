using System.Data;
using SGE.Aplicacion;

namespace SGE.Repositorio;

public class RepositorioExpediente : IExpedienteRepositorio
{
    public static void Inicializar(){
        using var db = new Context();
        if(db.Database.EnsureCreated()){
            db.SetJournalModeToDelete();
        } 
    }

    public bool ActualizarEstadoExpediente(Expediente expediente)
    {
        throw new NotImplementedException();
    }

    public void agregarExpediente(Expediente expediente)
    {
        using var db = new Context();
        db.Expedientes.Add(expediente);
        db.SaveChanges();
    }

    public bool eliminarExpediente(int id)
    {
        using var db = new Context();
        var query = db.Expedientes.Where(e => e.Id == id).SingleOrDefault();
        if(query != null){
            db.Expedientes.Remove(query);
            db.SaveChanges();
            return true;
        }
        else{
            return false;
        }
    }
    public bool modificarExpediente(string st, int idExpediente, int idUsuario)
    {
        using var db = new Context();
        var query = db.Expedientes.Where(e => e.Id == idExpediente).SingleOrDefault();
        if(query != null){
            query.EstadoExpediente = EstadoExpediente.Parse<EstadoExpediente>(st);
            query.IdUsuario = idUsuario;
            query.FechaModiificacion = DateTime.Now;
            return true;
        }
        else{
            return false;
        }
    }

    public Expediente? obtenerExpediente(int id)
    {
        using var db = new Context();
        return db.Expedientes.Where(e => e.Id == id).SingleOrDefault();
    }

    public List<Expediente> obtenerListaExpediente()
    {
        using var db = new Context();
        return db.Expedientes.ToList();
    }
}
