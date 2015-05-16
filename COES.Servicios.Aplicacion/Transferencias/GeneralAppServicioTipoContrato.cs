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
    public class GeneralAppServicioTipoContrato : AppServicioBase
    {

          /// Inserta o actualiza un registro de Tipo Contrato
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveOrUpdateTipoContrato(TipoContratoDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Tipocontcodi == 0)
                {
                //    id = FactoryTransferencia.GetAreaRepository().Save(entity);
                    id = FactoryTransferencia.GetTipoContratoRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetTipoContratoRepository().Update(entity);
                    id = entity.Tipocontcodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un área en base al id
        /// </summary>
        /// <param name="idTipoContrato"></param>
        public int DeleteTipoContrato(int idTipoContrato)
        {
            try
            {
                FactoryTransferencia.GetTipoContratoRepository().Delete(idTipoContrato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return idTipoContrato;
        }

        /// <summary>
        /// Permite obtener el área en base al id
        /// </summary>
        /// <param name="idTipoContrato"></param>
        /// <returns></returns>
        public TipoContratoDTO GetByIdTipoContrato(int idTipoContrato)
        {
            return FactoryTransferencia.GetTipoContratoRepository().GetById(idTipoContrato);
        }

        /// <summary>
        /// Permite listar todas las áreas
        /// </summary>
        /// <returns></returns>
        public List<TipoContratoDTO> ListTipoContrato()
        {
            return FactoryTransferencia.GetTipoContratoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas de áreas en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<TipoContratoDTO> BuscarTipoContrato(string nombre)
        {
            return FactoryTransferencia.GetTipoContratoRepository().GetByCriteria(nombre);
        }
    }

    
}
