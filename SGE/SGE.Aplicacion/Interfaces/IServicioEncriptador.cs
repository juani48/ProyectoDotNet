namespace SGE.Aplicacion;

public interface IServicioEncriptador
{
    string EncriptarSHA256(string entrada);
}
