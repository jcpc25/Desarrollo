using COES.Dominio.DTO.Transferencias;
using COES.MVC.Intranet.Areas.Transferencias.Models;
using COES.MVC.Intranet.Models;
using COES.Servicios.Aplicacion.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class InfoDesviacionController : Controller
    {
        // GET: /Transferencias/InfoDesviacion/
        public ActionResult Index()
        {
            PeriodoModel modelPeriodo = new PeriodoModel();
            modelPeriodo.ListaPeriodos = (new GeneralAppServicioPeriodo()).ListPeriodo();

            TempData["Periodo"] = new SelectList(modelPeriodo.ListaPeriodos, "PERIANIOMES", "PERINOMBRE");

            return Lista(201001, 0, 1);
        }

        //POST
        [HttpPost]
        public ActionResult Lista(Int32 AnioMes, Decimal Desviacion, Int32 Valorizaciones)
        {
            // Dias del Mes Seleccionado
            Int32 Dias = System.DateTime.DaysInMonth(Convert.ToInt32(AnioMes.ToString().Substring(0, 4)), Convert.ToInt32(AnioMes.ToString().Substring(4, 2)));

            DateTime Fecha1 = DateTime.ParseExact(AnioMes.ToString() + "01", "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(-Valorizaciones);
            DateTime Fecha2 = DateTime.ParseExact(AnioMes.ToString() + "01", "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddDays(-1);

            Int32 AnioMes1 = Convert.ToInt32(Fecha1.ToString("yyyyMM"));
            Int32 AnioMes2 = Convert.ToInt32(Fecha2.ToString("yyyyMM"));

            Int32 DiasMeses = (Fecha2.Date - Fecha1.Date).Days + 1;

            InfoDesviacionModel model = new InfoDesviacionModel();
            model.ListaInfoDesviacion = (new GeneralAppServicioInfoDesviacion()).BuscarInfoDesviacion(AnioMes, AnioMes1, AnioMes2, Dias, DiasMeses, Desviacion);

            return PartialView(model);
        }

    }
}
