using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Areas.Hidrologia.Models;
using COES.MVC.Intranet.Helper;
using COES.Servicios.Aplicacion.Hidrologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Hidrologia.Controllers
{
    public class FormatoMedicionController : Controller
    {
        //
        // GET: /Hidrologia/FormatoMedicion/
        public HidrologiaAppServicio servicio;
        public FormatoMedicionController()
        {
            servicio = new HidrologiaAppServicio();
        }

        public ActionResult Index()
        {
            BusquedaFormatoMedicionModel model = new BusquedaFormatoMedicionModel();
            model.ListaOrigenLectura = servicio.ListMeOrigenlecturas ();
            model.ListaLectura = servicio.ListMeLecturas();
            model.ListaAreasCoes = servicio.ListFwAreas();


            return View(model);
        }

        public PartialViewResult ListaFormato(int area)
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.ListaFormato = servicio.GetByCriteriaMeFormatos(area) ;
            return PartialView(model);
        }

        public PartialViewResult ListaHoja(int formato)
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.ListaLectura = servicio.ListMeLecturas();
            model.ListaFormatoHojas = servicio.GetByCriteriaMeFormatohojas(formato);
            model.FormatoCodigo = formato;
            model.ListaEmpresa = servicio.ListarEmpresas();
            model.EmpresaCodigo = 0;
            return PartialView(model);
        }

        public PartialViewResult ListaPtoMedicion(int empresa,int  formato,int hoja)
        { 
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.ListaHojaPto = servicio.GetByCriteriaMeHojaptomeds(empresa, formato,hoja);
            model.ListaHeadColumn = servicio.GetByCriteriaMeHeadcolumns(formato, empresa);
            model.EmpresaCodigo = empresa;
            model.HojaNumero = hoja;
            model.FormatoCodigo = formato;
            return PartialView(model);

        }

        /// <summary>
        /// Permite mostrar la vista para la creacion de puntos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Agregar()
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.ListaLectura = servicio.ListMeLecturas();
            model.ListaAreasCoes = servicio.ListFwAreas();
            return PartialView(model);
        }

        public ActionResult Editar()
        {
            string codigo = "0";
            if (Request["id"] != null)
                codigo = Request["id"];
            int id = int.Parse(codigo);
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.Formato = servicio.GetByIdMeFormato(id);
            if (model.Formato == null)
            {
                model.Formato = new MeFormatoDTO();
                model.Formato.Formatcodi = -1;
                model.Formato.Formatnombre = string.Empty;
                model.Formato.Formatperiodo = 0;
                model.Formato.Formatresolucion = 0;
                model.Formato.Lastdate = DateTime.Now;
            }
            model.ListaLectura = servicio.ListMeLecturas();
            model.ListaAreasCoes = servicio.ListFwAreas();
            return View(model);
        }

        [HttpPost]
        public JsonResult AgregarFormato(string nombre, int area, int resolucion,int horizonte,int periodo,int lectura,string tituloHoja)
        {
            MeFormatoDTO formato = new MeFormatoDTO();
            MeFormatohojaDTO hoja = new MeFormatohojaDTO();
            int resultado = 1;
            formato.Formatnombre = nombre;
            formato.Areacode = area;
            formato.Formatresolucion = resolucion;
            formato.Formathorizonte = horizonte;
            formato.Formatperiodo = periodo;

            formato.Formatextension = "xlsx";
            formato.Lastdate = DateTime.Now;
            formato.Lastuser = User.Identity.Name;
            try
            {
                int idFormato = servicio.SaveMeFormato(formato);
                hoja.Formatcodi = idFormato;
                hoja.Hojanumero = 1;
                hoja.Hojatitulo = tituloHoja;
                hoja.Lastdate = DateTime.Now;
                hoja.Lectcodi = lectura;
                hoja.Lastuser = User.Identity.Name;
                servicio.SaveMeFormatohoja(hoja);
                return Json(resultado);
            }
            catch
            {
                return Json(-1);
            }   
        }
        /// <summary>
        /// Actualiza el formato y sus hojas
        /// </summary>
        /// <param name="idFormato"></param>
        /// <param name="idHoja"></param>
        /// <param name="nombre"></param>
        /// <param name="area"></param>
        /// <param name="resolucion"></param>
        /// <param name="horizonte"></param>
        /// <param name="periodo"></param>
        /// <param name="lectura"></param>
        /// <param name="tituloHoja"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ActualizarFormato(int idFormato,int idHoja,string nombre, int area, int resolucion, int horizonte, int periodo, int lectura, string tituloHoja)
        {
            MeFormatoDTO formato = servicio.GetByIdMeFormato(idFormato);
            if (formato != null)
            {
                formato.Formatnombre = nombre;
                formato.Formatresolucion = resolucion;
                formato.Formathorizonte = horizonte;
                formato.Formatperiodo = periodo;
                formato.Lastdate = DateTime.Now;
                formato.Lastuser = User.Identity.Name;
                try
                {
                    servicio.UpdateMeFormato(formato);
                    MeFormatohojaDTO hoja = servicio.GetByIdMeFormatohoja(idHoja, idFormato);
                    hoja.Lectcodi = lectura;
                    hoja.Hojatitulo = tituloHoja;
                    hoja.Lastdate = DateTime.Now;
                    hoja.Lastuser = User.Identity.Name;
                    servicio.UpdateMeFormatohoja(hoja);

                    int resultado = 1;
                    return Json(resultado);
                }
                catch
                {
                    return Json(-1);
                }
            }
            else {
                return Json(-1);
            }


        }

        [HttpPost]
        public PartialViewResult DetalleGeneralFormato(int formato)
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.Formato = servicio.GetByIdMeFormato(formato);
            model.ListaAreasCoes = servicio.ListFwAreas();
            return PartialView(model);
        }

        /// <summary>
        /// Abre el popup para ingresar el punto de medicion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult MostrarAgregarPto(int empresa,int formato,int hoja)
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.ListaMedidas = servicio.ListSiTipoinformacions();
            model.ListaFamilia = servicio.ListarFamilia().Where(x => x.Famcodi != 0 && x.Famcodi != -1).ToList();
            model.ListaEquipo = servicio.GetByCriteriaEqequipo(empresa, 3).Where(x => x.Equicodi != 0 && x.Equicodi != -1).ToList();
            model.HojaNumero = hoja;
            model.EmpresaCodigo = empresa;
            model.FormatoCodigo = formato;
            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult MostrarAgregarTitulo(int empresa, int formato, int hoja,string titulo,int pos)
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.HojaNumero = hoja;
            model.EmpresaCodigo = empresa;
            model.FormatoCodigo = formato;
            model.HeadColFormato = titulo;
            model.HeadColPos = pos;
            if (pos > 0)
            {
                var entity = servicio.GetByIdMeHeadcolumn(formato, hoja, empresa, pos);
                model.HeadColAncho = (int)entity.Headlen;
            }

            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult MostrarEditarPto(int formato, int hoja,int pos,string limsup,int activo)
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.HojaPto = new MeHojaptomedDTO();
            if (limsup != "")
                model.HojaPto.Hojaptolimsup = decimal.Parse(limsup);
            model.HojaPto.Hojaptoactivo = activo;
            return PartialView(model);
        }


        [HttpPost]
        public JsonResult EditarPto(int formato, int hoja, int medicion, int punto, decimal limsup, int signo, int estado)
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            MeHojaptomedDTO entity = servicio.GetByIdMeHojaptomed(hoja, formato, medicion, punto, signo);
            entity.Hojaptolimsup = limsup;
            entity.Hojaptoactivo = estado;
            if (entity != null)
            {
                entity.Hojaptolimsup = limsup;
                entity.Hojaptoactivo = estado;
                try
                {
                    servicio.UpdateMeHojaptomed(entity);
                    model.Resultado = 1;
                }
                catch
                {
                    model.Resultado = -2;
                }
            }
            else
            {
                model.Resultado = -1;
            }

            return Json(model);
        }


        /// <summary>
        /// aGREGA UN PTO DE MEDICION AL FORMATO
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="formato"></param>
        /// <param name="hoja"></param>
        /// <param name="punto"></param>
        /// <param name="medida"></param>
        /// <param name="limsup"></param>
        /// <param name="orden"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AgregarPto(int empresa, int formato, int hoja, int punto, int medida, string limsup, int signo)
        {
            decimal? limiteSup = null;
            FormatoMedicionModel model = new FormatoMedicionModel();
            MeHojaptomedDTO hojaptos = new MeHojaptomedDTO();
            if (limsup != "")
            {
                limiteSup = decimal.Parse(limsup);
            }
            //validar si punto pertenece a la empresa
            hojaptos.Ptomedicodi = punto;
            hojaptos.Formatcodi = formato;
            hojaptos.Hojanumero = hoja;
            hojaptos.Hojaptosigno = 1;
            hojaptos.Hojaptoactivo = 1;
            hojaptos.Tipoinfocodi = medida;
            hojaptos.Hojaptolimsup = limiteSup;
            hojaptos.Hojaptoliminf = 0;
            hojaptos.Lastdate = DateTime.Now;
            hojaptos.Lastuser = User.Identity.Name;
            try
            {
                var entity = servicio.GetByIdMeHojaptomed(hoja, formato, medida, punto, signo);
                if (entity == null)
                {
                    model.HojaPto = servicio.GrabarHojaPtoMedicion(hojaptos, empresa);
                    model.Resultado = 1;
                }
                else
                    model.Resultado = 0;
            }
            catch
            {

                model.Resultado = -1;
            }
            return Json(model);
        }

        public JsonResult AgregarTitulo(int empresa, int formato, int hoja,int pos ,string titulo, int ancho)
        {
            int accion = 0; //Editar Titulo
            FormatoMedicionModel model = new FormatoMedicionModel();
            MeHeadcolumnDTO entity = servicio.GetByIdMeHeadcolumn(formato, hoja, empresa, pos);
            if (entity == null)
            {
                accion = 1; // Nuevo Titulo
                entity = new MeHeadcolumnDTO();
            }
            entity.Formatcodi = formato;
            entity.Emprcodi = empresa;
            entity.Headnombre = titulo;
            entity.Headrow = 1;
            entity.Hojacodi = hoja;
            entity.Headlen = ancho;
            try
            {
                if (accion == 1)
                {
                    model.Resultado = 1;
                    servicio.SaveMeHeadcolumn(entity);
                }
                else
                {
                    model.Resultado = 0;
                    servicio.UpdateMeHeadcolumn(entity);
                }
                
            }
            catch
            {
                model.Resultado = -1;
            }

            return Json(model);
        }

        /// <summary>
        /// Genera Vista de listado de equipo
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="familia"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult ListarEquipo(int empresa, int familia)
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.ListaEquipo = servicio.GetByCriteriaEqequipo(empresa, familia).Where(x => x.Equicodi != 0 && x.Equicodi != -1).ToList();
            return PartialView(model);
        }
        /// <summary>
        /// Genera listado de puntos de medicion 
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult ListarPto(int equipo)
        {
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.ListaPtos = servicio.GetByIdEquipoMePtomedicion(equipo);
            
            return PartialView(model);
        }

        
        /// <summary>
        /// Actualiza el orden de los ptos de medicion en el formato 
        /// </summary>
        /// <param name="formato"></param>
        /// <param name="hoja"></param>
        /// <param name="empresa"></param>
        /// <param name="id"></param>
        /// <param name="fromPosition"></param>
        /// <param name="toPosition"></param>
        /// <param name="direction"></param>
        public void UpdateOrder(int formato,int hoja,int empresa,int id, int fromPosition, int toPosition, string direction)
        {
           
            if (direction == "back")
            {
                MeHojaptomedDTO entity = new MeHojaptomedDTO();
                var lista = servicio.GetByCriteriaMeHojaptomeds(empresa, formato, hoja).Where(x => x.Hojaptoorden >= toPosition
                    && x.Hojaptoorden <= fromPosition).OrderByDescending(x => x.Hojaptoorden);
                foreach (var reg in lista)
                {
                    if (reg.Hojaptoorden == fromPosition)
                    {
                        reg.Hojaptoorden = 0;
                        entity = reg;
                    }
                    else
                        reg.Hojaptoorden++;
                    servicio.UpdateMeHojaptomed(reg);
                }
                entity.Hojaptoorden = toPosition;
                servicio.UpdateMeHojaptomed(entity);
                
                    //servicio.CambiarOrdenPto(formato, hoja, empresa, fromPosition, toPosition);
            }
            else
            {
                MeHojaptomedDTO entity = new MeHojaptomedDTO();
                var lista = servicio.GetByCriteriaMeHojaptomeds(empresa, formato, hoja).Where(x => x.Hojaptoorden >= fromPosition
                    && x.Hojaptoorden <= toPosition).OrderBy(x => x.Hojaptoorden);
                foreach (var reg in lista)
                {
                    if (reg.Hojaptoorden == fromPosition)
                    {
                        reg.Hojaptoorden = 0;
                        entity = reg;
                    }
                    else
                        reg.Hojaptoorden--;
                    servicio.UpdateMeHojaptomed(reg);
                }
                entity.Hojaptoorden = toPosition;
                servicio.UpdateMeHojaptomed(entity);
            }

        }

        public PartialViewResult ListarHeadColumn(int formato,int hoja,int empresa)
        { 
            FormatoMedicionModel model = new FormatoMedicionModel();
            model.ListaHeadColumn = servicio.GetByCriteriaMeHeadcolumns(formato,empresa).Where(x => x.Hojacodi == hoja).ToList();
            return PartialView(model);
        }

        public JsonResult EliminarTitulo(int formato, int hoja, int empresa)
        {
            int resultado = 0;
            var lista = servicio.GetByCriteriaMeHeadcolumns(formato, empresa).Where(x => x.Hojacodi == hoja).ToList();
            var totalTitulos = lista.Max(x => x.Headpos);
            if (totalTitulos != null)
            {
                resultado = (int)totalTitulos;
                servicio.DeleteMeHeadcolumn(formato,hoja,empresa,(int)totalTitulos);
            }
            return Json(resultado);
        }

        public ActionResult IndexHoja()
        {
            string formato = string.Empty;
            if (Request["id"] != null)
                formato = Request["id"];
            ViewBag.formato = formato;
            return View();
        }


    }
}
