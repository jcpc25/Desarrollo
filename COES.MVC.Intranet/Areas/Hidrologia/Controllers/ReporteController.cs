using COES.Dominio.DTO.Sic;
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
        public JsonResult GraficoReporte(string idsEmpresas, string fechaInicial, string fechaFinal)
            //(string fechaInicial, string fechaFinal, string idsempresas, string idscuencas, int idptomedida)
        {
            HidrologiaModel model = new HidrologiaModel();
            DateTime fechaIni = DateTime.MinValue;
            DateTime fechaFin = DateTime.MinValue;
            List<MeMedicion1DTO> ListaMes = new List<MeMedicion1DTO>();
            List<MeMedicion1DTO> listaMesAux = new List<MeMedicion1DTO>();  
            int mes = Int32.Parse(fechaInicial.Substring(0, 2));
            int anho = Int32.Parse(fechaInicial.Substring(3, 4));
            fechaIni = new DateTime(anho, mes, 1);
            anho = Int32.Parse(fechaFinal.Substring(3, 4));
            mes = Int32.Parse(fechaFinal.Substring(0, 2));
            fechaFin = new DateTime(anho, mes, 1);                        

            ListaMes = this.logic.listaRptMesPtoMedicion(24, 5, idsEmpresas, fechaIni, fechaFin);

            foreach (MeMedicion1DTO list in ListaMes)
            {
                list.AmhoMesPtomedi = COES.Base.Tools.Util.ObtenerMesAnho(list.Medifecha);                   
                listaMesAux.Add(list);              
            }
            ListaMes = listaMesAux;
            var jsonResult = Json(ListaMes);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

    }
}
