namespace SGE.Aplicacion;

public class CasoDeUsoListarUsuarios(IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorizacion)
{
    public List<Usuario> Ejecutar()
    {  //preguntar si es el admin
       if(!servicioAutorizacion.PoseePermisoAdministrador(PermisoAdministrador.ListarUsuario))
         throw new AutorizacionException("El usuario no posee los permisos para listar usuarios.");
       return usuarioRepositorio.obtenerUsuarios();
    }
}