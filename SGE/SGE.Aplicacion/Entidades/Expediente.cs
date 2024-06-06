using System.Data.Common;

namespace SGE.Aplicacion;

public class Expediente
{
    public int Id { get; set; } //identificador
    public string Caratula { get; set; } = ""; //texto ingreaso por le usuario
    public DateTime FechaCreacion { get; set; } = DateTime.Now; //propiedad solo de lectura, la fecha de creacion es unica
    public DateTime FechaModiificacion { get; set; }= DateTime.Now; //fecha de la ultima modificiacion
    public int IdUsuario { get; set; } //identificador del ultimo usuario que modifico el expediente
    public EstadoExpediente EstadoExpediente { get; set; }=EstadoExpediente.RecienIniciado;

    public override string ToString()
        {
            return $"----INFORMACION DEL EXPEDIENTE----"+
            $"\n-ID del expediente: {this.Id}"+
            $"\n-Caratula: {this.Caratula}"+
            $"\n-Fecha de creacion: {this.FechaCreacion}"+
            $"\n-Fecha de modificacion: {this.FechaModiificacion}"+
            $"\n-ID del ultimo usuario en modificar: {this.IdUsuario}"+
            $"\n-Estado del expediente: {this.EstadoExpediente}"+
            "\n-------------------------------------------------"; 
        }
}
