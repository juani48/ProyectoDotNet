namespace SGE.Aplicacion;

public class AutorizacionException : Exception
{
    public AutorizacionException()
    { 
        
    }
    public AutorizacionException(string message) : base(message) { }
    public AutorizacionException(string message, Exception inner) : base(message, inner) { }
}
