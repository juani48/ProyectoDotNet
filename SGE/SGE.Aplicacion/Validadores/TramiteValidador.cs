namespace SGE.Aplicacion;

public class TramiteValidador
{
    
    public static bool ValidarTramite(Tramite tramite)
    {
        if(string.IsNullOrWhiteSpace(tramite.Contenido))
        {
            throw new ValidacionException("El contenido del trámite no puede estar vacio");
        }

        if(tramite.IdUsuario <= 0)
        {
            throw new ValidacionException ("El id de usuario debe se un numero mayor a cero(0).");
        }
        return true;
    }    

}
