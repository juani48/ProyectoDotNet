namespace SGE.Aplicacion;

public class CasoDeUsoModificarUsuario (IUsuarioRepositorio usuarioRepositorio, IServicioEncriptador servicioEncriptador)
{
    public void Ejecutar(Usuario usuario, string contraseña){
        if(contraseña != ""){
            usuario.Contraseña = contraseña;
        }
        usuario.Contraseña = servicioEncriptador.EncriptarSHA256(usuario.Contraseña);
        UsuarioValidador.ValidarUsuario(usuario);
        if(!usuarioRepositorio.ModificarUsuario(usuario)){
            throw new RepositorioException("El usuario que se desea modificar no existe.");
        }
    }
}
