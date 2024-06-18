namespace SGE.Aplicacion;

public class CasoDeUsoIniciarSesion(IUsuarioRepositorio usuarioRepositorio)
{
    public bool Ejecutar(string nombre, string contrasena)
    {
        return usuarioRepositorio.IniciarSesion(nombre, contrasena);
    }
}