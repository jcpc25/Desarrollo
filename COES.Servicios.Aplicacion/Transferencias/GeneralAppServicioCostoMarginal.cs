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
    public class GeneralAppServicioCostoMarginal: AppServicioBase
    {
        public int SaveCostoMarginal(CostoMarginalDTO entity)
        {
            try
            {
                int id = 0;
                if (entity.CosMarCodi == 0)
                {
                    id = FactoryTransferencia.GetCostoMarginalRepository().Save(entity);
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// Elimina Todos los Costos Marginales del Periodo : PeriCodi
        public int DeleteListaCostoMarginal(int PeriCodi, int CostMargVersion)
        {
            try
            {
                FactoryTransferencia.GetCostoMarginalRepository().Delete(PeriCodi, CostMargVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return PeriCodi;
        }
        
        /// <summary>
        /// Permite listar los codigo de CostoMarginal
        /// </summary>
      
        /// <param name="pericodi"></param>
        /// <returns></returns>
        public List<CostoMarginalDTO> ListCostoMarginal(int pericodi)
        {
            return FactoryTransferencia.GetCostoMarginalRepository().List(pericodi);
        }
        
        /// <summary>
        /// Permite realizar búsquedas de CODIGO RETIRO SIN CONTRATO en base al codigodde periodo ,empresa y codigoentrega
        /// </summary>
        /// <param name="pericodi"></param>
        /// <param name="barrcodi"></param>
        /// <returns></returns>
        public List<CostoMarginalDTO> BuscarCostoMarginal (int pericodi, string barrcodi)
        {

            return FactoryTransferencia.GetCostoMarginalRepository().GetByCriteria(pericodi, barrcodi);
        }


        /// <summary>
        ///List  ValorTransferencia en base al
        /// </summary>
        /// <param name="barrcodi"></param>
        ///  <param name="pericodi"></param>
        ///   <param name="version"></param>
        public List<CostoMarginalDTO> ListValorTransferenciaByBarraPeridoVersion(int barrcodi, int pericodi, int version)
        {
            return FactoryTransferencia.GetCostoMarginalRepository().ListByBarrPeriodoVersion(barrcodi, pericodi, version);
        }

        public List<CostoMarginalDTO> ListCostoMarginal(int? idPeriodo)
        {
            return FactoryTransferencia.GetCostoMarginalRepository().GetByCodigo(idPeriodo);
        }

        public List<CostoMarginalDTO> ListNombreBarraTransferencia(int idPeriodo, int iVersion)
        {
            return FactoryTransferencia.GetCostoMarginalRepository().GetByBarraTransferencia(idPeriodo, iVersion); 
        }

        public List<CostoMarginalDTO> ListCostoMarginalByBarraPeridoVersion(int barrcodi, int pericodi, int version)
        {
            return FactoryTransferencia.GetCostoMarginalRepository().ListByBarrPeriodoVersion(barrcodi, pericodi, version);
        }

    }
}
