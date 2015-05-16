using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla ME_PERFIL_RULE
    /// </summary>
    public interface IMePerfilRuleRepository
    {
        int Save(MePerfilRuleDTO entity);
        void Update(MePerfilRuleDTO entity);
        void Delete(int prrucodi, string username);
        MePerfilRuleDTO GetById(int prrucodi);
        List<MePerfilRuleDTO> List();
        List<MePerfilRuleDTO> GetByCriteria(int area, string fuente);
        List<MePerfilRuleDTO> ObtenerPuntosEjecutado();
        List<MePerfilRuleDTO> ObtenerPuntosDemanda();
        List<MePerfilRuleDTO> ObtenerPuntosScada();
        string ObtenerNombrePunto(int ptoMediCodi);
        string ObtenerNombrePuntoScada(int ptoMediCodi);
        string ObtenerNombrePuntoDemanda(int ptoMediCodi);
    }
}
