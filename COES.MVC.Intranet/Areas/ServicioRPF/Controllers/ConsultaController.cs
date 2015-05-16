﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Areas.ServicioRPF.Helper;
using COES.MVC.Intranet.Areas.ServicioRPF.Models;
using COES.MVC.Intranet.Helper;
using COES.MVC.Intranet.ServicioCloud;
using COES.Servicios.Aplicacion.ServicioRPF;

namespace COES.MVC.Intranet.Areas.ServicioRPF.Controllers
{
    public class ConsultaController : Controller
    {
        ServicioCloudClient servicioCloud = new ServicioCloudClient();
        RpfAppServicio logic = new RpfAppServicio();

        /// <summary>
        /// Pagina de consulta de carga de datos
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ServicioModel model = new ServicioModel();
            model.FechaConsulta = DateTime.Now.AddDays(-1).ToString(Constantes.FormatoFecha);

            return View(model);
        }

        /// <summary>
        /// Pagina para consultar las potencias maximas
        /// </summary>
        /// <returns></returns>
        public ActionResult Potencias()
        {
            ServicioModel model = new ServicioModel();
            model.FechaConsulta = DateTime.Now.AddDays(-1).ToString(Constantes.FormatoFecha);

            return View(model);
        }

        /// <summary>
        /// Pagina de carga de archivos
        /// </summary>
        /// <returns></returns>
        public ActionResult Carga()
        {
            ServicioModel model = new ServicioModel();
            model.Usuario = User.Identity.Name;

            return View(model);
        }
        
        /// <summary>
        /// Consulta el estado de envio
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public PartialViewResult Consulta(string fecha)
        {
            ServicioModel model = new ServicioModel();
            List<ServicioRpfDTO> list = this.logic.ObtenerUnidadesCarga();
            List<int> ids = (from puntos in list select puntos.PTOMEDICODI).Distinct().ToList();
            DateTime fechaConsulta = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);

            List<ResultadoVerificacion> resultado = this.servicioCloud.VerificarEnvio(ids.ToArray(), fechaConsulta).ToList();

            foreach (ServicioRpfDTO item in list)
            {
                foreach (ResultadoVerificacion result in resultado)
                {
                    if (item.PTOMEDICODI == result.PtoMediCodi)
                    {
                        item.INDICADOR = (result.IndicadorEnvio == Constantes.SI) ? Constantes.TextoSI : Constantes.TextoNO;
                        break;
                    }
                }
            }

            model.ListaConsulta = list;

            return PartialView(model);
        }

        /// <summary>
        /// Consulta las potencias maximas
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public PartialViewResult ConsultaPotencia(string fecha)
        {
            ServicioModel model = new ServicioModel();
            List<ServicioRpfDTO> list = this.logic.ObtenerUnidadesCarga();          

            DateTime fechaConsulta = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            List<RegistroRPF> resultado = this.servicioCloud.ObtenerPotenciasMaximas(fechaConsulta).ToList();

            foreach (ServicioRpfDTO item in list)
            {
                RegistroRPF rpf = resultado.Where(x => x.PTOMEDICODI == item.PTOMEDICODI).FirstOrDefault();

                if (rpf != null)
                {
                    item.POTENCIAMAX = rpf.POTENCIA;
                }
            }

            model.ListaConsulta = list;

            return PartialView(model);
        }
        
        /// <summary>
        /// Genera el archivo del reporte de cumplimiento
        /// </summary>
        /// <param name="puntos"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GenerarArchivo(string puntos, string fecha)
        {
            int result = 1;
            try
            {
                string[] codigos = puntos.Split(Constantes.CaracterComa);
                List<int> list = new List<int>();
                foreach (string codigo in codigos) 
                    if(!string.IsNullOrEmpty(codigo))
                        list.Add(int.Parse(codigo));

                DateTime fechaConsulta = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                List<Medicion> entitys = servicioCloud.DescargarEnvio(list.ToArray(), fechaConsulta).ToList();
                string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF] + Constantes.NombreCSVServicioRPF;
                this.GenerarArchivo(entitys, fullPath, fecha);

                result = 1;
            }
            catch
            {
                result = -1;
            }

            return Json(result);
        }

        /// <summary>
        /// Exporta el reporte generado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Exportar()
        {
            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF] + Constantes.NombreCSVServicioRPF;
            return File(fullPath, Constantes.AppCSV, Constantes.NombreCSVServicioRPF);
        }

        /// <summary>
        /// Genera el archivo de reporte de potencias maximas
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GenerarArchivoPotencia(string fecha)
        {
            int result = 1;
            try
            {
                DateTime fechaConsulta = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);

                List<ServicioRpfDTO> list = this.logic.ObtenerUnidadesCarga();
               
                List<RegistroRPF> resultado = this.servicioCloud.ObtenerPotenciasMaximas(fechaConsulta).ToList();

                foreach (ServicioRpfDTO item in list)
                {
                    RegistroRPF rpf = resultado.Where(x => x.PTOMEDICODI == item.PTOMEDICODI).FirstOrDefault();

                    if (rpf != null)
                    {
                        item.POTENCIAMAX = rpf.POTENCIA;
                    }
                }

                ExcelDocument.GenerarReportePotencia(list);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return Json(result);
        }

        /// <summary>
        /// Exporta el reporte de potencias generado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult ExportarPotencia()
        {
            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF] + Constantes.NombreReporteRPFPotencia;
            return File(fullPath, Constantes.AppExcel, Constantes.NombreReporteRPFPotencia);
        }

        /// <summary>
        /// Permite generar el archivo de reporte de datos cargados
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GenerarArchivoReporte(string fecha)
        {
            int indicador = 1;

            try
            {
                DateTime fechaConsulta = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);

                ServicioModel model = new ServicioModel();
                List<ServicioRpfDTO> list = this.logic.ObtenerUnidadesCarga();
                List<int> ids = (from puntos in list select puntos.PTOMEDICODI).Distinct().ToList();               

                List<ResultadoVerificacion> resultado = this.servicioCloud.VerificarEnvio(ids.ToArray(), fechaConsulta).ToList();

                foreach (ServicioRpfDTO item in list)
                {
                    foreach (ResultadoVerificacion result in resultado)
                    {
                        if (item.PTOMEDICODI == result.PtoMediCodi)
                        {
                            item.INDICADOR = (result.IndicadorEnvio == Constantes.SI) ? Constantes.TextoSI : Constantes.TextoNO;
                            break;
                        }
                    }
                }
                
                ExcelDocument.GenerarReporteCarga(list);
                indicador = 1;
            }
            catch
            {
                indicador = -1;
            }

            return Json(indicador);
        }

        /// <summary>
        /// Permite exportar el reporte generado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult ExportarReporte()
        {
            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteServicioRPF] + Constantes.NombreReporteCargaRPF;
            return File(fullPath, Constantes.AppExcel, Constantes.NombreReporteCargaRPF);
        }

        /// <summary>
        /// Generar el archivo CSV con los datos cargados
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="fileName"></param>
        /// <param name="fecha"></param>
        protected void GenerarArchivo(List<Medicion> entitys, string fileName, string fecha)
        {
            List<int> puntos = (from punto in entitys select punto.PTOMEDICODI).Distinct().ToList();
            string[] texto = new string[86403];
            int[] tipos = { 1, 6 };            

            texto[0] = " ";
            texto[1] = " ";
            texto[2] = "Fecha: ," + fecha; 
            int t = 0;
            foreach (int punto in puntos)
            {                
                for (int i = 0; i < tipos.Length; i++)
                {
                    texto[0] = texto[0] + "," + punto;
                    texto[1] = texto[1] + "," + tipos[i];

                    List<Medicion> list = entitys.Where(x => x.PTOMEDICODI == punto && x.TIPOINFOCODI == tipos[i]).OrderBy(x => x.FECHAHORA).ToList();

                    int k = 3;
                    foreach (Medicion item in list)
                    {   
                        for (int j = 0; j <= 59; j++)
                        {
                            if (t == 0 && i == 0)
                                texto[k] = item.FECHAHORA.AddSeconds(j).ToString("HH:mm:ss") + "," + item.GetType().GetProperty("H" + j.ToString()).GetValue(item, null);
                            else
                                texto[k] = texto[k] + "," + item.GetType().GetProperty("H" + j.ToString()).GetValue(item, null);
                            k++;
                        }
                    }
                }

                t++;
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                foreach (string item in texto)
                {
                    file.WriteLine(item);
                }
            }

        }

    }
}
