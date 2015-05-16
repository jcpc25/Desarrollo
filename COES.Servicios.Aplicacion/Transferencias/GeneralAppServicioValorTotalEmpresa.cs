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
    public class GeneralAppServicioValorTotalEmpresa : AppServicioBase
    {

        /// <summary>
        /// Graba una entidad SaldoTransmisionEmpresa
        /// </summary>
        /// <param name="entity"></param>
        public int SaveOrUpdateValorTotalEmpresa(ValorTotalEmpresaDTO entity)
       
        {
            try
            {
                int id = 0;

                if (entity.VALTOTAEMPCODI == 0)
                {
                    id = FactoryTransferencia.GetValorTotalEmpresaRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetValorTotalEmpresaRepository().Update(entity);
                    id = entity.VALTOTAEMPCODI;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

            /// <summary>
            /// Elimina  ValorTotalEmpresa en base al periodo y version
            /// </summary>
            /// <param name="periodo"></param>
            /// <param name="version"></param>
        public int DeleteValorTotalEmpresa(int pericodi, int version)
        {
            try
            {
                FactoryTransferencia.GetValorTotalEmpresaRepository().Delete(pericodi, version);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return pericodi;
        }

        ///// <summary>
        ///// Permite obtener la barra de transferencia en base al id
        ///// </summary>
        ///// <param name="idBarra"></param>
        ///// <returns></returns>
        //public RecalculoDTO GetByIdRecalculo(int idRecalculo)
        //{
        //    return FactoryTransferencia.GetRecalculoRepository().GetById(idRecalculo);
        //}

        ///// <summary>
        ///// Permite listar todas las barras de transferencias
        ///// </summary>
        ///// <returns></returns>
        //public List<RecalculoDTO> ListRecalculos(int id)
        //{
        //    return FactoryTransferencia.GetRecalculoRepository().List(id);
        //}

        ///// <summary>
        ///// Permite realizar búsquedas de barras de transferencia en base al nombre
        ///// </summary>
        ///// <param name="nombre"></param>
        ///// <returns></returns>
        //public List<RecalculoDTO> BuscarRecalculo(string nombre)
        //{
        //    return FactoryTransferencia.GetRecalculoRepository().GetByCriteria(nombre);
        //}

        /// <summary>
        /// Permite realizar búsquedas de Empresapago positivo por periodo y version
        /// </summary>
        /// <param name="pericodi"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public List<ValorTotalEmpresaDTO> BuscarEmpresasValorPositivo(int pericodi, int version)
        {
            return FactoryTransferencia.GetValorTotalEmpresaRepository().GetEmpresaPositivaByCriteria(pericodi, version);
        }


        /// <summary>
        /// Permite realizar búsquedas de Empresapago negativos por periodo y version
        /// </summary>
        /// <param name="pericodi"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public List<ValorTotalEmpresaDTO> BuscarEmpresasValorNegativo(int pericodi, int version)
        {
            return FactoryTransferencia.GetValorTotalEmpresaRepository().GetEmpresaNegativaByCriteria(pericodi, version);
        }


    }
}
