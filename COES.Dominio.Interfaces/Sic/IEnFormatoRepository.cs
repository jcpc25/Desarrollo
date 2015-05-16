using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EN_FORMATO
    /// </summary>
    public interface IEnFormatoRepository
    {
        void Update(EnFormatoDTO entity);
        void Save(EnFormatoDTO entity);
        void Delete();
        EnFormatoDTO GetById();
        List<EnFormatoDTO> List();
        List<EnFormatoDTO> GetByCriteria();
    }
}
