using COES.Dominio.DTO.Transferencias;
using COES.MVC.Extranet.Areas.Transferencias.Models;
using COES.MVC.Intranet.Areas.Transferencias.Helper;
using COES.MVC.Intranet.Areas.Transferencias.Models;
using COES.MVC.Intranet.Helper;
using COES.Servicios.Aplicacion.Transferencias;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class EnvioInformacionController : Controller
    {
        //
        // GET: /Transferencias/EnvioInformacion/

        public ActionResult Index()
        {

            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.ListaPeriodos = (new GeneralAppServicioPeriodo()).ListPeriodo();

            TempData["PERIANIOMES2"] = new SelectList(modelPeriodo.ListaPeriodos, "PERICODI", "PERINOMBRE");

            TempData["PERIANIOMES1"] = new SelectList(modelPeriodo.ListaPeriodos, "PERICODI", "PERINOMBRE");

            TempData["PERIANIOMES3"] = new SelectList(modelPeriodo.ListaPeriodos, "PERICODI", "PERINOMBRE");

            TempData["PERIANIOMES4"] = new SelectList(modelPeriodo.ListaPeriodos, "PERICODI", "PERINOMBRE");

            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();

            TempData["EMPRCODI1"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");

            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");

            TempData["EMPRCODI3"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");
            
            return View();
        }
        
        [HttpPost]
        public JsonResult GenerarExcel(int periodo, int sEmp)
        {
            int indicador = 1;

            try
            {
                int Emprcodi = sEmp;
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;
               
                CodigoRetiroModel modelCodigoRetiro = new CodigoRetiroModel();

                EnvioInformacionModel model = new EnvioInformacionModel();
                model.ListaEntregReti = (new GeneralAppServicioExportarExcel()).BuscarCodigoRetiro(Emprcodi);

            
                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaEnvioExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteEnvioExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteEnvioExcel);
                }

                int row = 4;
                int row2 = 3;
                int colum = 2;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];

                    foreach (var item in model.ListaEntregReti)
                    {
                        
                        ws.Cells[row, 2].Value = (item.Emprnomb != null) ? item.Emprnomb.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Barrnombbarrtran != null) ? item.Barrnombbarrtran : string.Empty;
                        ws.Cells[row, 4].Value = (item.Codientrereticodigo != null) ? item.Codientrereticodigo : string.Empty;
                        ws.Cells[row, 5].Value = (item.Tipo != null) ? item.Tipo : string.Empty;
                        ws.Cells[row, 6].Value = (item.CentgeneClinombre != null) ? item.CentgeneClinombre : string.Empty;
                        row++;
                    }

                    ExcelWorksheet ws2 = xlPackage.Workbook.Worksheets.Add("DATOS");
                    ws2.Cells[2, 1].Value = "VERSION DE DECLARACION";
                    foreach (var item in model.ListaEntregReti)
                    {
                        ws2.Cells[1, colum].Value = (item.Codientrereticodigo != null) ? item.Codientrereticodigo.ToString() : string.Empty;
                        ws2.Cells[2, colum].Value = "Mejor información";
                        colum++;
                    }

                    ////////////////////////////
                    PeriodoModel modelPeriodo = new PeriodoModel();
                    modelPeriodo.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(periodo);
                    string sMes = modelPeriodo.Entidad.Mescodi.ToString();
                    if (sMes.Length == 1) sMes = "0" + sMes;
                    var Fecha = "01/" + sMes + "/" + modelPeriodo.Entidad.Aniocodi;
                    var dates = new List<DateTime>();
                    var dateIni = DateTime.ParseExact(Fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);  //Convert.ToDateTime(Fecha);
                    var dateFin = dateIni.AddMonths(1);

                    dateIni = dateIni.AddMinutes(15);
                    for (var dt = dateIni; dt <= dateFin; dt = dt.AddMinutes(15))
                    {
                        dates.Add(dt);
                    }

                    foreach (var item in dates)
                    {
                        ws2.Cells[row2, 1].Value = item.ToString("dd/MM/yyyy HH:mm:ss");
                        row2++;
                    }
                    xlPackage.Save();
                }
                indicador = 1;
            }
            catch
            {
                indicador = -1;
            }
            return Json(indicador);
        }



        [HttpGet]
        public virtual ActionResult AbrirExcel()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteEnvioExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteEnvioExcel);
        }


        [HttpPost]
        public ActionResult Upload(string sFecha)
        {
            string sNombreArchivo = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;

            try
            {
                if (Request.Files.Count == 1)
                {
                    var file = Request.Files[0];
                    sNombreArchivo = sFecha + "_" + file.FileName;

                    if (System.IO.File.Exists(path + sNombreArchivo))
                    {
                        System.IO.File.Delete(path + sNombreArchivo);
                    }

                    file.SaveAs(path + sNombreArchivo);
                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Permite cargar versiones deacuerdo al periodo
        /// </summary>
        /// <returns></returns>
        public JsonResult GetVersion(int pericodi)
        {

            RecalculoModel modelRecalculo = new RecalculoModel();
            modelRecalculo.ListaRecalculo = (new GeneralAppServicioRecalculo()).ListRecalculos(pericodi);


            return Json(modelRecalculo.ListaRecalculo);
        }

        /// <summary>
        /// Permite procesar el archivo cargado en un directorio
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ProcesarArchivo(string sNombreArchivo, int sPericodi, int sEmp, int sVer)
        {
            string pathfinal = "";
            string extension = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;

            try
            {
                //tratamos el archivo cargado en el directorio
                pathfinal = path + "/" + sNombreArchivo;

                //obtiene extension
                extension = Path.GetExtension(pathfinal);

                DataSet ds = new DataSet();

                //FileStream stream = new FileStream(pathfinal, FileMode.Open, FileAccess.Read);

                //if (extension.Equals(".xls"))
                //{   //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                //    Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateBinaryReader(stream);
                //    ds = excelReader.AsDataSet();
                //}
                //else if (extension.Equals(".xlsx"))
                //{   //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                //    Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream);
                //    excelReader.IsFirstRowAsColumnNames = true;
                //    ds = excelReader.AsDataSet();
                //}

                ds = (new Funcion()).GeneraDataset(pathfinal, 2);


                CodigoRetiroModel modelCodigoRetiro = new CodigoRetiroModel();
                CodigoEntregaModel modelCodigoEntrega = new CodigoEntregaModel();
                TransferenciaRetiroModel modelTransferenciaRetiro = new TransferenciaRetiroModel();
                TransferenciaEntregaModel modelTransferenciaEntrega = new TransferenciaEntregaModel();
                TransferenciaEntregaDTO entidadTEntrega = new TransferenciaEntregaDTO();
                TransferenciaRetiroDTO entidadTRetiro = new TransferenciaRetiroDTO();
                TransferenciaEntregaDetalleDTO entidadTEntregaDetalle = new TransferenciaEntregaDetalleDTO();
                TransferenciaRetiroDetalleDTO entidadTRetiroDetalle = new TransferenciaRetiroDetalleDTO();

                //////VARIABLES PARA CONFIRMACION DE ELIMNAR REGISTROS////////////
                int delEntregaok = 0;
                int delEntregadetaok = 0;
                int delRetirook = 0;
                int delRetirodetaok = 0;

                ////session de la empresa
                //int Emprcodi = Int32.Parse(Session["EMPRCODI"].ToString()); //MCHAVEZ: CORREGIR SESSION SELECCION DE LISTA DE EMPRESAS
                int Emprcodi = sEmp;
                //obtener el codigo de la version
                int tramver = sVer;

                //Eliminar registro de codigo de entrega
                delEntregadetaok = new GerenalAppServicioTransferenciaEntregaDetalle().DeleteTransferenciaEntregaDetalle(Emprcodi, sPericodi, tramver);
                delEntregaok = new GerenalAppServicioTransferenciaEntrega().DeleteTransferenciaEntrega(Emprcodi, sPericodi, tramver);

                //Eliminar  registros de codigo de retiro
                delRetirodetaok = new GerenalAppServicioTransferenciaRetiroDetalle().DeleteTransferenciaRetiroDetalle(Emprcodi, sPericodi, tramver);
                delRetirook = new GerenalAppServicioTransferenciaRetiro().DeleteTransferenciaRetiro(Emprcodi, sPericodi, tramver);
                /////////////////////////////////////////////////////////////////////

                //ARRAYLIST DETA ENTREGA
                ArrayList arrylist = new ArrayList();

                //ArrayLIST DETA RETIRO
                ArrayList arrylistR = new ArrayList();

                string TRANRETITIPOINFORMACION = "";
                int Tramiteversion = 0;
                int PeriodoCodigo = 0;
                int Barrcodi = 0;
                int Clicodi = 0;
                int CentralGenecodi = 0;
                int cod = 0;
                decimal promedio = 0;
                int DatosVacios = 0;
                string sAux = "";
                double dAux = 0;
                bool isDouble = false;
                decimal suma = 0;

                ArrayList listColuTodo = new ArrayList();

                foreach (DataColumn dc in ds.Tables[1].Columns)
                {
                    foreach (DataRow dtRow in ds.Tables[1].Rows)
                    {
                        if (String.IsNullOrEmpty(dtRow[dc].ToString()))
                        {
                            listColuTodo.Add("0");
                            DatosVacios++;
                        }
                        else
                        {
                            sAux = dtRow[dc].ToString();
                            isDouble = Double.TryParse(sAux, out dAux);
                            if (isDouble)
                                listColuTodo.Add(dAux);
                            else
                                listColuTodo.Add(sAux);
                        }

                    }

                    modelCodigoEntrega.Entidad = (new GeneralAppServicioCodigoEntrega()).GetByCodigoEntregaCodigo(dc.ColumnName.ToString());
                    if (modelCodigoEntrega.Entidad != null)                  
                    {
                      
                        Tramiteversion = tramver;
                        PeriodoCodigo = sPericodi;
                        Emprcodi = modelCodigoEntrega.Entidad.Emprcodi;
                        Barrcodi = modelCodigoEntrega.Entidad.Barrcodi;
                        CentralGenecodi = modelCodigoEntrega.Entidad.Centgenecodi;

                        entidadTEntrega.Codentcodi = modelCodigoEntrega.Entidad.Codientrcodi;
                        entidadTEntrega.Emprcodi = Emprcodi;
                        entidadTEntrega.Barrcodi = Barrcodi;
                        entidadTEntrega.Codientrcodigo = dc.ColumnName.ToString();
                        entidadTEntrega.Centgenecodi = CentralGenecodi;
                        entidadTEntrega.Pericodi = sPericodi;
                        entidadTEntrega.Tranentrversion = Tramiteversion;
                        entidadTEntrega.Tranentripoinformacion = listColuTodo[0].ToString();
                        entidadTEntrega.Tentusername = User.Identity.Name;
                        cod = (new GerenalAppServicioTransferenciaEntrega()).SaveOrUpdateTransferenciaEntrega(entidadTEntrega);

                        ////Graba detalle
                        int cantidadve = 96;
                        ArrayList Listpordias = new ArrayList(cantidadve);
                        for (int c = 1; c < listColuTodo.Count; c += cantidadve)
                        {
                            var arrylistdDiaED = new ArrayList();
                            arrylistdDiaED.AddRange(listColuTodo.GetRange(c, cantidadve));
                            Listpordias.Add(arrylistdDiaED);
                        }

                        for (int c = 0; c < Listpordias.Count; c++)
                        {
                            arrylist = (ArrayList)Listpordias[c];

                            entidadTEntregaDetalle.Tranentrcodi = cod;
                            entidadTEntregaDetalle.Tranentrdetadia = (c + 1);
                            entidadTEntregaDetalle.Tranentrdetaversion = Tramiteversion;
                            entidadTEntregaDetalle.Tentdeusername = User.Identity.Name;

                            suma = 0;
                            suma += entidadTEntregaDetalle.Tranentrdetah1 = Decimal.Parse(arrylist[0].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah2 = Decimal.Parse(arrylist[1].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah3 = Decimal.Parse(arrylist[2].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah4 = Decimal.Parse(arrylist[3].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah5 = Decimal.Parse(arrylist[4].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah6 = Decimal.Parse(arrylist[5].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah7 = Decimal.Parse(arrylist[6].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah8 = Decimal.Parse(arrylist[7].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah9 = Decimal.Parse(arrylist[8].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah10 = Decimal.Parse(arrylist[9].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah11 = Decimal.Parse(arrylist[10].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah12 = Decimal.Parse(arrylist[11].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah13 = Decimal.Parse(arrylist[12].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah14 = Decimal.Parse(arrylist[13].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah15 = Decimal.Parse(arrylist[14].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah16 = Decimal.Parse(arrylist[15].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah17 = Decimal.Parse(arrylist[16].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah18 = Decimal.Parse(arrylist[17].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah19 = Decimal.Parse(arrylist[18].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah20 = Decimal.Parse(arrylist[19].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah21 = Decimal.Parse(arrylist[20].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah22 = Decimal.Parse(arrylist[21].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah23 = Decimal.Parse(arrylist[22].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah24 = Decimal.Parse(arrylist[23].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah25 = Decimal.Parse(arrylist[24].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah26 = Decimal.Parse(arrylist[25].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah27 = Decimal.Parse(arrylist[26].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah28 = Decimal.Parse(arrylist[27].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah29 = Decimal.Parse(arrylist[28].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah30 = Decimal.Parse(arrylist[29].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah31 = Decimal.Parse(arrylist[30].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah32 = Decimal.Parse(arrylist[31].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah33 = Decimal.Parse(arrylist[32].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah34 = Decimal.Parse(arrylist[33].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah35 = Decimal.Parse(arrylist[34].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah36 = Decimal.Parse(arrylist[35].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah37 = Decimal.Parse(arrylist[36].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah38 = Decimal.Parse(arrylist[37].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah39 = Decimal.Parse(arrylist[38].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah40 = Decimal.Parse(arrylist[39].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah41 = Decimal.Parse(arrylist[40].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah42 = Decimal.Parse(arrylist[41].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah43 = Decimal.Parse(arrylist[42].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah44 = Decimal.Parse(arrylist[43].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah45 = Decimal.Parse(arrylist[44].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah46 = Decimal.Parse(arrylist[45].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah47 = Decimal.Parse(arrylist[46].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah48 = Decimal.Parse(arrylist[47].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah49 = Decimal.Parse(arrylist[48].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah50 = Decimal.Parse(arrylist[49].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah51 = Decimal.Parse(arrylist[50].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah52 = Decimal.Parse(arrylist[51].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah53 = Decimal.Parse(arrylist[52].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah54 = Decimal.Parse(arrylist[53].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah55 = Decimal.Parse(arrylist[54].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah56 = Decimal.Parse(arrylist[55].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah57 = Decimal.Parse(arrylist[56].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah58 = Decimal.Parse(arrylist[57].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah59 = Decimal.Parse(arrylist[58].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah60 = Decimal.Parse(arrylist[59].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah61 = Decimal.Parse(arrylist[60].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah62 = Decimal.Parse(arrylist[61].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah63 = Decimal.Parse(arrylist[62].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah64 = Decimal.Parse(arrylist[63].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah65 = Decimal.Parse(arrylist[64].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah66 = Decimal.Parse(arrylist[65].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah67 = Decimal.Parse(arrylist[66].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah68 = Decimal.Parse(arrylist[67].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah69 = Decimal.Parse(arrylist[68].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah70 = Decimal.Parse(arrylist[69].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah71 = Decimal.Parse(arrylist[70].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah72 = Decimal.Parse(arrylist[71].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah73 = Decimal.Parse(arrylist[72].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah74 = Decimal.Parse(arrylist[73].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah75 = Decimal.Parse(arrylist[74].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah76 = Decimal.Parse(arrylist[75].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah77 = Decimal.Parse(arrylist[76].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah78 = Decimal.Parse(arrylist[77].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah79 = Decimal.Parse(arrylist[78].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah80 = Decimal.Parse(arrylist[79].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah81 = Decimal.Parse(arrylist[80].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah82 = Decimal.Parse(arrylist[81].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah83 = Decimal.Parse(arrylist[82].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah84 = Decimal.Parse(arrylist[83].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah85 = Decimal.Parse(arrylist[84].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah86 = Decimal.Parse(arrylist[85].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah87 = Decimal.Parse(arrylist[86].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah88 = Decimal.Parse(arrylist[87].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah89 = Decimal.Parse(arrylist[88].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah90 = Decimal.Parse(arrylist[89].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah91 = Decimal.Parse(arrylist[90].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah92 = Decimal.Parse(arrylist[91].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah93 = Decimal.Parse(arrylist[92].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah94 = Decimal.Parse(arrylist[93].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah95 = Decimal.Parse(arrylist[94].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTEntregaDetalle.Tranentrdetah96 = Decimal.Parse(arrylist[95].ToString(), System.Globalization.NumberStyles.Float);

                            entidadTEntregaDetalle.Tranentrdetasumadia = suma;
                            promedio = Math.Round((suma / 96), 6);
                            entidadTEntregaDetalle.Tranentrdetapromdia = promedio;

                            int SaveOk = 0;
                            SaveOk = (new GerenalAppServicioTransferenciaEntregaDetalle()).SaveOrUpdateTransferenciaEntregaDetalle(entidadTEntregaDetalle);

                            arrylist.Clear();
                        }
                    }
                    else 
                    {
                         modelCodigoRetiro.Entidad = (new GeneralAppServicioCodigoRetiro()).GetByCodigoRetiroCodigo(dc.ColumnName.ToString());
                         if (modelCodigoRetiro.Entidad!= null)
                         {
                       
                        Emprcodi = modelCodigoRetiro.Entidad.Emprcodi;
                        Barrcodi = modelCodigoRetiro.Entidad.Barrcodi;
                        Clicodi = modelCodigoRetiro.Entidad.Clicodi;

                        Tramiteversion = tramver;
                        TRANRETITIPOINFORMACION = listColuTodo[0].ToString();

                        entidadTRetiro.Emprcodi = Emprcodi;
                        entidadTRetiro.Barrcodi = Barrcodi;
                        entidadTRetiro.TRetCoresoCorescCodi = modelCodigoRetiro.Entidad.Solicodireticodi;
                        entidadTRetiro.Solicodireticodigo = dc.ColumnName.ToString();
                        entidadTRetiro.Clicodi = Clicodi;
                        entidadTRetiro.Pericodi = sPericodi;
                        entidadTRetiro.Tranretiversion = Tramiteversion;
                        entidadTRetiro.Tranretitipoinformacion = TRANRETITIPOINFORMACION;
                        entidadTRetiro.Tretusername = User.Identity.Name;
                        entidadTRetiro.Trettabla = modelCodigoRetiro.Entidad.Trettabla;
                        cod = (new GerenalAppServicioTransferenciaRetiro()).SaveOrUpdateTransferenciaRetiro(entidadTRetiro);

                        ////Obtiene datos segunda tabla
                        int cantidadve = 96;
                        ArrayList Listpordias = new ArrayList(cantidadve);
                        for (int c = 1; c < listColuTodo.Count; c += cantidadve)
                        {
                            var arrylistDiaRD = new ArrayList();
                            arrylistDiaRD.AddRange(listColuTodo.GetRange(c, cantidadve));
                            Listpordias.Add(arrylistDiaRD);
                            //detalle
                        }

                        for (int c = 0; c < Listpordias.Count; c++)
                        {
                            arrylistR = (ArrayList)Listpordias[c];
                            entidadTRetiroDetalle.Tranreticodi = cod;
                            entidadTRetiroDetalle.Tranretidetadia = c + 1;
                            entidadTRetiroDetalle.Tranretidetaversion = Tramiteversion;
                            entidadTRetiroDetalle.Tretdeusername = User.Identity.Name;

                            suma = 0;
                            suma += entidadTRetiroDetalle.Tranretidetah1 = Decimal.Parse(arrylistR[0].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah2 = Decimal.Parse(arrylistR[1].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah3 = Decimal.Parse(arrylistR[2].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah4 = Decimal.Parse(arrylistR[3].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah5 = Decimal.Parse(arrylistR[4].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah6 = Decimal.Parse(arrylistR[5].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah7 = Decimal.Parse(arrylistR[6].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah8 = Decimal.Parse(arrylistR[7].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah9 = Decimal.Parse(arrylistR[8].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah10 = Decimal.Parse(arrylistR[9].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah11 = Decimal.Parse(arrylistR[10].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah12 = Decimal.Parse(arrylistR[11].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah13 = Decimal.Parse(arrylistR[12].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah14 = Decimal.Parse(arrylistR[13].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah15 = Decimal.Parse(arrylistR[14].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah16 = Decimal.Parse(arrylistR[15].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah17 = Decimal.Parse(arrylistR[16].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah18 = Decimal.Parse(arrylistR[17].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah19 = Decimal.Parse(arrylistR[18].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah20 = Decimal.Parse(arrylistR[19].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah21 = Decimal.Parse(arrylistR[20].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah22 = Decimal.Parse(arrylistR[21].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah23 = Decimal.Parse(arrylistR[22].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah24 = Decimal.Parse(arrylistR[23].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah25 = Decimal.Parse(arrylistR[24].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah26 = Decimal.Parse(arrylistR[25].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah27 = Decimal.Parse(arrylistR[26].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah28 = Decimal.Parse(arrylistR[27].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah29 = Decimal.Parse(arrylistR[28].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah30 = Decimal.Parse(arrylistR[29].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah31 = Decimal.Parse(arrylistR[30].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah32 = Decimal.Parse(arrylistR[31].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah33 = Decimal.Parse(arrylistR[32].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah34 = Decimal.Parse(arrylistR[33].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah35 = Decimal.Parse(arrylistR[34].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah36 = Decimal.Parse(arrylistR[35].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah37 = Decimal.Parse(arrylistR[36].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah38 = Decimal.Parse(arrylistR[37].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah39 = Decimal.Parse(arrylistR[38].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah40 = Decimal.Parse(arrylistR[39].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah41 = Decimal.Parse(arrylistR[40].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah42 = Decimal.Parse(arrylistR[41].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah43 = Decimal.Parse(arrylistR[42].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah44 = Decimal.Parse(arrylistR[43].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah45 = Decimal.Parse(arrylistR[44].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah46 = Decimal.Parse(arrylistR[45].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah47 = Decimal.Parse(arrylistR[46].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah48 = Decimal.Parse(arrylistR[47].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah49 = Decimal.Parse(arrylistR[48].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah50 = Decimal.Parse(arrylistR[49].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah51 = Decimal.Parse(arrylistR[50].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah52 = Decimal.Parse(arrylistR[51].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah53 = Decimal.Parse(arrylistR[52].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah54 = Decimal.Parse(arrylistR[53].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah55 = Decimal.Parse(arrylistR[54].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah56 = Decimal.Parse(arrylistR[55].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah57 = Decimal.Parse(arrylistR[56].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah58 = Decimal.Parse(arrylistR[57].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah59 = Decimal.Parse(arrylistR[58].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah60 = Decimal.Parse(arrylistR[59].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah61 = Decimal.Parse(arrylistR[60].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah62 = Decimal.Parse(arrylistR[61].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah63 = Decimal.Parse(arrylistR[62].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah64 = Decimal.Parse(arrylistR[63].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah65 = Decimal.Parse(arrylistR[64].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah66 = Decimal.Parse(arrylistR[65].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah67 = Decimal.Parse(arrylistR[66].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah68 = Decimal.Parse(arrylistR[67].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah69 = Decimal.Parse(arrylistR[68].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah70 = Decimal.Parse(arrylistR[69].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah71 = Decimal.Parse(arrylistR[70].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah72 = Decimal.Parse(arrylistR[71].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah73 = Decimal.Parse(arrylistR[72].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah74 = Decimal.Parse(arrylistR[73].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah75 = Decimal.Parse(arrylistR[74].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah76 = Decimal.Parse(arrylistR[75].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah77 = Decimal.Parse(arrylistR[76].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah78 = Decimal.Parse(arrylistR[77].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah79 = Decimal.Parse(arrylistR[78].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah80 = Decimal.Parse(arrylistR[79].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah81 = Decimal.Parse(arrylistR[80].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah82 = Decimal.Parse(arrylistR[81].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah83 = Decimal.Parse(arrylistR[82].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah84 = Decimal.Parse(arrylistR[83].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah85 = Decimal.Parse(arrylistR[84].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah86 = Decimal.Parse(arrylistR[85].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah87 = Decimal.Parse(arrylistR[86].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah88 = Decimal.Parse(arrylistR[87].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah89 = Decimal.Parse(arrylistR[88].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah90 = Decimal.Parse(arrylistR[89].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah91 = Decimal.Parse(arrylistR[90].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah92 = Decimal.Parse(arrylistR[91].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah93 = Decimal.Parse(arrylistR[92].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah94 = Decimal.Parse(arrylistR[93].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah95 = Decimal.Parse(arrylistR[94].ToString(), System.Globalization.NumberStyles.Float);
                            suma += entidadTRetiroDetalle.Tranretidetah96 = Decimal.Parse(arrylistR[95].ToString(), System.Globalization.NumberStyles.Float);

                            entidadTRetiroDetalle.Tranretidetasumadia = suma;
                            promedio = Math.Round((suma / 96), 6);
                            entidadTRetiroDetalle.Tranretidetapromdia = promedio;

                            int SaveOk = 0;
                            SaveOk = (new GerenalAppServicioTransferenciaRetiroDetalle()).SaveOrUpdateTransferenciaRetiroDetalle(entidadTRetiroDetalle);

                            arrylistR.Clear();
                                }
                         }
                         else
                         {
                             //En caso el codigo de retiro cargado no se encuentra
                         }


                    }
                    listColuTodo.Clear();
                }

                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }



        public ActionResult FetchGraphData(int periodo, string codigoER, int empr)
        {
            TransferenciaEntregaDetalleModel modelTransferenciaEntregaDetalle = new TransferenciaEntregaDetalleModel();
            TransferenciaRetiroDetalleModel modelTransferenciaRetiroDetalle = new TransferenciaRetiroDetalleModel();

            //OBETENRE OCDIGO EMPRESA LOGIN
            //int Emprcodi = Int32.Parse(Session["EMPRCODI"].ToString()); //MCHAVEZ: CORREGIR SESSION SELECCION DE LISTA DE EMPRESAS
            int Emprcodi = empr;
            int version = 0;
            if (Session["VersionG"] != null)
            {
                version = (int)(Session["VersionG"]);
            }
           

            if ((codigoER).Substring(0, 1).Equals("I"))
            {
                modelTransferenciaEntregaDetalle.ListaTransferenciaEntregaDetalle = (new GerenalAppServicioTransferenciaEntregaDetalle()).BuscarTransferenciaEntregaDetalle(Emprcodi, periodo, codigoER, version);
                var dataEntrega = modelTransferenciaEntregaDetalle.ListaTransferenciaEntregaDetalle;

                return Json(new { dataER = dataEntrega, dataCodigo = codigoER }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                modelTransferenciaRetiroDetalle.ListaTransferenciaRetiroDetalle = (new GerenalAppServicioTransferenciaRetiroDetalle()).BuscarTransferenciaRetiroDetalle(Emprcodi, periodo, codigoER, version);
                var dataRetiro = modelTransferenciaRetiroDetalle.ListaTransferenciaRetiroDetalle;

                return Json(new { dataER = dataRetiro, dataCodigo = codigoER }, JsonRequestBehavior.AllowGet);
            }
        }

        //Retirona lista de codigo de retiro y entrega
        public ActionResult getListRetiroEntrega(int periodo, int Empr,int Vers)
        {
            TransferenciaEntregaModel modelTransferenciaEntrega = new TransferenciaEntregaModel();
            TransferenciaRetiroModel modelTransferenciaRetiro = new TransferenciaRetiroModel();

            //OBETENRE OCDIGO EMPRESA LOGIN
            //int Emprcodi = Int32.Parse(Session["EMPRCODI"].ToString()); //MCHAVEZ: CORREGIR SESSION SELECCION DE LISTA DE EMPRESAS
            int Emprcodi = Empr;
            //Version
            int version = Vers;
            Session["VersionG"] = version;

            modelTransferenciaEntrega.ListaTransferenciaEntrega = (new GerenalAppServicioTransferenciaEntrega()).ListTransferenciaEntrega(Emprcodi, periodo, version);
            modelTransferenciaRetiro.ListaTransferenciaRetiro = (new GerenalAppServicioTransferenciaRetiro()).ListTransferenciaRetiro(Emprcodi, periodo, version);

            var dataEntrega = modelTransferenciaEntrega.ListaTransferenciaEntrega;
            var dataRetiro = modelTransferenciaRetiro.ListaTransferenciaRetiro;

            return Json(new { entr = dataEntrega, reti = dataRetiro }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GenerarExcel1(string sPericodi)
        {
            int indicador = 1;
            int pericodi = Int32.Parse(sPericodi);
            //int periodo = 1;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;
                string sFecha = DateTime.Now.ToString("yyyyMMddHHmmss"); ;

                TransferenciaEntregaDetalleModel model = new TransferenciaEntregaDetalleModel();
                model.ListaTransferenciaEntregaDetalle = (new GerenalAppServicioTransferenciaEntregaDetalle()).ListBalanceEnergiaActiva(pericodi);

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaBalanceEnergiaActivaExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteBalanceEnergiaActivaExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteBalanceEnergiaActivaExcel);
                }

                int row = 4;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];

                    foreach (var item in model.ListaTransferenciaEntregaDetalle)
                    {
                        ws.Cells[row, 2].Value = (item.Nombbarra != null) ? item.Nombbarra.ToString() : string.Empty;
                        //ws.Cells[row, 3].Value = (item.EmpCodi != null) ? item.EmpCodi.ToString() : string.Empty;
                        //ws.Cells[row, 4].Value = (item.PeriCodi != null) ? item.PeriCodi.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Tentcodigo != null) ? item.Tentcodigo.ToString() : string.Empty;
                        ws.Cells[row, 4].Value = (item.Energia != null) ? item.Energia.ToString() : string.Empty;
                        //ws.Cells[row, 5].Value = (item.neto != null) ? item.neto.ToString() : string.Empty;

                        row++;
                    }
                    xlPackage.Save();
                }
                indicador = 1;
            }
            catch
            {
                indicador = -1;
            }

            return Json(indicador);
        }

        [HttpGet]
        public virtual ActionResult AbrirExcel1()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteBalanceEnergiaActivaExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteBalanceEnergiaActivaExcel);
        }

    }
}
