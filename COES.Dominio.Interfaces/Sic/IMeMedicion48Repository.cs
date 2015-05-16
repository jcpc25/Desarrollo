using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla ME_MEDICION48
    /// </summary>
    public interface IMeMedicion48Repository
    {
        void Save(MeMedicion48DTO entity);
        void Update(MeMedicion48DTO entity);
        void Delete(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi);
        MeMedicion48DTO GetById(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi);
        List<MeMedicion48DTO> List();
        List<MeMedicion48DTO> GetByCriteria();
        List<MeMedicion48DTO> ObtenerGeneracionRER(int idEmpresa, int lectCodi, DateTime fechaInicio, DateTime fechaFin);
        void EliminarValoresCargados(int idEmpresa, int lectCodi, DateTime fechaInicio, DateTime fechaFin);
        bool ValidarExistenciaDatos(int idEmpresa, int lectCodi, DateTime fechaInicio, DateTime fechaFin);
        void DeleteEnvioArchivo(int idLectura, DateTime fechaInicio, DateTime fechaFin, int idFormato, int idEmpresa);
        List<MeMedicion48DTO> GetEnvioArchivo(int idFormato, int idEmpresa, DateTime fechaInicio, DateTime fechaFin);
        List<MeMedicion48DTO> ObteneReporteValidacionMedidores(string empresas, int tipoGrupoCodi, string fuenteEnergia,
            DateTime fechaInicio, DateTime fechaFin);
        List<MeMedicion48DTO> ObtenerReporteValidacionDespacho(string empresas, int tipoGrupoCodi, string fuenteEnergia,
            DateTime fechaInicio, DateTime fechaFin);
        List<MeMedicion48DTO> GetHidrologia(int idLectura, int idOrigenLectura, string idsEmpresa, string idsCuenca, DateTime fechaInicio, DateTime fechaFin);
    }
}
