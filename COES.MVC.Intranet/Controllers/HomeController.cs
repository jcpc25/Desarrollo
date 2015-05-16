using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using COES.MVC.Intranet.Helper;
using COES.MVC.Intranet.Models;
using COES.MVC.Intranet.SeguridadServicio;

namespace COES.Web.MVC.Seguridad.Controllers
{
    public class HomeController : Controller
    {
        SeguridadServicioClient servicio = new SeguridadServicioClient();
        List<string> ListaMapa = new List<string>(); 

        /// <summary>
        /// Permite mostrar la vista inicial de la app
        /// </summary>
        /// <returns></returns>
        //[CustomAuthorize]
        public ActionResult Default()
        {   
            HttpCookie cookie = Request.Cookies[DatosSesion.InicioSesion];

            if (cookie != null)
            {
                if (cookie[DatosSesion.SesionUsuario] != null)
                {
                    Session[DatosSesion.SesionMapa] = Constantes.NodoPrincipal; 
                    Session[DatosSesion.SesionUsuario] = this.servicio.ObtenerUsuarioPorLogin(cookie[DatosSesion.SesionUsuario].ToString());                  
                    FormsAuthentication.SetAuthCookie(cookie[DatosSesion.SesionUsuario].ToString(), false);
                }
            }
            else 
            {
                if (Session[DatosSesion.SesionUsuario] != null)
                {
                    Session[DatosSesion.SesionMapa] = Constantes.NodoPrincipal;                    
                }
                else
                {
                    Response.Redirect(Constantes.PaginaLogin);
                }
            }


            return View();
        }
                
        /// <summary>
        /// Muestra vista de info
        /// </summary>
        /// <returns></returns>
        public ActionResult Info()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de autorizacion
        /// </summary>
        /// <returns></returns>
        public ActionResult Autorizacion()
        {
            return View();
        }

        /// <summary>
        /// Permite mostrar la pagina de login
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Permite cerrar sesion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session[DatosSesion.SesionUsuario] = null;
            HttpCookie myCookie = new HttpCookie(DatosSesion.InicioSesion);
            myCookie.Expires = DateTime.Now.AddDays(-2d);
            Response.Cookies.Add(myCookie);
            return Json(1);
        }

        /// <summary>
        /// Permite realizar la validacion del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public JsonResult Autenticar(string usuario, string password, int indicador)
        {
            int resultado = 0;
            UserDTO entidad = this.servicio.AutentificarUsuarioAD(usuario, password, out resultado);

            if (resultado == 1)
            {                
                FormsAuthentication.SetAuthCookie(usuario, false);
                Session[DatosSesion.SesionUsuario] = entidad;
                this.CrearCokkie(usuario, indicador);
            }
            else 
            {
                entidad = this.servicio.AutentificarUsuario(usuario, password, out resultado);
                if (resultado == 1)
                {                   
                    FormsAuthentication.SetAuthCookie(usuario, false);
                    Session[DatosSesion.SesionUsuario] = entidad;
                    this.CrearCokkie(usuario, indicador);
                }
            }

            return Json(resultado);
        
        }

        /// <summary>
        /// Permite una autentificacion para usuarios anónimos
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public JsonResult AutenticarAnonimo()
        {
            int resultado = 0;
            string usuario = Constantes.UsuarioAnonimo;
            string clave = Constantes.ClaveAnonimo;

            UserDTO entidad = this.servicio.AutentificarUsuario(usuario, clave, out resultado);

            if (resultado == 1)
            {
                FormsAuthentication.SetAuthCookie(usuario, false);
                Session[DatosSesion.SesionUsuario] = entidad;
            }

            return Json(resultado);
        }

        /// <summary>
        /// Permite crear una cokkie con los datos del usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="indicador"></param>
        protected void CrearCokkie(string userName, int indicador)
        {
            if (indicador == 1)
            {
                HttpCookie cookie = Request.Cookies[DatosSesion.InicioSesion];

                if (cookie == null)
                {
                    cookie = new HttpCookie(DatosSesion.InicioSesion);
                }

                cookie[DatosSesion.SesionUsuario] = userName;
                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
            }
            else
            {
                HttpCookie myCookie = new HttpCookie(DatosSesion.InicioSesion);
                myCookie.Expires = DateTime.Now.AddDays(-2d);
                Response.Cookies.Add(myCookie);
            }        
        }


        /// <summary>
        /// Permite mostrar el menu de la aplicacion
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public PartialViewResult Menu()
        {
            ViewBag.Menu = this.CrearMenu();        
            return PartialView();
        }

        /// <summary>
        /// Permite mostrar los datos en la cabecera
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public PartialViewResult Header()
        {
            ViewBag.UserName = string.Empty;

            if (Session[DatosSesion.SesionUsuario] != null)
            {
                ViewBag.UserName = ((UserDTO)Session[DatosSesion.SesionUsuario]).UsernName;
                ViewBag.UserLogin = ((UserDTO)Session[DatosSesion.SesionUsuario]).UserLogin + Constantes.SufijoImagenUser;
            }
            else 
            {
                if (string.IsNullOrEmpty(User.Identity.Name))
                {
                    ViewBag.UserLogin = User.Identity.Name + Constantes.SufijoImagenUser;
                }
            }

            return PartialView();
        }

        /// <summary>
        /// Permite establecer el nodo actual consultado
        /// </summary>
        /// <param name="idOpcion"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SetearOpcion(int idOpcion)
        {
            if (idOpcion > 0)
            {
                Session[DatosSesion.SesionIdOpcion] = idOpcion;
                string str = string.Empty;
                string user = User.Identity.Name;
                List<OptionDTO> opciones = this.servicio.ObtenerOpcionPorUsuario(Constantes.IdAplicacion, user).ToList();
                this.servicio.GrabarEstadistica(idOpcion, user, DateTime.Now);

                this.ObtenerMapaRuta(opciones, idOpcion);                

                for (int i = this.ListaMapa.Count - 1; i >= 0; i--)
                {
                    str = str + this.ListaMapa[i] + Constantes.SeparacionMapa;
                }

                Session[DatosSesion.SesionMapa] = str;
                return Json(1);
            }
            else 
            {
                Session[DatosSesion.SesionIdOpcion] = null;
                return Json(-1);
            }
        }

        /// <summary>
        /// Muestra el mapa de navegacion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult MostrarMapa()
        {
            if (Session[DatosSesion.SesionMapa] != null)
            {
                return Json(Session[DatosSesion.SesionMapa].ToString());
            }
            return Json(Constantes.NodoPrincipal);
        }


        ///<summary>
        ///Arma el menu segun la aplicación y el usuario
        ///</summary>
        ///<returns></returns>
        private IList<MenuModel> CrearMenu()
        {
            IList<MenuModel> list = new List<MenuModel>();
            if (User != null)
            {
                string user = User.Identity.Name;
                List<OptionDTO> opciones = this.servicio.ObtenerOpcionPorUsuario(Constantes.IdAplicacion, user).ToList();

                foreach (OptionDTO item in opciones)
                {
                    list.Add(new MenuModel()
                    {
                        OpcionId = (int)item.OptionCode,
                        PadreId = item.PadreCodi,
                        Descripcion = item.OptionDesc,
                        Nombre = item.OptionName,
                        NroOrden = item.NroOrden,
                        OpcionURL = item.DesUrl,
                        Tipo = item.IndTipo,
                        DesControlador = (!string.IsNullOrEmpty(item.DesArea)) ? item.DesArea + "/" + item.DesController : item.DesController,
                        DesAccion = item.DesAction,
                        DesArea = item.DesArea
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// Permite obtener la ruta actual
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="idOpcion"></param>
        /// <returns></returns>
        private void ObtenerMapaRuta(List<OptionDTO> lista, int idOpcion)
        {        
            OptionDTO dto = lista.Where(x => x.OptionCode == idOpcion).FirstOrDefault();
            if (dto != null)
            {
                this.ListaMapa.Add(dto.OptionName);
                if (dto.PadreCodi != 1)
                {
                    this.ObtenerMapaRuta(lista, dto.PadreCodi);              
                }                
            }      
        }
    }
}
