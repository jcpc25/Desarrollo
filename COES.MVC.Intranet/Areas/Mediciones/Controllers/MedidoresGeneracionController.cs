using COES.Dominio.DTO.Sic;
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
    public class MedidoresGeneracionController : Controller
    {
        /// <summary>
        /// Clase para acceso a los datos y bl
        /// </summary>
        ConsultaMedidoresAppServicio servicio = new ConsultaMedidoresAppServicio();

        /// <summary>
        /// Carga inicial de la página
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            MedidoresGeneracionModel model = new MedidoresGeneracionModel();

            //model.ListaEmpresas = this.servicio.ListaEmpresa();           
            model.ListaTipoGeneracion = this.servicio.ListaTipoGeneracion();
            model.ListaTipoEmpresas = this.servicio.ListaTipoEmpresas();
            model.FechaInicio = DateTime.Now.AddDays(-7).ToString(Constantes.FormatoFecha);
            model.FechaFin = DateTime.Now.ToString(Constantes.FormatoFecha);

            return View(model);
        }

        /// <summary>
        /// Permite cargar las empresas por los tipos seleccionados
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Empresas(string tiposEmpresa)
        {
            MedidoresGeneracionModel model = new MedidoresGeneracionModel();
            List<SiEmpresaDTO> entitys = this.servicio.ObteneEmpresasPorTipo(tiposEmpresa);
            model.ListaEmpresas = entitys;
           
            return PartialView(model);            
        }

        /// <summary>
        /// Permite listar los registros de medidores de generación
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Lista(string fechaInicial, string fechaFinal, string tiposEmpresa, string empresas, string tiposGeneracion,
            int central, int parametro, int nroPagina)
        {
            MedidoresGeneracionModel model = new MedidoresGeneracionModel();

            DateTime fecInicio = DateTime.Now;
            DateTime fecFin = DateTime.Now;

            if (!string.IsNullOrEmpty(fechaInicial)) {
                fecInicio = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }
            if (!string.IsNullOrEmpty(fechaFinal)) {
                fecFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }

            if (string.IsNullOrEmpty(empresas)) empresas = Constantes.ParametroDefecto;
            if (string.IsNullOrEmpty(tiposGeneracion)) tiposGeneracion = Constantes.ParametroDefecto;

            List<MeMedicion96DTO> sumatoria = new List<MeMedicion96DTO>(); ;
            model.ListaDatos = this.servicio.ObtenerConsultaMedidores(fecInicio, fecFin, tiposEmpresa, empresas,
                tiposGeneracion, central, parametro,
                nroPagina, Constantes.PageSizeMedidores, out sumatoria);

            model.EntidadTotal = sumatoria;

            string header = string.Empty;
            if (parametro == 1) header = "Total Energía Activa  (MWh)";
            if (parametro == 2) header = "Total Energía Reactiva (MVarh)";
            if (parametro == 3) header = "Total Servicios Auxiliares (MWh)";

            model.TextoCabecera = header;
            model.IndicadorPublico = (User.Identity.Name == Constantes.UsuarioAnonimo) ? Constantes.SI : Constantes.NO;

            return PartialView(model);
        }

        /// <summary>
        /// Permite mostrar el paginado de la consulta
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Paginado(string fechaInicial, string fechaFinal, string tiposEmpresa, string empresas, string tiposGeneracion,
            int central, int parametro)
        {
            MedidoresGeneracionModel model = new MedidoresGeneracionModel();

            DateTime fecInicio = DateTime.Now;
            DateTime fecFin = DateTime.Now;

            if (!string.IsNullOrEmpty(fechaInicial))
            {
                fecInicio = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }
            if (!string.IsNullOrEmpty(fechaFinal))
            {
                fecFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }

            if (string.IsNullOrEmpty(empresas)) empresas = Constantes.ParametroDefecto;
            if (string.IsNullOrEmpty(tiposGeneracion)) tiposGeneracion = Constantes.ParametroDefecto;

            int nroRegistros = this.servicio.ObtenerNroRegistroConsultaMedidores(fecInicio, fecFin, tiposEmpresa,
                empresas, tiposGeneracion, central, parametro);

            if (nroRegistros > Constantes.NroPageShow)
            {
                int pageSize = Constantes.PageSizeMedidores;
                int nroPaginas = (nroRegistros % pageSize == 0) ? nroRegistros / pageSize : nroRegistros / pageSize + 1;
                model.NroPaginas = nroPaginas;
                model.NroMostrar = Constantes.NroPageShow;
                model.IndicadorPagina = true;
            }

            return PartialView(model);
        }

        /// <summary>
        /// Permite generar el formato horizontal
        /// </summary>
        /// <param name="fechaInicial"></param>
        /// <param name="fechaFinal"></param>
        /// <param name="empresas"></param>
        /// <param name="tiposGeneracion"></param>
        /// <param name="central"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Exportar(string fechaInicial, string fechaFinal, string tiposEmpresa, string empresas, string tiposGeneracion,
            int central, string parametros, int tipo) 
        {
            try
            {
                DateTime fecInicio = DateTime.Now;
                DateTime fecFin = DateTime.Now;

                if (!string.IsNullOrEmpty(fechaInicial))
                {
                    fecInicio = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(fechaFinal))
                {
                    fecFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                }

                if (string.IsNullOrEmpty(empresas)) empresas = Constantes.ParametroDefecto;
                if (string.IsNullOrEmpty(tiposGeneracion)) tiposGeneracion = Constantes.ParametroDefecto;

                string path = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones];
                string file = string.Empty;

                if (tipo == 1) file = NombreArchivo.ReporteMedidoresHorizontal;
                if (tipo == 2) file = NombreArchivo.ReporteMedidoresVertical;
                if (tipo == 3) file = NombreArchivo.ReporteMedidoresCSV;
                
                bool flag = (User.Identity.Name == Constantes.UsuarioAnonimo) ? false : true;

                this.servicio.GenerarArchivoExportacion(fecInicio, fecFin, tiposEmpresa, empresas, tiposGeneracion, central, 
                    parametros, path, file, tipo, flag);
               

                return Json("1");
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Permite abrir el archivo del reporte generado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Descargar(int tipo)
        {
            string file = string.Empty;
            string app = Constantes.AppExcel;

            if (tipo == 1) file = NombreArchivo.ReporteMedidoresHorizontal;
            if (tipo == 2) file = NombreArchivo.ReporteMedidoresVertical;
            if (tipo == 3)
            {
                file = NombreArchivo.ReporteMedidoresCSV;
                app = Constantes.AppCSV;
            }

            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteMediciones] + file;
            return File(fullPath, app, file);
        }

        /// <summary>
        /// Valida la selección de datos de exportación
        /// </summary>
        /// <param name="formato"></param>
        /// <param name="fechaInicial"></param>
        /// <param name="fechaFinal"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ValidarExportacion(int formato, string fechaInicial, string fechaFinal, string parametros)
        {
            try
            {
                DateTime fecInicio = DateTime.Now;
                DateTime fecFin = DateTime.Now;

                if (!string.IsNullOrEmpty(fechaInicial))
                {
                    fecInicio = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(fechaFinal))
                {
                    fecFin = DateTime.ParseExact(fechaFinal, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                }

                TimeSpan ts = fecFin.Subtract(fecInicio);

                if (ts.TotalDays > 92)
                {
                    return Json(2);
                }

                if (formato == 3)
                {
                    if (!string.IsNullOrWhiteSpace(parametros))
                    {
                        string[] ids = parametros.Split(Constantes.CaracterComa);

                        if (ids.Count() > 1)
                        {
                            return Json(3);
                        }
                    }
                    else 
                    {
                        return Json(4);
                    }
                }

                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }


       
    }
}
