using System.Data;
using SGE.Aplicacion;

namespace SGE.Repositorio;

public class RepositorioExpediente : IExpedienteRepositorio
{
    public static void Inicializar(){
        using var db = new Context();
        if(db.Database.EnsureCreated()){
            db.SetJournalModeToDelete();
            db.SaveChanges();
        }
    }

    public void AgregarExpediente(Expediente expediente)
    {
        using var db = new Context();
        db.Expedientes.Add(expediente);
        db.SaveChanges();
    }

    public bool EliminarExpediente(int id)
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
    public bool ModificarExpediente(Expediente expediente)
    {
        using var db = new Context();
        var query = db.Expedientes.Where(e => e.Id == expediente.Id).SingleOrDefault();
        if(query != null){
            query.Caratula = expediente.Caratula;
            query.EstadoExpediente = expediente.EstadoExpediente;
            query.IdUsuario = expediente.IdUsuario;
            query.FechaModiificacion = DateTime.Now;
            db.SaveChanges();
            
            return true;
        }
        else{
            return false;
        }
    }

    public Expediente? ObtenerExpediente(int id)
    {
        using var db = new Context();
        return db.Expedientes.Where(e => e.Id == id).SingleOrDefault();
    }

    public List<Expediente> ObtenerListaExpediente()
    {
        using var db = new Context();
        return db.Expedientes.ToList();
    }
}
