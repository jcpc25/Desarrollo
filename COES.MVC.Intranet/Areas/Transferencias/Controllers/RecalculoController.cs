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
    public class RecalculoController : Controller
    {
        // GET: /Transferencias/Recalculo/
        //[CustomAuthorize]
        public ActionResult Index(int id=0)
        {
            if (id != 0)
            { Session["sPericodi"] = id; }

            return View();
        }

        [HttpPost]
        public ActionResult Lista()
        {
            int id = Convert.ToInt32(Session["sPericodi"].ToString());
            RecalculoModel model = new RecalculoModel();
            model.ListaRecalculo = (new GeneralAppServicioRecalculo()).ListRecalculos(id);
            model.bNuevo = (new Funcion()).ValidarPermnisoNuevo(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEliminar = (new Funcion()).ValidarPermnisoEliminar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return PartialView(model);
        }

        public ActionResult New()
        {
            RecalculoModel modelo = new RecalculoModel();
            modelo.Entidad = new RecalculoDTO();
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.Entidad.Recapericodi = Convert.ToInt32(Session["sPericodi"].ToString());
            modelo.Recafecini = System.DateTime.Now.ToString("dd/MM/yyyy");
            modelo.Recafecfin = System.DateTime.Now.ToString("dd/MM/yyyy");
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(modelo.Entidad.Recapericodi);
            TempData["Periodonombre"] = modelPeriodo.Entidad.Perinombre;
            return PartialView(modelo); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RecalculoModel modelo)
        {
            bool bDuplicarData = false;
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["sPericodi"].ToString());
                if (modelo.Entidad.Recacodi == 0)
                    bDuplicarData = true; //Nuevo
                if (modelo.Recafecini != "" && modelo.Recafecini != null)
                    modelo.Entidad.Recafecini = DateTime.ParseExact(modelo.Recafecini, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                if (modelo.Recafecfin != "" && modelo.Recafecfin != null)
                    modelo.Entidad.Recafecfin = DateTime.ParseExact(modelo.Recafecfin, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                modelo.Entidad.Recausername = User.Identity.Name;
                //modelo.IdRecalculo = (new GeneralAppServicioRecalculo()).SaveOrUpdateRecalculo(modelo.Entidad);
                if (bDuplicarData)
                {
                    modelo.IdRecalculo = 2; //COMENTAR LUEGO DE LA IMPLELEMNTACIÓN
                    int iIdBorrar;
                    int iPeriCodi = modelo.Entidad.Recapericodi;
                    int iVersionNew = modelo.IdRecalculo;
                    int iVersionOld = modelo.IdRecalculo - 1; //Versión atenrior a duplicar
                    //Eliminamos información anterior
                    iIdBorrar = (new GeneralAppServicioFactorPerdida()).DeleteListaFactorPerdida(iPeriCodi, iVersionNew);
                    //Duplicamos la información de la tabla TRN_FACTOR_PERDIDA
                    FactorPerdidaModel modelFacPer = new FactorPerdidaModel();
                    modelFacPer.ListaFactoresPerdida = (new GeneralAppServicioFactorPerdida()).ListByPeriodoVersion(iPeriCodi, iVersionOld);
                    foreach (var dtoFP in modelFacPer.ListaFactoresPerdida)
                    {
                        dtoFP.FacPerCodi = 0;
                        dtoFP.FacPerVersion = iVersionNew;
                        modelFacPer.IdFactorPerdida = (new GeneralAppServicioFactorPerdida()).SaveFactorPerdida(dtoFP);
                    }
                }
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            //Error
            modelo.sError = "Se ha producido un error al insertar la información";
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(modelo.Entidad.Recapericodi);
            TempData["Periodonombre"] = modelPeriodo.Entidad.Perinombre;
            return PartialView(modelo);
        }

        public ActionResult Edit(int id)
        {
            RecalculoModel modelo = new RecalculoModel();
            modelo.Entidad = (new GeneralAppServicioRecalculo()).GetByIdRecalculo(id);
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.Recafecini = modelo.Entidad.Recafecini.ToString("dd/MM/yyyy");
            modelo.Recafecfin = modelo.Entidad.Recafecfin.ToString("dd/MM/yyyy");
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(modelo.Entidad.Recapericodi);
            TempData["Periodonombre"] = modelPeriodo.Entidad.Perinombre;
            return PartialView(modelo); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string Delete(int id = 0)
        {
            RecalculoModel model = new RecalculoModel();
            model.IdRecalculo = (new GeneralAppServicioRecalculo()).DeleteRecalculo(id);
            return "true";
        }

    }
}
