using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla MD_ENVIO
    /// </summary>
    public interface IMdEnvioRepository
    {
        void Save(MdEnvioDTO entity);
        void Update(MdEnvioDTO entity);
        void Delete(int enviocodi);
        MdEnvioDTO GetById(int enviocodi);
        List<MdEnvioDTO> List();
        List<MdEnvioDTO> GetByCriteria(int emprcodi, DateTime enviomes);
    }
}
