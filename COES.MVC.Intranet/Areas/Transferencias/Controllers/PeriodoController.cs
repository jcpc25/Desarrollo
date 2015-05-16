using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using COES.Dominio.DTO.Transferencias;
using COES.MVC.Intranet.Areas.Transferencias.Models;
using COES.Servicios.Aplicacion.Transferencias;
using COES.MVC.Intranet.Helper;
using COES.MVC.Intranet.Areas.Transferencias.Helper;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class PeriodoController : Controller
    {
        // GET: /Transferencias/Periodo/
        //[CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Lista(string nombre)
        {
            PeriodoModel model = new PeriodoModel();
            model.ListaPeriodos = (new GeneralAppServicioPeriodo()).BuscarPeriodo(nombre);

            model.bNuevo = (new Funcion()).ValidarPermnisoNuevo(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEditar = (new Funcion()).ValidarPermnisoEditar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            model.bEliminar = (new Funcion()).ValidarPermnisoEliminar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            return PartialView(model);
        }
        //
        // GET: /Transferencias/Periodo/Details/5

        public ActionResult View(int id = 0)
        {
            PeriodoModel model = new PeriodoModel();
            model.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(id);

            return PartialView(model);
        }
        
        //
        // GET: /Transferencias/Periodo/Create
        public ActionResult New()
        {
            PeriodoModel modelo = new PeriodoModel();
            modelo.Entidad = new PeriodoDTO();
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.Entidad.Pericodi = 0;
            modelo.Entidad.Perihoralimite = "20:00";
            modelo.Perifechavalorizacion = System.DateTime.Now.ToString("dd/MM/yyyy");
            modelo.Perifechalimite = System.DateTime.Now.ToString("dd/MM/yyyy");
            modelo.Perifechaobservacion = System.DateTime.Now.ToString("dd/MM/yyyy");
            modelo.Entidad.Aniocodi = DateTime.Today.Year;
            modelo.Entidad.Mescodi = DateTime.Today.Month;
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            TempData["Mescodigo"] = new SelectList((new Funcion()).ObtenerMes(), "Value", "Text", modelo.Entidad.Mescodi);
            TempData["Aniocodigo"] = new SelectList((new Funcion()).ObtenerAnio(), "Value", "Text", modelo.Entidad.Aniocodi);
            return PartialView(modelo); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PeriodoModel modelo)
        {
            bool bRecalculo = false;
            if (ModelState.IsValid)
            {
                if (modelo.Entidad.Pericodi == 0)
                    bRecalculo = true; //Nuevo
                if (modelo.Entidad.Perianiomes == 0)
                    modelo.Entidad.Perianiomes = modelo.Entidad.Aniocodi * 100 + modelo.Entidad.Mescodi;
                if (modelo.Entidad.Periestado.Equals(""))
                    modelo.Entidad.Periestado = "Abierto";
                if (modelo.Perifechalimite != "" && modelo.Perifechalimite != null)
                    modelo.Entidad.Perifechalimite = DateTime.ParseExact(modelo.Perifechalimite, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                if (modelo.Perifechavalorizacion != "" && modelo.Perifechavalorizacion != null)
                    modelo.Entidad.Perifechavalorizacion = DateTime.ParseExact(modelo.Perifechavalorizacion, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                if (modelo.Perifechaobservacion != "" && modelo.Perifechaobservacion !=  null)
                    modelo.Entidad.Perifechaobservacion = DateTime.ParseExact(modelo.Perifechaobservacion, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                modelo.Entidad.Periusername = User.Identity.Name;
                modelo.IdPeriodo = (new GeneralAppServicioPeriodo()).SaveOrUpdatePeriodo(modelo.Entidad);
                if (bRecalculo)
                {   //Insertamos la version 1 en el recalculo 
                    RecalculoDTO dto = new RecalculoDTO();
                    dto.Recapericodi = modelo.IdPeriodo;
                    dto.Recausername = User.Identity.Name;
                    dto.Recafecini = modelo.Entidad.Perifechalimite;
                    dto.Recafecfin = modelo.Entidad.Perifechalimite;
                    dto.Recadesc = "Apertura del periodo";
                    RecalculoModel model = new RecalculoModel();
                    model.IdRecalculo = (new GeneralAppServicioRecalculo()).SaveOrUpdateRecalculo(dto);
                }
                TempData["sMensajeExito"] = "La información ha sido correctamente registrada";
                return RedirectToAction("Index");
            }
            //Error
            modelo.sError = "Se ha producido un error al insertar la información";
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            TempData["Mescodigo"] = new SelectList((new Funcion()).ObtenerMes(), "Value", "Text", modelo.Entidad.Mescodi);
            TempData["Aniocodigo"] = new SelectList((new Funcion()).ObtenerAnio(), "Value", "Text", modelo.Entidad.Aniocodi);
            return PartialView(modelo); 
        }

        //
        // GET: /Transferencias/Periodo/Edit/id
        public ActionResult Edit(int id)
        {
            PeriodoModel modelo = new PeriodoModel();
            modelo.Entidad = (new GeneralAppServicioPeriodo()).GetByIdPeriodo(id);
            if (modelo.Entidad == null)
            {
                return HttpNotFound();
            }
            modelo.Perifechavalorizacion = modelo.Entidad.Perifechavalorizacion.ToString("dd/MM/yyyy");
            modelo.Perifechalimite = modelo.Entidad.Perifechalimite.ToString("dd/MM/yyyy");
            modelo.Perifechaobservacion = modelo.Entidad.Perifechaobservacion.ToString("dd/MM/yyyy");
            modelo.bGrabar = (new Funcion()).ValidarPermnisoGrabar(Session[DatosSesion.SesionIdOpcion], User.Identity.Name);
            TempData["Mescodigo"] = new SelectList((new Funcion()).ObtenerMes(), "Value", "Text", modelo.Entidad.Mescodi);
            TempData["Aniocodigo"] = new SelectList((new Funcion()).ObtenerAnio(), "Value", "Text", modelo.Entidad.Aniocodi);
            return PartialView(modelo); 
        }

        // POST: /Transferencias/Periodo/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string Delete(int id = 0)
        {
            PeriodoModel model = new PeriodoModel();
            model.IdPeriodo = (new GeneralAppServicioPeriodo()).DeletePeriodo(id);
            return "true";
        }
    }
}
