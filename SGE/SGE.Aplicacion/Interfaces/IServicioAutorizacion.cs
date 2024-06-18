namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{
  bool PoseeElPermiso(Permiso permiso);
  bool PoseePermisoAdministrador(PermisoAdministrador permisoAdministrador);
}

