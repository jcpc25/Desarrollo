using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla CB_ARCHIVOENVIO
    /// /// </summary>
    public interface ICbArchivoEnvioRepository
    {
        void Save(CbArchivoEnvioDTO entity);
        void Update(CbArchivoEnvioDTO entity);
        void Delete(int concepcodi, int enviocodi);
        List<CbArchivoEnvioDTO> GetById(int enviocodi);
        List<CbArchivoEnvioDTO> List();
        void UpdateEstado(int iEstado, int concepcodi, int enviocodi, int archienvioorden);
        int GetMaxIdOrden(int concepcodi, int enviocodi);
    }
}
