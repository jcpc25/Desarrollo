using COES.Dominio.DTO.Sic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Sic
{
    public interface IMeMedicion96Repository
    {
        void Save(MeMedicion96DTO entity);

        List<MeMedicion96DTO> ObtenerConsultaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin, int nroPagina, int nroRegistros);
        
        List<MeMedicion96DTO> ObtenerConsultaServiciosAuxiliares(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin, int nroPagina, int nroRegistros);

        List<MeMedicion96DTO> ObtenerExportacionConsultaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin);

        List<MeMedicion96DTO> ObtenerExportacionServiciosAuxiliares(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin);

        List<MeMedicion96DTO> ObtenerExportacionMasivaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin);

        List<MeMedicion96DTO> ObtenerExportacionMasivaSSAA(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
           string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin);
        
        List<MeMedicion96DTO> ObtenerTotalConsultaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin);

        List<MeMedicion96DTO> ObtenerTotalServiciosAuxiliares(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin);

        int ObtenerNroElementosConsultaMedidores(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin);

        int ObtenerNroElementosServiciosAuxiliares(int tipoInfoCodi, string empresas, int tipoGrupoCodi,
            string tipoGeneracion, DateTime fechaInicio, DateTime fechaFin);

        List<MeMedicion96DTO> ListarTotalH(DateTime fechaini, DateTime fechafin, string empresas,
            string tiposGeneracion, int central);

        List<MeMedicion96DTO> ListarDetalle(DateTime fechaini, DateTime fechafin, string empresas,
            string tiposGeneracion, int central);

        List<MeMedicion96DTO> ObtenerReporteMedidores(string empresas, int tipoGrupoCodi, string fuenteEnergia,
            DateTime fechaInicio, DateTime fechaFin);

        List<MeMedicion96DTO> ObtenerDatosReporteMD(string empresas, int tipoGrupoCodi, string fuenteEnergia,
            DateTime fechaInicio, DateTime fechaFin);

        List<MeMedicion96DTO> ObtenerEnvioPorEmpresa(int emprcodi, DateTime fechaPeriodo);

        void DeleteEnvioPorEmpresa(int emprcodi, DateTime fechaPeriodo);

        List<ConsolidadoEnvioDTO> ConsolidadoEnvioXEmpresa(int emprcodi, DateTime fechaPeriodo);

        List<MeMedicion96DTO> ObtenerEnvioInterconexion(int emprcodi, DateTime fechaini, DateTime fechafin);

        void DeleteEnvioInterconexion(DateTime medifecha);

        List<MeMedicion96DTO> ObtenerHistoricoInterconexion(int ptomedicodi, DateTime fechaini, DateTime fechafin);

        int ObtenerTotalHistoricoInterconexion(int ptomedicodi, DateTime fechaini, DateTime fechafin);

        List<MeMedicion96DTO> ObtenerHistoricoPagInterconexion(int ptomedicodi, DateTime fechaini, DateTime fechafin, int pagina);

        void DeleteEnvioArchivo(int idLectura, DateTime fechaInicio, DateTime fechaFin, int idFormato, int idEmpresa);

        List<MeMedicion96DTO> GetEnvioArchivo(int idFormato, int idEmpresa, DateTime fechaInicio, DateTime fechaFin);

        List<MeMedicion96DTO> GetByCriteria(int idTipoInformacion, int idPtoMedicion, int idLectura, DateTime fechaInicio,
            DateTime fechaFin);
        List<MeMedicion96DTO> GetHidrologia(int idLectura, int idOrigenLectura, string idsEmpresa, DateTime fechaInicio, DateTime fechaFin);

    }
}
