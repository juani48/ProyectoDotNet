namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repo)
{
    public EtiquetaTramite? Ejecutar(int id) 
    {
            EtiquetaTramite? e= repo.ObtenerEtiqueta(id);
            if(e !=null ){
                return e;
            }
            else
            {
                throw new RepositorioException("no se encuentra el tramite.");
            }
    }

}
