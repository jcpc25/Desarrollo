using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla ME_MEDICION1
    /// </summary>
    public interface IMeMedicion1Repository
    {
        void Save(MeMedicion1DTO entity);
        void Update(MeMedicion1DTO entity);
        void Delete(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi);
        MeMedicion1DTO GetById(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi);
        List<MeMedicion1DTO> List();
        List<MeMedicion1DTO> GetByCriteria();
        void DeleteEnvioArchivo(int idLectura, DateTime fechaInicio, DateTime fechaFin, int idFormato, int idEmpresa);
        List<MeMedicion1DTO> GetEnvioArchivo(int idFormato, int idEmpresa, DateTime fechaInicio, DateTime fechaFin);
        List<MeMedicion1DTO> GetHidrologia(int idLectura, int idOrigenLectura, string idsEmpresa, DateTime fechaInicio, DateTime fechaFin);
    }
}
