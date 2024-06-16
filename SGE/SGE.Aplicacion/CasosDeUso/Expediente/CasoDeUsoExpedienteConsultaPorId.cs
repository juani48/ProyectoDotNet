using System.Text;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepo, ITramiteRepositorio tramiteRepo)
{
    //Tengo que retornar un expediente con todos sus tramites asociados
    public Expediente Ejecutar(int idExpediente, out List<Tramite> lista)
    {
        Expediente? expediente = expedienteRepo.ObtenerExpediente(idExpediente); //Obtengo el expediente 
        if(expediente == null) 
        {
            throw new RepositorioException($"No se encontro el expediente con ID: {idExpediente}.");
        }
        else
        {
            lista = tramiteRepo.ListarTramitesPorExpedienteID(idExpediente); //Recibo la lista de tramites asociados al expediente
            return expediente;
        }
    }
    //Faltaria imprimir los datos en pantalla "Console.WriteLine(casoDeUso.Ejecutar(idExpediente));"
    public Expediente Ejecutar(int idExpediente)
    {
        Expediente? expediente = expedienteRepo.ObtenerExpediente(idExpediente); //Obtengo el expediente 
        if(expediente == null) 
        {
            throw new RepositorioException($"No se encontro el expediente con ID: {idExpediente}.");
        }
        else
        {
            return expediente;
        }
    }
}
