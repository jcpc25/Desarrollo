using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EN_ESTFORMATO
    /// </summary>
    public interface IEnEstformatoRepository
    {
        void Save(EnEstformatoDTO entity);
        void Update(EnEstformatoDTO entity);
        void Delete();
        EnEstformatoDTO GetById();
        List<EnEstformatoDTO> List();
        List<EnEstformatoDTO> ListFormatoXEstado(int ensayocodi, int iformatocodi);
        List<EnEstformatoDTO> GetByCriteria();
    }
}
