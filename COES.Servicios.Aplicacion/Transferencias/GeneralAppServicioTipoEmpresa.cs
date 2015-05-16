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
   public class GeneralAppServicioTipoEmpresa: AppServicioBase
    {
       public List<TipoEmpresaDTO> ListTipoEmpresas()
       {
           return FactoryTransferencia.GetTipoEmpresaRepository().List();
       }
    }
}
