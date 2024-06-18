namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    List<Permiso> obtenerPermisos(int id);
    Usuario? obtenerUsuario(int id);
    void AgregarPermiso(int id, Permiso permiso);

    void EliminarPermiso(int id, Permiso permiso);
    List<Usuario> obtenerUsuarios();
    
    void EliminarUsuario(int id);
    
    bool IniciarSesion(string nombre, string contrasena);
    void RegistrarUsuario(Usuario usuario, string contrasena);

    


}
