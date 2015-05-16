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
using System.Globalization;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class CodigoRetiroSinContratoController : Controller
    {
        // GET: /Transferencias/CodigoRetiroSinContrato/
        //[CustomAuthorize]
        public ActionResult Index()
        {
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();
            
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();

            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");      

            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN");

            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Lista(string nombreCli, string nombreBarra, string fechaInicio, string fechaFin, string estado)
        {
            if (nombreCli.Equals("--Seleccione--"))
                nombreCli = null;
            if (nombreBarra.Equals("--Seleccione--"))
                nombreBarra = null;

            DateTime? dtfi = null;
            if (string.IsNullOrEmpty(fechaInicio))
            {
                dtfi = null;
            }
            else
            {
                dtfi = DateTime.ParseExact(fechaInicio, Constantes.FormatoFecha, CultureInfo.InvariantCulture); //Convert.ToDateTime(fechaInicio);
            }

            DateTime? dtff = null;
            if (string.IsNullOrEmpty(fechaFin))
            {
                dtfi = null;
            }
            else
            {
                dtfi = DateTime.ParseExact(fechaFin, Constantes.FormatoFecha, CultureInfo.InvariantCulture);  //Convert.ToDateTime(fechaFin);
            }

            CodigoRetiroSinContratoModel model = new CodigoRetiroSinContratoModel();
            model.ListaCodigoRetiroSinContrato = (new GeneralAppServicioCodigoRetiroSinContrato()).BuscarCodigoRetiroSinContrato(nombreCli, nombreBarra, dtfi, dtff, estado);

            model.bNuevo = (new Funcion()).ValidarPermnisoNuevo(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEliminar = (new Funcion()).ValidarPermnisoEliminar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return PartialView(model);
        }

        //GET
        public ActionResult View(int id = 0)
        {
            CodigoRetiroSinContratoModel model = new CodigoRetiroSinContratoModel();
            model.Entidad = (new GeneralAppServicioCodigoRetiroSinContrato()).GetByIdCodigoRetiroSinContrato(id);
            return PartialView(model);
        }

        //GET
        public ActionResult New()
        {
            CodigoRetiroSinContratoModel modelo = new CodigoRetiroSinContratoModel();
            modelo.Entidad = new CodigoRetiroSinContratoDTO();
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.Entidad.Codretisinconcodi = 0;
            modelo.Codretisinconfechainicio = System.DateTime.Now.ToString("dd/MM/yyyy");
            modelo.Codretisinconfechafin = System.DateTime.Now.ToString("dd/MM/yyyy");
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).BuscarEmpresas("");
            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).BuscarBarra("");
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN");

            modelo.Entidad.Genemprcodi = Funcion.CODIEMPR_SINCONTRATO;
            return PartialView(modelo); 
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CodigoRetiroSinContratoModel modelo)
        {
            CodigoRetiroSinContratoModel modeloAux = new CodigoRetiroSinContratoModel(); //Consultamos si el codigo ya encuentra registrado
            modeloAux.Entidad = (new GeneralAppServicioCodigoRetiroSinContrato()).BuscarCodigoRetiroSinContratoCodigo(modelo.Entidad.Codretisinconcodigo);
            if (modeloAux.Entidad != null && modelo.Entidad.Codretisinconcodi != modeloAux.Entidad.Codretisinconcodi)
                modelo.sError = "El Código de retiro sin contrato [" + modelo.Entidad.Codretisinconcodigo + "], ya se encuentra registrado";
            else if (ModelState.IsValid)
            {
                modelo.Entidad.Codretisinconusername = User.Identity.Name;
                if (modelo.Codretisinconfechainicio != "" && modelo.Codretisinconfechainicio != null)
                    modelo.Entidad.Codretisinconfechainicio = DateTime.ParseExact(modelo.Codretisinconfechainicio, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                if (modelo.Codretisinconfechafin != "" && modelo.Codretisinconfechafin != null)
                    modelo.Entidad.Codretisinconfechafin = DateTime.ParseExact(modelo.Codretisinconfechafin, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                modelo.IdCodigoRetirosinContrato = (new GeneralAppServicioCodigoRetiroSinContrato()).SaveOrUpdateCodigoRetiroSinContrato(modelo.Entidad);
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            //Error
            if (modelo.sError == null) modelo.sError = "Se ha producido un error al insertar la información";
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).BuscarEmpresas("");
            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE", modelo.Entidad.Clicodi);
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).BuscarBarra("");
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN", modelo.Entidad.Barrcodi);
            return PartialView(modelo); 
        }

        //GET
        public ActionResult Edit(int id = 0)
        {
            CodigoRetiroSinContratoModel modelo = new CodigoRetiroSinContratoModel();
            modelo.Entidad = (new GeneralAppServicioCodigoRetiroSinContrato()).GetByIdCodigoRetiroSinContrato(id);
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.Codretisinconfechainicio = modelo.Entidad.Codretisinconfechainicio.ToString("dd/MM/yyyy");
            if (modelo.Entidad.Codretisinconfechafin != null)
            { modelo.Codretisinconfechafin = modelo.Entidad.Codretisinconfechafin.GetValueOrDefault().ToString("dd/MM/yyyy"); }
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).BuscarEmpresas("");
            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE", modelo.Entidad.Clicodi);
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).BuscarBarra("");
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN", modelo.Entidad.Barrcodi);

            
            return PartialView(modelo); 
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string Delete(int id)
        {
            CodigoRetiroSinContratoModel model = new CodigoRetiroSinContratoModel();
            model.IdCodigoRetirosinContrato = (new GeneralAppServicioCodigoRetiroSinContrato()).DeleteCodigoRetiroSinContrato(id);
            return "True";
        }

        [HttpPost]
        public JsonResult GenerarExcel()
        {
            int indicador = 1;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;

                CodigoRetiroSinContratoModel model = new CodigoRetiroSinContratoModel();
                model.ListaCodigoRetiroSinContrato = (new GeneralAppServicioCodigoRetiroSinContrato()).ListCodigoRetiroSinContrato();

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaCodigoRetiroSinConExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteCodigoRetiroSinConExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteCodigoRetiroSinConExcel);
                }

                int row = 4;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];

                    foreach (var item in model.ListaCodigoRetiroSinContrato)
                    {
                        ws.Cells[row, 2].Value = (item.Barrnombbarrtran != null) ? item.Barrnombbarrtran.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Clinombre != null) ? item.Clinombre : string.Empty;
                        ws.Cells[row, 4].Value = (item.Codretisinconfechainicio != null) ? item.Codretisinconfechainicio.ToString("dd/MM/yyyy") : string.Empty;
                        ws.Cells[row, 5].Value = (item.Codretisinconfechafin != null) ? item.Codretisinconfechafin.Value.ToString("dd/MM/yyyy") : string.Empty;
                        ws.Cells[row, 6].Value = (item.Codretisinconcodigo != null) ? item.Codretisinconcodigo.ToString() : string.Empty;
                        ws.Cells[row, 7].Value = string.Empty;
                        if (item.Codretisinconestado != null)
                        {
                            if (item.Codretisinconestado.ToString().Equals("ACT")) ws.Cells[row, 7].Value = "Activo";
                            else ws.Cells[row, 7].Value = "Inactivo";
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
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteCodigoRetiroSinConExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteCodigoRetiroSinConExcel);
        }  
    }
}
