using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EQ_RELACION
    /// </summary>
    public interface IEqRelacionRepository
    {
        int Save(EqRelacionDTO entity);
        void Update(EqRelacionDTO entity);
        void Delete(int relacioncodi);
        EqRelacionDTO GetById(int relacioncodi);
        List<EqRelacionDTO> List();
        List<EqRelacionDTO> GetByCriteria();
    }
}
