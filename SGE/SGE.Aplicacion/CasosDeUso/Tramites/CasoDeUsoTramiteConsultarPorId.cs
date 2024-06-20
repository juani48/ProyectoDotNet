namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultarPorId (ITramiteRepositorio tramiteRepositorio)
{
    public List<Tramite> Ejecutar(int? idTramite){
        if(idTramite == null){
            throw new ValidacionException("El ID ingresado es invalido.");
        }
        Tramite? tramite = tramiteRepositorio.ObtenerTramite(idTramite.Value);
        if(tramite != null){
            return new List<Tramite>(){tramite};
        }
        else{
            throw new RepositorioException("No existe el tramite a modificar.");
        }
    }

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
