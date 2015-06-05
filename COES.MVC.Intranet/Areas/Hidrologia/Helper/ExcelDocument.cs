using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using COES.MVC.Intranet.Helper;
using OfficeOpenXml;
using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Areas.Hidrologia.Models;
using OfficeOpenXml.Style;
using System.Drawing;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using System.Globalization;
using COES.Servicios.Aplicacion.Hidrologia;

namespace COES.MVC.Intranet.Areas.Hidrologia.Helper
{
    public class ExcelDocument
    {
        /// <summary>
        /// Permite exportar los perfiles almacenados en base de datos
        /// </summary>
        /// <param name="list"></param>
        ///         
        private static void AddImage(ExcelWorksheet ws, int columnIndex, int rowIndex, string filePath)
        {
            //How to Add a Image using EP Plus
            Bitmap image = new Bitmap(filePath);

            ExcelPicture picture = null;
            if (image != null)
            {
                picture = ws.Drawings.AddPicture("pic" + rowIndex.ToString() + columnIndex.ToString(), image);
                picture.From.Column = columnIndex;
                picture.From.Row = rowIndex;
                picture.From.ColumnOff = ExcelHelper.Pixel2MTU(1); //Two pixel space for better alignment
                picture.From.RowOff = ExcelHelper.Pixel2MTU(1);//Two pixel space for better alignment
                picture.SetSize(120,40);

            }
        }

        public static void ConfiguraEncabezadoHojaExcel(ExcelWorksheet ws, string titulo, string fInicio, string fFin)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();

            AddImage(ws, 1, 0, ruta + Constantes.NombreLogoCoes);
            ws.Cells[1, 3].Value = titulo;
            var font = ws.Cells[1, 3].Style.Font;
            font.Size = 16;
            font.Bold = true;
            font.Name = "Calibri";
            //Borde, font cabecera de Tabla Fecha
            var borderFecha = ws.Cells[3, 2, 4, 3].Style.Border;
            borderFecha.Bottom.Style = borderFecha.Top.Style = borderFecha.Left.Style = borderFecha.Right.Style = ExcelBorderStyle.Thin;
            var fontTabla = ws.Cells[3, 2, 4, 3].Style.Font;
            fontTabla.Size = 8;
            fontTabla.Name = "Calibri";
            fontTabla.Bold = true;
            ws.Cells[3, 2].Value = "Fecha Inicio:";
            ws.Cells[4, 2].Value = "Fecha Fin:";
            ws.Cells[3, 3].Value = fInicio;
            ws.Cells[4, 3].Value = fFin;           
        }

        public static void ConfiguraEncabezadoHojaExcel2(ExcelWorksheet ws, string titulo)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();

            AddImage(ws, 1, 0, ruta + Constantes.NombreLogoCoes);
            ws.Cells[1, 4].Value = titulo;
            var font = ws.Cells[1, 4].Style.Font;
            font.Size = 16;
            font.Bold = true;
            font.Name = "Calibri";
            var fontTabla = ws.Cells[3, 2, 3, 3].Style.Font;
            fontTabla.Size = 8;
            fontTabla.Name = "Calibri";
            fontTabla.Bold = true;
            ws.Cells[3, 2].Value = "FECHA:";
            ws.Cells[3, 3].Value = DateTime.Now.ToString(Constantes.FormatoFechaHora);
        }
        
        public static void AddGraficoLineas(ExcelWorksheet ws, int row, int col)
        {
            var LineaChart = ws.Drawings.AddChart("crtExtensionsSize", eChartType.Line);
            //Set top left corner to row 1 column 2
            LineaChart.SetPosition(5, 0, col+3, 0);
            LineaChart.SetSize(800, 600);

            var ran1 = ws.Cells[7,3,row+7,3];
            var ran2 = ws.Cells["0:0"];

            var serie1 = (ExcelChartSerie)LineaChart.Series.Add(ran1, ran2);
            serie1.Header = ws.Cells[6,3].Value.ToString();

            ran1 = ws.Cells[7,4, row+7,4];
            var serie2 = LineaChart.Series.Add(ran1, ran2);
            serie2.Header = ws.Cells[6,4].Value.ToString();

            ran1 = ws.Cells[7, 5,row+7,5];
            var serie3 = LineaChart.Series.Add(ran1, ran2);
            serie3.Header = ws.Cells[6, 5].Value.ToString();

            LineaChart.Title.Text = "GRAFICO - PROGRAMADO MENSUAL - QN";       
            //Set datalabels and remove the legend
            //LineaChart.DataLabel.ShowCategory = true;
            //pieChart.DataLabel.ShowPercent = true;
            //pieChart.DataLabel.ShowLeaderLines = true;
            //colChart.Legend.Remove();
            
            var xml = LineaChart.ChartXml;
            var lst = xml.GetElementsByTagName("c:lineChart");
            foreach (System.Xml.XmlNode item in lst[0].ChildNodes) {
                if (item.Name.Equals("ser")) {
                    foreach (System.Xml.XmlNode subitem in item.ChildNodes) {
                        if (subitem.Name.Equals("c:cat")) {
                            item.RemoveChild(subitem);
                            break;
                        }
                    }
                }
            }

        }
        
        public static void AddGraficoPie(ExcelWorksheet ws, int row)
        {
            var pieChart = ws.Drawings.AddChart("crtExtensionsSize", eChartType.PieExploded3D) as ExcelPieChart;
            //Set top left corner to row 1 column 2
            pieChart.SetPosition(3, 0, 4, 0);
            pieChart.SetSize(800, 600);
            pieChart.Series.Add(ExcelRange.GetAddress(5, 3, row, 3), ExcelRange.GetAddress(5, 2, row, 2));

            //pieChart.Title.Text = "Mantenimientos Ejecutados";
            //Set datalabels and remove the legend
            pieChart.DataLabel.ShowCategory = true;
            pieChart.DataLabel.ShowPercent = true;
            pieChart.DataLabel.ShowLeaderLines = true;
            pieChart.Legend.Remove();
        }

        public static void AddGraficoColumn(ExcelWorksheet ws, int rows, int ncol)
        {
            var colChart = ws.Drawings.AddChart("crtExtensionsSize", eChartType.ColumnStacked);
            //Set top left corner to row 1 column 2
            colChart.SetPosition(6 + rows, 0, 1, 0);
            colChart.SetSize(1000, 400);
            List<ExcelChartSerie> series = new List<ExcelChartSerie>();
            for (var i = 0; i < rows; i++)
            {

                series.Add(colChart.Series.Add(ExcelRange.GetAddress(5 + i, 3, 5 + i, 3 + ncol), ExcelRange.GetAddress(4, 3, 4, 3 + ncol)));
                series[i].Header = ws.Cells[5 + i, 2].Value.ToString();

            }
            //pieChart.Title.Text = "Mantenimientos Ejecutados";
            //Set datalabels and remove the legend
            //pieChart.DataLabel.ShowCategory = true;
            //pieChart.DataLabel.ShowPercent = true;
            //pieChart.DataLabel.ShowLeaderLines = true;
            //colChart.Legend.Remove();
        }

        public static void AddGraficoBar(ExcelWorksheet ws, int rows, int ncol)
        {
            var colChart = ws.Drawings.AddChart("crtExtensionsSize", eChartType.BarStacked);
            //Set top left corner to row 1 column 2
            colChart.SetPosition(6 + rows, 0, 1, 0);
            colChart.SetSize(1000, 400);
            List<ExcelChartSerie> series = new List<ExcelChartSerie>();
            for (var i = 0; i < rows; i++)
            {

                series.Add(colChart.Series.Add(ExcelRange.GetAddress(5 + i, 3, 5 + i, 3 + ncol), ExcelRange.GetAddress(4, 3, 4, 3 + ncol)));
                series[i].Header = ws.Cells[5 + i, 2].Value.ToString();

            }
            //pieChart.Title.Text = "Mantenimientos Ejecutados";
            //Set datalabels and remove the legend
            //pieChart.DataLabel.ShowCategory = true;
            //pieChart.DataLabel.ShowPercent = true;
            //pieChart.DataLabel.ShowLeaderLines = true;
            //colChart.Legend.Remove();
        }

        public static void ConfiguracionHojaExcel(ExcelWorksheet ws, List<MeMedicion1DTO> listaCabecera)
        {

            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();
            int ncol = listaCabecera.Count;          
            var fill = ws.Cells[7, 2, 7, ncol + 2].Style; 
            fill.Fill.PatternType = ExcelFillStyle.Solid;
            fill.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            fill.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
            fill.Border.Bottom.Style = fill.Border.Top.Style = fill.Border.Left.Style = fill.Border.Right.Style = ExcelBorderStyle.Thin;
            var border = ws.Cells[7, 2, 7, ncol + 2].Style.Border;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

            using (ExcelRange r = ws.Cells[6, 2, 6, ncol + 2])
            {
                //r.Merge = true;
                //r.Style.Font.SetFromFont(new Font("Arial", 22, FontStyle.Italic));
                r.Style.Font.Color.SetColor(Color.White);
                r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
            }

            ws.Cells[6, 2].Value = "AFLUENTES"; ws.Cells[7, 2].Value = "AÑO - MES";
            int col = 3;
            ws.Column(1).Width = 5;
            ws.Column(2).Width = 20;
            foreach (var reg in listaCabecera)
            {
                ws.Cells[6, col].Value = reg.Ptomedinomb;
                ws.Cells[7, col].Value = reg.Tipoinfoabrev;
                ws.Column(col).Width = 20;
                col++;
            }

        }

        public static void ConfiguracionHojaExcel2(ExcelWorksheet ws, List<MeMedicion24DTO> lista)
        {
            NumberFormatInfo nfi = GenerarNumberFormatInfo2();
            //string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();
            int ncol = lista.Count;
            var fill = ws.Cells[8, 3, 8, ncol + 2].Style;
            fill.Fill.PatternType = ExcelFillStyle.Solid;
            fill.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            fill.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
            fill.Border.Bottom.Style = fill.Border.Top.Style = fill.Border.Left.Style = fill.Border.Right.Style = ExcelBorderStyle.Thin;
            var border = ws.Cells[8, 3, 8   , ncol + 2].Style.Border;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

            using (ExcelRange r = ws.Cells[6, 2, 7, ncol + 2])
            {
                //r.Merge = true;
                //r.Style.Font.SetFromFont(new Font("Arial", 22, FontStyle.Italic));
                r.Style.Font.Color.SetColor(Color.White);
                r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
            }

            ws.Cells[6, 2].Value = "RECURSO"; ws.Cells[7, 2, 8, 2].Value = "FECHA";
            int col = 3;
            ws.Column(1).Width = 5;
            ws.Column(2).Width = 20;
            foreach (var reg in lista)
            {
                ws.Cells[6, col].Value = reg.Equinomb;
                ws.Cells[7, col].Value = reg.Tipoptomedinomb;
                ws.Cells[8, col].Value = reg.Tipoinfoabrev;
                ws.Cells[9, col].Value = reg.Medifecha.ToString("dd/MM/yyyy");
                ws.Column(col).Width = 20;
                col++;
            }

            int formatHorizonte = 1;
            int nBloques = 24;
            int row = 10;
            int column = 3;
            if (lista.Count > 0)
            {
                for (int i = 0; i < formatHorizonte; i++)
                    for (int k = 1; k <= nBloques; k++)
                    {
                        //var fechaMin = ((fechaInicio.AddMinutes(k * resolucion + i * 60 * 24))).ToString(ConstantesBase.FormatoFechaHora);
                        //strHtml.Append("<tr>");
                        //strHtml.Append(string.Format("<td>{0}</td>", fechaMin));
                        int z = 0;
                        foreach (var p in lista)
                        {
                            decimal valor = (decimal)p.GetType().GetProperty("H" + k).GetValue(p, null);
                            ws.Cells[row+k-1, column+z].Value = string.Format("{0}", valor.ToString("N", nfi));
                            z++;
                        }
                   
                    }

            }
            else
            {
                //strHtml.Append("<td  style='text-align:center'>No existen registros.</td>");
            }

            for (var j = 0; j <= (nBloques - 1); j++)
            {
                string hora = ("0" + j.ToString()).Substring(("0" + j.ToString()).Length - 2, 2) + ":00";
                ws.Cells[row+j, 2].Value = hora;

            }

        }

        public static void ConfiguracionHojaExcel3(ExcelWorksheet ws, List<MeMedicion1DTO> lista)
        {
            NumberFormatInfo nfi = GenerarNumberFormatInfo2();
            List<MeMedicion1DTO> listaCabecera = lista.GroupBy(x => new { x.Ptomedicodi, x.Ptomedinomb, x.Tipoinfoabrev })
                     .Select(y => new MeMedicion1DTO()
                     {
                         Ptomedicodi = y.Key.Ptomedicodi,
                         Ptomedinomb = y.Key.Ptomedinomb,
                         Tipoinfoabrev = y.Key.Tipoinfoabrev
                     }
                     ).ToList();
            int ncol = listaCabecera.Count;                        
            var fill = ws.Cells[7, 2, 7, ncol + 3].Style;
            fill.Fill.PatternType = ExcelFillStyle.Solid;
            fill.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            fill.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
            fill.Border.Bottom.Style = fill.Border.Top.Style = fill.Border.Left.Style = fill.Border.Right.Style = ExcelBorderStyle.Thin;
            var border = ws.Cells[7, 2, 7, ncol + 3].Style.Border;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
            

            using (ExcelRange r = ws.Cells[6, 2, 6, ncol + 3])
            {
                //r.Merge = true;
                //r.Style.Font.SetFromFont(new Font("Arial", 22, FontStyle.Italic));
                r.Style.Font.Color.SetColor(Color.White);
                r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
            }

            ws.Cells[6, 3].Value = "AFLUENTES"; ws.Cells[7, 2].Value = "AÑO"; ws.Cells[7, 3].Value = "SEMANA";
            int col = 4;
            ws.Column(1).Width = 5;
            ws.Column(2).Width = 20;
            foreach (var reg in listaCabecera)
            {
                ws.Cells[6, col].Value = reg.Ptomedinomb;
                ws.Cells[7, col].Value = reg.Tipoinfoabrev;
                ws.Column(col).Width = 20;
                col++;
            }
            int row = 8;
            int column = 2;

            DateTime fechaInicio = lista.Min(x => x.Medifecha);
            int nSem = COES.Base.Tools.Util.GenerarNroSemana(fechaInicio);
            if (lista.Count > 0)
            {
                DateTime fant = new DateTime();
                DateTime f = new DateTime();
                foreach (var reg in lista)
                {
                    f = reg.Medifecha;
                    if (f != fant)
                    {
                        var anho = f.Year.ToString();
                        var mes = f.Month;
                        ws.Cells[row, column].Value = anho;
                        ws.Cells[row, column + 1].Value = nSem;
                        ++nSem;
                        int z = 1;
                        foreach (var p in listaCabecera)
                        {
                            var reg2 = lista.Find(x => x.Medifecha == f && x.Ptomedicodi == p.Ptomedicodi);
                            if (reg2 != null)
                            {
                                decimal valor = (decimal)reg2.H1;
                                ws.Cells[row, column + 1 + z].Value = string.Format("{0}", valor.ToString("N", nfi));
                                z++;
                            }
                            else
                            {
                                ws.Cells[row, column + z+1].Value = "";
                                z++;
                            }
                        }
                        z--;
                        border = ws.Cells[row, 2, row, 3 + z].Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        var fontTabla = ws.Cells[row, 2, row, 3 + z].Style.Font;
                        fontTabla.Size = 8;
                        fontTabla.Name = "Calibri";
                        row++;
                    }
                    fant = f;
                }
            }

        }

        public static void AplicarFormatoFila(ExcelWorksheet ws, int row, int col, int ncol)
        {
            var border = ws.Cells[row, col, row, col + ncol].Style.Border;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
            var fontTabla = ws.Cells[row, col, row, col + ncol].Style.Font;
            fontTabla.Size = 8;
            fontTabla.Name = "Calibri";
            fontTabla.Color.SetColor(Color.FromArgb(51, 102, 255));

        }

        //Genera archivo excel de reporte DIARIO - Q TURB. VERT.
        public static void GenerarArchivoHidrologiaDiario(HidrologiaModel model)
        {

            List<MeMedicion24DTO> list = model.ListaMedicion24;
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaExcelHidrologia);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteHidrologia01);
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteHidrologia01);
            }
            //int row = 10;
            //int column = 2;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = null;
                ws = xlPackage.Workbook.Worksheets.Add("DIARIO-QTV");
                ws = xlPackage.Workbook.Worksheets["DIARIO-QTV"];
                string titulo = "REPORTE DE PROGRAMADO DIARIO - Q TURB. VERT.";
                ConfiguraEncabezadoHojaExcel(ws, titulo, model.FechaInicio, model.FechaFin);
                ConfiguracionHojaExcel2(ws, list);
                xlPackage.Save();
            }

        }
        
        //Genera archivo excel de reporte mensual QN
        public static void GenerarArchivoHidrologiaMesQN(HidrologiaModel model)
        {
            NumberFormatInfo nfi = GenerarNumberFormatInfo2();                
            List<MeMedicion1DTO> list = model.ListaMedicion1;
            List<MeMedicion1DTO> listaCabecera = list.GroupBy(x => new { x.Ptomedicodi, x.Ptomedinomb, x.Tipoinfoabrev })
                     .Select(y => new MeMedicion1DTO()
                     {
                         Ptomedicodi = y.Key.Ptomedicodi,
                         Ptomedinomb = y.Key.Ptomedinomb,
                         Tipoinfoabrev = y.Key.Tipoinfoabrev
                     }
                     ).ToList();
            int nrow = listaCabecera.Count;

            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaExcelHidrologia);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteHidrologia00);
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteHidrologia00);
            }
            int row = 8;
            int column = 2;           
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = null;
                ws = xlPackage.Workbook.Worksheets.Add("MENSUAL-QN");
                ws = xlPackage.Workbook.Worksheets["MENSUAL-QN"];
                string titulo = "REPORTE DE PROGRAMADO MENSUAL - QN";
                ConfiguraEncabezadoHojaExcel(ws, titulo,model.FechaInicio, model.FechaFin);                              
                ConfiguracionHojaExcel(ws, listaCabecera);

                if (list.Count > 0)
                {
                    DateTime fant = new DateTime();
                    DateTime f = new DateTime();
                    foreach (var reg in list)
                    {
                        f = reg.Medifecha;
                        if (f != fant)
                        {
                            var anho = f.Year.ToString();
                            var mes = f.Month;
                            ws.Cells[row, column].Value = anho + " - " + COES.Base.Tools.Util.ObtenerNombreMes(mes);
                            int z = 1;
                            foreach (var p in listaCabecera)
                            {
                                var reg2 = list.Find(x => x.Medifecha == f && x.Ptomedicodi == p.Ptomedicodi);
                                if (reg2 != null)
                                {
                                    decimal valor = (decimal)reg2.H1;
                                    ws.Cells[row, column + z].Value = string.Format("{0}", valor.ToString("N", nfi));
                                    z++;
                                }
                                else
                                {
                                    ws.Cells[row, column + z].Value = "";
                                    z++;
                                }
                            }
                            z--;
                            var border = ws.Cells[row, 2, row, 2 + z].Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                            var fontTabla = ws.Cells[row, 2, row, 2 + z].Style.Font;
                            fontTabla.Size = 8;
                            fontTabla.Name = "Calibri";
                            row++;
                        }
                        fant = f;
                    }

                    xlPackage.Save();
                }
            }

        }

        //Genera archivo excel de reporte semanal QN
        public static void GenerarArchivoHidrologiaSemanal(HidrologiaModel model)
        {           
            List<MeMedicion1DTO> list = model.ListaMedicion1;            
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaExcelHidrologia);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteHidrologia02);
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteHidrologia02);
            }
           
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = null;
                ws = xlPackage.Workbook.Worksheets.Add("SEMANAL-QN");
                ws = xlPackage.Workbook.Worksheets["SEMANAL-QN"];
                string titulo = "REPORTE DE PROGRAMADO SEMANAL - QN";
                ConfiguraEncabezadoHojaExcel(ws, titulo, model.FechaInicio, model.FechaFin);
                ConfiguracionHojaExcel3(ws, list);                
                xlPackage.Save();
            }

        }

        //genera archivo de grafico Programado Mensual Q Turb. Vert.
        public static void GenerarArchivoGrafDiario(HidrologiaModel model)
        {

            List<String> listCategoriaGrafico = model.ListaCategoriaGrafico; // Lista de horas ordenados para la categoria del grafico
            List<String> listSerieName = model.ListaSerieName; //Lista de nombres de las series del grafico(Ptos de medicion)
            decimal?[][] listSerieData = model.ListaSerieData; // lista de valores para las series del grafico



            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreRptGraficoHidrologia01);
            int nfil = listCategoriaGrafico.Count;
            int ncol = listSerieName.Count;
            int row = 7;
            string titulo = "";

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreRptGraficoHidrologia01);
            }

            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = null;
                ws = xlPackage.Workbook.Worksheets.Add("GRAF-DIARIO");
                ws = xlPackage.Workbook.Worksheets["GRAF-DIARIO"];

                titulo = "GRAFICO - PROGRAMADO DIARIO - Q TURB. VERT. ";
                ConfiguraEncabezadoHojaExcel(ws, titulo, model.FechaInicio, model.FechaFin);
                ws.Column(1).Width = 5;
                ws.Column(2).Width = 20;
                ws.Cells[row - 1, 2].Value = "FECHA";
                for (int i = 0; i < ncol; i++)
                {
                    ws.Cells[row - 1, i + 3].Value = listSerieName[i];
                }
                for (int i = 0; i < nfil; i++)
                {
                    ws.Cells[row + i, 2].Value = listCategoriaGrafico[i];
                }

                //Borde cabecera de Tabla Listado
                var border = ws.Cells[row - 1, 2, row - 1, ncol + 2].Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                using (ExcelRange r = ws.Cells[row - 1, 2, row - 1, ncol + 2])
                {
                    r.Style.Font.Color.SetColor(Color.White);
                    r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));

                }
                for (int i = 0; i < ncol; i++) //inserta los datos 
                    for (int j = 0; j < nfil; j++)
                    {
                        ws.Cells[j + 7, i + 3].Value = listSerieData[i][j];
                    }
                // borde de region de datos
                var borderReg = ws.Cells[row, 2, row + nfil - 1, ncol + 2].Style.Border;
                borderReg.Bottom.Style = borderReg.Top.Style = border.Left.Style = borderReg.Right.Style = ExcelBorderStyle.Thin;
                var fontTabla = ws.Cells[row, 2, row + nfil - 1, ncol + 2].Style.Font;
                fontTabla.Size = 8;
                fontTabla.Name = "Calibri";
                AddGraficoLineas(ws, nfil, ncol);
                xlPackage.Save();
            }

        }
        
        //genera archivo de grafico Programado Mensual QN
        public static void GenerarArchivoGrafMensualQN(HidrologiaModel model)
        {
            List<String> listCategoriaGrafico = model.ListaCategoriaGrafico; // Lista de Anho y Mes ordenados para la categoria del grafico
            List<String> listSerieName = new List<String>(); //Lista de nombres de las series del grafico(Ptos de medicion)
            decimal?[][] listSerieData = model.ListaSerieData; // lista de valores para las series del grafico
            
            // Obtener Lista de nombres de las series del grafico.
            var listaGrupoMedicion = model.ListaMedicion1.GroupBy(x => x.Ptomedicodi).Select(group => group.First()).ToList();
            int z=0;
            foreach (var reg in listaGrupoMedicion)
            {         
                listSerieName.Add(reg.Ptomedinomb);
                z++;
            }
            
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreRptGraficoHidrologia00);
            int nfil = listCategoriaGrafico.Count;
            int ncol = listSerieName.Count;
            int row = 7;           
            string titulo = "";

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreRptGraficoHidrologia00);
            }

            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = null;
                 ws = xlPackage.Workbook.Worksheets.Add("GRAF-MENSUAL-QN");
                 ws = xlPackage.Workbook.Worksheets["GRAF-MENSUAL-QN"];
                 
                 titulo = "GRAFICO - PROGRAMADO MENSUAL - QN ";
                        ConfiguraEncabezadoHojaExcel(ws, titulo, model.FechaInicio, model.FechaFin);                     
                        ws.Column(1).Width = 5;
                        ws.Column(2).Width = 20;                        
                        ws.Cells[row - 1, 2].Value = "AFLUENTES";
                        for (int i=0 ; i<ncol; i++){
                            ws.Cells[row - 1, i+3].Value = listSerieName[i];
                        }
                        for (int i = 0; i < nfil; i++)
                        {
                            ws.Cells[row + i, 2].Value = listCategoriaGrafico[i];
                        }

                        //Borde cabecera de Tabla Listado
                        var border = ws.Cells[row - 1, 2, row - 1, ncol+2].Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        using (ExcelRange r = ws.Cells[row - 1, 2, row - 1, ncol+2])
                        {
                            r.Style.Font.Color.SetColor(Color.White);
                            r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));

                        }
                        for (int i = 0; i<ncol; i++ ) //inserta los datos 
                            for (int j = 0; j<nfil ; j++){
                                ws.Cells[j+7, i+3].Value = listSerieData[i][j];
                            }  
                        // borde de region de datos
                        var borderReg = ws.Cells[row, 2, row + nfil-1, ncol+2].Style.Border;
                        borderReg.Bottom.Style = borderReg.Top.Style = border.Left.Style = borderReg.Right.Style = ExcelBorderStyle.Thin;
                        var fontTabla = ws.Cells[row, 2, row + nfil - 1, ncol + 2].Style.Font;
                        fontTabla.Size = 8;
                        fontTabla.Name = "Calibri";
                AddGraficoLineas(ws, nfil, ncol);
                xlPackage.Save();
            }
        }// ********************

        public  static NumberFormatInfo GenerarNumberFormatInfo2()
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalDigits = 3;
            nfi.NumberDecimalSeparator = ",";
            return nfi;
        }

    }
}