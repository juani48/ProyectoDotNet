namespace SGE.Aplicacion;

public class CasoDeUsoEliminarUsuario(IUsuarioRepositorio usuarioRepositorio, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if(!servicioAutorizacion.PoseePermisoAdministrador(id, PermisoAdministrador.UsuarioBaja))
          throw new AutorizacionException("El usuario no posee el permiso correspondiente.");
        if(!usuarioRepositorio.EliminarUsuario(idUsuario))
          throw new RepositorioException("El usuario no existe.");
    }
}