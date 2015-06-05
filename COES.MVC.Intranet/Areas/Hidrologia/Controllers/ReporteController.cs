using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Areas.Hidrologia.Helper;
using COES.MVC.Intranet.Areas.Hidrologia.Models;
using COES.Servicios.Aplicacion.Hidrologia;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        /// <summary>
        /// Almacena los fechas del reporte
        /// </summary>
        public List<DateTime> ListaFechas
        {
            get
            {
                return (Session[DatosSesion.ListaFechas] != null) ?
                    (List<DateTime>)Session[DatosSesion.ListaFechas] : new List<DateTime>();
            }
            set { Session[DatosSesion.ListaFechas] = value; }
        }

        /// <summary>
        /// Almacena los datos del reporte grafico Mensual QN
        /// </summary>
        public HidrologiaModel modelGraficoMensual
        {
            get
            {
                return (Session[DatosSesion.modelGraficoMensual] != null) ?
                    (HidrologiaModel)Session[DatosSesion.modelGraficoMensual] : new HidrologiaModel();
            }
            set { Session[DatosSesion.modelGraficoMensual] = value; }
        }

        /// <summary>
        /// Almacena los datos del reporte grafico Semanal QN
        /// </summary>
        public HidrologiaModel modelGraficoSemanal
        {
            get
            {
                return (Session[DatosSesion.modelGraficoSemanal] != null) ?
                    (HidrologiaModel)Session[DatosSesion.modelGraficoMensual] : new HidrologiaModel();
            }
            set { Session[DatosSesion.modelGraficoSemanal] = value; }
        }
        
        /// <summary>
        /// Almacena los datos del reporte grafico diario
        /// </summary>
        public HidrologiaModel modelGraficoDiario
        {
            get
            {
                return (Session[DatosSesion.modelGraficoDiario] != null) ?
                    (HidrologiaModel)Session[DatosSesion.modelGraficoDiario] : new HidrologiaModel();
            }
            set { Session[DatosSesion.modelGraficoDiario] = value; }
        }

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
        public PartialViewResult Lista(string idsEmpresa, string idsCuenca,int idTipoInformacion, string fechaInicial, string fechaFinal, int nroPagina,
                                       string anho, int semanaIni, int semanaFin, int opcion)
        {
            HidrologiaModel model = new HidrologiaModel();
            var formato = logic.GetByIdMeFormato(idTipoInformacion);
            formato.ListaHoja = logic.GetByCriteriaMeFormatohojas(idTipoInformacion);
            DateTime fechaIni = DateTime.MinValue;
            DateTime fechaFin = DateTime.MinValue;
            switch (formato.Formatresolucion)
            {
                case 60 * 24 * 30://mensual 
                    fechaIni = COES.Base.Tools.Util.FormatFecha(fechaInicial);
                    fechaFin = COES.Base.Tools.Util.FormatFecha(fechaFinal);
                    List<MeMedicion1DTO> lista = this.logic.ListaMed1Hidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa,fechaIni, fechaFin);
                    ListaFechas = lista.Select(x => x.Medifecha).Distinct().ToList();
                    if (ListaFechas.Count > 0)
                    {
                        fechaIni = lista.Min(x => x.Medifecha);
                        fechaFin = lista.Max(x => x.Medifecha);
                    }

                    break;
                case 60*24: //semanal 
                    int ianho = Int32.Parse(anho);
                    fechaIni = COES.Base.Tools.Util.GenerarFecha(ianho, semanaIni);
                    fechaFin = COES.Base.Tools.Util.GenerarFecha(ianho, semanaFin);                  
                    break;
                case 60 : //diario
                    fechaIni = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    fechaFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    List<MeMedicion24DTO> lista24 = this.logic.ListaMed24Hidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa, idsCuenca, fechaIni, fechaFin);
                    ListaFechas = lista24.Select(x => x.Medifecha).Distinct().ToList();
                    if (ListaFechas.Count > 0)
                    {
                        fechaIni = ListaFechas[nroPagina-1];
                    }
                    break;
                default:
                    fechaIni = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    fechaFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    break;
            }
            
            string resultado = this.logic.ObtenerReporteHidrologia(idsEmpresa, idsCuenca, fechaIni, fechaFin, formato, opcion);
            model.Resultado = resultado;
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult GraficoReporte(string idsEmpresas, string idsCuencas, string fechaInicial, string fechaFinal, int idTipoInformacion, int nroPagina,
                                        string anho, int semanaIni, int semanaFin)       
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
                    fechaIni = COES.Base.Tools.Util.FormatFecha(fechaInicial);
                    fechaFin = COES.Base.Tools.Util.FormatFecha(fechaFinal);                    
                    model = GraficoMensual((int)formato.ListaHoja[0].Lectcodi, idsEmpresas, fechaIni, fechaFin);
                    model.TipoReporte = idTipoInformacion;
                    break;
                case 60 * 24: //grafico semanal - QN
                    int ianho = Int32.Parse(anho);
                    fechaIni = COES.Base.Tools.Util.GenerarFecha(ianho, semanaIni);
                    fechaFin = COES.Base.Tools.Util.GenerarFecha(ianho, semanaFin);             
                    model = GraficoSemanal((int)formato.ListaHoja[0].Lectcodi, idsEmpresas, fechaIni, fechaFin);
                    model.TipoReporte = idTipoInformacion;
                    break;
                case 60: // grafico diario QN - TURB. VERT.
                    fechaIni = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    fechaFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);                   
                    model = GraficoDiario((int)formato.ListaHoja[0].Lectcodi, idsEmpresas, idsCuencas, formato, fechaIni, fechaFin, nroPagina);
                    model.TipoReporte = idTipoInformacion;
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
            model.ListaMedicion1 = lista;
            model.ListaCategoriaGrafico = new List<string>(); //AÑO - MES
            model.ListaSerieName = new List<string>();
            ListaFechas = lista.Select(x => x.Medifecha).Distinct().ToList();
            if (ListaFechas.Count > 0)
            {
                fechaIni = lista.Min(x => x.Medifecha);
                fechaFin = lista.Max(x => x.Medifecha);
            }
            model.TitlexAxis = "MESES - AÑO";
            model.TituloReporte = "REPORTE GRÁFICO PROGRAMADO MENSUAL - QN";
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
            modelGraficoMensual = model;
            return model;
        }

        public HidrologiaModel GraficoSemanal(int idLectura, string idsEmpresas, DateTime fechaIni, DateTime fechaFin)
        {
            HidrologiaModel model = new HidrologiaModel();
            List<MeMedicion1DTO> lista = this.logic.ListaMed1Hidrologia(idLectura, 5, idsEmpresas, fechaIni, fechaFin);
            model.ListaMedicion1 = lista;
            model.ListaCategoriaGrafico = new List<string>(); //
            model.ListaSerieName = new List<string>();
            ListaFechas = lista.Select(x => x.Medifecha).Distinct().ToList();
           
            if (ListaFechas.Count > 0)
            {
                fechaIni = lista.Min(x => x.Medifecha);
                fechaFin = lista.Max(x => x.Medifecha);
            }
             model.TitlexAxis = "AÑO :" + fechaIni.Year.ToString();
             model.TituloReporte = "REPORTE GRÁFICO PROGRAMADO SEMANAL - QN";
            // Obtener Lista de Sem-Nros ordenados para la categoria del grafico
            int nSemanaIni = COES.Base.Tools.Util.GenerarNroSemana(fechaIni);
            int nSemanaFin = COES.Base.Tools.Util.GenerarNroSemana(fechaFin);
            int nroSemanas = nSemanaFin - nSemanaIni + 1;
            for (var i = nSemanaIni; i <= nSemanaFin; i++)
            {
                string semNro = "Sem-" + i;                
                model.ListaCategoriaGrafico.Add(semNro);               
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
                model.ListaSerieData[i] = new decimal?[nroSemanas];              
                for (var j=0; j < nroSemanas; j++)
                {
                    DateTime fecha = ListaFechas[j];
                    decimal? valor = null;
                    var entity = lista.Find(x => x.Ptomedicodi == listaGrupoMedicion[i].Ptomedicodi && x.Medifecha == fecha);
                    if (entity != null)
                    {
                        valor = entity.H1;
                        model.ListaSerieData[i][j] = valor;
                    }                    
                }
            }
            modelGraficoSemanal = model;
            return model;
        }

        public HidrologiaModel GraficoDiario(int idLectura, string idsEmpresas, string idsCuencas, MeFormatoDTO formato, DateTime fechaIni, DateTime fechaFin, int nroPagina)
        {
            HidrologiaModel model = new HidrologiaModel();
            fechaIni = ListaFechas[nroPagina - 1];
            model.TitlexAxis = "Dia:" + fechaIni.ToString("dd - MM - yyyy");
            model.TituloReporte = "REPORTE GRÁFICO PROGRAMADO DIARIO - QN TURB. VERT";
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
                string nombreSerie = reg.Equinomb + "-" + reg.Tipoptomedinomb + " " + reg.Tipoinfoabrev;
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
            modelGraficoDiario = model;
            return model;
        }

        /// <summary>
        /// Permite mostrar el paginado de la consulta
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Paginado(string idsEmpresa, string idsCuenca, int idTipoInformacion, string fechaInicial, string fechaFinal)
        {
            HidrologiaModel model = new HidrologiaModel();
            model.IndicadorPagina = false;
            var formato = logic.GetByIdMeFormato(idTipoInformacion);
            formato.ListaHoja = logic.GetByCriteriaMeFormatohojas(idTipoInformacion);
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFin = DateTime.Now;

            if (fechaInicial != null)
            {
                fechaInicio = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }
            if (fechaFinal != null)
            {
                fechaFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }
            fechaFin = fechaFin.AddDays(1);

            int nroRegistros = this.logic.ObtenerNroFilasMed1Hidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa, idsCuenca, fechaInicio, fechaFin);

            if (nroRegistros > 0)
            {
                model.NroPaginas = nroRegistros;
                model.NroMostrar = Constantes.NroPageShow;
                model.IndicadorPagina = true;
            }

            return PartialView(model);
        }

        // exporta el reporte general consultado a archivo excel
        [HttpPost]
        public JsonResult GenerarArchivoReporteXLS(string idsEmpresa, string idsCuenca, int idTipoInformacion, string fechaInicial, string fechaFinal,
                                                    string annho, int semanaIni, int semanaFin)
        {
            int indicador = 1;
            DateTime fechaIni = DateTime.MinValue;
            DateTime fechaFin = DateTime.MinValue;
            HidrologiaModel model = new HidrologiaModel();
            var formato = logic.GetByIdMeFormato(idTipoInformacion);
            formato.ListaHoja = logic.GetByCriteriaMeFormatohojas(idTipoInformacion);
            try
            {
                switch (idTipoInformacion)
                {
                    case 4: //PROGRAMADO SEMANAL - QN.
                        int ianho = Int32.Parse(annho);
                        fechaIni = COES.Base.Tools.Util.GenerarFecha(ianho, semanaIni);
                        fechaFin = COES.Base.Tools.Util.GenerarFecha(ianho, semanaFin);
                        List<MeMedicion1DTO> lista1 = this.logic.ListaMed1Hidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa, fechaIni, fechaFin);                                            
                        model.FechaInicio = fechaIni.ToString("dd - MM - yyyy");
                        model.FechaFin = fechaFin.ToString("dd - MM - yyyy");
                        model.ListaMedicion1 = lista1;
                        ExcelDocument.GenerarArchivoHidrologiaSemanal(model);
                        indicador = 4;

                        break;
                    case 5: //EJECUTADO DIARIO - Q TURB. VERT.
                        fechaIni = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                        fechaFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                        List<MeMedicion24DTO> lista24 = this.logic.ListaMed24Hidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa, idsCuenca, fechaIni, fechaFin);
                        //ListaFechas = lista24.Select(x => x.Medifecha).Distinct().ToList();
                        model.FechaInicio = fechaIni.ToString("dd - MM - yyyy");
                        model.FechaFin = fechaFin.ToString("dd - MM - yyyy");
                        model.ListaMedicion24 = lista24;
                        ExcelDocument.GenerarArchivoHidrologiaDiario(model);
                        indicador = 5;

                        break;
                    case 7: //PROGRAMADO MENSUAL - QN
                       
                        fechaIni = COES.Base.Tools.Util.FormatFecha(fechaInicial);                       
                        fechaFin = COES.Base.Tools.Util.FormatFecha(fechaFinal);                                       
                        List<MeMedicion1DTO> lista = this.logic.ListaMed1Hidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa, fechaIni, fechaFin);
                        model.ListaMedicion1 = lista;
                        var anho = fechaIni.Year.ToString();
                        var mes = fechaIni.Month;                
                        model.FechaInicio = COES.Base.Tools.Util.ObtenerNombreMes(mes) + " - " + anho;
                        anho = fechaFin.Year.ToString();
                        mes = fechaFin.Month;
                        model.FechaFin = COES.Base.Tools.Util.ObtenerNombreMes(mes) + " - " + anho;
                        ExcelDocument.GenerarArchivoHidrologiaMesQN(model);
                        indicador = 7;
                        break;                   
                }
                
                
                
            }
            catch
            {
                indicador = -1;
            }

            return Json(indicador);
        }

        [HttpPost]
        public JsonResult GenerarArchivoGrafMensualQN(string fechaInicial, string fechaFinal)
        {
            int indicador = 1;
            try
            {               
                HidrologiaModel model = new HidrologiaModel();
                model = modelGraficoMensual;
                model.FechaInicio = fechaInicial;
                model.FechaFin = fechaFinal;
                ExcelDocument.GenerarArchivoGrafMensualQN(model);
                indicador = 1;
            }

            catch
            {
                indicador = -1;
            }

            
            return Json(indicador);
        }

        public JsonResult GenerarArchivoGrafDiario01(string fechaInicial, string fechaFinal)
        {
            int indicador = 1;
            try
            {
                HidrologiaModel model = new HidrologiaModel();
                model = modelGraficoDiario;
                model.FechaInicio = fechaInicial;
                model.FechaFin = fechaFinal;
                ExcelDocument.GenerarArchivoGrafDiario(model);
                indicador = 1;
            }
            catch
            {
                indicador = -1;
            }

            return Json(indicador);
        }

        /// <summary>
        /// Permite exportar el reporte general y por tipo de mantenimientos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult ExportarReporte()
        {
            string nombreArchivo = string.Empty;
            var sTipoReporte = Request["tipo"];
            short tipoReporte = short.Parse(sTipoReporte);
            switch (tipoReporte)
            {
                case 0:
                    nombreArchivo = Constantes.NombreReporteHidrologia00;
                    break;
                case 1:
                    nombreArchivo = Constantes.NombreRptGraficoHidrologia00;
                    break;
                case 2:
                    nombreArchivo = Constantes.NombreReporteHidrologia01;
                    break;
                case 3:
                    nombreArchivo = Constantes.NombreRptGraficoHidrologia01;
                    break;
                case 4:
                    nombreArchivo = Constantes.NombreReporteHidrologia02;
                    break;
                //case 5:
                //    nombreArchivo = Constantes.NombreReporteMantenimiento05;
                //    break;
                //case 6:
                //    nombreArchivo = Constantes.NombreReporteMantenimiento06;
                //    break;


            }
            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteHidrologia] + nombreArchivo;
            return File(fullPath, Constantes.AppExcel, nombreArchivo);
        }

        public PartialViewResult CargarSemanas(string idAnho)
        {
            HidrologiaModel model = new HidrologiaModel();
            List<TipoInformacion> entitys = new List<TipoInformacion>();
            DateTime dfecha = new DateTime(Int32.Parse(idAnho), 12, 31);
            int nsemanas = COES.Base.Tools.Util.ObtenerNroSemanasxAnho(dfecha);

            for (int i = 1; i <= nsemanas; i++)
            {
                TipoInformacion reg = new TipoInformacion();
                reg.IdTipoInfo = i;
                reg.NombreTipoInfo = "Semana " + i + "-" + idAnho;
                entitys.Add(reg);

            }            
            model.ListaSemanas= entitys;
            return PartialView(model);
        }
        
    }
}
