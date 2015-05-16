using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Areas.Formulas.Models;
using COES.MVC.Intranet.Helper;
using COES.Servicios.Aplicacion.General;

using COES.Servicios.Aplicacion.Scada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Formulas.Controllers
{
    public class ConfiguracionController : Controller
    {
        /// <summary>
        /// Instancia de objeto para acceso a datos
        /// </summary>
        PerfilScadaServicio servicio = new PerfilScadaServicio();

        public List<FormulaItem> ListaItemFormula = new List<FormulaItem>();

        /// <summary>
        /// Obtiene la lista completa de puntos
        /// </summary>
        public List<MePerfilRuleDTO> ListaPuntos
        {
            get
            {
                return (Session[DatosSesion.ListaPuntoFormula] != null) ?
                    (List<MePerfilRuleDTO>)Session[DatosSesion.ListaPuntoFormula] : new List<MePerfilRuleDTO>();
            }
            set { Session[DatosSesion.ListaPuntoFormula] = value; }
        }

        /// <summary>
        /// Permite identificar la fuente
        /// </summary>
        public string Indicador
        {
            get
            {
                return (Session[DatosSesion.IndicadorFuente] != null) ? Session[DatosSesion.IndicadorFuente].ToString() :
                    COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.FuenteEjecutado;
            }
            set { Session[DatosSesion.IndicadorFuente] = value; }
        }


        /// <summary>
        /// Action de inicio de la pagina
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ConfiguracionPerfilModel model = new ConfiguracionPerfilModel();
            model.Fuente = this.Indicador;    

            return View(model);
        }
        
        /// <summary>
        /// Permite buscar las fórmulas que puede visualizar el usuario
        /// </summary>
        /// <param name="fuente"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Lista(string fuente)
        {
            ConfiguracionPerfilModel model = new ConfiguracionPerfilModel();
            int areaCode = (int)((COES.MVC.Intranet.SeguridadServicio.UserDTO)Session[DatosSesion.SesionUsuario]).AreaCode;
            model.ListaFormulas = this.servicio.GetByCriteriaMePerfilRules(areaCode, fuente);            

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            try
            {
                this.servicio.EliminarFormula(id, User.Identity.Name);
                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }

        /// <summary>
        /// Habilita el formulario para crear una nueva fórmula
        /// </summary>
        /// <returns></returns>
        public ActionResult Nuevo(int? id, string edit)
        {
            ConfiguracionPerfilModel model = new ConfiguracionPerfilModel();

            int[] ids = { 1, 3, 4, 5, 7, 8, 12, 17 };

            model.ListaAreas = (new SeguridadServicio.SeguridadServicioClient()).ObtenerAreasCOES().Where(x=> ids.Contains(x.AreaCode)).ToList();
            model.Edicion = edit;

            if (id == null) id = 0;

            if (id == 0)
            {
                model.IdsAreas = new List<int>();
                model.ListaItems = new List<FormulaItem>();
                model.Fuente = string.Empty;
                model.IdFormula = 0;                
            }
            else
            {
                MePerfilRuleDTO entity = this.servicio.GetByIdMePerfilRule((int)id);
                model.SubEstacion = entity.Prruabrev;
                model.Area = entity.Prrudetalle;
                model.Fuente = entity.Prruind;
                model.IdsAreas = entity.IdRoles;             
                model.IdFormula = (int)id;
                model.UsuarioCreacion = entity.Prrufirstuser;
                model.UsuarioModificacion = entity.Prrulastuser;
                model.FechaCreacion = (entity.Prrufirstdate != null) ? ((DateTime)entity.Prrufirstdate).ToString(Constantes.FormatoFechaFull) 
                    : string.Empty;
                model.FechaModificacion = (entity.Prrulastdate != null) ? ((DateTime)entity.Prrulastdate).ToString(Constantes.FormatoFechaFull) 
                    : string.Empty;

                this.Indicador = entity.Prruind;

                this.DescomponerFormula(entity.Prruformula);
                List<FormulaItem> formulas = this.ListaItemFormula;

                foreach (FormulaItem item in formulas)
                {
                    if (entity.Prruind == COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.FuenteEjecutado)
                    {
                        if (item.Tipo == COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.Scada.ToString())
                        {
                            item.Tipo = COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.OrigenSCADA;
                            item.Descripcion = COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.TextoSCADA;
                            item.PuntoNombre = this.servicio.ObtenerNombrePunto(COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.OrigenSCADA,
                                item.Codigo);
                        }
                        else if (item.Tipo == COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.Medicion.ToString())
                        {
                            item.Tipo = COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.OrigenEjecutado;
                            item.Descripcion = COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.TextoEjecutado;
                            item.PuntoNombre = this.servicio.ObtenerNombrePunto(COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.OrigenEjecutado,
                                item.Codigo);
                        }
                    }
                    if (entity.Prruind == COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.FuenteDemanda)
                    {
                        item.Tipo = COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.OrigenDemanda;
                        item.Descripcion = COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.TextoDemanda;
                        item.PuntoNombre = this.servicio.ObtenerNombrePunto(COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.OrigenDemanda,
                                item.Codigo);
                    }
                }

                model.ListaItems = formulas;
            }

            return View(model);
        }

        /// <summary>
        /// Permite descomponer las formulas
        /// </summary>
        /// <param name="formula"></param>
        private void DescomponerFormula(string formula)
        {
            if (formula.Length > 0)
            {
                int posScada = formula.LastIndexOf(COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.Scada);
                int posMedic = formula.LastIndexOf(COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.Medicion);
                int pos = posMedic;
                char tipo = COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.Medicion;

                if (posScada > posMedic)
                {
                    pos = posScada;
                    tipo = COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.Scada;
                }

                string punto = formula.Substring(pos + 1, formula.Length - pos - 1);
                int posIni = formula.LastIndexOf(COES.Servicios.Aplicacion.Helper.ConstanteFormulaScada.SeparadorFormula);
                string operador = formula.Substring(posIni + 1, pos - posIni - 1);

                this.ListaItemFormula.Add(new FormulaItem
                {
                    Codigo = int.Parse(punto),
                    Tipo = tipo.ToString(),
                    Constante = decimal.Parse(operador)
                });

                if (posIni >= 0)
                {
                    string newFormula = formula.Substring(0, posIni);
                    this.DescomponerFormula(newFormula);
                }
            }
        }

        /// <summary>
        /// Permite mostrar las fuentes para obtener las fórmulas
        /// </summary>
        /// <param name="indicador"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Selector(string indicador)
        {
            ConfiguracionPerfilModel model = new ConfiguracionPerfilModel();
            List<MePerfilRuleDTO> listPuntos = this.servicio.ObtenerPuntosPorFuente(indicador);
            this.ListaPuntos = listPuntos;
            List<MePerfilRuleDTO> listEmpresas = new List<MePerfilRuleDTO>();

            var items = listPuntos.Select(x => new { x.EmprCodi, x.EmprNomb }).Distinct().ToList();
            foreach (var item in items)
            {
                listEmpresas.Add(new MePerfilRuleDTO { EmprCodi = item.EmprCodi, EmprNomb = item.EmprNomb });
            }

            model.ListaEmpresas = listEmpresas.OrderBy(x => x.EmprNomb).ToList();
            model.Origen = indicador;
            
            return PartialView(model);
        }

        /// <summary>
        /// Permite cargar los puntos de la empresa seleccionada
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargarPuntos(int idEmpresa, int idSubEstacion)
        {
            IList<MePerfilRuleDTO> entitys = this.ListaPuntos.Where(x => x.EmprCodi == idEmpresa && x.Areacodi == idSubEstacion).ToList();
            SelectList list = new SelectList(entitys, EntidadPropiedad.PtoMediCodi, EntidadPropiedad.PtoNomb);

            return Json(list);
        }


        /// <summary>
        /// Carga las subestaciones de una empresa
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargarSubEstacion(int idEmpresa)
        {
            IList<MePerfilRuleDTO> entitys = this.ListaPuntos.Where(x => x.EmprCodi == idEmpresa).ToList();
            var items = entitys.Select(x => new { x.Areacodi, x.AreaNomb}).Distinct().ToList();
            List<MePerfilRuleDTO> listAreas = new List<MePerfilRuleDTO>();

            foreach (var item in items)
            {
                listAreas.Add(new MePerfilRuleDTO { Areacodi = item.Areacodi, AreaNomb = item.AreaNomb });
            }
            
            SelectList list = new SelectList(listAreas, EntidadPropiedad.Areacodi, EntidadPropiedad.AreaNomb);

            return Json(list);
        }

        /// <summary>
        /// Permite grabar la fórmula
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="subEstacion"></param>
        /// <param name="area"></param>
        /// <param name="roles"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Grabar(int idFormula, string fuente, string subEstacion, string area, string roles, string items)
        {
            try
            {
                List<string> idRoles = roles.Split(Constantes.CaracterComa).ToList();
                string formula = items.Remove(items.Length - 1, 1);

                MePerfilRuleDTO entity = new MePerfilRuleDTO();
                entity.Prruabrev = subEstacion;
                entity.Prrudetalle = area;
                entity.Prruformula = items;
                entity.Prrulastuser = User.Identity.Name;
                entity.Prrufirstuser = User.Identity.Name;
                entity.Prruactiva = Constantes.SI;
                entity.Prruind = fuente;
                entity.Prrucodi = idFormula;
                entity.Prrupref = string.Empty;

                int id = this.servicio.GrabarMePerfilRule(entity, idRoles);
                
                return Json(id);
            }
            catch
            {
                return Json(-1);
            }
        }
    }
}
