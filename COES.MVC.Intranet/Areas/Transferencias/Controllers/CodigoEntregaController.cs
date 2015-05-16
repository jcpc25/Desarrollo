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
    public class CodigoEntregaController : Controller
    {
        // GET: /Transferencias/CodigoEntrega/
        //[CustomAuthorize]
        public ActionResult Index()
        {
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();

            CentralGeneracionModel modelCentralGene = new CentralGeneracionModel();
            modelCentralGene.ListaCentralGeneracion = (new GeneralAppServicioCentralGeneracion()).ListCentralGeneracion();
       
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();

            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");

            TempData["CENTGENECODI2"] = new SelectList(modelCentralGene.ListaCentralGeneracion, "CENTGENECODI", "CENTGENENOMBRE");

            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN");
          
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Lista(string nombreEmp, string centralGene, string nombreBarra, string fechaInicio, string fechaFin, string estado)
        {
            if (nombreEmp.Equals("--Seleccione--") || nombreEmp.Equals(""))
                nombreEmp = null;
            if (centralGene.Equals("--Seleccione--"))
                centralGene = null;
            if (nombreBarra.Equals("--Seleccione--"))
                nombreBarra = null;
            DateTime? dtfi = null;
            if (string.IsNullOrEmpty(fechaInicio))
            {
                dtfi = null;
            }
            else
            {
                dtfi = DateTime.ParseExact(fechaInicio, Constantes.FormatoFecha, CultureInfo.InvariantCulture);  //Convert.ToDateTime(fechaInicio);
            }

            DateTime? dtff = null;
            if (string.IsNullOrEmpty(fechaFin))
            {
                dtff = null;
            }
            else
            {
                dtff = DateTime.ParseExact(fechaFin, Constantes.FormatoFecha, CultureInfo.InvariantCulture); //Convert.ToDateTime(fechaFin);
            }
      
            CodigoEntregaModel model = new CodigoEntregaModel();
            model.ListaCodigoEntrega = (new GeneralAppServicioCodigoEntrega()).BuscarCodigoEntrega(nombreEmp, centralGene, nombreBarra, dtfi, dtff, estado);

            model.bNuevo = (new Funcion()).ValidarPermnisoNuevo(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEliminar = (new Funcion()).ValidarPermnisoEliminar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return PartialView(model);
        }

        public ActionResult View(int id = 0)
        {
            CodigoEntregaModel model = new CodigoEntregaModel();
            model.Entidad = (new GeneralAppServicioCodigoEntrega()).GetByIdCodigoEntra(id);

            return PartialView(model);
        }

        public ActionResult New()
        {
            CodigoEntregaModel modelo = new CodigoEntregaModel();
            modelo.Entidad = new CodigoEntregaDTO();
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.Entidad.Codientrcodi = 0;
            modelo.Codientrfechainicio = System.DateTime.Now.ToString("dd/MM/yyyy");
            modelo.Codientrfechafin = System.DateTime.Now.ToString("dd/MM/yyyy");
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            CentralGeneracionModel modelCentralGene = new CentralGeneracionModel();
            modelCentralGene.ListaCentralGeneracion = (new GeneralAppServicioCentralGeneracion()).ListCentralGeneracion();
            TempData["CENTGENECODI2"] = new SelectList(modelCentralGene.ListaCentralGeneracion, "CENTGENECODI", "CENTGENENOMBRE");
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();
            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN");
            return PartialView(modelo); 
        }
        
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CodigoEntregaModel modelo)
        {
            CodigoEntregaModel modeloAux = new CodigoEntregaModel(); //Consultamos si el codigo ya encuentra registrado
            modeloAux.Entidad = (new GeneralAppServicioCodigoEntrega()).GetByCodigoEntregaCodigo(modelo.Entidad.Codientrcodigo);
            if (modeloAux.Entidad != null && modelo.Entidad.Codientrcodi != modeloAux.Entidad.Codientrcodi)
                modelo.sError = "El Código de Entrega [" + modelo.Entidad.Codientrcodigo + "], ya se encuentra registrado";
            else if (ModelState.IsValid)
            {   //El modelo es valido
                modelo.Entidad.Codientrusername = User.Identity.Name;
                if (modelo.Entidad.Codientrestado == null)
                    modelo.Entidad.Codientrestado = "ACT";
                if (modelo.Codientrfechainicio != "" && modelo.Codientrfechainicio != null)
                    modelo.Entidad.Codientrfechainicio = DateTime.ParseExact(modelo.Codientrfechainicio, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                if (modelo.Codientrfechafin != "" && modelo.Codientrfechafin != null)
                    modelo.Entidad.Codientrfechafin = DateTime.ParseExact(modelo.Codientrfechafin, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                modelo.IdCodigoEntrega = (new GeneralAppServicioCodigoEntrega()).SaveOrUpdateCodigoEntrega(modelo.Entidad);
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            //Error
            if (modelo.sError == null) modelo.sError = "Se ha producido un error al insertar la información";
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            CentralGeneracionModel modelCentralGene = new CentralGeneracionModel();
            modelCentralGene.ListaCentralGeneracion = (new GeneralAppServicioCentralGeneracion()).ListCentralGeneracion();
            TempData["CENTGENECODI2"] = new SelectList(modelCentralGene.ListaCentralGeneracion, "CENTGENECODI", "CENTGENENOMBRE", modelo.Entidad.Centgenecodi);
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();
            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE", modelo.Entidad.Emprcodi);
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN", modelo.Entidad.Barrcodi);
            return PartialView(modelo); 
        }

        //GET
        public ActionResult Edit(int id = 0)
        {
            CodigoEntregaModel modelo = new CodigoEntregaModel();
            modelo.Entidad = (new GeneralAppServicioCodigoEntrega()).GetByIdCodigoEntra(id);
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.Codientrfechainicio = modelo.Entidad.Codientrfechainicio.ToString("dd/MM/yyyy");
            if (modelo.Entidad.Codientrfechafin != null)
            { modelo.Codientrfechafin = modelo.Entidad.Codientrfechafin.GetValueOrDefault().ToString("dd/MM/yyyy"); }
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            CentralGeneracionModel modelCentralGene = new CentralGeneracionModel();
            modelCentralGene.ListaCentralGeneracion = (new GeneralAppServicioCentralGeneracion()).ListCentralGeneracion();
            TempData["CENTGENECODI2"] = new SelectList(modelCentralGene.ListaCentralGeneracion, "CENTGENECODI", "CENTGENENOMBRE", modelo.Entidad.Centgenecodi);
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();
            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE", modelo.Entidad.Emprcodi);
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN", modelo.Entidad.Barrcodi);
            return PartialView(modelo); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string Delete(int id = 0)
        {
            CodigoEntregaModel model = new CodigoEntregaModel();
            model.IdCodigoEntrega = (new GeneralAppServicioCodigoEntrega()).DeleteCodigoEntrega(id);
            return "true";
        }


        [HttpPost]
        public JsonResult GenerarExcel()
        {
            int indicador = 1;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;

                CodigoEntregaModel model = new CodigoEntregaModel();
                model.ListaCodigoEntrega = (new GeneralAppServicioCodigoEntrega()).ListCodigoEntrega();

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaCodigoEntregaExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteCodigoEntregaExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteCodigoEntregaExcel);
                }

                int row = 4;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];

                    foreach (var item in model.ListaCodigoEntrega)
                    {
                        ws.Cells[row, 2].Value = (item.Centgenenombre != null) ? item.Centgenenombre.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Barrnombbarrtran != null) ? item.Barrnombbarrtran : string.Empty;
                        ws.Cells[row, 4].Value = (item.Emprnomb != null) ? item.Emprnomb.ToString() : string.Empty;
                        ws.Cells[row, 5].Value = (item.Codientrfechainicio != null) ? item.Codientrfechainicio.ToString("dd/MM/yyyy") : string.Empty;
                        ws.Cells[row, 6].Value = (item.Codientrfechafin != null) ? item.Codientrfechafin.Value.ToString("dd/MM/yyyy") : string.Empty;
                        ws.Cells[row, 7].Value = (item.Codientrcodigo != null) ? item.Codientrcodigo.ToString() : string.Empty;
                        ws.Cells[row, 8].Value = string.Empty;
                        if (item.Codientrestado != null)
                        {
                            if (item.Codientrestado.ToString().Equals("ACT")) ws.Cells[row, 8].Value = "Activo";
                            else ws.Cells[row, 8].Value = "Inactivo";
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
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteCodigoEntregaExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteCodigoEntregaExcel);
        }        
    }
}
