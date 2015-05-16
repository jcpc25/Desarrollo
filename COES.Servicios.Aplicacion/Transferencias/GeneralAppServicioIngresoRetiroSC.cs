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
   public class GeneralAppServicioIngresoRetiroSC:AppServicioBase
    {

        public int SaveIngresoRetiroSC(IngresoRetiroSCDTO entity)
        {
            try
            {
                int id = 0;
                if (entity.Ingrsccodi == 0)
                {
                    id = FactoryTransferencia.GetIngresoRetiroSCRepository().Save(entity);
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public int DeleteListaIngresoRetiroSC(int PeriCodi, int IngrscVersion)
        {
            try
            {
                FactoryTransferencia.GetIngresoRetiroSCRepository().Delete(PeriCodi, IngrscVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return PeriCodi;
        }


        public List<IngresoRetiroSCDTO> ListImportesByPeriVer(int pericodi, int version)
        {
            return FactoryTransferencia.GetIngresoRetiroSCRepository().GetByCriteria(pericodi, version);
        }

        public List<IngresoRetiroSCDTO> BuscarIngresoRetiroSC(int? idPeriodo)
        {
            return FactoryTransferencia.GetIngresoRetiroSCRepository().GetByCodigo(idPeriodo);
        }
    }
}
