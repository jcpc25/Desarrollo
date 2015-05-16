using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using System.Linq;
using log4net;
using System.Text;
using System.IO;
using OfficeOpenXml;
using System.Net;
using OfficeOpenXml.Drawing;
using System.Globalization;
using OfficeOpenXml.Style;
using System.Drawing;


namespace COES.Servicios.Aplicacion.Mediciones
{
    public class ConsultaMedidoresAppServicio: AppServicioBase
    {
        ExcelPackage xlPackage = null;

        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ConsultaMedidoresAppServicio));

        /// <summary>
        /// Lista los tipos de generación
        /// </summary>
        /// <returns></returns>
        public List<SiTipogeneracionDTO> ListaTipoGeneracion()
        {
            return FactorySic.GetSiTipogeneracionRepository().GetByCriteria().Where(x => x.Tgenercodi != -1 && x.Tgenercodi != 0 && x.Tgenercodi != 5).ToList();
        }

        /// <summary>
        /// Permite listar los tipos de empresas
        /// </summary>
        /// <returns></returns>
        public List<SiTipoempresaDTO> ListaTipoEmpresas()
        {
            return FactorySic.GetSiTipoempresaRepository().List();
        }

        /// <summary>
        /// Lista las fuentes de energía
        /// </summary>
        /// <returns></returns>
        public List<SiFuenteenergiaDTO> ListaFuenteEnergia()
        {
            return FactorySic.GetSiFuenteenergiaRepository().GetByCriteria().Where(x => x.Fenergcodi != -1 && x.Fenergcodi != 0).ToList();
        }

        /// <summary>
        /// Permite listar las empresas
        /// </summary>
        /// <returns></returns>
        public List<SiEmpresaDTO> ListaEmpresa()
        {
            return FactorySic.GetSiEmpresaRepository().ObtenerEmpresasSEIN();
        }

        /// <summary>
        /// Permite obtener las empresa por tipo
        /// </summary>
        /// <returns></returns>
        public List<SiEmpresaDTO> ObteneEmpresasPorTipo(string tiposEmpresa)
        {
            if (string.IsNullOrEmpty(tiposEmpresa)) tiposEmpresa = Constantes.ParametroDefecto;
            return FactorySic.GetSiEmpresaRepository().GetByCriteria(tiposEmpresa);
        }

        /// <summary>
        /// Permite obtener la lista de la consulta
        /// </summary>       
        public List<MeMedicion96DTO> ObtenerConsultaMedidores(DateTime fecInicio,DateTime  fecFin, string tiposEmpresa, string empresas,
            string tiposGeneracion, int central, int parametro, int nroPagina, int nroRegistros, out List<MeMedicion96DTO> sumatoria)
        {                        
            if (tiposEmpresa != Constantes.ParametroDefecto && empresas == Constantes.ParametroDefecto)
            {
                List<int> idsEmpresas = this.ObteneEmpresasPorTipo(tiposEmpresa).Select(x=>x.Emprcodi).ToList();
                empresas = string.Join<int>(Constantes.CaracterComa.ToString(), idsEmpresas);
            }

            List<MeMedicion96DTO> entitys = null;
            sumatoria = null;

            int tipoInformacion = 0;

            if (parametro == 1 || parametro == 2)
            {
                tipoInformacion = parametro;
                entitys = FactorySic.GetMeMedicion96Repository().ObtenerConsultaMedidores(tipoInformacion, empresas, central, 
                    tiposGeneracion, fecInicio, fecFin, nroPagina, nroRegistros);
                sumatoria = FactorySic.GetMeMedicion96Repository().ObtenerTotalConsultaMedidores(tipoInformacion, empresas, central,
                    tiposGeneracion, fecInicio, fecFin);
            }
            if (parametro == 3)
            {
                tipoInformacion = 1;
                string[] codigos = tiposGeneracion.Split(Constantes.CaracterComa);
                string fuentes = string.Empty;

                foreach (string item in codigos)
                {
                    int id = int.Parse(item);
                    if (id == 1)
                    {
                        if(!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 20.ToString();
                        else fuentes = fuentes + 20.ToString();
                    }
                    else if (id == 2)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 21.ToString();
                        else fuentes = fuentes + 21.ToString();
                    }
                    else if (id == 3)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 22.ToString();
                        else fuentes = fuentes + 22.ToString();
                    }
                    else if (id == 4)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 23.ToString();
                        else fuentes = fuentes + 23.ToString();
                    }
                }

                if (string.IsNullOrEmpty(fuentes)) fuentes = Constantes.ParametroDefecto;

                entitys = FactorySic.GetMeMedicion96Repository().ObtenerConsultaServiciosAuxiliares(tipoInformacion, empresas, central,
                    fuentes, fecInicio, fecFin, nroPagina, nroRegistros);
                sumatoria = FactorySic.GetMeMedicion96Repository().ObtenerTotalServiciosAuxiliares(tipoInformacion, empresas, central,
                    fuentes, fecInicio, fecFin);
            }

            return entitys;
        }

        /// <summary>
        /// Obtiene el número de registros de la consulta
        /// </summary>
        /// <param name="fecInicio"></param>
        /// <param name="fecFin"></param>
        /// <param name="empresas"></param>
        /// <param name="tiposGeneracion"></param>
        /// <param name="central"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public int ObtenerNroRegistroConsultaMedidores(DateTime fecInicio, DateTime fecFin, string tiposEmpresa, string empresas,
            string tiposGeneracion, int central, int parametro)
        {
            if (tiposEmpresa != Constantes.ParametroDefecto && empresas == Constantes.ParametroDefecto)
            {
                List<int> idsEmpresas = this.ObteneEmpresasPorTipo(tiposEmpresa).Select(x => x.Emprcodi).ToList();
                empresas = string.Join<int>(Constantes.CaracterComa.ToString(), idsEmpresas);
            }

            int count = 0;

            int tipoInformacion = 0;

            if (parametro == 1 || parametro == 2)
            {
                tipoInformacion = parametro;
                count  = FactorySic.GetMeMedicion96Repository().ObtenerNroElementosConsultaMedidores(tipoInformacion, empresas, central,
                    tiposGeneracion, fecInicio, fecFin);
            }
            if (parametro == 3)
            {
                tipoInformacion = 1;
                string[] codigos = tiposGeneracion.Split(Constantes.CaracterComa);
                string fuentes = string.Empty;

                foreach (string item in codigos)
                {
                    int id = int.Parse(item);
                    if (id == 1)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 20.ToString();
                        else fuentes = fuentes + 20.ToString();
                    }
                    else if (id == 2)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 21.ToString();
                        else fuentes = fuentes + 21.ToString();
                    }
                    else if (id == 3)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 22.ToString();
                        else fuentes = fuentes + 22.ToString();
                    }
                    else if (id == 4)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 23.ToString();
                        else fuentes = fuentes + 23.ToString();
                    }

                }

                if (string.IsNullOrEmpty(fuentes)) fuentes = Constantes.ParametroDefecto;

                count = FactorySic.GetMeMedicion96Repository().ObtenerNroElementosServiciosAuxiliares(tipoInformacion, empresas, central,
                    fuentes, fecInicio, fecFin);
            }

            return count;
        }
                     

        /// <summary>
        /// Permite generar el formato horizontal
        /// </summary>
        /// <param name="fecInicio"></param>
        /// <param name="fecFin"></param>
        /// <param name="empresas"></param>
        /// <param name="tiposGeneracion"></param>
        /// <param name="central"></param>
        /// <param name="parametros"></param>
        public void GenerarArchivoExportacion(DateTime fecInicio, DateTime fecFin, string tiposEmpresa, string empresas,
            string tiposGeneracion, int central, string parametros, string path, string file, int formato, bool flag)
        {
            try
            {
                #region Acceso a datos

                if (tiposEmpresa != Constantes.ParametroDefecto && empresas == Constantes.ParametroDefecto)
                {
                    List<int> idsEmpresas = this.ObteneEmpresasPorTipo(tiposEmpresa).Select(x => x.Emprcodi).ToList();
                    empresas = string.Join<int>(Constantes.CaracterComa.ToString(), idsEmpresas);
                }

                string[] codigos = tiposGeneracion.Split(Constantes.CaracterComa);
                string fuentes = string.Empty;

                foreach (string item in codigos)
                {
                    int id = int.Parse(item);
                    if (id == 1)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 20.ToString();
                        else fuentes = fuentes + 20.ToString();
                    }
                    else if (id == 2)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 21.ToString();
                        else fuentes = fuentes + 21.ToString();
                    }
                    else if (id == 3)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 22.ToString();
                        else fuentes = fuentes + 22.ToString();
                    }
                    else if (id == 4)
                    {
                        if (!string.IsNullOrEmpty(fuentes)) fuentes = fuentes + Constantes.CaracterComa.ToString() + 23.ToString();
                        else fuentes = fuentes + 23.ToString();
                    }
                }

                if (string.IsNullOrEmpty(fuentes)) fuentes = Constantes.ParametroDefecto;


                List<MeMedicion96DTO> listActiva = null;
                List<MeMedicion96DTO> listReactiva = null;
                List<MeMedicion96DTO> listServiciosAuxiliares = null;

                List<MeMedicion96DTO> listCSV = null;

                if (string.IsNullOrEmpty(parametros))
                {
                    listActiva = FactorySic.GetMeMedicion96Repository().ObtenerExportacionConsultaMedidores(1, empresas, central,
                        tiposGeneracion, fecInicio, fecFin);

                    listReactiva = FactorySic.GetMeMedicion96Repository().ObtenerExportacionConsultaMedidores(2, empresas, central,
                        tiposGeneracion, fecInicio, fecFin);

                    listServiciosAuxiliares = FactorySic.GetMeMedicion96Repository().ObtenerExportacionServiciosAuxiliares(1, empresas, central,
                        fuentes, fecInicio, fecFin);
                }
                else
                {
                    string[] lecturas = parametros.Split(Constantes.CaracterComa);

                    foreach (string item in lecturas)
                    {
                        int id = int.Parse(item);

                        if (formato == 1 || formato == 2)
                        {
                            if (id == 1)
                            {
                                listActiva = FactorySic.GetMeMedicion96Repository().ObtenerExportacionConsultaMedidores(1, empresas, central,
                                    tiposGeneracion, fecInicio, fecFin);
                            }
                            if (id == 2)
                            {
                                listReactiva = FactorySic.GetMeMedicion96Repository().ObtenerExportacionConsultaMedidores(2, empresas, central,
                                     tiposGeneracion, fecInicio, fecFin);
                            }
                            if (id == 3)
                            {
                                listServiciosAuxiliares = FactorySic.GetMeMedicion96Repository().ObtenerExportacionServiciosAuxiliares(1, empresas, central,
                                    fuentes, fecInicio, fecFin);
                            }
                        }
                        if (formato == 3)
                        {
                            if (id == 1)
                            {
                                listCSV = FactorySic.GetMeMedicion96Repository().ObtenerExportacionMasivaMedidores(1, empresas, central,
                                    tiposGeneracion, fecInicio, fecFin);
                            }
                            if (id == 2)
                            {
                                listCSV = FactorySic.GetMeMedicion96Repository().ObtenerExportacionMasivaMedidores(2, empresas, central,
                                        tiposGeneracion, fecInicio, fecFin);
                            }
                            if (id == 3)
                            {
                                listCSV = FactorySic.GetMeMedicion96Repository().ObtenerExportacionMasivaSSAA(1, empresas, central,
                                        fuentes, fecInicio, fecFin);
                            }
                        }
                    }
                }

                #endregion

                #region Generación de Archivo

                file = path + file;
                FileInfo newFile = new FileInfo(file);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(file);
                }


                if (formato == 1)
                {
                    using (xlPackage = new ExcelPackage(newFile))
                    {
                        if (listActiva != null)
                        {
                            this.CreaHojaHorizontal("ACTIVA (MW)", listActiva, fecInicio.ToString("dd/MM/yyyy"),
                                fecFin.ToString("dd/MM/yyyy"), "REGISTROS DE MEDIDORES EN BORNES DE GENERACIÓN CADA 15 MINUTOS DE POTENCIA ACTIVA (MW)", 1, flag);
                        }
                        if (listReactiva != null)
                        {
                            this.CreaHojaHorizontal("REACTIVA (MVAR)", listReactiva, fecInicio.ToString("dd/MM/yyyy"),
                                    fecFin.ToString("dd/MM/yyyy"), "REGISTROS DE MEDIDORES EN BORNES DE GENERACIÓN CADA 15 MINUTOS DE POTENCIA REACTIVA (MVAR)", 2, flag);
                        }
                        if (listServiciosAuxiliares != null)
                        {
                            this.CreaHojaHorizontal("SERV. AUX. (MW)", listServiciosAuxiliares, fecInicio.ToString("dd/MM/yyyy"),
                                fecFin.ToString("dd/MM/yyyy"), "REGISTROS DE MEDIDORES EN BORNES DE GENERACIÓN CADA 15 MINUTOS DE LOS SERVICIOS AUXILIARES (MW)", 3, flag);
                        }
                        xlPackage.Save();
                    }

                }

                if (formato == 2)
                {
                    using (xlPackage = new ExcelPackage(newFile))
                    {
                        if (listActiva != null)
                        {
                            this.CreaHojaVertical("ACTIVA (MW)", listActiva, fecInicio.ToString("dd/MM/yyyy"),
                                fecFin.ToString("dd/MM/yyyy"), "REGISTROS DE MEDIDORES EN BORNES DE GENERACIÓN CADA 15 MINUTOS DE POTENCIA ACTIVA (MW)", 1, flag);
                        }
                        if (listReactiva != null)
                        {
                            this.CreaHojaVertical("REACTIVA (MVAR)", listReactiva, fecInicio.ToString("dd/MM/yyyy"),
                                    fecFin.ToString("dd/MM/yyyy"), "REGISTROS DE MEDIDORES EN BORNES DE GENERACIÓN CADA 15 MINUTOS DE POTENCIA REACTIVA (MVAR)", 2, flag);
                        }
                        if (listServiciosAuxiliares != null)
                        {
                            this.CreaHojaVertical("SERV. AUX. (MW)", listServiciosAuxiliares, fecInicio.ToString("dd/MM/yyyy"),
                                fecFin.ToString("dd/MM/yyyy"), "REGISTROS DE MEDIDORES EN BORNES DE GENERACIÓN CADA 15 MINUTOS DE LOS SERVICIOS AUXILIARES (MW)", 3, flag);
                        }
                        xlPackage.Save();
                    }
                }

                if (formato == 3)
                {
                    if (listCSV != null)
                    {
                        this.CreaFormatoCSV(listCSV, fecInicio, fecFin, file);
                    }
                }


                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #region Creación de hojas excel
        
        /// <summary>
        /// Crea la hoja con los datos a exportar
        /// </summary>
        /// <param name="hojaName"></param>
        /// <param name="list"></param>
        protected void CreaHojaHorizontal(string hojaName, List<MeMedicion96DTO> list, string fechaInicio, string fechaFin, string titulo, int tipo, bool flag)
        {
            ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add(hojaName);

            if (ws != null)
            {
                ws.Cells[5, 2].Value = titulo;

                ExcelRange rg = ws.Cells[5, 2, 5, 2];                
                rg.Style.Font.Size = 13;
                rg.Style.Font.Bold = true;

                ws.Cells[7, 2].Value = "Desde:";
                ws.Cells[7, 3].Value = fechaInicio;
                ws.Cells[8, 2].Value = "Hasta:";
                ws.Cells[8, 3].Value = fechaFin;

                ws.Cells[10, 2].Value = "FECHA";
                ws.Cells[10, 3].Value = "PUNTO MEDICIÓN";
                ws.Cells[10, 4].Value = "EMPRESA";
                ws.Cells[10, 5].Value = "CENTRAL";
                ws.Cells[10, 6].Value = "UNIDAD";

                string header = string.Empty;
                if (tipo == 1) header = "TOTAL ENERGIA ACTIVA  (MWh)";
                if (tipo == 2) header = "TOTAL ENERGÍA REACTIVA (MVarh)";
                if (tipo == 3) header = "TOTAL SERVICIOS AUXILIARES (MWh)"; 

                ws.Cells[10, 7].Value = header;

                DateTime now = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                for (int i = 1; i <= 96; i++)
                {
                    DateTime fecColumna = now.AddMinutes(15 * i);
                    ws.Cells[10, 7 + i].Value = fecColumna.ToString("HH:mm");                    
                }

                rg = ws.Cells[10, 2, 10, 103];
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;


                int row = 11;     
           
                foreach (MeMedicion96DTO item in list)
                {
                    ws.Cells[row, 2].Value = ((DateTime)item.Medifecha).ToString("dd/MM/yyyy");
                    ws.Cells[row, 3].Value = item.Ptomedicodi;
                    ws.Cells[row, 4].Value = item.Emprnomb;
                    ws.Cells[row, 5].Value = item.Central;
                    ws.Cells[row, 6].Value = item.Equinomb;

                    ws.Cells[row, 7].Formula = "=SUM(" + this.ObtenerColumnNumber(row, 8) + ":" + this.ObtenerColumnNumber(row, 103) + ")/4";

                    for (int k = 1; k <= 96; k++)
                    {
                        object resultado = item.GetType().GetProperty("H" + k).GetValue(item, null);
                        if (resultado != null)
                        { 
                            ws.Cells[row, 7 + k].Value = Convert.ToDecimal(resultado);
                        }
                    }                    

                    rg = ws.Cells[row, 2, row, 103];

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

                ws.Column(2).Style.Numberformat.Format = "dd/MM/yyyy";

                for (int t = 7; t <= 103; t++)
                {
                    ws.Column(t).Style.Numberformat.Format = "#,##0.000";
                }


                string footer1 = string.Empty;
                string footer2 = string.Empty;
                string footer3 = string.Empty;

                if (tipo == 1) {
                    footer1 = "TOTAL ENERGÍA (MWh)";
                    footer2 = "TOTAL POTENCIA MÁXIMA (MW)";
                    footer3 = "TOTAL POTENCIA MÍNIMA (MW)";
                }
                if (tipo == 2) {
                    footer1 = "TOTAL ENERGÍA REACTIVA(MVarh)";
                    footer2 = "TOTAL POTENCIA REACTIVA MÁXIMA (MVAR)";
                    footer3 = "TOTAL POTENCIA REACTIVA MÍNIMA (MVAR)";
                }
                if (tipo == 3) {
                    footer1 = "TOTAL ENERGÍA SERV. AUX. (MWh)";
                    footer2 = "TOTAL POTENCIA MÁXIMA SERV. AUX. (MW)";
                    footer3 = "TOTAL POTENCIA MÍNIMA SERV. AUX. (MW)";
                }

                ws.Cells[row, 2].Value = footer1;
                rg = ws.Cells[row, 2, row, 6];
                rg.Merge = true;
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[row + 1, 2].Value = footer2;
                rg = ws.Cells[row + 1 , 2, row + 1, 6];
                rg.Merge = true;
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[row + 2, 2].Value = footer3;
                rg = ws.Cells[row + 2, 2, row + 2, 6];
                rg.Merge = true;
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                
                rg = ws.Cells[row, 2, row + 2, 103];
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

                ws.Cells[row, 7].Formula = "=SUM(" + this.ObtenerColumnNumber(11, 7) + ":" + this.ObtenerColumnNumber(11 + list.Count - 1, 7) + ")";

                for (int k = 1; k <= 96; k++)
                {
                    ws.Cells[row, 7 + k].Formula = "=SUM(" + this.ObtenerColumnNumber(11, 7 + k) + ":" + this.ObtenerColumnNumber(11 + list.Count - 1, 7 + k) + ")/4";
                    ws.Cells[row + 1, 7 + k].Formula = "=MAX(" + this.ObtenerColumnNumber(11, 7 + k) + ":" + this.ObtenerColumnNumber(11 + list.Count - 1, 7 + k) + ")";
                    ws.Cells[row + 2, 7 + k].Formula = "=MIN(" + this.ObtenerColumnNumber(11, 7 + k) + ":" + this.ObtenerColumnNumber(11 + list.Count - 1, 7 + k) + ")";
                }

                ws.Cells[row + 1, 7].Formula = "=MAX(" + this.ObtenerColumnNumber(row + 1, 8) + ":" + this.ObtenerColumnNumber(row + 1, 103) + ")";
                ws.Cells[row + 2, 7].Formula = "=MIN(" + this.ObtenerColumnNumber(row + 2, 8) + ":" + this.ObtenerColumnNumber(row + 2, 103) + ")";

                


                ws.Cells[1, 1].Value = "0";
                ws.Cells[1, 1].Style.Font.Color.SetColor(Color.White);



                ws.Cells[row + 4, 2].Value = "Leyenda";

                if (flag)
                {
                    ws.Cells[row + 6, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[row + 6, 2].Style.Fill.BackgroundColor.SetColor(Color.Red);
                    ws.Cells[row + 6, 3].Value = "Registros negativos";
                    ws.Cells[row + 8, 2].Value = "(*) Incluye a las centrales eléctricas RER No Adjudicadas (C.T. Maple Etanol y C.H. Pías I).";                    
                }
                else
                {
                    ws.Cells[row + 6, 2].Value = "(*) Incluye a las centrales eléctricas RER No Adjudicadas (C.T. Maple Etanol y C.H. Pías I)."; 

                }

                

                rg = ws.Cells[row + 4, 2, row + 8, 3];
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;
                rg.Style.Font.Color.SetColor(Color.Black);
                rg.Style.Font.Italic = true;

                rg = ws.Cells[1, 3, row + 2, 103];
                rg.AutoFitColumns();


                ws.View.FreezePanes(11, 8);


                if (flag)
                {

                    var cellAddress = new ExcelAddress(1, 1, list.Count + 20, 103);
                    var cf = ws.ConditionalFormatting.AddLessThan(cellAddress);
                    cf.Formula = "0";
                    cf.Style.Fill.BackgroundColor.Color = Color.Red;
                }


                
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
        }

        /// <summary>
        /// Permite crear la hoja con los datos verticales
        /// </summary>
        /// <param name="hojaName"></param>
        /// <param name="list"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="titulo"></param>
        protected void CreaHojaVertical(string hojaName, List<MeMedicion96DTO> list, string fechaInicio, string fechaFin, string titulo, int tipo, bool flag)
        {
            ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add(hojaName);

            if (ws != null)
            {
                ws.Cells[5, 2].Value = titulo;

                ExcelRange rg = ws.Cells[5, 2, 5, 2];
                rg.Style.Font.Size = 13;
                rg.Style.Font.Bold = true;

                ws.Cells[7, 2].Value = "Desde:";
                ws.Cells[7, 3].Value = fechaInicio;
                ws.Cells[8, 2].Value = "Hasta:";
                ws.Cells[8, 3].Value = fechaFin;

                int row = 10;
                int column = 4;

                ws.Cells[row, column - 2].Value = "FECHA/HORA";
                ws.Cells[row, column - 2, row + 3, column - 2].Merge = true;
                ws.Cells[row, column - 1].Value = "TOTAL";
                ws.Cells[row, column - 1, row + 2, column - 1].Merge = true;
                
                string header = string.Empty;
                if (tipo == 1) header = "MW";
                if (tipo == 2) header = "MVAR";
                if (tipo == 3) header = "MW";

                ws.Cells[row + 3, column - 1].Value = header;

                var listEmpresas = list.Select(m => new { m.Emprcodi, m.Emprnomb }).Distinct().OrderBy(x=>x.Emprnomb).ToList();

                DateTime fecha = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fecFin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                int dias = (int)(fecFin.Subtract(fecha).TotalDays);

                foreach (var empresa in listEmpresas)
                {
                    var listCentrales = list.Where(x => x.Emprcodi == empresa.Emprcodi).Select(m => new { m.Equipadre, m.Central, m.Emprcodi }).Distinct().ToList();

                    int countCentral = 0;
                    foreach (var central in listCentrales)
                    {
                       
                        var listEquipos = (central.Equipadre != 0) ? list.Where(x => x.Equipadre == central.Equipadre && x.Emprcodi == central.Emprcodi).
                            Select(m => new { m.Equicodi, m.Equinomb, m.Ptomedicodi }).Distinct().ToList() :
                        list.Where(x => x.Central == central.Central && x.Emprcodi == central.Emprcodi).
                            Select(m => new { m.Equicodi, m.Equinomb, m.Ptomedicodi }).Distinct().ToList();

                        int count = 0;
                        foreach (var equipo in listEquipos)
                        {
                            ws.Cells[row, column].Value = equipo.Ptomedicodi;
                            ws.Cells[row + 3, column].Value = equipo.Equinomb.Trim();
                            column++;
                            count++;
                            countCentral++;

                            List<MeMedicion96DTO> listDatos = list.Where(x => x.Ptomedicodi == equipo.Ptomedicodi).OrderBy(x => x.Medifecha).ToList();

                            int fila = 14;

                            if (listDatos.Count > 0)
                            {
                                int diferencia = (int)((DateTime)listDatos[0].Medifecha).Subtract(fecha).TotalDays;

                                for (int j = 0; j < diferencia; j++)
                                {
                                    for (int i = 1; i <= 96; i++)
                                    {
                                        fila++;
                                    }
                                }
                            }

                            foreach (MeMedicion96DTO dato in listDatos)
                            {
                                for (int i = 1; i <= 96; i++)
                                {
                                    object resultado = dato.GetType().GetProperty("H" + i).GetValue(dato, null);
                                    if (resultado != null)
                                    {
                                        ws.Cells[fila, column - 1].Value = Convert.ToDecimal(resultado);
                                    }

                                    fila++;
                                }
                            }
                        }

                        ws.Cells[row + 2, column - count].Value = central.Central.Trim();
                        ws.Cells[row + 2, column - count, row + 2, column - 1].Merge = true;
                    }

                    ws.Cells[row + 1, column - countCentral].Value = empresa.Emprnomb.Trim();
                    ws.Cells[row + 1, column - countCentral, row + 1, column - 1].Merge = true;
                }
                
                int k = row + 4;
                int t = 2;
                for (int i = 0; i < dias + 1; i++)
                {
                    for (int j = 1; j <= 96; j++)
                    {
                        ws.Cells[k, t].Value = fecha.AddDays(i).AddMinutes(j * 15).ToString("dd/MM/yyyy HH:mm");
                        ws.Cells[k, t + 1].Formula = "=SUM(" + this.ObtenerColumnNumber(k, t + 2) + ":" + this.ObtenerColumnNumber(k, column - 1) + ")";
                        k++;
                    }
                }

                rg = ws.Cells[row, 2, row + 3, column - 1];
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Left.Color.SetColor(Color.Gray);
                rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Right.Color.SetColor(Color.Gray);
                rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Top.Color.SetColor(Color.Gray);
                rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Bottom.Color.SetColor(Color.Gray);
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;


                rg = ws.Cells[row + 4, 2, k - 1, column - 1];

                rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Left.Color.SetColor(Color.Black);
                rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Right.Color.SetColor(Color.Black);
                rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Top.Color.SetColor(Color.Black);
                rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Bottom.Color.SetColor(Color.Black);
                rg.Style.Font.Size = 10;

                
                string footer1 = string.Empty;
                string footer2 = string.Empty;
                string footer3 = string.Empty;

                if (tipo == 1)
                {
                    footer1 = "TOTAL ENERGÍA (MWh)";
                    footer2 = "TOTAL POTENCIA MÁXIMA (MW)";
                    footer3 = "TOTAL POTENCIA MÍNIMA (MW)";
                }
                if (tipo == 2)
                {
                    footer1 = "TOTAL ENERGÍA REACTIVA(MVarh)";
                    footer2 = "TOTAL POTENCIA REACTIVA MÁXIMA (MVAR)";
                    footer3 = "TOTAL POTENCIA REACTIVA MÍNIMA (MVAR)";
                }
                if (tipo == 3)
                {
                    footer1 = "TOTAL ENERGÍA SERV. AUX. (MWh)";
                    footer2 = "TOTAL POTENCIA MÁXIMA SERV. AUX. (MW)";
                    footer3 = "TOTAL POTENCIA MÍNIMA SERV. AUX. (MW)";
                }
                
                ws.Cells[k, 2].Value = footer1;
                ws.Cells[k + 1, 2].Value = footer2;
                ws.Cells[k + 2, 2].Value = footer3;

                for (int l = 3; l < column; l++)
                {
                    ws.Cells[k, l].Formula = "=SUM(" + this.ObtenerColumnNumber(row + 4, l) + ":" + this.ObtenerColumnNumber(k - 1, l) + ")/4";
                    ws.Cells[k + 1, l].Formula = "=MAX(" + this.ObtenerColumnNumber(row + 4, l) + ":" + this.ObtenerColumnNumber(k - 1, l) + ")";
                    ws.Cells[k + 2, l].Formula = "=MIN(" + this.ObtenerColumnNumber(row + 4, l) + ":" + this.ObtenerColumnNumber(k - 1, l) + ")";
                }
                
                rg = ws.Cells[14, 3, k + 2, column];
                rg.Style.Numberformat.Format = "#,##0.000";
                          
                rg = ws.Cells[k, 2, k + 2, column - 1];
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
                rg.Style.Font.Size = 10;
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Font.Bold = true;

                ws.Column(2).Width = 25;
                rg = ws.Cells[1, 3, k + 2, column];
                rg.AutoFitColumns();
                
                ws.Cells[1, 1].Value = "0";
                ws.Cells[1, 1].Style.Font.Color.SetColor(Color.White);

                ws.Cells[k + 4, 2].Value = "Leyenda";

                if (flag)
                {
                    ws.Cells[k + 6, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[k + 6, 2].Style.Fill.BackgroundColor.SetColor(Color.Red);
                    ws.Cells[k + 6, 3].Value = "Registros negativos";
                    ws.Cells[k + 8, 2].Value = "(*) Incluye a las centrales eléctricas RER No Adjudicadas (C.T. Maple Etanol y C.H. Pías I).";
                }
                else
                {
                    ws.Cells[k + 6, 2].Value = "(*) Incluye a las centrales eléctricas RER No Adjudicadas (C.T. Maple Etanol y C.H. Pías I).";
                }

                

                rg = ws.Cells[k + 4, 2, k + 8, 3];
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;
                rg.Style.Font.Color.SetColor(Color.Black);
                rg.Style.Font.Italic = true;

                ws.View.FreezePanes(14, 4);

                if (flag)
                {
                    var cellAddress = new ExcelAddress(1, 1, k + 2, column);
                    var cf = ws.ConditionalFormatting.AddLessThan(cellAddress);
                    cf.Formula = "0";
                    cf.Style.Fill.BackgroundColor.Color = Color.Red;
                }

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
        }

        /// <summary>
        /// Permite crear el formato csv
        /// </summary>
        /// <param name="list"></param>
        protected void CreaFormatoCSV(List<MeMedicion96DTO> list, DateTime fechaInicio, DateTime fechaFin, string fileName)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                var listCentrales = list.Select(m => new { m.Ptomedicodi, m.Ptomedielenomb, m.Emprnomb }).Distinct().OrderBy(x => x.Emprnomb).ToList();

                int dias = (int)fechaFin.Subtract(fechaInicio).TotalDays + 1;
                List<List<MeMedicion96DTO>> totales = new List<List<MeMedicion96DTO>>();

                string header = "fechahora ";
                                
                foreach (var item in listCentrales)
                {
                    List<MeMedicion96DTO> listDatos = list.Where(x => x.Ptomedicodi == item.Ptomedicodi).ToList().OrderBy(p => p.Medifecha).ToList();

                    if (listDatos.Count > 0)
                    {
                        DateTime fecha = (DateTime)listDatos[0].Medifecha;

                        int diferencia = (int)fecha.Subtract(fechaInicio).TotalDays;

                        for (int i = 0; i < diferencia; i++)
                        {
                            listDatos.Insert(0, new MeMedicion96DTO());
                        }
                    }

                    totales.Add(listDatos);                  
                    header = header + ", " + item.Emprnomb.Trim() + " -" + item.Ptomedielenomb.Trim();
                }

                file.WriteLine(header);

                for (int i = 0; i < dias; i++)
                {
                    for (int j = 1; j <= 96; j++)
                    {
                        string linea = fechaInicio.AddDays(i).AddMinutes(j * 15).ToString("dd/MM/yyyy HH:mm");

                        for (int k = 0; k < listCentrales.Count; k++)
                        {
                            if (totales[k].Count > i)
                            {
                                MeMedicion96DTO entidad = totales[k][i];

                                object val = entidad.GetType().GetProperty("H" + j).GetValue(entidad, null);

                                if (val != null)
                                {
                                    linea = linea + ", " + val.ToString();
                                }
                                else
                                {
                                    linea = linea + "," + " ";
                                }
                            }
                            else
                            {
                                linea = linea + ", " + " ";
                            }
                        }

                        file.WriteLine(linea);
                    }
                }
            }
        }

        /// <summary>
        /// Retorna el nombre de columna
        /// </summary>
        /// <param name="nroColumn"></param>
        /// <returns></returns>
        protected string ObtenerColumnNumber(int nroFila, int nroColumn)
        {
            string[] columns = {"A","B", "C", "D", "E", "F", "G", "H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                               "AA","AB","AC","AD","AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN","AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX","AY","AZ",
                               "BA","BB","BC","BD","BE","BF","BG","BH","BI","BJ","BK","BL","BM","BN","BO","BP","BQ","BR","BS","BT","BU","BV","BW","BX","BY","BZ",
                               "CA","CB","CC","CD","CE","CF","CG","CH","CI","CJ","CK","CL","CM","CN","CO","CP","CQ","CR","CS","CT","CU","CV","CW","CX","CY","CZ",
                               "DA","DB","DC","DD","DE","DF","DG","DH","DI","DJ","DK","DL","DM","DN","DO","DP","DQ","DR","DS","DT","DU","DV","DW","DX","DY","DZ",
                               "EA","EB","EC","ED","EE","EF","EG","EH","EI","EJ","EK","EL","EM","EN","EO","EP","EQ","ER","ES","ET","EU","EV","EW","EX","EY","EZ",
                               "FA","FB","FC","FD","FE","FF","FG","FH","FI","FJ","FK","FL","FM","FN","FO","FP","FQ","FR","FS","FT","FU","FV","FW","FX","FY","FZ",
                               "GA","GB","GC","GD","GE","GF","GG","GH","GI","GJ","GK","GL","GM","GN","GO","GP","GQ","GR","GS","GT","GU","GV","GW","GX","GY","GZ",
                               "HA","HB","HC","HD","HE","HF","HG","HH","HI","HJ","HK","HL","HM","HN","HO","HP","HQ","HR","HS","HT","HU","HV","HW","HX","HY","HZ",
                               "IA","IB","IC","ID","IE","IF","IG","IH","II","IJ","IK","IL","IM","IN","IO","IP","IQ","IR","IS","IT","IU","IV","IW","IX","IY","IZ"
                               };

            int index = nroColumn - 1;

            return columns[index] + nroFila;
        }

        #endregion
    }
}
