using COES.MVC.Intranet.Areas.Transferencias.Models;
using COES.Servicios.Aplicacion.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class InfoDesbalanceController : Controller
    {
        //
        // GET: /Transferencias/InfoDesbalance/

        public ActionResult Index()
        {

            PeriodoModel modelPeriodo1 = new PeriodoModel();
            modelPeriodo1.ListaPeriodos = (new GeneralAppServicioPeriodo()).ListPeriodo();

            TempData["PERIANIOMES1"] = new SelectList(modelPeriodo1.ListaPeriodos, "PERICODI", "PERINOMBRE");

            return View();
        }


        //POST
        [HttpPost]
        public ActionResult Lista(string periodo)
        {
            InfoDesbalanceModel model = new InfoDesbalanceModel();
            model.ListaInfodesbalance = (new GeneralAppServicioInfoDesbalance()).BuscarInfoDesbalance(periodo);

            return PartialView(model);
        }
    }
}
