namespace SGE.Aplicacion;

public class CasoDeUsoAgregarPermiso (IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idUsuario, Permiso permiso) 
    {   
        if(!servicioAutorizacion.PoseePermisoAdministrador(PermisoAdministrador.UsuarioModificacion))
           throw new AutorizacionException("El usuario no posee los permisos para modificar otros usuarios.");
        Usuario? usuario = usuarioRepositorio.obtenerUsuario(idUsuario);
        if(usuario == null)
           throw new RepositorioException("El usuario no existe.");
        usuarioRepositorio.AgregarPermiso(idUsuario, permiso);   
    }
}
