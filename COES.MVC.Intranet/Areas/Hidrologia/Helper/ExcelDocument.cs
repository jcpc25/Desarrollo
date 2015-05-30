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

namespace COES.MVC.Intranet.Areas.Hidrologia.Helper
{
    public class ExcelDocument
    {
        /// <summary>
        /// Permite exportar los perfiles almacenados en base de datos
        /// </summary>
        /// <param name="list"></param>

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

        public static void ConfiguraEncabezadoHojaExcel(ExcelWorksheet ws, string titulo)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia].ToString();

            AddImage(ws, 1, 0, ruta + Constantes.NombreLogoCoes);
            ws.Cells[1, 3].Value = titulo;
            var font = ws.Cells[1, 3].Style.Font;
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

            //LineaChart.Series.Add(ExcelRange.GetAddress(5, 3, row, 3), ExcelRange.GetAddress(5, 2, row, 2));

            //pieChart.Title.Text = "Mantenimientos Ejecutados";
            //Set datalabels and remove the legend
            //LineaChart.DataLabel.ShowCategory = true;
            //LineaChart.DataLabel.ShowPercent = true;
            //LineaChart.DataLabel.ShowLeaderLines = true;
            //LineaChart.Legend.Remove();


            //ExcelChart ec = (ExcelLineChart)chartSheet.Drawings.AddChart("chart_1",      eChartType.Line);
            //ec.SetPosition(1, 0, 3, 0);
            //ec.SetSize(800, 300);
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
            AddImage(ws, 1, 0, ruta + Constantes.NombreLogoCoes);

            var fill = ws.Cells[5, 2, 5, ncol + 2].Style; 
            fill.Fill.PatternType = ExcelFillStyle.Solid;
            fill.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            fill.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
            fill.Border.Bottom.Style = fill.Border.Top.Style = fill.Border.Left.Style = fill.Border.Right.Style = ExcelBorderStyle.Thin;

            var border = ws.Cells[4, 2, 4, ncol + 2].Style.Border;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

           // ws.Cells[4, 2, 4, ncol + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            using (ExcelRange r = ws.Cells["B4:E4"])
            {
                //r.Merge = true;
                //r.Style.Font.SetFromFont(new Font("Arial", 22, FontStyle.Italic));
                r.Style.Font.Color.SetColor(Color.White);
                r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
            }

            ws.Cells[4, 2].Value = "AFLUENTES"; ws.Cells[5, 2].Value = "AÑO - MES";
            int col = 3;
            ////ws.Row(1).Height = 30;
            //ws.Row(2).Height = 10;
            ws.Column(1).Width = 5;
            ws.Column(2).Width = 20;
            foreach (var reg in listaCabecera)
            {
                ws.Cells[4, col].Value = reg.Ptomedinomb;
                ws.Cells[5, col].Value = reg.Tipoinfoabrev;
                ws.Column(col).Width = 20;
                col++;
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

        //Genera archivo excel de reporte mensual QN
        public static void GenerarArchivoHidrologiaMesQN(HidrologiaModel model)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalDigits = 3;
            nfi.NumberDecimalSeparator = ",";
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
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteHidrologia);
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteHidrologia);
            }
            int row = 6;
            int column = 2;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = null;
                ws = xlPackage.Workbook.Worksheets.Add("MENSUAL-QN");
                ws = xlPackage.Workbook.Worksheets["MENSUAL-QN"];
                ws.Cells[1, 3].Value = "REPORTE DE PROGRAMADO MENSUAL - QN";
                ws.Cells[3, 2].Value = "FECHA:";
                ws.Cells[3, 3].Value = DateTime.Now.ToString(Constantes.FormatoFechaHora);
                var font = ws.Cells[1, 3].Style.Font;
                font.Size = 16;
                font.Bold = true;
                font.Name = "Calibri";
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
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreArchivoGrafMensualQN);
            int nfil = listCategoriaGrafico.Count;
            int ncol = listSerieName.Count;
            int row = 7;           
            string titulo = "";

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreArchivoGrafMensualQN);
            }

            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = null;
                 ws = xlPackage.Workbook.Worksheets.Add("GRAF-MENSUAL-QN");
                 ws = xlPackage.Workbook.Worksheets["GRAF-MENSUAL-QN"];
                 
                 titulo = "GRAFICO - PROGRAMADO MENSUAL - QN ";

                        ConfiguraEncabezadoHojaExcel(ws, titulo);
                        ws.Cells[4, 2].Value = "Fecha Inicio:";
                        ws.Cells[5, 2].Value = "Fecha Fin:";
                        ws.Cells[4, 3].Value = model.FechaInicio;
                        ws.Cells[5, 3].Value = model.FechaFin;

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
                        for (int i = 0; i<ncol; i++ )
                            for (int j = 0; j<nfil ; j++){
                                ws.Cells[j+7, i+3].Value = listSerieData[i][j];
                            }                             
                AddGraficoLineas(ws, nfil, ncol);
                xlPackage.Save();
            }
        }// ********************


    }
}