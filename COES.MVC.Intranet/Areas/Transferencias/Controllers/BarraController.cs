using COES.MVC.Intranet.Helper;
using COES.Dominio.DTO.Transferencias;
using COES.Servicios.Aplicacion.Transferencias;
using COES.MVC.Intranet.Areas.Transferencias.Models;
using COES.MVC.Intranet.Areas.Transferencias.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;
using System.IO;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class BarraController : Controller
    {
        // GET: /Transferencias/barra/
        //[CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Lista(string nombre)
        {
            BarraModel model = new BarraModel();
            model.ListaBarras = (new GeneralAppServicioBarra()).BuscarBarra(nombre);
            model.bNuevo = (new Funcion()).ValidarPermnisoNuevo(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEliminar = (new Funcion()).ValidarPermnisoEliminar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return PartialView(model);
        }

        //GET
        public ActionResult View(int id = 0)
        {
            BarraModel model = new BarraModel();
            model.Entidad = (new GeneralAppServicioBarra()).GetByIdBarra(id);

            return PartialView(model);
        }

        //GET
        public ActionResult New()
        {
            AreaModel modelArea = new AreaModel();
            modelArea.ListaAreas = (new GeneralAppServicioArea()).ListAreas();

            BarraDTO dto = new BarraDTO();
            dto.Barrcodi = 0;

            if (dto == null)
            {
                return HttpNotFound();
            }
            dto.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            
            TempData["Areacodigo"] = new SelectList(modelArea.ListaAreas, "Areacodi", "Areanombre");

            return View(dto);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Barrcodi,Barrnombre,Barrtension,Barrpuntosumirer,Barrbarrabgr, Barrflagbarrtran, Barrnombbarrtran, Barrestado, Areacodi")] BarraDTO barra)
        {
            if (ModelState.IsValid)
            {
                barra.Barrusername = User.Identity.Name;
                BarraModel model = new BarraModel();
                model.IdBarra = (new GeneralAppServicioBarra()).SaveOrUpdateBarra(barra);
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            return PartialView(barra);
        }

        //GET
        public ActionResult Edit(int id = 0)
        {
            AreaModel modelArea = new AreaModel();
            modelArea.ListaAreas = (new GeneralAppServicioArea()).ListAreas();

            BarraDTO dto = new BarraDTO();
            dto = (new GeneralAppServicioBarra()).GetByIdBarra(id);

            if (dto == null)
            {
                return HttpNotFound();
            }

            TempData["Areacodigo"] = new SelectList(modelArea.ListaAreas, "Areacodi", "Areanombre");
            dto.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return View(dto);
        }
 
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string Delete(int id = 0)
        {
            BarraModel model = new BarraModel();
            model.IdBarra = (new GeneralAppServicioBarra()).DeleteBarra(id);
            return "true";
        }

        [HttpPost]
        public JsonResult GenerarExcel()
        {
            int indicador = 1;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;
                string sFecha = DateTime.Now.ToString("yyyyMMddHHmmss"); ;

                BarraModel model = new BarraModel();
                model.ListaBarras = (new GeneralAppServicioBarra()).BuscarBarra("");

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaBarraExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteBarraExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteBarraExcel);
                }

                int row = 4;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];

                    foreach (var item in model.ListaBarras)
                    {
                        ws.Cells[row, 2].Value = (item.Barrcodi != null) ? item.Barrcodi.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Barrnombre != null) ? item.Barrnombre : string.Empty;
                        ws.Cells[row, 4].Value = (item.Barrtension != null) ? item.Barrtension.ToString() : string.Empty;
                        ws.Cells[row, 5].Value = (item.Barrpuntosumirer != null) ? item.Barrpuntosumirer.ToString() : string.Empty;
                        ws.Cells[row, 6].Value = (item.Barrbarrabgr != null) ? item.Barrbarrabgr.ToString() : string.Empty;
                        ws.Cells[row, 7].Value = (item.Barrflagbarrtran != null) ? item.Barrflagbarrtran.ToString() : string.Empty;
                        ws.Cells[row, 8].Value = (item.Barrnombbarrtran != null) ? item.Barrnombbarrtran.ToString() : string.Empty;
                        ws.Cells[row, 9].Value = string.Empty;
                        if (item.Barrestado != null)
                        {
                            if (item.Barrestado.ToString().Equals("ACT")) ws.Cells[row, 9].Value = "Activo";
                            else ws.Cells[row, 9].Value = "Inactivo";
                        }
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
        public virtual ActionResult AbrirExcel()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteBarraExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteBarraExcel);
        }        
    }
}
