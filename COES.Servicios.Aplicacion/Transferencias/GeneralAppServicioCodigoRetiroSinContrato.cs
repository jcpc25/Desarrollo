using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Servicios.Aplicacion.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Servicios.Aplicacion.Transferencias
{
    /// <summary>
    /// Clases con métodos del módulo CODIGO RETIRO SIN CONTRATO
    /// </summary>
   public  class GeneralAppServicioCodigoRetiroSinContrato : AppServicioBase
    {
        /// <summary>
        /// Inserta o actualiza un registro CODIGO RETIRO SIN CONTRATO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
       public int SaveOrUpdateCodigoRetiroSinContrato(CodigoRetiroSinContratoDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Codretisinconcodi == 0)
                {
                 
                    id = FactoryTransferencia.GetCodigoRetiroSinContratoRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetCodigoRetiroSinContratoRepository().Update(entity);
                    id = entity.Codretisinconcodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
       /// Elimina un CODIGO RETIRO SIN CONTRATO en base al id
        /// </summary>
        /// <param name="idCodigoRetiro"></param>
       public int DeleteCodigoRetiroSinContrato(int idCodigoRetiro)
        {
            try
            {
                FactoryTransferencia.GetCodigoRetiroSinContratoRepository().Delete(idCodigoRetiro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return idCodigoRetiro;
        }

        /// <summary>
       /// Permite obtener el CODIGO RETIRO SIN CONTRATO en base al id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public CodigoRetiroSinContratoDTO GetByIdCodigoRetiroSinContrato(int id)
        {
            return FactoryTransferencia.GetCodigoRetiroSinContratoRepository().GetById(id);
        }

        /// <summary>
       /// Permite listar todas CODIGO RETIRO SIN CONTRATO
        /// </summary>
        /// <returns></returns>
       public List<CodigoRetiroSinContratoDTO> ListCodigoRetiroSinContrato()
        {
            return FactoryTransferencia.GetCodigoRetiroSinContratoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas de CODIGO RETIRO SIN CONTRATO en base al cliente, barra, fecha inicio, fecha fin y estado
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
       public List<CodigoRetiroSinContratoDTO> BuscarCodigoRetiroSinContrato(string nombreCli, string nombreBarra, DateTime? fechaini, DateTime? fechafin, string estado)
        {
            return FactoryTransferencia.GetCodigoRetiroSinContratoRepository().GetByCriteria(nombreCli, nombreBarra, fechaini, fechafin, estado);
        }

       /// <summary>
       /// Permite realizar búsquedas de CODIGO RETIRO SIN CONTRATO en base al código
       /// </summary>
       /// <param name="nombre"></param>
       /// <returns></returns>
       public CodigoRetiroSinContratoDTO BuscarCodigoRetiroSinContratoCodigo(string Codretisinconcodigo)
       {
           return FactoryTransferencia.GetCodigoRetiroSinContratoRepository().GetByCodigoRetiroSinContratoCodigo(Codretisinconcodigo);
       }
    }
}
