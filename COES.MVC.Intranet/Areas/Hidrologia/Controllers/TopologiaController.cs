﻿using COES.MVC.Intranet.Areas.Hidrologia.Helper;
using COES.MVC.Intranet.Areas.Hidrologia.Models;
using COES.Servicios.Aplicacion.Hidrologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Hidrologia.Controllers
{
    public class TopologiaController : Controller
    {
        //
        // GET: /Hidrologia/Topologia/
        HidrologiaAppServicio logic = new HidrologiaAppServicio();

        public ActionResult Index()
        {
            HidrologiaModel model = new HidrologiaModel();
            model.ListaCuenca = this.logic.ListarEquiposXFamilia(41);
            model.ListaTipoRecursos = this.logic.ListarTipoRecursos(Constantes.Recursos);
            return View(model);
        }

        public PartialViewResult lista(int cuenca, int nroPagina, string recursos)
        {
            HidrologiaModel model = new HidrologiaModel();
            model.ListaRecursosCuenca = this.logic.ListarRecursosxCuenca(cuenca, recursos);
            return PartialView(model);
        }
    }
}
