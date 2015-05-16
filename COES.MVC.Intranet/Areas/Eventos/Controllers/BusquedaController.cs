using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using COES.MVC.Intranet.Areas.Eventos.Models;
using COES.MVC.Intranet.Helper;
using COES.Servicios.Aplicacion.Eventos;

namespace COES.MVC.Intranet.Areas.Eventos.Controllers
{
    public class BusquedaController : Controller
    {
        EventoAppServicio servicio = new EventoAppServicio();

        public PartialViewResult Index()
        {
            BusquedaEquipoModel model = new BusquedaEquipoModel();

            model.ListaEmpresa = this.servicio.ListarEmpresas().Where(x => x.EMPRCODI != 0 && x.EMPRCODI != -1).ToList();
            model.ListaFamilia = this.servicio.ListarFamilias().ToList();

            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult Area(int idEmpresa)
        {
            BusquedaEquipoModel model = new BusquedaEquipoModel();
            model.ListaArea = servicio.ObtenerAreaPorEmpresa(idEmpresa).ToList();
            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult Resultado(int idEmpresa, int idFamilia, int idArea, string filtro, int nroPagina)
        {
            BusquedaEquipoModel model = new BusquedaEquipoModel();
            model.ListaEquipo = servicio.BuscarEquipoEvento(idEmpresa, idArea, idFamilia, filtro, nroPagina, Constantes.PageSize).ToList();
            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult Paginado(int idEmpresa, int idFamilia, int idArea, string filtro)
        {
            BusquedaEquipoModel model = new BusquedaEquipoModel();
            model.IndicadorPagina = false;
            int nroRegistros = servicio.ObtenerNroFilasBusquedaEquipo(idEmpresa, idArea, idFamilia, filtro);

            if (nroRegistros > Constantes.NroPageShow)
            {
                int pageSize = Constantes.PageSize;
                int nroPaginas = (nroRegistros % pageSize == 0) ? nroRegistros / pageSize : nroRegistros / pageSize + 1;
                model.NroPaginas = nroPaginas;
                model.NroMostrar = Constantes.NroPageShow;
                model.IndicadorPagina = true;
            }

            return PartialView(model);
        }

    }
}
