using System;
using System.Collections.Generic;
using System.Linq;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using log4net;

namespace COES.Servicios.Aplicacion.Equipamiento
{
    /// <summary>
    /// Clases con métodos del módulo Despacho
    /// </summary>
    public class DespachoAppServicio : AppServicioBase
    {
        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DespachoAppServicio));

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

     

        #endregion

        /// <summary>
        /// Listado de Grupo de generación de despacho para osinergmin
        /// </summary>
        public List<GrupoGeneracionDTO> ListarGeneradoresDespachoOsinergmin()
        {
            return FactorySic.GetPrGrupoRepository().ListarGeneradoresDespachoOsinergmin();
        }

        public List<PrGrupoDTO> ListaModosOperacionActivos()
        {
            return FactorySic.GetPrGrupoRepository().ListaModosOperacionActivos();
        }
        
        /// <summary>
        /// Obtener los grupos según tipo de categoria
        /// </summary>
        /// <param name="tipoGrupoCodi"></param>
        /// <returns></returns>
        public List<PrGrupoDTO> ObtenerMantenimientoGrupoRER(int tipoGrupoCodi)
        {
            return FactorySic.GetPrGrupoRepository().GetByCriteria(tipoGrupoCodi);
        }

        /// <summary>
        /// Permite actualizar el tipo del grupo seleccionados
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <param name="userName"></param>
        public void CambiarTipoGrupo(int idGrupo, int idTipoGrupo, string userName)
        {
            try
            {
                FactorySic.GetPrGrupoRepository().CambiarTipoGrupo(idGrupo, idTipoGrupo, userName, DateTime.Now);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Inserta un registro de la tabla PR_TIPOGRUPO
        /// </summary>
        public void SavePrTipogrupo(PrTipogrupoDTO entity)
        {
            try
            {
                FactorySic.GetPrTipogrupoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla PR_TIPOGRUPO
        /// </summary>
        public void UpdatePrTipogrupo(PrTipogrupoDTO entity)
        {
            try
            {
                FactorySic.GetPrTipogrupoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla PR_TIPOGRUPO
        /// </summary>
        public void DeletePrTipogrupo(int tipogrupocodi)
        {
            try
            {
                FactorySic.GetPrTipogrupoRepository().Delete(tipogrupocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla PR_TIPOGRUPO
        /// </summary>
        public PrTipogrupoDTO GetByIdPrTipogrupo(int tipogrupocodi)
        {
            return FactorySic.GetPrTipogrupoRepository().GetById(tipogrupocodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla PR_TIPOGRUPO
        /// </summary>
        public List<PrTipogrupoDTO> ListPrTipogrupos()
        {
            return FactorySic.GetPrTipogrupoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla PrTipogrupo
        /// </summary>
        public List<PrTipogrupoDTO> GetByCriteriaPrTipogrupos()
        {
            return FactorySic.GetPrTipogrupoRepository().GetByCriteria();
        }

        public List<ModoOperacionDTO> ListadoModosOperacionPorCentral(int iCentral)
        {
            try
            {
                var resultado = FactorySic.GetPrGrupoRepository().ModoOperacionCentral1(iCentral);
                var resultadoNuevo = FactorySic.GetPrGrupoRepository().ModoOperacionCentral2(iCentral);

                int NumNuevos = 0;
                int NumAntiguos = resultado.Count();

                var ResultadoFinal = new List<ModoOperacionDTO>(); ;
                if (resultadoNuevo != null)
                {
                    NumNuevos = resultadoNuevo.Count();
                }

                if (NumAntiguos > NumNuevos)
                {
                    ResultadoFinal = resultado.ToList();
                    //Logica para fusionar la lista de modos Originales con los Nuevos, en caso existan datos en los Modos Nuevos
                    if (NumNuevos > 0)
                    {
                        var NuevosGrupos = resultadoNuevo.ToList();
                        foreach (var NewGroup in NuevosGrupos)
                        {
                            var indiceBusqueda = ResultadoFinal.FindIndex(go => go.GRUPOCODI == NewGroup.GRUPOCODI);
                            if (indiceBusqueda > -1)
                            {
                                ResultadoFinal[indiceBusqueda].EQUICODI = NewGroup.EQUICODI;
                            }
                        }
                    }
                }
                if (NumAntiguos < NumNuevos)
                {
                    ResultadoFinal = resultadoNuevo.ToList();
                }
                if (NumNuevos == NumAntiguos)
                {
                    ResultadoFinal = resultadoNuevo.ToList();
                }

                //var lsResultadoReturn = new List<ModoOperacionDTO>();
                foreach (var grupo in ResultadoFinal)
                {
                    var Modo = FactorySic.GetPrGrupoRepository().GetById(grupo.GRUPOCODI);//  _prEquipoDatRepository.Context.PR_GRUPO.Single(grup => grup.GRUPOCODI == grupo.GRUPOCODI);
                    grupo.IDCENTRAL = iCentral.ToString();
                    if (grupo.EQUICODI > -1)
                    {
                        var equipo = FactorySic.GetEqEquipoRepository().GetById(grupo.EQUICODI);// _prEquipoDatRepository.Context.EQ_EQUIPO.Single(eq => eq.EQUICODI == grupo.EQUICODI);
                        string EquipoComb = "";
                        if (equipo.Equiabrev.Trim() == "TV")
                        {
                            EquipoComb = "CC";
                        }
                        else
                        {
                            EquipoComb = equipo.Equiabrev.Trim();
                        }
                        EquipoComb = EquipoComb + " " + Modo.Grupocomb.Trim();
                        grupo.GRUPONOM = EquipoComb;
                        grupo.MODONOM = Modo.Gruponomb.Trim();
                        //ResultadoFinal.IndexOf(grupo);
                    }
                    else
                    {
                        grupo.GRUPONOM = Modo.Grupoabrev.Trim();
                    }
                }

                return ResultadoFinal;
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public int ObtenerCodigoModoOperacionPadre(int iPrGrupo)
        {
            try
            {
                return FactorySic.GetPrGrupoRepository().ObtenerCodigoModoOperacionPadre(iPrGrupo);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public List<ConceptoDatoDTO> ListadoValoresModoOperacion(int iEquiCodi, int iGrupoCodi)
        {
            try
            {
                IEnumerable<ConceptoDatoDTO> ResultadoGrupoDat;
                IEnumerable<ConceptoDatoDTO> ResultadoEquipoDat = null; ;
                var ConceptoCentral = new ConceptoDatoDTO();
                ConceptoCentral.CONCEPCODI = -99;
                if (iEquiCodi > -1)
                {
                    ResultadoGrupoDat = FactorySic.GetPrGrupodatRepository().ListarDatosConceptoGrupoDat(iGrupoCodi);// _prEquipoDatRepository.Context.Database.SqlQuery<ConceptoDatoDTO>("select distinct gd.concepcodi,fn_sdatoactualconcepto(gd.grupocodi,gd.concepcodi) valor ,c.concepunid from pr_grupodat gd inner join pr_concepto c on gd.concepcodi=c.concepcodi where gd.grupocodi=:p0", iGrupoCodi);

                    ResultadoEquipoDat = FactorySic.GetPrEquipodatRepository().ListarDatosConceptoEquipoDat(iEquiCodi, iGrupoCodi);
                    // _prEquipoDatRepository.Context.Database.SqlQuery<ConceptoDatoDTO>("select distinct ed.concepcodi,FN_SDATOACTUALEQUIPODAT(ed.grupocodi,ed.concepcodi,ed.equicodi) valor,c.concepunid from pr_equipodat ed inner join pr_concepto c on c.concepcodi=ed.concepcodi where ed.grupocodi=:p0 and ed.equicodi=:p1", iGrupoCodi, iEquiCodi);
                }
                else
                {
                    ResultadoGrupoDat = FactorySic.GetPrGrupodatRepository().ListarDatosConceptoGrupoDat(iGrupoCodi);
                    //ResultadoGrupoDat = _prEquipoDatRepository.Context.Database.SqlQuery<ConceptoDatoDTO>("select distinct gd.concepcodi,fn_sdatoactualconcepto(gd.grupocodi,gd.concepcodi) valor ,c.concepunid from pr_grupodat gd inner join pr_concepto c on gd.concepcodi=c.concepcodi where gd.grupocodi=:p0", iGrupoCodi);
                }

                var ResultadoFinal = ResultadoGrupoDat.ToList();
                if (iEquiCodi > -1)
                {
                    var ResultadoEquipoDato = ResultadoEquipoDat.ToList();
                    foreach (var ConceptoDatoDTO in ResultadoEquipoDato)
                    {
                        var Existe = ResultadoFinal.FindIndex(concep => concep.CONCEPCODI == ConceptoDatoDTO.CONCEPCODI);
                        if (Existe == -1)
                        {
                            ResultadoFinal.Add(ConceptoDatoDTO);
                        }
                        else
                        {
                            ResultadoFinal[Existe].VALOR = ConceptoDatoDTO.VALOR;
                        }
                    }
                    var equipo = FactorySic.GetEqEquipoRepository().GetById(iEquiCodi);// _prEquipoDatRepository.Context.EQ_EQUIPO.Single(eq => eq.EQUICODI == iEquiCodi);
                    var Modo = FactorySic.GetPrGrupoRepository().GetById(iGrupoCodi); //_prEquipoDatRepository.Context.PR_GRUPO.Single(grup => grup.GRUPOCODI == iGrupoCodi);

                    ConceptoCentral.VALOR = (equipo.Equiabrev.Trim() + " " + Modo.Grupocomb).Trim();

                }
                else
                {
                    //var Modo = _prEquipoDatRepository.Context.PR_GRUPO.Single(grup => grup.GRUPOCODI == iGrupoCodi);
                    var Modo = FactorySic.GetPrGrupoRepository().GetById(iGrupoCodi);
                    ConceptoCentral.VALOR = Modo.Gruponomb;
                }
                ResultadoFinal.Add(ConceptoCentral);
                return ResultadoFinal;
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
