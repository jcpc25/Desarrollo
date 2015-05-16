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
   public  class GeneralAppServicioCodigoEntrega : AppServicioBase
    {

        public int SaveOrUpdateCodigoEntrega(CodigoEntregaDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Codientrcodi == 0)
                {
                    id = FactoryTransferencia.GetCodigoEntregaRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetCodigoEntregaRepository().Update(entity);
                    id = entity.Codientrcodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un CodigoEntrega en base al id
        /// </summary>
        /// <param name="idCodigoEntrega"></param>
        public int DeleteCodigoEntrega(int idCodigoEntrega)
        {
            try
            {
                FactoryTransferencia.GetCodigoEntregaRepository().Delete(idCodigoEntrega);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return idCodigoEntrega;
        }

        /// <summary>
        /// Permite obtener el CodigoEntrega en base al id
        /// </summary>
        /// <param name="idCodigoEntrega"></param>
        /// <returns></returns>
        public CodigoEntregaDTO GetByIdCodigoEntra(int idCodigoEntrega)
        {
            return FactoryTransferencia.GetCodigoEntregaRepository().GetById(idCodigoEntrega);
        }

        /// <summary>
        /// Permite listar todas codigoEntrega
        /// </summary>
        /// <returns></returns>
        public List<CodigoEntregaDTO> ListCodigoEntrega()
        {
            return FactoryTransferencia.GetCodigoEntregaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas de CodigoEntrega en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<CodigoEntregaDTO> BuscarCodigoEntrega(string nombreEmp, string barrTrans, string centralgene, DateTime? fechini, DateTime? fechafin, string estado)
        {
            return FactoryTransferencia.GetCodigoEntregaRepository().GetByCriteria(nombreEmp, barrTrans, centralgene, fechini, fechafin, estado);
        }


        public CodigoEntregaDTO GetByCodigoEntregaCodigo(string codEntrCodigo)
        {
            return FactoryTransferencia.GetCodigoEntregaRepository().GetByCodiEntrCodigo(codEntrCodigo);
        }
    }
}
