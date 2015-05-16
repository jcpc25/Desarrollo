using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COES.MVC.Intranet.Models;
using COES.Servicios.Aplicacion.General;

namespace COES.MVC.Intranet.Controllers
{
    public class GeneralController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Grilla(string nombre)
        {
            EmpresaModel model = new EmpresaModel();
            model.ListaEmpresas = null;                   

            return PartialView(model);
        }
    }
}
