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
  public class GeneralAppServicioRecalculo: AppServicioBase
    {
        public int SaveOrUpdateRecalculo(RecalculoDTO entity)
        //public IEnumerable(<BarraTransferenciaDTO entity>)SaveOrUpdateBarraTransferencia
        {
            try
            {
                int id = 0;

                if (entity.Recacodi == 0)
                {
                    id = FactoryTransferencia.GetRecalculoRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetRecalculoRepository().Update(entity);
                    id = entity.Recacodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina una barra de transferencia en base al id
        /// </summary>
        /// <param name="idBarra"></param>
        public int DeleteRecalculo(int idRecalculo)
        {
            try
            {
                FactoryTransferencia.GetRecalculoRepository().Delete(idRecalculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return idRecalculo;
        }

        /// <summary>
        /// Permite obtener la barra de transferencia en base al id
        /// </summary>
        /// <param name="idBarra"></param>
        /// <returns></returns>
        public RecalculoDTO GetByIdRecalculo(int idRecalculo)
        {
            return FactoryTransferencia.GetRecalculoRepository().GetById(idRecalculo);
        }

        /// <summary>
        /// Permite listar todas las barras de transferencias
        /// </summary>
        /// <returns></returns>
        public List<RecalculoDTO> ListRecalculos(int id)
        {
            return FactoryTransferencia.GetRecalculoRepository().List(id);
        }

        /// <summary>
        /// Permite realizar búsquedas de barras de transferencia en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<RecalculoDTO> BuscarRecalculo(string nombre)
        {
            return FactoryTransferencia.GetRecalculoRepository().GetByCriteria(nombre);
        }


        public int GetUltimaVersion(int pericodi)
        {
            return FactoryTransferencia.GetRecalculoRepository().GetUltimaVersion(pericodi);

        }
    }
}
