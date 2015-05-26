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
        public JsonResult GraficoReporte(string idsEmpresas,string idsCuencas, string fechaInicial, string fechaFinal,int idTipoInformacion)
            //(string fechaInicial, string fechaFinal, string idsempresas, string idscuencas, int idptomedida)
        {
            HidrologiaModel model = new HidrologiaModel();
            DateTime fechaIni = DateTime.MinValue;
            DateTime fechaFin = DateTime.MinValue;
            var formato = logic.GetByIdMeFormato(idTipoInformacion);
            formato.ListaHoja = logic.GetByCriteriaMeFormatohojas(idTipoInformacion);
            model.TituloReporte = formato.ListaHoja[0].Hojatitulo;
            switch (formato.Formatresolucion)
            {
                case 60 * 24 * 30: //grafico mensual
                    int mes = Int32.Parse(fechaInicial.Substring(0, 2));
                    int anho = Int32.Parse(fechaInicial.Substring(3, 4));
                    fechaIni = new DateTime(anho, mes, 1);
                    anho = Int32.Parse(fechaFinal.Substring(3, 4));
                    mes = Int32.Parse(fechaFinal.Substring(0, 2));
                    fechaFin = new DateTime(anho, mes, 1);
                    model.TipoReporte = idTipoInformacion;
                    model = GraficoMensual((int)formato.ListaHoja[0].Lectcodi, idsEmpresas, fechaIni, fechaFin);
                    break;
                case 30: //grafio diario
                    fechaIni = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    fechaFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    model.TipoReporte = idTipoInformacion;
                    model = GraficoDiario((int)formato.ListaHoja[0].Lectcodi, idsEmpresas,idsCuencas ,formato, fechaIni, fechaFin);
                    break;
                case 60:
                    fechaIni = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    fechaFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    model.TipoReporte = idTipoInformacion;
                    model = GraficoDiario((int)formato.ListaHoja[0].Lectcodi, idsEmpresas,idsCuencas, formato ,fechaIni, fechaFin);
                    break;
            }
            var jsonResult = Json(model);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public HidrologiaModel GraficoMensual(int idLectura, string idsEmpresas, DateTime fechaIni, DateTime fechaFin)
        {
            HidrologiaModel model = new HidrologiaModel();
            List<MeMedicion1DTO> lista = this.logic.ListaMed1Hidrologia(idLectura, 5, idsEmpresas, fechaIni, fechaFin);
            model.ListaCategoriaGrafico = new List<string>();
            model.ListaSerieName = new List<string>();

            // Obtener Lista de Anho y Mes ordenados para la categoria del grafico
            int totalMeses = 0;
            for (var f = fechaIni; f <= fechaFin; f = f.AddMonths(1))
            {
                string anhoMes = COES.Base.Tools.Util.ObtenerNombreMesAbrev(f.Month) + " " +
                   f.Year.ToString().Substring(2, 2);
                model.ListaCategoriaGrafico.Add(anhoMes);
                totalMeses++;
            }

            // Obtener Lista de nombres de las series del grafico.
            var listaGrupoMedicion = lista.GroupBy(x => x.Ptomedicodi).Select(group => group.First()).ToList();
            foreach (var reg in listaGrupoMedicion)
            {
                string nombreSerie = reg.Ptomedinomb + " " + reg.Tipoptomedinomb + " " + reg.Tipoinfoabrev;
                model.ListaSerieName.Add(nombreSerie);
            }
            // Obtener lista de valores para las series del grafico
            model.ListaSerieData = new decimal?[listaGrupoMedicion.Count()][];
            for (var i = 0; i < listaGrupoMedicion.Count(); i++)
            {
                model.ListaSerieData[i] = new decimal?[totalMeses];
                var j = 0;
                for (var f = fechaIni; f <= fechaFin; f = f.AddMonths(1))
                {
                    decimal? valor = null;
                    var entity = lista.Find(x => x.Ptomedicodi == listaGrupoMedicion[i].Ptomedicodi && x.Medifecha == f);
                    if (entity != null)
                    {
                        valor = entity.H1;
                        model.ListaSerieData[i][j] = valor;
                    }
                    j++;
                }
            }
            return model;
        }

        public HidrologiaModel GraficoDiario(int idLectura, string idsEmpresas, string idsCuencas, MeFormatoDTO formato, DateTime fechaIni, DateTime fechaFin)
        {
            HidrologiaModel model = new HidrologiaModel();
            List<MeMedicion24DTO> lista = this.logic.ListaMed24Hidrologia(idLectura, 5, idsEmpresas, idsCuencas, fechaIni, fechaIni);
            model.ListaCategoriaGrafico = new List<string>();
            model.ListaSerieName = new List<string>();
            int totalIntervalos = 60 * 24 / (int)formato.Formatresolucion;
            // Obtener Lista de intervalos categoria del grafico

            for (var j = 0; j <= (totalIntervalos - 1); j++)
            {
                string hora = ("0" + j.ToString()).Substring(("0" + j.ToString()).Length - 2, 2) + ":00";
                model.ListaCategoriaGrafico.Add(hora);

            }
            // Obtener Lista de nombres de las series del grafico.
            
            var listaGrupoMedicion = lista.GroupBy(x => new { x.Ptomedicodi, x.Tipoinfocodi }).Select(group => group.First()).ToList();
            foreach (var reg in listaGrupoMedicion)
            {
                string nombreSerie = reg.Ptomedinomb + " " + reg.Tipoptomedinomb + " " + reg.Tipoinfoabrev;
                model.ListaSerieName.Add(nombreSerie);
            }
            // Obtener lista de valores para las series del grafico
            model.ListaSerieData = new decimal?[listaGrupoMedicion.Count()][];
            for (var i = 0; i < listaGrupoMedicion.Count(); i++)
            {
                model.ListaSerieData[i] = new decimal?[totalIntervalos];
                var entity = lista.Find(x => x.Ptomedicodi == listaGrupoMedicion[i].Ptomedicodi &&
                    x.Tipoinfocodi == listaGrupoMedicion[i].Tipoinfocodi && x.Medifecha == fechaIni);
                if (entity != null)
                {
                    for (var j = 1; j <= totalIntervalos; j++)
                    {
                        decimal valor = (decimal)entity.GetType().GetProperty("H" + j).GetValue(entity, null);
                        model.ListaSerieData[i][j - 1] = valor;
                    }
                }

            }
            return model;
        }

    }
}
