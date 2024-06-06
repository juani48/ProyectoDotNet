﻿namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (IExpedienteRepositorio expedienteRepositorio,
                                            IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Expediente expediente)
    {
        if(servicioAutorizacion.PoseeElPermiso(expediente.IdUsuario, Permiso.ExpedienteModificacion))
        {
            ExpedienteValidador.ValidarExpediente(expediente);
            if(!expedienteRepositorio.modificarExpediente(expediente.Caratula,expediente.Id,expediente.IdUsuario)){
                throw new RepositorioException("No existe el expediente a modificar.");
            }
        }
        else
        {
            throw new AutorizacionException("El usuario no posee permisos.");
        }
    }
}