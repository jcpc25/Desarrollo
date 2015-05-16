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
    public class TipoContratoController : Controller
    {
        //
        // GET: /Transferencias/TipoContrato/
        //[CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Lista(string nombre)
        {
            TipoContratoModel model = new TipoContratoModel();
            model.ListaTipoContrato = (new GeneralAppServicioTipoContrato()).BuscarTipoContrato(nombre);
            model.bNuevo = (new Funcion()).ValidarPermnisoNuevo(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEliminar = (new Funcion()).ValidarPermnisoEliminar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return PartialView(model);
        }

        //GET
        public ActionResult View(int id = 0)
        {
            TipoContratoModel model = new TipoContratoModel();
            model.Entidad = (new GeneralAppServicioTipoContrato()).GetByIdTipoContrato(id);

            return PartialView(model);
        }

        //GET
        public ActionResult New()
        {
            TipoContratoDTO dto = new TipoContratoDTO();
            dto.Tipocontcodi = 0;
            if (dto == null)
            {
                return HttpNotFound();
            }
            dto.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return View(dto);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Tipocontcodi,Tipocontnombre, Tipocontestado")] TipoContratoDTO tipocont)
        {
            if (ModelState.IsValid)
            {
                tipocont.Tipocontusername = User.Identity.Name;
                TipoContratoModel model = new TipoContratoModel();
                model.idTipoContrato = (new GeneralAppServicioTipoContrato()).SaveOrUpdateTipoContrato(tipocont);
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            return PartialView(tipocont);
        }
       
        //GET
        public ActionResult Edit(int id = 0)
        {
            TipoContratoDTO dto = new TipoContratoDTO();
            dto = (new GeneralAppServicioTipoContrato()).GetByIdTipoContrato(id);

            if (dto == null)
            {
                return HttpNotFound();
            }
            dto.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string Delete(int id = 0)
        {
            TipoContratoModel model = new TipoContratoModel();
            model.idTipoContrato = (new GeneralAppServicioTipoContrato()).DeleteTipoContrato(id);
            return "true";
        }


        [HttpPost]
        public JsonResult GenerarExcel()
        {
            int indicador = 1;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;

                TipoContratoModel model = new TipoContratoModel();
                model.ListaTipoContrato = (new GeneralAppServicioTipoContrato()).BuscarTipoContrato("");
                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaTipoContratoExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteTipoContratoExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteTipoContratoExcel);
                }

                int row = 4;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];

                    foreach (var item in model.ListaTipoContrato)
                    {
                        ws.Cells[row, 2].Value = (item.Tipocontcodi != null) ? item.Tipocontcodi.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Tipocontnombre != null) ? item.Tipocontnombre : string.Empty;
                        ws.Cells[row, 4].Value = (item.Tipocontfecins != null) ? item.Tipocontfecins.ToString() : string.Empty;
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
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteTipoContratoExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteTipoContratoExcel);
        }       

     

    }
}
