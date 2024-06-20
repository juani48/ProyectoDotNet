namespace SGE.Aplicacion;

public class CasoDeUsoRegistrarUsuario (IUsuarioRepositorio usuarioRepositorio, ServicioSesionUsuario servicioSesionUsuario, IServicioEncriptador servicioEncriptador)
{
    public void Ejecutar(Usuario usuario)
    {   
        UsuarioValidador.ValidarUsuario(usuario);
        if(usuarioRepositorio.obtenerUsuarios().Count() == 0){
            usuario.Permisos = new List<Permiso>{
                            Permiso.ExpedienteAlta, 
                            Permiso.ExpedienteBaja, 
                            Permiso.ExpedienteModificacion,
                            Permiso.TramiteAlta,
                            Permiso.TramiteBaja,
                            Permiso.TramiteModificacion};

            usuario.PermisosAdministrador = new List<PermisoAdministrador>(){
            PermisoAdministrador.ListarUsuario, PermisoAdministrador.UsuarioBaja, PermisoAdministrador.UsuarioModificacion};
        }
        usuario.Contraseña = servicioEncriptador.EncriptarSHA256(usuario.Contraseña);
        if(!usuarioRepositorio.RegistrarUsuario(usuario)){
            throw new RepositorioException("Ya existe un usuario con ese nombre y contraseña");
        }
        servicioSesionUsuario.UsuarioActual = usuario;
    }
}
