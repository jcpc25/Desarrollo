using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Servicios.Aplicacion.Factory;

namespace COES.Servicios.Aplicacion.Transferencias
{
    public class GeneralAppServicioFactorPerdida: AppServicioBase
    {
        /// <summary>
        /// Permite insertar o actualizar la información de la entidad
        /// </summary>
        /// <param name="FactorPerdidaDTO"></param>
        public int SaveFactorPerdida(FactorPerdidaDTO entity)
        {
            try
            {
                int id = 0;
                if (entity.FacPerCodi == 0)
                {
                     id = FactoryTransferencia.GetFactorPerdidaRepository().Save(entity);
                }
           
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina Todos los Factores de perdida del Periodo : PeriCodi
        /// </summary>
        /// <param name="PeriCodi"></param>
        /// <param name="FactPerdVersion"></param>
        public int DeleteListaFactorPerdida(int PeriCodi, int FactPerdVersion)
        {
            try
            {
                FactoryTransferencia.GetFactorPerdidaRepository().Delete(PeriCodi, FactPerdVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return PeriCodi;
        }

        /// <summary>
        /// Permite listar todas los Factores de Perdida de un periodo y versión
        /// </summary>
        /// <returns></returns>
        public List<FactorPerdidaDTO> ListByPeriodoVersion(int iPeriCodi, int iFactPerdVersion)
        {
            return FactoryTransferencia.GetFactorPerdidaRepository().ListByPeriodoVersion(iPeriCodi, iFactPerdVersion);
        }
    }
}
