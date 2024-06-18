namespace SGE.Aplicacion;

public class CasoDeUsoListarUsuarios(IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorizacion)
{
    public List<Usuario> Ejecutar(int IdUsuario)
    {  //preguntar si es el admin
       if(!servicioAutorizacion.PoseePermisoAdministrador(IdUsuario, PermisoAdministrador.ListarUsuario))
         throw new AutorizacionException("El usuario no posee el permiso para listar usuarios.");
       return usuarioRepositorio.obtenerUsuarios();
    }
}