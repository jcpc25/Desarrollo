using COES.Dominio.DTO.Transferencias;
using COES.Servicios.Aplicacion.Transferencias;
using COES.MVC.Intranet.Areas.Transferencias.Models;
using COES.MVC.Intranet.Areas.Transferencias.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COES.MVC.Intranet.Helper;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class LevantamientoController : Controller
    {
        //
        // GET: /Transferencias/Levantamiento/

        public ActionResult Index()
        {

            PeriodoModel model = new PeriodoModel();
            model.ListaPeriodos = (new GeneralAppServicioPeriodo()).BuscarPeriodo("");

            TempData["Periodocodigo"] = new SelectList(model.ListaPeriodos, "Pericodi", "Perinombre");

            return View();
        }

        [HttpPost]
        public ActionResult Lista(DateTime? fecha, int pericodi,  string corrinf) 
        {
            LevantamientoModel model = new LevantamientoModel();
            if (corrinf.Equals("Ambos")) corrinf = null;
            model.ListaTramites = (new GeneralAppServicioTramite()).BuscarTramite(fecha, corrinf, pericodi);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return PartialView(model);
        }

        public ActionResult View(int id)
        {
            LevantamientoModel model = new LevantamientoModel();
            model.Entidad = (new GeneralAppServicioTramite()).GetByIdTramite(id);

            return PartialView(model);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Tramcodi, Tipotramcodi, Tramrespuesta, Tramcorrinf")] TramiteDTO tramite)
        {
            if (ModelState.IsValid)
            {
                LevantamientoModel model = new LevantamientoModel();
                tramite.Usuacoescodi = User.Identity.Name;
                model.IdTramite = (new GeneralAppServicioTramite()).SaveOrUpdateTramite(tramite);
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            return PartialView(tramite);
        }


        public ActionResult Edit(int id)
        {
            TramiteDTO  dto = new TramiteDTO();
            dto = (new GeneralAppServicioTramite()).GetByIdTramite(id);
            if (dto == null)
            {
                return HttpNotFound();
            }
            TramiteLevantamientoModel modelTipoTramite = new TramiteLevantamientoModel();
            modelTipoTramite.Entidad = (new GeneralAppServicioTipoTramite()).GetByIdTipoTramite(dto.Tipotramcodi);
            TempData["Tipotramnombre"] = modelTipoTramite.Entidad.Tipotramnombre;

            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(dto.Pericodi);
            TempData["Periodonombre"] = modelPeriodo.Entidad.Perinombre;

            EmpresaModel modelEmpresa = new EmpresaModel();
            modelEmpresa.Entidad = (new GeneralAppServicioEmpresa()).GetByIdEmpresa((Int32)dto.Emprcodi);
            TempData["EmprNombre"] = modelEmpresa.Entidad.EmprNombre;

            dto.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name); 
            return View(dto);
        }

    }
}
