﻿namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    List<Permiso> obtenerPermisos(int id);
    List<PermisoAdministrador> obtenerPermisosAdministrador(int id);
    Usuario? obtenerUsuario(int id);
    void AgregarPermiso(int id, Permiso permiso);

    bool EliminarPermiso(int id, Permiso permiso);
    List<Usuario> obtenerUsuarios();
    
    bool EliminarUsuario(int id);
    
    Usuario? IniciarSesion(string nombre, string contrasena);
    bool RegistrarUsuario(Usuario usuario, string contrasena);
    bool VerificarUsuario(Usuario usuario, string nombre, string contrasena);

    


}
