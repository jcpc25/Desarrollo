using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla ME_FORMATO
    /// </summary>
    public interface IMeFormatoRepository
    {
        int Save(MeFormatoDTO entity);
        void Update(MeFormatoDTO entity);
        void Delete(int formatcodi);
        MeFormatoDTO GetById(int formatcodi);
        List<MeFormatoDTO> List();
        List<MeFormatoDTO> GetByCriteria(int areaUsuario);
    }
}
