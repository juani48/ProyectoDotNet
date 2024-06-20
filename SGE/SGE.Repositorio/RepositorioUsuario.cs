using SGE.Aplicacion;

namespace SGE.Repositorio;

public class RepositorioUsuario : IUsuarioRepositorio  {
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
    public void AgregarPermiso(int id, Permiso permiso) 
    {
        using var db = new Context();
        var usuario = db.Usuarios.Where(e => e.Id == id).SingleOrDefault();//Interactuando con la base de datos directamente
        if(usuario != null && usuario?.Permisos != null && !usuario.Permisos.Contains(permiso)){
           usuario?.Permisos?.Add(permiso);
           db.SaveChanges(); 
        }
    }

  public bool EliminarPermiso(int id, Permiso permiso)//Hacer que devuelva un booleano para poder manejar la excepcion
  {
    using var db = new Context();
    var usuario = db.Usuarios.Where(e => e.Id == id).SingleOrDefault(); 
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
      query.Nombre = usuario.Nombre;
      query.Correo = usuario.Correo;
      query.Apellido = usuario.Apellido;
      query.Contraseña = usuario.Contraseña;
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
  public Usuario? IniciarSesion(string nombreUsuario, string contraseña) 
  {
    using var db = new Context();
    return db.Usuarios.Where(u => u.Nombre == nombreUsuario && u.Contraseña == contraseña).SingleOrDefault();
  }

  public bool RegistrarUsuario(Usuario usuario) //agregar usuarios
  {
    using var db = new Context();

    if (!db.Usuarios.Any(u => u.Nombre == usuario.Nombre))
    {
      db.Usuarios.Add(usuario);
      db.SaveChanges();
      return true;
    }
    else{
      return false;
    }
  }
  

  public bool VerificarUsuario(Usuario usuario, string nombre, string contraseña)
  {
    using var db = new Context();
    var usuarioEncontrado = db.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
    if(usuarioEncontrado != null)
    {
      return usuarioEncontrado.Nombre == nombre &&
             usuarioEncontrado.Contraseña == contraseña;
    }
    return false;
  }

}
