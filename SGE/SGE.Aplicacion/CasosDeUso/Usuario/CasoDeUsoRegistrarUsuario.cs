namespace SGE.Aplicacion;

public class CasoDeUsoRegistrarUsuario(IUsuarioRepositorio usuarioRepositorio)
{
    public void Ejecutar(Usuario usuario, string contrasena)
    {   
        usuarioRepositorio.RegistrarUsuario(usuario, contrasena);

    }
}