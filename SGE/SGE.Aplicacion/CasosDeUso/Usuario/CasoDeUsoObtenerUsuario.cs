namespace SGE.Aplicacion;

public class CasoDeUsoObtenerUsuario (IUsuarioRepositorio usuarioRepositorio)
{
    public Usuario Ejecutar(int idUsuario){
        Usuario? usuario = usuarioRepositorio.obtenerUsuario( idUsuario );
        if(usuario == null){
            throw new RepositorioException($"No existe el usuario con ID: {idUsuario}");
        }
        return usuario;
    }
}
