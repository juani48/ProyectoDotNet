﻿namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (IExpedienteRepositorio expedienteRepositorio,
                                            IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Expediente expediente){
        if(servicioAutorizacion.PoseeElPermiso(expediente.IdUsuario, Permiso.ExpedienteModificacion)){
            ExpedienteValidador.ValidarExpediente(expediente);
            expedienteRepositorio.modificarExpediente(expediente.Caratula,expediente.Id,expediente.IdUsuario);
        }
        else{
            throw new AutorizacionException("El usuario no posee permisos");
        }
    }
}