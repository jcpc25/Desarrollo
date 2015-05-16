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
    public class GeneralAppServicioBarra : AppServicioBase
    {   /// <summary>
        /// Permite insertar o actualizar la información de la entidad
        /// </summary>
        /// <param name="BarraDTO"></param>
        public int SaveOrUpdateBarra(BarraDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Barrcodi == 0)
                {
                    id = FactoryTransferencia.GetBarraRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetBarraRepository().Update(entity);
                    id = entity.Barrcodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina una barra en base al id
        /// </summary>
        /// <param name="idBarra"></param>
        public int DeleteBarra(int idBarra)
        {
            try
            {
                FactoryTransferencia.GetBarraRepository().Delete(idBarra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return idBarra;
        }

        /// <summary>
        /// Permite obtener la barra en base al id
        /// </summary>
        /// <param name="idBarra"></param>
        /// <returns></returns>
        public BarraDTO GetByIdBarra(int idBarra)
        {
            return FactoryTransferencia.GetBarraRepository().GetById(idBarra);
        }

        /// <summary>
        /// Permite listar todas las barras
        /// </summary>
        /// <returns></returns>
        public List<BarraDTO> ListBarras()
        {
            return FactoryTransferencia.GetBarraRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas de barras en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<BarraDTO> BuscarBarra(string nombre)
        {
            return FactoryTransferencia.GetBarraRepository().GetByCriteria(nombre);
        }
    }
}
