namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultarPorId (ITramiteRepositorio tramiteRepositorio)
{
    public Tramite Ejecutar(int idTramite){
        Tramite? tramite = tramiteRepositorio.ObtenerTramite(idTramite);
        if(tramite != null){
            return tramite;
        }
        else{
            throw new RepositorioException("No existe el tramite a modificar.");
        }
    }
}
