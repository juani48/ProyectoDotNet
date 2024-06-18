namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{
  bool PoseeElPermiso(int IdUsuario, Permiso permiso);
  bool PoseePermisoAdministrador(int IdUsuario, PermisoAdministrador permisoAdministrador);
}

