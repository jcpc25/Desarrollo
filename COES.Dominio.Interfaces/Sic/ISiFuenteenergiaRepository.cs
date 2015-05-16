using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla SI_FUENTEENERGIA
    /// </summary>
    public interface ISiFuenteenergiaRepository
    {
        int Save(SiFuenteenergiaDTO entity);
        void Update(SiFuenteenergiaDTO entity);
        void Delete(int fenergcodi);
        SiFuenteenergiaDTO GetById(int fenergcodi);
        List<SiFuenteenergiaDTO> List();
        List<SiFuenteenergiaDTO> GetByCriteria();
    }
}
