using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COES.MVC.Intranet.Areas.Equipamiento.Models;
using COES.Servicios.Aplicacion.Equipamiento;
using COES.MVC.Intranet.Helper;
namespace COES.MVC.Intranet.Areas.Equipamiento.Controllers
{
    public class AreaController : Controller
    {
        /// <summary>
        /// Instancia de clase para el acceso a datos
        /// </summary>
        EquipamientoAppServicio servicio = new EquipamientoAppServicio();
        //
        // GET: /Equipamiento/Area/

        public ActionResult Index()
        {
            AreaModel modelo = new AreaModel();
            modelo.ListaTipoArea = servicio.ListEqTipoareas();
            modelo.idTipoArea = 0;
            return View(modelo);
        }

        [ActionName("Index"), HttpPost]
        public ActionResult IndexPost(AreaModel datosVentana)
        {
            datosVentana.ListaTipoArea = servicio.ListEqTipoareas();
            return View(datosVentana);
        }


        public ActionResult ListadoAreas(string sidx, string sord, int page, int rows,string pTipoArea,string pNombre)
        {
            int totalPages = 0;
            int iTipoArea = pTipoArea=="0"?-99:Convert.ToInt32(pTipoArea);
            var lsResultado = servicio.ListarxFiltro(iTipoArea, pNombre, page, Constantes.PageSizeEvento);
            int totalRecords = servicio.CantidadListarxFiltro(iTipoArea, pNombre);
            totalPages = (totalRecords % rows == 0) ? totalRecords / rows : totalRecords / rows + 1;
            var jsondata = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = (
                from q in lsResultado
                select new
                {
                    cell = new string[]
                    {
                        q.Areacodi.ToString(),
                        q.Areanomb,
                        string.IsNullOrEmpty(q.Areaabrev) ?"":q.Areaabrev,
                        q.Areacodi.ToString(),
                    }
                }
                ).ToArray()
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public PartialViewResult ListarAreas(AreaModel datosVentana)
        //{
        //    datosVentana.IndicadorPagina = false;
        //    int iTipoArea = datosVentana.idTipoArea == 0 ? -99 : datosVentana.idTipoArea;

        //    int nroRegistros = servicio.CantidadListarxFiltro(iTipoArea, datosVentana.NombreArea);

        //    if (nroRegistros > Constantes.NroPageShow)
        //    {
        //        int pageSize = Constantes.PageSizeEvento;
        //        int nroPaginas = (nroRegistros % pageSize == 0) ? nroRegistros / pageSize : nroRegistros / pageSize + 1;
        //        datosVentana.NroPaginas = nroPaginas;
        //        datosVentana.NroMostrar = Constantes.NroPageShow;
        //        datosVentana.IndicadorPagina = true;
        //    }

        //    datosVentana.ListaArea = servicio.ListarxFiltro(iTipoArea, datosVentana.NombreArea, datosVentana.NroPagina, Constantes.PageSizeEvento);

        //    return PartialView(datosVentana);
        //}

        public ActionResult Detalle(int id)
        {
            var oArea= servicio.GetByIdEqArea(id);
            var modelo = new AreaDetalleModel();
            modelo.Areaabrev = oArea.Areaabrev;
            modelo.Areacodi = oArea.Areacodi;
            modelo.Areanomb = oArea.Areanomb;
            modelo.Areapadre = oArea.Areapadre;
            modelo.Tareacodi = oArea.Tareacodi;

            return View(modelo);
        }

    }
}
