namespace SGE.Aplicacion;
//Cambiar el nombre por: ServicioAutorizacionProvisorio. No es actualizacion
public class ServicioAutorizacionProvisorio(IUsuarioRepositorio usuario):IServicioAutorizacion
{
  public bool PoseeElPermiso(int id, Permiso permiso) //siempre retorna true para el id 1, en otro caso retorna false
  {
    if(id == 1)  //Si es el administrador, siempre retorna true
      return true;
    var permisos = usuario.obtenerPermisos(id); //Si no es el administrador, recorremos la lista de permisos y verificamos si lo tiene o no
    return permisos?.Contains(permiso) ?? false;
  }

  public bool PoseePermisoAdministrador(int id, PermisoAdministrador permisoAdministrador)
  {
    if(id == 1)
      return true;
    else
      return false;
  }

 
}
