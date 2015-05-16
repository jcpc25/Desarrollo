using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using System.Linq;
using log4net;
using System.Text;
using System.IO;
using OfficeOpenXml;
using System.Net;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.Drawing;
namespace COES.Servicios.Aplicacion.Mediciones
{
    public class ReporteMedidoresAppServicio: AppServicioBase
    {
        ExcelPackage xlPackage = null;

        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ReporteMedidoresAppServicio));

        /// <summary>
        /// Lista los tipos de generación
        /// </summary>
        /// <returns></returns>
        public List<SiTipogeneracionDTO> ListaTipoGeneracion()
        {
            return FactorySic.GetSiTipogeneracionRepository().GetByCriteria().Where(x => x.Tgenercodi != -1 && x.Tgenercodi != 0 && x.Tgenercodi != 5).ToList();
        }

        /// <summary>
        /// Lista las fuentes de energía
        /// </summary>
        /// <returns></returns>
        public List<SiFuenteenergiaDTO> ListaFuenteEnergia(int idTipoGeneracion)
        {
            return FactorySic.GetSiFuenteenergiaRepository().GetByCriteria().Where(x => x.Fenergcodi != -1 
                && x.Fenergcodi != 0 && (x.Tgenercodi == idTipoGeneracion || idTipoGeneracion == 0)).ToList();
        }

        /// <summary>
        /// Permite listar los tipos de empresas
        /// </summary>
        /// <returns></returns>
        public List<SiTipoempresaDTO> ListaTipoEmpresas()
        {
            return FactorySic.GetSiTipoempresaRepository().List();
        }

        /// <summary>
        /// Permite listar las empresas
        /// </summary>
        /// <returns></returns>
        public List<SiEmpresaDTO> ListaEmpresa()
        {
            return FactorySic.GetSiEmpresaRepository().ObtenerEmpresasSEIN();
        }

        /// <summary>
        /// Permite obtener las empresa por tipo
        /// </summary>
        /// <returns></returns>
        public List<SiEmpresaDTO> ObteneEmpresasPorTipo(string tiposEmpresa)
        {
            if (string.IsNullOrEmpty(tiposEmpresa)) tiposEmpresa = Constantes.ParametroDefecto;
            return FactorySic.GetSiEmpresaRepository().GetByCriteria(tiposEmpresa);
        }

        /// <summary>
        /// Permite generar el reporte resumen de medidores
        /// </summary>
        /// <param name="fechaInicial"></param>
        /// <param name="fechaFinal"></param>
        /// <param name="empresas"></param>
        /// <param name="tiposGeneracion"></param>
        /// <param name="fuentesEnergia"></param>
        /// <param name="central"></param>
        /// <param name="indAdjudicado"></param>
        public void ObtenerReporteMedidores(DateTime fechaInicial, DateTime fechaFinal, string tiposEmpresa, string empresas,
            string tiposGeneracion, string fuentesEnergia, int central, out List<MedicionReporteDTO> listCuadros,
            out MedicionReporteDTO datosReporte, out List<MedicionReporteDTO> reporteFE, out List<MeMedicion96DTO> reporteEmpresas, out List<MedicionReporteDTO> reporteTG)
        {
            if (!string.IsNullOrEmpty(tiposGeneracion))
            {
                if (!string.IsNullOrEmpty(fuentesEnergia))
                {
                    if (tiposGeneracion != Constantes.ParametroDefecto && fuentesEnergia != Constantes.ParametroDefecto)
                    {
                        List<SiFuenteenergiaDTO> listFuente = this.ListaFuenteEnergia(0);
                        List<int> tipos = (tiposGeneracion.Split(Constantes.CaracterComa)).Select(n => int.Parse(n)).ToList();
                        List<int> ids = listFuente.Where(x => tipos.Any(y => x.Tgenercodi == y)).Select(x => x.Fenergcodi).ToList();
                        List<int> fuentes = (fuentesEnergia.Split(Constantes.CaracterComa)).Select(n => int.Parse(n)).ToList();
                        List<int> permitidos = fuentes.Where(x => ids.Any(y => x == y)).ToList();
                        fuentesEnergia = string.Join<int>(Constantes.CaracterComa.ToString(), permitidos);

                        if (string.IsNullOrEmpty(fuentesEnergia)) fuentesEnergia = Constantes.ParametroNoExiste;
                    }
                    else
                    {
                        if (tiposGeneracion != Constantes.ParametroDefecto)
                        {
                            List<SiFuenteenergiaDTO> listFuente = this.ListaFuenteEnergia(0);
                            List<int> tipos = (tiposGeneracion.Split(Constantes.CaracterComa)).Select(n => int.Parse(n)).ToList();
                            List<int> ids = listFuente.Where(x => tipos.Any(y => x.Tgenercodi == y)).Select(x => x.Fenergcodi).ToList();
                            fuentesEnergia = string.Join<int>(Constantes.CaracterComa.ToString(), ids);

                            if (string.IsNullOrEmpty(fuentesEnergia)) fuentesEnergia = Constantes.ParametroNoExiste;
                        }
                        
                    }
                }               
            }

            if (tiposEmpresa != Constantes.ParametroDefecto && empresas == Constantes.ParametroDefecto)
            {
                List<int> idsEmpresas = this.ObteneEmpresasPorTipo(tiposEmpresa).Select(x => x.Emprcodi).ToList();
                empresas = string.Join<int>(Constantes.CaracterComa.ToString(), idsEmpresas);
            }

            List<MeMedicion96DTO> listDemanda = FactorySic.GetMeMedicion96Repository().ObtenerDatosReporteMD(empresas,
                central, fuentesEnergia, fechaInicial, fechaFinal);
            MedicionReporteDTO umbrales = this.ObtenerParametros(listDemanda);

            datosReporte = umbrales;

            List<MeMedicion96DTO> list = FactorySic.GetMeMedicion96Repository().ObtenerReporteMedidores(empresas,
                central, fuentesEnergia, fechaInicial, fechaFinal);

            var listEmpresas = list.Select(x => new { x.Emprcodi, x.Emprnomb }).Distinct().OrderBy(x => x.Emprnomb).ToList();
            var listCentrales = list.Select(x => new { x.Emprcodi, x.Central }).Distinct().ToList();
            var listEquipos = list.Select(x => new
            {
                x.Emprcodi,                
                x.Central,
                x.Equicodi,
                x.Equinomb,
                x.Tgenernomb,
                x.Tgenercodi,
                x.Fenergcodi,
                x.Fenergnomb
            }).Distinct().ToList();

            #region Armado de cuadros

            List<MedicionReporteDTO> resultado = new List<MedicionReporteDTO>();

            int i = 1;
            decimal sumTotal = 0;
            decimal maxTotal = 0;
            decimal minTotal = 0;

            decimal solarTotal = 0;
            decimal eolicaTotal = 0;
            decimal hidraulicaTotal = 0;
            decimal termicoTotal = 0;

            foreach (var itemEmpresa in listEmpresas)
            {
                var subCentral = listCentrales.Where(x => x.Emprcodi == itemEmpresa.Emprcodi).ToList();

                decimal sumEmpresa = 0;
                decimal maxEmpresa = 0;
                decimal minEmpresa = 0;

                decimal solarEmpresa = 0;
                decimal eolicaEmpresa = 0;
                decimal hidraulicaEmpresa = 0;
                decimal termicoEmpresa = 0;

                foreach (var itemCentral in subCentral)
                {

                    var subEquipo = 
                        listEquipos.Where(x => x.Central == itemCentral.Central && x.Emprcodi == itemCentral.Emprcodi).ToList();


                    foreach (var itemEquipo in subEquipo)
                    {
                        MedicionReporteDTO resultadoEquipo = new MedicionReporteDTO();

                        resultadoEquipo.NroItem = i;
                        resultadoEquipo.Emprnomb = itemEmpresa.Emprnomb;
                        resultadoEquipo.Central = itemCentral.Central;
                        resultadoEquipo.Unidad = itemEquipo.Equinomb;
                        resultadoEquipo.Fenergcodi = itemEquipo.Fenergcodi;
                        resultadoEquipo.Fenergnomb = itemEquipo.Fenergnomb;
                        resultadoEquipo.Tgenercodi = itemEquipo.Tgenercodi;
                        resultadoEquipo.Tgenernomb = itemEquipo.Tgenernomb;
                        resultadoEquipo.IndicadorTotal = false;
                        resultadoEquipo.IndicadorTotalGeneral = false;
                        

                        MeMedicion96DTO unidadMaxima = list.Where(x => x.Equicodi == itemEquipo.Equicodi && x.Medifecha == umbrales.FechaMaximaDemanda).FirstOrDefault();
                        MeMedicion96DTO unidadMinima = list.Where(x => x.Equicodi == itemEquipo.Equicodi && x.Medifecha == umbrales.FechaMinimaDemanda).FirstOrDefault();
                                                                     
                        decimal energiaUnidad = 0;
                        decimal maximaUnidad = 0;
                        decimal minimaUnidad = 0;
                        decimal valorUnidad = 0;

                        object subTotal = list.Where(x => x.Equicodi == itemEquipo.Equicodi).Sum(x => x.Meditotal);
                        if (subTotal != null)
                        {
                            energiaUnidad = energiaUnidad + Convert.ToDecimal(subTotal);
                        }

                        if (unidadMaxima != null)
                        {
                            for (int k = 1; k <= 96; k++)
                            {
                                object result = unidadMaxima.GetType().GetProperty(Constantes.CaracterH + k).GetValue(unidadMaxima, null);
                                if (result != null)
                                {
                                    valorUnidad = Convert.ToDecimal(result);

                                    if (k == umbrales.HoraMaximaDemanda)
                                    {
                                        maximaUnidad = valorUnidad;
                                    }

                                }
                            }
                        }

                        if (unidadMinima != null)
                        {
                            for (int k = 1; k <= 96; k++)
                            {
                                object result = unidadMinima.GetType().GetProperty(Constantes.CaracterH + k).GetValue(unidadMinima, null);
                                if (result != null)
                                {
                                    valorUnidad = Convert.ToDecimal(result);

                                    if (k == umbrales.HoraMinimaDemanda)
                                    {
                                        minimaUnidad = valorUnidad;
                                    }
                                }
                            }
                        }


                        resultadoEquipo.Total = (energiaUnidad != 0) ? energiaUnidad / 4 : 0;
                        resultadoEquipo.MaximaDemanda = maximaUnidad;
                        resultadoEquipo.MinimaDemanda = minimaUnidad;

                        sumEmpresa = sumEmpresa + resultadoEquipo.Total;
                        maxEmpresa = maxEmpresa + resultadoEquipo.MaximaDemanda;
                        minEmpresa = minEmpresa + resultadoEquipo.MinimaDemanda;

                        if (itemEquipo.Tgenercodi == 1)
                        {
                            resultadoEquipo.Hidraulico = resultadoEquipo.Total;
                            hidraulicaEmpresa = hidraulicaEmpresa + resultadoEquipo.Total;
                        }
                        else if (itemEquipo.Tgenercodi == 2)
                        {
                            resultadoEquipo.Termico = resultadoEquipo.Total;
                            termicoEmpresa = termicoEmpresa + resultadoEquipo.Total;
                        }
                        else if (itemEquipo.Tgenercodi == 3)
                        {
                            resultadoEquipo.Solar = resultadoEquipo.Total;
                            solarEmpresa = solarEmpresa + resultadoEquipo.Total;
                        }
                        else if (itemEquipo.Tgenercodi == 4)
                        {
                            resultadoEquipo.Eolico = resultadoEquipo.Total;
                            eolicaEmpresa = eolicaEmpresa + resultadoEquipo.Total;
                        }

                        resultado.Add(resultadoEquipo);
                        i++;
                       
                    }
                }

                sumTotal = sumTotal + sumEmpresa;
                maxTotal = maxTotal + maxEmpresa;
                minTotal = minTotal + minEmpresa;

                solarTotal = solarTotal + solarEmpresa;
                termicoTotal = termicoTotal + termicoEmpresa;
                hidraulicaTotal = hidraulicaTotal + hidraulicaEmpresa;
                eolicaTotal = eolicaTotal + eolicaEmpresa;


                MedicionReporteDTO resultadoEmpresa = new MedicionReporteDTO();
                resultadoEmpresa.IndicadorTotal = true;
                resultadoEmpresa.Emprnomb = itemEmpresa.Emprnomb;
                resultadoEmpresa.Total = sumEmpresa;
                resultadoEmpresa.MaximaDemanda = maxEmpresa;
                resultadoEmpresa.MinimaDemanda = minEmpresa;
                resultadoEmpresa.Solar = solarEmpresa;
                resultadoEmpresa.Eolico = eolicaEmpresa;
                resultadoEmpresa.Termico = termicoEmpresa;
                resultadoEmpresa.Hidraulico = hidraulicaEmpresa;
                resultado.Add(resultadoEmpresa);
            }

            MedicionReporteDTO resultadoTotal = new MedicionReporteDTO();
            resultadoTotal.IndicadorTotalGeneral = true;
            resultadoTotal.Total = sumTotal;
            resultadoTotal.MaximaDemanda = maxTotal;
            resultadoTotal.MinimaDemanda = minTotal;
            resultadoTotal.Solar = solarTotal;
            resultadoTotal.Hidraulico = hidraulicaTotal;
            resultadoTotal.Termico = termicoTotal;
            resultadoTotal.Eolico = eolicaTotal;
            resultado.Add(resultadoTotal);

            listCuadros = resultado;

            #endregion

            List<MeMedicion96DTO> listTipoRecurso = list.Where(x => x.Medifecha == umbrales.FechaMaximaDemanda).ToList();
            int indice = umbrales.HoraMaximaDemanda;
            
            List<MeMedicion96DTO> listFuenteGeneracion = new List<MeMedicion96DTO>();

            #region Fuente Generacion

            listFuenteGeneracion = (from t in listTipoRecurso
                              group t by new { t.Fenergcodi, t.Fenergnomb }
                                  into destino
                                  select new MeMedicion96DTO()
                                  {
                                      Fenergcodi = destino.Key.Fenergcodi,
                                      Fenergnomb = destino.Key.Fenergnomb,
                                      H1 = destino.Sum(t => t.H1),
                                      H2 = destino.Sum(t => t.H2),
                                      H3 = destino.Sum(t => t.H3),
                                      H4 = destino.Sum(t => t.H4),
                                      H5 = destino.Sum(t => t.H5),
                                      H6 = destino.Sum(t => t.H6),
                                      H7 = destino.Sum(t => t.H7),
                                      H8 = destino.Sum(t => t.H8),
                                      H9 = destino.Sum(t => t.H9),
                                      H10 = destino.Sum(t => t.H10),

                                      H11 = destino.Sum(t => t.H11),
                                      H12 = destino.Sum(t => t.H12),
                                      H13 = destino.Sum(t => t.H13),
                                      H14 = destino.Sum(t => t.H14),
                                      H15 = destino.Sum(t => t.H15),
                                      H16 = destino.Sum(t => t.H16),
                                      H17 = destino.Sum(t => t.H17),
                                      H18 = destino.Sum(t => t.H18),
                                      H19 = destino.Sum(t => t.H19),
                                      H20 = destino.Sum(t => t.H20),

                                      H21 = destino.Sum(t => t.H21),
                                      H22 = destino.Sum(t => t.H22),
                                      H23 = destino.Sum(t => t.H23),
                                      H24 = destino.Sum(t => t.H24),
                                      H25 = destino.Sum(t => t.H25),
                                      H26 = destino.Sum(t => t.H26),
                                      H27 = destino.Sum(t => t.H27),
                                      H28 = destino.Sum(t => t.H28),
                                      H29 = destino.Sum(t => t.H29),
                                      H30 = destino.Sum(t => t.H30),

                                      H31 = destino.Sum(t => t.H31),
                                      H32 = destino.Sum(t => t.H32),
                                      H33 = destino.Sum(t => t.H33),
                                      H34 = destino.Sum(t => t.H34),
                                      H35 = destino.Sum(t => t.H35),
                                      H36 = destino.Sum(t => t.H36),
                                      H37 = destino.Sum(t => t.H37),
                                      H38 = destino.Sum(t => t.H38),
                                      H39 = destino.Sum(t => t.H39),
                                      H40 = destino.Sum(t => t.H40),

                                      H41 = destino.Sum(t => t.H41),
                                      H42 = destino.Sum(t => t.H42),
                                      H43 = destino.Sum(t => t.H43),
                                      H44 = destino.Sum(t => t.H44),
                                      H45 = destino.Sum(t => t.H45),
                                      H46 = destino.Sum(t => t.H46),
                                      H47 = destino.Sum(t => t.H47),
                                      H48 = destino.Sum(t => t.H48),
                                      H49 = destino.Sum(t => t.H49),
                                      H50 = destino.Sum(t => t.H50),


                                      H51 = destino.Sum(t => t.H51),
                                      H52 = destino.Sum(t => t.H52),
                                      H53 = destino.Sum(t => t.H53),
                                      H54 = destino.Sum(t => t.H54),
                                      H55 = destino.Sum(t => t.H55),
                                      H56 = destino.Sum(t => t.H56),
                                      H57 = destino.Sum(t => t.H57),
                                      H58 = destino.Sum(t => t.H58),
                                      H59 = destino.Sum(t => t.H59),
                                      H60 = destino.Sum(t => t.H60),

                                      H61 = destino.Sum(t => t.H61),
                                      H62 = destino.Sum(t => t.H62),
                                      H63 = destino.Sum(t => t.H63),
                                      H64 = destino.Sum(t => t.H64),
                                      H65 = destino.Sum(t => t.H65),
                                      H66 = destino.Sum(t => t.H66),
                                      H67 = destino.Sum(t => t.H67),
                                      H68 = destino.Sum(t => t.H68),
                                      H69 = destino.Sum(t => t.H69),
                                      H70 = destino.Sum(t => t.H70),

                                      H71 = destino.Sum(t => t.H71),
                                      H72 = destino.Sum(t => t.H72),
                                      H73 = destino.Sum(t => t.H73),
                                      H74 = destino.Sum(t => t.H74),
                                      H75 = destino.Sum(t => t.H75),
                                      H76 = destino.Sum(t => t.H76),
                                      H77 = destino.Sum(t => t.H77),
                                      H78 = destino.Sum(t => t.H78),
                                      H79 = destino.Sum(t => t.H79),
                                      H80 = destino.Sum(t => t.H80),

                                      H81 = destino.Sum(t => t.H81),
                                      H82 = destino.Sum(t => t.H82),
                                      H83 = destino.Sum(t => t.H83),
                                      H84 = destino.Sum(t => t.H84),
                                      H85 = destino.Sum(t => t.H85),
                                      H86 = destino.Sum(t => t.H86),
                                      H87 = destino.Sum(t => t.H87),
                                      H88 = destino.Sum(t => t.H88),
                                      H89 = destino.Sum(t => t.H89),
                                      H90 = destino.Sum(t => t.H90),

                                      H91 = destino.Sum(t => t.H91),
                                      H92 = destino.Sum(t => t.H92),
                                      H93 = destino.Sum(t => t.H93),
                                      H94 = destino.Sum(t => t.H94),
                                      H95 = destino.Sum(t => t.H95),
                                      H96 = destino.Sum(t => t.H96)

                                  }).ToList();

            #endregion

            List<MedicionReporteDTO> resultadoFE = new List<MedicionReporteDTO>();

            decimal totalMDFuenteEnergia = 0;
            decimal totalEnergiaFuenteEnergia = 0;

            foreach (MeMedicion96DTO item in listFuenteGeneracion)
            {
                MedicionReporteDTO itemFE = new MedicionReporteDTO();
                itemFE.Fenergnomb = item.Fenergnomb;

                if (indice >= 1 && indice <= 96)
                {
                    object result = item.GetType().GetProperty(Constantes.CaracterH + indice).GetValue(item, null);
                    itemFE.MDFuenteEnergia = (result != null) ? Convert.ToDecimal(result) : 0;
                    totalMDFuenteEnergia = totalMDFuenteEnergia + itemFE.MDFuenteEnergia;
                }

                object totFuente = list.Where(x=>x.Fenergcodi == item.Fenergcodi).Sum(x=>x.Meditotal);

                if(totFuente!=null)
                {
                    itemFE.EnergiaFuenteEnergia = Convert.ToDecimal(totFuente) / 4.0M;
                    totalEnergiaFuenteEnergia = totalEnergiaFuenteEnergia + itemFE.EnergiaFuenteEnergia;
                }               

                resultadoFE.Add(itemFE);                
            }

            List<SiFuenteenergiaDTO> listTotFuente = this.ListaFuenteEnergia(0);
            List<SiFuenteenergiaDTO> listTotFuenteFalta = listTotFuente.Where(x => !listFuenteGeneracion.Any(y => y.Fenergcodi == x.Fenergcodi)).ToList();

            foreach (SiFuenteenergiaDTO item in listTotFuenteFalta)
            {
                MedicionReporteDTO itemFE = new MedicionReporteDTO();
                itemFE.Fenergnomb = item.Fenergnomb;
                itemFE.MDFuenteEnergia = 0;
                object totFuente = list.Where(x => x.Fenergcodi == item.Fenergcodi).Sum(x => x.Meditotal);
                if (totFuente != null)
                {
                    itemFE.EnergiaFuenteEnergia = Convert.ToDecimal(totFuente) / 4.0M;
                    totalEnergiaFuenteEnergia = totalEnergiaFuenteEnergia + itemFE.EnergiaFuenteEnergia;
                }
                resultadoFE.Add(itemFE);
            }



            MedicionReporteDTO finalFE = new MedicionReporteDTO();
            finalFE.EnergiaFuenteEnergia = totalEnergiaFuenteEnergia;
            finalFE.MDFuenteEnergia = totalMDFuenteEnergia;
            finalFE.IndicadorTotal = true;
            resultadoFE.Add(finalFE);
                       
            reporteFE = resultadoFE;


            List<MeMedicion96DTO> listEmpresa = new List<MeMedicion96DTO>();
            listEmpresa = (from t in list
                           group t by new { t.Emprcodi, t.Emprnomb, t.Tgenercodi, t.Tgenernomb }
                               into destino
                               select new MeMedicion96DTO()
                               {
                                   Emprcodi = destino.Key.Emprcodi,
                                   Emprnomb = destino.Key.Emprnomb,
                                   Tgenercodi = destino.Key.Tgenercodi,
                                   Tgenernomb = destino.Key.Tgenernomb,
                                   Meditotal = destino.Sum(t => t.Meditotal)/4.0M
                               }).ToList();

            reporteEmpresas = listEmpresa;


             List<MeMedicion96DTO> listTipoGeneracion = new List<MeMedicion96DTO>();

             listTipoGeneracion = (from t in listTipoRecurso
                              group t by new { t.Tgenercodi, t.Tgenernomb }
                                  into destino
                                  select new MeMedicion96DTO()
                                  {
                                      Tgenercodi = destino.Key.Tgenercodi,
                                      Tgenernomb = destino.Key.Tgenernomb,
                                      H1 = destino.Sum(t => t.H1),
                                      H2 = destino.Sum(t => t.H2),
                                      H3 = destino.Sum(t => t.H3),
                                      H4 = destino.Sum(t => t.H4),
                                      H5 = destino.Sum(t => t.H5),
                                      H6 = destino.Sum(t => t.H6),
                                      H7 = destino.Sum(t => t.H7),
                                      H8 = destino.Sum(t => t.H8),
                                      H9 = destino.Sum(t => t.H9),
                                      H10 = destino.Sum(t => t.H10),

                                      H11 = destino.Sum(t => t.H11),
                                      H12 = destino.Sum(t => t.H12),
                                      H13 = destino.Sum(t => t.H13),
                                      H14 = destino.Sum(t => t.H14),
                                      H15 = destino.Sum(t => t.H15),
                                      H16 = destino.Sum(t => t.H16),
                                      H17 = destino.Sum(t => t.H17),
                                      H18 = destino.Sum(t => t.H18),
                                      H19 = destino.Sum(t => t.H19),
                                      H20 = destino.Sum(t => t.H20),

                                      H21 = destino.Sum(t => t.H21),
                                      H22 = destino.Sum(t => t.H22),
                                      H23 = destino.Sum(t => t.H23),
                                      H24 = destino.Sum(t => t.H24),
                                      H25 = destino.Sum(t => t.H25),
                                      H26 = destino.Sum(t => t.H26),
                                      H27 = destino.Sum(t => t.H27),
                                      H28 = destino.Sum(t => t.H28),
                                      H29 = destino.Sum(t => t.H29),
                                      H30 = destino.Sum(t => t.H30),

                                      H31 = destino.Sum(t => t.H31),
                                      H32 = destino.Sum(t => t.H32),
                                      H33 = destino.Sum(t => t.H33),
                                      H34 = destino.Sum(t => t.H34),
                                      H35 = destino.Sum(t => t.H35),
                                      H36 = destino.Sum(t => t.H36),
                                      H37 = destino.Sum(t => t.H37),
                                      H38 = destino.Sum(t => t.H38),
                                      H39 = destino.Sum(t => t.H39),
                                      H40 = destino.Sum(t => t.H40),

                                      H41 = destino.Sum(t => t.H41),
                                      H42 = destino.Sum(t => t.H42),
                                      H43 = destino.Sum(t => t.H43),
                                      H44 = destino.Sum(t => t.H44),
                                      H45 = destino.Sum(t => t.H45),
                                      H46 = destino.Sum(t => t.H46),
                                      H47 = destino.Sum(t => t.H47),
                                      H48 = destino.Sum(t => t.H48),
                                      H49 = destino.Sum(t => t.H49),
                                      H50 = destino.Sum(t => t.H50),


                                      H51 = destino.Sum(t => t.H51),
                                      H52 = destino.Sum(t => t.H52),
                                      H53 = destino.Sum(t => t.H53),
                                      H54 = destino.Sum(t => t.H54),
                                      H55 = destino.Sum(t => t.H55),
                                      H56 = destino.Sum(t => t.H56),
                                      H57 = destino.Sum(t => t.H57),
                                      H58 = destino.Sum(t => t.H58),
                                      H59 = destino.Sum(t => t.H59),
                                      H60 = destino.Sum(t => t.H60),

                                      H61 = destino.Sum(t => t.H61),
                                      H62 = destino.Sum(t => t.H62),
                                      H63 = destino.Sum(t => t.H63),
                                      H64 = destino.Sum(t => t.H64),
                                      H65 = destino.Sum(t => t.H65),
                                      H66 = destino.Sum(t => t.H66),
                                      H67 = destino.Sum(t => t.H67),
                                      H68 = destino.Sum(t => t.H68),
                                      H69 = destino.Sum(t => t.H69),
                                      H70 = destino.Sum(t => t.H70),

                                      H71 = destino.Sum(t => t.H71),
                                      H72 = destino.Sum(t => t.H72),
                                      H73 = destino.Sum(t => t.H73),
                                      H74 = destino.Sum(t => t.H74),
                                      H75 = destino.Sum(t => t.H75),
                                      H76 = destino.Sum(t => t.H76),
                                      H77 = destino.Sum(t => t.H77),
                                      H78 = destino.Sum(t => t.H78),
                                      H79 = destino.Sum(t => t.H79),
                                      H80 = destino.Sum(t => t.H80),

                                      H81 = destino.Sum(t => t.H81),
                                      H82 = destino.Sum(t => t.H82),
                                      H83 = destino.Sum(t => t.H83),
                                      H84 = destino.Sum(t => t.H84),
                                      H85 = destino.Sum(t => t.H85),
                                      H86 = destino.Sum(t => t.H86),
                                      H87 = destino.Sum(t => t.H87),
                                      H88 = destino.Sum(t => t.H88),
                                      H89 = destino.Sum(t => t.H89),
                                      H90 = destino.Sum(t => t.H90),

                                      H91 = destino.Sum(t => t.H91),
                                      H92 = destino.Sum(t => t.H92),
                                      H93 = destino.Sum(t => t.H93),
                                      H94 = destino.Sum(t => t.H94),
                                      H95 = destino.Sum(t => t.H95),
                                      H96 = destino.Sum(t => t.H96)

                                  }).ToList();


             List<MedicionReporteDTO> resultadoTG = new List<MedicionReporteDTO>();

             foreach (MeMedicion96DTO item in listTipoGeneracion)
             {
                 MedicionReporteDTO itemTG = new MedicionReporteDTO();
                 itemTG.Tgenernomb = item.Tgenernomb;

                 if (indice >= 1 && indice <= 96)
                 {
                     object result = item.GetType().GetProperty(Constantes.CaracterH + indice).GetValue(item, null);
                     itemTG.MDFuenteEnergia = (result != null) ? Convert.ToDecimal(result) : 0;                    
                 }

                 resultadoTG.Add(itemTG);
             }


             reporteTG = resultadoTG;

        }

        /// <summary>
        /// Permite obtener la máxima y nímima demanda
        /// </summary>
        /// <param name="list"></param>
        public MedicionReporteDTO ObtenerParametros(List<MeMedicion96DTO> list)
        {
            MedicionReporteDTO entity = new MedicionReporteDTO();

            decimal max = decimal.MinValue;
            decimal min = decimal.MaxValue;
            DateTime fechaMax = DateTime.Now;
            int horaMax = 0;
            DateTime fechaMin = DateTime.Now;
            int horaMin = 0;
            decimal valor = 0;

            int index = 0;
            int count = 0;

            foreach (MeMedicion96DTO item in list)
            {
                for (int i = 1; i <= 96; i++)
                {
                    object result = item.GetType().GetProperty(Constantes.CaracterH + i).GetValue(item, null);
                    if (result != null)
                    {
                        valor = Convert.ToDecimal(result);

                        if (valor > max)
                        {
                            max = valor;
                            fechaMax = (DateTime)item.Medifecha;
                            horaMax = i;
                            index = count;
                        }
                        if (valor < min)
                        {
                            min = valor;
                            fechaMin = (DateTime)item.Medifecha;
                            horaMin = i;
                        }
                    }
                }

                count++;
            }

            entity.MaximaDemanda = max;
            entity.FechaMaximaDemanda = fechaMax;
            entity.HoraMaximaDemanda = horaMax;
            entity.MinimaDemanda = min;
            entity.FechaMinimaDemanda = fechaMin;
            entity.HoraMinimaDemanda = horaMin;

            entity.MaximaDemandaHora = fechaMax.AddMinutes(horaMax * 15);
            entity.MinimaDemandaHora = fechaMin.AddMinutes(horaMin * 15);
                     
            /* 
             * maxima	72	91			
             * media	32	71			
             * minima	1	31		
             * minma    92	96
             */
            
            if (index < list.Count)
            {
                MeMedicion96DTO maxima = list[index];
                List<decimal> valores = new List<decimal>();

                decimal valorDmaxima = decimal.MinValue;
                decimal valorDmedia = decimal.MinValue;
                decimal valorDminima = decimal.MaxValue;
                int horaDmaxima = 0;
                int horaDmedia = 0;
                int horaDminima = 0;

                for (int i = 1; i <= 96; i++)
                {
                    object result = maxima.GetType().GetProperty(Constantes.CaracterH + i).GetValue(maxima, null);
                    if (result != null)
                    {
                        valores.Add(Convert.ToDecimal(result));
                    }
                }

                for (int i = 1; i <= 96; i++)
                {
                    decimal item = valores[i - 1];

                    if (i >= 72 && i <= 91)
                    {
                        if (item > valorDmaxima)
                        {
                            valorDmaxima = item;
                            horaDmaxima = i;
                        }
                    }
                    if (i >= 32 && i <= 71)
                    {
                        if (item > valorDmedia)
                        {
                            valorDmedia = item;
                            horaDmedia = i;
                        }
                    }
                    if ((i >= 1 && i <= 31) || (i >= 92 && i <= 96))
                    {
                        if (item < valorDminima)
                        {
                            valorDminima = item;
                            horaDminima = i;
                        }
                    }
                }

                entity.BloqueMaximaDemanda = valorDmaxima;
                entity.BloqueMediaDemanda = valorDmedia;
                entity.BloqueMinimaDemanda = valorDminima;
                entity.BloqueMaximaHora = horaDmaxima;
                entity.BloqueMediaHora = horaDmedia;
                entity.BloqueMinimaHora = horaDminima;

                entity.HoraBloqueMaxima = fechaMax.AddMinutes(15 * horaDmaxima);
                entity.HoraBloqueMedia = fechaMax.AddMinutes(15 * horaDmedia);
                entity.HoraBloqueMinima = fechaMax.AddMinutes(15 * horaDminima);

            }

            return entity;
        }

        /// <summary>
        /// Permite generar el reporte en excel de los medidores de generación
        /// </summary>
        /// <param name="listCuadros"></param>
        /// <param name="umbrales"></param>
        /// <param name="listFuenteEnergia"></param>
        /// <param name="path"></param>
        /// <param name="file"></param>
        public void GenerarArchivoExcel(List<MedicionReporteDTO> listCuadros,MedicionReporteDTO umbrales, 
            List<MedicionReporteDTO> listFuenteEnergia, DateTime fechaConsulta, DateTime fechaInicio, DateTime fechaFin ,
            string path, string file)
        {
            try
            {
                file = path + file;
                FileInfo newFile = new FileInfo(file);

                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(file);
                }

                using (xlPackage = new ExcelPackage(newFile))
                {
                    this.CrearHojaResumen(umbrales, listFuenteEnergia, fechaConsulta, fechaInicio, fechaFin);

                    this.CrearHojaRecursoEnergetico(listCuadros);

                    this.CrearHoraTipoGeneracion(listCuadros, umbrales);

                    xlPackage.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Crea la hoja con los datos a exportar
        /// </summary>
        /// <param name="hojaName"></param>
        /// <param name="list"></param>
        protected void CrearHojaResumen(MedicionReporteDTO umbrales,List<MedicionReporteDTO> listFuenteEnergia, DateTime fechaConsulta,
            DateTime fechaDesde, DateTime fechaHasta)
        {
            ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("RESUMEN");

            if (ws != null)
            {
                ws.Cells[5, 2].Value = "REPORTE DE PRODUCCIÓN DE ENERGÍA ELÉCTRICA Y POTENCIA EJECUTADA";

                ExcelRange rg = ws.Cells[5, 2, 5, 2];
                rg.Style.Font.Size = 13;
                rg.Style.Font.Bold = true;

                ws.Cells[7, 2].Value = "FECHA CONSULTA " + fechaConsulta.ToString("dd/MM/yyyy");
                rg = ws.Cells[7, 2, 7, 4];
                rg.Merge = true;
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#EAF7D9"));
                rg.Style.Border.Left.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Left.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                rg.Style.Border.Right.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Right.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                rg.Style.Border.Top.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Top.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                rg.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Bottom.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                
                ws.Cells[9, 2].Value = "PERIODO DE CONSULTA DEL " + fechaDesde.ToString("dd/MM/yyyy") + " AL " + fechaHasta.ToString("dd/MM/yyyy");
                rg = ws.Cells[9, 2, 9, 4];
                rg.Merge = true;
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#EAF7D9"));
                rg.Style.Border.Left.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Left.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                rg.Style.Border.Right.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Right.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                rg.Style.Border.Top.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Top.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                rg.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Bottom.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
               
                                
                ws.Cells[11, 2].Value = "Fecha del día de la máxima demanda: " + umbrales.FechaMaximaDemanda.ToString("dd/MM/yyyy");

                rg = ws.Cells[11, 2, 11, 4];
                rg.Merge = true;
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;

                ws.Cells[12, 2].Value = "Bloque horario";
                ws.Cells[12, 3].Value = "Hora";
                ws.Cells[12, 4].Value = "MW";

                rg = ws.Cells[12, 2, 12, 4];
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#E8F6FF"));
                rg.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#245C86"));
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;


                ws.Cells[13, 2].Value = "Máxima";
                ws.Cells[13, 3].Value = umbrales.HoraBloqueMaxima.ToString("HH:mm");
                ws.Cells[13, 4].Value = umbrales.BloqueMaximaDemanda;
                ws.Cells[14, 2].Value = "Media";
                ws.Cells[14, 3].Value = umbrales.HoraBloqueMedia.ToString("HH:mm");
                ws.Cells[14, 4].Value = umbrales.BloqueMediaDemanda;
                ws.Cells[15, 2].Value = "Mínima";
                ws.Cells[15, 3].Value = umbrales.HoraBloqueMinima.ToString("HH:mm");
                ws.Cells[15, 4].Value = umbrales.BloqueMinimaDemanda;


                rg = ws.Cells[13, 4, 15, 4];
                rg.Style.Numberformat.Format = "#,##0.000";

                rg = ws.Cells[13, 2, 15, 4];
                rg.Style.Font.Size = 10;
                rg.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#246189"));


                rg = ws.Cells[11, 2, 15, 4];
                rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Left.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Right.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Top.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Bottom.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                
                ws.Cells[17, 2].Value = "Tipo de recurso energético";
                rg = ws.Cells[17, 2, 19, 2];
                rg.Merge = true;               
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;
                
                ws.Cells[17, 3].Value = "Energía (MWh)";
                rg = ws.Cells[17, 3, 19, 3];
                rg.Merge = true;
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;


                ws.Cells[17, 4].Value = "Máxima demanda (MW)";
                rg = ws.Cells[17, 4, 17, 4];                
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;


                ws.Cells[18, 4].Value = "Dia: " + umbrales.FechaMaximaDemanda.ToString("dd/MM/yyyy");
                rg = ws.Cells[18, 4, 18, 4];               
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#E8F6FF"));
                rg.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#245C86"));
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;


                ws.Cells[19, 4].Value = umbrales.MaximaDemandaHora.ToString("HH:mm");
                rg = ws.Cells[19, 4, 19, 4];                
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;

                
                int index = 20;
                foreach (MedicionReporteDTO item in listFuenteEnergia)
                {
                    if (!item.IndicadorTotal)
                    {
                        ws.Cells[index, 2].Value = item.Fenergnomb;
                        ws.Cells[index, 3].Value = item.EnergiaFuenteEnergia;
                        ws.Cells[index, 4].Value = item.MDFuenteEnergia;

                        rg = ws.Cells[index, 2, index, 4];
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#246189"));
                    }
                    else
                    {
                        ws.Cells[index, 2].Value = "TOTAL";
                        ws.Cells[index, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[index, 3].Value = item.EnergiaFuenteEnergia;
                        ws.Cells[index, 4].Value = item.MDFuenteEnergia;

                        rg = ws.Cells[index, 2, index, 4];
                        rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2E8DCD"));
                        rg.Style.Font.Color.SetColor(Color.White);
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Bold = true;                    

                    }

                    index++;
                }


                rg = ws.Cells[20, 3, index, 4];
                rg.Style.Numberformat.Format = "#,##0.000";


                rg = ws.Cells[17, 2, index - 1, 4];
                rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Left.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Right.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Top.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Bottom.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));


                ws.Column(2).Width = 30;

                rg = ws.Cells[7, 3, index, 4];
                rg.AutoFitColumns();


                HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                ExcelPicture picture = ws.Drawings.AddPicture("ff", img);
                picture.From.Column = 1;
                picture.From.Row = 1;
                picture.To.Column = 2;
                picture.To.Row = 2;
                picture.SetSize(120, 35);

            }
        }

        /// <summary>
        /// Permite generar la hoja de consulta de reporte por recurso energético
        /// </summary>
        /// <param name="list"></param>
        protected void CrearHojaRecursoEnergetico(List<MedicionReporteDTO> list)
        {
            ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("RECURSO ENEGÉTICO");

            if (ws != null)
            {
                ws.Cells[5, 2].Value = "REPORTE DE PRODUCCIÓN DE ENERGÍA ELÉCTRICA Y POTENCIA EJECUTADA POR TIPO DE RECURSO ENERGÉTICO";

                ExcelRange rg = ws.Cells[5, 2, 5, 2];
                rg.Style.Font.Size = 13;
                rg.Style.Font.Bold = true;
                                                
                int row = 8;

                ws.Cells[row, 2].Value = "N°";
                ws.Cells[row, 3].Value = "Empresa";
                ws.Cells[row, 4].Value = "Central";
                ws.Cells[row, 5].Value = "Unidad";
                ws.Cells[row, 6].Value = "Tipo de Recurso Energético";
                ws.Cells[row, 7].Value = "Energía (MWh)";
                ws.Cells[row, 8].Value = "Máxima Demanda(MW)";
                ws.Cells[row, 9].Value = "Mínima Demanda(MW)";

                rg = ws.Cells[row, 2, row, 9];
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;

                row++;
                
                foreach (MedicionReporteDTO item in list)
                {
                    if (!item.IndicadorTotal && !item.IndicadorTotalGeneral)
                    {                      
                        ws.Cells[row, 2].Value = item.NroItem;
                        ws.Cells[row, 3].Value = item.Emprnomb;
                        ws.Cells[row, 4].Value = item.Central;
                        ws.Cells[row, 5].Value = item.Unidad;
                        ws.Cells[row, 6].Value = item.Fenergnomb;
                        ws.Cells[row, 7].Value = item.Total;
                        ws.Cells[row, 8].Value = item.MaximaDemanda;
                        ws.Cells[row, 9].Value = item.MinimaDemanda;

                        rg = ws.Cells[row, 2, row, 9];
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#246189"));
                    }
                    else 
                    {
                        if (item.IndicadorTotal)
                        { 
                            ws.Cells[row, 2].Value = "TOTAL: " + item.Emprnomb.Trim();
                            ws.Cells[row, 2, row, 6].Merge = true;
                            ws.Cells[row, 7].Value = item.Total;
                            ws.Cells[row, 8].Value = item.MaximaDemanda;
                            ws.Cells[row, 9].Value = item.MinimaDemanda;
                            
                            rg = ws.Cells[row, 2, row, 9];
                            rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#E8F6FF"));
                            rg.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#245C86"));
                            rg.Style.Font.Size = 10;
                            rg.Style.Font.Bold = true;

                            ws.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        
                        }
                        if (item.IndicadorTotalGeneral)
                        {
                            ws.Cells[row, 2].Value = "TOTAL GENERAL";
                            ws.Cells[row, 2, row, 6].Merge = true;
                            ws.Cells[row, 7].Value = item.Total;
                            ws.Cells[row, 8].Value = item.MaximaDemanda;
                            ws.Cells[row, 9].Value = item.MinimaDemanda;

                            rg = ws.Cells[row, 2, row, 9];
                            rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2E8DCD"));
                            rg.Style.Font.Color.SetColor(Color.White);
                            rg.Style.Font.Size = 10;
                            rg.Style.Font.Bold = true;

                            ws.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }
                    }
                   
                    row++;
                }


                rg = ws.Cells[9, 7, row, 9];
                rg.Style.Numberformat.Format = "#,##0.000";


                rg = ws.Cells[8, 2, row, 9];
                rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Left.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Right.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Top.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Bottom.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                
                ws.Column(2).Width = 10;

                rg = ws.Cells[8, 3, row, 9];
                rg.AutoFitColumns();

                HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                ExcelPicture picture = ws.Drawings.AddPicture("ff", img);
                picture.From.Column = 1;
                picture.From.Row = 1;
                picture.To.Column = 2;
                picture.To.Row = 2;
                picture.SetSize(120, 35);

            }

        }

        /// <summary>
        /// Permite generar la hora del reporte por tipo de generación
        /// </summary>
        /// <param name="list"></param>
        /// <param name="umbral"></param>
        protected void CrearHoraTipoGeneracion(List<MedicionReporteDTO> list, MedicionReporteDTO umbral)
        {
            ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("TIPO DE GENERACIÓN");

            if (ws != null)
            {
                ws.Cells[5, 2].Value = "REPORTE DE PRODUCCIÓN DE ENERGÍA ELÉCTRICA Y POTENCIA EJECUTADA POR TIPO DE GENERACIÓN";

                ExcelRange rg = ws.Cells[5, 2, 5, 2];
                rg.Style.Font.Size = 13;
                rg.Style.Font.Bold = true;
                
                ws.Cells[6, 10].Value = "Máxima demanda: el " + umbral.FechaMaximaDemanda.ToString("dd/MM/yyyy") + "a las " + umbral.MaximaDemandaHora.ToString("HH:mm");
                ws.Cells[6, 10, 6, 12].Merge = true;
                ws.Cells[7, 10].Value = "Mínima demanda: el " + umbral.FechaMinimaDemanda.ToString("dd/MM/yyyy") + "a las " + umbral.MinimaDemandaHora.ToString("HH:mm");
                ws.Cells[7, 10, 7, 12].Merge = true;
                
                rg = ws.Cells[6, 10, 7, 12];
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;             
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#EAF7D9"));
                rg.Style.Border.Left.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Left.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                rg.Style.Border.Right.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Right.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                rg.Style.Border.Top.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Top.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                rg.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                rg.Style.Border.Bottom.Color.SetColor(ColorTranslator.FromHtml("#BBDF8D"));
                
                int row = 9;
                                
                ws.Cells[row, 2].Value = "N°";
                ws.Cells[row, 3].Value = "Empresa";
                ws.Cells[row, 4].Value = "Central";
                ws.Cells[row, 5].Value = "Unidad";
                ws.Cells[row, 6].Value = "Energía Hidroeléctrica (MWh)";
                ws.Cells[row, 7].Value = "Energía Termoeléctrica (MWh)";
                ws.Cells[row, 8].Value = "Energía Solar (MWh)";
                ws.Cells[row, 9].Value = "Energía Eólica (MWh)";
                ws.Cells[row, 10].Value = "Total Empresa (MWh)";
                ws.Cells[row, 11].Value = "Máxima Demanda (MW)";
                ws.Cells[row, 12].Value = "Mínima Demanda (MW)";

                rg = ws.Cells[row, 2, row, 12];
                rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2980B9"));
                rg.Style.Font.Color.SetColor(Color.White);
                rg.Style.Font.Size = 10;
                rg.Style.Font.Bold = true;

                row++;
                
                foreach (MedicionReporteDTO item in list)
                {
                    if (!item.IndicadorTotal && !item.IndicadorTotalGeneral)
                    {                        
                        ws.Cells[row, 2].Value = item.NroItem;
                        ws.Cells[row, 3].Value = item.Emprnomb;
                        ws.Cells[row, 4].Value = item.Central;
                        ws.Cells[row, 5].Value = item.Unidad;
                        ws.Cells[row, 6].Value = item.Hidraulico;
                        ws.Cells[row, 7].Value = item.Termico;
                        ws.Cells[row, 8].Value = item.Solar;
                        ws.Cells[row, 9].Value = item.Eolico;
                        ws.Cells[row, 10].Value = item.Total;
                        ws.Cells[row, 11].Value = item.MaximaDemanda;
                        ws.Cells[row, 12].Value = item.MinimaDemanda;
                        rg = ws.Cells[row, 2, row, 12];
                        rg.Style.Font.Size = 10;
                        rg.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#246189"));
                    }
                    else
                    {
                        if (item.IndicadorTotal)
                        {                           
                            ws.Cells[row, 2].Value = "TOTAL "  + item.Emprnomb.Trim();
                            ws.Cells[row, 2, row, 5].Merge = true;                           

                            ws.Cells[row, 6].Value = item.Hidraulico;
                            ws.Cells[row, 7].Value = item.Termico;
                            ws.Cells[row, 8].Value = item.Solar;
                            ws.Cells[row, 9].Value = item.Eolico;
                            ws.Cells[row, 10].Value = item.Total;
                            ws.Cells[row, 11].Value = item.MaximaDemanda;
                            ws.Cells[row, 12].Value = item.MinimaDemanda;

                            rg = ws.Cells[row, 2, row, 12];
                            rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#E8F6FF"));
                            rg.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#245C86"));
                            rg.Style.Font.Size = 10;
                            rg.Style.Font.Bold = true;

                            ws.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        }
                        if (item.IndicadorTotalGeneral)
                        {
                            ws.Cells[row, 2].Value = "TOTAL GENERAL";
                            ws.Cells[row, 2, row, 5].Merge = true;                           

                            ws.Cells[row, 6].Value = item.Hidraulico;
                            ws.Cells[row, 7].Value = item.Termico;
                            ws.Cells[row, 8].Value = item.Solar;
                            ws.Cells[row, 9].Value = item.Eolico;
                            ws.Cells[row, 10].Value = item.Total;
                            ws.Cells[row, 11].Value = item.MaximaDemanda;
                            ws.Cells[row, 12].Value = item.MinimaDemanda;

                            rg = ws.Cells[row, 2, row, 12];
                            rg.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            rg.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rg.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#2E8DCD"));
                            rg.Style.Font.Color.SetColor(Color.White);
                            rg.Style.Font.Size = 10;
                            rg.Style.Font.Bold = true;

                            ws.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }
                    }

                    row++;
                }

                rg = ws.Cells[10, 7, row, 12];
                rg.Style.Numberformat.Format = "#,##0.000";


                rg = ws.Cells[9, 2, row, 12];
                rg.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Left.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Right.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Top.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));
                rg.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rg.Style.Border.Bottom.Color.SetColor(ColorTranslator.FromHtml("#9F9F9F"));


                ws.Column(2).Width = 10;

                rg = ws.Cells[9, 3, row, 12];
                rg.AutoFitColumns();

                HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create("http://www.coes.org.pe/wcoes/images/logocoes.png");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                System.Drawing.Image img = System.Drawing.Image.FromStream(response.GetResponseStream());
                ExcelPicture picture = ws.Drawings.AddPicture("ff", img);
                picture.From.Column = 1;
                picture.From.Row = 1;
                picture.To.Column = 2;
                picture.To.Row = 2;
                picture.SetSize(120, 35);
            }
        }

    }
}
