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
    public class GerenalAppServicioTransferenciaRetiroDetalle : AppServicioBase
    {
        /// <summary>
        /// Graba una entidad TransferenciaRetiroDTO
        /// </summary>
        /// <param name="entity"></param>
        public int SaveOrUpdateTransferenciaRetiroDetalle(TransferenciaRetiroDetalleDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Tranretidetacodi == 0)
                {
                    id = FactoryTransferencia.GetTransferenciaRetiroDetalleRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetTransferenciaRetiroDetalleRepository().Update(entity);
                    id = entity.Tranreticodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Permite listar los codigo de retiro
        /// </summary>
        /// <param name="emprcodi"></param>
        /// <param name="pericodi"></param>
        /// <returns></returns>
        public List<TransferenciaRetiroDetalleDTO> ListTransferenciaRetiroDetalle(int emprcodi, int pericodi)
        {
            return FactoryTransferencia.GetTransferenciaRetiroDetalleRepository().List(emprcodi, pericodi);
        }





        /// <summary>
        /// Permite realizar búsquedas de CODIGO RETIRO DETALLE en base al codigo de periodo 
        /// </summary>
        /// <param name="pericodi"></param>
        /// <returns></returns>
        public List<TransferenciaRetiroDetalleDTO> BuscarTransferenciaRetiroDetalle(int emprcodi, int pericodi, string solicodireticodigo,int version)
        {
            return FactoryTransferencia.GetTransferenciaRetiroDetalleRepository().GetByCriteria(emprcodi, pericodi, solicodireticodigo,version);
        }


        /// Elimina TransferenciaRetiroDetalle en base al id de
        /// </summary>
        /// <param name="Emprcodi"></param>
        /// /// <param name="pericodi"></param>
        /// /// <param name="version"></param>
        public int DeleteTransferenciaRetiroDetalle(int Emprcodi, int pericodi, int version)
        {
            try
            {
                FactoryTransferencia.GetTransferenciaRetiroDetalleRepository().Delete(Emprcodi, pericodi, version);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return version;
        }


        /// <summary>
        /// Permite listar los codigo de retiro por periodo y version
        /// </summary>
        /// <param name="periodo"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public List<TransferenciaRetiroDetalleDTO> ListTransferenciaRetiroDetallePeriVer(int periodo, int version)
        {
            return FactoryTransferencia.GetTransferenciaRetiroDetalleRepository().GetByPeriodoVersion(periodo, version);
        }
    }
}
