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
    public class GeneralAppServicioEmpresaPago : AppServicioBase
    {


        /// <summary>
        /// Permite Grabar EmpresaPago
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
       
        public int SaveoUpdateEmpresaPago(EmpresaPagoDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.EMPPAGOCODI == 0)
                {
                    id = FactoryTransferencia.GetEmpresaPagoRepository().Save(entity);
                }
                else
                {
                    //FactoryTransferencia.GetBarraRepository().Update(entity);
                    id = entity.EMPPAGOCODI;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
          
        }


        /// <summary>
        /// Elimina un EmpresaPago en base  al periodo y version
        /// </summary>
        /// <param name="pericodi"></param>
        /// <param name="version"></param>
        public int DeleteEmpresaPago(int pericodi,int version)
        {
            try
            {
                FactoryTransferencia.GetEmpresaPagoRepository().Delete(pericodi, version);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return pericodi;
        }



        /////// <summary>
        /////// Permite realizar búsquedas de Empresapago positivo por periodo y version
        /////// </summary>
        /////// <param name="pericodi"></param>
        /////// <param name="version"></param>
        /////// <returns></returns>
        //public List<EmpresaPagoDTO> BuscarEmpresasValorPositivo(int pericodi, int version)
        //{
        //    return FactoryTransferencia.GetEmpresaPagoRepository().GetEmpresaPositivaByCriteria(pericodi, version);
        //}


        ///// <summary>
        ///// Permite realizar búsquedas de Empresapago negativos por periodo y version
        ///// </summary>
        ///// <param name="pericodi"></param>
        ///// <param name="version"></param>
        ///// <returns></returns>
        //public List<EmpresaPagoDTO> BuscarEmpresasValorNegativo(int pericodi, int version)
        //{
        //    return FactoryTransferencia.GetEmpresaPagoRepository().GetEmpresaNegativaByCriteria(pericodi, version);
        //}
    }
}
