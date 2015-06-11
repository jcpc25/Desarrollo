using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EQ_FAMILIA
    /// </summary>
    public interface IEqFamiliaRepository
    {
        int Save(EqFamiliaDTO entity);
        void Update(EqFamiliaDTO entity);
        void Delete(int famcodi);
        EqFamiliaDTO GetById(int famcodi);
        List<EqFamiliaDTO> List();
        List<EqFamiliaDTO> GetByCriteria();
        List<EqFamiliaDTO> GetByCriteriaRecurso(string recursos);
    }
}
