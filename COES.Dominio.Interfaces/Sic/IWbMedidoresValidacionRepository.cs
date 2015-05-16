using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla WB_MEDIDORES_VALIDACION
    /// </summary>
    public interface IWbMedidoresValidacionRepository
    {
        int Save(WbMedidoresValidacionDTO entity);
        void Update(WbMedidoresValidacionDTO entity);
        void Delete(int medivalcodi);
        WbMedidoresValidacionDTO GetById(int medivalcodi);
        List<WbMedidoresValidacionDTO> List();
        List<WbMedidoresValidacionDTO> GetByCriteria();
    }
}
