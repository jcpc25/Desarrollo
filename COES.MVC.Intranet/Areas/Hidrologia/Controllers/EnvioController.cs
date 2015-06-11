using COES.Dominio.DTO.Sic;
using COES.MVC.Intranet.Areas.Hidrologia.Helper;
using COES.MVC.Intranet.Areas.Hidrologia.Models;
using COES.Servicios.Aplicacion.Hidrologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Globalization;

namespace COES.MVC.Intranet.Areas.Hidrologia.Controllers
{
    public class EnvioController : Controller
    {
        //
        // GET: /Hidrologia/Envio/
        HidrologiaAppServicio logic = new HidrologiaAppServicio();

        public ActionResult Index()
        {
            HidrologiaModel model = new HidrologiaModel();
            model.ListaEmpresas = this.logic.ListarEmpresasPorTipo(Constantes.EmpresaGeneradora.ToString());                     
            model.FechaInicio = DateTime.Now.AddDays(-15).ToString(Constantes.FormatoFecha);
            model.FechaFin = DateTime.Now.ToString(Constantes.FormatoFecha);
            model.ListaTipoInformacionEnvio = Tools.ObtenerListaTipoInfo();
            model.ListaFrecuencia = Tools.ObtenerListaFrecuencia();
            return View(model);           
        }

        public ActionResult EnvioDetallado()
        {
            HidrologiaModel model = new HidrologiaModel();
            model.ListaEmpresas = this.logic.ListarEmpresasPorTipo(Constantes.EmpresaGeneradora.ToString());                     
            model.FechaInicio = DateTime.Now.AddDays(-15).ToString(Constantes.FormatoFecha);
            model.FechaFin = DateTime.Now.ToString(Constantes.FormatoFecha);            
            model.ListaTipoFormato = Tools.ObtenerListaTipoFormato();
            model.ListaPtoMedida = Tools.ObtenerListaMedida();
            return View(model);
        }

    }
}
