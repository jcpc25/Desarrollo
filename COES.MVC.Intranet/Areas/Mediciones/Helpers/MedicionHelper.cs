using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Helper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Mediciones.Helpers
{
    public class MedicionHelper
    {
        /// <summary>
        /// Permite obtener la configuracion del RPF
        /// </summary>
        //ConfiguracionRPD configuracion = new ConfiguracionRPD();

        /// <summary>
        /// Lee los artículos desde el formato excel cargado
        /// </summary>
        /// <param name="codCliente"></param>
        /// <returns></returns>
        public List<DesviacionDTO> LeerDesdeFormato(string file)
        {
            try
            {
                List<DesviacionDTO> list = new List<DesviacionDTO>();

                int cantidad = 60;
                Debug.WriteLine("LeerFormato");
                FileInfo fileInfo = new FileInfo(file);
                
                using (ExcelPackage xlPackage = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets["DESV-SUB-SOB"];

                    for (int i = 6; i <= cantidad; i++)
                    {

                        for (int j = 1; j <= 3; j++)
                        {
                            if (ws.Cells[i, j*4+1].Value != null && ws.Cells[i, j*4+1].Value != string.Empty)
                            {
                                DesviacionDTO item = new DesviacionDTO();

                                item.Lectcodi = 4;
                                item.Medorigdesv = (ws.Cells[i, j*4 + 1] != null) ? int.Parse(ws.Cells[i, j*4 + 1].ToString()) : 0;
                                item.Desvfecha = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                item.Ptomedicodi = int.Parse(ws.Cells[i, j*4 + 4].ToString());


                                list.Add(item);
                            }
                            else
                            {

                                //break;

                            }

                        }

                        
                    }

                    
    
                    
                }
                Debug.WriteLine("Fin leer");
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error"+ex.ToString());
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Permite generar el reporte rer
        /// </summary>
        public static void GenerarReporteRER(List<MeMedicion48DTO> listDatos, List<WbGeneracionrerDTO> list, int horizonte, 
            string empresa, DateTime fecha, int? semana, DateTime fechaInicio, DateTime fechaFin)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones].ToString();
            string fileTemplate = (horizonte == 0) ? NombreArchivo.PlantillaGeneracionRERDiario :
                NombreArchivo.PlantillaGeneracionRERSemanal;
            FileInfo template = new FileInfo(ruta + fileTemplate);

            FileInfo newFile = new FileInfo(ruta + NombreArchivo.ReporteGeneracionRER);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + NombreArchivo.ReporteGeneracionRER);
            }

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                //ws.Cells[2, 2].Value = empresa;

                if (horizonte == 0)
                {
                    ws.Cells[3, 2].Value = fecha.ToString(Constantes.FormatoFecha);
                }
                if (horizonte == 1)
                {
                    ws.Cells[3, 2].Value = semana.ToString();
                    ws.Cells[4, 2].Value = fechaInicio.ToString(Constantes.FormatoFecha);
                    ws.Cells[5, 2].Value = fechaFin.ToString(Constantes.FormatoFecha);
                }

                List<WbGeneracionrerDTO> listCentrales = list.Where(x => x.IndPorCentral == Constantes.SI).ToList();
                List<WbGeneracionrerDTO> listUnidades = list.Where(x => x.IndPorCentral == Constantes.NO).ToList();

                int row = 8;
                int column = 2;

                foreach (WbGeneracionrerDTO item in listCentrales)
                {                   
                    ws.Cells[row, column].Value = item.Ptomedicodi.ToString();
                    ws.Cells[row + 1, column].Value = item.EmprNomb.ToString();
                    ws.Cells[row + 2, column].Value = item.Central;
                    ws.Cells[row + 3, column].Value = Constantes.TextoCentral;
                    ws.Cells[row + 4, column].Value = Constantes.TextoMW;

                    ws.Cells[row, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 1, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 2, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 3, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 4, column].StyleID = ws.Cells[row, 1].StyleID;
                    column++;
                }

                List<int> ids = listUnidades.Select(x => x.CentralCodi).Distinct().ToList();

                foreach (int id in ids)
                {
                    List<WbGeneracionrerDTO> listUnidad = listUnidades.Where(x => x.CentralCodi == id).ToList();

                    foreach (WbGeneracionrerDTO item in listUnidad)
                    {
                        ws.Cells[row, column].Value = item.Ptomedicodi.ToString();
                        ws.Cells[row + 1, column].Value = item.EmprNomb.ToString();                        
                        ws.Cells[row + 2, column].Value = item.Central;
                        ws.Cells[row + 3, column].Value = item.EquiNomb;
                        ws.Cells[row + 4, column].Value = Constantes.TextoMW;

                        ws.Cells[row, column].StyleID = ws.Cells[row, 1].StyleID;
                        ws.Cells[row + 1, column].StyleID = ws.Cells[row, 1].StyleID;
                        ws.Cells[row + 2, column].StyleID = ws.Cells[row, 1].StyleID;
                        ws.Cells[row + 3, column].StyleID = ws.Cells[row, 1].StyleID;
                        ws.Cells[row + 4, column].StyleID = ws.Cells[row, 1].StyleID;
                        column++;
                    }
                }
                               
                row = row + 5;
                int countDia = (horizonte == 0) ? 1 : 7;
                int minuto = 0;

                for (int i = 0; i < countDia; i++)
                {
                    for (int k = 1; k <= 48; k++)
                    {
                        column = 1;
                        ws.Cells[row, column].Value = fechaInicio.AddMinutes(minuto).ToString(Constantes.FormatoFechaHora);
                        minuto = minuto + 30;
                        column++;

                        foreach (WbGeneracionrerDTO item in listCentrales)
                        {
                            if (listDatos.Where(x => x.Ptomedicodi == item.Ptomedicodi).Count() > i)
                            {
                                MeMedicion48DTO entity = listDatos.Where(x => x.Ptomedicodi == item.Ptomedicodi).ToList()[i];
                                ws.Cells[row, column].Value = entity.GetType().GetProperty("H" + k).GetValue(entity, null).ToString();
                            }

                            ws.Cells[row, column].StyleID = ws.Cells[row, 2].StyleID;
                            column++;
                        }

                        foreach (int id in ids)
                        {
                            List<WbGeneracionrerDTO> listUnidad = listUnidades.Where(x => x.CentralCodi == id).ToList();

                            foreach (WbGeneracionrerDTO item in listUnidad)
                            {
                                if (listDatos.Where(x => x.Ptomedicodi == item.Ptomedicodi).Count() > i)
                                {
                                    MeMedicion48DTO entity = listDatos.Where(x => x.Ptomedicodi == item.Ptomedicodi).ToList()[i];
                                    ws.Cells[row, column].Value = entity.GetType().GetProperty("H" + k).GetValue(entity, null).ToString();
                                }

                                ws.Cells[row, column].StyleID = ws.Cells[row, 2].StyleID;
                                column++;
                            }
                        }
                        row++;
                    }
                }

                xlPackage.Save();
            }
        }


        /// <summary>
        /// Permite generar el reporte rer
        /// </summary>
        public static void GenerarReporteRERPorCentral(List<MeMedicion48DTO> listDatos, List<WbGeneracionrerDTO> list, int horizonte,
            string empresa, DateTime fecha, int? semana, DateTime fechaInicio, DateTime fechaFin)
        {
            string ruta = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones].ToString();
            string fileTemplate = (horizonte == 0) ? NombreArchivo.PlantillaGeneracionRERDiario :
                NombreArchivo.PlantillaGeneracionRERSemanal;
            FileInfo template = new FileInfo(ruta + fileTemplate);

            FileInfo newFile = new FileInfo(ruta + NombreArchivo.ReporteGeneracionRER);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(ruta + NombreArchivo.ReporteGeneracionRER);
            }

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                if (horizonte == 0)
                {
                    ws.Cells[3, 2].Value = fecha.ToString(Constantes.FormatoFecha);
                }
                if (horizonte == 1)
                {
                    ws.Cells[3, 2].Value = semana.ToString();
                    ws.Cells[4, 2].Value = fechaInicio.ToString(Constantes.FormatoFecha);
                    ws.Cells[5, 2].Value = fechaFin.ToString(Constantes.FormatoFecha);
                }

                List<WbGeneracionrerDTO> listCentrales = list.Where(x => x.IndPorCentral == Constantes.SI).ToList();
                List<WbGeneracionrerDTO> listUnidades = list.Where(x => x.IndPorCentral == Constantes.NO).ToList();

                int row = 8;
                int column = 2;

                foreach (WbGeneracionrerDTO item in listCentrales)
                {
                    //ws.Cells[row, column].Value = item.Ptomedicodi.ToString();
                    ws.Cells[row + 1, column].Value = item.EmprNomb.ToString();
                    ws.Cells[row + 2, column].Value = item.Central;
                    ws.Cells[row + 3, column].Value = Constantes.TextoCentral;
                    ws.Cells[row + 4, column].Value = Constantes.TextoMW;

                    //ws.Cells[row, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 1, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 2, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 3, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 4, column].StyleID = ws.Cells[row, 1].StyleID;
                    column++;
                }
                               

                List<int> ids = listUnidades.Select(x => x.CentralCodi).Distinct().ToList();

                foreach (int id in ids)
                {
                    WbGeneracionrerDTO central = listUnidades.Where(x => x.CentralCodi == id).FirstOrDefault();
                                        
                    ws.Cells[row + 1, column].Value = central.EmprNomb.ToString();
                    ws.Cells[row + 2, column].Value = central.Central;
                    ws.Cells[row + 3, column].Value = Constantes.TextoCentral;
                    ws.Cells[row + 4, column].Value = Constantes.TextoMW;

                    
                    ws.Cells[row + 1, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 2, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 3, column].StyleID = ws.Cells[row, 1].StyleID;
                    ws.Cells[row + 4, column].StyleID = ws.Cells[row, 1].StyleID;
                    column++;

                }

                row = row + 5;
                int countDia = (horizonte == 0) ? 1 : 7;
                int minuto = 0;

                for (int i = 0; i < countDia; i++)
                {
                    for (int k = 1; k <= 48; k++)
                    {
                        column = 1;
                        ws.Cells[row, column].Value = fechaInicio.AddMinutes(minuto).ToString(Constantes.FormatoFechaHora);
                        minuto = minuto + 30;
                        column++;

                        foreach (WbGeneracionrerDTO item in listCentrales)
                        {
                            if (listDatos.Where(x => x.Ptomedicodi == item.Ptomedicodi).Count() > i)
                            {
                                MeMedicion48DTO entity = listDatos.Where(x => x.Ptomedicodi == item.Ptomedicodi).ToList()[i];
                                ws.Cells[row, column].Value = entity.GetType().GetProperty("H" + k).GetValue(entity, null).ToString();
                            }

                            ws.Cells[row, column].StyleID = ws.Cells[row, 2].StyleID;
                            column++;
                        }

                        foreach (int id in ids)
                        {
                            List<WbGeneracionrerDTO> listUnidad = listUnidades.Where(x => x.CentralCodi == id).ToList();

                            decimal suma = 0;
                            bool flag = false;

                            foreach (WbGeneracionrerDTO item in listUnidad)
                            {
                                if (listDatos.Where(x => x.Ptomedicodi == item.Ptomedicodi).Count() > i)
                                {
                                    MeMedicion48DTO entity = listDatos.Where(x => x.Ptomedicodi == item.Ptomedicodi).ToList()[i];
                                    suma = suma + (decimal)(entity.GetType().GetProperty("H" + k).GetValue(entity, null));
                                    flag = true;
                                }                              
                            }

                            if (flag)
                            {
                                ws.Cells[row, column].Value = suma.ToString();
                            }

                            ws.Cells[row, column].StyleID = ws.Cells[row, 2].StyleID;
                            column++;
                        }
                        row++;
                    }
                }

                ws.Row(8).Hidden = true;
                ws.Row(7).Hidden = true;

                xlPackage.Save();
            }
        }



    }
}