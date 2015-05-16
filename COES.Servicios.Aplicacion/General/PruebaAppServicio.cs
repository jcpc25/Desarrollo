using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using log4net;

namespace COES.Servicios.Aplicacion.Prueba
{
    /// <summary>
    /// Clases con métodos del módulo Prueba
    /// </summary>
    public class PruebaAppServicio : AppServicioBase
    {
        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PruebaAppServicio));

        #region Métodos Tabla EQ_FAMILIA

        /// <summary>
        /// Inserta un registro de la tabla EQ_FAMILIA
        /// </summary>
        public void SaveEqFamilia(EqFamiliaDTO entity)
        {
            try
            {
                FactorySic.GetEqFamiliaRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EQ_FAMILIA
        /// </summary>
        public void UpdateEqFamilia(EqFamiliaDTO entity)
        {
            try
            {
                FactorySic.GetEqFamiliaRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EQ_FAMILIA
        /// </summary>
        public void DeleteEqFamilia(int famcodi)
        {
            try
            {
                FactorySic.GetEqFamiliaRepository().Delete(famcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EQ_FAMILIA
        /// </summary>
        public EqFamiliaDTO GetByIdEqFamilia(int famcodi)
        {
            return FactorySic.GetEqFamiliaRepository().GetById(famcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EQ_FAMILIA
        /// </summary>
        public List<EqFamiliaDTO> ListEqFamilias()
        {
            return FactorySic.GetEqFamiliaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla EqFamilia
        /// </summary>
        public List<EqFamiliaDTO> GetByCriteriaEqFamilias()
        {
            return FactorySic.GetEqFamiliaRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla ME_MEDICION48

        /// <summary>
        /// Inserta un registro de la tabla ME_MEDICION48
        /// </summary>
        public void SaveMeMedicion48(MeMedicion48DTO entity)
        {
            try
            {
                FactorySic.GetMeMedicion48Repository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_MEDICION48
        /// </summary>
        public void UpdateMeMedicion48(MeMedicion48DTO entity)
        {
            try
            {
                FactorySic.GetMeMedicion48Repository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_MEDICION48
        /// </summary>
        public void DeleteMeMedicion48(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi)
        {
            try
            {
                FactorySic.GetMeMedicion48Repository().Delete(lectcodi, medifecha, tipoinfocodi, ptomedicodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_MEDICION48
        /// </summary>
        public MeMedicion48DTO GetByIdMeMedicion48(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi)
        {
            return FactorySic.GetMeMedicion48Repository().GetById(lectcodi, medifecha, tipoinfocodi, ptomedicodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_MEDICION48
        /// </summary>
        public List<MeMedicion48DTO> ListMeMedicion48s()
        {
            return FactorySic.GetMeMedicion48Repository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeMedicion48
        /// </summary>
        public List<MeMedicion48DTO> GetByCriteriaMeMedicion48s()
        {
            return FactorySic.GetMeMedicion48Repository().GetByCriteria();
        }

        #endregion

    }
}
