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
    public class GerenalAppServicioTransferenciaEntrega : AppServicioBase
    {
        /// <summary>
        /// Graba una entidad TransferenciaEntregaDTO
        /// </summary>
        /// <param name="entity"></param>
        public int SaveOrUpdateTransferenciaEntrega(TransferenciaEntregaDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Tranentrcodi == 0)
                {
                    id = FactoryTransferencia.GetTransferenciaEntregaRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetTransferenciaEntregaRepository().Update(entity);
                    id = entity.Tranentrcodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Elimina unaTransferenciaEntrega en base al id de
        /// </summary>
        /// <param name="Emprcodi"></param>
        /// /// <param name="pericodi"></param>
        /// /// <param name="version"></param>
        public int DeleteTransferenciaEntrega(int Emprcodi,int pericodi,int version)
        {
            try
            {
                FactoryTransferencia.GetTransferenciaEntregaRepository().Delete(Emprcodi,pericodi,version);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return version;
        }


        /// <summary>
        /// Permite listar los codigo de entrega
        /// </summary>
        /// <param name="emprcodi"></param>
        /// <param name="pericodi"></param>
        /// <returns></returns>
        public List<TransferenciaEntregaDTO> ListTransferenciaEntrega(int emprcodi, int pericodi,int version)
        {
            return FactoryTransferencia.GetTransferenciaEntregaRepository().List(emprcodi, pericodi, version);
        }
    }

    
      
}
