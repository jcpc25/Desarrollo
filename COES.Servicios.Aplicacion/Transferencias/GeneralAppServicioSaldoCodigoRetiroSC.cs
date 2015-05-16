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
    public class GeneralAppServicioSaldoCodigoRetiroSC : AppServicioBase
    {


        /// <summary>
        /// Graba una entidad SaldoCodigiRetiroSC
        /// </summary>
        /// <param name="entity"></param>
        public int SaveOrUpdateSaldoCodigoRetiroSC(SaldoCodigoRetiroscDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.SALRSCCODI == 0)
                {
                    id = FactoryTransferencia.GetSaldoCodigoRetiroSCRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetSaldoCodigoRetiroSCRepository().Update(entity);
                    id = entity.SALRSCCODI;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }




        /// <summary>
        /// Elimina un SaldocodigoRetiroSC en base al periodo y version
        /// </summary>
        /// <param name="periodo"></param>
        /// <param name="version"></param>
        public int DeleteSaldoCodigoRetiroSC(int periodo, int version)
        {
            try
            {
                FactoryTransferencia.GetSaldoCodigoRetiroSCRepository().Delete(periodo, version);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return periodo;
        }

    }
}
