using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using COES.MVC.Intranet.Helper;
using OfficeOpenXml;
using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Areas.Eventos.Models;

namespace COES.MVC.Intranet.Areas.Evento.Helper
{
    public class ExcelDocument
    {
        /// <summary>
        /// Permite exportar los perfiles almacenados en base de datos
        /// </summary>
        /// <param name="list"></param>
        public static void GenerarArchivoRSF(List<RsfModel> list, DateTime fecha)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteEvento].ToString();
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaExcel);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteRSF);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteRSF);
            }



            int index = 6;
            int row = 4;
            int column = 6;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                ws.Cells[2, 3].Value = fecha.ToString(Constantes.FormatoFecha);

                if (list.Count > 0)
                {
                    foreach (RsfItemModel item in list[0].ListItems)
                    {
                        ws.Cells[row, column].Value = item.HoraInicio.ToString("HH:mm:ss") + "-" + item.HoraFin.ToString("HH:mm:ss");
                        column = column + 4;
                    }
                    
                    column = index;
                    row++;

                    foreach (RsfItemModel item in list[0].ListItems)
                    {
                        ws.Cells[row, column].Value = "MAN";
                        column += 2;
                        ws.Cells[row, column].Value = "AUTO";
                        column += 2;
                    }

                    row++;
                    
                    foreach (RsfModel item in list)
                    {
                        column = 2;

                        ws.Cells[row, column].Value = item.DesURS;
                        ws.Cells[row, column + 1].Value = item.Empresa;
                        ws.Cells[row, column + 2].Value = item.Central;
                        ws.Cells[row, column + 3].Value = item.Equipo;

                        column = column + 4;
                        foreach (RsfItemModel child in item.ListItems)
                        {
                            ws.Cells[row, column++].Value = child.Manual.ToString();
                            ws.Cells[row, column++].Value = (child.IndManual == Constantes.SI) ? Constantes.TextoSI : string.Empty;
                            ws.Cells[row, column++].Value = child.Automatico.ToString();
                            ws.Cells[row, column++].Value = (child.IndAutomatico == Constantes.SI) ? Constantes.TextoSI : string.Empty;
                        }
                        row++;
                    }

                    for (int k = column; k <= 69; k++)
                    {
                        ws.Column(k).Hidden = true;
                    }

                    for (int k = row; k <= 68; k++)
                    {
                        ws.Row(k).Hidden = true;
                    }

                }

                xlPackage.Save();
            }
        }

        /// <summary>
        /// Permite generar el formato con los datos cada 30 minutos
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fecha"></param>
        public static void GenerarArchivoRSF30(List<RsfModel> list, DateTime fecha)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteEvento].ToString();
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaExcelRSF30);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteRSF30);
           
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteRSF30);
            }
            
            //iniciamos logica de generación de archivo excel   

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                ws.Cells[2, 3].Value = fecha.ToString(Constantes.FormatoFecha);

                if (list.Count > 0)
                {
                    List<HoraExcel> resultadoAutomatico = new List<HoraExcel>();
                    List<HoraExcel> resultadoManual = new List<HoraExcel>();
                    List<HoraExcel> horaExcel = new List<HoraExcel>();

                    #region Obtención de datos
                    
                    List<int> ids = (from modelo in list select modelo.IdEquipo).Distinct().ToList();

                    foreach (int id in ids)
                    {
                        RsfModel item = list.Where(x => x.IdEquipo == id).First();

                        List<RsfItemModel> listItemsAutomatico = item.ListItems.Where(x => x.Automatico > 0).ToList();
                        List<RsfItemModel> listItemsManual = item.ListItems.Where(x => x.Manual > 0).ToList();

                        foreach (RsfItemModel child in listItemsAutomatico)
                        {
                            int horaInicio = child.HoraInicio.Hour;
                            int minutoInicio = child.HoraInicio.Minute;
                            int horaFin = child.HoraFin.Hour;
                            int minutoFin = child.HoraFin.Minute;

                            for (int i = horaInicio; i <= horaFin; i++)
                            {
                                if (i == horaInicio || i == horaFin)
                                {
                                    if (i == horaInicio)
                                    {
                                        if (i != 0 || minutoInicio != 0)
                                            resultadoAutomatico.Add(new HoraExcel { Hora = i, Minuto = minutoInicio, Valor = child.Automatico, IdEquipo = id });

                                        if (minutoInicio == 0 && horaInicio != horaFin)
                                        {
                                            resultadoAutomatico.Add(new HoraExcel { Hora = i, Minuto = 30, Valor = child.Automatico, IdEquipo = id });
                                        }
                                    }
                                    if (i == horaFin)
                                    {
                                        if (horaInicio != horaFin)
                                        {
                                            resultadoAutomatico.Add(new HoraExcel { Hora = i, Minuto = 0, Valor = child.Automatico, IdEquipo = id });
                                        }
                                        
                                        if (minutoFin != 0)
                                        {
                                            if (minutoFin > 30 && horaInicio != horaFin)
                                            {
                                                resultadoAutomatico.Add(new HoraExcel { Hora = i, Minuto = 30, Valor = child.Automatico, IdEquipo = id });
                                            }

                                            resultadoAutomatico.Add(new HoraExcel { Hora = i, Minuto = minutoFin, Valor = child.Automatico, IdEquipo = id });
                                        }
                                    }
                                }
                                else
                                {
                                    resultadoAutomatico.Add(new HoraExcel { Hora = i, Minuto = 0, Valor = child.Automatico, IdEquipo = id });
                                    resultadoAutomatico.Add(new HoraExcel { Hora = i, Minuto = 30, Valor = child.Automatico, IdEquipo = id });
                                }
                            }
                        }

                        foreach (RsfItemModel child in listItemsManual)
                        {
                            int horaInicio = child.HoraInicio.Hour;
                            int minutoInicio = child.HoraInicio.Minute;
                            int horaFin = child.HoraFin.Hour;
                            int minutoFin = child.HoraFin.Minute;

                            for (int i = horaInicio; i <= horaFin; i++)
                            {
                                if (i == horaInicio || i == horaFin)
                                {
                                    if (i == horaInicio)
                                    {
                                        if (i != 0 || minutoInicio != 0)
                                            resultadoManual.Add(new HoraExcel { Hora = i, Minuto = minutoInicio, Valor = child.Manual, IdEquipo = id });

                                        if (minutoInicio == 0 && horaInicio != horaFin)
                                        {
                                            resultadoManual.Add(new HoraExcel { Hora = i, Minuto = 30, Valor = child.Manual, IdEquipo = id });
                                        }
                                    }
                                    if (i == horaFin)
                                    {
                                        if (horaInicio != horaFin)
                                        {
                                            resultadoManual.Add(new HoraExcel { Hora = i, Minuto = 0, Valor = child.Manual, IdEquipo = id });
                                        }
                                        if (minutoFin != 0)
                                        {
                                            if (minutoFin > 30 && horaInicio != horaFin)
                                            {
                                                resultadoManual.Add(new HoraExcel { Hora = i, Minuto = 30, Valor = child.Manual, IdEquipo = id });
                                            }

                                            resultadoManual.Add(new HoraExcel { Hora = i, Minuto = minutoFin, Valor = child.Manual, IdEquipo = id });
                                        }
                                    }
                                }
                                else
                                {
                                    resultadoManual.Add(new HoraExcel { Hora = i, Minuto = 0, Valor = child.Manual, IdEquipo = id });
                                    resultadoManual.Add(new HoraExcel { Hora = i, Minuto = 30, Valor = child.Manual, IdEquipo = id });
                                }
                            }
                        }
                    }
                    
                    List<HoraExcel> listAutomatico = (from itemAuto in resultadoAutomatico
                                                      orderby itemAuto.Hora, itemAuto.Minuto
                                                      select new HoraExcel { Hora = itemAuto.Hora, Minuto = itemAuto.Minuto }).Distinct().ToList();

                    List<HoraExcel> listManual = (from itemManual in resultadoManual
                                                  orderby itemManual.Hora, itemManual.Minuto
                                                  select new HoraExcel { Hora = itemManual.Hora, Minuto = itemManual.Minuto }).Distinct().ToList();

                    
                    foreach (HoraExcel item in listAutomatico)
                    {
                        if (horaExcel.Where(x => x.Hora == item.Hora && x.Minuto == item.Minuto).Count() == 0)
                        {
                            horaExcel.Add(new HoraExcel { Hora = item.Hora, Minuto = item.Minuto });
                        }
                    }

                    foreach (HoraExcel item in listManual)
                    {
                        if (horaExcel.Where(x => x.Hora == item.Hora && x.Minuto == item.Minuto).Count() == 0)
                        {
                            horaExcel.Add(new HoraExcel { Hora = item.Hora, Minuto = item.Minuto });
                        }
                    }

                    List<HoraExcel> listHora = (from hora in horaExcel orderby hora.Hora, hora.Minuto select hora).ToList();

                    #endregion
                                       
                    List<int> idsAutomatico = (from registro in resultadoAutomatico select registro.IdEquipo).Distinct().ToList();
                    List<int> idsManual = (from registro in resultadoManual select registro.IdEquipo).Distinct().ToList();
                                        
                    int indice = 0;
                    int column = 2;
                    int row = 8;
                    
                    foreach (HoraExcel item in listHora)
                    {
                        ws.Cells[row, column].Value = item.Hora.ToString().PadLeft(2, '0') + ":" + item.Minuto.ToString().PadLeft(2, '0');
                        ws.Cells[row, column].StyleID = ws.Cells[8, 2].StyleID;
                        row++;
                    }

                    column++;
                    foreach (int id in idsAutomatico)
                    {
                        RsfModel itemAutomatico = list.Where(x => x.IdEquipo == id).First();
                        ws.Cells[3, column].Value = "AUT";
                        ws.Cells[4, column].Value = itemAutomatico.DesURS;
                        ws.Cells[5, column].Value = itemAutomatico.Empresa;
                        ws.Cells[6, column].Value = itemAutomatico.Central;
                        ws.Cells[7, column].Value = itemAutomatico.Equipo;

                        ws.Cells[4, column].StyleID = ws.Cells[4, 2].StyleID;
                        ws.Cells[5, column].StyleID = ws.Cells[4, 2].StyleID;
                        ws.Cells[6, column].StyleID = ws.Cells[4, 2].StyleID;
                        ws.Cells[7, column].StyleID = ws.Cells[4, 2].StyleID;

                        row = 8;
                        foreach (HoraExcel item in listHora)
                        {
                            HoraExcel child = resultadoAutomatico.Where(x => x.Hora == item.Hora && x.Minuto == item.Minuto && x.IdEquipo == id).FirstOrDefault();
                            if (child != null)
                            {
                                ws.Cells[row, column].Value = child.Valor.ToString();
                               
                            }
                            ws.Cells[row, column].StyleID = ws.Cells[8, 2].StyleID;
                            row++;
                        }

                        column++;
                    }

                    foreach (int id in idsManual)
                    {
                        RsfModel itemManual = list.Where(x => x.IdEquipo == id).First();
                        ws.Cells[3, column].Value = "MAN";
                        ws.Cells[4, column].Value = itemManual.DesURS;
                        ws.Cells[5, column].Value = itemManual.Empresa;
                        ws.Cells[6, column].Value = itemManual.Central;
                        ws.Cells[7, column].Value = itemManual.Equipo;

                        ws.Cells[4, column].StyleID = ws.Cells[4, 2].StyleID;
                        ws.Cells[5, column].StyleID = ws.Cells[4, 2].StyleID;
                        ws.Cells[6, column].StyleID = ws.Cells[4, 2].StyleID;
                        ws.Cells[7, column].StyleID = ws.Cells[4, 2].StyleID;

                        row = 8;
                        foreach (HoraExcel item in listHora)
                        {
                            HoraExcel child = resultadoManual.Where(x => x.Hora == item.Hora && x.Minuto == item.Minuto && x.IdEquipo == id).FirstOrDefault();
                            if (child != null)
                            {
                                ws.Cells[row, column].Value = child.Valor.ToString();
                                
                            }
                            ws.Cells[row, column].StyleID = ws.Cells[8, 2].StyleID;
                            row++;
                        }
                        column++;
                    }

                    indice++;

                }

                xlPackage.Save();
            }
        }

        public static void GenerarArchivoTotal(List<IeodCuadroDTO> list, string fechaInicio, string fechaFin) 
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteEvento].ToString();
            FileInfo template = new FileInfo(ruta + Constantes.PlantillaExcelReporteRSF);
            FileInfo newFile = new FileInfo(ruta + Constantes.NombreReporteRSFGeneral);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + Constantes.NombreReporteRSFGeneral);
            }            
           
            int row = 5;
            int column = 2;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                ws.Cells[2, 3].Value = fechaInicio;
                ws.Cells[2, 5].Value = fechaFin;

                if (list.Count > 0)
                {
                    foreach (IeodCuadroDTO item in list)
                    {
                        string[] hora = item.HORA.Split('-');
                        ws.Cells[row, column].Value = item.FECHA;
                        ws.Cells[row, column + 1].Value = hora[0];
                        ws.Cells[row, column + 2].Value = hora[1];
                        ws.Cells[row, column + 3].Value = item.RUS;
                        ws.Cells[row, column + 4].Value = item.ICVALOR1.ToString(Constantes.FormatoNumero);
                        ws.Cells[row, column + 5].Value = item.TIPO;

                        if (row > 5)
                        { 
                            ws.Cells[row, column].StyleID = ws.Cells[5, column].StyleID;
                            ws.Cells[row, column + 1].StyleID = ws.Cells[5, column].StyleID;
                            ws.Cells[row, column + 2].StyleID = ws.Cells[5, column].StyleID;
                            ws.Cells[row, column + 3].StyleID = ws.Cells[5, column].StyleID;
                            ws.Cells[row, column + 4].StyleID = ws.Cells[5, column].StyleID;
                            ws.Cells[row, column + 5].StyleID = ws.Cells[5, column].StyleID;
                        }

                        row++;
                    }
                }

                xlPackage.Save();
            }
        }
    }

    /// <summary>
    /// Clase para manejar las horas de la exportación
    /// </summary>
    public class HoraExcel
    {
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public decimal Valor { get; set; }
        public int IdEquipo { get; set; }

        public List<HoraExcel> ListaHoras()
        {
            List<HoraExcel> list = new List<HoraExcel>();
            list.Add(new HoraExcel { Hora = 0, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 1, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 1, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 2, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 2, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 3, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 3, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 4, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 4, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 5, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 5, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 6, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 6, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 7, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 7, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 8, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 8, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 9, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 9, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 10, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 10, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 11, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 11, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 12, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 12, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 13, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 13, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 14, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 14, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 15, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 15, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 16, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 16, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 17, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 17, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 18, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 18, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 19, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 19, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 20, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 20, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 21, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 21, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 22, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 22, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 23, Minuto = 0 });
            list.Add(new HoraExcel { Hora = 23, Minuto = 30 });
            list.Add(new HoraExcel { Hora = 0, Minuto = 0 });     

            return list;
        
        }
    }
}