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
    public class GeneralAppServicioPeriodo : AppServicioBase
    {
        public int SaveOrUpdatePeriodo(PeriodoDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Pericodi == 0)
                {
                    id = FactoryTransferencia.GetPeriodoRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetPeriodoRepository().Update(entity);
                    id = entity.Pericodi;
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
        public int DeletePeriodo(int idPeriodo)
        {
            try
            {
                FactoryTransferencia.GetPeriodoRepository().Delete(idPeriodo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return idPeriodo;
        }

        /// <summary>
        /// Permite obtener la barra en base al id
        /// </summary>
        /// <param name="idBarra"></param>
        /// <returns></returns>
        public PeriodoDTO GetByIdPeriodo(System.Int32? idPeriodo)
        {
            return FactoryTransferencia.GetPeriodoRepository().GetById(idPeriodo);
        }

        /// <summary>
        /// Permite listar todas las barras
        /// </summary>
        /// <returns></returns>
        public List<PeriodoDTO> ListPeriodo()
        {
            return FactoryTransferencia.GetPeriodoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas de barras en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<PeriodoDTO> BuscarPeriodo(string nombre)
        {
            return FactoryTransferencia.GetPeriodoRepository().GetByCriteria(nombre);
        }
    }
}
