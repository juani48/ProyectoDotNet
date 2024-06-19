namespace SGE.Aplicacion;

public static class UsuarioValidador
{
    public static bool ValidarUsuario(Usuario usuario){
        if((string.IsNullOrWhiteSpace(usuario.Apellido))||
            (string.IsNullOrWhiteSpace(usuario.Nombre))||
            (string.IsNullOrWhiteSpace(usuario.Correo))||
            (string.IsNullOrWhiteSpace(usuario.Contraseña)))
        {
            throw new ValidacionException("Los datos ingresados no pueden estar vacios.");
        }
        return true;
    }
}
