namespace SGE.Aplicacion;

public class CasoDeUsoTramiteListarPorEtiqueta (ITramiteRepositorio tramiteRepositorio)
{
    public List<Tramite> Ejecutar(EtiquetaTramite? etiquetaTramite){
        if(etiquetaTramite == null){
            throw new ValidacionException("La etiqueta ingresada es invalida.");
        }
        return tramiteRepositorio.ListarTramitesPorEtiqueta(etiquetaTramite.Value).OrderBy(t => t.FechaModificacion).ToList();
    }
}
