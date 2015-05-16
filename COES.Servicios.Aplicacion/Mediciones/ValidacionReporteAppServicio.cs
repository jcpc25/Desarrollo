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
using System.Globalization;
using OfficeOpenXml.Style;
using System.Drawing;

namespace COES.Servicios.Aplicacion.Mediciones
{
    public class ValidacionReporteAppServicio
    {
        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ConsultaMedidoresAppServicio));

        #region Métodos Tabla WB_MEDIDORES_VALIDACION

        /// <summary>
        /// Inserta un registro de la tabla WB_MEDIDORES_VALIDACION
        /// </summary>
        public void SaveWbMedidoresValidacion(WbMedidoresValidacionDTO entity)
        {
            try
            {
                FactorySic.GetWbMedidoresValidacionRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla WB_MEDIDORES_VALIDACION
        /// </summary>
        public void UpdateWbMedidoresValidacion(WbMedidoresValidacionDTO entity)
        {
            try
            {
                FactorySic.GetWbMedidoresValidacionRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla WB_MEDIDORES_VALIDACION
        /// </summary>
        public void DeleteWbMedidoresValidacion(int medivalcodi)
        {
            try
            {
                FactorySic.GetWbMedidoresValidacionRepository().Delete(medivalcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla WB_MEDIDORES_VALIDACION
        /// </summary>
        public WbMedidoresValidacionDTO GetByIdWbMedidoresValidacion(int medivalcodi)
        {
            return FactorySic.GetWbMedidoresValidacionRepository().GetById(medivalcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla WB_MEDIDORES_VALIDACION
        /// </summary>
        public List<WbMedidoresValidacionDTO> ListWbMedidoresValidacions()
        {
            return FactorySic.GetWbMedidoresValidacionRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla WbMedidoresValidacion
        /// </summary>
        public List<WbMedidoresValidacionDTO> GetByCriteriaWbMedidoresValidacions()
        {
            return FactorySic.GetWbMedidoresValidacionRepository().GetByCriteria();
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
        /// Permite obtener las empresa por tipo
        /// </summary>
        /// <returns></returns>
        public List<SiEmpresaDTO> ObteneEmpresasPorTipo(string tiposEmpresa)
        {
            if (string.IsNullOrEmpty(tiposEmpresa)) tiposEmpresa = Constantes.ParametroDefecto;
            return FactorySic.GetSiEmpresaRepository().GetByCriteria(tiposEmpresa);
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
        /// Lista los tipos de generación
        /// </summary>
        /// <returns></returns>
        public List<SiTipogeneracionDTO> ListaTipoGeneracion()
        {
            return FactorySic.GetSiTipogeneracionRepository().GetByCriteria().Where(x => x.Tgenercodi != -1 && x.Tgenercodi != 0 && x.Tgenercodi != 5).ToList();
        }

        /// <summary>
        /// Permite generar el reporte de validación
        /// </summary>
        /// <param name="fechaInicial"></param>
        /// <param name="fechaFinal"></param>
        /// <param name="tiposEmpresa"></param>
        /// <param name="empresas"></param>
        /// <param name="tiposGeneracion"></param>
        /// <param name="fuentesEnergia"></param>
        /// <param name="central"></param>
        /// <returns></returns>
        public List<ReporteValidacionMedidor> ObtenerReporteValidacion(DateTime fechaInicial, DateTime fechaFinal, string tiposEmpresa, string empresas,
            string tiposGeneracion, string fuentesEnergia, int central)
        {
            try
            {
                #region Parámetros

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

                #endregion

                List<WbMedidoresValidacionDTO> listConfiguracion = FactorySic.GetWbMedidoresValidacionRepository().GetByCriteria();

                List<MeMedicion48DTO> listDespacho = FactorySic.GetMeMedicion48Repository().ObtenerReporteValidacionDespacho(empresas,
                    central, fuentesEnergia, fechaInicial, fechaFinal);

                List<MeMedicion48DTO> listMedidores = FactorySic.GetMeMedicion48Repository().ObteneReporteValidacionMedidores(empresas,
                    central, fuentesEnergia, fechaInicial, fechaFinal);

                List<ReporteValidacionMedidor> resultado = new List<ReporteValidacionMedidor>();
                                
                //List<int> idsDespacho = listConfiguracion.Select(x => (int)x.Ptomedicodidesp).Distinct().ToList();
                List<int> idsDespacho = listDespacho.Select(x => x.Ptomedicodi).Distinct().ToList();                

                foreach (int idDespacho in idsDespacho)
                {
                    WbMedidoresValidacionDTO item = listConfiguracion.Where(x => x.Ptomedicodidesp == idDespacho).FirstOrDefault();
                    if (item != null)
                    {
                        ReporteValidacionMedidor itemResult = new ReporteValidacionMedidor();
                        itemResult.DesEmpresa = item.EmprNomb;
                        itemResult.DesGrupo = item.GrupoAbrev;
                        itemResult.PtoMediCodiDesp = idDespacho;
                        List<int> idsMedidores = listConfiguracion.Where(x => x.Ptomedicodidesp == idDespacho).Select(x => (int)x.Ptomedicodimed).ToList();

                        List<MeMedicion48DTO> itemMedidor = listMedidores.Where(x => idsMedidores.Any(y => x.Ptomedicodi == y)).ToList();
                        List<MeMedicion48DTO> itemDespacho = listDespacho.Where(x => x.Ptomedicodi == idDespacho).ToList();

                        if (itemDespacho!=null)
                        {
                            itemResult.ValorDespacho = itemDespacho.Sum(x => (decimal)x.H1);
                        }                        

                        if (itemMedidor != null)
                        {
                            itemResult.ValorMedidor = itemMedidor.Sum(x => (decimal)x.H1);
                        }

                        if (itemResult.ValorMedidor != 0)
                        {
                            if (itemResult.ValorDespacho != 0)
                            {
                                itemResult.Desviacion = (itemResult.ValorMedidor - itemResult.ValorDespacho) *100 / (itemResult.ValorMedidor);
                            }
                            else
                            {
                                itemResult.Desviacion = 0;
                            }
                            itemResult.IndMuestra = ConstantesBase.SI;
                            itemResult.IndColor = ConstantesBase.SI;

                            if (itemResult.Desviacion < 5) 
                            {
                                itemResult.IndColor = ConstantesBase.NO;
                                itemResult.Filtro = 1;
                            }
                            if (itemResult.Desviacion == 5) 
                            {
                                itemResult.Color = "#00CC00";
                                itemResult.Filtro = 2;
                            }
                            if (itemResult.Desviacion > 5 && itemResult.Desviacion < 20)
                            {
                                itemResult.Color = "#FFFF00";
                                itemResult.Filtro = 3;
                            }
                            if (itemResult.Desviacion >= 20) {
                                itemResult.Color = "#FF3300";
                                itemResult.Filtro = 4;
                            }                          
                        }
                        else 
                        {
                            itemResult.IndMuestra = ConstantesBase.NO;
                            itemResult.IndColor = ConstantesBase.NO;
                        }
                        
                        resultado.Add(itemResult);
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        
        #endregion
    }

    public class ReporteValidacionMedidor
    {
        public string DesEmpresa { get; set; }
        public string DesGrupo { get; set; }
        public decimal ValorMedidor { get; set; }
        public decimal ValorDespacho { get; set; }
        public string IndColor { get; set; }
        public string Color { get; set; }
        public decimal Desviacion { get; set; }
        public string IndMuestra { get; set; }
        public int Filtro { get; set; }
        public int PtoMediCodiDesp { get; set; }
        public int PtoMediCodiMed { get; set; }
    }
}
