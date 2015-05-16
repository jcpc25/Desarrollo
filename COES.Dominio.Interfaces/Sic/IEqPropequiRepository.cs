using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EQ_PROPEQUI
    /// </summary>
    public interface IEqPropequiRepository
    {
        void Save(EqPropequiDTO entity);
        void Update(EqPropequiDTO entity);
        void Delete(int propcodi, int equicodi, DateTime fechapropequi);
        EqPropequiDTO GetById(int propcodi, int equicodi, DateTime fechapropequi);
        List<EqPropequiDTO> List();
        List<EqPropequiDTO> GetByCriteria();
        List<PropiedadEquipoHistDTO> ListarDatosPropiedadesFichaTecnicaVigentesxEquipo(int iEquipo, int iFamilia);
    }
}
