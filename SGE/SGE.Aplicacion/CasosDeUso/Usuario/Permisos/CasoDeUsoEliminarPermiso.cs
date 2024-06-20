namespace SGE.Aplicacion;

public class CasoDeUsoEliminarPermiso (IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idUsuario, Permiso permiso)
    {
        if(!servicioAutorizacion.PoseePermisoAdministrador(PermisoAdministrador.UsuarioModificacion))
           throw new AutorizacionException("El usuario no posee los permisos para eliminar permisos de otros usuarios.");
        if(!usuarioRepositorio.EliminarPermiso(idUsuario, permiso))
           throw new RepositorioException("El usuario al que se le quiere eliminar el permiso no existe.");
    }
}
