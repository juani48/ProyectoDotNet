using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

namespace SGE.Repositorio;

public class Context : DbContext
{
    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Tramite> Tramites { get; set;}
    public DbSet<Usuario> Usuarios{get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=DataBase.sqlite");
    }
    
    public void SetJournalModeToDelete(){
        using var command = this.Database.GetDbConnection().CreateCommand();
        command.CommandText = "PRAGMA journal_mode = DELETE;";
        this.Database.OpenConnection();
        command.ExecuteNonQuery();
        this.Database.CloseConnection();
    }
}
