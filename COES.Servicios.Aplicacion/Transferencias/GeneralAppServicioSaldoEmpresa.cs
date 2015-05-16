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
    public class GeneralAppServicioSaldoEmpresa : AppServicioBase
    {
        /// <summary>
        /// Graba una entidad SaldoTransmisionEmpresa
        /// </summary>
        /// <param name="entity"></param>
        public int SaveOrUpdateSaldoTransmisionEmpresa(SaldoEmpresaDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.SALEMPCODI == 0)
                {
                    id = FactoryTransferencia.GetSaldoEmpresaRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetSaldoEmpresaRepository().Update(entity);
                    id = entity.SALEMPCODI;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }




        /// <summary>
        /// Elimina un SaldoTransmisionEmpresa en base al periodo y version
        /// </summary>
        /// <param name="periodo"></param>
        /// <param name="version"></param>
        public int DeleteSaldoTransmisionEmpresa(int periodo,int version)
        {
            try
            {
                FactoryTransferencia.GetSaldoEmpresaRepository().Delete(periodo, version);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return periodo;
        }

    }
}
