namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion, ITramiteRepositorio tramiteRepositorio)
{
    public void Ejecutar(Expediente expediente)
    {
        
        if(!servicioAutorizacion.PoseeElPermiso(expediente.IdUsuario,  Permiso.ExpedienteBaja))
        {
            throw new AutorizacionException("El usuario no tiene el permiso para realizar una baja de expediente.");
        }
        else
        {
          if(expedienteRepositorio.EliminarExpediente(expediente.Id))//Si retorna verdadero, se ejecuta automaticamente y se elimina el expediente
          {
            tramiteRepositorio.EliminarTramitesPorIdExpediente(expediente.Id);
            //Console.WriteLine("Expediente eliminado correctamente.");
          }
          else
            throw new RepositorioException($"El expediente con id {expediente.Id} no existe.");
        }
    }

}