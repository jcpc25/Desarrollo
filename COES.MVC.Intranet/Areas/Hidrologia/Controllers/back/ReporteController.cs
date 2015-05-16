using COES.MVC.Intranet.Areas.Hidrologia.Helper;
using COES.MVC.Intranet.Areas.Hidrologia.Models;
using COES.Servicios.Aplicacion.Hidrologia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Hidrologia.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Hidrologia/Reporte/
        HidrologiaAppServicio logic = new HidrologiaAppServicio();
        public ActionResult Index()
        {
            HidrologiaModel model = new HidrologiaModel();
            model.ListaEmpresas = this.logic.ListarEmpresasPorTipo(Constantes.EmpresaGeneradora.ToString());
            model.ListaPtoMedida = Tools.ObtenerListaMedida();
            model.ListaCuenca = this.logic.ListarEquiposXFamilia(41);
            model.FechaInicio = DateTime.Now.AddDays(-15).ToString(Constantes.FormatoFecha);
            model.FechaFin = DateTime.Now.ToString(Constantes.FormatoFecha);
            model.ListaTipoInformacion = Tools.ObtenerListaFormato();
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Lista(string idsEmpresa, int idTipoInformacion, string fechaInicial, string fechaFinal, int nroPagina)
        {
            HidrologiaModel model = new HidrologiaModel();
            var formato = logic.GetByIdMeFormato(idTipoInformacion);
            formato.ListaHoja = logic.GetByCriteriaMeFormatohojas(idTipoInformacion);
            DateTime fechaIni = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            DateTime fechaFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            //switch (formato.Formatresolucion)
            //{
            //    case 15://ListaMedidores96
            //        break;
            //    case 30: //ListaMedidores48
            //        break;
            //    case 60://ListaMedidores24
            //        break;
            //    case 60 * 24://ListaMedidores1
            //        break;
            //}
            string resultado = this.logic.ObtenerReporteHidrologia(idsEmpresa, fechaIni, fechaFin, formato); ///VARIAR POR EL TIPO DE REPORTE: TIPO 1, TIPO 2
            model.Resultado = resultado;
            return PartialView(model);
        }

    }
}
