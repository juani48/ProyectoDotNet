namespace SGE.Aplicacion;
//Cambiar el nombre por: ServicioAutorizacionProvisorio. No es actualizacion
public class ServicioAutorizacionProvisorio: IServicioAutorizacion
{
  public bool PoseeElPermiso(int id, Permiso permiso) //siempre retorna true para el id 1, en otro caso retorna false
  {
    if(id == 1)
      return true;
    else 
      return false;
  }
}
