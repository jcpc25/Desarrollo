﻿using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Areas.Medidores.Models;
using COES.MVC.Intranet.Helper;
using COES.Servicios.Aplicacion.Mediciones;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace COES.MVC.Intranet.Areas.Medidores.Helpers
{
    public class MedidorHelper
    {
        /// <summary>
        /// Permite generar el archivo excel de máxima demanda diaria
        /// </summary>
        /// <param name="entity"></param>
        public static void GenerarReporteMaximaDemandaDiaria(MaximaDemanda entity, string fechaInicio, string fechaFin)
        {
            try
            {
                String file = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones] + NombreArchivo.ReporteMaximaDemandaDiaria;
                FileInfo newFile = new FileInfo(file);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(file);
                }

                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("REPORTE");

                    if (ws != null)
                    {
                        ws.Cells[5, 2].Value = "MÄXIMA DEMANDA DIARIA";

                        ExcelRange rg = ws.Cells[5, 2, 5, 2];
                        rg.Style.Font.Size = 13;
                        rg.Style.Font.Bold = true;

                        ws.Cells[7, 2].Value = "DESDE:";
                        ws.Cells[7, 3].Value = fechaInicio;
                        ws.Cells[8, 2].Value = "HASTA:";
                        ws.Cells[8, 3].Value = fechaFin;

                        ws.Cells[10, 2].Value = "EMPRESA";
                        ws.Cells[10, 3].Value = "TIPO DE GENERACIÓN";
                        ws.Cells[10, 4].Value = "CENTRAL";
                        ws.Cells[10, 5].Value = "GRUPO";

                        for (var i = 1; i <= entity.ndiasXMes; i++)
                        {
                            ws.Cells[10, 5 + i].Value = i.ToString();
                        }
                        
                        rg = ws.Cells[10, 2, 10, 5 + entity.ndiasXMes];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;

                        int row = 11;
                        decimal valorMD = 0;

                        foreach (var reg in entity.ListaDemandaDia)
                        {
                            ws.Cells[row, 2].Value = reg.Empresanomb;
                            ws.Cells[row, 3].Value = reg.Tipogeneracion;
                            ws.Cells[row, 4].Value = reg.Centralnomb;
                            ws.Cells[row, 5].Value = reg.Gruponomb;
                            
                            for (var i = 0; i < entity.ndiasXMes; i++)
                            {
                                if (reg.valores.Count > i)
                                {
                                    valorMD = reg.valores[i];
                                }
                                else
                                {
                                    valorMD = 0;
                                }

                                ws.Cells[row, 6 + i].Value = valorMD;
                            }

                            rg = ws.Cells[row, 2, row, 5 + entity.ndiasXMes];

                            rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Left.Color.SetColor(Color.Black);
                            rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Right.Color.SetColor(Color.Black);
                            rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Top.Color.SetColor(Color.Black);
                            rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                            rg.Style.Font.Size = 10;

                            row++;
                        }
                                                                     
                        ws.Column(2).Width = 20;                       

                        for (int t = 7; t <= 5 + entity.ndiasXMes; t++)
                        {
                            ws.Column(t).Style.Numberformat.Format = "#,##0.000";
                        }

                        ws.Cells[row, 2].Value = "ENLACE INTERNACIONAL";
                        ws.Cells[row, 3].Value = "PAÍS";
                        
                        //ws.Cells[row, 4].Value = "";
                        ws.Cells[row, 4].Value = "TIPO DE INTERCAMBIO";
                        ws.Cells[row, 4, row, 5].Merge = true;

                        rg = ws.Cells[row, 2, row, 5 + entity.ndiasXMes];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;

                        for (var i = 1; i <= entity.ndiasXMes; i++)
                        {
                            ws.Cells[row, 5 + i].Value = i.ToString();
                        }
                        row++;
                        foreach (var reg in entity.ListaDemandaDiaTotalResumen)
                        {
                            switch (reg.Gruponomb)
                            {
                                case "TOTAL":
                                    ws.Cells[row, 2].Value = reg.Empresanomb;
                                    ws.Cells[row, 3].Value = reg.Tipogeneracion;
                                    ws.Cells[row, 4].Value = reg.Centralnomb;
                                    ws.Cells[row, 5].Value = reg.Gruponomb;

                                    for (var i = 0; i < entity.ndiasXMes; i++)
                                    {
                                        ws.Cells[row, 6 + i].Value = reg.valores[i];
                                    }
                                    break;
                                case "IMPORTACIÓN":
                                case "EXPORTACIÓN":
                                    ws.Cells[row, 2].Value ="L - 2280(Zorritos - Machala)";
                                    ws.Cells[row, 3].Value = "ECUADOR";
                                    ws.Cells[row, 4].Value = reg.Gruponomb;
                                    ws.Cells[row, 4, row, 5].Merge = true;
                                    for (var i = 0; i < entity.ndiasXMes; i++)
                                    {
                                        ws.Cells[row, 6 + i].Value = reg.valores[i];
                                    }
                                    break;
                                case "HORA":
                                    ws.Cells[row, 2].Value = reg.Empresanomb;
                                    ws.Cells[row, 3].Value = reg.Tipogeneracion;
                                    ws.Cells[row, 4].Value = reg.Centralnomb;
                                    ws.Cells[row, 5].Value = reg.Gruponomb;

                                    for (var i = 0; i < entity.ndiasXMes; i++)
                                    {
                                        ws.Cells[row, 6 + i].Value = reg.horamin[i];
                                    }
                                    break;
                            }
                            row++;
                        }

                        rg = ws.Cells[row - 4, 2, row -3, 5 + entity.ndiasXMes];

                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                        rg.Style.Font.Size = 10;



                        rg = ws.Cells[row - 2, 2, row - 1, 5 + entity.ndiasXMes];
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#3493D1"));

                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;

                        ws.View.FreezePanes(11, 6);
                        rg = ws.Cells[1, 3, row + 2, 5 + entity.ndiasXMes];
                        rg.AutoFitColumns();
                                            
                        HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                        ExcelPicture picture = ws.Drawings.AddPicture("ff", img);
                        picture.From.Column = 1;
                        picture.From.Row = 1;
                        picture.To.Column = 2;
                        picture.To.Row = 2;
                        picture.SetSize(120, 35);
                    }

                    xlPackage.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite generar el reporte de máxima demanda en HFP y HP
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public static void GenerarReporteMaximaDemandaHFPHP(MaximaDemanda entity, string fechaInicio, string fechaFin)
        {
            try
            {
                String file = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones] + NombreArchivo.ReporteMaxinaDemandaHFPHP;
                FileInfo newFile = new FileInfo(file);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(file);
                }

                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("REPORTE");

                    if (ws != null)
                    {
                        ws.Cells[5, 2].Value = "MÄXIMA DEMANDA HFP Y HP";

                        ExcelRange rg = ws.Cells[5, 2, 5, 2];
                        rg.Style.Font.Size = 13;
                        rg.Style.Font.Bold = true;

                        ws.Cells[7, 2].Value = "DESDE:";
                        ws.Cells[7, 3].Value = fechaInicio;
                        ws.Cells[8, 2].Value = "HASTA:";
                        ws.Cells[8, 3].Value = fechaFin;

                        ws.Cells[10, 2].Value = "FECHA";
                        ws.Cells[10, 3].Value = "HFP";
                        ws.Cells[10, 5].Value = "HP";

                        rg = ws.Cells[10, 2, 11, 2];
                        rg.Merge = true;
                        rg.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        rg = ws.Cells[10, 3, 10, 4];
                        rg.Merge = true;

                        rg = ws.Cells[10, 5, 10, 6];
                        rg.Merge = true;

                        ws.Cells[11, 3].Value = "MW";
                        ws.Cells[11, 4].Value = "HORA";
                        ws.Cells[11, 5].Value = "MW";
                        ws.Cells[11, 6].Value = "HORA";
                        
                        rg = ws.Cells[10, 2, 11, 6];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;
                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);

                        int row = 12;
                        int index = 0;
                        foreach (var reg in entity.ListaDemandaDia_HFP_HP)
                        {
                            ws.Cells[row, 2].Value = reg.Medifecha.ToString(Constantes.FormatoFecha);
                            ws.Cells[row, 3].Value = reg.ValorHFP;
                            ws.Cells[row, 4].Value = reg.MedifechaHFP;
                            ws.Cells[row, 5].Value = reg.ValorHP;
                            ws.Cells[row, 6].Value = reg.MedifechaHP;

                            rg = ws.Cells[row, 2, row, 6];

                            rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Left.Color.SetColor(Color.Black);
                            rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Right.Color.SetColor(Color.Black);
                            rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Top.Color.SetColor(Color.Black);
                            rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                            rg.Style.Font.Size = 10;

                            if (index == entity.IndexHFP)
                            {
                                rg = ws.Cells[row, 3, row, 4];
                                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#C4E8FF"));
                            }
                            if (index == entity.IndexHP)
                            {
                                rg = ws.Cells[row, 5, row, 6];
                                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#C4E8FF"));
                            }

                            row++;
                            index++;
                        }                        

                        ws.Column(2).Width = 20;

                        for (int t = 3; t <= 6; t++)
                        {
                            ws.Column(t).Style.Numberformat.Format = "#,##0.000";
                        }

                        rg = ws.Cells[1, 3, row + 2, 6];
                        rg.AutoFitColumns();

                        HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                        ExcelPicture picture = ws.Drawings.AddPicture("ff", img);
                        picture.From.Column = 1;
                        picture.From.Row = 1;
                        picture.To.Column = 2;
                        picture.To.Row = 2;
                        picture.SetSize(120, 35);
                    }

                    xlPackage.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite generar el reporte del ranking de la demanda en excel
        /// </summary>
        /// <param name="demandaDiaria"></param>
        /// <param name="datosMD"></param>
        /// <param name="listaOrdenada"></param>
        /// <param name="produccionEnergia"></param>
        /// <param name="fc"></param>
        /// <param name="evolucion"></param>
        /// <param name="diagramaCarga"></param>
        public static void GenerarReporteRankingDemanda(List<DemandadiaDTO> demandaDiaria, DemandadiaDTO datosMD,  List<DemandadiaDTO> listaOrdenada, 
            decimal produccionEnergia, decimal fc, EntidadSerieMedicionEvolucion evolucion, EntidadSerieMedicionEvolucion diagramaCarga) 
        {
            try
            {
                String file = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones] + NombreArchivo.ReporteRankingDemanda;
                FileInfo newFile = new FileInfo(file);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(file);
                }

                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    #region Primera Hoja

                    ExcelWorksheet wsMD = xlPackage.Workbook.Worksheets.Add("MD Mensual");

                    if (wsMD != null)
                    {
                        wsMD.Cells[5, 2].Value = "MÄXIMA DEMANDA MENSUAL";

                        ExcelRange rg = wsMD.Cells[5, 2, 5, 2];
                        rg.Style.Font.Size = 13;
                        rg.Style.Font.Bold = true;

                        wsMD.Cells[7, 2].Value = "Máxima Demanda Mensual:";
                        wsMD.Cells[7, 3].Value = datosMD.ValorMD;
                        wsMD.Cells[8, 2].Value = "Fecha:";
                        wsMD.Cells[8, 3].Value = datosMD.FechaMD;
                        wsMD.Cells[9, 2].Value = "Hora:";
                        wsMD.Cells[9, 3].Value = datosMD.HoraMD;


                        wsMD.Cells[11, 2].Value = "FECHA";
                        wsMD.Cells[11, 3].Value = "HFP";
                        wsMD.Cells[11, 5].Value = "HP";

                        rg = wsMD.Cells[11, 2, 12, 2];
                        rg.Merge = true;
                        rg.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        rg = wsMD.Cells[11, 3, 11, 4];
                        rg.Merge = true;

                        rg = wsMD.Cells[11, 5, 11, 6];
                        rg.Merge = true;

                        wsMD.Cells[12, 3].Value = "MW";
                        wsMD.Cells[12, 4].Value = "HORA";
                        wsMD.Cells[12, 5].Value = "MW";
                        wsMD.Cells[12, 6].Value = "HORA";

                        rg = wsMD.Cells[11, 2, 12, 6];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;
                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);

                        int row = 13;
                        int index = 0;
                        foreach (var reg in demandaDiaria)
                        {
                            wsMD.Cells[row, 2].Value = reg.Medifecha.ToString(Constantes.FormatoFecha);
                            wsMD.Cells[row, 3].Value = reg.ValorHFP;
                            wsMD.Cells[row, 4].Value = reg.MedifechaHFP;
                            wsMD.Cells[row, 5].Value = reg.ValorHP;
                            wsMD.Cells[row, 6].Value = reg.MedifechaHP;

                            rg = wsMD.Cells[row, 2, row, 6];

                            rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Left.Color.SetColor(Color.Black);
                            rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Right.Color.SetColor(Color.Black);
                            rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Top.Color.SetColor(Color.Black);
                            rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                            rg.Style.Font.Size = 10;

                            if (index == datosMD.IndiceMDHFP)
                            {
                                rg = wsMD.Cells[row, 3, row, 4];
                                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#C4E8FF"));
                            }
                            if (index == datosMD.IndiceMDHP)
                            {
                                rg = wsMD.Cells[row, 5, row, 6];
                                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#C4E8FF"));
                            }

                            row++;
                            index++;
                        }

                        wsMD.Column(2).Width = 20;

                        for (int t = 3; t <= 6; t++)
                        {
                            wsMD.Column(t).Style.Numberformat.Format = "#,##0.000";
                        }

                        rg = wsMD.Cells[1, 3, row + 2, 6];
                        rg.AutoFitColumns();

                        HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                        ExcelPicture picture = wsMD.Drawings.AddPicture("ff", img);
                        picture.From.Column = 1;
                        picture.From.Row = 1;
                        picture.To.Column = 2;
                        picture.To.Row = 2;
                        picture.SetSize(120, 35);
                    }


                    
                    #endregion

                    #region Segunda parte

                    ExcelWorksheet wsOrden = xlPackage.Workbook.Worksheets.Add("Ordenamiento MD");
                    
                    if (wsOrden != null)
                    {
                        wsOrden.Cells[5, 2].Value = "ORDENAMIENTO MÁXIMA DEMANDA";

                        ExcelRange rg = wsOrden.Cells[5, 2, 5, 2];
                        rg.Style.Font.Size = 13;
                        rg.Style.Font.Bold = true;

                        wsOrden.Cells[7, 2].Value = "Producción de Energía (MWh)";
                        wsOrden.Cells[7, 3].Value = produccionEnergia;
                        wsOrden.Cells[8, 2].Value = "Factor carga";
                        wsOrden.Cells[8, 3].Value = fc;
                        
                        wsOrden.Cells[10, 2].Value = "N° de Registos/MES";
                        wsOrden.Cells[10, 3].Value = "Fecha/Hora";
                        wsOrden.Cells[10, 4].Value = "Demanda (MW)";
                        
                        rg = wsOrden.Cells[10, 2, 10, 4];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;
                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);

                        int row = 11;                        
                        foreach (var reg in listaOrdenada)
                        {
                            wsOrden.Cells[row, 2].Value = (row - 10);
                            wsOrden.Cells[row, 3].Value = reg.StrMediFecha;
                            wsOrden.Cells[row, 4].Value = reg.Valor; 
                            
                            rg = wsOrden.Cells[row, 2, row, 4];

                            rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Left.Color.SetColor(Color.Black);
                            rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Right.Color.SetColor(Color.Black);
                            rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Top.Color.SetColor(Color.Black);
                            rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                            rg.Style.Font.Size = 10;
                            
                            row++;                           
                        }

                        wsOrden.Column(2).Width = 20;

                        for (int t = 3; t <= 4; t++)
                        {
                            wsOrden.Column(t).Style.Numberformat.Format = "#,##0.000";
                        }

                        rg = wsOrden.Cells[1, 3, row + 2, 6];
                        rg.AutoFitColumns();
                        
                        var chart = wsOrden.Drawings.AddChart("crtExtensionsSize", eChartType.Area);
                        chart.SetPosition(180, 440);
                        chart.SetSize(1000, 500);
                        chart.Series.Add(wsOrden.Cells[11, 4, row, 4], wsOrden.Cells[11, 2, row, 2]);
                        chart.Legend.Position = eLegendPosition.Bottom; 
                        chart.Legend.Add();
                        chart.YAxis.Title.Text = "Potencia (MW)";
                        chart.YAxis.Font.Size = 9;
                        chart.XAxis.Title.Text = "Tiempo";

                                                

                        HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                        ExcelPicture picture = wsOrden.Drawings.AddPicture("ff", img);
                        picture.From.Column = 1;
                        picture.From.Row = 1;
                        picture.To.Column = 2;
                        picture.To.Row = 2;
                        picture.SetSize(120, 35);
                    }

                    #endregion

                    #region Tercera parte

                    ExcelWorksheet wsEvolucion = xlPackage.Workbook.Worksheets.Add("Evolución diagramas");

                    if (wsEvolucion != null)
                    {
                        wsEvolucion.Cells[5, 2].Value = "EVOLUCIÓN DE LOS DIAGRAMAS DE CARGA";

                        ExcelRange rg = wsEvolucion.Cells[5, 2, 5, 2];
                        rg.Style.Font.Size = 13;
                        rg.Style.Font.Bold = true;

                        wsEvolucion.Cells[7, 2].Value = "Máxima Demanda Mensual:";
                        wsEvolucion.Cells[7, 3].Value = datosMD.ValorMD;
                        wsEvolucion.Cells[8, 2].Value = "Fecha:";
                        wsEvolucion.Cells[8, 3].Value = datosMD.FechaMD;
                        wsEvolucion.Cells[9, 2].Value = "Hora:";
                        wsEvolucion.Cells[9, 3].Value = datosMD.HoraMD;

                        wsEvolucion.Cells[11, 2].Value = "HORA";

                        int column = 3;

                        foreach (SerieMedicionEvolucion item in evolucion.ListaSerie)
                        {
                            wsEvolucion.Cells[11, column].Value = item.SerieName;
                            column++;
                        }

                        rg = wsEvolucion.Cells[11, 2, 11, column - 1];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;
                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);

                        int row = 12;
                        column = 3;

                        DateTime fecha = DateTime.ParseExact(datosMD.FechaMD, Constantes.FormatoFecha, CultureInfo.InvariantCulture);

                        for (int i = 1; i <= 96; i++)
                        {
                            wsEvolucion.Cells[row, column - 1].Value = fecha.AddMinutes(i * 15).ToString(Constantes.FormatoHoraMinuto);
                            row++;
                        }

                        foreach (SerieMedicionEvolucion item in evolucion.ListaSerie)
                        {
                            row = 12;
                            foreach (decimal valor in item.ListaValores)
                            {
                                wsEvolucion.Cells[row, column].Value = valor;
                                row++;
                            }
                            column++;
                        }

                        rg = wsEvolucion.Cells[11, 2, row - 1, column - 1];

                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                        rg.Style.Font.Size = 10;
                        
                        wsEvolucion.Column(2).Width = 30;

                        for (int t = 3; t <= 4; t++)
                        {
                            wsEvolucion.Column(t).Style.Numberformat.Format = "#,##0.000";
                        }

                        rg = wsEvolucion.Cells[1, 3, row + 2, 6];
                        rg.AutoFitColumns();

                        var chart = wsEvolucion.Drawings.AddChart("chartEvolucion", eChartType.AreaStacked);
                        chart.SetPosition(200, 890);
                        chart.SetSize(1000, 600);

                        column = 3;
                        int header = 0;
                        foreach (SerieMedicionEvolucion item in evolucion.ListaSerie)
                        {
                            chart.Series.Add(wsEvolucion.Cells[12, column, 107, column], wsEvolucion.Cells[12, 2, 107, 2]);
                            chart.Series[header].Header = item.SerieName;
                            header++;
                            column++;
                        }

                        chart.Legend.Position = eLegendPosition.Bottom;
                        chart.Legend.Add();
                        chart.Title.Text = "DESPACHO EN EL DÍA DE MÁXIMA DEMANDA POR TIPO DE RECURSO ENERGÉTICO " + evolucion.Titulo;
                        chart.YAxis.Title.Text = "Potencia (MW)";
                        chart.YAxis.Font.Size = 11;
                        chart.XAxis.Title.Text = "Tiempo";

                        row = 111;

                        wsEvolucion.Cells[row, 2].Value = "Fecha Máxima Demanda";
                        wsEvolucion.Cells[row, 3].Value = diagramaCarga.FechaMaximaDemanda;
                        wsEvolucion.Cells[row + 1, 2].Value = "Hora Máxima Demanda";
                        wsEvolucion.Cells[row + 1, 3].Value = DateTime.ParseExact(diagramaCarga.FechaMaximaDemanda, Constantes.FormatoFecha, 
                            CultureInfo.InvariantCulture).AddMinutes(diagramaCarga.IndiceMaximaDemanda*15).ToString(Constantes.FormatoHoraMinuto);
                        wsEvolucion.Cells[row + 2, 2].Value = "Valor Máxima Demanda";
                        wsEvolucion.Cells[row + 2, 3].Value = diagramaCarga.ValorMaximaDemanda;
                        wsEvolucion.Cells[row + 3, 2].Value = "Fecha Mínima Demanda";
                        wsEvolucion.Cells[row + 3, 3].Value = diagramaCarga.FechaMinimaDemanda;
                        wsEvolucion.Cells[row + 4, 2].Value = "Hora Mínima Demanda";
                        wsEvolucion.Cells[row + 4, 3].Value = DateTime.ParseExact(diagramaCarga.FechaMinimaDemanda, Constantes.FormatoFecha,
                            CultureInfo.InvariantCulture).AddMinutes(diagramaCarga.IndiceMinimaDemanda * 15).ToString(Constantes.FormatoHoraMinuto);
                        wsEvolucion.Cells[row + 5, 2].Value = "Valor Mínima Demanda";
                        wsEvolucion.Cells[row + 5, 3].Value = diagramaCarga.ValorMinimaDemanda;
                        
                        wsEvolucion.Cells[118, 2].Value = "Hora";
                        wsEvolucion.Cells[118, 3].Value = "Máxima Demanda";
                        wsEvolucion.Cells[118, 4].Value = "Mínima Demanda";

                        rg = wsEvolucion.Cells[118, 2, 118, 4];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;
                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);

                        row = 119;
                        column = 3;

                        fecha = DateTime.ParseExact(datosMD.FechaMD, Constantes.FormatoFecha, CultureInfo.InvariantCulture);

                        for (int i = 1; i <= 96; i++)
                        {
                            wsEvolucion.Cells[row, column - 1].Value = fecha.AddMinutes(i * 15).ToString(Constantes.FormatoHoraMinuto);
                            row++;
                        }

                        foreach (SerieMedicionEvolucion item in diagramaCarga.ListaSerie)
                        {
                            row = 119;
                            foreach (decimal valor in item.ListaValores)
                            {
                                wsEvolucion.Cells[row, column].Value = valor;
                                row++;
                            }
                            column++;
                        }

                        rg = wsEvolucion.Cells[119, 2, row - 1, column - 1];

                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                        rg.Style.Font.Size = 10;

                        var chartMaximo = wsEvolucion.Drawings.AddChart("chartMaximaMinima", eChartType.Area);
                        chartMaximo.SetPosition(2340, 480);
                        chartMaximo.SetSize(1000, 600);

                        column = 3;
                        header = 0;
                        foreach (SerieMedicionEvolucion item in diagramaCarga.ListaSerie)
                        {
                            chartMaximo.Series.Add(wsEvolucion.Cells[119, column, 214, column], wsEvolucion.Cells[119, 2, 214, 2]);
                            chartMaximo.Series[header].Header = item.SerieName;
                            header++;
                            column++;
                        }

                        chartMaximo.Legend.Position = eLegendPosition.Bottom;
                        chartMaximo.Legend.Add();
                        chartMaximo.Title.Text = "DIAGRAMA DE CARGA DEL SEIN MÁXIMA Y MÍNIMA DEMANDA ACUMULADA A " + diagramaCarga.Titulo;
                        chartMaximo.YAxis.Title.Text = "Potencia (MW)";
                        chartMaximo.YAxis.Font.Size = 11;
                        chartMaximo.XAxis.Title.Text = "Tiempo";

                        HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                        ExcelPicture picture = wsEvolucion.Drawings.AddPicture("ff", img);
                        picture.From.Column = 1;
                        picture.From.Row = 1;
                        picture.To.Column = 2;
                        picture.To.Row = 2;
                        picture.SetSize(120, 35);
                    }

                    #endregion

                    xlPackage.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Permite generar el reporte del diagrama de carga
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mes"></param>
        public static void GenerarReporteDuracionCarga(List<SerieDuracionCarga> list, int anio, int mes)
        {
            try
            {
                string file = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones] + NombreArchivo.ReporteDuracionCarga;
                FileInfo newFile = new FileInfo(file);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(file);
                }

                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("REPORTE");

                    if (ws != null)
                    {
                        ws.Cells[5, 2].Value = "DURACIÓN DE CARGA";

                        ExcelRange rg = ws.Cells[5, 2, 5, 2];
                        rg.Style.Font.Size = 13;
                        rg.Style.Font.Bold = true;
                        
                        ws.Cells[6, 2].Value = "AÑO:";
                        ws.Cells[6, 3].Value = " " + anio;

                        int row = 8;
                        int column = 2;
                        

                        if (list.Count > 0)
                        {
                            ws.Cells[row, column].Value = "NRO";
                            column++;
                            foreach (SerieDuracionCarga item in list)
                            {
                                ws.Cells[row, column].Value = item.SerieName;
                                column++;
                            }

                            rg = ws.Cells[row, 2, row, column - 1];
                            rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                            rg.Style.Font.Color.SetColor(Color.White);
                            rg.Style.Font.Size = 10;
                            rg.Style.Font.Bold = true;
                            rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Left.Color.SetColor(Color.Black);
                            rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Right.Color.SetColor(Color.Black);
                            rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Top.Color.SetColor(Color.Black);
                            rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Bottom.Color.SetColor(Color.Black);

                            int index = 1;                            
                            column = 3;
                            
                            foreach (SerieDuracionCarga item in list)
                            {
                                row = 9;
                                foreach (decimal valor in item.ListaValores)
                                {
                                    if (column == 3) 
                                    {
                                        ws.Cells[row, column - 1].Value = index;
                                    }

                                    ws.Cells[row, column].Value = valor;
                                    row++;
                                    index++;
                                }
                                column++;
                            }

                            rg = ws.Cells[9, 2, row - 1, column - 1];
                            rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Left.Color.SetColor(Color.Black);
                            rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Right.Color.SetColor(Color.Black);
                            rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Top.Color.SetColor(Color.Black);
                            rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                            rg.Style.Font.Size = 10;


                            var chart = ws.Drawings.AddChart("chartMaximaMinima", eChartType.AreaStacked);
                            chart.SetPosition(240,750);
                            chart.SetSize(1000, 600);

                            column = 3;
                            int header = 0;
                            foreach (SerieDuracionCarga item in list)
                            {
                                chart.Series.Add(ws.Cells[9, column, row - 1, column], ws.Cells[9, 2, row - 1, 2]);
                                chart.Series[header].Header = item.SerieName;
                                header++;
                                column++;
                            }

                            chart.Legend.Position = eLegendPosition.Bottom;
                            chart.Legend.Add();
                            chart.Title.Text = "DIAGRAMA DE DURACIÓN DE CARGA MENSUAL";
                            chart.YAxis.Title.Text = "Potencia (MW)";
                            chart.YAxis.Font.Size = 11;
                            chart.XAxis.Title.Text = "Tiempo";
                            

                            for (int t = 3; t <= column; t++)
                            {
                                ws.Column(t).Style.Numberformat.Format = "#,##0.000";
                            }

                        }


                        HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                        ExcelPicture picture = ws.Drawings.AddPicture("Logo", img);
                        picture.From.Column = 1;
                        picture.From.Row = 1;
                        picture.To.Column = 2;
                        picture.To.Row = 2;
                        picture.SetSize(120, 35);

                    }                   

                    xlPackage.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite armar la tabla del reporte de máxima demanda consolidado mensual
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ObtenerReporteConsolidado(List<MedicionReporteDTO> list, int opcion)
        {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalSeparator = ",";
            nfi.NumberDecimalDigits = 3;
            
            StringBuilder str = new StringBuilder();

            var listFechas = list.Select(x => new { x.Anio, x.Mes, x.FechaMaximaDemanda, x.Indice }).
                OrderBy(x => x.FechaMaximaDemanda).Distinct().ToList();

            #region Cabecera

            str.Append("<table class='tabla-formulario'>");
            str.Append("  <thead>");
            str.Append("    <tr>");
            str.Append("       <th rowspan='3'>Empresa</th>");
            str.Append("       <th rowspan='3'>Tipo de Generación</th>");
            str.Append("       <th rowspan='3'>Central</th>");
            str.Append("       <th rowspan='3'>Unidad</th>");
            str.Append(string.Format("       <th colspan='{0}'>Máxima Demanda Mensual (MW)</th>", listFechas.Count));
            str.Append("    </tr>");
            str.Append("    <tr style='background-color:#50A2D8'>");

            foreach (var item in listFechas)
            {
                str.Append(string.Format("       <th>{0}</th>", COES.Base.Tools.Util.ObtenerNombreMesAbrev(item.Mes) + " " + item.Anio));
            }

            str.Append("    </tr>");
            str.Append("    <tr>");

            foreach (var item in listFechas)
            {
                string fecha = item.FechaMaximaDemanda.AddMinutes(item.Indice * 15).ToString(Constantes.FormatoFechaHora);
                str.Append(string.Format("       <th>{0}</th>", fecha));
            }

            str.Append("    </tr>");
            str.Append("  </thead>");

            #endregion

            str.Append("  <tbody>");

            List<ReporteConsolidado> resultado = ObtenerEstructura(list);

            foreach (ReporteConsolidado item in resultado)
            {
                str.Append("    <tr>");
                string style = "style='text-align:right'";
                if (item.IndEmpresa == 1)
                {
                    str.Append(string.Format("      <td rowspan='{1}'>{0}</td>", item.DesEmpresa, item.RowSpanEmpresa));
                }
                if (item.IndTotalEmpresa == 1)
                {
                    str.Append(string.Format("      <td colspan='4' style='background-color:#BFDEF0;text-align:right; font-weight:bold' >Total: {0}</td>", item.DesEmpresa));
                    style = "style='background-color:#BFDEF0; text-align:right'";
                }
                if (item.IndTipoGeneracion == 1)
                {
                    str.Append(string.Format("      <td rowspan='{1}'>{0}</td>", item.DesTipoGeneracion, item.RowSpanTipoGeneracion));
                }
                if (item.IndTotalTipoGeneracion == 1)
                {
                    str.Append(string.Format("      <td colspan='3' style='background-color:#EEF5FD;text-align:right; font-weight:bold'>Total: {0}</td>", item.DesTipoGeneracion));
                    style = "style='background-color:#EEF5FD; text-align:right'";
                }
                if (item.IndCentral == 1)
                {
                    str.Append(string.Format("      <td rowspan='{1}'>{0}</td>", item.DesCentral, item.RowSpanCentral));
                }

                if (item.IndTotalGeneralTG == 1)
                {
                    str.Append(string.Format("      <td colspan='4' style='background-color:#3594D2;text-align:right; font-weight:bold; color:#ffffff'>TOTAL: {0}</td>", item.DesTipoGeneracion));
                    style = "style='background-color:#3594D2; text-align:right; color:#ffffff'";
                }

                if (item.IndTotalGeneral == 1)
                {
                    str.Append("      <td colspan='4' style='background-color:#2980B9;text-align:right; font-weight:bold; color:#ffffff'>TOTAL COES</td>");
                    style = "style='background-color:#2980B9; text-align:right; color:#ffffff'";
                }

                if (item.IndTotalEmpresa != 1 && item.IndTotalTipoGeneracion != 1 && item.IndTotalGeneralTG != 1 && item.IndTotalGeneral != 1)
                {
                    str.Append(string.Format("      <td>{0}</td>", item.DesUnidad));
                }

                foreach (decimal valor in item.Valores)
                {
                    str.Append(string.Format("      <td {1}>{0}</td>", valor.ToString("N", nfi), style));
                }

                str.Append("    </tr>");
            }

            str.Append("  </tbody>");
            str.Append("</table>");

            return str.ToString();
        }

        /// <summary>
        /// Permite obtener el reporte de consolidado mensual en excel
        /// </summary>
        /// <param name="list"></param>
        public static void GenerarReporteExcelConsolidado(List<MedicionReporteDTO> list)
        {
            try
            {
                String file = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones] + NombreArchivo.ReporteConsolidoMensual;
                FileInfo newFile = new FileInfo(file);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(file);
                }

                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("REPORTE");

                    if (ws != null)
                    {
                        ws.Cells[5, 2].Value = "CONSOLIDADO MAXIMA DEMANDA MENSUAL";

                        ExcelRange rg = ws.Cells[5, 2, 5, 2];
                        rg.Style.Font.Size = 13;
                        rg.Style.Font.Bold = true;


                        var listFechas = list.Select(x => new { x.Anio, x.Mes, x.FechaMaximaDemanda, x.Indice }).
                                OrderBy(x => x.FechaMaximaDemanda).Distinct().ToList();
                                              
                        
                        ws.Cells[7, 2].Value = "EMPRESA";
                        ws.Cells[7, 2, 9, 2].Merge = true;
                        ws.Cells[7, 3].Value = "TIPO DE GENERACIÓN";
                        ws.Cells[7, 3, 9, 3].Merge = true;
                        ws.Cells[7, 4].Value = "CENTRAL";
                        ws.Cells[7, 4, 9, 4].Merge = true;
                        ws.Cells[7, 5].Value = "UNIDAD";
                        ws.Cells[7, 5, 9, 5].Merge = true;
                        ws.Cells[7, 6].Value = "MÁXIMA DEMANDA MENSUAL (MW)";
                        ws.Cells[7, 6, 7, 6 + listFechas.Count -1 ].Merge = true;

                        int column = 6;

                        foreach (var item in listFechas)
                        {                           
                            string fecha = item.FechaMaximaDemanda.AddMinutes(item.Indice * 15).ToString(Constantes.FormatoFechaHora);
                            ws.Cells[8, column].Value = COES.Base.Tools.Util.ObtenerNombreMesAbrev(item.Mes) + " " + item.Anio;
                            ws.Cells[9, column].Value = fecha;
                            column++;
                        }                       

                        rg = ws.Cells[7, 2, 9, column - 1];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;
                        rg.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        int row = 10;
                        int columnFinal = column;
                                                
                        List<ReporteConsolidado> resultado = ObtenerEstructura(list);

                        foreach (ReporteConsolidado item in resultado)
                        {                           
                           
                            if (item.IndEmpresa == 1)
                            {
                                ws.Cells[row, 2].Value = item.DesEmpresa;
                                ws.Cells[row, 2, row + item.RowSpanEmpresa -1, 2].Merge = true;                                
                            }

                            if (item.IndTotalEmpresa == 1)
                            {
                                ws.Cells[row, 2].Value = "TOTAL: " + item.DesEmpresa;
                                ws.Cells[row, 2, row, 5].Merge = true;

                                rg = ws.Cells[row, 2, row, columnFinal - 1];
                                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#BFDEF0"));
                            }

                            if (item.IndTipoGeneracion == 1)
                            {
                                ws.Cells[row, 3].Value = item.DesTipoGeneracion;
                                ws.Cells[row, 3, row + item.RowSpanTipoGeneracion -1, 3].Merge = true;                                
                            }

                            if (item.IndTotalTipoGeneracion == 1)
                            {
                                ws.Cells[row, 3].Value = "TOTAL: " + item.DesTipoGeneracion;
                                ws.Cells[row, 3, row, 5].Merge = true;

                                rg = ws.Cells[row, 3, row, columnFinal - 1];
                                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#EEF5FD"));
                            }

                            if (item.IndCentral == 1)
                            {                               
                                ws.Cells[row, 4].Value = item.DesCentral;
                                ws.Cells[row, 4, row + item.RowSpanCentral -1, 4].Merge = true;
                            }

                            if (item.IndTotalGeneralTG == 1)
                            {
                                ws.Cells[row, 2].Value = "TOTAL: " + item.DesTipoGeneracion;
                                ws.Cells[row, 2, row, 5].Merge = true;

                                rg = ws.Cells[row, 2, row, columnFinal - 1];
                                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#3594D2"));
                                rg.Style.Font.Color.SetColor(Color.White);
                            }

                            if (item.IndTotalGeneral == 1)
                            {
                                ws.Cells[row, 2].Value = "TOTAL COES ";
                                ws.Cells[row, 2, row, 5].Merge = true;

                                rg = ws.Cells[row, 2, row, columnFinal -1];
                                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                                rg.Style.Font.Color.SetColor(Color.White);
                            }

                            if (item.IndTotalEmpresa != 1 && item.IndTotalTipoGeneracion != 1 && item.IndTotalGeneralTG != 1 && item.IndTotalGeneral != 1)
                            {                               
                                ws.Cells[row, 5].Value = item.DesUnidad;
                            }

                            column = 6;
                            foreach (decimal valor in item.Valores)
                            {
                                ws.Cells[row, column].Value = valor;                                
                                column++;
                            }
                            row++;
                        }

                        rg = ws.Cells[10, 2, row - 1, column - 1];

                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                        rg.Style.Font.Size = 10;
                        rg.Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                        for (int t = 6; t <= 6 + columnFinal; t++)
                        {
                            ws.Column(t).Style.Numberformat.Format = "#,##0.000";
                        }
                                                
                        rg = ws.Cells[1, 2, row , columnFinal];
                        rg.AutoFitColumns();

                        ws.View.FreezePanes(10, 3);

                        HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                        ExcelPicture picture = ws.Drawings.AddPicture("ff", img);
                        picture.From.Column = 1;
                        picture.From.Row = 1;
                        picture.To.Column = 2;
                        picture.To.Row = 2;
                        picture.SetSize(120, 35);
                    }

                    xlPackage.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener la estructura del reporte
        /// </summary>
        /// <param name="list"></param>
        private static List<ReporteConsolidado> ObtenerEstructura(List<MedicionReporteDTO> list)
        {
            List<ReporteConsolidado> resultado = new List<ReporteConsolidado>();
            List<SubReporteConsolidado> subResultado = new List<SubReporteConsolidado>();

            #region Obtención de datos

            var listEmpresas = list.Select(x => new { x.EmprCodi, x.Emprnomb }).Distinct().ToList();
            var listFecha = list.Select(x => new { x.Anio, x.Mes }).Distinct().ToList();

            var listEquipos = list.Select(x => new
            {
                x.EmprCodi,
                x.Central,
                x.EquiCodi,
                x.Unidad,
                x.Tgenernomb,
                x.Tgenercodi,
                x.Fenergcodi,
                x.Fenergnomb
            }).Distinct().ToList();
                        

            foreach (var itemEmpresa in listEmpresas)
            {                
                var listTipoGeneracion = listEquipos.Where(x => x.EmprCodi == itemEmpresa.EmprCodi).
                    Select(x => new { x.Tgenercodi, x.Tgenernomb }).Distinct().ToList();

                foreach (var itemTipoGeneracion in listTipoGeneracion)
                {
                    var listCentral = listEquipos.Where(x => x.EmprCodi == itemEmpresa.EmprCodi && x.Tgenercodi == itemTipoGeneracion.Tgenercodi).Select(
                        x => new { x.Central }).Distinct().ToList();

                    foreach (var itemCentral in listCentral)
                    {
                        var listaUnidad = listEquipos.Where(x => x.EmprCodi == itemEmpresa.EmprCodi && x.Tgenercodi == itemTipoGeneracion.Tgenercodi &&
                            x.Central == itemCentral.Central).Select(x => new { x.EquiCodi, x.Unidad, x.Fenergnomb }).Distinct().ToList();

                        foreach (var itemUnidad in listaUnidad)
                        {
                            ReporteConsolidado itemResultado = new ReporteConsolidado();
                            itemResultado.DesEmpresa = itemEmpresa.Emprnomb;
                            itemResultado.DesTipoGeneracion = itemTipoGeneracion.Tgenernomb;
                            itemResultado.DesCentral = itemCentral.Central;
                            itemResultado.DesUnidad = itemUnidad.Unidad;
                            itemResultado.DesFuenteEnergia = itemUnidad.Fenergnomb;
                            itemResultado.EmprCodi = itemEmpresa.EmprCodi;
                            itemResultado.TgenerCodi = itemTipoGeneracion.Tgenercodi;
                            itemResultado.IndTotalCentral = 0;
                            itemResultado.IndTotalTipoGeneracion = 0;
                            itemResultado.IndTotalEmpresa = 0;
                                            
                            List<decimal> valores = new List<decimal>();

                            foreach (var itemFecha in listFecha)
                            {
                                var entity = list.Where(x => x.EquiCodi == itemUnidad.EquiCodi && x.Anio == itemFecha.Anio && x.Mes == itemFecha.Mes).FirstOrDefault();

                                if (entity != null)
                                {
                                    valores.Add(entity.ValorMD);
                                }
                            }
                            
                            itemResultado.Valores = valores;
                            resultado.Add(itemResultado);
                        }

                        SubReporteConsolidado subReporte = new SubReporteConsolidado();
                        subReporte.Cantidad = listaUnidad.Count;
                        subReporte.Central = itemCentral.Central;
                        subReporte.EmprCodi = itemEmpresa.EmprCodi;
                        subReporte.TgenerCodi = itemTipoGeneracion.Tgenercodi;
                        subResultado.Add(subReporte);
                    }
                }
            }

            #endregion

            List<int> subListEmpresa = new List<int>();
            List<SubReporteConsolidado> subListTipoGeneracion = new List<SubReporteConsolidado>();
            List<SubReporteConsolidado> subListCentral = new List<SubReporteConsolidado>();

            foreach (ReporteConsolidado item in resultado)
            {
                if (!subListEmpresa.Contains(item.EmprCodi))
                {
                    item.RowSpanEmpresa = subResultado.Where(x => x.EmprCodi == item.EmprCodi).Sum(x => x.Cantidad)
                        + subResultado.Where(x => x.EmprCodi == item.EmprCodi).Select(x => x.TgenerCodi).Distinct().Count();
                    item.IndEmpresa = 1;
                    subListEmpresa.Add(item.EmprCodi);
                }
                else
                {
                    item.RowSpanEmpresa = 0;
                    item.IndEmpresa = 0;
                }

                int count = subListTipoGeneracion.Where(x => x.EmprCodi == item.EmprCodi && x.TgenerCodi == item.TgenerCodi).Count();

                if (count == 0)
                {
                    item.RowSpanTipoGeneracion = subResultado.Where(x => x.EmprCodi == item.EmprCodi && x.TgenerCodi == 
                        item.TgenerCodi).Sum(x => x.Cantidad);
                    item.IndTipoGeneracion = 1;

                    SubReporteConsolidado subItemReporteConsolidado = new SubReporteConsolidado();
                    subItemReporteConsolidado.EmprCodi = item.EmprCodi;
                    subItemReporteConsolidado.TgenerCodi = item.TgenerCodi;
                    subListTipoGeneracion.Add(subItemReporteConsolidado);
                }
                else
                {
                    item.RowSpanTipoGeneracion = 0;
                    item.IndTipoGeneracion = 0;
                }

                int countCentral = subListCentral.Where(x => x.EmprCodi == item.EmprCodi && x.TgenerCodi == item.TgenerCodi &&
                    x.Central == item.DesCentral).Count();

                if (countCentral == 0)
                {
                    item.RowSpanCentral = subResultado.Where(x => x.EmprCodi == item.EmprCodi && x.TgenerCodi ==
                        item.TgenerCodi && x.Central == item.DesCentral).Sum(x => x.Cantidad);
                    item.IndCentral = 1;

                    SubReporteConsolidado subItemReporteConsolidado = new SubReporteConsolidado();
                    subItemReporteConsolidado.EmprCodi = item.EmprCodi;
                    subItemReporteConsolidado.TgenerCodi = item.TgenerCodi;
                    subItemReporteConsolidado.Central = item.DesCentral;
                    subListCentral.Add(subItemReporteConsolidado);
                }
                else 
                {
                    item.RowSpanCentral = 0;
                    item.IndCentral = 0;
                }
            }
                        
            List<ReporteConsolidado> final = new List<ReporteConsolidado>();
            
            foreach (var itemEmpresa in listEmpresas)
            {
                var listTipoGeneracion = resultado.Where(x => x.EmprCodi == itemEmpresa.EmprCodi).Select(x => 
                    new { x.TgenerCodi, x.DesTipoGeneracion }).Distinct().ToList();
                List<decimal> totalEmpresa = new List<decimal>();

                int contadorEmpresa = 0;
                foreach (var itemTipoGeneracion in listTipoGeneracion)
                {
                    List<decimal> totalTipoGeneracion = new List<decimal>();
                    List<List<decimal>> lista = resultado.Where(x => x.EmprCodi == itemEmpresa.EmprCodi && x.TgenerCodi == 
                        itemTipoGeneracion.TgenerCodi).Select(x => x.Valores).ToList();

                    int contadorTipoGeneracion = 0;
                    foreach (List<decimal> subList in lista)
                    {
                        if (contadorTipoGeneracion == 0)                        
                        {
                            totalTipoGeneracion = new List<decimal>(subList);
                        }
                        else 
                        {
                            for (int i = 0; i < subList.Count; i++)
                            {
                                totalTipoGeneracion[i] = totalTipoGeneracion[i] + subList[i];
                            }
                        }
                        contadorTipoGeneracion++;
                    }                                       

                    if (contadorEmpresa == 0)
                    {
                        totalEmpresa = new List<decimal>(totalTipoGeneracion);
                    }
                    else
                    {
                        for (int i = 0; i < totalTipoGeneracion.Count; i++)
                        {
                            totalEmpresa[i] = totalEmpresa[i] + totalTipoGeneracion[i];
                        }
                    }

                    contadorEmpresa++;

                    List<ReporteConsolidado> subListTG = resultado.Where(x => x.EmprCodi == itemEmpresa.EmprCodi && x.TgenerCodi == 
                        itemTipoGeneracion.TgenerCodi).ToList();
                    final.AddRange(subListTG);

                    ReporteConsolidado subTotalTG = new ReporteConsolidado();
                    subTotalTG.TgenerCodi = itemTipoGeneracion.TgenerCodi;
                    subTotalTG.DesTipoGeneracion = itemTipoGeneracion.DesTipoGeneracion;
                    subTotalTG.Valores = totalTipoGeneracion;
                    subTotalTG.IndTotalTipoGeneracion = 1;
                    final.Add(subTotalTG);
                }

                ReporteConsolidado subTotalEmpresa = new ReporteConsolidado();
                subTotalEmpresa.EmprCodi = itemEmpresa.EmprCodi;
                subTotalEmpresa.DesEmpresa = itemEmpresa.Emprnomb;
                subTotalEmpresa.IndTotalEmpresa = 1;
                subTotalEmpresa.Valores = totalEmpresa;
                final.Add(subTotalEmpresa);                              
            }
            
            List<ReporteConsolidado> arreglo = final.Where(x => x.IndTotalTipoGeneracion == 1).ToList();
            var subListTipo = arreglo.Select(x => new { x.TgenerCodi, x.DesTipoGeneracion }).Distinct().ToList();

            int contadorTotal = 0;
            List<decimal> valoresTotal = new List<decimal>();
            foreach (var item in subListTipo)
            {
                List<decimal> valoresTipo = new List<decimal>();

                List<List<decimal>> lista = arreglo.Where(x => x.TgenerCodi ==
                       item.TgenerCodi).Select(x => x.Valores).ToList();

                int contadorTipo = 0;
                foreach (List<decimal> subList in lista)
                {
                    if (contadorTipo == 0)
                    {
                        valoresTipo = new List<decimal>(subList);
                    }
                    else
                    {
                        for (int i = 0; i < subList.Count; i++)
                        {
                            valoresTipo[i] = valoresTipo[i] + subList[i];
                        }
                    }
                    contadorTipo++;
                }           
                               
                ReporteConsolidado itemTipoGeneracion = new ReporteConsolidado();
                itemTipoGeneracion.TgenerCodi = item.TgenerCodi;
                itemTipoGeneracion.DesTipoGeneracion = item.DesTipoGeneracion;
                itemTipoGeneracion.Valores = valoresTipo;
                itemTipoGeneracion.IndTotalGeneralTG = 1;
                final.Add(itemTipoGeneracion);

                if (contadorTotal == 0)
                {
                    valoresTotal = new List<decimal>(valoresTipo);
                }
                else
                {
                    for (int i = 0; i < valoresTipo.Count; i++)
                    {
                        valoresTotal[i] = valoresTotal[i] + valoresTipo[i];
                    }
                }
                contadorTotal++;                
            }

            ReporteConsolidado itemGeneral = new ReporteConsolidado();
            itemGeneral.Valores = valoresTotal;
            itemGeneral.IndTotalGeneral = 1;
            final.Add(itemGeneral);
                      
            return final;
        }

        /// <summary>
        /// Permite generar el reporte de validación de medidores
        /// </summary>
        /// <param name="list"></param>
        public static void GenerarReporteValidacionMedidores(List<ReporteValidacionMedidor> list, string fechaInicio, string fechaFin)
        {
            try
            {
                String file = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones] + NombreArchivo.ReporteValidacionMedidores;
                FileInfo newFile = new FileInfo(file);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(file);
                }

                using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("REPORTE");

                    if (ws != null)
                    {
                        ws.Cells[5, 2].Value = "REPORTE DE VALIDACIÓN DE REGISTRO DE MEDIDORES Y SCADA";

                        ExcelRange rg = ws.Cells[5, 2, 5, 2];
                        rg.Style.Font.Size = 13;
                        rg.Style.Font.Bold = true;

                        ws.Cells[7, 2].Value = "DESDE:";
                        ws.Cells[7, 3].Value = fechaInicio;
                        ws.Cells[8, 2].Value = "HASTA:";
                        ws.Cells[8, 3].Value = fechaFin;

                        ws.Cells[10, 2].Value = "EMPRESA";
                        ws.Cells[10, 3].Value = "GRUPO";
                        ws.Cells[10, 4].Value = "REGISTROS MEDIDORES (MW)";
                        ws.Cells[10, 5].Value = "REGISTROS SCADA (MWh)";
                        ws.Cells[10, 6].Value = "DESVIACIÓN (%)";
                        
                        rg = ws.Cells[10, 2, 10, 6];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;

                        int row = 11;
                       
                        foreach (var reg in list)
                        {
                            ws.Cells[row, 2].Value = reg.DesEmpresa;
                            ws.Cells[row, 3].Value = reg.DesGrupo;
                            ws.Cells[row, 4].Value = reg.ValorMedidor;
                            ws.Cells[row, 5].Value = reg.ValorDespacho;
                            if (reg.IndMuestra == Constantes.SI)
                            {
                                ws.Cells[row, 6].Value = reg.Desviacion;
                            }

                            if (reg.IndColor == Constantes.SI)
                            {
                                rg = ws.Cells[row, 6, row, 6];
                                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(reg.Color));
                            }

                            row++;
                        }

                        rg = ws.Cells[11, 2, row - 1, 6];
                        rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Left.Color.SetColor(Color.Black);
                        rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Right.Color.SetColor(Color.Black);
                        rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Top.Color.SetColor(Color.Black);
                        rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                        rg.Style.Font.Size = 10;
                        ws.Column(2).Width = 20;

                        for (int t = 3; t <= 4; t++)
                        {
                            ws.Column(t).Style.Numberformat.Format = "#,##0.000";
                        }

                        rg.AutoFitColumns();

                        ws.View.FreezePanes(10, 3);

                        HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                        ExcelPicture picture = ws.Drawings.AddPicture("ff", img);
                        picture.From.Column = 1;
                        picture.From.Row = 1;
                        picture.To.Column = 2;
                        picture.To.Row = 2;
                        picture.SetSize(120, 35);
                    }

                    xlPackage.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }

    /// <summary>
    /// Permite obtener la estructura del reporte
    /// </summary>
    public class ReporteConsolidado
    {
        public int EmprCodi { get; set; }
        public int TgenerCodi { get; set; }
        public string DesEmpresa { get; set; }
        public int RowSpanEmpresa { get; set; }
        public int IndEmpresa { get; set; }
        public string DesTipoGeneracion { get; set; }
        public int RowSpanTipoGeneracion { get; set; }
        public int IndTipoGeneracion { get; set; }
        public string DesCentral { get; set; }
        public int RowSpanCentral { get; set; }
        public int IndCentral { get; set; }
        public string DesUnidad { get; set; }
        public string DesFuenteEnergia { get; set; }
        public List<decimal> Valores { get; set; }
        public int IndTotalEmpresa { get; set; }
        public int IndTotalTipoGeneracion { get; set; }
        public int IndTotalCentral { get; set; }
        public int IndTotalGeneralTG { get; set; }
        public int IndTotalGeneral { get; set; }
    }

    /// <summary>
    /// Permite obtener la cantidad de elementos del reporte
    /// </summary>
    public class SubReporteConsolidado
    {
        public int EmprCodi { get; set; }
        public int TgenerCodi { get; set; }
        public string Central { get; set; }
        public int Cantidad { get; set; }
        public List<decimal> Valores { get; set; }
        public int IndicadorEmpresa { get; set; }
        public int IndicadorTiepoGeneracion { get; set; }
    }

   
}