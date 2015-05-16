using COES.Base.Core;
using COES.Dominio.DTO.Sic;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Servicios.Aplicacion.Combustibles
{
    public class CombustibleAppServicio : AppServicioBase
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CombustibleAppServicio));
        #region Métodos Tabla Si_Empresa

        public List<SiEmpresaDTO> ObtenerEmpresasPorUsuario(string userlogin)
        {
            return FactorySic.GetSiEmpresaRepository().GetByUser(userlogin);
        }

        public List<SiEmpresaDTO> ObtenerEmpresasSEIN()
        {
            return FactorySic.GetSiEmpresaRepository().ObtenerEmpresasSEIN();
        }
        #endregion
        /// <summary>
        /// Obtiene la lista de empresas por combustible
        /// </summary>
        /// <param name="tipocombustible"></param>
        /// <returns></re
        /// O:8ns>
        public List<SiEmpresaDTO> ObtenerEmpresasxCombustible(string tipocombustible)
        {
            return FactorySic.GetSiEmpresaRepository().ObtenerEmpresasxCombustible(tipocombustible);
        }
        /// <summary>
        /// Obtiene las empresas por tipo de combustible y por Usuario
        /// </summary>
        /// <param name="tipocombustible"></param>
        /// <returns></returns>
        public List<SiEmpresaDTO> ObtenerEmpresasxCombustiblexUsuario(string tipocombustible,string usuario)
        {
            return FactorySic.GetSiEmpresaRepository().ObtenerEmpresasxCombustiblexUsuario(tipocombustible,usuario);
        }



        #region Métodos Taba Ext_Estado_Envio

        public List<ExtEstadoEnvioDTO> ListExtEstadoEnvio()
        {
            return FactorySic.GetExtEstadoEnvioRepository().List();
        }

        #endregion

        #region Métodos TabLa eq_equipo

        public List<EqEquipoDTO> ListEqEquipoEmpresa(int emprcodi,int tipocomb)
        {
            return FactorySic.GetEqEquipoRepository().ListarCentralesXCombustible(emprcodi,tipocomb);
        }

        #endregion

        #region Métodos Tabla CB_COMBUSTIBLEDATOS

        /// <summary>
        /// Inserta un registro de la tabla CB_COMBUSTIBLEDATOS
        /// </summary>
        public void SaveCbCombustibledatos(CbCombustibledatosDTO entity)
        {
            try
            {
                FactorySic.GetCbCombustibledatosRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla CB_COMBUSTIBLEDATOS
        /// </summary>
        public void UpdateCbCombustibledatos(CbCombustibledatosDTO entity)
        {
            try
            {
                FactorySic.GetCbCombustibledatosRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla CB_COMBUSTIBLEDATOS
        /// </summary>
        public void DeleteCbCombustibledatos(DateTime combdatosfecha, int concepcodi, int enviocodi)
        {
            try
            {
                FactorySic.GetCbCombustibledatosRepository().Delete(combdatosfecha, concepcodi, enviocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla CB_COMBUSTIBLEDATOS
        /// </summary>
        public CbCombustibledatosDTO GetByIdCbCombustibledatos(DateTime combdatosfecha, int concepcodi, int enviocodi)
        {
            return FactorySic.GetCbCombustibledatosRepository().GetById(combdatosfecha, concepcodi, enviocodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla CB_COMBUSTIBLEDATOS
        /// </summary>
        public List<CbCombustibledatosDTO> ListCbCombustibledatoss()
        {
            return FactorySic.GetCbCombustibledatosRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla CbCombustibledatos
        /// </summary>
        public List<CbCombustibledatosDTO> GetByCriteriaCbCombustibledatoss(int concepcodi, int enviocodi)
        {
            return FactorySic.GetCbCombustibledatosRepository().GetByCriteria(concepcodi,enviocodi);
        }

        public void GrabarPropiedadesEnvio(List<CbCombustibledatosDTO> lista, int tipoCombustible)
        {
            foreach (var reg in lista)
            {
                reg.Concepcodi = FactorySic.GetCbConceptocombRepository().GetByCriteria(reg.Conceporden, tipoCombustible);
                SaveCbCombustibledatos(reg);
            }
        }
        /// <summary>
        /// Permite listar todos valores enviados de los precios de combustible 
        /// </summary>
        public List<CbCombustibledatosDTO> GetListaValoresEnvio(int idEnvio)
        {
            return FactorySic.GetCbCombustibledatosRepository().GetListPropValor(idEnvio);
        }

        #endregion

        #region Métodos Tabla CB_CONCEPTOCOMB

        /// <summary>
        /// Inserta un registro de la tabla CB_CONCEPTOCOMB
        /// </summary>
        public void SaveCbConceptocomb(CbConceptocombDTO entity)
        {
            try
            {
                FactorySic.GetCbConceptocombRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla CB_CONCEPTOCOMB
        /// </summary>
        public void UpdateCbConceptocomb(CbConceptocombDTO entity)
        {
            try
            {
                FactorySic.GetCbConceptocombRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla CB_CONCEPTOCOMB
        /// </summary>
        public void DeleteCbConceptocomb(int concepcodi)
        {
            try
            {
                FactorySic.GetCbConceptocombRepository().Delete(concepcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla CB_CONCEPTOCOMB
        /// </summary>
        public CbConceptocombDTO GetByIdCbConceptocomb(int concepcodi)
        {
            return FactorySic.GetCbConceptocombRepository().GetById(concepcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla CB_CONCEPTOCOMB
        /// </summary>
        public List<CbConceptocombDTO> ListCbConceptocombs()
        {
            return FactorySic.GetCbConceptocombRepository().List();
        }



        #endregion

        #region Métodos Tabla CB_ENVIO

        /// <summary>
        /// Inserta un registro de la tabla CB_ENVIO
        /// </summary>
        public int SaveCbEnvio(CbEnvioDTO entity)
        {
            int codigo = 0;
            try
            {
                codigo = FactorySic.GetCbEnvioRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
            return codigo;
        }

        /// <summary>
        /// Actualiza un registro de la tabla CB_ENVIO
        /// </summary>
        public void UpdateCbEnvio(CbEnvioDTO entity)
        {
            try
            {
                FactorySic.GetCbEnvioRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateCbEnvioObs(CbEnvioDTO entity)
        {
            try
            {
                FactorySic.GetCbEnvioRepository().UpdateObs(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla CB_ENVIO
        /// </summary>
        public void DeleteCbEnvio(int enviocodi)
        {
            try
            {
                FactorySic.GetCbEnvioRepository().Delete(enviocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla CB_ENVIO
        /// </summary>
        public CbEnvioDTO GetByIdCbEnvio(int enviocodi)
        {
            return FactorySic.GetCbEnvioRepository().GetById(enviocodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla CB_ENVIO
        /// </summary>
        public List<CbEnvioDTO> ListCbEnvios()
        {
            return FactorySic.GetCbEnvioRepository().List();
        }

        public List<CbEnvioDTO> ListaDetalleCbEnvios(int tipocombcodi)
        {
            return FactorySic.GetCbEnvioRepository().ListaDetalle(tipocombcodi);
        }

        public List<CbEnvioDTO> ListaDetalleCbEnviosFiltro(string emprcodi, string grupocodi, string estenvcodi, DateTime fechaInicio, DateTime fechaFin, int tipocombustibles, int nroPaginas, int pageSize)
        {
            return FactorySic.GetCbEnvioRepository().ListaDetalleFiltro(emprcodi, grupocodi, estenvcodi, fechaInicio, fechaFin, tipocombustibles, nroPaginas, pageSize);
        }
        
        public List<CbEnvioDTO> ListaDetalleCbEnviosFiltroXls(string emprcodi, string grupocodi, string estenvcodi, DateTime fechaInicio, DateTime fechaFin, int tipocombustibles)
        {
            return FactorySic.GetCbEnvioRepository().ListaDetalleFiltroXls(emprcodi, grupocodi, estenvcodi, fechaInicio, fechaFin, tipocombustibles);
        }
        
        public int GetTotalEnvio(string emprcodi, string grupocodi, string estenvcodi, DateTime fechaInicio, DateTime fechaFin, int tipocombustibles)
        {
            return FactorySic.GetCbEnvioRepository().ObtenerTotalListaEnvio(emprcodi, grupocodi, estenvcodi, fechaInicio, fechaFin, tipocombustibles);
        }

        public List<DateTime> ObtenerDiasFeriados(DateTime fIni, DateTime fFin)
        {
            return FactorySic.GetCbEnvioRepository().ObtenerDiasFeriados(fIni, fFin);
        }

        #endregion

        #region Métodos Tabla PR_GRUPO

        /// <summary>
        /// Inserta un registro de la tabla PR_GRUPO
        /// </summary>
        public void SavePrGrupo(PrGrupoDTO entity)
        {
            try
            {
                FactorySic.GetPrGrupoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla PR_GRUPO
        /// </summary>
        public void UpdatePrGrupo(PrGrupoDTO entity)
        {
            try
            {
                FactorySic.GetPrGrupoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla PR_GRUPO
        /// </summary>
        public void DeletePrGrupo(int grupocodi)
        {
            try
            {
                FactorySic.GetPrGrupoRepository().Delete(grupocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla PR_GRUPO
        /// </summary>
        public PrGrupoDTO GetByIdPrGrupo(int grupocodi)
        {
            return FactorySic.GetPrGrupoRepository().GetById(grupocodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla PR_GRUPO
        /// </summary>
        public List<PrGrupoDTO> ListPrGrupos()
        {
            return FactorySic.GetPrGrupoRepository().List();
        }
        /// <summary>
        /// Permite listar todos los registros de la tabla PR_GRUPO por codigo de empresa
        /// </summary>
        public List<PrGrupoDTO> ListPrGruposxEmpresa(string tipocombustible, string emprcodi)
        {
            return FactorySic.GetPrGrupoRepository().ListCentrales(tipocombustible, emprcodi);
        }



        #endregion

        #region Métodos Tabla CB_ARCHIVOENVIO

        /// <summary>
        /// Inserta un registro de la tabla CB_ARCHIVOENVIO
        /// </summary>
        public void SaveCbArchivoEnvio(CbArchivoEnvioDTO entity)
        {
            try
            {
                FactorySic.GetCbArchivoEnvioRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
            
        }

        /// <summary>
        /// Actualiza un registro de la tabla CB_ARCHIVOENVIO
        /// </summary>
        public void UpdateCbArchivoEnvio(CbArchivoEnvioDTO entity)
        {
            try
            {
                FactorySic.GetCbArchivoEnvioRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Actualiza el estado de un registro de la tabla CB_ARCHIVOENVIO
        /// </summary>
        public void UpdateCbArchivoEnvioEstado(int iEstado, int concepcodi, int enviocodi, int archienvioorden)
        {
            try
            {
                FactorySic.GetCbArchivoEnvioRepository().UpdateEstado(iEstado, concepcodi, enviocodi, archienvioorden);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// determina el nro máximo de envio de archivo de la tabla CB_ARCHIVOENVIO para una propiedad
        /// </summary>
        public int GetMAxOrdenEnvioProp(int concepcodi, int enviocodi)
        {
            int maxIdEnvio = 0;
            try
            {
                maxIdEnvio = FactorySic.GetCbArchivoEnvioRepository().GetMaxIdOrden(concepcodi, enviocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
            return maxIdEnvio;
        }
               /// <summary>
        /// Elimina un registro de la tabla CB_ARCHIVOENVIO
        /// </summary>
        public void DeleteCbArchivoEnvio(int concepcodi, int enviocodi)
        {
            try
            {
                FactorySic.GetCbArchivoEnvioRepository().Delete(concepcodi,enviocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener uno o varios registros de la tabla CB_ARCHIVOENVIO
        /// </summary>
        public List<CbArchivoEnvioDTO> GetByIdCbArchivoEnvio(int enviocodi)
        {
            return FactorySic.GetCbArchivoEnvioRepository().GetById(enviocodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla CB_ARCHIVOENVIO
        /// </summary>
        public List<CbArchivoEnvioDTO> ListCbArchivoEnvio()
        {
            return FactorySic.GetCbArchivoEnvioRepository().List();
        }

        #endregion
    }
}
