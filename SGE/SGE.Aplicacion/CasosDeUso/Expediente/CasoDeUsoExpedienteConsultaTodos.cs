﻿namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos (IExpedienteRepositorio expedienteRepositorio)
{
    public List<Expediente> Ejecutar(){
        return  expedienteRepositorio.ObtenerListaExpediente();
    }

}
