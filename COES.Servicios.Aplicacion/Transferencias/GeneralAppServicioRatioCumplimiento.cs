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
  public  class GeneralAppServicioRatioCumplimiento: AppServicioBase
    {
      public List<RatioCumplimientoDTO> ListRatioCumplimiento(int? idTipoEmpresa, int? idPeriodo)
      {
          return FactoryTransferencia.GetRatioCumplimientoRepository().GetByCodigo(idTipoEmpresa, idPeriodo);
      }

      public List<RatioCumplimientoDTO> BuscarRatio(string nombre)
      {
          return FactoryTransferencia.GetRatioCumplimientoRepository().GetByCriteria(nombre);
      }
    }
}
