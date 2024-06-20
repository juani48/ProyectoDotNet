namespace SGE.Aplicacion;

public class CasoDeUsoTramiteListar(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar() 
    {
        return repo.ListarTramites().OrderBy(t => t.FechaModificacion).ToList();
    }

}
