namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repo)
{
    public EtiquetaTramite Ejecutar(int id) {
            return repo.obtenerEtiqueta(id);
    }

}
