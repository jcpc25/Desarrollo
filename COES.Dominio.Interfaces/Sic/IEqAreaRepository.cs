using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EQ_AREA
    /// </summary>
    public interface IEqAreaRepository
    {
        int Save(EqAreaDTO entity);
        void Update(EqAreaDTO entity);
        void Delete(int areacodi);
        EqAreaDTO GetById(int areacodi);
        List<EqAreaDTO> List();
        List<EqAreaDTO> GetByCriteria();
        List<EqAreaDTO> ListarxFiltro(int idTipoArea, string strNombreArea, int nroPagina, int nroFilas);
        int CantidadListarxFiltro(int idTipoArea, string strNombreArea);
    }
}
