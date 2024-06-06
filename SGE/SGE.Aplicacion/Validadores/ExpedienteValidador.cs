namespace SGE.Aplicacion;

public static class ExpedienteValidador
{
    public static bool ValidarExpediente(Expediente expediente)
    {
        if(string.IsNullOrWhiteSpace(expediente.Caratula))
        {
            throw new ValidacionException("La caratula no puede estar vacia.");
        }

        if(expediente.IdUsuario <= 0)
        {
            throw new ValidacionException ("El id de usuario debe se un numero mayor a cero(0).");
        }
        return true;
    }    
}
