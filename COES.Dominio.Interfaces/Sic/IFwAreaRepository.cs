using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla FW_AREA
    /// </summary>
    public interface IFwAreaRepository
    {
        int Save(FwAreaDTO entity);
        void Update(FwAreaDTO entity);
        void Delete(int areacode);
        FwAreaDTO GetById(int areacode);
        List<FwAreaDTO> List();
        List<FwAreaDTO> GetByCriteria();
    }
}
