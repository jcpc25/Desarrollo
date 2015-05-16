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
    public class CompensacionController : Controller
    {
        // GET: /Transferencias/Compensacion/
        //[CustomAuthorize]
        public ActionResult Index(int id=0)
        {
            if ( id !=0)
            { Session["sPericodi"] = id; }
            return View();
        }

        [HttpPost]
        public ActionResult Lista()
        {
            int id = Convert.ToInt32(Session["sPericodi"].ToString());
            CompensacionModel model = new CompensacionModel();
            model.ListaCompensacion = (new GeneralAppServicioCompensacion()).ListCompensaciones(id);
            model.bNuevo = (new Funcion()).ValidarPermnisoNuevo(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEliminar = (new Funcion()).ValidarPermnisoEliminar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return PartialView(model);
        }

        public ActionResult New()
        {
            CompensacionModel modelo = new CompensacionModel();
            modelo.Entidad = new CompensacionDTO();
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.Entidad.Cabecomppericodi = Convert.ToInt32(Session["sPericodi"].ToString());
            modelo.Entidad.Cabecompcodi = 0;
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(modelo.Entidad.Cabecomppericodi);
            TempData["Periodonombre"] = modelPeriodo.Entidad.Perinombre;
            return PartialView(modelo); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CompensacionModel modelo)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["sPericodi"].ToString());
                modelo.Entidad.Cabecompusername = User.Identity.Name;
                modelo.IdCompensacion = (new GeneralAppServicioCompensacion()).SaveOrUpdateCompensacion(modelo.Entidad);
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            //Error
            modelo.sError = "Se ha producido un error al insertar la información";
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(modelo.Entidad.Cabecomppericodi);
            TempData["Periodonombre"] = modelPeriodo.Entidad.Perinombre;
            return PartialView(modelo);
        }

        public ActionResult Edit(int id)
        {
            CompensacionModel modelo = new CompensacionModel();
            modelo.Entidad = (new GeneralAppServicioCompensacion()).GetByIdCompensacion(id);
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(modelo.Entidad.Cabecomppericodi);
            TempData["Periodonombre"] = modelPeriodo.Entidad.Perinombre;
            return PartialView(modelo); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string Delete(int id = 0)
        {
            CompensacionModel model = new CompensacionModel();
            model.IdCompensacion = (new GeneralAppServicioCompensacion()).DeleteCompensacion(id);
            return "true";
        }

        [HttpPost]
        public JsonResult GenerarExcel()
        {
            int indicador = 1;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;
                CompensacionModel model = new CompensacionModel();
                model.ListaCompensacion = (new GeneralAppServicioCompensacion()).BuscarCompensacion("");

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaCompensacionExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteCompensacionExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteCompensacionExcel);
                }

                int row = 4;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Constantes.HojaReporteExcel];

                    foreach (var item in model.ListaCompensacion)
                    {
                        ws.Cells[row, 2].Value = item.Cabecompcodi.ToString(); // (item.Cabecompcodi != null) ? item.Cabecompcodi.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Cabecompnombre != null) ? item.Cabecompnombre : string.Empty;
                        ws.Cells[row, 4].Value = (item.Cabecompver != null) ? item.Cabecompver.ToString() : string.Empty;
                        ws.Cells[row, 5].Value = (item.Cabecompfecins != null) ? item.Cabecompfecins.ToString() : string.Empty;
                        ws.Cells[row, 6].Value = item.Cabecomppericodi.ToString(); // (item.Cabecomppericodi != null) ? item.Cabecomppericodi.ToString() : string.Empty;
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
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteCompensacionExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteCompensacionExcel);
        }        


    }
}
