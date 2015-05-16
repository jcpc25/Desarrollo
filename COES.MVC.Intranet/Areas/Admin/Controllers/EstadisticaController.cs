﻿using COES.MVC.Intranet.Areas.Admin.Helper;
using COES.MVC.Intranet.Areas.Admin.Models;
using COES.MVC.Intranet.Helper;
using COES.MVC.Intranet.SeguridadServicio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Admin.Controllers
{
    public class EstadisticaController : Controller
    {
        /// <summary>
        /// Acceso al servicio de seguridad
        /// </summary>
        SeguridadServicioClient servicio = new SeguridadServicioClient();

        /// <summary>
        /// Muestra la pantalla inicial de la opcion
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            EstadisticaModel model = new EstadisticaModel();
            model.FechaInicio = DateTime.Now.AddDays(-7).ToString(Constantes.FormatoFecha);
            model.FechaFin = DateTime.Now.AddDays(1).ToString(Constantes.FormatoFecha);

            return View(model);
        }

        /// <summary>
        /// Permite mostrar el menu de opciones
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Tree()
        {
            List<OptionDTO> list = this.servicio.ObtenerOpcionPorSistema(Constantes.IdAplicacion).ToList();
            string menu = (new MenuHelper()).ObtenerTreeOpciones(list, string.Empty);
            ViewBag.Menu = menu;

            return PartialView();
        }

        /// <summary>
        /// Muestra reporte por aplicacion y rango de fechas
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Aplicacion(string fechaInicio, string fechaFin)
        {
            EstadisticaModel model = new EstadisticaModel();
            DateTime fecInicio = DateTime.Now;
            DateTime fecFin = DateTime.Now;

            if (!string.IsNullOrEmpty(fechaInicio))
            {
                fecInicio = DateTime.ParseExact(fechaInicio, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(fechaFin))
            {
                fecFin = DateTime.ParseExact(fechaFin, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }

            List<LogOptionDTO> list = this.servicio.ObtenerEstadisticaPorSistema(Constantes.IdAplicacion, fecInicio, fecFin).ToList();
            model.ListaEstadistica = list;
            return PartialView(model);
        }

        /// <summary>
        /// Muestra reporte por opcion y rango de fechas
        /// </summary>
        /// <param name="idOpcion"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Opcion(int idOpcion, string fechaInicio, string fechaFin)
        {
            EstadisticaModel model = new EstadisticaModel();
            DateTime fecInicio = DateTime.Now;
            DateTime fecFin = DateTime.Now;

            if (!string.IsNullOrEmpty(fechaInicio))
            {
                fecInicio = DateTime.ParseExact(fechaInicio, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(fechaFin))
            {
                fecFin = DateTime.ParseExact(fechaFin, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }
            
            List<LogOptionDTO> list = this.servicio.ObtenerEstadisticaPorOpcion(idOpcion, fecInicio, fecFin).ToList();
            model.ListaEstadistica = list;
            return PartialView(model);
        }
    }
}
