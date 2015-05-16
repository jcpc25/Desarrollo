using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using log4net;

namespace COES.Servicios.Aplicacion.Equipamiento
{
    /// <summary>
    /// Clases con métodos del módulo Equipamiento
    /// </summary>
    public class EquipamientoAppServicio : AppServicioBase
    {
        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(EquipamientoAppServicio));

        #region Métodos Tabla EQ_EQUIPO

        /// <summary>
        /// Inserta un registro de la tabla EQ_EQUIPO
        /// </summary>
        public void SaveEqEquipo(EqEquipoDTO entity)
        {
            try
            {
                FactorySic.GetEqEquipoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_EQUIPO
        /// </summary>
        public void UpdateEqEquipo(EqEquipoDTO entity)
        {
            try
            {
                FactorySic.GetEqEquipoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_EQUIPO
        /// </summary>
        public void DeleteEqEquipo(int equicodi)
        {
            try
            {
                FactorySic.GetEqEquipoRepository().Delete(equicodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_EQUIPO
        /// </summary>
        public EqEquipoDTO GetByIdEqEquipo(int equicodi)
        {
            return FactorySic.GetEqEquipoRepository().GetById(equicodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_EQUIPO
        /// </summary>
        public List<EqEquipoDTO> ListEqEquipos()
        {
            return FactorySic.GetEqEquipoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqEquipo
        /// </summary>
        public List<EqEquipoDTO> GetByCriteriaEqEquipos()
        {
            return FactorySic.GetEqEquipoRepository().GetByCriteria();
        }
        /// <summary>
        /// Listado de centrales para Osinergmin
        /// </summary>
        /// <returns></returns>
        public List<EqEquipoDTO> ListadoCentralesOsinergmin()
        {
            return FactorySic.GetEqEquipoRepository().ListadoCentralesOsinergmin();
        }

        /// <summary>
        /// Listado de Equipos por filtro de Empresa, Familia, Tipo Empresa y Estado Equipo
        /// </summary>
        /// <param name="idEmpresa">Código Empresa</param>
        /// <param name="sEstado">Estado de Equipo</param>
        /// <param name="idTipoEquipo">Código Familia</param>
        /// <param name="idTipoEmpresa">Código Tipo Empresa</param>
        /// <param name="sNombreEquipo">Nombre de Equipo</param>
        /// <param name="idPadre">Código Padre Equipo * Usar -99 para evitar este filtro*</param>
        /// <returns></returns>
        public List<EqEquipoDTO> ListarEquiposxFiltro(int idEmpresa, string sEstado, int idTipoEquipo, int idTipoEmpresa,
            string sNombreEquipo, int idPadre)
        {
            return FactorySic.GetEqEquipoRepository()
                .ListarEquiposxFiltro(idEmpresa, sEstado, idTipoEquipo, idTipoEmpresa, sNombreEquipo, idPadre);
        }
        /// <summary>
        /// Listado de Equipos filtrado por nombre.
        /// Datos solo de tabla Equipo
        /// </summary>
        /// <param name="coincidencia">Nombre del Equipo</param>
        /// <param name="nroPagina">N° de página</param>
        /// <param name="nroFilas">N° de Filas</param>
        /// <returns></returns>
        public List<EqEquipoDTO> BuscarEquipoxNombre(string coincidencia, int nroPagina, int nroFilas)
        {
            return FactorySic.GetEqEquipoRepository().BuscarEquipoxNombre(coincidencia, nroPagina, nroFilas);
        }

        /// <summary>
        /// Listado de Equipos filtrado por varias familias.
        /// Datos de Equipo, Familia, Empresa y Area
        /// </summary>
        /// <param name="iCodFamilias">Código de Familias</param>
        /// <returns></returns>
        public List<EqEquipoDTO> ListarEquipoxFamilias(params int[] iCodFamilias)
        {
            return FactorySic.GetEqEquipoRepository().ListarEquipoxFamilias(iCodFamilias);
        }

        #endregion

        #region Métodos Tabla EQ_AREA

        /// <summary>
        /// Inserta un registro de la tabla EQ_AREA
        /// </summary>
        public void SaveEqArea(EqAreaDTO entity)
        {
            try
            {
                FactorySic.GetEqAreaRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_AREA
        /// </summary>
        public void UpdateEqArea(EqAreaDTO entity)
        {
            try
            {
                FactorySic.GetEqAreaRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_AREA
        /// </summary>
        public void DeleteEqArea(int areacodi)
        {
            try
            {
                FactorySic.GetEqAreaRepository().Delete(areacodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_AREA
        /// </summary>
        public EqAreaDTO GetByIdEqArea(int areacodi)
        {
            return FactorySic.GetEqAreaRepository().GetById(areacodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_AREA
        /// </summary>
        public List<EqAreaDTO> ListEqAreas()
        {
            return FactorySic.GetEqAreaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqArea
        /// </summary>
        public List<EqAreaDTO> GetByCriteriaEqAreas()
        {
            return FactorySic.GetEqAreaRepository().GetByCriteria();
        }

        /// <summary>
        /// Listado de áreas filtradas por tipo de área y nombre de área
        /// </summary>
        /// <param name="idTipoArea">Id de Tipo de Área, para evitar este filtro usar -99</param>
        /// <param name="strNombreArea">Nombre de Área</param>
        /// <param name="nroPagina">Cantidad de Página</param>
        /// <param name="nroFilas">Cantidad de Registros por Página</param>
        /// <returns></returns>
        public List<EqAreaDTO> ListarxFiltro(int idTipoArea, string strNombreArea, int nroPagina, int nroFilas)
        {
            return FactorySic.GetEqAreaRepository().ListarxFiltro(idTipoArea, strNombreArea, nroPagina, nroFilas);
        }

        /// <summary>
        /// Obtiene la cantidad total de resultados de la Consulta ListarxFiltro
        /// </summary>
        /// <param name="idTipoArea">Id de Tipo de Área, para evitar este filtro usar -99</param>
        /// <param name="strNombreArea">Nombre de Área</param>
        /// <returns></returns>
        public int CantidadListarxFiltro(int idTipoArea, string strNombreArea)
        {
            return FactorySic.GetEqAreaRepository().CantidadListarxFiltro(idTipoArea, strNombreArea);
        }

        #endregion

        #region Métodos Tabla EQ_EQUIREL

        /// <summary>
        /// Inserta un registro de la tabla EQ_EQUIREL
        /// </summary>
        public void SaveEqEquirel(EqEquirelDTO entity)
        {
            try
            {
                FactorySic.GetEqEquirelRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_EQUIREL
        /// </summary>
        public void UpdateEqEquirel(EqEquirelDTO entity)
        {
            try
            {
                FactorySic.GetEqEquirelRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_EQUIREL
        /// </summary>
        public void DeleteEqEquirel(int equicodi1, int tiporelcodi, int equicodi2)
        {
            try
            {
                FactorySic.GetEqEquirelRepository().Delete(equicodi1, tiporelcodi, equicodi2);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_EQUIREL
        /// </summary>
        public EqEquirelDTO GetByIdEqEquirel(int equicodi1, int tiporelcodi, int equicodi2)
        {
            return FactorySic.GetEqEquirelRepository().GetById(equicodi1, tiporelcodi, equicodi2);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_EQUIREL
        /// </summary>
        public List<EqEquirelDTO> ListEqEquirels()
        {
            return FactorySic.GetEqEquirelRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqEquirel
        /// </summary>
        public List<EqEquirelDTO> GetByCriteriaEqEquirels()
        {
            return FactorySic.GetEqEquirelRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla EQ_FAMREL

        /// <summary>
        /// Inserta un registro de la tabla EQ_FAMREL
        /// </summary>
        public void SaveEqFamrel(EqFamrelDTO entity)
        {
            try
            {
                FactorySic.GetEqFamrelRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_FAMREL
        /// </summary>
        public void UpdateEqFamrel(EqFamrelDTO entity)
        {
            try
            {
                FactorySic.GetEqFamrelRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_FAMREL
        /// </summary>
        public void DeleteEqFamrel(int tiporelcodi, int famcodi1, int famcodi2)
        {
            try
            {
                FactorySic.GetEqFamrelRepository().Delete(tiporelcodi, famcodi1, famcodi2);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_FAMREL
        /// </summary>
        public EqFamrelDTO GetByIdEqFamrel(int tiporelcodi, int famcodi1, int famcodi2)
        {
            return FactorySic.GetEqFamrelRepository().GetById(tiporelcodi, famcodi1, famcodi2);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_FAMREL
        /// </summary>
        public List<EqFamrelDTO> ListEqFamrels()
        {
            return FactorySic.GetEqFamrelRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqFamrel
        /// </summary>
        public List<EqFamrelDTO> GetByCriteriaEqFamrels()
        {
            return FactorySic.GetEqFamrelRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla EQ_PROPEQUI

        /// <summary>
        /// Inserta un registro de la tabla EQ_PROPEQUI
        /// </summary>
        public void SaveEqPropequi(EqPropequiDTO entity)
        {
            try
            {
                FactorySic.GetEqPropequiRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_PROPEQUI
        /// </summary>
        public void UpdateEqPropequi(EqPropequiDTO entity)
        {
            try
            {
                FactorySic.GetEqPropequiRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_PROPEQUI
        /// </summary>
        public void DeleteEqPropequi(int propcodi, int equicodi, DateTime fechapropequi)
        {
            try
            {
                FactorySic.GetEqPropequiRepository().Delete(propcodi, equicodi, fechapropequi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_PROPEQUI
        /// </summary>
        public EqPropequiDTO GetByIdEqPropequi(int propcodi, int equicodi, DateTime fechapropequi)
        {
            try
            {
                return FactorySic.GetEqPropequiRepository().GetById(propcodi, equicodi, fechapropequi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_PROPEQUI
        /// </summary>
        public List<EqPropequiDTO> ListEqPropequis()
        {
            try
            {
                return FactorySic.GetEqPropequiRepository().List();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqPropequi
        /// </summary>
        public List<EqPropequiDTO> GetByCriteriaEqPropequis()
        {
            try
            {
                return FactorySic.GetEqPropequiRepository().GetByCriteria();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public List<PropiedadEquipoHistDTO> ListarDatosPropiedadesFichaTecnicaVigentesxEquipo(int iEquipo)
        {
            try
            {
                var oEquipo = FactorySic.GetEqEquipoRepository().GetById(iEquipo);
                return FactorySic.GetEqPropequiRepository()
                    .ListarDatosPropiedadesFichaTecnicaVigentesxEquipo(iEquipo, oEquipo.Famcodi.Value);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
            
        }

        #endregion

        #region Métodos Tabla EQ_PROPIEDAD

        /// <summary>
        /// Inserta un registro de la tabla EQ_PROPIEDAD
        /// </summary>
        public void SaveEqPropiedad(EqPropiedadDTO entity)
        {
            try
            {
                FactorySic.GetEqPropiedadRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_PROPIEDAD
        /// </summary>
        public void UpdateEqPropiedad(EqPropiedadDTO entity)
        {
            try
            {
                FactorySic.GetEqPropiedadRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_PROPIEDAD
        /// </summary>
        public void DeleteEqPropiedad(int propcodi)
        {
            try
            {
                FactorySic.GetEqPropiedadRepository().Delete(propcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_PROPIEDAD
        /// </summary>
        public EqPropiedadDTO GetByIdEqPropiedad(int propcodi)
        {
            return FactorySic.GetEqPropiedadRepository().GetById(propcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_PROPIEDAD
        /// </summary>
        public List<EqPropiedadDTO> ListEqPropiedads()
        {
            return FactorySic.GetEqPropiedadRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqPropiedad
        /// </summary>
        public List<EqPropiedadDTO> GetByCriteriaEqPropiedads()
        {
            return FactorySic.GetEqPropiedadRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla EQ_RELACION

        /// <summary>
        /// Inserta un registro de la tabla EQ_RELACION
        /// </summary>
        public void SaveEqRelacion(EqRelacionDTO entity)
        {
            try
            {
                FactorySic.GetEqRelacionRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_RELACION
        /// </summary>
        public void UpdateEqRelacion(EqRelacionDTO entity)
        {
            try
            {
                FactorySic.GetEqRelacionRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_RELACION
        /// </summary>
        public void DeleteEqRelacion(int relacioncodi)
        {
            try
            {
                FactorySic.GetEqRelacionRepository().Delete(relacioncodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_RELACION
        /// </summary>
        public EqRelacionDTO GetByIdEqRelacion(int relacioncodi)
        {
            return FactorySic.GetEqRelacionRepository().GetById(relacioncodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_RELACION
        /// </summary>
        public List<EqRelacionDTO> ListEqRelacions()
        {
            return FactorySic.GetEqRelacionRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqRelacion
        /// </summary>
        public List<EqRelacionDTO> GetByCriteriaEqRelacions()
        {
            return FactorySic.GetEqRelacionRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla EQ_TIPOAREA

        /// <summary>
        /// Inserta un registro de la tabla EQ_TIPOAREA
        /// </summary>
        public void SaveEqTipoarea(EqTipoareaDTO entity)
        {
            try
            {
                FactorySic.GetEqTipoareaRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_TIPOAREA
        /// </summary>
        public void UpdateEqTipoarea(EqTipoareaDTO entity)
        {
            try
            {
                FactorySic.GetEqTipoareaRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_TIPOAREA
        /// </summary>
        public void DeleteEqTipoarea(int tareacodi)
        {
            try
            {
                FactorySic.GetEqTipoareaRepository().Delete(tareacodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_TIPOAREA
        /// </summary>
        public EqTipoareaDTO GetByIdEqTipoarea(int tareacodi)
        {
            return FactorySic.GetEqTipoareaRepository().GetById(tareacodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_TIPOAREA
        /// </summary>
        public List<EqTipoareaDTO> ListEqTipoareas()
        {
            return FactorySic.GetEqTipoareaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqTipoarea
        /// </summary>
        public List<EqTipoareaDTO> GetByCriteriaEqTipoareas()
        {
            return FactorySic.GetEqTipoareaRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla EQ_TIPOREL

        /// <summary>
        /// Inserta un registro de la tabla EQ_TIPOREL
        /// </summary>
        public void SaveEqTiporel(EqTiporelDTO entity)
        {
            try
            {
                FactorySic.GetEqTiporelRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_TIPOREL
        /// </summary>
        public void UpdateEqTiporel(EqTiporelDTO entity)
        {
            try
            {
                FactorySic.GetEqTiporelRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_TIPOREL
        /// </summary>
        public void DeleteEqTiporel(int tiporelcodi)
        {
            try
            {
                FactorySic.GetEqTiporelRepository().Delete(tiporelcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_TIPOREL
        /// </summary>
        public EqTiporelDTO GetByIdEqTiporel(int tiporelcodi)
        {
            return FactorySic.GetEqTiporelRepository().GetById(tiporelcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_TIPOREL
        /// </summary>
        public List<EqTiporelDTO> ListEqTiporels()
        {
            return FactorySic.GetEqTiporelRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqTiporel
        /// </summary>
        public List<EqTiporelDTO> GetByCriteriaEqTiporels()
        {
            return FactorySic.GetEqTiporelRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla PR_CONCEPTO

        /// <summary>
        /// Inserta un registro de la tabla PR_CONCEPTO
        /// </summary>
        public void SavePrConcepto(PrConceptoDTO entity)
        {
            try
            {
                FactorySic.GetPrConceptoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla PR_CONCEPTO
        /// </summary>
        public void UpdatePrConcepto(PrConceptoDTO entity)
        {
            try
            {
                FactorySic.GetPrConceptoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla PR_CONCEPTO
        /// </summary>
        public void DeletePrConcepto(int concepcodi)
        {
            try
            {
                FactorySic.GetPrConceptoRepository().Delete(concepcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla PR_CONCEPTO
        /// </summary>
        public PrConceptoDTO GetByIdPrConcepto(int concepcodi)
        {
            return FactorySic.GetPrConceptoRepository().GetById(concepcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla PR_CONCEPTO
        /// </summary>
        public List<PrConceptoDTO> ListPrConceptos()
        {
            return FactorySic.GetPrConceptoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla PrConcepto
        /// </summary>
        public List<PrConceptoDTO> GetByCriteriaPrConceptos()
        {
            return FactorySic.GetPrConceptoRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla PR_GRUPODAT

        /// <summary>
        /// Inserta un registro de la tabla PR_GRUPODAT
        /// </summary>
        public void SavePrGrupodat(PrGrupodatDTO entity)
        {
            try
            {
                FactorySic.GetPrGrupodatRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla PR_GRUPODAT
        /// </summary>
        public void UpdatePrGrupodat(PrGrupodatDTO entity)
        {
            try
            {
                FactorySic.GetPrGrupodatRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla PR_GRUPODAT
        /// </summary>
        public void DeletePrGrupodat(DateTime fechadat, int concepcodi, int grupocodi, int deleted)
        {
            try
            {
                FactorySic.GetPrGrupodatRepository().Delete(fechadat, concepcodi, grupocodi, deleted);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla PR_GRUPODAT
        /// </summary>
        public PrGrupodatDTO GetByIdPrGrupodat(DateTime fechadat, int concepcodi, int grupocodi, int deleted)
        {
            return FactorySic.GetPrGrupodatRepository().GetById(fechadat, concepcodi, grupocodi, deleted);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla PR_GRUPODAT
        /// </summary>
        public List<PrGrupodatDTO> ListPrGrupodats()
        {
            return FactorySic.GetPrGrupodatRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla PrGrupodat
        /// </summary>
        public List<PrGrupodatDTO> GetByCriteriaPrGrupodats()
        {
            return FactorySic.GetPrGrupodatRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla PR_EQUIPODAT

        /// <summary>
        /// Inserta un registro de la tabla PR_EQUIPODAT
        /// </summary>
        public void SavePrEquipodat(PrEquipodatDTO entity)
        {
            try
            {
                FactorySic.GetPrEquipodatRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla PR_EQUIPODAT
        /// </summary>
        public void UpdatePrEquipodat(PrEquipodatDTO entity)
        {
            try
            {
                FactorySic.GetPrEquipodatRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla PR_EQUIPODAT
        /// </summary>
        public void DeletePrEquipodat(int equicodi, int grupocodi, int concepcodi, DateTime fechadat)
        {
            try
            {
                FactorySic.GetPrEquipodatRepository().Delete(equicodi, grupocodi, concepcodi, fechadat);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla PR_EQUIPODAT
        /// </summary>
        public PrEquipodatDTO GetByIdPrEquipodat(int equicodi, int grupocodi, int concepcodi, DateTime fechadat)
        {
            return FactorySic.GetPrEquipodatRepository().GetById(equicodi, grupocodi, concepcodi, fechadat);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla PR_EQUIPODAT
        /// </summary>
        public List<PrEquipodatDTO> ListPrEquipodats()
        {
            return FactorySic.GetPrEquipodatRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla PrEquipodat
        /// </summary>
        public List<PrEquipodatDTO> GetByCriteriaPrEquipodats()
        {
            return FactorySic.GetPrEquipodatRepository().GetByCriteria();
        }

        #endregion
    }
}
