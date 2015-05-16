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
  public class GeneralAppServicioCompensacion: AppServicioBase
    {

        public int SaveOrUpdateCompensacion(CompensacionDTO entity)
        //public IEnumerable(<BarraTransferenciaDTO entity>)SaveOrUpdateBarraTransferencia
        {
            try
            {
                int id = 0;

                if (entity.Cabecompcodi == 0)
                {
                    id = FactoryTransferencia.GetCompensacionRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetCompensacionRepository().Update(entity);
                    id = entity.Cabecompcodi;
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
        public int DeleteCompensacion(int idCompensacion)
        {
            try
            {
                FactoryTransferencia.GetCompensacionRepository().Delete(idCompensacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return idCompensacion;
        }

        /// <summary>
        /// Permite obtener la barra de transferencia en base al id
        /// </summary>
        /// <param name="idBarra"></param>
        /// <returns></returns>
        public CompensacionDTO GetByIdCompensacion(int idCompensacion)
        {
            return FactoryTransferencia.GetCompensacionRepository().GetById(idCompensacion);
        }

        /// <summary>
        /// Permite listar todas las barras de transferencias
        /// </summary>
        /// <returns></returns>

        public CompensacionDTO GetByCodigo(string nombre, int pericodi)
        {
            return FactoryTransferencia.GetCompensacionRepository().GetByCodigo(nombre, pericodi);
        }

        public List<CompensacionDTO> ListCompensaciones(int id)
        {
            return FactoryTransferencia.GetCompensacionRepository().List(id);
        }

        /// <summary>
        /// Permite realizar búsquedas de barras de transferencia en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<CompensacionDTO> BuscarCompensacion(string nombre)
        {
            return FactoryTransferencia.GetCompensacionRepository().GetByCriteria(nombre);
        }
    }
}
