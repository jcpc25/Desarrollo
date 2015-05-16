using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla ME_HOJAPTOMED
    /// </summary>
    public interface IMeHojaptomedRepository
    {
        void Save(MeHojaptomedDTO entity, int empresa);
        void Update(MeHojaptomedDTO entity);
        void Delete(int hojanumero, int formatcodi, int tipoinfocodi, int ptomedicodi);
        MeHojaptomedDTO GetById(int hojanumero, int formatcodi, int tipoinfocodi, int ptomedicodi, int hojaptosigno);
        List<MeHojaptomedDTO> List();
        List<MeHojaptomedDTO> GetByCriteria(int emprcodi, int formatcodi, int hojacodi);
    }
}
