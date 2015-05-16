using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla CB_CONCEPTOCOMB
    /// </summary>
    public interface ICbConceptocombRepository
    {
        int Save(CbConceptocombDTO entity);
        void Update(CbConceptocombDTO entity);
        void Delete(int concepcodi);
        CbConceptocombDTO GetById(int concepcodi);
        List<CbConceptocombDTO> List();
        int GetByCriteria(int orden, int tipocomb);
    }
}
