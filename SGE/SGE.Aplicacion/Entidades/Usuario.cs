namespace SGE.Aplicacion;

public class Usuario
{
    public int Id{get; set;}
    public string Nombre{get; set;} = "";
    public string Apellido{get;set;} = "";
    public string Correo{get; set;} = "";
    public string Contraseña{get;set;} = "";
    public List<Permiso>? Permisos {get; set;} = new List<Permiso>();

}
