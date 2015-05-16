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
    public class GeneralAppServicioCodigoRetiro : AppServicioBase
    {

        public int SaveOrUpdateCodigoRetiro(CodigoRetiroDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Solicodireticodi == 0)
                {
                    id = FactoryTransferencia.GetCodigoRetiroRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetCodigoRetiroRepository().Update(entity);
                    id = entity.Solicodireticodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un CodigoRetiro en base al id
        /// </summary>
        /// <param name="idCodigoRetiro"></param>
        public int DeleteCodigoRetiro(int idCodigoRetiro)
        {
            try
            {
                FactoryTransferencia.GetCodigoRetiroRepository().Delete(idCodigoRetiro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return idCodigoRetiro;
        }

        /// <summary>
        /// Permite obtener el CodigoRetiro en base al id
        /// </summary>
        /// <param name="idCodigoRetiro"></param>
        /// <returns></returns>
        public CodigoRetiroDTO GetByIdCodigoRetiro(int idCodigoRetiro)
        {
            return FactoryTransferencia.GetCodigoRetiroRepository().GetById(idCodigoRetiro);
        }

        /// <summary>
        /// Permite listar todas codigoEntrega
        /// </summary>
        /// <returns></returns>
        public List<CodigoRetiroDTO> ListCodigoRetiro(string estado)
        {
            return FactoryTransferencia.GetCodigoRetiroRepository().List(estado);
        }

        

        /// <summary>
        /// Permite realizar búsquedas de CodigoEntrega en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<CodigoRetiroDTO> BuscarCodigoRetiro(string nombreEmp, string tipousu, string tipocont, string bartran, string clinomb, DateTime? fechaIni, DateTime? fechaFin, string Solicodiretiobservacion, string estado)
        {

            return FactoryTransferencia.GetCodigoRetiroRepository().GetByCriteria(nombreEmp, tipousu, tipocont, bartran, clinomb, fechaIni, fechaFin, Solicodiretiobservacion, estado);
        }

        /// <summary>
        /// Permite obtener el CodigoRetiro en base al CodigoRetiroCodigo
        /// </summary>
        /// <param name="CodigoRetiroCodigo"></param>
        /// <returns></returns>
        public CodigoRetiroDTO GetByCodigoRetiroCodigo(string CodigoRetiroCodigo)
        {
            return FactoryTransferencia.GetCodigoRetiroRepository().GetByCodigoRetiCodigo(CodigoRetiroCodigo);
        }


    }
}
