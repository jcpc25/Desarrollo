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
        public PartialViewResult Lista(string idsEmpresa, string idsCuenca,int idTipoInformacion, string fechaInicial, string fechaFinal, int nroPagina)
        {
            HidrologiaModel model = new HidrologiaModel();
            var formato = logic.GetByIdMeFormato(idTipoInformacion);
            formato.ListaHoja = logic.GetByCriteriaMeFormatohojas(idTipoInformacion);
            DateTime fechaIni = DateTime.MinValue;
            DateTime fechaFin = DateTime.MinValue;
            switch (formato.Formatresolucion)
            {
                case 60 * 24 * 30://mensual ->ListaMedidores1
                    int mes = Int32.Parse(fechaInicial.Substring(0, 2));
                    int anho = Int32.Parse(fechaInicial.Substring(3, 4));
                    fechaIni = new DateTime(anho, mes, 1);
                    anho = Int32.Parse(fechaFinal.Substring(3, 4));
                    mes = Int32.Parse(fechaFinal.Substring(0, 2));
                    fechaFin = new DateTime(anho, mes, 1);
                    break;
                case 60*24: //semanal -> ListaMedidores1
                    int ianho = Int32.Parse(fechaInicial.Substring(0, 4));
                    fechaIni = new DateTime(ianho, 1, 1);
                    ianho = Int32.Parse(fechaFinal.Substring(0, 4));
                    fechaFin = new DateTime(ianho, 1, 1);
                    break;
                default:
                    fechaIni = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    fechaFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    break;
            }
            string resultado = this.logic.ObtenerReporteHidrologia(idsEmpresa,idsCuenca, fechaIni, fechaFin, formato);
            model.Resultado = resultado;
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult GraficoReporte()
            //(string fechaInicial, string fechaFinal, string idsempresas, string idscuencas, int idptomedida)
        {
            HidrologiaModel model = new HidrologiaModel();
            List<PtoMedida> Lista = new List<PtoMedida>();

            Lista.Add(new PtoMedida() { IdMedida1 = 1.2, IdMedida2 = 1.2, NombreMedida = "ENE" });
            Lista.Add(new PtoMedida() { IdMedida1 = 0.5, IdMedida2 = 1.7, NombreMedida = "FEB" });
            Lista.Add(new PtoMedida() { IdMedida1 = 3.4, IdMedida2 = 1.9, NombreMedida = "MAR" });
            Lista.Add(new PtoMedida() { IdMedida1 = 4.5, IdMedida2 = 2.5, NombreMedida = "ABR" });
            Lista.Add(new PtoMedida() { IdMedida1 = 0.8, IdMedida2 = 3.5, NombreMedida = "MAY" });
            Lista.Add(new PtoMedida() { IdMedida1 = 2.5, IdMedida2 = 4.8, NombreMedida = "JUN" });
            Lista.Add(new PtoMedida() { IdMedida1 = 7.8, IdMedida2 = 5, NombreMedida = "JUL" });
            Lista.Add(new PtoMedida() { IdMedida1 = 8.0, IdMedida2 = 2.9, NombreMedida = "AGO" });
            Lista.Add(new PtoMedida() { IdMedida1 = 0.9, IdMedida2 = 3.4, NombreMedida = "SET" });
            Lista.Add(new PtoMedida() { IdMedida1 = 10.5,IdMedida2 = 5.6, NombreMedida = "OCT" });
            Lista.Add(new PtoMedida() { IdMedida1 = 11.5, IdMedida2 = 10, NombreMedida = "NOV" });
            Lista.Add(new PtoMedida() { IdMedida1 = 12.7, IdMedida2 = 0.9, NombreMedida = "DIC" });
            model.ListaPtoMedida = Lista;

            var jsonResult = Json(model);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

    }
}
