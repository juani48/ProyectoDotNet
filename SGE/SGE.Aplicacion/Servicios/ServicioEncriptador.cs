namespace SGE.Aplicacion;
using System.Security.Cryptography;
using System.Text;

public class ServicioEncriptador : IServicioEncriptador
{
    public string EncriptarSHA256(string entrada){
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(entrada));
        var builder = new StringBuilder();

        foreach (var b in bytes){
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }
}
