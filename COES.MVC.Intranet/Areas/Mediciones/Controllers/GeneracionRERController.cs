using COES.Dominio.DTO.Sic;
using COES.Framework.Base.Tools;
using COES.MVC.Intranet.Areas.Mediciones.Helpers;
using COES.MVC.Intranet.Areas.Mediciones.Models;
using COES.MVC.Intranet.Helper;
using COES.Servicios.Aplicacion.Mediciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Mediciones.Controllers
{
    public class GeneracionRERController : Controller
    {
        GeneracionRERAppServicio logic = new GeneracionRERAppServicio();

        /// <summary>
        /// Muestra la página de inicio del módulo
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            GeneracionRERModel model = new GeneracionRERModel();

            model.ListaEmpresas = this.logic.ObtenerPuntosEmpresas();

            List<string> semanas = new List<string>();
            for (int i = 1; i <= 53; i++)
            {
                semanas.Add(i.ToString().PadLeft(2, Convert.ToChar(Constantes.CaracterCero)));
            }

            List<int> anios = new List<int>();
            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 1; i++)
            {
                anios.Add(i);
            }
            model.ListaAnios = anios;
            model.Anio = DateTime.Now.Year;

            model.Fecha = DateTime.Now.ToString(Constantes.FormatoFecha);
            model.ListaSemanas = semanas;
            int nroSemana = EPDate.f_numerosemana(DateTime.Now);

            DateTime fechaInicio = EPDate.f_fechainiciosemana(DateTime.Now.Year, nroSemana);
            DateTime fechaFin = fechaInicio.AddDays(6);
            model.FechaInicio = fechaInicio.ToString(Constantes.FormatoFecha);
            model.FechaFin = fechaFin.ToString(Constantes.FormatoFecha);


            model.NroSemana = nroSemana;

            return View(model);
        }

        /// <summary>
        /// Muestra la página de inicio del módulo
        /// </summary>
        /// <returns></returns>
        public ActionResult Reporte()
        {
            GeneracionRERModel model = new GeneracionRERModel();

            model.ListaEmpresas = this.logic.ObtenerPuntosEmpresas();

            List<string> semanas = new List<string>();
            for (int i = 1; i <= 53; i++)
            {
                semanas.Add(i.ToString().PadLeft(2, Convert.ToChar(Constantes.CaracterCero)));
            }

            List<int> anios = new List<int>();
            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 1; i++)
            {
                anios.Add(i);
            }
            model.ListaAnios = anios;
            model.Anio = DateTime.Now.Year;

            model.Fecha = DateTime.Now.ToString(Constantes.FormatoFecha);
            model.ListaSemanas = semanas;
            int nroSemana = EPDate.f_numerosemana(DateTime.Now);

            DateTime fechaInicio = EPDate.f_fechainiciosemana(DateTime.Now.Year, nroSemana);
            DateTime fechaFin = fechaInicio.AddDays(6);
            model.FechaInicio = fechaInicio.ToString(Constantes.FormatoFecha);
            model.FechaFin = fechaFin.ToString(Constantes.FormatoFecha);


            model.NroSemana = nroSemana;

            return View(model);
        }

        /// <summary>
        /// Permite ontener las fechas por semana
        /// </summary>
        /// <param name="nroSemana"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerFechasAnio(int nroSemana, int anio)
        {
            GeneracionRERModel json = new GeneracionRERModel();

            DateTime fecha = EPDate.f_fechainiciosemana(anio, nroSemana);
            json.FechaInicio = fecha.ToString(Constantes.FormatoFecha);
            json.FechaFin = fecha.AddDays(6).ToString(Constantes.FormatoFecha);

            return Json(json);
        }

        /// <summary>
        /// Permite mostrar los datos cargados
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="horizonte"></param>
        /// <param name="fecha"></param>
        /// <param name="nroSemana"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Lista(int idEmpresa, int horizonte, string fecha, int? nroSemana)
        {
            GeneracionRERModel model = new GeneracionRERModel();

            DateTime fechaInicial = DateTime.Now;
            DateTime fechaFinal = DateTime.Now;

            if (horizonte == 0)
            {
                fechaInicial = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                fechaFinal = fechaInicial;
            }
            if (horizonte == 1)
            {
                fechaInicial = EPDate.f_fechainiciosemana(DateTime.Now.Year, (int)nroSemana);
                fechaFinal = fechaInicial.AddDays(6);
            }

            string resultado = this.logic.ObtenerConsultaRER(idEmpresa, horizonte, fechaInicial, fechaFinal, 1);

            model.Resultado = resultado;

                      

            return PartialView(model);
        }


        /// <summary>
        /// Permite generar el reporte de cumplimiento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Exportar(int idEmpresa, string desEmpresa, int horizonte, string fecha, int? nroSemana)
        {
            int indicador = 1;

            try
            {                
                DateTime fechaInicial = DateTime.Now;
                DateTime fechaFinal = DateTime.Now;

                if (horizonte == 0)
                {
                    fechaInicial = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    fechaFinal = fechaInicial;
                }
                if (horizonte == 1)
                {
                    fechaInicial = EPDate.f_fechainiciosemana(DateTime.Now.Year, (int)nroSemana);
                    fechaFinal = fechaInicial.AddDays(6);
                }

                List<MeMedicion48DTO> list = this.logic.ObtenerConsulta(idEmpresa, horizonte, fechaInicial, fechaFinal);
                List<WbGeneracionrerDTO> listPuntos = this.logic.ObtenerListaFormato(idEmpresa);

                if (list.Count > 0)
                {
                    MedicionHelper.GenerarReporteRER(list, listPuntos, horizonte, desEmpresa, fechaInicial, nroSemana, fechaInicial, fechaFinal);
                    indicador = 1;
                }
                else 
                {
                    indicador = 2;
                }                 
            }
            catch
            {
                indicador = -1;              
            }

            return Json(indicador);
        }

        /// <summary>
        /// Permite exportar agrupado por central
        /// </summary>      
        /// <returns></returns>
        [HttpPost]
        public JsonResult ExportarCentral(int idEmpresa, string desEmpresa, int horizonte, string fecha, int? nroSemana)
        {
            int indicador = 1;

            try
            {
                DateTime fechaInicial = DateTime.Now;
                DateTime fechaFinal = DateTime.Now;

                if (horizonte == 0)
                {
                    fechaInicial = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                    fechaFinal = fechaInicial;
                }
                if (horizonte == 1)
                {
                    fechaInicial = EPDate.f_fechainiciosemana(DateTime.Now.Year, (int)nroSemana);
                    fechaFinal = fechaInicial.AddDays(6);
                }

                List<MeMedicion48DTO> list = this.logic.ObtenerConsulta(idEmpresa, horizonte, fechaInicial, fechaFinal);
                List<WbGeneracionrerDTO> listPuntos = this.logic.ObtenerListaFormato(idEmpresa);

                if (list.Count > 0)
                {
                    MedicionHelper.GenerarReporteRERPorCentral(list, listPuntos, horizonte, desEmpresa, fechaInicial, nroSemana, fechaInicial, fechaFinal);
                    indicador = 1;
                }
                else
                {
                    indicador = 2;
                }
            }
            catch
            {
                indicador = -1;
            }

            return Json(indicador);
        }


        /// <summary>
        /// Permite abrir el archivo del reporte generado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Descargar()
        {            
            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones] + NombreArchivo.ReporteGeneracionRER;
            return File(fullPath, Constantes.AppExcel, NombreArchivo.ReporteGeneracionRER);
        }

        /// <summary>
        /// Permite generar el reporte de cumplimiento
        /// </summary>
        /// <param name="horizonte"></param>
        /// <param name="fecha"></param>
        /// <param name="nroSemana"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Cumplimiento(int horizonte, string fecha, int? nroSemana)
        {
            GeneracionRERModel model = new GeneracionRERModel();

            DateTime fechaProceso = DateTime.Now;

            if (horizonte == 0)
            {
                fechaProceso = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }

            List<ExtLogenvioDTO> listado = this.logic.GetByCriteriaExtLogenvios(horizonte, fechaProceso, nroSemana);

            model.ListaReporte = listado;

            return PartialView(model);
        }             

    }
}
