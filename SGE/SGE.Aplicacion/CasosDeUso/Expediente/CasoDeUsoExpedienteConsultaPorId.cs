using System.Text;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepo, ITramiteRepositorio tramiteRepo)
{
    //Tengo que retornar un expediente con todos sus tramites asociados
    public string Ejecutar(int idExpediente)
    {
        Expediente? expediente = expedienteRepo.obtenerExpediente(idExpediente); //Obtengo el expediente 
        if(expediente == null) 
        {
            throw new RepositorioException($"No se encontro el expediente {idExpediente}.");
        }
        else
        {
            StringBuilder st = new StringBuilder(); //Si este expediente existe, empiezo a armar el string a retornar
            st.AppendLine(expediente.ToString()); //agrego los datos del expediente
            List<Tramite> lista = tramiteRepo.ListarTramitesPorExpedienteID(idExpediente); //Recibo la lista de tramites asociados al expediente
            foreach(Tramite t in lista)
            {
                st.AppendLine(t.ToString()); //Los concateno 
            }
            return st.ToString(); //Retorno el string de expediente y sus tramites
        }
    }
    //Faltaria imprimir los datos en pantalla "Console.WriteLine(casoDeUso.Ejecutar(idExpediente));"

}
