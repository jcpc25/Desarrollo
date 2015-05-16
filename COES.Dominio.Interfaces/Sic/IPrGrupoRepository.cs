using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla PR_GRUPO
    /// </summary>
    public interface IPrGrupoRepository
    {
        int Save(PrGrupoDTO entity);
        void Update(PrGrupoDTO entity);
        void Delete(int grupocodi);
        PrGrupoDTO GetById(int grupocodi);
        List<PrGrupoDTO> List();
        List<PrGrupoDTO> GetByCriteria(int idTipoGrupo);
        List<GrupoGeneracionDTO> ListarGeneradoresDespachoOsinergmin();
        List<PrGrupoDTO> ListaModosOperacionActivos();
        void CambiarTipoGrupo(int idGrupo, int idTipoGrupo, string userName, DateTime fecha);
        List<ModoOperacionDTO> ModoOperacionCentral1(int iCentral);
        List<ModoOperacionDTO> ModoOperacionCentral2(int iCentral);
        int ObtenerCodigoModoOperacionPadre(int iPrGrupo);
        List<PrGrupoDTO> ListCentrales(string tipocombustible, string emprcodi);
    }
}
