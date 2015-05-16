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
   public  class GeneralAppServicioInfoDesviacion: AppServicioBase
    {
       public List<InfoDesviacionDTO> BuscarInfoDesviacion(Int32 AnioMes, Int32 AnioMes1, Int32 AnioMes2, Int32 Dias, Int32 DiasMeses, Decimal Desviacion)
        {
            return FactoryTransferencia.GetInfoDesviacionRepository().GetByCriteria(AnioMes, AnioMes1, AnioMes2, Dias, DiasMeses, Desviacion);
        }
    }
}
