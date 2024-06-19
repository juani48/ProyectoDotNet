namespace SGE.Aplicacion;

public class CasoDeUsoModificarUsuario (IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorizacion)//Junto los casos de uso de modificar, elimnar y agregar permiso
{
    public void AgregarPermiso(int idUsuario, Permiso permiso) 
    {   //aca estoy verificando que el usuario actual sea el administrador. Pero creo que en blazor simplemente se hace visible si es administrador, sino no. Asi que no se si es necesario
        if(!servicioAutorizacion.PoseePermisoAdministrador(PermisoAdministrador.UsuarioModificacion))
           throw new AutorizacionException("El usuario no posee los permisos para modificar otros usuarios.");
        Usuario? usuario = usuarioRepositorio.obtenerUsuario(idUsuario);
        if(usuario == null)
           throw new RepositorioException("El usuario no existe.");
        usuarioRepositorio.AgregarPermiso(idUsuario, permiso);   
    }

    public void EliminarPermiso(int idUsuario, Permiso permiso)
    {
        if(!servicioAutorizacion.PoseePermisoAdministrador(PermisoAdministrador.UsuarioModificacion))
           throw new AutorizacionException("El usuario no posee los permisos para eliminar permisos de otros usuarios.");
        if(!usuarioRepositorio.EliminarPermiso(idUsuario, permiso))
           throw new RepositorioException("El usuario al que se le quiere eliminar el permiso no existe.");
    }

    public void Modificar(Usuario usuario, string contraseña){
        if(contraseña != ""){
            usuario.Contraseña = contraseña;
        }
        UsuarioValidador.ValidarUsuario(usuario);
        if(!usuarioRepositorio.ModificarUsuario(usuario)){
            throw new RepositorioException("El usuario que se desea modificar no existe.");
        }
    }
}
