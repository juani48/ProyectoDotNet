using SGE.Aplicacion;
using System.Security.Cryptography;
using System.Text;

namespace SGE.Repositorio;

public class RepositorioUsuario : IUsuarioRepositorio  {//Creo que tambien se podria pasar Context por el constructor primario
  public static void Inicializar(){
    using var db = new Context();
    if(db.Database.EnsureCreated()){
      db.SetJournalModeToDelete();
      db.SaveChanges();
    }
  }
    
   //-----------------Metodos para permisos------------------------
    public Usuario? obtenerUsuario(int id)
    {
        using var db = new Context();
        return db.Usuarios.Where(e => e.Id == id).SingleOrDefault();
    }

    public List<Permiso> obtenerPermisos(int id)
    {
       var usuario = obtenerUsuario(id);
       return usuario?.Permisos ?? new List<Permiso>();
    }

  public List<PermisoAdministrador> obtenerPermisosAdministrador(int id){
      var usuario = obtenerUsuario(id);
      return usuario?.PermisosAdministrador ?? new List<PermisoAdministrador>();
    }

    //si tengo que hacer un manejo de excepciones en el caso de uso, este metodo lo pongo para devolver un booleano
    public void AgregarPermiso(int id, Permiso permiso) //Hay que actualizar primero los datos de la lista y despues agregarlos a la base de datos o directamente interactuar con la base de datos?
    {
        using var db = new Context();//si invoco a obtenerUsuario estaria trabajando en otro contecto y no funcionaria
        var usuario = db.Usuarios.Where(e => e.Id == id).SingleOrDefault();//Interactuando con la base de datos directamente
        if(usuario != null && usuario?.Permisos != null && !usuario.Permisos.Contains(permiso)){
           usuario?.Permisos?.Add(permiso);
           db.SaveChanges(); 
        }
        //List<Permiso> lista = obtenerPermisos(id); //Actualizando la lista y despues guardando cambios
        //lista.Add(permiso);
    }

  public bool EliminarPermiso(int id, Permiso permiso)//Hacer que devuelva un booleano para poder manejar la excepcion
  {
    using var db = new Context();
    var usuario = db.Usuarios.Where(e => e.Id == id).SingleOrDefault(); //si invoco a obtenerUsuario estaria trabajando en otro contexto y no funcionaria, para poder usarlo tendria que modificarlo y pasarle el contexto por parametro
     if (usuario != null && usuario?.Permisos != null && usuario.Permisos.Contains(permiso))
    {
        usuario.Permisos.Remove(permiso);
        db.SaveChanges();
        return true;
    }
    return false;
  }

  public bool ModificarUsuario( Usuario usuario){
    using var db = new Context();
    var query = db.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();
    if(query != null){
      query = usuario;
      db.SaveChanges();
      return true;
    }
    else{
      return false;
    }
  }

//----------------Eliminar/Listar usuarios-------------------
  public List<Usuario> obtenerUsuarios()
  {
    using var db = new Context();
    return db.Usuarios.ToList();
  }

  public bool EliminarUsuario(int id) //Hacer que devuelva un booleano para poder manejar la excepcion
  {
    using var db = new Context();
    var usuario = db.Usuarios.SingleOrDefault(e => e.Id == id);
    if (usuario != null)
    {
      db.Usuarios.Remove(usuario);
      db.SaveChanges();
      return true;
    }
    return false;
  }


 //---------------Inicio de sesion, registro----------------------- 
  public Usuario? IniciarSesion(string nombreUsuario, string contrasena) //Retorna verdadero si el usuario esta registrado
  {
    using var db = new Context();
    var contrasenaEncriptada = EncriptarSHA256(contrasena);
    return db.Usuarios.Where(u => u.Nombre == nombreUsuario && u.Contraseña == contrasenaEncriptada).SingleOrDefault();
  }

  public bool RegistrarUsuario(Usuario usuario, string contrasena) //agregar usuarios
  {
    using var db = new Context();

    if (!db.Usuarios.Any(u => u.Nombre == usuario.Nombre))
    {
      if(db.Usuarios.ToList().Count() == 0){
        usuario.Permisos = new List<Permiso>{
                            Permiso.ExpedienteAlta, 
                            Permiso.ExpedienteBaja, 
                            Permiso.ExpedienteModificacion,
                            Permiso.TramiteAlta,
                            Permiso.TramiteBaja,
                            Permiso.TramiteModificacion};
        usuario.PermisosAdministrador = new List<PermisoAdministrador>(){
          PermisoAdministrador.ListarUsuario, PermisoAdministrador.UsuarioBaja, PermisoAdministrador.UsuarioModificacion
        };
      }

      usuario.Contraseña = EncriptarSHA256(contrasena);
      db.Usuarios.Add(usuario);
      db.SaveChanges();
      return true;
    }
    else{
      return false;
    }
  }
  private string EncriptarSHA256(string entrada)
  {
    using var sha256 = SHA256.Create();
    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(entrada));
    var builder = new StringBuilder();
    foreach (var b in bytes)
    {
      builder.Append(b.ToString("x2"));
    }
    return builder.ToString();
  }

  public bool VerificarUsuario(Usuario usuario, string nombre, string contrasena)
  {
    using var db = new Context();
    var usuarioEncontrado = db.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
    if(usuarioEncontrado != null)
    {
      return usuarioEncontrado.Nombre == nombre &&
             usuarioEncontrado.Contraseña == EncriptarSHA256(contrasena);
    }
    return false;
  }

}
