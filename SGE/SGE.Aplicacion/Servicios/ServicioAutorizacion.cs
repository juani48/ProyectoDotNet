namespace SGE.Aplicacion;
public class ServicioAutorizacion(IUsuarioRepositorio usuarioRepositorio, ServicioSesionUsuario servicioSesionUsuario):IServicioAutorizacion
{
  public bool PoseeElPermiso(Permiso permiso) //siempre retorna true para el id 1, en otro caso retorna false
  {
    var permisos = usuarioRepositorio.obtenerPermisos(servicioSesionUsuario.UsuarioActual.Id); //Si no es el administrador, recorremos la lista de permisos y verificamos si lo tiene o no
    return permisos?.Contains(permiso) ?? false;
  }

  public bool PoseePermisoAdministrador(PermisoAdministrador permisoAdministrador)
  {
    var permisos = usuarioRepositorio.obtenerPermisosAdministrador(servicioSesionUsuario.UsuarioActual.Id); //Si no es el administrador, recorremos la lista de permisos y verificamos si lo tiene o no
    return permisos?.Contains(permisoAdministrador) ?? false;
  }

 
}
