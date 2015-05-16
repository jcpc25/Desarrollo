using COES.Dominio.DTO.Transferencias;
using COES.Servicios.Aplicacion.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Servicios.Aplicacion.Transferencias
{
    public class GerenalAppServicioTransferenciaEntregaDetalle
    {

        /// <summary>
        /// Graba una entidad TransferenciaRetiroDTO
        /// </summary>
        /// <param name="entity"></param>
        public int SaveOrUpdateTransferenciaEntregaDetalle(TransferenciaEntregaDetalleDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Tranentrdetacodi == 0)
                {
                    id = FactoryTransferencia.GetTransferenciaEntregaDetalleRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetTransferenciaEntregaDetalleRepository().Update(entity);
                    id = entity.Tranentrdetacodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Permite listar los codigo de entrega
        /// </summary>
        /// <param name="emprcodi"></param>
        /// <param name="pericodi"></param>
        /// <returns></returns>
        public List<TransferenciaEntregaDetalleDTO> ListTransferenciaEntregaDetalle(int emprcodi, int pericodi)
        {
            return FactoryTransferencia.GetTransferenciaEntregaDetalleRepository().List(emprcodi,pericodi);
        }


        /// <summary>
        /// Permite realizar búsquedas de CODIGO RETIRO SIN CONTRATO en base al codigodde periodo ,empresa y codigoentrega
        /// </summary>
        /// <param name="pericodi"></param>
        /// <returns></returns>
        public List<TransferenciaEntregaDetalleDTO> BuscarTransferenciaEntregaDetalle(int emprcodi,int pericodi,string codientrcodi, int version)
        {

            return FactoryTransferencia.GetTransferenciaEntregaDetalleRepository().GetByCriteria(emprcodi, pericodi, codientrcodi, version);
        }

        /// Elimina TransferenciaEntregaDetalle en base al id de
        /// </summary>
        /// <param name="Emprcodi"></param>
        /// /// <param name="pericodi"></param>
        /// /// <param name="version"></param>
        public int DeleteTransferenciaEntregaDetalle(int Emprcodi, int pericodi, int version)
        {
            try
            {
                FactoryTransferencia.GetTransferenciaEntregaDetalleRepository().Delete(Emprcodi, pericodi, version);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return version;
        }

        /// <summary>
        /// Permite listar los codigo de entrega por periodo y version
        /// </summary>
        /// <param name="periodo"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public List<TransferenciaEntregaDetalleDTO> ListTransferenciaEntregaDetallePeriVer(int periodo, int version)
        {
            return FactoryTransferencia.GetTransferenciaEntregaDetalleRepository().GetByPeriodoVersion(periodo, version);
        }

        public List<TransferenciaEntregaDetalleDTO> ListBalanceEnergiaActiva(int periodo)
        {
            return FactoryTransferencia.GetTransferenciaEntregaDetalleRepository().BalanceEnergiaActiva(periodo);
        }
    }
}
