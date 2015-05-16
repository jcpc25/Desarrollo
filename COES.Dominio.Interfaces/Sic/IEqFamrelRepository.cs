using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EQ_FAMREL
    /// </summary>
    public interface IEqFamrelRepository
    {
        void Save(EqFamrelDTO entity);
        void Update(EqFamrelDTO entity);
        void Delete(int tiporelcodi, int famcodi1, int famcodi2);
        EqFamrelDTO GetById(int tiporelcodi, int famcodi1, int famcodi2);
        List<EqFamrelDTO> List();
        List<EqFamrelDTO> GetByCriteria();
    }
}
