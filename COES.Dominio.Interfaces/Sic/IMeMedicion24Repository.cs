using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla ME_MEDICION24
    /// </summary>
    public interface IMeMedicion24Repository
    {
        void Save(MeMedicion24DTO entity);
        void Update(MeMedicion24DTO entity);
        void Delete();
        MeMedicion24DTO GetById();
        List<MeMedicion24DTO> List();
        List<MeMedicion24DTO> GetByCriteria();
        void DeleteEnvioArchivo(int idLectura, DateTime fechaInicio, DateTime fechaFin, int idFormato, int idEmpresa);
        List<MeMedicion24DTO> GetEnvioArchivo(int idFormato, int idEmpresa, DateTime fechaInicio, DateTime fechaFin);
        List<MeMedicion24DTO> GetHidrologia(int idLectura, int idOrigenLectura,string idsEmpresa,string idsCuenca, DateTime fechaInicio, DateTime fechaFin);
    }
}
