using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Helper;
using OfficeOpenXml;

namespace COES.MVC.Intranet.Areas.ServicioRPF.Helper
{
    /// <summary>
    /// Clase que permite exportar el reporte de cumplimiento servicio RPF
    /// </summary>
    public class ExcelDocument
    {
        /// <summary>
        /// Permite exportar los perfiles almacenados en base de datos
        /// </summary>
        /// <param name="list"></param>
        public static void GenerarReporteCarga(List<ServicioRpfDTO> list)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF].ToString();
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaExcel);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteCargaRPF);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteCargaRPF);
            }

            int row = 4;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                foreach (ServicioRpfDTO item in list)
                {
                    ws.Cells[row, 2].Value = (item.EMPRNOMB != null) ? item.EMPRNOMB : string.Empty;
                    ws.Cells[row, 3].Value = (item.EQUINOMB != null) ? item.EQUINOMB : string.Empty;
                    ws.Cells[row, 4].Value = (item.EQUIABREV != null) ? item.EQUIABREV : string.Empty;
                    ws.Cells[row, 5].Value = item.PTOMEDICODI.ToString();
                    ws.Cells[row, 6].Value = (item.INDICADOR != null) ? item.INDICADOR : string.Empty;

                    row++;
                }                                 
                   
                xlPackage.Save();
            }
        }

        /// <summary>
        /// Permite elaborar el reporte de consistencia de datos
        /// </summary>
        /// <param name="list"></param>
        public static void GenerarReporteConsistencia(List<ServicioRpfDTO> list, DateTime fecha) 
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF].ToString();
            FileInfo template = new FileInfo(ruta + NombreArchivo.PlantillaConsistenciaRPF);
            FileInfo newFile = new FileInfo(ruta + NombreArchivo.ReporteConsistenciaRPF);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + NombreArchivo.ReporteConsistenciaRPF);
            }
            
            int row = 5;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                ws.Cells[2, 3].Value = fecha.ToString(Constantes.FormatoFecha);

                foreach (ServicioRpfDTO item in list)
                {
                    ws.Cells[row, 2].Value = (item.EMPRNOMB != null) ? item.EMPRNOMB : string.Empty;
                    ws.Cells[row, 3].Value = (item.EQUINOMB != null) ? item.EQUINOMB : string.Empty;
                    ws.Cells[row, 4].Value = (item.EQUIABREV != null) ? item.EQUIABREV : string.Empty;
                    ws.Cells[row, 5].Value = (item.FechaCarga != null) ? item.FechaCarga : string.Empty;
                    ws.Cells[row, 6].Value = item.Consistencia.ToString();
                    ws.Cells[row, 7].Value = (item.EstadoOperativo != null) ? item.EstadoOperativo : string.Empty;
                    ws.Cells[row, 8].Value = (item.EstadoInformacion != null) ? item.EstadoInformacion : string.Empty;

                    row++;
                }

                xlPackage.Save();
            }
        }

        /// <summary>
        /// Permite generar el formato de potencias máximas
        /// </summary>
        /// <param name="list"></param>
        public static void GenerarReportePotencia(List<ServicioRpfDTO> list)
        { 
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF].ToString();
            
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaPotencia);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteRPFPotencia);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteRPFPotencia);
            }

            int row = 4;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                foreach (ServicioRpfDTO item in list)
                {
                    ws.Cells[row, 2].Value = (item.EMPRNOMB != null) ? item.EMPRNOMB : string.Empty;
                    ws.Cells[row, 3].Value = (item.EQUINOMB != null) ? item.EQUINOMB : string.Empty;
                    ws.Cells[row, 4].Value = (item.EQUIABREV != null) ? item.EQUIABREV : string.Empty;
                    ws.Cells[row, 5].Value = item.PTOMEDICODI.ToString();
                    ws.Cells[row, 6].Value = (item.POTENCIAMAX != null) ? item.POTENCIAMAX.ToString(Constantes.FormatoDecimal) : string.Empty;

                    row++;
                }

                xlPackage.Save();
            }

        }


        /// <summary>
        /// Permite generar el reporte de cumplimiento de la evaluacion RPF
        /// </summary>
        /// <param name="list"></param>
        public static void GenerarReporteCumplimiento(List<ServicioRpfDTO> list)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF].ToString();
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaCumplimiento);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteCumplimientoRPF);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteCumplimientoRPF);
            }

            int row = 4;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                foreach (ServicioRpfDTO item in list)
                {
                    ws.Cells[row, 2].Value = (item.EMPRNOMB != null) ? item.EMPRNOMB : string.Empty;
                    ws.Cells[row, 3].Value = (item.EQUINOMB != null) ? item.EQUINOMB : string.Empty;
                    ws.Cells[row, 4].Value = (item.EQUIABREV != null) ? item.EQUIABREV : string.Empty;
                    ws.Cells[row, 5].Value = item.PTOMEDICODI.ToString();
                    ws.Cells[row, 6].Value = (item.HORAINICIO != null) ? item.HORAINICIO : string.Empty;
                    ws.Cells[row, 7].Value = (item.HORAFIN != null) ? item.HORAFIN : string.Empty;
                    ws.Cells[row, 8].Value = item.PORCENTAJE.ToString(Constantes.FormatoNumero) + Constantes.CaracterPorcentaje;
                    ws.Cells[row, 9].Value = (item.INDCUMPLIMIENTO != null) ? item.INDCUMPLIMIENTO : string.Empty;
                    
                    row++;
                }

                xlPackage.Save();
            }
        }

        /// <summary>
        /// Permite generar el reporte de cumplimiento de la evaluacion RPF
        /// </summary>
        /// <param name="list"></param>
        public static void GenerarReporteCumplimientoFalla(List<ServicioRpfDTO> list)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF].ToString();
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaCumplimientoFalla);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteCumplimientoRPFFalla);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteCumplimientoRPFFalla);
            }

            int row = 4;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                foreach (ServicioRpfDTO item in list)
                {
                    ws.Cells[row, 2].Value = (item.EMPRNOMB != null) ? item.EMPRNOMB : string.Empty;
                    ws.Cells[row, 3].Value = (item.EQUINOMB != null) ? item.EQUINOMB : string.Empty;
                    ws.Cells[row, 4].Value = (item.EQUIABREV != null) ? item.EQUIABREV : string.Empty;
                    ws.Cells[row, 5].Value = item.PTOMEDICODI.ToString();                   
                    ws.Cells[row, 6].Value = item.PORCENTAJE.ToString(Constantes.FormatoNumero) + Constantes.CaracterPorcentaje;
                    ws.Cells[row, 7].Value = (item.INDCUMPLIMIENTO != null) ? item.INDCUMPLIMIENTO : string.Empty;

                    row++;
                }

                xlPackage.Save();
            }
        }

        /// <summary>
        /// Permite generar el archivo con los datos de las frecuencias
        /// </summary>
        /// <param name="list"></param>
        public static void GenerarArchivoFrecuencias(List<ServicioGps> list)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF].ToString();
            FileInfo template = new FileInfo(ruta + NombreArchivo.PlantillaFrecuenciaRPF);
            FileInfo newFile = new FileInfo(ruta + NombreArchivo.ReporteFrecuenciasRPF);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + NombreArchivo.ReporteFrecuenciasRPF);
            }

            int row = 4;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                if (list.Count > 0)
                {
                    ws.Cells[1, 2].Value = list[0].Fecha.ToString(Constantes.FormatoFecha);
                }

                foreach (ServicioGps item in list)
                {
                    ws.Cells[row, 1].Value = item.Fecha.ToString(Constantes.FormatoHora);
                    ws.Cells[row, 2].Value = item.Frecuencia;
                    row++;
                }

                xlPackage.Save();
            }
        }
    }
}