using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COES.Dominio.DTO.Transferencias;
using COES.MVC.Intranet.Models;
using COES.MVC.Intranet.Areas.Transferencias.Models;
using COES.Servicios.Aplicacion.Transferencias;
using COES.MVC.Intranet.Helper;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Collections;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class InfoFaltanteController : Controller
    {
        // GET: /Transferencias/InfoFaltante/
        public ActionResult Index()
        {
            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.ListaPeriodos = (new GeneralAppServicioPeriodo()).ListPeriodo();

            TempData["Periodo"] = new SelectList(modelPeriodo.ListaPeriodos, "PERICODI", "PERINOMBRE");

            return Lista(0);
        }

        // POST
        [HttpPost]
        public ActionResult Lista(Int32 PeriCodi)
        {
            InfoFaltanteModel model = new InfoFaltanteModel();
            model.ListaInfoFaltante = (new GeneralAppServicioInfoFaltante()).BuscarInfoFaltante(PeriCodi);

            return PartialView(model);
        }

    }
}
