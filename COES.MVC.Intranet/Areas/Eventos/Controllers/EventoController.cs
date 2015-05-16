using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COES.MVC.Intranet.Areas.Eventos.Helper;
using COES.MVC.Intranet.Areas.Eventos.Models;
using COES.MVC.Intranet.Helper;
using Novacode;
using COES.Servicios.Aplicacion.Eventos;
using COES.Dominio.DTO.Sic;

namespace COES.MVC.Intranet.Areas.Eventos.Controllers
{
    public class EventoController : Controller
    {
        /// <summary>
        /// Instancia de clase para el acceso a datos
        /// </summary>
        EventoAppServicio servicio = new EventoAppServicio();

        /// <summary>
        /// Maneja los datos de la pantalla de perturbacion
        /// </summary>
        public List<InformePerturbacionDTO> ListaItemReportePerturbacion
        {
            get
            {
                return (Session[DatosSesion.SesionPerturbacion] != null) ?
                    (List<InformePerturbacionDTO>)Session[DatosSesion.SesionPerturbacion] : new List<InformePerturbacionDTO>();
            }
            set { Session[DatosSesion.SesionPerturbacion] = value; }
        }

        /// <summary>
        /// Muestra la pantalla inicial del módulo
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            BusquedaEventoModel model = new BusquedaEventoModel();
            model.ListaTipoEvento = this.servicio.ListarTipoEvento();
            model.ListaEmpresas = this.servicio.ListarEmpresas();
            model.ListaFamilias = this.servicio.ListarFamilias();
            model.ListaTipoEmpresas = this.servicio.ListarTipoEmpresas();
            model.ListaCausaEvento = this.servicio.ListarCausasEventos();
            model.FechaInicio = DateTime.Now.ToString(Constantes.FormatoFecha);
            model.FechaFin = DateTime.Now.ToString(Constantes.FormatoFecha);
            model.ParametroDefecto = 0;
            return View(model);
        }

        /// <summary>
        /// Permite mostrar la lista de eventos
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Lista(BusquedaEventoModel modelo)
        {
            EventoModel model = new EventoModel();

            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFin = DateTime.Now;

            if (modelo.FechaInicio != null)
            {
                fechaInicio = DateTime.ParseExact(modelo.FechaInicio, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }
            if (modelo.FechaFin != null)
            {
                fechaFin = DateTime.ParseExact(modelo.FechaFin, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }
            fechaFin = fechaFin.AddDays(1);

            model.ListaEventos = servicio.BuscarEventos(modelo.IdTipoEvento, fechaInicio, fechaFin, modelo.Version, modelo.Turno,
                modelo.IdTipoEmpresa, modelo.IdEmpresa, modelo.IdFamilia, modelo.Informe, modelo.IndInterrupcion, modelo.NroPagina, Constantes.PageSizeEvento).ToList();

            return PartialView(model);
        }

        /// <summary>
        /// Permite mostrar el paginado de la consulta
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Paginado(BusquedaEventoModel modelo)
        {
            BusquedaEventoModel model = new BusquedaEventoModel();
            model.IndicadorPagina = false;

            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFin = DateTime.Now;

            if (modelo.FechaInicio != null)
            {
                fechaInicio = DateTime.ParseExact(modelo.FechaInicio, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }
            if (modelo.FechaFin != null)
            {
                fechaFin = DateTime.ParseExact(modelo.FechaFin, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            }
            fechaFin = fechaFin.AddDays(1);

            int nroRegistros = servicio.ObtenerNroFilasEvento(modelo.IdTipoEvento, fechaInicio, fechaFin, modelo.Version, modelo.Turno,
                modelo.IdTipoEmpresa, modelo.IdEmpresa, modelo.IdFamilia, modelo.Informe, modelo.IndInterrupcion);

            if (nroRegistros > Constantes.NroPageShow)
            {
                int pageSize = Constantes.PageSizeEvento;
                int nroPaginas = (nroRegistros % pageSize == 0) ? nroRegistros / pageSize : nroRegistros / pageSize + 1;
                model.NroPaginas = nroPaginas;
                model.NroMostrar = Constantes.NroPageShow;
                model.IndicadorPagina = true;
            }

            return PartialView(model);
        }

        /// <summary>
        /// Permite visualizar el detalle del evento
        /// </summary>
        /// <returns></returns>
        public ActionResult Detalle()
        {
            string codigo = Request[RequestParameter.EventoId];
            int id = int.Parse(codigo);

            EventoModel model = new EventoModel();
            EventoDTO evento = this.servicio.ObtenerEvento(id);
            model.ListaTipoEvento = this.servicio.ListarTipoEvento().ToList();
            model.ListaEmpresas = this.servicio.ListarEmpresas().ToList();
            model.ListaCausaEvento = this.servicio.ObtenerCausaEvento(evento.TIPOEVENCODI).ToList();
            model.Evento = evento;
            model.IdEvento = id;

            return View(model);
        }

        /// <summary>
        /// Muestra la vista del informe
        /// </summary>
        /// <returns></returns>
        public ActionResult Perturbacion()
        {

            string codigo = Request[RequestParameter.EventoId];
            int id = int.Parse(codigo);

            string indicador = Constantes.NO;

            if (Request[RequestParameter.Indicador] != null)
            {
                indicador = Request[RequestParameter.Indicador];
            }

            PerturbacionModel model = new PerturbacionModel();
            EventoDTO evento = this.servicio.ObtenerResumenEvento(id);
            model.AsuntoEvento = evento.EVENDESC;
            model.FechaEvento = (evento.EVENINI != null) ? ((DateTime)evento.EVENINI).ToString(Constantes.FormatoFecha) : string.Empty;
            model.HoraEvento = (evento.EVENINI != null) ? ((DateTime)evento.EVENINI).ToString(Constantes.FormatoHora) : string.Empty;
            model.EmpresaEvento = evento.EMPRNOMB;
            model.EquipoEvento = evento.EQUIABREV;
            model.CodigoEvento = id;
            model.IndicadorGrabado = indicador;
            model.ListaCausaEvento = this.servicio.ObtenerCausaEvento(evento.TIPOEVENCODI).ToList();
            model.ListaInforme = this.servicio.ObtenerInformePorEvento(id).ToList();
            model.IndicadorExistencia = evento.EVENPERTURBACION;
            this.ListaItemReportePerturbacion = model.ListaInforme;

            return View(model);
        }

        /// <summary>
        /// Permite agregar un item al reporte de perturbación
        /// </summary>
        /// <param name="nroOrden"></param>
        /// <param name="tipo"></param>
        /// <param name="descripcion"></param>
        /// <param name="hora"></param>
        /// <param name="equipo"></param>
        /// <param name="interruptor"></param>
        /// <param name="senial"></param>
        /// <param name="ac"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddItemPerturbacion(int nroOrden, string tipo, string descripcion, string hora,
            string equipo, string interruptor, string senial, string ac)
        {
            List<InformePerturbacionDTO> list = this.ListaItemReportePerturbacion;
            list.Add(new InformePerturbacionDTO
            {
                ITEMORDEN = nroOrden,
                ITEMTIPO = tipo,
                ITEMDESCRIPCION = descripcion,
                ITEMTIME = hora,
                ITEMSENALIZACION = senial,
                ITEMAC = ac,
                EQUICODI = (!string.IsNullOrEmpty(equipo)) ? (int?)int.Parse(equipo) : null,
                INTERRUPTORCODI = (!string.IsNullOrEmpty(interruptor)) ? (int?)int.Parse(interruptor) : null
            });
            this.ListaItemReportePerturbacion = list;
            return Json(1);
        }

        /// <summary>
        /// Permite editar un item del reporte de perturbación
        /// </summary>
        /// <param name="nroOrden"></param>
        /// <param name="tipo"></param>
        /// <param name="descripcion"></param>
        /// <param name="hora"></param>
        /// <param name="equipo"></param>
        /// <param name="interruptor"></param>
        /// <param name="senial"></param>
        /// <param name="ac"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditItemPerturbacion(int nroOrden, string tipo, string descripcion, string hora,
            string equipo, string interruptor, string senial, string ac)
        {
            try
            {
                List<InformePerturbacionDTO> list = this.ListaItemReportePerturbacion;
                InformePerturbacionDTO item = list.Where(x => x.ITEMORDEN == nroOrden && x.ITEMTIPO == tipo).FirstOrDefault();
                if (item != null)
                {
                    item.ITEMDESCRIPCION = descripcion;
                    item.ITEMTIME = hora;
                    item.ITEMSENALIZACION = senial;
                    item.ITEMAC = ac;
                    item.EQUICODI = (!string.IsNullOrEmpty(equipo)) ? (int?)int.Parse(equipo) : null;
                    item.INTERRUPTORCODI = (!string.IsNullOrEmpty(interruptor)) ? (int?)int.Parse(interruptor) : null;
                    this.ListaItemReportePerturbacion = list;
                }
                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }

        /// <summary>
        /// Quita un item del reporte de perturbación
        /// </summary>
        /// <param name="nroOrden"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteItemPerturbacion(int nroOrden, string tipo)
        {
            try
            {
                List<InformePerturbacionDTO> list = this.ListaItemReportePerturbacion;
                InformePerturbacionDTO item = list.Where(x => x.ITEMORDEN == nroOrden && x.ITEMTIPO == tipo).FirstOrDefault();
                if (item != null)
                {
                    list.Remove(item);
                    this.ListaItemReportePerturbacion = list;
                }
                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }

        /// <summary>
        /// Permite obtener el nro de orden
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerNroOrden(string tipo)
        {
            List<InformePerturbacionDTO> list = this.ListaItemReportePerturbacion;
            decimal? nro = list.Where(x => x.ITEMTIPO == tipo).Max(x => x.ITEMORDEN);
            if (nro != null)
            {
                return Json((int)nro + 1);
            }
            else
            {
                return Json(1);
            }
        }

        /// <summary>
        /// Permite generar el reporte de perturbación
        /// </summary>
        /// <param name="idEvento"></param>
        /// <param name="idCausa"></param>
        /// <param name="asunto"></param>
        /// <param name="analisis"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GrabarReporte(int idEvento, string idCausa, string asunto, string analisis)
        {
            try
            {
                List<InformePerturbacionDTO> list = this.ListaItemReportePerturbacion;

                if (!string.IsNullOrEmpty(idCausa))
                {
                    InformePerturbacionDTO itemCausa = list.Where(x => x.ITEMTIPO == TipoItemPerturbacion.ItemCausa).FirstOrDefault();
                    if (itemCausa != null)
                    {
                        itemCausa.SUBCAUSACODI = int.Parse(idCausa);
                    }
                    else
                    {
                        list.Add(new InformePerturbacionDTO
                        {
                            ITEMORDEN = 1,
                            ITEMTIPO = TipoItemPerturbacion.ItemCausa,
                            SUBCAUSACODI = int.Parse(idCausa)
                        });
                    }
                }
                else
                {
                    InformePerturbacionDTO itemCausa = list.Where(x => x.ITEMTIPO == TipoItemPerturbacion.ItemCausa).FirstOrDefault();
                    if (itemCausa != null)
                    {
                        list.Remove(itemCausa);
                    }
                }

                InformePerturbacionDTO itemAsunto = list.Where(x => x.ITEMTIPO == TipoItemPerturbacion.ItemDescripcion).FirstOrDefault();

                if (itemAsunto != null)
                {
                    itemAsunto.ITEMDESCRIPCION = asunto;
                }
                else
                {
                    list.Add(new InformePerturbacionDTO
                    {
                        ITEMORDEN = 1,
                        ITEMTIPO = TipoItemPerturbacion.ItemDescripcion,
                        ITEMDESCRIPCION = asunto
                    });
                }

                InformePerturbacionDTO itemAnalisis = list.Where(x => x.ITEMTIPO == TipoItemPerturbacion.ItemAnalisis).FirstOrDefault();

                if (itemAnalisis != null)
                {
                    itemAnalisis.ITEMDESCRIPCION = analisis;
                }
                else
                {
                    list.Add(new InformePerturbacionDTO
                    {
                        ITEMORDEN = 1,
                        ITEMTIPO = TipoItemPerturbacion.ItemAnalisis,
                        ITEMDESCRIPCION = analisis
                    });
                }

                this.ListaItemReportePerturbacion = list;
                int resultado = this.servicio.GrabarInformePerturbacion(list, idEvento, HttpContext.User.Identity.Name);
                return Json(resultado);
            }
            catch (Exception)
            {
                return Json(-1);
            }
        }

        /// <summary>
        /// Permite eliminar el reporte de perturbacion
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EliminarReporte(int idEvento)
        {
            try
            {
                this.servicio.EliminarInformePerturbacion(idEvento);
                return Json(1);
            }
            catch (Exception)
            {
                return Json(-1);
            }
        }

        /// <summary>
        /// Permite generar el archivo del reporte
        /// </summary>
        /// <param name="idEvento"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GenerarArchivo(int idEvento, string tipo)
        {
            try
            {
                List<InformePerturbacionDTO> Lista = this.servicio.ObtenerInformePorEvento(idEvento).ToList();
                EventoDTO evento = this.servicio.ObtenerResumenEvento(idEvento);
                string path = ConfigurationManager.AppSettings[RutaDirectorio.ReporteEvento].ToString();

                if (tipo == Constantes.FormatoWord)
                {
                    (new WordDocument()).GenerarReportePerturbacion(Lista, evento, idEvento, path);

                }
                if (tipo == Constantes.FormatoPDF)
                {
                    (new PdfDocument()).GenerarReportePerturbacion(Lista, evento, idEvento, path);
                }

                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(-1);
            }
        }
           
        /// <summary>
        /// Permite abrir el archivo generado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Exportar()
        {
            string tipo = Request[RequestParameter.Indicador];
            string file = string.Empty;
            string app = string.Empty;

            if (tipo == Constantes.FormatoWord)
            {
                file = Constantes.NombreReportePerturbacionWord;
                app = Constantes.AppWord;
            }
            if (tipo == Constantes.FormatoPDF)
            {
                file = Constantes.NombreReportePerturbacionPdf;
                app = Constantes.AppPdf;
            }

            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteEvento] + file;
            return File(fullPath, app, file);
        }


        /// <summary>
        /// Permite cargar los puntos de la empresa seleccionada
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargarEmpresas(int idTipoEmpresa)
        {
            List<EmpresaDTO> entitys = new List<EmpresaDTO>();

            if (idTipoEmpresa != 0)
            {
                entitys = this.servicio.ListarEmpresasPorTipo(idTipoEmpresa);
            }
            else
            {
                entitys = this.servicio.ListarEmpresas();
            }

            SelectList list = new SelectList(entitys, EntidadPropiedad.EmprCodi, EntidadPropiedad.EmprNomb);

            return Json(list);
        }
    }
}