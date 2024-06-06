namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{
  bool PoseeElPermiso(int IdUsuario, Permiso permiso);
}

