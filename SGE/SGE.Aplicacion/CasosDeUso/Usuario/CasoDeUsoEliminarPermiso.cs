namespace SGE.Aplicacion;

public class CasoDeUsoEliminarPermiso(IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorzacion)
{
    public void Ejecutar(int id, int idUsuario, Permiso permiso)
    {
        if(!servicioAutorzacion.PoseePermisoAdministrador(id, PermisoAdministrador.UsuarioBaja))
           throw new AutorizacionException("El usuario no posee el permiso.");
        if(!usuarioRepositorio.EliminarPermiso(idUsuario, permiso))
           throw new RepositorioException("El usuario al que se le quiere eliminar el permiso no existe.");
    }

}