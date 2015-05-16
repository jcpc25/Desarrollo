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
    public class GerenalAppServicioTransferenciaRetiro : AppServicioBase
    {

        /// <summary>
        /// Graba una entidad TransferenciaRetiroDTO
        /// </summary>
        /// <param name="entity"></param>
        public int SaveOrUpdateTransferenciaRetiro(TransferenciaRetiroDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Tranreticodi == 0)
                {
                    id = FactoryTransferencia.GetTransferenciaRetiroRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetTransferenciaRetiroRepository().Update(entity);
                    id = entity.Tranreticodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// Elimina TransferenciaRetiro en base al id de
        /// </summary>
        /// <param name="Emprcodi"></param>
        /// /// <param name="pericodi"></param>
        /// /// <param name="version"></param>
        public int DeleteTransferenciaRetiro(int Emprcodi, int pericodi, int version)
        {
            try
            {
                FactoryTransferencia.GetTransferenciaRetiroRepository().Delete(Emprcodi, pericodi, version);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return version;
        }


        /// <summary>
        /// Permite listar los codigo de retiro
        /// </summary>
        /// <param name="emprcodi"></param>
        /// <param name="pericodi"></param>
        /// <returns></returns>
        public List<TransferenciaRetiroDTO> ListTransferenciaRetiro(int emprcodi, int pericodi,int version)
        {
            return FactoryTransferencia.GetTransferenciaRetiroRepository().List(emprcodi, pericodi, version);
        }

    }
}
