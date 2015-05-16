using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla MD_PUBLICACION
    /// </summary>
    public interface IMdPublicacionRepository
    {
        void Save(MdPublicacionDTO entity);
        void Update(MdPublicacionDTO entity);
        void Delete(int emprcodi, DateTime publimes);
        MdPublicacionDTO GetById(int emprcodi, DateTime publimes);
        List<MdPublicacionDTO> List();
        List<MdPublicacionDTO> GetByCriteria();
        MdPublicacionDTO GetLastPubEmpresa(DateTime publimes, int emprcodi);
    }
}
