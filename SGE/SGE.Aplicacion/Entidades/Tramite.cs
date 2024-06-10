namespace SGE.Aplicacion;

public class Tramite
{
        public int Id {get; set;}
        public int ExpedienteId{set;get;}
        public EtiquetaTramite EtiquetaTramite{get;set;}=EtiquetaTramite.EscritoPresentado;
        public string Contenido{get;set;}="";
        public DateTime FechaCreacion { get; set;} = DateTime.Now;
        public DateTime FechaModificacion { get; set; }= DateTime.Now;
        public int IdUsuario{get;set;}

}
