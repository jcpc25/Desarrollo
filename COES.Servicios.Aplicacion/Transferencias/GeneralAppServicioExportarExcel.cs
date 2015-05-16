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
    public class GeneralAppServicioExportarExcel : AppServicioBase
    {

        /// <summary>
        /// Permite realizar búsquedas de CodigoEntrega en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<ExportExcelDTO> BuscarCodigoRetiro(int codEmp)
        {
            return FactoryTransferencia.GetIEnvioInformacionRepository().GetByCriteria(codEmp);
        }
    }
}
