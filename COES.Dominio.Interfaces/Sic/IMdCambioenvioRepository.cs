using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla MD_CAMBIOENVIO
    /// </summary>
    public interface IMdCambioenvioRepository
    {
        void Save(MdCambioenvioDTO entity);
        void Update(MdCambioenvioDTO entity);
        void Delete(int tipoinfocodi, int enviocodiold, DateTime medifecha, int ptomedicodi);
        MdCambioenvioDTO GetById(int tipoinfocodi, int enviocodiold, DateTime medifecha, int ptomedicodi);
        List<MdCambioenvioDTO> List();
        List<MdCambioenvioDTO> GetByCriteria();
    }
}
