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
  public class GeneralAppServicioIngresoCompensacion: AppServicioBase
    {
        public int SaveIngresoCompensacion(IngresoCompensacionDTO entity)
        {
            try
            {
                int id = 0;
                if (entity.IngrCompCodi == 0)
                {
                    id = FactoryTransferencia.GetIngresoCompensacionRepository().Save(entity);
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public int DeleteListaIngresoCompensacion(int PeriCodi, int IngrCompVersion)
        {
            try
            {
                FactoryTransferencia.GetIngresoCompensacionRepository().Delete(PeriCodi, IngrCompVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return PeriCodi;
        }

        public List<IngresoCompensacionDTO> BuscarIngresoCompensacion(int? idPeriodo)
        {
            return FactoryTransferencia.GetIngresoCompensacionRepository().GetByCodigo(idPeriodo);
        }
    }
}
