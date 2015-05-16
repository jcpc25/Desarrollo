using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Areas.Evento.Helper;
using COES.MVC.Intranet.Areas.Eventos.Models;
using COES.MVC.Intranet.Helper;
using COES.Servicios.Aplicacion.Eventos;

namespace COES.MVC.Intranet.Areas.Eventos.Controllers
{
    public class HorasOperacionController : Controller
    {
        HoraOperacionAppServicio logic = new HoraOperacionAppServicio();

        /// <summary>
        /// Lista que contiene los datos programados
        /// </summary>
        public List<RsfModel> ListaServicio
        {
            get
            {
                return (Session[DatosSesion.ListaServicio] != null) ?
                    (List<RsfModel>)Session[DatosSesion.ListaServicio] : new List<RsfModel>();
            }
            set { Session[DatosSesion.ListaServicio] = value; }
        }

        public ActionResult Index()
        {
            this.ListaServicio = null;
            MatrizModel model = new MatrizModel();
            model.Fecha = DateTime.Now.ToString(Constantes.FormatoFecha);

            return View(model);
        }

        [HttpPost]
        public PartialViewResult Agregar(int idEquipo, string central, string nombre, string empresa, int idEmpresa)
        {
            MatrizModel model = new MatrizModel();
            List<RsfModel> list = this.ListaServicio;

            if (list.Where(x => x.IdEquipo == idEquipo).ToList().Count == 0)
            {
                RsfModel entity = new RsfModel
                {
                    Central = central,
                    Empresa = empresa,
                    Equipo = nombre,
                    IdEmpresa = idEmpresa,
                    IdEquipo = idEquipo,
                    DesURS = this.ObtenerNombreURS(idEquipo)
                };

                if (list.Count > 0)
                {
                    List<RsfItemModel> items = list[0].ListItems;
                    List<RsfItemModel> subItems = new List<RsfItemModel>();
                    foreach (RsfItemModel item in items)
                    {
                        RsfItemModel subItem = new RsfItemModel();
                        subItem.Automatico = 0;
                        subItem.IndAutomatico = Constantes.NO;
                        subItem.IndManual = Constantes.NO;
                        subItem.Manual = 0;
                        subItem.HoraInicio = item.HoraInicio;
                        subItem.HoraFin = item.HoraFin;
                        subItems.Add(subItem);
                    }

                    entity.ListItems = subItems;
                }
                else
                {
                    entity.ListItems = new List<RsfItemModel>();
                }

                list.Add(entity);
            }

            this.ListaServicio = list;
            model.ListaElementos = this.OrdenarLista(list);

            return PartialView(VistasParciales.Matriz, model);
        }

        [HttpPost]
        public PartialViewResult CargarHora()
        {
            HoraModel model = new HoraModel();

            List<RsfModel> list = this.ListaServicio;

            if (list.Count > 0)
            {
                if (list[0].ListItems.Count > 0)
                {
                    model.TxtInicio = list[0].ListItems[list[0].ListItems.Count - 1].HoraFin.ToString(Constantes.FormatoHora);
                    model.TxtFin = list[0].ListItems[list[0].ListItems.Count - 1].HoraFin.ToString(Constantes.FormatoHora);
                }
                else
                {
                    model.TxtInicio = Constantes.HoraInicio;
                    model.TxtFin = Constantes.HoraInicio;
                }
            }
            else
            {
                model.TxtInicio = Constantes.HoraInicio;
                model.TxtFin = Constantes.HoraInicio;
            }

            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult AgregarHora(string fecha, string horaInicio, string horaFin, string indicador, int indice)
        {
            DateTime fechaInicio = DateTime.ParseExact(fecha + Constantes.EspacioBlanco + horaInicio,
                Constantes.FormatoFechaFull, CultureInfo.InvariantCulture);
            DateTime fechaFin = DateTime.ParseExact(fecha + Constantes.EspacioBlanco + horaFin,
                Constantes.FormatoFechaFull, CultureInfo.InvariantCulture);

            MatrizModel model = new MatrizModel();
            List<RsfModel> list = this.ListaServicio;

            foreach (RsfModel item in list)
            {
                if (indicador != Constantes.SI)
                {
                    List<RsfItemModel> entitys = item.ListItems;
                    RsfItemModel entity = new RsfItemModel
                        {
                            HoraInicio = fechaInicio,
                            HoraFin = fechaFin,
                            IndAutomatico = Constantes.NO,
                            IndManual = Constantes.NO
                        };

                    entitys.Add(entity);
                    item.ListItems = entitys;
                }
                else
                {
                    if (item.ListItems.Count > indice)
                    {
                        item.ListItems[indice].HoraInicio = fechaInicio;
                        item.ListItems[indice].HoraFin = fechaFin;
                    }
                }
            }

            this.ListaServicio = list;
            model.ListaElementos = this.OrdenarLista(list);
            return PartialView(VistasParciales.Matriz, model);
        }

        [HttpPost]
        public JsonResult ActualizarValor(int indicador, int idEquipo, int columna, decimal valor)
        {
            try
            {
                RsfModel entity = this.ListaServicio.Where(x => x.IdEquipo == idEquipo).FirstOrDefault();

                if (indicador == 1) entity.ListItems[columna].Manual = valor;
                else entity.ListItems[columna].Automatico = valor;

                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }

        [HttpPost]
        public JsonResult ActualizarIndicador(int indicador, int idEquipo, int columna, string check)
        {
            try
            {
                RsfModel entity = this.ListaServicio.Where(x => x.IdEquipo == idEquipo).FirstOrDefault();

                if (indicador == 1) entity.ListItems[columna].IndManual = check;
                else entity.ListItems[columna].IndAutomatico = check;

                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }

        [HttpPost]
        public JsonResult Grabar(string fecha)
        {
            try
            {
                DateTime fechaProceso = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);

                List<IeodCuadroDTO> entitys = new List<IeodCuadroDTO>();

                List<RsfModel> list = this.ListaServicio;
                foreach (RsfModel item in list)
                {
                    foreach (RsfItemModel child in item.ListItems)
                    {
                        IeodCuadroDTO itemAutomatico = new IeodCuadroDTO();
                        itemAutomatico.EQUICODI = item.IdEquipo;
                        itemAutomatico.SUBCAUSACODI = 319;
                        itemAutomatico.ICCHECK1 = child.IndAutomatico;
                        itemAutomatico.ICCHECK2 = Constantes.NO;
                        itemAutomatico.ICHORINI = child.HoraInicio;
                        itemAutomatico.ICHORFIN = child.HoraFin;
                        itemAutomatico.EVENCLASECODI = 1;
                        itemAutomatico.LASTDATE = DateTime.Now;
                        itemAutomatico.LASTUSER = User.Identity.Name;
                        itemAutomatico.ICVALOR1 = child.Automatico;

                        entitys.Add(itemAutomatico);

                        IeodCuadroDTO itemManual = new IeodCuadroDTO();
                        itemManual.EQUICODI = item.IdEquipo;
                        itemManual.SUBCAUSACODI = 318;
                        itemManual.ICCHECK1 = child.IndManual;
                        itemManual.ICCHECK2 = Constantes.NO;
                        itemManual.ICHORINI = child.HoraInicio;
                        itemManual.ICHORFIN = child.HoraFin;
                        itemManual.EVENCLASECODI = 1;
                        itemManual.LASTDATE = DateTime.Now;
                        itemManual.LASTUSER = User.Identity.Name;
                        itemManual.ICVALOR1 = child.Manual;

                        entitys.Add(itemManual);
                    }
                }

                this.logic.GrabarDatos(entitys, fechaProceso);
                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }

        [HttpPost]
        public PartialViewResult Consultar(string fecha)
        {
            MatrizModel model = new MatrizModel();
            
            DateTime fechaConsulta = DateTime.ParseExact(fecha, Constantes.FormatoFecha,
                CultureInfo.InvariantCulture);
            List<IeodCuadroDTO> entitys = this.logic.Consultar(fechaConsulta);
            this.ListaServicio = null;
            List<RsfModel> resultado = new List<RsfModel>();

            if (entitys.Count > 0)
            {
                List<int> ids = (from cuadro in entitys select cuadro.EQUICODI).Distinct().ToList();

                foreach (int id in ids)
                {
                    List<IeodCuadroDTO> listManual = (from cuadro in entitys
                                                      orderby cuadro.ICCODI ascending
                                                      where cuadro.EQUICODI == id && cuadro.SUBCAUSACODI == 318
                                                      select cuadro).ToList();

                    List<IeodCuadroDTO> listAutomatico = (from cuadro in entitys
                                                          orderby cuadro.ICCODI ascending
                                                          where cuadro.EQUICODI == id && cuadro.SUBCAUSACODI == 319
                                                          select cuadro).ToList();

                    if (listManual.Count == listAutomatico.Count)
                    {
                        RsfModel rsf = new RsfModel();
                        IeodCuadroDTO temporal = entitys.Where(x => x.EQUICODI == id).FirstOrDefault();

                        rsf.Equipo = temporal.EQUIABREV;
                        rsf.Empresa = temporal.EMPRENOMB;
                        rsf.Central = temporal.TAREAABREV + temporal.AREANOMB;
                        rsf.IdEmpresa = (int)temporal.EMPRCODI;
                        rsf.IdEquipo = temporal.EQUICODI;
                        rsf.Potencia = 0;
                        rsf.DesURS = this.ObtenerNombreURS(temporal.EQUICODI);

                        List<RsfItemModel> itemsRsf = new List<RsfItemModel>();

                        int k = 0;
                        foreach (IeodCuadroDTO item in listManual)
                        {
                            RsfItemModel itemRsf = new RsfItemModel();
                            itemRsf.HoraInicio = item.ICHORINI;
                            itemRsf.HoraFin = item.ICHORFIN;
                            itemRsf.Automatico = listAutomatico[k].ICVALOR1;
                            itemRsf.IndAutomatico = listAutomatico[k].ICCHECK1;
                            itemRsf.Manual = item.ICVALOR1;
                            itemRsf.IndManual = item.ICCHECK1;
                            itemsRsf.Add(itemRsf);

                            k++;
                        }

                        rsf.ListItems = itemsRsf;
                        resultado.Add(rsf);
                    }
                }
            }
            else
            {
                List<IeodCuadroDTO> lista = this.logic.GetConfiguracion();

                foreach (IeodCuadroDTO item in lista)
                {
                    RsfModel rsf = new RsfModel();

                    rsf.Equipo = item.EQUIABREV;
                    rsf.Empresa = item.EMPRENOMB;
                    rsf.Central = item.TAREAABREV + item.AREANOMB;
                    rsf.IdEmpresa = (int)item.EMPRCODI;
                    rsf.IdEquipo = item.EQUICODI;
                    rsf.Potencia = 0;
                    rsf.DesURS = this.ObtenerNombreURS(item.EQUICODI);

                    resultado.Add(rsf);
                }
            }

            this.ListaServicio = resultado;
            model.ListaElementos = this.OrdenarLista(resultado);

            return PartialView(VistasParciales.Matriz, model);
        }

        [HttpPost]
        public PartialViewResult QuitarEquipo(string codigos)
        {
            MatrizModel model = new MatrizModel();
            List<RsfModel> list = this.ListaServicio;
            List<RsfModel> resultado = new List<RsfModel>();

            string[] ids = codigos.Split(Constantes.CaracterComa);

            foreach (RsfModel item in list)
            {
                if (!ids.Contains(item.IdEquipo.ToString()))
                {
                    resultado.Add(item);
                }
            }

            this.ListaServicio = resultado;
            model.ListaElementos = this.OrdenarLista(resultado);
            return PartialView(VistasParciales.Matriz, model);
        }

        [HttpPost]
        public PartialViewResult QuitarHora(string codigos)
        {
            MatrizModel model = new MatrizModel();
            List<RsfModel> list = this.ListaServicio;
            string[] ids = codigos.Split(Constantes.CaracterComa);

            foreach (RsfModel item in list)
            {
                for (int i = 0; i < item.ListItems.Count; i++)
                {
                    for (int k = 0; k < ids.Length - 1; k++)
                    {
                        if (i == int.Parse(ids[k]))
                        {
                            item.ListItems[i].CheckDelete = Constantes.SI;
                        }
                    }
                }

                List<RsfItemModel> entitys = new List<RsfItemModel>();
                foreach (RsfItemModel child in item.ListItems)
                {
                    if (child.CheckDelete != Constantes.SI)
                    {
                        entitys.Add(child);
                    }
                }

                item.ListItems = entitys;
            }

            this.ListaServicio = list;
            model.ListaElementos = this.OrdenarLista(list);

            return PartialView(VistasParciales.Matriz, model);
        }

        [HttpPost]
        public PartialViewResult EditarHora(string horaInicio, string horaFin, int indice)
        {
            HoraModel model = new HoraModel();

            model.TxtInicio = horaInicio;
            model.TxtFin = horaFin;
            model.IndicadorEdicion = Constantes.SI;
            model.Indice = indice;

            return PartialView(VistasParciales.CargarHora, model);
        }

        /// <summary>
        /// Permite obtener la descripción del URS
        /// </summary>
        /// <param name="idEquipo"></param>
        /// <returns></returns>
        private string ObtenerNombreURS(int idEquipo)
        {
            if (idEquipo == 1199) return "URS-A-001";
            if (idEquipo == 22 || idEquipo == 23 || idEquipo == 25) return "URS-A-002";
            if (idEquipo == 11571) return "URS-A-003";
            if (idEquipo == 267 || idEquipo == 264) return "URS-M-001";
            if (idEquipo == 19 || idEquipo == 24) return "URS-M-002";
            if (idEquipo == 28 || idEquipo == 29) return "URS-M-003";
            if (idEquipo == 20 || idEquipo == 21 || idEquipo == 978) return "URS-M-004";
            if (idEquipo == 12329) return "URS-M-005";
            if (idEquipo == 18 || idEquipo == 34 || idEquipo == 35) return "URS-M-006";

            return "URS";
        }

        /// <summary>
        /// Permite ordenar la lista
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<RsfModel> OrdenarLista(List<RsfModel> list)
        {
            foreach (RsfModel item in list)
            {
                string[] orders = item.DesURS.Split(Constantes.CaracterGuion);
                if(orders.Length == 3)
                {
                    item.Order = orders[2];
                }
            }

            return list.OrderBy(x => x.Order).ToList();
        }
        
        [HttpPost]
        public JsonResult Generar(string fecha)
        {
            int result = 1;
            try
            {
                DateTime fechaProceso = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                ExcelDocument.GenerarArchivoRSF(this.ListaServicio, fechaProceso);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return Json(result);
        }

        [HttpGet]
        public virtual ActionResult Exportar()
        {
            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteEvento] + Constantes.NombreReporteRSF;
            return File(fullPath, Constantes.AppExcel, Constantes.NombreReporteRSF);
        }

        [HttpPost]
        public JsonResult GenerarMediaHora(string fecha)
        {
            int result = 1;
            try
            {
                DateTime fechaProceso = DateTime.ParseExact(fecha, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                ExcelDocument.GenerarArchivoRSF30(this.ListaServicio, fechaProceso);
                result = 1;
            }
            catch
            {
                result = -1;
            }

            return Json(result);
        }

        [HttpGet]
        public virtual ActionResult ExportarMediaHora()
        {
            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteEvento] + Constantes.NombreReporteRSF30;
            return File(fullPath, Constantes.AppExcel, Constantes.NombreReporteRSF30);
        }        

        [HttpPost]
        public JsonResult GenerarReservaAsignada(string inicio, string fin)
        {
            int result = 1;
            try
            {
                DateTime fechaInicio = DateTime.ParseExact(inicio, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(fin, Constantes.FormatoFecha, CultureInfo.InvariantCulture);

                List<IeodCuadroDTO> total = new List<IeodCuadroDTO>();

                int dias = (int)fechaFin.Subtract(fechaInicio).TotalDays;

                for (int i = 0; i <= dias; i++)
                {
                    DateTime fecha = fechaInicio.AddDays(i);
                    List<IeodCuadroDTO> all = this.logic.ObtenerReporte(fecha, fecha);
                    List<IeodCuadroDTO> list = new List<IeodCuadroDTO>();

                    list = (from t in all
                            group t by new { t.RUS, t.HORA, t.TIPO }
                                into destino
                                select new IeodCuadroDTO()
                                {
                                    RUS = destino.Key.RUS,
                                    HORA = destino.Key.HORA,
                                    TIPO = destino.Key.TIPO,
                                    ICVALOR1 = destino.Sum(t => t.ICVALOR1),
                                    FECHA = fecha.ToString(Constantes.FormatoFecha)
                                }).ToList();

                    total.AddRange(list);
                }

                ExcelDocument.GenerarArchivoTotal(total, fechaInicio.ToString(Constantes.FormatoFecha), fechaFin.ToString(Constantes.FormatoFecha));

                result = 1;
            }
            catch
            {
                result = -1;
            }

            return Json(result);
        }

        [HttpGet]
        public virtual ActionResult ExportarReservaAsignada()
        {
            string fullPath = ConfigurationManager.AppSettings[RutaDirectorio.ReporteEvento] + Constantes.NombreReporteRSFGeneral;
            return File(fullPath, Constantes.AppExcel, Constantes.NombreReporteRSFGeneral);
        }
    }
}