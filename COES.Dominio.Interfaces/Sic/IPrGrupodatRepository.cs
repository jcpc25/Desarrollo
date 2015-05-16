using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla PR_GRUPODAT
    /// </summary>
    public interface IPrGrupodatRepository
    {
        void Save(PrGrupodatDTO entity);
        void Update(PrGrupodatDTO entity);
        void Delete(DateTime fechadat, int concepcodi, int grupocodi, int deleted);
        PrGrupodatDTO GetById(DateTime fechadat, int concepcodi, int grupocodi, int deleted);
        List<PrGrupodatDTO> List();
        List<PrGrupodatDTO> GetByCriteria();
        List<ConceptoDatoDTO> ListarDatosConceptoGrupoDat(int iGrupoCodi);
    }
}
