namespace SGE.Aplicacion;

public class CasoDeUsoIniciarSesion(IUsuarioRepositorio usuarioRepositorio)
{
    public void Ejecutar(string nombre, string contrasena)
    {
        if(!usuarioRepositorio.IniciarSesion(nombre, contrasena)){

            throw new RepositorioException($"No existe un usuario con nombre: {nombre}");
        }
    }
}