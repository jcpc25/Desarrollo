using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla CB_ENVIO
    /// /// </summary>
    public interface ICbEnvioRepository
    {
        int Save(CbEnvioDTO entity);
        void Update(CbEnvioDTO entity);
        void UpdateObs(CbEnvioDTO entity);
        void Delete(int enviocodi);
        CbEnvioDTO GetById(int enviocodi);
        List<CbEnvioDTO> List();
        List<CbEnvioDTO> ListaDetalle(int tipocombcodi);
        List<CbEnvioDTO> ListaDetalleFiltro(string emprcodi, string grupocodi, string estenvcodi, DateTime fechaInicio, DateTime fechaFin, int tipocombustibles, int nroPaginas, int pageSize);
        List<CbEnvioDTO> ListaDetalleFiltroXls(string emprcodi, string grupocodi, string estenvcodi, DateTime fechaInicio, DateTime fechaFin, int tipocombustibles);
        int ObtenerTotalListaEnvio(string emprcodi, string grupocodi, string estenvcodi, DateTime fechaInicio, DateTime fechaFin, int tipocombustibles);
        List<DateTime> ObtenerDiasFeriados(DateTime fIni, DateTime fFin);
    }


}
