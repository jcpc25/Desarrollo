using COES.MVC.Intranet.Helper;
using COES.Dominio.DTO.Transferencias;
using COES.MVC.Intranet.Areas.Transferencias.Models;
using COES.MVC.Intranet.Areas.Transferencias.Helper;
using COES.Servicios.Aplicacion.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Collections;
using OfficeOpenXml;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class IngresoCompensacionController : Controller
    {
        // GET: /Transferencias/IngresoCompensacion/
        //[CustomAuthorize]
        public ActionResult Index()
        {
            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.ListaPeriodos = (new GeneralAppServicioPeriodo()).ListPeriodo();

            TempData["Pericodigo"] = new SelectList(modelPeriodo.ListaPeriodos, "Pericodi", "Perinombre");
            TempData["Pericodigo1"] = new SelectList(modelPeriodo.ListaPeriodos, "Pericodi", "Perinombre");

            return View();
        }


        [HttpPost]
        public ActionResult Lista(int? pericodi)
        {
            IngresoCompensacionModel model = new IngresoCompensacionModel();
            model.ListaIngresoCompensacion = (new GeneralAppServicioIngresoCompensacion()).BuscarIngresoCompensacion(pericodi);
            return PartialView(model);
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

        [HttpPost]
        public JsonResult ProcesarArchivo(string sNombreArchivo, string sPericodi)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;

            try
            {
                //tratamos el archivo cargado en el directorio
                string aux = path + "/" + sNombreArchivo;
                
                FileInfo archivo = new FileInfo(path + sNombreArchivo);
                ExcelPackage xlPackage = new ExcelPackage(archivo);
                ExcelWorksheet excelWorksheet = xlPackage.Workbook.Worksheets[1];

                ExcelRange rRange = (ExcelRange)excelWorksheet.Cells["A1:Y1000"]; //ALL: 1000 para registrar 1000
                int rColumna = 1000;
                int rFila = 1000;
                ExcelRange rCelda = null;

                Int32 iVersion = 1;
                string sNomEmpresa;
                Int32 iCodEmpresa;
                string sNomCompensacion;
                Int32 iCodCompensacion=0;
                Decimal iImporte = 0;
                PeriodoModel modelPeri = new PeriodoModel();
                modelPeri.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(Int32.Parse(sPericodi));
                int iPeriCodi = modelPeri.Entidad.Pericodi;

                //Eliminamos la version anterior de la tabla FactorPerdida por periodo y version
                IngresoCompensacionModel modelIC = new IngresoCompensacionModel();
                IngresoCompensacionDTO dtoIC = new IngresoCompensacionDTO();
                dtoIC.PeriCodi = (new GeneralAppServicioIngresoCompensacion()).DeleteListaIngresoCompensacion(iPeriCodi, iVersion);
                dtoIC = null;

                //Iniciamos la lectura del archivo en Excel
                for (int i = 2; i <= rColumna; i++)
                {
                    iCodEmpresa = 0;
                    rCelda = rRange.Worksheet.Cells[1, i]; //Nombre de la compensacion
                    if (rCelda.Value != null)
                    {   sNomCompensacion = rCelda.Value.ToString();
                        CompensacionModel modelComp = new CompensacionModel();
                        modelComp.Entidad = (new GeneralAppServicioCompensacion()).GetByCodigo(sNomCompensacion, iPeriCodi);
                        if (modelComp.Entidad == null)
                        {
                            return Json(-1); 
                        }
                        iCodCompensacion = modelComp.Entidad.Cabecompcodi;
                        for (int j = 2; j <= rFila; j++)
                        {   //Listamos por empresa
                            rCelda = rRange.Worksheet.Cells[j, 1]; 
                            if (rCelda.Value != null)
                            {
                                sNomEmpresa = rCelda.Value.ToString();
                                EmpresaModel modelEmp = new EmpresaModel();
                                modelEmp.Entidad = (new GeneralAppServicioEmpresa()).GetByCodigo(sNomEmpresa);

                                iCodEmpresa = modelEmp.Entidad.EmprCodi;
                                rCelda = rRange.Worksheet.Cells[j, i]; 
                                if (rCelda.Value != null) iImporte = Convert.ToDecimal(rCelda.Value.ToString());

                                dtoIC = new IngresoCompensacionDTO();
                                dtoIC.PeriCodi = iPeriCodi;
                                dtoIC.CompCodi = iCodCompensacion;
                                dtoIC.EmprCodi = iCodEmpresa; //Asignamos el codigo de la empresa
                                dtoIC.IngrCompVersion = iVersion;
                                dtoIC.IngrCompImporte = iImporte;
                                dtoIC.IngrCompusername = User.Identity.Name;
                                modelIC.IdIngresoCompensacion = (new GeneralAppServicioIngresoCompensacion()).SaveIngresoCompensacion(dtoIC);
                                dtoIC = null;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                xlPackage.Dispose();
                rRange = null;

                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(-1);
            }
        }

    }
}
