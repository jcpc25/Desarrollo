﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Hidrologia.Helper
{
    public class Constantes
    {
        public const string FormatoFecha = "dd/MM/yyyy";
        public const string FormatoHora = "HH:mm:ss";
        public const string FormatoFechaHora = "dd/MM/yyyy HH:mm";
        public const int PageSize = 20;
        public const int NroPageShow = 10;

        public const string HojaReporteExcel = "REPORTE";
        public const string HojaFormatoExcel = "FORMATO";
        public const string NombreLogoCoes = "coes.png";
        public const string PlantillaExcelHidrologia = "PlantillaReporteHIDROLOGIA.xlsx";           
        public const string NombreRptGraficoHidrologia00 = "RptGraficoHidrologia_00.xlsx";
        public const string NombreRptGraficoHidrologia01 = "RptGraficoHidrologia_01.xlsx";
        public const string NombreReporteHidrologia00 = "RptHidrologia_00.xlsx";
        public const string NombreReporteHidrologia01 = "RptHidrologia_01.xlsx";
        public const string NombreReporteHidrologia02 = "RptHidrologia_02.xlsx";
        
        
        public const string AppExcel = "application/vnd.ms-excel";
        public const string AppWord = "application/vnd.ms-word";
        public const string AppPdf = "application/pdf";

        public const string PaginaLogin = "/WebForm/Account/Login.aspx";
        public const string PaginaAccesoDenegado = "home/autorizacion";
        public const string DefaultControler = "Home";
        public const string LoginAction = "Login";
        public const string DefaultAction = "default";
        public const int IdAplicacion = 10;
        public const string SI = "S";
        public const string NO = "N";

        public const string FormatoWord = "WORD";
        public const string FormatoPDF = "PDF";

        public const char CaracterComa = ',';
        public const string AperturaSerie = "[";
        public const string CierreSerie = "]";
        public const char CaracterCero = '0';

        public const string TextoCentral = "CENTRAL";
        public const string TextoMW = "MW";
        public const string CaracterH = "H";

        public const int EnPlazo = 3;
        public const int FueraPlazo = 5;
        public const int FormatoCodigo = 2;

        public const int EmpresaGeneradora = 3;
        public const int IdmModulo = 3;
    }

    /// <summary>
    /// Contiene las rutas de los directorios utilizados
    /// </summary>
    public class RutaDirectorio
    {
        public const string ReporteHidrologia = "ReporteHidrologia";
    }

    /// <summary>
    /// Constantes para los datos de sesion
    /// </summary>
    public class DatosSesion
    {
  
        public const string ListaFechas = "ListaFechas";        
        public const string modelGraficoMensual = "modelGraficoMensual";
        public const string modelGraficoDiario = "modelGraficoDiario";
        public const string modelGraficoSemanal = "modelGraficoSemanal";
    }
}