using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla ME_AMPLIACIONFECHA
    /// </summary>
    public interface IMeAmpliacionfechaRepository
    {
        void Save(MeAmpliacionfechaDTO entity);
        void Update(MeAmpliacionfechaDTO entity);
        void Delete();
        MeAmpliacionfechaDTO GetById(DateTime fecha, int empresa, int formato);
        List<MeAmpliacionfechaDTO> List();
        List<MeAmpliacionfechaDTO> GetByCriteria();
        List<MeAmpliacionfechaDTO> GetListaAmpliacion(DateTime fechaIni, DateTime fechaFin, int empresa, int formato);
    }
}
