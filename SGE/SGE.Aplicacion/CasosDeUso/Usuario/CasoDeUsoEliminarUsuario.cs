namespace SGE.Aplicacion;

public class CasoDeUsoEliminarUsuario(IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idUsuario)
    {
        if(!servicioAutorizacion.PoseePermisoAdministrador(PermisoAdministrador.UsuarioBaja))
          throw new AutorizacionException("El usuario no posee los permisos para eliminarotros usuarios.");
        if(!usuarioRepositorio.EliminarUsuario(idUsuario))
          throw new RepositorioException("El usuario no existe.");
    }
}