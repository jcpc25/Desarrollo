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
   public class GeneralAppServicioTramite: AppServicioBase
    {
        /// <summary>
        /// Inserta o actualiza un registro de barra de transferencia
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveOrUpdateTramite(TramiteDTO entity)
        //public IEnumerable(<BarraTransferenciaDTO entity>)SaveOrUpdateBarraTransferencia
        {
            try
            {
                int id = 0;


                if (entity.Tramcodi == 0)
                {
                    id = FactoryTransferencia.GetTramiteRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetTramiteRepository().Update(entity);
                    id = entity.Tramcodi;
                }
              

                
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //public int UpdateTramite(TramiteDTO entity)
        ////public IEnumerable(<BarraTransferenciaDTO entity>)SaveOrUpdateBarraTransferencia
        //{
        //    try
        //    {
        //        int id = 0;


        //        if (entity.Tramcodi >= 1)
                
        //        {
        //            FactoryTransferencia.GetTramiteRepository().Update(entity);
        //            id = entity.Tramcodi;
        //        }




        //        return id;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        /// <summary>
        /// Permite obtener la barra de transferencia en base al id
        /// </summary>
        /// <param name="idBarra"></param>
        /// <returns></returns>
        public TramiteDTO GetByIdTramite(int idTramite)
        {
            return FactoryTransferencia.GetTramiteRepository().GetById(idTramite);
        }

        /// <summary>
        /// Permite listar todas las barras de transferencias
        /// </summary>
        /// <returns></returns>
        public List<TramiteDTO> ListTramite()
        {
            return FactoryTransferencia.GetTramiteRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas de barras de transferencia en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<TramiteDTO> BuscarTramite(DateTime? fecha, string corrinf, int periodo)
        {
            return FactoryTransferencia.GetTramiteRepository().GetByCriteria(fecha, corrinf, periodo);
        }
    }
}
