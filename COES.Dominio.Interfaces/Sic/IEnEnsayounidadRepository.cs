using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EN_ENSAYOUNIDAD
    /// </summary>
    public interface IEnEnsayounidadRepository
    {
        void Update(EnEnsayounidadDTO entity);
        void Save(EnEnsayounidadDTO entity);
        void Delete(int ensayocodi);
        EnEnsayounidadDTO GetById();
        List<EnEnsayounidadDTO> List();
        List<EnEnsayounidadDTO> GetByCriteria();
        List<EnEnsayounidadDTO> ListarUnidadxEnsayo(int ensayocodi);
    }
}
