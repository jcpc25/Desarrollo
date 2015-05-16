using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla ME_PERFIL_RULE
    /// </summary>
    public class MePerfilRuleHelper : HelperBase
    {
        public MePerfilRuleHelper(): base(Consultas.MePerfilRuleSql)
        {
        }

        public MePerfilRuleDTO Create(IDataReader dr)
        {
            MePerfilRuleDTO entity = new MePerfilRuleDTO();

            int iPrrucodi = dr.GetOrdinal(this.Prrucodi);
            if (!dr.IsDBNull(iPrrucodi)) entity.Prrucodi = Convert.ToInt32(dr.GetValue(iPrrucodi));

            int iPrrupref = dr.GetOrdinal(this.Prrupref);
            if (!dr.IsDBNull(iPrrupref)) entity.Prrupref = dr.GetString(iPrrupref);

            int iPrruabrev = dr.GetOrdinal(this.Prruabrev);
            if (!dr.IsDBNull(iPrruabrev)) entity.Prruabrev = dr.GetString(iPrruabrev);

            int iPrrudetalle = dr.GetOrdinal(this.Prrudetalle);
            if (!dr.IsDBNull(iPrrudetalle)) entity.Prrudetalle = dr.GetString(iPrrudetalle);

            int iPrruformula = dr.GetOrdinal(this.Prruformula);
            if (!dr.IsDBNull(iPrruformula)) entity.Prruformula = dr.GetString(iPrruformula);

            int iPrruactiva = dr.GetOrdinal(this.Prruactiva);
            if (!dr.IsDBNull(iPrruactiva)) entity.Prruactiva = dr.GetString(iPrruactiva);

            int iPrrulastuser = dr.GetOrdinal(this.Prrulastuser);
            if (!dr.IsDBNull(iPrrulastuser)) entity.Prrulastuser = dr.GetString(iPrrulastuser);

            int iPrrulastdate = dr.GetOrdinal(this.Prrulastdate);
            if (!dr.IsDBNull(iPrrulastdate)) entity.Prrulastdate = dr.GetDateTime(iPrrulastdate);

            int iPrruind = dr.GetOrdinal(this.Prruind);
            if (!dr.IsDBNull(iPrruind)) entity.Prruind = dr.GetString(iPrruind);

            int iPrrufirstuser = dr.GetOrdinal(this.Prrufirstuser);
            if (!dr.IsDBNull(iPrrufirstuser)) entity.Prrufirstuser = dr.GetString(iPrrufirstuser);

            int iPrrufirstdate = dr.GetOrdinal(this.Prrufirstdate);
            if (!dr.IsDBNull(iPrrufirstdate)) entity.Prrufirstdate = dr.GetDateTime(iPrrufirstdate);

            return entity;
        }

        #region Mapeo de Campos

        public string Prrucodi = "PRRUCODI";
        public string Prrupref = "PRRUPREF";
        public string Prruabrev = "PRRUABREV";
        public string Prrudetalle = "PRRUDETALLE";
        public string Prruformula = "PRRUFORMULA";
        public string Prruactiva = "PRRUACTIVA";
        public string Prrulastuser = "PRRULASTUSER";
        public string Prrulastdate = "PRRULASTDATE";
        public string Prruind = "PRRUIND";
        public string Prrufirstuser = "PRRUFIRSTUSER";
        public string Prrufirstdate = "PRRUFIRSTDATE";        
        public string EmprNomb = "EMPRNOMB";
        public string AreaNomb = "AREANOMB";
        public string EquiNomb = "EQUINOMB";
        public string PtoMediCodi = "PTOMEDICODI";
        public string PtoDescripcion = "PTODESCRIPCION";
        public string PtoNomb = "PTONOMB";
        public string Fuente = "FUENTE";
        public string EmprCodi = "EMPRCODI";
        public string Areacodi = "AREACODI";
        
        public string SqlObtenerPuntosEjecutado
        {
            get { return base.GetSqlXml("ObtenerPuntosEjecutado"); }
        }

        public string SqlObtenerPuntosDemanda
        {
            get { return base.GetSqlXml("ObtenerPuntosDemanda"); }
        }

        public string SqlObtenerPuntosSCADA
        {
            get { return base.GetSqlXml("ObtenerPuntosScada"); }
        }

        public string SqlObtenerNombrePunto
        {
            get { return base.GetSqlXml("ObtenerNombrePunto"); }
        }

        public string SqlObtenerNombrePuntoDemanda
        {
            get { return base.GetSqlXml("ObtenerNombrePuntoDemanda"); }
        }

        public string SqlObtenerNombrePuntoScada
        {
            get { return base.GetSqlXml("ObtenerNombrePuntoScada"); }
        }

        #endregion
    }
}
