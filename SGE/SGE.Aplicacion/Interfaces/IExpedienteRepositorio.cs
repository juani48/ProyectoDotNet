﻿namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    Expediente? ObtenerExpediente(int id);
    void AgregarExpediente(Expediente expediente); //corresponde a los repositorios la responsabilidad de asignar el Id de las entidades 
    bool EliminarExpediente(int id); //se deben eliminar también todos los trámites asociados a dicho expediente
    List<Expediente> ObtenerListaExpediente();

    bool ModificarExpediente(Expediente expediente);
    bool ActualizarEstadoExpediente(Expediente expediente);
}
