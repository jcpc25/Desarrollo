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
    public class GeneralAppServicioExportarExcelG : AppServicioBase
    {

        /// <summary>
        /// Permite realizar búsquedas de Cuadro para exportar en base al periodo y version
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<ExportExcelDTO> BuscarValoresParaCuadro(int pericodi, int version)
        {
            return FactoryTransferencia.GetExportExcelRepository().GetByPeriVer(pericodi,version);
        }


        /// <summary>
        /// Permite realizar búsquedas de CodigoEntrega en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<ExportExcelDTO> BuscarCompensacion(int emprcodi,int pericodi,int version  )
        {
            return FactoryTransferencia.GetExportExcelRepository().GetByEmprPeriVersion(emprcodi, pericodi, version);
        }


          /// <summary>
        /// Permite realizar búsquedas de PAGOS DE EMPRESAS en base al PERIODO Y VERSION
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<EmpresaPagoDTO> BuscarPagosMatriz(int emprcodi,int pericodi,int version  )
        {
            return FactoryTransferencia.GetExportExcelRepository().GetMatrizByPeriVersion(emprcodi,pericodi, version);
        }


            public List<EmpresaPagoDTO> BuscarEmpresasPagMatriz(int pericodi,int version  )
        {
            return FactoryTransferencia.GetExportExcelRepository().GetMatrizEmprByPeriVersion(pericodi, version);
        }
     
     
    }
}
