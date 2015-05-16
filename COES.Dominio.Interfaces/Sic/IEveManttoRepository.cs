using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla EVE_MANTTO
    /// </summary>
    public interface IEveManttoRepository
    {
        void Save(EveManttoDTO entity);
        void Update(EveManttoDTO entity);
        void Delete(int manttocodi);
        EveManttoDTO GetById(int manttocodi);
        List<EveManttoDTO> List();
        List<EveManttoDTO> GetByCriteria();
        List<EveManttoDTO> BuscarMantenimientos(string idsTipoMantenimiento, DateTime fechaInicio, DateTime fechaFin,
            string idsTipoEmpresa, string idsEmpresa, string idsTipoEquipo, string indInterrupcion, string idstipoMantto, 
            string idsEquipos,int nroPagina, int nroFilas);
        int ObtenerNroRegistros(string idsTipoMantenimiento, DateTime fechaInicio, DateTime fechaFin,
           string idsTipoEmpresa, string idsEmpresa, string idsTipoEquipo, string idsEquipos, string indInterrupcion, string idstipoMantto);
        List<ReporteManttoDTO> ObtenerTotalManttoEmpresa(DateTime fechaInicio, DateTime fechaFin,
            string idsTipoEmpresa, string idsEmpresa, string idsTipoEquipo, string indInterrupcion, string idstipoMantto);
        List<EveManttoDTO> ObtenerReporteMantenimientos(string idsTipoMantenimiento, DateTime fechaInicio, DateTime fechaFin,
            string idsTipoEmpresa, string idsEmpresa, string idsTipoEquipo, string indInterrupcion,string idstipoMantto,string idsEquipo);
    }
}
