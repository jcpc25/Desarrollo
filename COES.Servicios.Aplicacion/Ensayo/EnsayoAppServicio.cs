using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using log4net;

namespace COES.Servicios.Aplicacion.ensayo
{
    /// <summary>
    /// Clases con métodos del módulo ensayo
    /// </summary>
    public class EnsayoAppServicio : AppServicioBase
    {
        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(EnsayoAppServicio));

        #region Métodos Tabla EN_ENSAYO

        /// <summary>
        /// Inserta un registro de la tabla EN_ENSAYO
        /// </summary>
        public int SaveEnEnsayo(EnEnsayoDTO entity)
        {
            int codigo = 0;
            try
            {
                codigo =FactorySic.GetEnEnsayoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
            return codigo;
        }

        /// <summary>
        /// Actualiza un registro de la tabla EN_ENSAYO
        /// </summary>
        public void UpdateEnEnsayo(EnEnsayoDTO entity)
        {
            try
            {
                FactorySic.GetEnEnsayoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Actualiza un registro columna ensayo de la tabla EN_ENSAYO
        /// </summary>       
        public void ActualizaEstadoEnsayo(int icodiensayo, DateTime dfechaEvento, int iCodEstado, DateTime lastdate, string lastuser)
        { 
            try
            {
                FactorySic.GetEnEnsayoRepository().UpdateEstadoEnsayo(icodiensayo, dfechaEvento, iCodEstado, lastdate, lastuser);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EN_ENSAYO
        /// </summary>
        public void DeleteEnEnsayo()
        {
            try
            {
                FactorySic.GetEnEnsayoRepository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EN_ENSAYO
        /// </summary>
        public EnEnsayoDTO GetByIdEnEnsayo(int id)
        {
            return FactorySic.GetEnEnsayoRepository().GetById(id);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EN_ENSAYO
        /// </summary>
        public List<EnEnsayoDTO> ListEnEnsayos()
        {
            return FactorySic.GetEnEnsayoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EnEnsayo
        /// </summary>
        public List<EnEnsayoDTO> GetByCriteriaEnEnsayos()
        {
            return FactorySic.GetEnEnsayoRepository().GetByCriteria();
        }
        public List<EnEnsayoDTO> ListaDetalleCbEnsayosFiltro(string emprcodi, string equicodi, string estados, DateTime fechaInicio, DateTime fechaFin, int nroPaginas, int pageSize)
        {
            return FactorySic.GetEnEnsayoRepository().ListaDetalleFiltro(emprcodi, equicodi, estados, fechaInicio, fechaFin, nroPaginas, pageSize);
        }

        /// <summary>
        ///Permite listar los ensayos segun los filtros indicados para foprmato Excel
        /// </summary>     
        public List<EnEnsayoDTO> ListaDetalleCbEnsayosFiltroXls(string emprcodi, string equicodi, string estados, DateTime fechaInicio, DateTime fechaFin)
        {
            return FactorySic.GetEnEnsayoRepository().ListaDetalleFiltroXls(emprcodi, equicodi, estados, fechaInicio, fechaFin);
        }
        /// <summary>
        /// permite contar la antidad de ensayos
        /// </summary>       
        public int GetTotalEnsayo(string empresas, string centrales, string estados, DateTime fechaInicio, DateTime fechaFin)
        {
            return FactorySic.GetEnEnsayoRepository().ObtenerTotalListaEnsayo(empresas, centrales, estados, fechaInicio, fechaFin);
        }
        #endregion



        #region Métodos Tabla EN_ENSAYOFORMATO

        /// <summary>
        /// Inserta un registro de la tabla EN_ENSAYOFORMATO
        /// </summary>
        public void SaveEnEnsayoformato(EnEnsayoformatoDTO entity)
        {
            try
            {
                FactorySic.GetEnEnsayoformatoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EN_ENSAYOFORMATO
        /// </summary>
        public void UpdateEnEnsayoformato(EnEnsayoformatoDTO entity)
        {
            try
            {
                FactorySic.GetEnEnsayoformatoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro estado de la tabla EN_ENSAYOFORMATO
        /// </summary>
        public void UpdateEnEnsayoformatoEstado(int ensformtestado, int ensayocodi, int formatocodi)
        {
            try
            {
                FactorySic.GetEnEnsayoformatoRepository().UpdateEstado(ensformtestado, ensayocodi, formatocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EN_ENSAYOFORMATO
        /// </summary>
        public void DeleteEnEnsayoformato()
        {
            try
            {
                FactorySic.GetEnEnsayoformatoRepository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EN_ENSAYOFORMATO
        /// </summary>
        public EnEnsayoformatoDTO GetByIdEnEnsayoformato(int ensayocodi, int formatocodi)
        {
            return FactorySic.GetEnEnsayoformatoRepository().GetById(ensayocodi, formatocodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EN_ENSAYOFORMATO
        /// </summary>
        public List<EnEnsayoformatoDTO> ListEnEnsayoformatos()
        {
            return FactorySic.GetEnEnsayoformatoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EnEnsayoformato
        /// </summary>
        public List<EnEnsayoformatoDTO> GetByCriteriaEnEnsayoformatos()
        {
            return FactorySic.GetEnEnsayoformatoRepository().GetByCriteria();
        }

        public List<EnEnsayoformatoDTO> ListFormatoXEnsayo(int ensayocodi)
        {
            return FactorySic.GetEnEnsayoformatoRepository().ListaFormatoXEnsayo(ensayocodi);
        }
        #endregion

        /// <summary>
        /// Permite listar todos los ultimos formatos de la tabla EN_ENSAYOFORMATO de una emresa y una central
        /// </summary>
        public List<EnEnsayoformatoDTO> ListEnEnsayoFormatosEmpresaCentral(int emprcodi, int equicodi)
        {
            return FactorySic.GetEnEnsayoformatoRepository().ListaFormatoXEnsayoEmpresaCtral(emprcodi, equicodi);
        }
        #region Métodos Tabla EN_ENSAYOUNIDAD

        /// <summary>
        /// Inserta un registro de la tabla EN_ENSAYOUNIDAD
        /// </summary>
        public void SaveEnEnsayounidad(EnEnsayounidadDTO entity)
        {
            try
            {
                FactorySic.GetEnEnsayounidadRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EN_ENSAYOUNIDAD
        /// </summary>
        public void UpdateEnEnsayounidad(EnEnsayounidadDTO entity)
        {
            try
            {
                FactorySic.GetEnEnsayounidadRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EN_ENSAYOUNIDAD
        /// </summary>
        public void DeleteEnEnsayounidad(int ensayocodi)
        {
            try
            {
                FactorySic.GetEnEnsayounidadRepository().Delete(ensayocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EN_ENSAYOUNIDAD
        /// </summary>
        public EnEnsayounidadDTO GetByIdEnEnsayounidad()
        {
            return FactorySic.GetEnEnsayounidadRepository().GetById();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EN_ENSAYOUNIDAD
        /// </summary>
        public List<EnEnsayounidadDTO> ListEnEnsayounidads()
        {
            return FactorySic.GetEnEnsayounidadRepository().List();
        }
        /// <summary>
        /// Permite listar todas las unidades para un ensayo de la tabla EN_ENSAYOUNIDAD
        /// </summary>
        public List<EnEnsayounidadDTO> GetListarUnidadxEnsayo(int ensayocodi)
        {
            return FactorySic.GetEnEnsayounidadRepository().ListarUnidadxEnsayo(ensayocodi);
        }
        /// <summary>
        /// Permite realizar búsquedas en la tabla EnEnsayounidad
        /// </summary>
        public List<EnEnsayounidadDTO> GetByCriteriaEnEnsayounidads()
        {
            return FactorySic.GetEnEnsayounidadRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla EN_FORMATO

        /// <summary>
        /// Inserta un registro de la tabla EN_FORMATO
        /// </summary>
        public void SaveEnFormato(EnFormatoDTO entity)
        {
            try
            {
                FactorySic.GetEnFormatoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EN_FORMATO
        /// </summary>
        public void UpdateEnFormato(EnFormatoDTO entity)
        {
            try
            {
                FactorySic.GetEnFormatoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EN_FORMATO
        /// </summary>
        public void DeleteEnFormato()
        {
            try
            {
                FactorySic.GetEnFormatoRepository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EN_FORMATO
        /// </summary>
        public EnFormatoDTO GetByIdEnFormato()
        {
            return FactorySic.GetEnFormatoRepository().GetById();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EN_FORMATO
        /// </summary>
        public List<EnFormatoDTO> ListEnFormatos()
        {
            return FactorySic.GetEnFormatoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EnFormato
        /// </summary>
        public List<EnFormatoDTO> GetByCriteriaEnFormatos()
        {
            return FactorySic.GetEnFormatoRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla Si_Empresa
        /// <summary>
        /// Obtiene la lista de empresas generadoras
        /// </summary>
        public List<SiEmpresaDTO> ObtenerEmpresasSEIN()
        {
            return FactorySic.GetSiEmpresaRepository().ObtenerEmpresasSEIN();
        }

        public List<SiEmpresaDTO> ObtenerEmpresasXUsuario(string userlogin)
        {
            return FactorySic.GetSiEmpresaRepository().GetByUser(userlogin);
        }
        #endregion

        #region Métodos TabLa eq_equipo

        public List<EqEquipoDTO> ListEqEquipoEmpresaGEN(string emprcodi)
        {
            return FactorySic.GetEqEquipoRepository().ListarCentralesXEmpresaGEN(emprcodi);
        }
        public List<EqEquipoDTO> ListEqEquipoEnsayo(string equicodi)
        {
            return FactorySic.GetEqEquipoRepository().ListarEquiposEnsayo(equicodi);
        }
        #endregion

        #region Métodos Tabla EN_ESTADOS

        /// <summary>
        /// Inserta un registro de la tabla EN_ESTADOS
        /// </summary>
        public void SaveEnEstados(EnEstadoDTO entity)
        {
            try
            {
                FactorySic.GetEnEstadosRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EN_ESTADOS
        /// </summary>
        public void UpdateEnEstados(EnEstadoDTO entity)
        {
            try
            {
                FactorySic.GetEnEstadosRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EN_ESTADOS
        /// </summary>
        public void DeleteEnEstados()
        {
            try
            {
                FactorySic.GetEnEstadosRepository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EN_ESTADOS
        /// </summary>
        public EnEstadoDTO GetByIdEnEstados()
        {
            return FactorySic.GetEnEstadosRepository().GetById();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EN_ESTADOS
        /// </summary>
        public List<EnEstadoDTO> ListEnEstadoss()
        {
            return FactorySic.GetEnEstadosRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EnEstados
        /// </summary>
        public List<EnEstadoDTO> GetByCriteriaEnEstadoss()
        {
            return FactorySic.GetEnEstadosRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla EN_ESTENSAYO

        /// <summary>
        /// Inserta un registro de la tabla EN_ESTENSAYO
        /// </summary>
        public void SaveEnEstensayo(EnEstensayoDTO entity)
        {
            try
            {
                FactorySic.GetEnEstensayoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EN_ESTENSAYO
        /// </summary>
        public void UpdateEnEstensayo(EnEstensayoDTO entity)
        {
            try
            {
                FactorySic.GetEnEstensayoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EN_ESTENSAYO
        /// </summary>
        public void DeleteEnEstensayo()
        {
            try
            {
                FactorySic.GetEnEstensayoRepository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EN_ESTENSAYO
        /// </summary>
        public EnEstensayoDTO GetByIdEnEstensayo()
        {
            return FactorySic.GetEnEstensayoRepository().GetById();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EN_ESTENSAYO
        /// </summary>
        public List<EnEstensayoDTO> ListEnEstensayos()
        {
            return FactorySic.GetEnEstensayoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EnEstensayo
        /// </summary>
        public List<EnEstensayoDTO> GetByCriteriaEnEstensayos()
        {
            return FactorySic.GetEnEstensayoRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla EN_ESTFORMATO

        /// <summary>
        /// Inserta un registro de la tabla EN_ESTFORMATO
        /// </summary>
        public void SaveEnEstformato(EnEstformatoDTO entity)
        {
            try
            {
                FactorySic.GetEnEstformatoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EN_ESTFORMATO
        /// </summary>
        public void UpdateEnEstformato(EnEstformatoDTO entity)
        {
            try
            {
                FactorySic.GetEnEstformatoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EN_ESTFORMATO
        /// </summary>
        public void DeleteEnEstformato()
        {
            try
            {
                FactorySic.GetEnEstformatoRepository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EN_ESTFORMATO
        /// </summary>
        public EnEstformatoDTO GetByIdEnEstformato()
        {
            return FactorySic.GetEnEstformatoRepository().GetById();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EN_ESTFORMATO
        /// </summary>
        public List<EnEstformatoDTO> ListEnEstformatos()
        {
            return FactorySic.GetEnEstformatoRepository().List();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EN_ESTFORMATO de un Ensayo
        /// </summary>
        public List<EnEstformatoDTO> ListEnEstformatosEnsayo(int ensayocodi, int iformatocodi)
        {
            return FactorySic.GetEnEstformatoRepository().ListFormatoXEstado(ensayocodi, iformatocodi);
        }


        /// <summary>
        /// Permite realizar búsquedas en la tabla EnEstformato
        /// </summary>
        public List<EnEstformatoDTO> GetByCriteriaEnEstformatos()
        {
            return FactorySic.GetEnEstformatoRepository().GetByCriteria();
        }

        #endregion
    }
}
