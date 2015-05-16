using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Helper
{
    public class Constantes
    {
        public const int AccionEditar = 0;
        public const int AccionNuevo = 1;

        public const string FormatoFecha = "dd/MM/yyyy";
        public const string FormatoHora = "HH:mm:ss";
        public const string FormatoHoraMinuto = "HH:mm";
        public const string FormatoFechaHora = "dd/MM/yyyy HH:mm";
        public const string FormatoFechaFull = "dd/MM/yyyy HH:mm:ss";
        public const string HoraInicio = "00:00:00";
        public const string FormatoNumero = "#,###.00";
        public const string FormatoDecimal = "###.00";
        public const int PageSize = 20;
        public const int PageSizeEvento = 50;
        public const int PageSizeMedidores = 200;
        public const int NroPageShow = 10;

        public const string NombreReportePerturbacionWord = "Perturbacion.docx";
        public const string NombreReportePerturbacionPdf = "Perturbacion.pdf";
        public const string NombreReportePerfilScadaExcel = "Perfiles.xlsx";
        public const string NombrePlantillaImportacionPerfilExcel = "PlantillaImportacion.xlsx";
        public const string NombreFormatoImportacionPerfilExcel = "Importacion.xlsx";
        public const string NombreReporteRSF = "rsf.xlsx";
        public const string NombreReporteRSF30 = "rsf30.xlsx";
        public const string NombreReporteRSFGeneral = "rsf_reporte.xlsx";
        public const string PlantillaReportePerfilScadaExcel = "Plantilla.xlsx";
        public const string NombreCSVServicioRPF = "CumplimientoRPF.csv";
        public const string HojaReporteExcel = "REPORTE";
        public const string NombreLogoCoes = "coes.png";
        public const string PlantillaExcel = "Plantilla.xlsx";
        public const string PlantillaExcelRSF30 = "PlantillaRsf30.xlsx";
        public const string PlantillaExcelReporteRSF = "PlantillaReporteRSF.xlsx";
        public const string PlantillaCumplimiento = "PlantillaRPF.xlsx";
        public const string PlantillaCumplimientoFalla = "PlantillaRPFFalla.xlsx";
        public const string PlantillaPotencia = "PlantillaPotenciaRPF.xlsx";
        public const string NombreReporteCargaRPF = "Cumplimiento.xlsx";
        public const string NombreReporteCumplimientoRPF = "Evaluacion.xlsx";
        public const string NombreReporteCumplimientoRPFFalla = "EvaluacionFalla.xlsx";
        public const string ArchivoPotencia = "Potencia.xlsx";
        public const string ArchivoImportacionPerfiles = "ImportacionPerfil.xlsx";
        public const string ArchivoDesviacion = "Desviacion.xlsx";
        public const string NombreReporteRPFWord = "CumplimientoRPF.docx";
        public const string NombreReporteRPFFallaWord = "CumplimientoFallaRPF.docx";
        public const string NombreChartRPF = "ChartRPF.jpg";
        public const string NombreChartFallaRPF = "ChartFallaRPF.jpg";
        public const string NombreReporteRPFPotencia = "PotenciaMaximaRPF.xlsx";

        public const string AppExcel = "application/vnd.ms-excel";
        public const string AppWord = "application/vnd.ms-word";
        public const string AppPdf = "application/pdf";
        public const string AppCSV = "application/CSV";
        
        public const string PaginaLogin = "home/login";
        public const string PaginaAccesoDenegado = "home/autorizacion";
        public const string DefaultControler = "Home";
        public const string LoginAction = "Login";
        public const string DefaultAction = "default";
        public const string RutaCarga = "Uploads/";
        public const int IdAplicacion = 1;
        public const string SI = "S";
        public const string NO = "N";
        public const string TextoSI = "Si";
        public const string TextoNO = "No";
        public const string TextoNoRango = "No rango";
        public const string TextoFPIncorrecto = "P o F en 0";
        public const string TextoNoEnvio = "No envío";
        public const string TextoNoSospechoso = "No sospechoso";
        public const string TextoRSFA = "RSF - A";

        public const string FormatoWord = "WORD";
        public const string FormatoPDF = "PDF";

        public const char CaracterComa = ',';
        public const char CaracterAnd = '&';
        public const char CaracterArroba = '@';
             
        public const string Coma = ",";
        public const string AperturaSerie = "[";
        public const string CierreSerie = "]";
        public const string EspacioBlanco = " ";
        public const char CaracterGuion = '-';
        public const string CaracterPorcentaje = "%";
        public const string CaracterCero = "0";
        public const char CaracterDosPuntos = ':';

        public const string LogError = "INTRANET.COES";

        public const string NodoPrincipal = "Principal <span>/</span>";
        public const string SeparacionMapa = "<span>/</span>";
        public const string SufijoImagenUser = "@coes.org.pe.jpg";
        public const string UsuarioAnonimo = "usuario.anonimo";
        public const string ClaveAnonimo = "sgoCOES2014";
        public const string TextoCentral = "CENTRAL";
        public const string TextoMW = "MW";
        public const string ParametroDefecto = "-1";
        public const string Opero = "OPERÓ";
        public const string NoOpero = "NO OPERÓ";
        public const string Indeterminado = "INDETERMINADO";

        public const string NombreReporteMantenimiento = "RptMantenimiento.xlsx";
        public const string NombreReporteMantenimiento01 = "RptMantenimiento_01.xlsx";
        public const string NombreReporteMantenimiento02 = "RptMantenimiento_02.xlsx";
        public const string NombreReporteMantenimiento03 = "RptMantenimiento_03.xlsx";
        public const string NombreReporteMantenimiento04 = "RptMantenimiento_04.xlsx";
        public const string NombreReporteMantenimiento05 = "RptMantenimiento_05.xlsx";
        public const string NombreReporteMantenimiento06 = "RptMantenimiento_06.xlsx";
        public const string PlantillaExcelMantenimiento = "PlantillaMantenimiento.xlsx";
    }



    /// <summary>
    /// Constantes para los nombres de los parametros query string
    /// </summary>
    public class RequestParameter
    {
        public const string EventoId = "id";
        public const string Indicador = "ind";
        public const string PerfilId = "id";
    }

    /// <summary>
    /// Constantes para los datos de sesion
    /// </summary>
    public class DatosSesion
    {
        public const string SesionPerturbacion = "SesionPerturbacion";       
        public const string SesionUsuario = "SesionUsuario";
        public const string SesionIdOpcion = "SesionIdOpcion";
        public const string SesionOpciones = "SesionOpciones";
        public const string SesionIndPermiso = "SesionIndPermiso";
        public const string SesionNodo = "SesionNodo";
        public const string SesionPermiso = "SesionPermiso";
        public const string SesionEmpresa = "SesionEmpresa";
        public const string ListaFormulas = "ListaFormulas";
        public const string ListaScada = "ListaScada";
        public const string ListaTotal = "ListaTotal";
        public const string EntidadScada = "EntidadScada";
        public const string ListaGrabado = "ListaGrabado";
        public const string UltimoPerfil = "UltimoPerfil";
        public const string ListaServicio = "ListaServicio";
        public const string ListaEvaluacion = "ListaEvaluacion";
        public const string ListaConfiguracion = "ListaConfiguracion";
        public const string ListaRangoNoEncontrado = "ListaRangoNoEncontrado";
        public const string ListaNoCargaron = "ListaNoCargaron";
        public const string ListaNoIncluir = "ListaNoIncluir";
        public const string ListaPotencia = "ListaPotencia";
        public const string ListaGrafico = "ListaGrafico";
        public const string ListaDatosFalla = "ListaDatosFalla";
        public const string ListaFrecuenciaFalla = "ListaFrecuenciaFalla";
        public const string ListaFrecuenciaFallaTotal = "ListaFrecuenciaFallaTotal";
        public const string ListaPotenciaFalla = "ListaPotenciaFalla";
        public const string IndicadorEvaluacion = "IndicadorEvaluacion";
        public const string NumeroSegundos = "NumeroSegundos";
        public const string ListaPuntoFormula = "ListaPuntoFormula";
        public const string FechaProceso = "FechaProceso";
        public const string IndicadorFuente = "IndicadorFuente";
        public const string DatosImportados = "DatosImportados";
        public const string ListaGraficoMaximo = "ListaGraficoMaximo";
        public const string ListaGraficoMinimo = "ListaGraficoMinimo";
        public const string NombrePlantillaImportacion = "NombrePlantillaImportacion";
        public const string ListaIncorrecto = "ListaIncorrecto";
        public const string SesionMapa = "SesionMapa";
        public const string InicioSesion = "InicioSesion";
        public const string ListaFuenteEnergia = "ListaFuenteEnergia";
        public const string ReporteEmpresas = "ReporteEmpresas";
        public const string ListaTipoGeneracion = "ListaTipoGeneracion";
        public const string ListaReporteConsistencia = "ListaReporteConsistencia";
        public const string ListaManttoEmpresa = "ListaManttoEmpresa";
        public const string ListaManttosTotal = "ListaManttosTotal";
    }

    /// <summary>
    /// Contiene las rutas de los directorios utilizados
    /// </summary>
    public class RutaDirectorio 
    {
        public const string ReporteEvento = "ReporteEvento";
        public const string ReportePerfiles = "ReportePerfiles";
        public const string ReporteServicioRPF = "ReporteServicioRPF";
        public const string ReporteMediciones = "ReporteMediciones";
    }

    /// <summary>
    /// Contiene los nombres de propiedades de clases
    /// </summary>
    public class EntidadPropiedad
    {
        public const string PtoMediCodi = "PtoMediCodi";
        public const string PtoNomb = "PtoDescripcion";
        public const string Areacodi = "Areacodi";
        public const string AreaNomb = "AreaNomb";
        public const string EmprCodi = "EMPRCODI";
        public const string EmprNomb = "EMPRNOMB";
        public const string EquiCodi = "EquiCodi";
        public const string EquiNomb = "EquiNomb";
        public const string Emprcodi = "Emprcodi";
        public const string Emprnomb = "Emprnomb";
        public const string Tipoptomedicodi = "Tipoptomedicodi";
        public const string Tipoptomedinomb = "Tipoptomedinomb";
        

        
    }


    /// <summary>
    /// Contiene los nombres de los items del reporte de perturbacion
    /// </summary>
    public class TipoItemPerturbacion
    {
        public const string ItemFecha = "RP_FECHA";
        public const string ItemHora = "RP_HORA";
        public const string ItemEquipo = "RP_EQUIPO";
        public const string ItemEmpresa = "RP_EMPRESA";
        public const string ItemCausa = "RP_CAUSA";
        public const string ItemDescripcion = "RP_DESCRIPCION";
        public const string ItemSecuencia = "RP_SECUENCIA";
        public const string ItemActuacion = "RP_ACTUACION";
        public const string ItemAnalisis = "RP_ANALISIS";
        public const string ItemConclusion = "RP_CONCLUSION";
        public const string ItemRecomendacion = "RP_RECOMENDACION";
        public const string ItemOportunidad = "RP_OPORTUNIDAD";
        public const string ItemAcuerdo = "RP_ACUERDO";
        public const string ItemPlazo = "RP_PLAZO";
    }

    /// <summary>
    /// Contiene los nombres de los archivos
    /// </summary>
    public class NombreArchivo
    {
        public const string PlantillaGeneracionRERDiario = "PlantillaGeneracionRERDiario.xlsx";
        public const string PlantillaGeneracionRERSemanal = "PlantillaGeneracionRERSemanal.xlsx";
        public const string PlantillaConsistenciaRPF = "PlantillaConsistencia.xlsx";
        public const string ReporteGeneracionRER = "ReporteRER.xlsx";
        public const string ReporteCumplimientoRER = "CumplimientoRER.xlsx";
        public const string ReporteMedidoresHorizontal = "ReporteMedidores_Horizontal.xlsx";
        public const string ReporteMedidoresVertical = "ReporteMedidores_Vertical.xlsx";
        public const string ReporteMedidoresCSV = "ReporteMedidores.csv";
        public const string ReporteMedidoresGeneracion = "ReporteMedidoresGeneracion.xlsx";
        public const string ReporteConsistenciaRPF = "ReporteConsistenciaRPF.xlsx";
        public const string ReporteFrecuenciasRPF = "FrecuenciasRPF.xlsx";
        public const string PlantillaFrecuenciaRPF = "PlantillaFrecuencia.xlsx";
        public const string ReporteEvento = "Eventos.xlsx";
        public const string ReporteMaximaDemandaDiaria = "MaximaDemandaDiaria.xlsx";
        public const string ReporteMaxinaDemandaHFPHP = "MaximaDemandaHFPHP.xlsx";
        public const string ReporteRankingDemanda = "RankingDemanda.xlsx";
        public const string ReporteDuracionCarga = "DuracionCarga.xlsx";
        public const string ReporteConsolidoMensual = "ConsolidadoMensual.xlsx";
        public const string ReporteValidacionMedidores = "ValidacionDatos.xlsx";
    }

    public class TipoEventos
    {
        public const int EventoPruebas = 6;
    }

    public class PuntoMedicion
    {
        public const int CodRef = -1;
        public const int TipoInfoCodi = 0;
        public const string EstadoActivo = "A";
    }

}