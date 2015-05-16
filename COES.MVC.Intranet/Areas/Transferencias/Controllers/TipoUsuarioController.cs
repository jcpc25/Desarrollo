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
    public class TipoUsuarioController : Controller
    {
        //
        // GET: /Transferencias/TipoUsuario/
        //[CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Lista(string nombre)
        {
            TipoUsuarioModel model = new TipoUsuarioModel();
            model.ListaTipoUsuario = (new GeneralAppServicioTipoUsuario()).BuscarTipoUsuario(nombre);
            model.bNuevo = (new Funcion()).ValidarPermnisoNuevo(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEliminar = (new Funcion()).ValidarPermnisoEliminar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return PartialView(model);
        }

        //GET
        public ActionResult View(int id = 0)
        {
            TipoUsuarioModel model = new TipoUsuarioModel();
            model.Entidad = (new GeneralAppServicioTipoUsuario()).GetByTipoUsuario(id);

            return PartialView(model);
        }

        //GET
        public ActionResult New()
        {
            TipoUsuarioDTO dto = new TipoUsuarioDTO();
            dto.Tipousuacodi = 0;

            if (dto == null)
            {
                return HttpNotFound();
            }
            dto.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return View(dto);
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Tipousuacodi,Tipousuanombre, Tipousuaestado")] TipoUsuarioDTO tipousu)
        {
            if (ModelState.IsValid)
            {
                tipousu.Tipousuausername = User.Identity.Name;
                TipoUsuarioModel model = new TipoUsuarioModel();
                model.idTipoUsuario = (new GeneralAppServicioTipoUsuario()).SaveOrUpdateTipoUsuario(tipousu);
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            return PartialView(tipousu);
        }
       
        //GET
        public ActionResult Edit(int id = 0)
        {
            TipoUsuarioDTO dto = new TipoUsuarioDTO();
            dto = (new GeneralAppServicioTipoUsuario()).GetByTipoUsuario(id);

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
            TipoUsuarioModel model = new TipoUsuarioModel();
            model.idTipoUsuario = (new GeneralAppServicioTipoUsuario()).DeleteTipoUsuario(id);
            return "true";
        }

        [HttpPost]
        public JsonResult GenerarExcel()
        {
            int indicador = 1;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;
                TipoUsuarioModel model = new TipoUsuarioModel();
                model.ListaTipoUsuario = (new GeneralAppServicioTipoUsuario()).BuscarTipoUsuario("");

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaTipoUsuarioExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteTipoUsuarioExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteTipoUsuarioExcel);
                }

                int row = 4;
                //int row2 = 3;
                //int colum = 2;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                    foreach (var item in model.ListaTipoUsuario)
                    {
                        ws.Cells[row, 2].Value = (item.Tipousuacodi != null) ? item.Tipousuacodi.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Tipousuanombre != null) ? item.Tipousuanombre : string.Empty;
                        ws.Cells[row, 4].Value = (item.Tipousuafecins != null) ? item.Tipousuafecins.ToString() : string.Empty;
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
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteTipoUsuarioExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteTipoUsuarioExcel);
        }        
    }
}
