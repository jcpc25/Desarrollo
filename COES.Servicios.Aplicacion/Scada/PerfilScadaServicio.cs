﻿using System;
using System.Collections.Generic;
using System.Linq;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using System.Globalization;

namespace COES.Servicios.Aplicacion.Scada
{
    public class PerfilScadaServicio : AppServicioBase
    {
        public List<FormulaItem> ListaItemFormula = new List<FormulaItem>();
        public List<ScadaDTO> ListaValores = new List<ScadaDTO>();
        
        /// <summary>
        /// Permite listar las formular por usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<EjecutadoRuleDTO> ListarFormulaPorUsuario(string userName)
        {
            return FactorySic.ObtenerEjecutadoRuleDao().ListarFormulaPorUsuario(userName);
        }   
        
        /// <summary>
        /// Obtiene los datos necesarios para realizar los cálculos
        /// </summary>
        /// <param name="formulas"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public List<ScadaDTO> ObtenerDatosProceso(List<MePerfilRuleDTO> formulas, DateTime fechaInicio, DateTime fechaFin, string fuente)
        {
            #region Obtencion de Fórmulas

            foreach (MePerfilRuleDTO item in formulas)
            {
                this.DescomponerFormula(item.Prruformula);
            }

            List<FormulaItem> listScada = this.ListaItemFormula.Where(x => x.Tipo == ConstanteFormulaScada.Scada.ToString()).ToList();
            List<FormulaItem> listMedic = this.ListaItemFormula.Where(x => x.Tipo == ConstanteFormulaScada.Medicion.ToString()).ToList();

            string whereScada = string.Empty;
            int i = 0;
            foreach (FormulaItem item in listScada)
            {
                whereScada = whereScada + item.Codigo + ((i < listScada.Count - 1) ? ConstanteFormulaScada.CaracterComa : string.Empty);
                i++;
            }

            string whereMedicion = string.Empty;
            i = 0;
            foreach (FormulaItem item in listMedic)
            {
                whereMedicion = whereMedicion + item.Codigo + ((i < listMedic.Count - 1) ? ConstanteFormulaScada.CaracterComa : string.Empty);
                i++;
            }

            if (!string.IsNullOrEmpty(whereScada))
                this.ListaValores.AddRange(FactorySic.ObtenerScadaTRDao().ObtenerConsultaScada(whereScada, fechaInicio, fechaFin));
            if (!string.IsNullOrEmpty(whereMedicion))
            {
                int lectcodi = 0;
                int tipoinfocodi = 0;

                if (fuente == ConstanteFormulaScada.FuenteDemanda)                 
                {
                    lectcodi = 45;
                    tipoinfocodi = 20;
                }
                if (fuente == ConstanteFormulaScada.FuenteEjecutado)
                {
                    lectcodi = 6;
                    tipoinfocodi = 1;
                }

                this.ListaValores.AddRange(FactorySic.ObtenerScadaSICDao().ObtenerConsultaMedicion(whereMedicion, fechaInicio, fechaFin, 
                    lectcodi, tipoinfocodi));
            }

            #endregion

            List<ScadaDTO> resultado = new List<ScadaDTO>();
            int nroDias = Convert.ToInt32((fechaFin.Subtract(fechaInicio)).TotalDays);

            for (int t = 0; t <= nroDias; t++)
            {
                DateTime fecha = fechaInicio.AddDays(t);
                ScadaDTO entity = new ScadaDTO();
                entity.MEDIFECHA = fecha;
                entity.CLASIFICACION = this.ObtenerClasificacion(fecha);
                entity.INDICADOR = ConstanteFormulaScada.SI;

                decimal h2 = 0, h4 = 0, h6 = 0, h8 = 0, h10 = 0;
                decimal h12 = 0, h14 = 0, h16 = 0, h18 = 0, h20 = 0;
                decimal h22 = 0, h24 = 0, h26 = 0, h28 = 0, h30 = 0;
                decimal h32 = 0, h34 = 0, h36 = 0, h38 = 0, h40 = 0;
                decimal h42 = 0, h44 = 0, h46 = 0, h48 = 0, h50 = 0;
                decimal h52 = 0, h54 = 0, h56 = 0, h58 = 0, h60 = 0;
                decimal h62 = 0, h64 = 0, h66 = 0, h68 = 0, h70 = 0;
                decimal h72 = 0, h74 = 0, h76 = 0, h78 = 0, h80 = 0;
                decimal h82 = 0, h84 = 0, h86 = 0, h88 = 0, h90 = 0;
                decimal h92 = 0, h94 = 0, h96 = 0;
               

                foreach (FormulaItem item in this.ListaItemFormula)
                {
                    ScadaDTO formula = this.ObtenerValorFormula(item, fecha);

                    if (formula != null)
                    {
                        #region Mapeo de Campos

                        h2 = h2 + ((formula.H2 != null) ? (decimal)formula.H2 : 0) * item.Constante;
                        h4 = h4 + ((formula.H4 != null) ? (decimal)formula.H4 : 0) * item.Constante;
                        h6 = h6 + ((formula.H6 != null) ? (decimal)formula.H6 : 0) * item.Constante;
                        h8 = h8 + ((formula.H8 != null) ? (decimal)formula.H8 : 0) * item.Constante;
                        h10 = h10 + ((formula.H10 != null) ? (decimal)formula.H10 : 0) * item.Constante;
                        h12 = h12 + ((formula.H12 != null) ? (decimal)formula.H12 : 0) * item.Constante;
                        h14 = h14 + ((formula.H14 != null) ? (decimal)formula.H14 : 0) * item.Constante;
                        h16 = h16 + ((formula.H16 != null) ? (decimal)formula.H16 : 0) * item.Constante;
                        h18 = h18 + ((formula.H18 != null) ? (decimal)formula.H18 : 0) * item.Constante;
                        h20 = h20 + ((formula.H20 != null) ? (decimal)formula.H20 : 0) * item.Constante;
                        h22 = h22 + ((formula.H22 != null) ? (decimal)formula.H22 : 0) * item.Constante;
                        h24 = h24 + ((formula.H24 != null) ? (decimal)formula.H24 : 0) * item.Constante;
                        h26 = h26 + ((formula.H26 != null) ? (decimal)formula.H26 : 0) * item.Constante;
                        h28 = h28 + ((formula.H28 != null) ? (decimal)formula.H28 : 0) * item.Constante;
                        h30 = h30 + ((formula.H30 != null) ? (decimal)formula.H30 : 0) * item.Constante;
                        h32 = h32 + ((formula.H32 != null) ? (decimal)formula.H32 : 0) * item.Constante;
                        h34 = h34 + ((formula.H34 != null) ? (decimal)formula.H34 : 0) * item.Constante;
                        h36 = h36 + ((formula.H36 != null) ? (decimal)formula.H36 : 0) * item.Constante;
                        h38 = h38 + ((formula.H38 != null) ? (decimal)formula.H38 : 0) * item.Constante;
                        h40 = h40 + ((formula.H40 != null) ? (decimal)formula.H40 : 0) * item.Constante;
                        h42 = h42 + ((formula.H42 != null) ? (decimal)formula.H42 : 0) * item.Constante;
                        h44 = h44 + ((formula.H44 != null) ? (decimal)formula.H44 : 0) * item.Constante;
                        h46 = h46 + ((formula.H46 != null) ? (decimal)formula.H46 : 0) * item.Constante;
                        h48 = h48 + ((formula.H48 != null) ? (decimal)formula.H48 : 0) * item.Constante;
                        h50 = h50 + ((formula.H50 != null) ? (decimal)formula.H50 : 0) * item.Constante;
                        h52 = h52 + ((formula.H52 != null) ? (decimal)formula.H52 : 0) * item.Constante;
                        h54 = h54 + ((formula.H54 != null) ? (decimal)formula.H54 : 0) * item.Constante;
                        h56 = h56 + ((formula.H56 != null) ? (decimal)formula.H56 : 0) * item.Constante;
                        h58 = h58 + ((formula.H58 != null) ? (decimal)formula.H58 : 0) * item.Constante;
                        h60 = h60 + ((formula.H60 != null) ? (decimal)formula.H60 : 0) * item.Constante;
                        h62 = h62 + ((formula.H62 != null) ? (decimal)formula.H62 : 0) * item.Constante;
                        h64 = h64 + ((formula.H64 != null) ? (decimal)formula.H64 : 0) * item.Constante;
                        h66 = h66 + ((formula.H66 != null) ? (decimal)formula.H66 : 0) * item.Constante;
                        h68 = h68 + ((formula.H68 != null) ? (decimal)formula.H68 : 0) * item.Constante;
                        h70 = h70 + ((formula.H70 != null) ? (decimal)formula.H70 : 0) * item.Constante;
                        h72 = h72 + ((formula.H72 != null) ? (decimal)formula.H72 : 0) * item.Constante;
                        h74 = h74 + ((formula.H74 != null) ? (decimal)formula.H74 : 0) * item.Constante;
                        h76 = h76 + ((formula.H76 != null) ? (decimal)formula.H76 : 0) * item.Constante;
                        h78 = h78 + ((formula.H78 != null) ? (decimal)formula.H78 : 0) * item.Constante;
                        h80 = h80 + ((formula.H80 != null) ? (decimal)formula.H80 : 0) * item.Constante;
                        h82 = h82 + ((formula.H82 != null) ? (decimal)formula.H82 : 0) * item.Constante;
                        h84 = h84 + ((formula.H84 != null) ? (decimal)formula.H84 : 0) * item.Constante;
                        h86 = h86 + ((formula.H86 != null) ? (decimal)formula.H86 : 0) * item.Constante;
                        h88 = h88 + ((formula.H88 != null) ? (decimal)formula.H88 : 0) * item.Constante;
                        h90 = h90 + ((formula.H90 != null) ? (decimal)formula.H90 : 0) * item.Constante;
                        h92 = h92 + ((formula.H92 != null) ? (decimal)formula.H92 : 0) * item.Constante;
                        h94 = h94 + ((formula.H94 != null) ? (decimal)formula.H94 : 0) * item.Constante;
                        h96 = h96 + ((formula.H96 != null) ? (decimal)formula.H96 : 0) * item.Constante;

                        #endregion
                    }
                }

                entity.H2 = h2; entity.H4 = h4; entity.H6 = h6; entity.H8 = h8; entity.H10 = h10;
                entity.H12 = h12; entity.H14 = h14; entity.H16 = h16; entity.H18 = h18; entity.H20 = h20;
                entity.H22 = h22; entity.H24 = h24; entity.H26 = h26; entity.H28 = h28; entity.H30 = h30;
                entity.H32 = h32; entity.H34 = h34; entity.H36 = h36; entity.H38 = h38; entity.H40 = h40;
                entity.H42 = h42; entity.H44 = h44; entity.H46 = h46; entity.H48 = h48; entity.H50 = h50;
                entity.H52 = h52; entity.H54 = h54; entity.H56 = h56; entity.H58 = h58; entity.H60 = h60;
                entity.H62 = h62; entity.H64 = h64; entity.H66 = h66; entity.H68 = h68; entity.H70 = h70;
                entity.H72 = h72; entity.H74 = h74; entity.H76 = h76; entity.H78 = h78; entity.H80 = h80;
                entity.H82 = h82; entity.H84 = h84; entity.H86 = h86; entity.H88 = h88; entity.H90 = h90;
                entity.H92 = h92; entity.H94 = h94; entity.H96 = h96; 


                resultado.Add(entity);
            }

            return resultado;
        }

        /// <summary>
        /// Permite obtener el valor de una formula
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private ScadaDTO ObtenerValorFormula(FormulaItem item, DateTime fecha)
        {
            ScadaDTO entidad = this.ListaValores.Where(x => ((x.CANALCODI == item.Codigo && item.Tipo == ConstanteFormulaScada.Scada.ToString()) ||
                                        (x.PTOMEDICODI == item.Codigo && item.Tipo == ConstanteFormulaScada.Medicion.ToString())) 
                                        && x.MEDIFECHA == fecha).FirstOrDefault();

            if (entidad != null)
            {
                return entidad;
            }

            return null;
        }

        /// <summary>
        /// Permite obtener la clasificación de una fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        private int ObtenerClasificacion(DateTime fecha)
        {
            string dia = fecha.ToString("ddd", new CultureInfo("es-ES")).ToLower();

            if (dia == "mar" || dia == "mié" || dia == "jue" || dia == "vie") return 1;
            if (dia == "sáb") return 2;
            if (dia == "dom") return 3;
            if (dia == "lun") return 4;

            return 0;
        }

        /// <summary>
        /// Permite descomponer las formulas
        /// </summary>
        /// <param name="formula"></param>
        private void DescomponerFormula(string formula)
        {
            if (formula.Length > 0)
            {
                int posScada = formula.LastIndexOf(ConstanteFormulaScada.Scada);
                int posMedic = formula.LastIndexOf(ConstanteFormulaScada.Medicion);
                int pos = posMedic;
                char tipo = ConstanteFormulaScada.Medicion;
                if (posScada > posMedic)
                {
                    pos = posScada;
                    tipo = ConstanteFormulaScada.Scada;
                }

                string punto = formula.Substring(pos + 1, formula.Length - pos - 1);
                int posIni = formula.LastIndexOf(ConstanteFormulaScada.SeparadorFormula);
                string operador = formula.Substring(posIni + 1, pos - posIni - 1);

                this.ListaItemFormula.Add(new FormulaItem
                {
                    Codigo = int.Parse(punto),
                    Tipo = tipo.ToString(),
                    Constante = decimal.Parse(operador)
                });

                if (posIni >= 0)
                {
                    string newFormula = formula.Substring(0, posIni);
                    this.DescomponerFormula(newFormula);
                }
            }
        }

        /// <summary>
        /// Permite grabar los datos del perfil scada
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int GrabarPerfilScada(PerfilScadaDTO entity)
        {
            try
            {
                int id = FactorySic.ObtenerScadaSICDao().GrabarPerfil(entity);

                foreach (ScadaDTO item in entity.LISTADETALLE)
                {
                    item.PERFCODI = id;
                    FactorySic.ObtenerScadaSICDao().GrabarPerfilDetalle(item);
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener los datos del perfil almacenado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PerfilScadaDTO ObtenerPerfil(int id)
        {
            PerfilScadaDTO entity = FactorySic.ObtenerScadaSICDao().ObtenerPerfil(id);
            entity.LISTAITEMS = FactorySic.ObtenerScadaSICDao().ObtienePerfilDetalle(id);

            return entity;
        }

        /// <summary>
        /// Permite obtener la última fórmula si es que existiese
        /// </summary>
        /// <param name="idFormula"></param>
        /// <returns></returns>
        public PerfilScadaDTO ObtenerUltimoPerfil(int idFormula, int agrupacion)
        {
            PerfilScadaDTO entity = FactorySic.ObtenerScadaSICDao().ObtenerPerfilPorFormula(idFormula, agrupacion);

            if (entity != null)
            {
                entity.LISTAITEMS = FactorySic.ObtenerScadaSICDao().ObtienePerfilDetalle(entity.PERFCODI);
            }

            return entity;
        }

        /// <summary>
        /// Permite obtener los perfiles de un usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns></returns>
        public List<PerfilScadaDTO> ListarPerfilesPorUsuario(string username, DateTime inicio, DateTime fin, string fuente)
        {
            return FactorySic.ObtenerScadaSICDao().ListarPerfilesPorUsuario(username, inicio, fin, fuente);
        }

        /// <summary>
        /// Permite obtener el listado de perfiles para exportación
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<PerfilScadaDTO> ObtenerPerfilesExportacion(string username, int areaCode, string fuente)
        {
            List<PerfilScadaDTO> result = new List<PerfilScadaDTO>();

            List<PerfilScadaDTO> list = FactorySic.ObtenerScadaSICDao().ObtenerPerfilesExportacion(username, areaCode, fuente);            
            List<int> formulas = (from formula in list select formula.EJRUCODI).Distinct().ToList();

            foreach (int formula in formulas) 
            {
                bool flag = false;
                PerfilScadaDTO obj = new PerfilScadaDTO();
                List<PerfilScadaDetDTO> objDet = new List<PerfilScadaDetDTO>();

                for (int i = 1; i <= 4; i++)
                { 
                    var item = (from scada in list where scada.EJRUCODI == formula && scada.PERFCLASI == i 
                                orderby scada.PERFCODI descending select scada).FirstOrDefault();

                    if (item != null)
                    {
                        if (item.PERFCODI > 0)
                        {
                            if (!flag)
                            {
                                obj.PRRUNOMB = item.PRRUNOMB;
                                obj.PRRUABREV = item.PRRUABREV;
                                obj.LASTUSER = item.LASTUSER;

                                flag = true;
                            }

                            List<PerfilScadaDetDTO> listDet = FactorySic.ObtenerScadaSICDao().ObtienePerfilDetalle(item.PERFCODI);
                            objDet.AddRange(listDet);
                        }
                    }                    
                }

                if (!flag)
                { 
                    var item = (from scada in list where scada.EJRUCODI == formula select scada).FirstOrDefault();
                    if (item != null)
                    {
                        if (item.EJRUCODI > 0)
                        {
                            obj.PRRUNOMB = item.PRRUNOMB;
                            obj.PRRUABREV = item.PRRUABREV;
                            obj.LASTUSER = item.LASTUSER;
                        }
                    }
                }

                obj.LISTAITEMS = objDet;
                result.Add(obj);
            }         

            return result;
        }

        
        /**MANTENIMIENTO DE FORMULAS SCADA Y DEMANDA EN BARRAS**/
        /// <summary>
        /// Inserta un registro de la tabla ME_PERFIL_RULE
        /// </summary>
        public int GrabarMePerfilRule(MePerfilRuleDTO entity, List<string> roles)
        {
            try
            {
                int id = 0;
                entity.Prrulastdate = DateTime.Now;
                entity.Prrufirstdate = DateTime.Now;

                if (entity.Prrucodi == 0)
                {
                    id = FactorySic.GetMePerfilRuleRepository().Save(entity);
                }
                else 
                {
                    FactorySic.GetMePerfilRuleRepository().Update(entity);
                    id = entity.Prrucodi;
                }

                FactorySic.GetMePerfilRuleAreaRepository().Delete(id);

                foreach (string rol in roles)
                {
                    if (!string.IsNullOrEmpty(rol))
                    {
                        MePerfilRuleAreaDTO item = new MePerfilRuleAreaDTO { Areacode = int.Parse(rol), Prrucodi = id };
                        FactorySic.GetMePerfilRuleAreaRepository().Save(item);
                    }
                }

                return id;
            }
            catch (Exception ex)
            {               
                throw new Exception(ex.Message, ex);
            }
        }
             

        /// <summary>
        /// Permite obtener un registro de la tabla ME_PERFIL_RULE
        /// </summary>
        public MePerfilRuleDTO GetByIdMePerfilRule(int prrucodi)
        {
            MePerfilRuleDTO entity = FactorySic.GetMePerfilRuleRepository().GetById(prrucodi);
            List<MePerfilRuleAreaDTO> entitys = FactorySic.GetMePerfilRuleAreaRepository().GetByCriteria(prrucodi);
            List<int> ids = new List<int>();

            foreach (MePerfilRuleAreaDTO item in entitys)
            {
                ids.Add(item.Areacode);
            }

            entity.IdRoles = ids;

            return entity;
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_PERFIL_RULE
        /// </summary>
        public List<MePerfilRuleDTO> ListMePerfilRules()
        {
            return FactorySic.GetMePerfilRuleRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MePerfilRule
        /// </summary>
        public List<MePerfilRuleDTO> GetByCriteriaMePerfilRules(int area, string fuente)
        {
            return FactorySic.GetMePerfilRuleRepository().GetByCriteria(area, fuente);
        }

        /// <summary>
        /// Permite obtener los puntos para elaborar las fórmulas
        /// </summary>
        /// <param name="fuente"></param>
        /// <returns></returns>
        public List<MePerfilRuleDTO> ObtenerPuntosPorFuente(string fuente)
        {
            if (fuente == ConstanteFormulaScada.OrigenDemanda)
            {
                return FactorySic.GetMePerfilRuleRepository().ObtenerPuntosDemanda();
            }
            if (fuente == ConstanteFormulaScada.OrigenEjecutado)
            {
                return FactorySic.GetMePerfilRuleRepository().ObtenerPuntosEjecutado();
            }
            if (fuente == ConstanteFormulaScada.OrigenSCADA)
            {
                return FactorySic.GetMePerfilRuleScadaRepository().ObtenerPuntosScada();
            }

            return null;
        }

        /// <summary>
        /// Permite obtener el nombre del punto de medición
        /// </summary>
        /// <param name="fuente"></param>
        /// <param name="ptoMedicion"></param>
        /// <returns></returns>
        public string ObtenerNombrePunto(string fuente, int ptoMedicion)
        {
            if (fuente == ConstanteFormulaScada.OrigenEjecutado)
            {
                return FactorySic.GetMePerfilRuleRepository().ObtenerNombrePunto(ptoMedicion);
            }
            if (fuente == ConstanteFormulaScada.OrigenDemanda)
            {
                return FactorySic.GetMePerfilRuleRepository().ObtenerNombrePuntoDemanda(ptoMedicion);
            }
            if (fuente == ConstanteFormulaScada.OrigenSCADA)
            {
                return FactorySic.GetMePerfilRuleScadaRepository().ObtenerNombrePuntoScada(ptoMedicion);
            }
           
            return null;
        }

        /// <summary>
        /// Permite eliminar una formula
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        public void EliminarFormula(int id, string username)
        {
            try
            {
                FactorySic.GetMePerfilRuleRepository().Delete(id, username);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        
    }

    /// <summary>
    /// Clase que permite almacenar los items de una formula
    /// </summary>
    public class FormulaItem
    {
        public decimal Constante { get; set; }
        public string Tipo { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string PuntoNombre { get; set; }
    }
}
