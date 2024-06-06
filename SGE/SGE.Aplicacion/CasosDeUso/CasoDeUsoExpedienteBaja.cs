namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion, ITramiteRepositorio tramiteRepositorio)
{
    public void Ejecutar(int idUsuario, int idExpediente)
    {
        
        if(!servicioAutorizacion.PoseeElPermiso(idUsuario,  Permiso.ExpedienteBaja))
        {
            throw new AutorizacionException("El usuario no tiene el permiso para realizar una baja de expediente.");
        }
        else
        {
          if(expedienteRepositorio.eliminarExpediente(idExpediente))//Si retorna verdadero, se ejecuta automaticamente y se elimina el expediente
          {
            tramiteRepositorio.EliminarTramitesPorIdExpediente(idExpediente);
            Console.WriteLine("Expediente eliminado correctamente.");
          }
          else
            throw new RepositorioException($"El expediente con id {idExpediente} no existe.");
        }
    }

}