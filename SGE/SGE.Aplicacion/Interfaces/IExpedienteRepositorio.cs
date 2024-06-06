﻿namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    Expediente? obtenerExpediente(int id);
    void agregarExpediente(Expediente expediente); //corresponde a los repositorios la responsabilidad de asignar el Id de las entidades 
    bool eliminarExpediente(int id); //se deben eliminar también todos los trámites asociados a dicho expediente
    List<Expediente> obtenerListaExpediente();

    void modificarExpediente(string st, int idExpediente, int idUsuario);
    void ActualizarEstadoExpediente(Expediente expediente);
    /*
    "Además, se debe implementar un caso de uso que permita la consulta de un expediente junto con todos
    sus trámites, utilizando el Id del expediente como referencia."
    
    metodo para obetener una lista de object con el primer elemento expediente, los demas tramite
    */
}
