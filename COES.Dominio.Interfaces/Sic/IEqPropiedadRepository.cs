using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EQ_PROPIEDAD
    /// </summary>
    public interface IEqPropiedadRepository
    {
        int Save(EqPropiedadDTO entity);
        void Update(EqPropiedadDTO entity);
        void Delete(int propcodi);
        EqPropiedadDTO GetById(int propcodi);
        List<EqPropiedadDTO> List();
        List<EqPropiedadDTO> GetByCriteria();
    }
}
