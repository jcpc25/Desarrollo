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
    public class CodigoRetiroController : Controller
    {
        //
        // GET: /Transferencias/CodigoRetiro/
        //[CustomAuthorize]
        public ActionResult Index()
        {
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();       

            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();

            TipoContratoModel modelTipoCont = new TipoContratoModel();
            modelTipoCont.ListaTipoContrato = (new GeneralAppServicioTipoContrato()).ListTipoContrato();

            TipoUsuarioModel modelTipoUsu = new TipoUsuarioModel();
            modelTipoUsu.ListaTipoUsuario = (new GeneralAppServicioTipoUsuario()).ListTipoUsuario();

            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");

            TempData["CLICODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");

            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN");

            TempData["TIPOCONTCODI2"] = new SelectList(modelTipoCont.ListaTipoContrato, "TIPOCONTCODI", "TIPOCONTNOMBRE");

            TempData["TIPOUSUACODI2"] = new SelectList(modelTipoUsu.ListaTipoUsuario, "TIPOUSUACODI", "TIPOUSUANOMBRE");

            return View();
        }

        public ActionResult View(int id = 0)
        {
            CodigoRetiroModel model = new CodigoRetiroModel();
            model.Entidad = (new GeneralAppServicioCodigoRetiro()).GetByIdCodigoRetiro(id);

            return PartialView(model);
        }

        //POST
        [HttpPost]
        public ActionResult Lista(string nombreEmp, string tipousu, string tipocont, string barr, string clinomb, string fechaInicio, string fechaFin, string Solicodiretiobservacion, string radiobtn)
        {
            string estado ="";

            if (nombreEmp.Equals("--Seleccione--") || nombreEmp.Equals(""))
                nombreEmp = null;
            if (tipousu.Equals("--Seleccione--"))
                tipousu = null;
            if (tipocont.Equals("--Seleccione--"))
                tipocont = null;
            if (barr.Equals("--Seleccione--"))
                barr = null;
            if (clinomb.Equals("--Seleccione--"))
                clinomb = null;

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
                dtff = null;
            }
            else
            {
                dtff = DateTime.ParseExact(fechaFin, Constantes.FormatoFecha, CultureInfo.InvariantCulture); //Convert.ToDateTime(fechaFin);
            }

            if (radiobtn != null)
            {
                if (radiobtn.Equals("TODOS")) estado = null;
                else if (radiobtn.Equals("CON")) estado = "ASI";
                else if (radiobtn.Equals("SIN")) estado = "GEN";
            }
            
            CodigoRetiroModel model = new CodigoRetiroModel();

            model.ListaCodigoRetiro = (new GeneralAppServicioCodigoRetiro()).BuscarCodigoRetiro(nombreEmp, tipousu, tipocont, barr, clinomb, dtfi, dtff, Solicodiretiobservacion, estado);

            foreach (var x in model.ListaCodigoRetiro)
            {
                if (x.Solicodireticodigo == null)
                    x.Solicodireticodigo = "PENDIENTE";
            }
            model.bNuevo = (new Funcion()).ValidarPermnisoNuevo(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEliminar = (new Funcion()).ValidarPermnisoEliminar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);

            return PartialView(model);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CodigoRetiroModel modelo)
        {
            CodigoRetiroModel modeloAux = new CodigoRetiroModel(); //Consultamos si el codigo ya encuentra registrado
            modeloAux.Entidad = (new GeneralAppServicioCodigoRetiro()).GetByCodigoRetiroCodigo(modelo.Entidad.Solicodireticodigo);
            if (modeloAux.Entidad.Solicodireticodi != 0 && modelo.Entidad.Solicodireticodi != modeloAux.Entidad.Solicodireticodi)
                modelo.sError = "El Código de Entrega [" + modelo.Entidad.Solicodireticodigo + "], ya se encuentra registrado";
            else if (ModelState.IsValid)
            {
                modelo.Entidad.Coesusername = User.Identity.Name;
                modelo.Entidad.Solicodiretiestado = "ASI"; //Codigo Asigando
                modelo.IdcodRetiro = (new GeneralAppServicioCodigoRetiro()).SaveOrUpdateCodigoRetiro(modelo.Entidad);
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            if (modelo.sError == null) modelo.sError = "Se ha producido un error al insertar la información";
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            EmpresaModel modelCliente = new EmpresaModel();
            modelCliente.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();
            TempData["CLICODI2"] = new SelectList(modelCliente.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE", modelo.Entidad.Clicodi);
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN", modelo.Entidad.Barrcodi);
            TipoContratoModel modelTipoCont = new TipoContratoModel();
            modelTipoCont.ListaTipoContrato = (new GeneralAppServicioTipoContrato()).ListTipoContrato();
            TempData["TIPOCONTCODI2"] = new SelectList(modelTipoCont.ListaTipoContrato, "TIPOCONTCODI", "TIPOCONTNOMBRE", modelo.Entidad.Tipocontcodi);
            TipoUsuarioModel modelTipoUsu = new TipoUsuarioModel();
            modelTipoUsu.ListaTipoUsuario = (new GeneralAppServicioTipoUsuario()).ListTipoUsuario();
            TempData["TIPOUSUACODI2"] = new SelectList(modelTipoUsu.ListaTipoUsuario, "TIPOUSUACODI", "TIPOUSUANOMBRE", modelo.Entidad.Tipousuacodi);

            return PartialView(modelo); 
        }

        //GET
        public ActionResult Edit(int id = 0)
        {
            CodigoRetiroModel modelo = new CodigoRetiroModel();
            modelo.Entidad = (new GeneralAppServicioCodigoRetiro()).GetByIdCodigoRetiro(id);
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            EmpresaModel modelCliente = new EmpresaModel();
            modelCliente.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();
            TempData["CLICODI2"] = new SelectList(modelCliente.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE", modelo.Entidad.Clicodi);
            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN", modelo.Entidad.Barrcodi);
            TipoContratoModel modelTipoCont = new TipoContratoModel();
            modelTipoCont.ListaTipoContrato = (new GeneralAppServicioTipoContrato()).ListTipoContrato();
            TempData["TIPOCONTCODI2"] = new SelectList(modelTipoCont.ListaTipoContrato, "TIPOCONTCODI", "TIPOCONTNOMBRE", modelo.Entidad.Tipocontcodi);
            TipoUsuarioModel modelTipoUsu = new TipoUsuarioModel();
            modelTipoUsu.ListaTipoUsuario = (new GeneralAppServicioTipoUsuario()).ListTipoUsuario();
            TempData["TIPOUSUACODI2"] = new SelectList(modelTipoUsu.ListaTipoUsuario, "TIPOUSUACODI", "TIPOUSUANOMBRE", modelo.Entidad.Tipousuacodi);

            return PartialView(modelo); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string Delete(int id = 0)
        {
            CodigoRetiroModel model = new CodigoRetiroModel();
            if (id != 0)
            {
                model.Entidad = (new GeneralAppServicioCodigoRetiro()).GetByIdCodigoRetiro(id);
                //SOLICITAR DAR DE DABAJA = SOLBAJAOK
                model.Entidad.Solicodiretiobservacion = "SOLBAJAOK";
                model.Entidad.Solicodiretifechadebaja = DateTime.Now.Date;
            }
            model.IdcodRetiro = (new GeneralAppServicioCodigoRetiro()).SaveOrUpdateCodigoRetiro(model.Entidad);

            return "true";
        }

        [HttpPost]
        public JsonResult GenerarExcel()
        {
            int indicador = 1;
            string estado = "ASI";
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;

                CodigoRetiroModel model = new CodigoRetiroModel();
                model.ListaCodigoRetiro = (new GeneralAppServicioCodigoRetiro()).ListCodigoRetiro(estado);

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaCodigoRetiroExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteCodigoRetiroExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteCodigoRetiroExcel);
                }

                int row = 4;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];

                    foreach (var item in model.ListaCodigoRetiro)
                    {
                        ws.Cells[row, 2].Value = (item.Clinombre != null) ? item.Clinombre.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Barrnombbarrtran != null) ? item.Barrnombbarrtran : string.Empty;
                        ws.Cells[row, 4].Value = (item.Emprnombre != null) ? item.Emprnombre.ToString() : string.Empty;
                        ws.Cells[row, 5].Value = (item.Solicodiretifechainicio != null) ? item.Solicodiretifechainicio.Value.ToString("dd/MM/yyyy") : string.Empty;
                        ws.Cells[row, 6].Value = (item.Solicodiretifechafin != null) ? item.Solicodiretifechafin.Value.ToString("dd/MM/yyyy") : string.Empty;
                        ws.Cells[row, 7].Value = (item.Tipocontnombre != null) ? item.Tipocontnombre.ToString() : string.Empty;
                        ws.Cells[row, 8].Value = (item.Tipousuanombre != null) ? item.Tipousuanombre.ToString() : string.Empty;
                        ws.Cells[row, 9].Value = (item.Solicodiretidescripcion != null) ? item.Solicodiretidescripcion.ToString() : string.Empty;
                        ws.Cells[row, 10].Value = (item.Solicodireticodigo != null) ? item.Solicodireticodigo.ToString() : string.Empty;
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
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteCodigoRetiroExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteCodigoRetiroExcel);
        } 
    }
}
