using COES.MVC.Intranet.Areas.Mediciones.Models;
using COES.Servicios.Aplicacion.Equipamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Mediciones.Controllers
{
    public class ConfiguracionController : Controller
    {
        DespachoAppServicio logic = new DespachoAppServicio();

        /// <summary>
        /// Permite cargar la pagina inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ConfiguracionModel model = new ConfiguracionModel();
            model.ListaTipoGrupo = this.logic.GetByCriteriaPrTipogrupos();
            return View(model);
        }

        /// <summary>
        /// Realizar un listado de los grupos
        /// </summary>
        /// <param name="idTipoGrupo"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Lista(int idTipoGrupo)
        {
            ConfiguracionModel model = new ConfiguracionModel();
            model.ListaGrupo = this.logic.ObtenerMantenimientoGrupoRER(idTipoGrupo);
            return PartialView(model);
        }

        /// <summary>
        /// Permite actualizar el tipo de grupo
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <param name="idTipoGrupo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CambiarTipoGrupo(int idGrupo, int idTipoGrupo)
        {
            try
            {
                this.logic.CambiarTipoGrupo(idGrupo, idTipoGrupo, User.Identity.Name);
                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }

        [HttpPost]
        public PartialViewResult Edicion(int idGrupo, string emprNomb, string grupoNomb, 
            string grupoAbrev, int idTipoGrupo)
        {
            ConfiguracionModel model = new ConfiguracionModel();

            model.IdGrupo = idGrupo;
            model.EmpresaNombre = emprNomb;
            model.GrupoNombre = grupoNomb;
            model.GrupoAbreviacion = grupoAbrev;
            model.TipoGrupoCodi = idTipoGrupo;
            model.ListaTipoGrupo = this.logic.GetByCriteriaPrTipogrupos();

            return PartialView(model);
        }

    }
}
