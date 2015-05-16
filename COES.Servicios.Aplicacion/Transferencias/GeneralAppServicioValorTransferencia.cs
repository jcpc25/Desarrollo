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
    public class GeneralAppServicioValorTransferencia : AppServicioBase
    {
        public int SaveValorTransferencia(ValorTransferenciaDTO entity)
        {
            try
            {
                int id = 0;
                if (entity.ValoTranCodi == 0)
                {
                    id = FactoryTransferencia.GetValorTransferenciaRepository().Save(entity);
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// Elimina Todos los Costos Marginales del Periodo : PeriCodi
        public int DeleteListaValorTransferencia(int PeriCodi, int CostMargVersion)
        {
            try
            {
                FactoryTransferencia.GetValorTransferenciaRepository().Delete(PeriCodi, CostMargVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return PeriCodi;
        }

        public List<ValorTransferenciaDTO> ListValorTransferenciaEmpresaRE(int pericodi, int version)
        {
            return FactoryTransferencia.GetValorTransferenciaRepository().List(pericodi, version);
        }

        public List<ValorTransferenciaDTO> BuscarValorTransferenciaGetByCriteria(int? empcodi, int? barrcodi, int? pericodi)//int pericodi, string barrcodi
        {

            return FactoryTransferencia.GetValorTransferenciaRepository().GetByCriteria(empcodi,  barrcodi, pericodi); //
        }


      


          /// <summary>
        ///Obtener lista  de total ValorTransferencia por 
        /// </summary>
     
        ///  <param name="pericodi"></param>
        ///   <param name="version"></param>
        public List<ValorTransferenciaDTO> ObtenerTotalEnergiaporEntregaoRetiro( int pericodi, int version)
        {
            return FactoryTransferencia.GetValorTransferenciaRepository().GetTotalByTipoFlag(pericodi, version);
        }


           ///Obtener lista  Valor de la empresa  por 
        /// </summary>
     
        ///  <param name="pericodi"></param>
        ///   <param name="version"></param>
        public List<ValorTransferenciaDTO> ObtenerTotalValorEmpresa( int pericodi, int version)
        {
            return FactoryTransferencia.GetValorTransferenciaRepository().GetValorEmpresa(pericodi, version);
        }

        public List<ValorTransferenciaDTO> ListarBalance(int periodo)
        {
            return FactoryTransferencia.GetValorTransferenciaRepository().GetBalance(periodo);
        }
        
        
    }
}
