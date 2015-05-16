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
    public class PtoMedicionController : Controller
    {
        //
        // GET: /Hidrologia/PtoMedicion/
        public HidrologiaAppServicio servicio;
        public PtoMedicionController()
        {
            servicio = new HidrologiaAppServicio();
        }
        public ActionResult Index()
        {
            BusquedaPtoMedicionModel model = new BusquedaPtoMedicionModel();
            model.ListaTipoPuntoMedicion = servicio.ListMeTipopuntomedicions("-1");
            model.ListaOrigenLectura = servicio.ListMeOrigenlecturas().Where(x => x.Origlectcodi != 0).ToList();
            model.ListaTipoInformacion = servicio.ListSiTipoinformacions();
            model.ListaEmpresas = servicio.ListarEmpresas();
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Lista(string empresas, string tipoOrigenLectura, string tipoPtomedicodi, int nroPagina)
        {
            PtoMedicionModel model = new PtoMedicionModel();
            model.ListaPtoMedicion = servicio.ListarPtoMedicion(empresas, tipoOrigenLectura, tipoPtomedicodi);
            return PartialView(model);
        }
        /// <summary>
        /// Agregar Punto de Medicion en BD
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Grabar(int empresa,int equipocodi,int lectura,int ptomedicion,int orden,string barranomb,string elenomb,
            string osicodi,short tipopto)
        {
            MePtomedicionDTO punto = new MePtomedicionDTO();
            int resultado = 1;
            int ptomedicodi = ptomedicion;

            FwCounterDTO counter;
            int accion = Constantes.AccionEditar;
            if (ptomedicodi == 0)
            {
                accion = Constantes.AccionNuevo;
                var buscar = servicio.ListarPtoMedicionDuplicados(equipocodi, lectura, tipopto);
                if (buscar.Count > 0)
                    return Json(-1); //Existe Punto
                counter = servicio.GetByIdFwCounter("ME_PTOMEDICION");
                if (counter != null)
                    ptomedicodi = (int)counter.Maxcount + 1;
            }
            else
            {
                punto = servicio.GetByIdMePtomedicion(ptomedicodi);
            }

            punto.Ptomedicodi = ptomedicodi;
            punto.Lastuser = User.Identity.Name;
            punto.Lastdate = DateTime.Now;
            punto.Emprcodi = empresa;
            punto.Equicodi = equipocodi;
            punto.Origlectcodi = lectura;
            punto.Orden = orden;
            punto.Ptomedibarranomb = barranomb;
            punto.Ptomedielenomb = elenomb; // Abreviatura d el Pto medicion , sin espacios en blanco
            punto.Osicodi = osicodi;
            punto.Tipoptomedicodi = tipopto;
            try
            {
                if (accion == Constantes.AccionNuevo)
                {
                    int grupocodi = -1;
                    var equipo = servicio.GetByIdEqequipo(equipocodi);
                    if (equipo != null)
                        if (equipo.Grupocodi != null)
                            grupocodi = (int)equipo.Grupocodi;
                    punto.Grupocodi = grupocodi;
                    punto.Codref = PuntoMedicion.CodRef;
                    punto.Tipoinfocodi = PuntoMedicion.TipoInfoCodi;
                    punto.Ptomediestado = PuntoMedicion.EstadoActivo;
                    FwCounterDTO entity = new FwCounterDTO();
                    entity.Maxcount = ptomedicodi;
                    entity.Tablename = "ME_PTOMEDICION";
                    servicio.SavePtoMedicion(punto, entity);
                }
                else // Accion Editar
                {
                    servicio.UpdatePtoMedicion(punto);
                }
            }
            catch
            {
                resultado = 0;
            }

            return Json(resultado);
        }

        public ActionResult Editar()
        {
            string codigo = "0";
            if(Request["id"] != null)
                codigo = Request["id"];
            int id = int.Parse(codigo);
            PtoMedicionModel model = new PtoMedicionModel();
            model.ptomedicion = servicio.GetByIdMePtomedicion(id);
            if (model.ptomedicion == null)
            {
                model.ptomedicion = new MePtomedicionDTO();
                model.ptomedicion.Emprcodi = -1;
                model.ptomedicion.famcodi = 0;
                model.ptomedicion.Equicodi = 0;
                model.ptomedicion.Origlectcodi = 0;
                model.ptomedicion.Ptomedicodi = 0;
                model.ptomedicion.Orden = 0;
                model.ptomedicion.Ptomedibarranomb = string.Empty;
                model.ptomedicion.Ptomedielenomb = string.Empty;
                model.ptomedicion.Osicodi = string.Empty;
            }
            model.ListaEmpresas = servicio.ListarEmpresas();
            model.ListaFamilia = servicio.ListarFamilia();
            model.ListaEquipo = this.servicio.GetByCriteriaEqequipo((int)model.ptomedicion.Emprcodi, model.ptomedicion.famcodi);
            model.ListaTipoPuntoMedicion = servicio.ListMeTipopuntomedicions(model.ptomedicion.Origlectcodi.ToString());
            model.ListaOrigenLectura = servicio.ListMeOrigenlecturas();

            return View(model);
        }

        [HttpPost]
        public JsonResult CargarEquipos(int idEmpresa,int idFamilia)
        {
            List<EqEquipoDTO> entitys = new List<EqEquipoDTO>();
            entitys = this.servicio.GetByCriteriaEqequipo(idEmpresa, idFamilia);
            SelectList list = new SelectList(entitys, EntidadPropiedad.EquiCodi, EntidadPropiedad.EquiNomb);

            return Json(list);
        }

        [HttpPost]
        public JsonResult CargarTipoPto(string tipoOrigenLectura)
        {
            List<MeTipopuntomedicionDTO> lista = new List<MeTipopuntomedicionDTO>();
            lista = servicio.ListMeTipopuntomedicions(tipoOrigenLectura);
            SelectList list = new SelectList(lista, EntidadPropiedad.Tipoptomedicodi, EntidadPropiedad.Tipoptomedinomb);
            return Json(list);
        }

        [HttpPost]
        public PartialViewResult TipoPtoMedicion(string tipoOrigenLectura)
        {
            BusquedaPtoMedicionModel model = new BusquedaPtoMedicionModel();
            List<MeTipopuntomedicionDTO> lista = new List<MeTipopuntomedicionDTO>();
            lista = servicio.ListMeTipopuntomedicions(tipoOrigenLectura);
            lista.Add(new MeTipopuntomedicionDTO()
            {
                 Tipoptomedicodi = -1,
                 Tipoptomedinomb = "_NO DEFINIDO"
            });

            model.ListaTipoPuntoMedicion = lista;
            return PartialView(model);
        }
    }
}
