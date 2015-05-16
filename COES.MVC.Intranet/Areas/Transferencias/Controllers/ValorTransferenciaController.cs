using COES.Dominio.DTO.Transferencias;
using COES.MVC.Intranet.Areas.Transferencias.Helper;
using COES.MVC.Intranet.Areas.Transferencias.Models;
using COES.Servicios.Aplicacion.Transferencias;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COES.MVC.Intranet.Helper;

namespace COES.MVC.Intranet.Areas.Transferencias.Controllers
{
    public class ValorTransferenciaController : Controller
    {
        public ActionResult Index()
        {
            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();

            CentralGeneracionModel modelCentralGene = new CentralGeneracionModel();
            modelCentralGene.ListaCentralGeneracion = (new GeneralAppServicioCentralGeneracion()).ListCentralGeneracion();

            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();


            PeriodoModel modelPeriodo1 = new PeriodoModel();
            modelPeriodo1.ListaPeriodos = (new GeneralAppServicioPeriodo()).ListPeriodo();

            TempData["PERIANIOMES1"] = new SelectList(modelPeriodo1.ListaPeriodos, "PERICODI", "PERINOMBRE");
            TempData["PERIANIOMES2"] = new SelectList(modelPeriodo1.ListaPeriodos, "PERICODI", "PERINOMBRE");
            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE");
            TempData["CENTGENECODI2"] = new SelectList(modelCentralGene.ListaCentralGeneracion, "CENTGENECODI", "CENTGENENOMBRE");
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN");

            return View();
        }


        //POST
        [HttpPost]
        public ActionResult Lista(int? empcodi, int? centgenecodi, int? barrcodi, int? pericodi)
        {


            ValorTransferenciaModel model = new ValorTransferenciaModel();
            model.ListaValorTransferencia = (new GeneralAppServicioValorTransferencia()).BuscarValorTransferenciaGetByCriteria(empcodi, barrcodi, pericodi); //int pericodi, string barrcodi

            return PartialView(model);
        }

        public ActionResult View(int id = 0)
        {
            ValorTransferenciaModel model = new ValorTransferenciaModel();
            //model.Entidad = (new GeneralAppServicioValorTransferencia()).GetByIdValorTransferencia(id);

            return PartialView(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Recalcular(int pericodi)
        {

            try
            {

                int version = 1;

                //eliminando valor transferencia
                int eliminavalor = 0;
                eliminavalor = new GeneralAppServicioValorTransferencia().DeleteListaValorTransferencia(pericodi, version);


                TransferenciaEntregaDetalleModel modelTransferenciaEntregaDetalle = new TransferenciaEntregaDetalleModel();
                TransferenciaRetiroDetalleModel modelTransferenciaRetiroDetalle = new TransferenciaRetiroDetalleModel();


                modelTransferenciaEntregaDetalle.ListaTransferenciaEntregaDetalle = (new GerenalAppServicioTransferenciaEntregaDetalle()).ListTransferenciaEntregaDetallePeriVer(pericodi, version);
                modelTransferenciaRetiroDetalle.ListaTransferenciaRetiroDetalle = (new GerenalAppServicioTransferenciaRetiroDetalle()).ListTransferenciaRetiroDetallePeriVer(pericodi, version);



                //Para traer especificamente entrega
                TransferenciaEntregaDetalleModel modelTransferenciaEntregaDetalle2 = new TransferenciaEntregaDetalleModel();
                CostoMarginalModel modelCostoMarginaModel2 = new CostoMarginalModel();

                //
                //Para traer especificamente entrega
                TransferenciaRetiroDetalleModel modelTransferenciaRetiroDetalle3 = new TransferenciaRetiroDetalleModel();
                CostoMarginalModel modelCostoMarginaModel3 = new CostoMarginalModel();




                //Valor de transferencia
                ValorTransferenciaDTO entidadValorTransferencia = new ValorTransferenciaDTO();


                foreach (var x in modelTransferenciaEntregaDetalle.ListaTransferenciaEntregaDetalle)
                {

                    modelCostoMarginaModel2.ListaCostoMarginal = (new GeneralAppServicioCostoMarginal()).ListValorTransferenciaByBarraPeridoVersion(x.Barrcodi, pericodi, version);
                    modelTransferenciaEntregaDetalle2.ListaTransferenciaEntregaDetalle = (new GerenalAppServicioTransferenciaEntregaDetalle()).BuscarTransferenciaEntregaDetalle(x.Emprcodi, pericodi, x.Codientrcodigo, version);

                    var CME = modelCostoMarginaModel2.ListaCostoMarginal;
                    var TE = modelTransferenciaEntregaDetalle2.ListaTransferenciaEntregaDetalle;

                    for (int i = 0; i < CME.Count(); i++)
                    {
                        decimal total = 0;

                        decimal TotalEnergiaEntrega = 0;
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah1);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah2);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah3);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah4);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah5);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah6);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah7);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah8);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah9);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah10);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah11);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah12);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah13);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah14);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah15);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah16);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah17);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah18);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah19);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah20);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah21);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah22);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah23);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah24);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah25);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah26);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah27);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah28);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah29);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah30);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah31);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah32);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah33);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah34);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah35);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah36);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah37);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah38);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah39);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah40);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah41);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah42);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah43);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah44);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah45);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah46);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah47);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah48);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah49);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah50);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah51);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah52);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah53);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah54);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah55);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah56);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah57);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah58);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah59);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah60);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah61);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah62);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah63);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah64);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah65);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah66);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah67);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah68);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah69);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah70);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah71);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah72);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah73);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah74);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah75);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah76);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah77);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah78);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah79);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah80);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah81);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah82);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah83);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah84);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah85);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah86);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah87);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah88);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah89);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah90);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah91);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah92);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah93);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah94);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah95);
                        TotalEnergiaEntrega += (TE[i].Tranentrdetah96);

                        //////

                        entidadValorTransferencia.BarrCodi = x.Barrcodi;
                        entidadValorTransferencia.EmpCodi = x.Emprcodi;
                        entidadValorTransferencia.PeriCodi = x.Pericodi;
                        entidadValorTransferencia.ValoTranFlag = "E";
                        entidadValorTransferencia.CostMargCodi = CME[i].CosMarCodi;
                        entidadValorTransferencia.ValoTranCodEntRet = x.Codientrcodigo;
                        entidadValorTransferencia.ValoTranVersion = x.Tranentrversion;
                        entidadValorTransferencia.ValoTranDia = TE[i].Tranentrdetadia;
                        entidadValorTransferencia.VTTipoinformacion = x.Tranentrtipoinformacion;
                        entidadValorTransferencia.VTTotalEnergia = (TotalEnergiaEntrega);
                        entidadValorTransferencia.Vtranusername = User.Identity.Name;

                        total += entidadValorTransferencia.VT1 = (CME[i].CosMar1 * TE[i].Tranentrdetah1);
                        total += entidadValorTransferencia.VT2 = (CME[i].CosMar2 * TE[i].Tranentrdetah2);
                        total += entidadValorTransferencia.VT3 = (CME[i].CosMar3 * TE[i].Tranentrdetah3);
                        total += entidadValorTransferencia.VT4 = (CME[i].CosMar4 * TE[i].Tranentrdetah4);
                        total += entidadValorTransferencia.VT5 = (CME[i].CosMar5 * TE[i].Tranentrdetah5);
                        total += entidadValorTransferencia.VT6 = (CME[i].CosMar6 * TE[i].Tranentrdetah6);
                        total += entidadValorTransferencia.VT7 = (CME[i].CosMar7 * TE[i].Tranentrdetah7);
                        total += entidadValorTransferencia.VT8 = (CME[i].CosMar8 * TE[i].Tranentrdetah8);
                        total += entidadValorTransferencia.VT9 = (CME[i].CosMar9 * TE[i].Tranentrdetah9);
                        total += entidadValorTransferencia.VT10 = (CME[i].CosMar10 * TE[i].Tranentrdetah10);
                        total += entidadValorTransferencia.VT11 = (CME[i].CosMar11 * TE[i].Tranentrdetah11);
                        total += entidadValorTransferencia.VT12 = (CME[i].CosMar12 * TE[i].Tranentrdetah12);
                        total += entidadValorTransferencia.VT13 = (CME[i].CosMar13 * TE[i].Tranentrdetah13);
                        total += entidadValorTransferencia.VT14 = (CME[i].CosMar14 * TE[i].Tranentrdetah14);
                        total += entidadValorTransferencia.VT15 = (CME[i].CosMar15 * TE[i].Tranentrdetah15);
                        total += entidadValorTransferencia.VT16 = (CME[i].CosMar16 * TE[i].Tranentrdetah16);
                        total += entidadValorTransferencia.VT17 = (CME[i].CosMar17 * TE[i].Tranentrdetah17);
                        total += entidadValorTransferencia.VT18 = (CME[i].CosMar18 * TE[i].Tranentrdetah18);
                        total += entidadValorTransferencia.VT19 = (CME[i].CosMar19 * TE[i].Tranentrdetah19);
                        total += entidadValorTransferencia.VT20 = (CME[i].CosMar20 * TE[i].Tranentrdetah20);
                        total += entidadValorTransferencia.VT21 = (CME[i].CosMar21 * TE[i].Tranentrdetah21);
                        total += entidadValorTransferencia.VT22 = (CME[i].CosMar22 * TE[i].Tranentrdetah22);
                        total += entidadValorTransferencia.VT23 = (CME[i].CosMar23 * TE[i].Tranentrdetah23);
                        total += entidadValorTransferencia.VT24 = (CME[i].CosMar24 * TE[i].Tranentrdetah24);
                        total += entidadValorTransferencia.VT25 = (CME[i].CosMar25 * TE[i].Tranentrdetah25);
                        total += entidadValorTransferencia.VT26 = (CME[i].CosMar26 * TE[i].Tranentrdetah26);
                        total += entidadValorTransferencia.VT27 = (CME[i].CosMar27 * TE[i].Tranentrdetah27);
                        total += entidadValorTransferencia.VT28 = (CME[i].CosMar28 * TE[i].Tranentrdetah28);
                        total += entidadValorTransferencia.VT29 = (CME[i].CosMar29 * TE[i].Tranentrdetah29);
                        total += entidadValorTransferencia.VT30 = (CME[i].CosMar30 * TE[i].Tranentrdetah30);
                        total += entidadValorTransferencia.VT31 = (CME[i].CosMar31 * TE[i].Tranentrdetah31);
                        total += entidadValorTransferencia.VT32 = (CME[i].CosMar32 * TE[i].Tranentrdetah32);
                        total += entidadValorTransferencia.VT33 = (CME[i].CosMar33 * TE[i].Tranentrdetah33);
                        total += entidadValorTransferencia.VT34 = (CME[i].CosMar34 * TE[i].Tranentrdetah34);
                        total += entidadValorTransferencia.VT35 = (CME[i].CosMar35 * TE[i].Tranentrdetah35);
                        total += entidadValorTransferencia.VT36 = (CME[i].CosMar36 * TE[i].Tranentrdetah36);
                        total += entidadValorTransferencia.VT37 = (CME[i].CosMar37 * TE[i].Tranentrdetah37);
                        total += entidadValorTransferencia.VT38 = (CME[i].CosMar38 * TE[i].Tranentrdetah38);
                        total += entidadValorTransferencia.VT39 = (CME[i].CosMar39 * TE[i].Tranentrdetah39);
                        total += entidadValorTransferencia.VT40 = (CME[i].CosMar40 * TE[i].Tranentrdetah40);
                        total += entidadValorTransferencia.VT41 = (CME[i].CosMar41 * TE[i].Tranentrdetah41);
                        total += entidadValorTransferencia.VT42 = (CME[i].CosMar42 * TE[i].Tranentrdetah42);
                        total += entidadValorTransferencia.VT43 = (CME[i].CosMar43 * TE[i].Tranentrdetah43);
                        total += entidadValorTransferencia.VT44 = (CME[i].CosMar44 * TE[i].Tranentrdetah44);
                        total += entidadValorTransferencia.VT45 = (CME[i].CosMar45 * TE[i].Tranentrdetah45);
                        total += entidadValorTransferencia.VT46 = (CME[i].CosMar46 * TE[i].Tranentrdetah46);
                        total += entidadValorTransferencia.VT47 = (CME[i].CosMar47 * TE[i].Tranentrdetah47);
                        total += entidadValorTransferencia.VT48 = (CME[i].CosMar48 * TE[i].Tranentrdetah48);
                        total += entidadValorTransferencia.VT49 = (CME[i].CosMar49 * TE[i].Tranentrdetah49);
                        total += entidadValorTransferencia.VT50 = (CME[i].CosMar50 * TE[i].Tranentrdetah50);
                        total += entidadValorTransferencia.VT51 = (CME[i].CosMar51 * TE[i].Tranentrdetah51);
                        total += entidadValorTransferencia.VT52 = (CME[i].CosMar52 * TE[i].Tranentrdetah52);
                        total += entidadValorTransferencia.VT53 = (CME[i].CosMar53 * TE[i].Tranentrdetah53);
                        total += entidadValorTransferencia.VT54 = (CME[i].CosMar54 * TE[i].Tranentrdetah54);
                        total += entidadValorTransferencia.VT55 = (CME[i].CosMar55 * TE[i].Tranentrdetah55);
                        total += entidadValorTransferencia.VT56 = (CME[i].CosMar56 * TE[i].Tranentrdetah56);
                        total += entidadValorTransferencia.VT57 = (CME[i].CosMar57 * TE[i].Tranentrdetah57);
                        total += entidadValorTransferencia.VT58 = (CME[i].CosMar58 * TE[i].Tranentrdetah58);
                        total += entidadValorTransferencia.VT59 = (CME[i].CosMar59 * TE[i].Tranentrdetah59);
                        total += entidadValorTransferencia.VT60 = (CME[i].CosMar60 * TE[i].Tranentrdetah60);
                        total += entidadValorTransferencia.VT61 = (CME[i].CosMar61 * TE[i].Tranentrdetah61);
                        total += entidadValorTransferencia.VT62 = (CME[i].CosMar62 * TE[i].Tranentrdetah62);
                        total += entidadValorTransferencia.VT63 = (CME[i].CosMar63 * TE[i].Tranentrdetah63);
                        total += entidadValorTransferencia.VT64 = (CME[i].CosMar64 * TE[i].Tranentrdetah64);
                        total += entidadValorTransferencia.VT65 = (CME[i].CosMar65 * TE[i].Tranentrdetah65);
                        total += entidadValorTransferencia.VT66 = (CME[i].CosMar66 * TE[i].Tranentrdetah66);
                        total += entidadValorTransferencia.VT67 = (CME[i].CosMar67 * TE[i].Tranentrdetah67);
                        total += entidadValorTransferencia.VT68 = (CME[i].CosMar68 * TE[i].Tranentrdetah68);
                        total += entidadValorTransferencia.VT69 = (CME[i].CosMar69 * TE[i].Tranentrdetah69);
                        total += entidadValorTransferencia.VT70 = (CME[i].CosMar70 * TE[i].Tranentrdetah70);
                        total += entidadValorTransferencia.VT71 = (CME[i].CosMar71 * TE[i].Tranentrdetah71);
                        total += entidadValorTransferencia.VT72 = (CME[i].CosMar72 * TE[i].Tranentrdetah72);
                        total += entidadValorTransferencia.VT73 = (CME[i].CosMar73 * TE[i].Tranentrdetah73);
                        total += entidadValorTransferencia.VT74 = (CME[i].CosMar74 * TE[i].Tranentrdetah74);
                        total += entidadValorTransferencia.VT75 = (CME[i].CosMar75 * TE[i].Tranentrdetah75);
                        total += entidadValorTransferencia.VT76 = (CME[i].CosMar76 * TE[i].Tranentrdetah76);
                        total += entidadValorTransferencia.VT77 = (CME[i].CosMar77 * TE[i].Tranentrdetah77);
                        total += entidadValorTransferencia.VT78 = (CME[i].CosMar78 * TE[i].Tranentrdetah78);
                        total += entidadValorTransferencia.VT79 = (CME[i].CosMar79 * TE[i].Tranentrdetah79);
                        total += entidadValorTransferencia.VT80 = (CME[i].CosMar80 * TE[i].Tranentrdetah80);
                        total += entidadValorTransferencia.VT81 = (CME[i].CosMar81 * TE[i].Tranentrdetah81);
                        total += entidadValorTransferencia.VT82 = (CME[i].CosMar82 * TE[i].Tranentrdetah82);
                        total += entidadValorTransferencia.VT83 = (CME[i].CosMar83 * TE[i].Tranentrdetah83);
                        total += entidadValorTransferencia.VT84 = (CME[i].CosMar84 * TE[i].Tranentrdetah84);
                        total += entidadValorTransferencia.VT85 = (CME[i].CosMar85 * TE[i].Tranentrdetah85);
                        total += entidadValorTransferencia.VT86 = (CME[i].CosMar86 * TE[i].Tranentrdetah86);
                        total += entidadValorTransferencia.VT87 = (CME[i].CosMar87 * TE[i].Tranentrdetah87);
                        total += entidadValorTransferencia.VT88 = (CME[i].CosMar88 * TE[i].Tranentrdetah88);
                        total += entidadValorTransferencia.VT89 = (CME[i].CosMar89 * TE[i].Tranentrdetah89);
                        total += entidadValorTransferencia.VT90 = (CME[i].CosMar90 * TE[i].Tranentrdetah90);
                        total += entidadValorTransferencia.VT91 = (CME[i].CosMar91 * TE[i].Tranentrdetah91);
                        total += entidadValorTransferencia.VT92 = (CME[i].CosMar92 * TE[i].Tranentrdetah92);
                        total += entidadValorTransferencia.VT93 = (CME[i].CosMar93 * TE[i].Tranentrdetah93);
                        total += entidadValorTransferencia.VT94 = (CME[i].CosMar94 * TE[i].Tranentrdetah94);
                        total += entidadValorTransferencia.VT95 = (CME[i].CosMar95 * TE[i].Tranentrdetah95);
                        total += entidadValorTransferencia.VT96 = (CME[i].CosMar96 * TE[i].Tranentrdetah96);
                        entidadValorTransferencia.VTTotalDia = (total);


                        int Grabo = 0;
                        Grabo = new GeneralAppServicioValorTransferencia().SaveValorTransferencia(entidadValorTransferencia);
                    }




                }
                foreach (var y in modelTransferenciaRetiroDetalle.ListaTransferenciaRetiroDetalle)
                {
                    modelCostoMarginaModel3.ListaCostoMarginal = (new GeneralAppServicioCostoMarginal()).ListValorTransferenciaByBarraPeridoVersion(y.Barrcodi, pericodi, version);
                    modelTransferenciaRetiroDetalle3.ListaTransferenciaRetiroDetalle = (new GerenalAppServicioTransferenciaRetiroDetalle()).BuscarTransferenciaRetiroDetalle(y.Emprcodi, pericodi, y.Solicodireticodigo, version);


                    var CMR = modelCostoMarginaModel3.ListaCostoMarginal;
                    var TR = modelTransferenciaRetiroDetalle3.ListaTransferenciaRetiroDetalle;

                    for (int i = 0; i < CMR.Count(); i++)
                    {

                        decimal total = 0;

                        decimal TotalEnergiaRetiro = 0;





                        TotalEnergiaRetiro += (TR[i].Tranretidetah1);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah2);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah3);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah4);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah5);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah6);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah7);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah8);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah9);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah10);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah11);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah12);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah13);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah14);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah15);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah16);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah17);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah18);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah19);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah20);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah21);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah22);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah23);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah24);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah25);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah26);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah27);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah28);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah29);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah30);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah31);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah32);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah33);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah34);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah35);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah36);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah37);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah38);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah39);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah40);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah41);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah42);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah43);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah44);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah45);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah46);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah47);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah48);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah49);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah50);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah51);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah52);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah53);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah54);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah55);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah56);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah57);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah58);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah59);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah60);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah61);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah62);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah63);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah64);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah65);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah66);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah67);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah68);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah69);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah70);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah71);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah72);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah73);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah74);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah75);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah76);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah77);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah78);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah79);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah80);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah81);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah82);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah83);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah84);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah85);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah86);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah87);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah88);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah89);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah90);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah91);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah92);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah93);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah94);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah95);
                        TotalEnergiaRetiro += (TR[i].Tranretidetah96);

                        ////
                        entidadValorTransferencia.BarrCodi = y.Barrcodi;
                        entidadValorTransferencia.EmpCodi = y.Emprcodi;
                        entidadValorTransferencia.PeriCodi = y.Pericodi;
                        if (y.TretTabla.Equals("CORESO"))
                        {
                            entidadValorTransferencia.ValoTranFlag = "R";
                        }                        
                        if(y.TretTabla.Equals("CORESC"))
                        {
                            entidadValorTransferencia.ValoTranFlag = "X";
                        }

                        entidadValorTransferencia.CostMargCodi = CMR[i].CosMarCodi;
                        entidadValorTransferencia.ValoTranCodEntRet = y.Solicodireticodigo;
                        entidadValorTransferencia.ValoTranVersion = y.Tretversion;
                        entidadValorTransferencia.ValoTranDia = TR[i].Tranretidetadia;
                        entidadValorTransferencia.VTTipoinformacion = y.Tranretitipoinformacion;
                        entidadValorTransferencia.VTTotalEnergia = (TotalEnergiaRetiro);
                        entidadValorTransferencia.Vtranusername = User.Identity.Name;


                        total += entidadValorTransferencia.VT1 = (CMR[i].CosMar1 * TR[i].Tranretidetah1);
                        total += entidadValorTransferencia.VT2 = (CMR[i].CosMar2 * TR[i].Tranretidetah2);
                        total += entidadValorTransferencia.VT3 = (CMR[i].CosMar3 * TR[i].Tranretidetah3);
                        total += entidadValorTransferencia.VT4 = (CMR[i].CosMar4 * TR[i].Tranretidetah4);
                        total += entidadValorTransferencia.VT5 = (CMR[i].CosMar5 * TR[i].Tranretidetah5);
                        total += entidadValorTransferencia.VT6 = (CMR[i].CosMar6 * TR[i].Tranretidetah6);
                        total += entidadValorTransferencia.VT7 = (CMR[i].CosMar7 * TR[i].Tranretidetah7);
                        total += entidadValorTransferencia.VT8 = (CMR[i].CosMar8 * TR[i].Tranretidetah8);
                        total += entidadValorTransferencia.VT9 = (CMR[i].CosMar9 * TR[i].Tranretidetah9);
                        total += entidadValorTransferencia.VT10 = (CMR[i].CosMar10 * TR[i].Tranretidetah10);
                        total += entidadValorTransferencia.VT11 = (CMR[i].CosMar11 * TR[i].Tranretidetah11);
                        total += entidadValorTransferencia.VT12 = (CMR[i].CosMar12 * TR[i].Tranretidetah12);
                        total += entidadValorTransferencia.VT13 = (CMR[i].CosMar13 * TR[i].Tranretidetah13);
                        total += entidadValorTransferencia.VT14 = (CMR[i].CosMar14 * TR[i].Tranretidetah14);
                        total += entidadValorTransferencia.VT15 = (CMR[i].CosMar15 * TR[i].Tranretidetah15);
                        total += entidadValorTransferencia.VT16 = (CMR[i].CosMar16 * TR[i].Tranretidetah16);
                        total += entidadValorTransferencia.VT17 = (CMR[i].CosMar17 * TR[i].Tranretidetah17);
                        total += entidadValorTransferencia.VT18 = (CMR[i].CosMar18 * TR[i].Tranretidetah18);
                        total += entidadValorTransferencia.VT19 = (CMR[i].CosMar19 * TR[i].Tranretidetah19);
                        total += entidadValorTransferencia.VT20 = (CMR[i].CosMar20 * TR[i].Tranretidetah20);
                        total += entidadValorTransferencia.VT21 = (CMR[i].CosMar21 * TR[i].Tranretidetah21);
                        total += entidadValorTransferencia.VT22 = (CMR[i].CosMar22 * TR[i].Tranretidetah22);
                        total += entidadValorTransferencia.VT23 = (CMR[i].CosMar23 * TR[i].Tranretidetah23);
                        total += entidadValorTransferencia.VT24 = (CMR[i].CosMar24 * TR[i].Tranretidetah24);
                        total += entidadValorTransferencia.VT25 = (CMR[i].CosMar25 * TR[i].Tranretidetah25);
                        total += entidadValorTransferencia.VT26 = (CMR[i].CosMar26 * TR[i].Tranretidetah26);
                        total += entidadValorTransferencia.VT27 = (CMR[i].CosMar27 * TR[i].Tranretidetah27);
                        total += entidadValorTransferencia.VT28 = (CMR[i].CosMar28 * TR[i].Tranretidetah28);
                        total += entidadValorTransferencia.VT29 = (CMR[i].CosMar29 * TR[i].Tranretidetah29);
                        total += entidadValorTransferencia.VT30 = (CMR[i].CosMar30 * TR[i].Tranretidetah30);
                        total += entidadValorTransferencia.VT31 = (CMR[i].CosMar31 * TR[i].Tranretidetah31);
                        total += entidadValorTransferencia.VT32 = (CMR[i].CosMar32 * TR[i].Tranretidetah32);
                        total += entidadValorTransferencia.VT33 = (CMR[i].CosMar33 * TR[i].Tranretidetah33);
                        total += entidadValorTransferencia.VT34 = (CMR[i].CosMar34 * TR[i].Tranretidetah34);
                        total += entidadValorTransferencia.VT35 = (CMR[i].CosMar35 * TR[i].Tranretidetah35);
                        total += entidadValorTransferencia.VT36 = (CMR[i].CosMar36 * TR[i].Tranretidetah36);
                        total += entidadValorTransferencia.VT37 = (CMR[i].CosMar37 * TR[i].Tranretidetah37);
                        total += entidadValorTransferencia.VT38 = (CMR[i].CosMar38 * TR[i].Tranretidetah38);
                        total += entidadValorTransferencia.VT39 = (CMR[i].CosMar39 * TR[i].Tranretidetah39);
                        total += entidadValorTransferencia.VT40 = (CMR[i].CosMar40 * TR[i].Tranretidetah40);
                        total += entidadValorTransferencia.VT41 = (CMR[i].CosMar41 * TR[i].Tranretidetah41);
                        total += entidadValorTransferencia.VT42 = (CMR[i].CosMar42 * TR[i].Tranretidetah42);
                        total += entidadValorTransferencia.VT43 = (CMR[i].CosMar43 * TR[i].Tranretidetah43);
                        total += entidadValorTransferencia.VT44 = (CMR[i].CosMar44 * TR[i].Tranretidetah44);
                        total += entidadValorTransferencia.VT45 = (CMR[i].CosMar45 * TR[i].Tranretidetah45);
                        total += entidadValorTransferencia.VT46 = (CMR[i].CosMar46 * TR[i].Tranretidetah46);
                        total += entidadValorTransferencia.VT47 = (CMR[i].CosMar47 * TR[i].Tranretidetah47);
                        total += entidadValorTransferencia.VT48 = (CMR[i].CosMar48 * TR[i].Tranretidetah48);
                        total += entidadValorTransferencia.VT49 = (CMR[i].CosMar49 * TR[i].Tranretidetah49);
                        total += entidadValorTransferencia.VT50 = (CMR[i].CosMar50 * TR[i].Tranretidetah50);
                        total += entidadValorTransferencia.VT51 = (CMR[i].CosMar51 * TR[i].Tranretidetah51);
                        total += entidadValorTransferencia.VT52 = (CMR[i].CosMar52 * TR[i].Tranretidetah52);
                        total += entidadValorTransferencia.VT53 = (CMR[i].CosMar53 * TR[i].Tranretidetah53);
                        total += entidadValorTransferencia.VT54 = (CMR[i].CosMar54 * TR[i].Tranretidetah54);
                        total += entidadValorTransferencia.VT55 = (CMR[i].CosMar55 * TR[i].Tranretidetah55);
                        total += entidadValorTransferencia.VT56 = (CMR[i].CosMar56 * TR[i].Tranretidetah56);
                        total += entidadValorTransferencia.VT57 = (CMR[i].CosMar57 * TR[i].Tranretidetah57);
                        total += entidadValorTransferencia.VT58 = (CMR[i].CosMar58 * TR[i].Tranretidetah58);
                        total += entidadValorTransferencia.VT59 = (CMR[i].CosMar59 * TR[i].Tranretidetah59);
                        total += entidadValorTransferencia.VT60 = (CMR[i].CosMar60 * TR[i].Tranretidetah60);
                        total += entidadValorTransferencia.VT61 = (CMR[i].CosMar61 * TR[i].Tranretidetah61);
                        total += entidadValorTransferencia.VT62 = (CMR[i].CosMar62 * TR[i].Tranretidetah62);
                        total += entidadValorTransferencia.VT63 = (CMR[i].CosMar63 * TR[i].Tranretidetah63);
                        total += entidadValorTransferencia.VT64 = (CMR[i].CosMar64 * TR[i].Tranretidetah64);
                        total += entidadValorTransferencia.VT65 = (CMR[i].CosMar65 * TR[i].Tranretidetah65);
                        total += entidadValorTransferencia.VT66 = (CMR[i].CosMar66 * TR[i].Tranretidetah66);
                        total += entidadValorTransferencia.VT67 = (CMR[i].CosMar67 * TR[i].Tranretidetah67);
                        total += entidadValorTransferencia.VT68 = (CMR[i].CosMar68 * TR[i].Tranretidetah68);
                        total += entidadValorTransferencia.VT69 = (CMR[i].CosMar69 * TR[i].Tranretidetah69);
                        total += entidadValorTransferencia.VT70 = (CMR[i].CosMar70 * TR[i].Tranretidetah70);
                        total += entidadValorTransferencia.VT71 = (CMR[i].CosMar71 * TR[i].Tranretidetah71);
                        total += entidadValorTransferencia.VT72 = (CMR[i].CosMar72 * TR[i].Tranretidetah72);
                        total += entidadValorTransferencia.VT73 = (CMR[i].CosMar73 * TR[i].Tranretidetah73);
                        total += entidadValorTransferencia.VT74 = (CMR[i].CosMar74 * TR[i].Tranretidetah74);
                        total += entidadValorTransferencia.VT75 = (CMR[i].CosMar75 * TR[i].Tranretidetah75);
                        total += entidadValorTransferencia.VT76 = (CMR[i].CosMar76 * TR[i].Tranretidetah76);
                        total += entidadValorTransferencia.VT77 = (CMR[i].CosMar77 * TR[i].Tranretidetah77);
                        total += entidadValorTransferencia.VT78 = (CMR[i].CosMar78 * TR[i].Tranretidetah78);
                        total += entidadValorTransferencia.VT79 = (CMR[i].CosMar79 * TR[i].Tranretidetah79);
                        total += entidadValorTransferencia.VT80 = (CMR[i].CosMar80 * TR[i].Tranretidetah80);
                        total += entidadValorTransferencia.VT81 = (CMR[i].CosMar81 * TR[i].Tranretidetah81);
                        total += entidadValorTransferencia.VT82 = (CMR[i].CosMar82 * TR[i].Tranretidetah82);
                        total += entidadValorTransferencia.VT83 = (CMR[i].CosMar83 * TR[i].Tranretidetah83);
                        total += entidadValorTransferencia.VT84 = (CMR[i].CosMar84 * TR[i].Tranretidetah84);
                        total += entidadValorTransferencia.VT85 = (CMR[i].CosMar85 * TR[i].Tranretidetah85);
                        total += entidadValorTransferencia.VT86 = (CMR[i].CosMar86 * TR[i].Tranretidetah86);
                        total += entidadValorTransferencia.VT87 = (CMR[i].CosMar87 * TR[i].Tranretidetah87);
                        total += entidadValorTransferencia.VT88 = (CMR[i].CosMar88 * TR[i].Tranretidetah88);
                        total += entidadValorTransferencia.VT89 = (CMR[i].CosMar89 * TR[i].Tranretidetah89);
                        total += entidadValorTransferencia.VT90 = (CMR[i].CosMar90 * TR[i].Tranretidetah90);
                        total += entidadValorTransferencia.VT91 = (CMR[i].CosMar91 * TR[i].Tranretidetah91);
                        total += entidadValorTransferencia.VT92 = (CMR[i].CosMar92 * TR[i].Tranretidetah92);
                        total += entidadValorTransferencia.VT93 = (CMR[i].CosMar93 * TR[i].Tranretidetah93);
                        total += entidadValorTransferencia.VT94 = (CMR[i].CosMar94 * TR[i].Tranretidetah94);
                        total += entidadValorTransferencia.VT95 = (CMR[i].CosMar95 * TR[i].Tranretidetah95);
                        total += entidadValorTransferencia.VT96 = (CMR[i].CosMar96 * TR[i].Tranretidetah96);
                        entidadValorTransferencia.VTTotalDia = (total);

                        int Grabo = 0;
                        Grabo = new GeneralAppServicioValorTransferencia().SaveValorTransferencia(entidadValorTransferencia);
                    }

                }

                int version1 = 1;


                //ELIMINAR DATOS PREVIAMENTE
                int deletepok = 0;
                deletepok = new GeneralAppServicioValorTransferenciaEmpresa().DeleteValorTransferenciaEmpresa(pericodi, version1);
                //VALOR TRANSFERENCIA EMPRESA

                ValorTransferenciaEmpresaModel objModel = new ValorTransferenciaEmpresaModel();
                ValorTransferenciaModel modelValorTransferenciaModel = new ValorTransferenciaModel();

                //valor transferenciaempresa dto

                ValorTransferenciaEmpresaDTO entidadValorTransferenciaEmpresa = new ValorTransferenciaEmpresaDTO();

                modelValorTransferenciaModel.ListaValorTransferencia = new GeneralAppServicioValorTransferencia().ListValorTransferenciaEmpresaRE(pericodi, version1);


                foreach (var x in modelValorTransferenciaModel.ListaValorTransferencia)
                {

                    entidadValorTransferenciaEmpresa.Empcodi = (int)x.EmpCodi;
                    entidadValorTransferenciaEmpresa.Valtranempversion = x.ValoTranVersion;
                    entidadValorTransferenciaEmpresa.Valtranemptotal = x.VTEmpresaEntrega - x.VTEmpresaRetiro;
                    entidadValorTransferenciaEmpresa.Pericodi = (int)x.PeriCodi;
                    entidadValorTransferenciaEmpresa.Vtraneusername = User.Identity.Name;
                    int graboOk = 0;
                    graboOk = new GeneralAppServicioValorTransferenciaEmpresa().SaveValorTransferenciaEmpresa(entidadValorTransferenciaEmpresa);

                }


                //saldo total
                decimal SumEntrega = 0;
                decimal SumRetiroSO = 0;
                decimal SumRetiroSC = 0;
                decimal SaldoTotal = 0;


                //ELIMINAR PREVIAMENTE DATOS
                int deleteSaldo = 0;
                deleteSaldo = new GeneralAppServicioSaldoEmpresa().DeleteSaldoTransmisionEmpresa(pericodi, version1);
                int deleteSaldoSC = 0;
                deleteSaldoSC = new GeneralAppServicioSaldoCodigoRetiroSC().DeleteSaldoCodigoRetiroSC(pericodi, version1);

                //Obtiene 
                SaldoEmpresaDTO objSaldoEmpresa = new SaldoEmpresaDTO();
                SaldoCodigoRetiroscDTO objCodigoRetiroSC = new SaldoCodigoRetiroscDTO();

                modelValorTransferenciaModel.ListaValorTransferencia = new GeneralAppServicioValorTransferencia().ObtenerTotalEnergiaporEntregaoRetiro(pericodi, version1);

                //0 son entregas
                SumEntrega = modelValorTransferenciaModel.ListaValorTransferencia[0].VTTotalDia;
                //1 son retiros SO
                SumRetiroSO = modelValorTransferenciaModel.ListaValorTransferencia[1].VTTotalDia;
                //3 son retiro SC
                SumRetiroSC = modelValorTransferenciaModel.ListaValorTransferencia[2].VTTotalDia;
                SaldoTotal = -SumEntrega + SumRetiroSO + SumRetiroSC;

                ///Obtener los ingresos potencia de las empresas
                IngresoPotenciaModel modelIP = new IngresoPotenciaModel();


                modelIP.ListaIngresoPotencia = new GeneralAppServicioIngresoPotencia().ListImportesByPeriVer(pericodi, version1);


                //obtiene total


                foreach (var obj in modelIP.ListaIngresoPotencia)
                {

                    objSaldoEmpresa.EMPCODI = obj.EmprCodi;
                    objSaldoEmpresa.SALEMPVERSION = obj.IngrPoteVersion;
                    objSaldoEmpresa.SALEMPSALDO = (SaldoTotal * (Decimal)obj.IngrPoteImporte) / obj.Total;
                    objSaldoEmpresa.PERICODI = obj.PeriCodi;
                    objSaldoEmpresa.SALEMPUSERNAME = User.Identity.Name;

                    int saveok = 0;
                    saveok = new GeneralAppServicioSaldoEmpresa().SaveOrUpdateSaldoTransmisionEmpresa(objSaldoEmpresa);
                }


                //Obtener los ingresos potencia de las empresas Sin Contrato
                IngresoRetiroSCModel modelIPSC = new IngresoRetiroSCModel();
                modelIPSC.ListaIngresoRetiroSC = new GeneralAppServicioIngresoRetiroSC().ListImportesByPeriVer(pericodi,version1);



                foreach (var obj in modelIPSC.ListaIngresoRetiroSC)
                {

                    objCodigoRetiroSC.EMPRCODI = obj.EmprCodi;
                    objCodigoRetiroSC.SALRSCVERSION = obj.Ingrscversion;
                    objCodigoRetiroSC.SALRSCSALDO = (SumRetiroSC * (Decimal)obj.Ingrscimporte) / obj.Total;
                    objCodigoRetiroSC.PERICODI = obj.PeriCodi;
                    objCodigoRetiroSC.SALRSCUSERNAME = User.Identity.Name;

                    int saveok = 0;

                    saveok = new GeneralAppServicioSaldoCodigoRetiroSC().SaveOrUpdateSaldoCodigoRetiroSC(objCodigoRetiroSC);
                }





                //eliminar datos Previamente TotalValorEmpresa
                int deleteTVEmpresa = 0;

                deleteTVEmpresa = new GeneralAppServicioValorTotalEmpresa().DeleteValorTotalEmpresa(pericodi, version1);

                //Declaro entidad
                ValorTotalEmpresaDTO objVTE = new ValorTotalEmpresaDTO();
                //Obtener  valores por empresa
                modelValorTransferenciaModel.ListaValorTransferencia = new GeneralAppServicioValorTransferencia().ObtenerTotalValorEmpresa(pericodi, version1);
                //
                foreach (var obj in modelValorTransferenciaModel.ListaValorTransferencia)
                {


                    objVTE.EMPCODI = (Int32)obj.EmpCodi;
                    objVTE.VALTOTAEMPVERSION = obj.ValoTranVersion;
                    objVTE.VALTOTAEMPTOTAL = obj.Salempsaldo + obj.Compensacion + obj.Valorizacion + obj.Salrscsaldo;
                    objVTE.PERICODI = (Int32)obj.PeriCodi;
                    objVTE.VOTEMUSERNAME = User.Identity.Name;

                    int saveok = 0;
                    saveok = new GeneralAppServicioValorTotalEmpresa().SaveOrUpdateValorTotalEmpresa(objVTE);

                }



                //eliminar empresar pago
                int eliminook = 0;

                eliminook = (new GeneralAppServicioEmpresaPago()).DeleteEmpresaPago(pericodi, version1);

                //Grabar Empresa pago...........
                ValorTotalEmpresaModel objmodel = new ValorTotalEmpresaModel();
                ValorTotalEmpresaModel objmodel2 = new ValorTotalEmpresaModel();
                objmodel.ListaValorTotalEmpresa = (new GeneralAppServicioValorTotalEmpresa()).BuscarEmpresasValorPositivo(pericodi, version1);
                objmodel2.ListaValorTotalEmpresa = (new GeneralAppServicioValorTotalEmpresa()).BuscarEmpresasValorNegativo(pericodi, version1);


                EmpresaPagoDTO objEmpresaPago = new EmpresaPagoDTO();
                foreach (var objPosi in objmodel.ListaValorTotalEmpresa)
                {
                    foreach (var objNega in objmodel2.ListaValorTotalEmpresa)
                    {
                        objEmpresaPago.VALTOTAEMPCODI = objPosi.VALTOTAEMPCODI;
                        objEmpresaPago.EMPCODI = objPosi.EMPCODI;
                        objEmpresaPago.VALTOTAEMPVERSION = objPosi.VALTOTAEMPVERSION;
                        objEmpresaPago.PERICODI = objPosi.PERICODI;
                        objEmpresaPago.EMPPAGOCODEMPPAGO = objNega.EMPCODI;
                        objEmpresaPago.EMPPAGOMONTO = (objNega.VALTOTAEMPTOTAL / objNega.TOTAL) * objPosi.VALTOTAEMPTOTAL;
                        objEmpresaPago.EMPPAGUSERNAME = User.Identity.Name;
                        int graboPagook = 0;

                        graboPagook = (new GeneralAppServicioEmpresaPago()).SaveoUpdateEmpresaPago(objEmpresaPago);

                    }
                }




                return Json(1);
            }
            catch
            {
                return Json(-1);
            }
        }

        //GET
        public ActionResult Edit(int id = 0)
        {
            CentralGeneracionModel modelCentralGene = new CentralGeneracionModel();
            modelCentralGene.ListaCentralGeneracion = (new GeneralAppServicioCentralGeneracion()).ListCentralGeneracion();


            EmpresaModel modelEmp = new EmpresaModel();
            modelEmp.ListaEmpresas = (new GeneralAppServicioEmpresa()).ListEmpresas();

            //BarraTransferenciaModel modelTran = new BarraTransferenciaModel();
            //modelTran.ListaBarraTransferencia = (new GeneralAppServicioBarraTransferencia()).ListBarrasTransferencia();

            BarraModel modelBarr = new BarraModel();
            modelBarr.ListaBarras = (new GeneralAppServicioBarra()).ListBarras();



            CodigoEntregaDTO dto = new CodigoEntregaDTO();
            dto = (new GeneralAppServicioCodigoEntrega()).GetByIdCodigoEntra(id);


            TempData["CENTGENECODI2"] = new SelectList(modelCentralGene.ListaCentralGeneracion, "CENTGENECODI", "CENTGENENOMBRE", dto.Centgenecodi);

            TempData["EMPRCODI2"] = new SelectList(modelEmp.ListaEmpresas, "EMPRCODI", "EMPRNOMBRE", dto.Emprcodi);


            if (dto == null)
            {
                return HttpNotFound();
            }
            TempData["BARRCODI2"] = new SelectList(modelBarr.ListaBarras, "BARRCODI", "BARRNOMBBARRTRAN", dto.Barrcodi);


            return View(dto);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string Delete(int id = 0)
        {
            ValorTransferenciaModel model = new ValorTransferenciaModel();
            model.IdValorTransferencia = (new GeneralAppServicioValorTransferencia()).DeleteListaValorTransferencia(id, id);
            return "true";
        }



        //Metodo para el informe preliminar

        //POST
        [HttpPost]
        public ActionResult ListaInfo(int pericodi)
        {


            int version = 1;
            InformePreliminarModel model = new InformePreliminarModel();
            model.ListaInformePreliminar = (new GeneralAppServicioInformePreliminar()).ListInformeByPeriVer(pericodi, version);
            TempData["DataInforme"] = model.ListaInformePreliminar;
            return PartialView(model);
        }


        [HttpPost]
        public JsonResult GenerarExcel()
        {
            int indicador = 1;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;
                //Ejemplo.GenerarReporteExcel(path);

                InformePreliminarDTO dto = new InformePreliminarDTO();
                InformePreliminarModel model = new InformePreliminarModel();
                List<InformePreliminarDTO> arr = new List<InformePreliminarDTO>();
                arr = (List<InformePreliminarDTO>)TempData["DataInforme"];

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaInformePreliminarExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteInformePreliminarExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteInformePreliminarExcel);
                }

                int row = 4;
                int row2 = 3;
                int colum = 2;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];

                    foreach (var item in arr)
                    {


                        ws.Cells[row, 2].Value = (item.NombEmp != null) ? item.NombEmp.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.Valorizacion != null) ? item.Valorizacion.ToString() : string.Empty;
                        ws.Cells[row, 4].Value = (item.Compensacion != null) ? item.Compensacion.ToString() : string.Empty;
                        ws.Cells[row, 5].Value = (item.IngresoPotencia != null) ? item.IngresoPotencia.ToString() : string.Empty;
                        ws.Cells[row, 6].Value = (item.SaldoTransmision != null) ? item.SaldoTransmision.ToString() : string.Empty;
                        ws.Cells[row, 7].Value = (item.ValorTotalEmp != null) ? item.ValorTotalEmp.ToString() : string.Empty;
                        row++;

                    }



                    xlPackage.Save();
                }
                indicador = 1;
            }
            catch
            {
                indicador = -1;
            }
            return Json(indicador);
        }

        [HttpGet]
        public virtual ActionResult AbrirExcel()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteInformePreliminarExcel;
            return File(path, Funcion.AppExcel, Funcion.NombreReporteInformePreliminarExcel);
        }


        [HttpPost]
        public JsonResult GenerarExcel1(string sPericodi)
        {
            int indicador = 1;
            int pericodi = Int32.Parse(sPericodi);
            //int periodo = 1;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;
                string sFecha = DateTime.Now.ToString("yyyyMMddHHmmss"); ;

                ValorTransferenciaModel model = new ValorTransferenciaModel();
                model.ListaValorTransferencia = (new GeneralAppServicioValorTransferencia()).ListarBalance(pericodi);

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaBalanceEnergiaExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteBalanceEnergiaExcel);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteBalanceEnergiaExcel);
                }

                int row = 4;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];

                    foreach (var item in model.ListaValorTransferencia)
                    {
                        ws.Cells[row, 2].Value = (item.nombEmpresa != null) ? item.nombEmpresa.ToString() : string.Empty;
                        //ws.Cells[row, 3].Value = (item.EmpCodi != null) ? item.EmpCodi.ToString() : string.Empty;
                        //ws.Cells[row, 4].Value = (item.PeriCodi != null) ? item.PeriCodi.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.entregas != null) ? item.entregas.ToString() : string.Empty;
                        ws.Cells[row, 4].Value = (item.retiros != null) ? item.retiros.ToString() : string.Empty;
                        ws.Cells[row, 5].Value = (item.neto != null) ? item.neto.ToString() : string.Empty;

                        row++;
                    }
                    xlPackage.Save();
                }
                indicador = 1;
            }
            catch
            {
                indicador = -1;
            }

            return Json(indicador);
        }

        [HttpGet]
        public virtual ActionResult AbrirExcel1()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteBalanceEnergiaExcel;
            return File(path, Constantes.AppExcel, Funcion.NombreReporteBalanceEnergiaExcel);
        }


        [HttpPost]
        public JsonResult GenerarExcelCuadro(int pericodigo)
        {
            int indicador = 1;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;
                //Ejemplo.GenerarReporteExcel(path);

                int version = 1;
                InformePreliminarDTO dto = new InformePreliminarDTO();



                ExportExcelModel model = new ExportExcelModel();
                model.ListaExportExcel = (new GeneralAppServicioExportarExcelG()).BuscarValoresParaCuadro(pericodigo, version); //int pericodi, string barrcodi
                ExportExcelModel model2 = new ExportExcelModel();

                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaCuadroExcel);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteCuadro);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteCuadro);
                }

                int row = 4;

                int row2 = 3;
                int colum = 2;
                int c = 0;
                int b = 0;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];
                    for (int i = 0; i < model.ListaExportExcel.Count(); i++)
                    {

                        c = 5;
                        model2.ListaExportExcel = (new GeneralAppServicioExportarExcelG()).BuscarCompensacion(model.ListaExportExcel[0].EMPRCODI, model.ListaExportExcel[0].Pericodi, model.ListaExportExcel[0].Vtranversion); //int pericodi, string barrcodi
                        foreach (var item2 in model2.ListaExportExcel)
                        {
                            ws.Cells[3, c].Value = (item2.CabComnombre != null) ? item2.CabComnombre.ToString() : string.Empty;
                            c++;

                        }
                        ws.Cells[3, c].Value = "TOTAL EMPRESA";



                    }

                    foreach (var item in model.ListaExportExcel)
                    {
                        b = 5;

                        ws.Cells[row, 2].Value = (item.Emprnomb != null) ? item.Emprnomb.ToString() : string.Empty;
                        ws.Cells[row, 3].Value = (item.ValorizacionTransferencia != null) ? item.ValorizacionTransferencia.ToString() : string.Empty;
                        ws.Cells[row, 4].Value = (item.SaldoTransmision != null) ? item.SaldoTransmision.ToString() : string.Empty;

                        model2.ListaExportExcel = (new GeneralAppServicioExportarExcelG()).BuscarCompensacion(item.EMPRCODI, item.Pericodi, item.Vtranversion); //int pericodi, string barrcodi
                        foreach (var item2 in model2.ListaExportExcel)
                        {
                            ws.Cells[row, b].Value = (item.IngComImporte != null) ? item.Compensacion.ToString() : string.Empty;
                            b++;

                        }
                        ws.Cells[row, b].Value = (item.TotalEmp != null) ? item.TotalEmp.ToString() : string.Empty;

                        row++;

                    }



                    xlPackage.Save();
                }
                indicador = 1;
            }
            catch
            {
                indicador = -1;
            }
            return Json(indicador);
        }

        [HttpGet]
        public virtual ActionResult AbrirExcelCuadro()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteCuadro;
            return File(path, Funcion.AppExcel, Funcion.NombreReporteCuadro);
        }

        [HttpPost]
        public JsonResult GenerarExcelMatriz(int pericodigo)
        {
            int indicador = 1;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte;
                //Ejemplo.GenerarReporteExcel(path);
                int version = 1;
                EmpresaPagoModel model = new EmpresaPagoModel();
                model.ListaEmpresasPago = (new GeneralAppServicioExportarExcelG()).BuscarEmpresasPagMatriz(pericodigo, version); //int pericodi, string barrcodi
                EmpresaPagoModel model2 = new EmpresaPagoModel();



                FileInfo template = new FileInfo(path + Funcion.NombrePlantillaMatriz);
                FileInfo newFile = new FileInfo(path + Funcion.NombreReporteMatriz);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(path + Funcion.NombreReporteMatriz);
                }

                int row = 4;
                int row2 = 3;
                int colum = 3;
                int a = 0;
                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets[Funcion.HojaReporteExcel];




                    for (int i = 0; i < model.ListaEmpresasPago.Count(); i++)
                    {

                        if (i == 0)
                        {
                            model2.ListaEmpresasPago = (new GeneralAppServicioExportarExcelG()).BuscarPagosMatriz(
                                model.ListaEmpresasPago[0].EMPCODI, pericodigo, version); //int pericodi, string barrcodi
                            foreach (var item2 in model2.ListaEmpresasPago)
                            {
                                ws.Cells[3, colum].Value = (item2.EMPRNOMBPAGO != null) ? item2.EMPRNOMBPAGO.ToString() : string.Empty;
                                colum++;

                            }


                        }

                    }


                    foreach (var item in model.ListaEmpresasPago)
                    {


                        ws.Cells[row, 2].Value = (item.EMPRNOMB != null) ? item.EMPRNOMB.ToString() : string.Empty;
                        model2.ListaEmpresasPago = (new GeneralAppServicioExportarExcelG()).BuscarPagosMatriz(item.EMPCODI, pericodigo, version);
                        colum = 3;
                        foreach (var item2 in model2.ListaEmpresasPago)
                        {
                            ws.Cells[row, colum].Value = (item2.EMPPAGOMONTO != null) ? item.EMPPAGOMONTO.ToString() : string.Empty;
                            colum++;
                        }

                        row++;

                    }




                    xlPackage.Save();
                }
                indicador = 1;
            }
            catch
            {
                indicador = -1;
            }
            return Json(indicador);
        }

        [HttpGet]
        public virtual ActionResult AbrirExcelMatriz()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Funcion.RutaReporte + Funcion.NombreReporteMatriz;
            return File(path, Funcion.AppExcel, Funcion.NombreReporteMatriz);
        }

    }
}
