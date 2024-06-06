namespace SGE.Aplicacion;

public class Tramite
{
        public int Id {get; set;}
        public int ExpedienteId{set;get;}
        public EtiquetaTramite EtiquetaTramite{get;set;}=EtiquetaTramite.EscritoPresentado;
        public String contenido{get;set;}="";
        public DateTime FechaCreacion { get; set;} = DateTime.Now;
        public DateTime FechaModificacion { get; set; }= DateTime.Now;
        public int IdUsuario{get;set;}

        public override string ToString()
        {
                return $"(Id:{Id}) Id De Expediente: {ExpedienteId}, Estado: {EtiquetaTramite}, Contenido: {contenido}, Fecha Creacion: {FechaCreacion}, Fecha Modificacion: {FechaModificacion}, Id Usuario: {IdUsuario}";
        }

}
