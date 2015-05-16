using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using log4net;

namespace COES.Servicios.Aplicacion.General
{
    /// <summary>
    /// Clases con métodos del módulo GENERAL
    /// </summary>
    public class GeneralAppServicio : AppServicioBase
    {
        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(GeneralAppServicio));

        ///// <summary>
        ///// Inserta o actualiza un registro de empresas
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public int SaveOrUpdateEmpresa(EmpresaDTO entity)
        //{
        //    try
        //    {
        //        int id = 0;

        //        if (entity.Emprcodi == 0)
        //        {
        //            id = FactorySic.GetEmpresaRepository().Save(entity);
        //        }
        //        else
        //        {
        //            FactorySic.GetEmpresaRepository().Update(entity);
        //            id = entity.Emprcodi;
        //        }

        //        return id;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(Constantes.LogError, ex);
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        ///// <summary>
        ///// Elimina una empresa en base al id
        ///// </summary>
        ///// <param name="idEmpresa"></param>
        //public void DeleteEmpresa(int idEmpresa)
        //{
        //    try
        //    {
        //        FactorySic.GetEmpresaRepository().Delete(idEmpresa);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        ///// <summary>
        ///// Permite obtener la empresa en base al id
        ///// </summary>
        ///// <param name="idEmpresa"></param>
        ///// <returns></returns>
        //public EmpresaDTO GetByIdEmpresa(int idEmpresa)
        //{
        //    return FactorySic.GetEmpresaRepository().GetById(idEmpresa);
        //}

        ///// <summary>
        ///// Permite listar todas las empresas
        ///// </summary>
        ///// <returns></returns>
        //public List<EmpresaDTO> ListEmpresas()
        //{
        //    return FactorySic.GetEmpresaRepository().List();
        //}

        ///// <summary>
        ///// Permite realizar búsquedas de empresas en base al nombre
        ///// </summary>
        ///// <param name="nombre"></param>
        ///// <returns></returns>
        //public List<EmpresaDTO> BuscarEmpresas(string nombre)
        //{
        //    return FactorySic.GetEmpresaRepository().GetByCriteria(nombre);
        //}

        /// <summary>
        /// Permite obtener un registro de la tabla SI_FUENTEENERGIA
        /// </summary>
        public SiFuenteenergiaDTO GetByIdSiFuenteenergia(int fenergcodi)
        {
            return FactorySic.GetSiFuenteenergiaRepository().GetById(fenergcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla SI_FUENTEENERGIA
        /// </summary>
        public List<SiFuenteenergiaDTO> ListSiFuenteenergias()
        {
            return FactorySic.GetSiFuenteenergiaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla SiFuenteenergia
        /// </summary>
        public List<SiFuenteenergiaDTO> GetByCriteriaSiFuenteenergias()
        {
            return FactorySic.GetSiFuenteenergiaRepository().GetByCriteria();
        }

        public List<SiEmpresaDTO> ListarEmpresasPorTipoEmpresa(int iTipoEmpresa)
        {
            return FactorySic.GetSiEmpresaRepository().List(iTipoEmpresa);
        }
    }
}
