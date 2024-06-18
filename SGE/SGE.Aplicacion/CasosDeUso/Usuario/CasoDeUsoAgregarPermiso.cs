namespace SGE.Aplicacion;

public class CasoDeUsoAgregarPermiso(IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int id, int idUsuario, Permiso permiso)
    {   //aca estoy verificando que el usuario actual sea el administrador. Pero creo que en blazor simplemente se hace visible si es administrador, sino no. Asi que no se si es necesario
        if(!servicioAutorizacion.PoseePermisoAdministrador(id, PermisoAdministrador.UsuarioModificacion))
           throw new AutorizacionException(" No cuenta con el permiso correspondiente.");
        Usuario? usuario = usuarioRepositorio.obtenerUsuario(idUsuario);
        if(usuario == null)
           throw new RepositorioException("El usuario no existe.");
        usuarioRepositorio.AgregarPermiso(idUsuario, permiso);   
    }
}