using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla PR_CONCEPTO
    /// </summary>
    public interface IPrConceptoRepository
    {
        int Save(PrConceptoDTO entity);
        void Update(PrConceptoDTO entity);
        void Delete(int concepcodi);
        PrConceptoDTO GetById(int concepcodi);
        List<PrConceptoDTO> List();
        List<PrConceptoDTO> GetByCriteria();
    }
}
