using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla CB_COMBUSTIBLEDATOS
    /// </summary>
    public interface ICbCombustibledatosRepository
    {
        void Save(CbCombustibledatosDTO entity);
        void Update(CbCombustibledatosDTO entity);
        void Delete(DateTime combdatosfecha, int concepcodi, int enviocodi);
        CbCombustibledatosDTO GetById(DateTime combdatosfecha, int concepcodi, int enviocodi);
        List<CbCombustibledatosDTO> List();
        List<CbCombustibledatosDTO> GetByCriteria(int concepcodi, int enviocodi);
        List<CbCombustibledatosDTO> GetListPropValor(int Conceporden);
    }
}
