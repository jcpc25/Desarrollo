using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EVE_MANTTO
    /// </summary>
    public class EveManttoHelper : HelperBase
    {
        public EveManttoHelper(): base(Consultas.EveManttoSql)
        {
        }

        public EveManttoDTO Create(IDataReader dr)
        {
            EveManttoDTO entity = new EveManttoDTO();

            int iManttocodi = dr.GetOrdinal(this.Manttocodi);
            if (!dr.IsDBNull(iManttocodi)) entity.Manttocodi = Convert.ToInt32(dr.GetValue(iManttocodi));

            int iEquicodi = dr.GetOrdinal(this.Equicodi);
            if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

            int iEvenclasecodi = dr.GetOrdinal(this.Evenclasecodi);
            if (!dr.IsDBNull(iEvenclasecodi)) entity.Evenclasecodi = Convert.ToInt32(dr.GetValue(iEvenclasecodi));

            int iTipoevencodi = dr.GetOrdinal(this.Tipoevencodi);
            if (!dr.IsDBNull(iTipoevencodi)) entity.Tipoevencodi = Convert.ToInt32(dr.GetValue(iTipoevencodi));

            int iCompcode = dr.GetOrdinal(this.Compcode);
            if (!dr.IsDBNull(iCompcode)) entity.Compcode = Convert.ToInt32(dr.GetValue(iCompcode));

            int iEvenini = dr.GetOrdinal(this.Evenini);
            if (!dr.IsDBNull(iEvenini)) entity.Evenini = dr.GetDateTime(iEvenini);

            int iEvenpreini = dr.GetOrdinal(this.Evenpreini);
            if (!dr.IsDBNull(iEvenpreini)) entity.Evenpreini = dr.GetDateTime(iEvenpreini);

            int iEvenfin = dr.GetOrdinal(this.Evenfin);
            if (!dr.IsDBNull(iEvenfin)) entity.Evenfin = dr.GetDateTime(iEvenfin);

            int iSubcausacodi = dr.GetOrdinal(this.Subcausacodi);
            if (!dr.IsDBNull(iSubcausacodi)) entity.Subcausacodi = Convert.ToInt32(dr.GetValue(iSubcausacodi));

            int iEvenprefin = dr.GetOrdinal(this.Evenprefin);
            if (!dr.IsDBNull(iEvenprefin)) entity.Evenprefin = dr.GetDateTime(iEvenprefin);

            int iEvenmwindisp = dr.GetOrdinal(this.Evenmwindisp);
            if (!dr.IsDBNull(iEvenmwindisp)) entity.Evenmwindisp = dr.GetDecimal(iEvenmwindisp);

            int iEvenpadre = dr.GetOrdinal(this.Evenpadre);
            if (!dr.IsDBNull(iEvenpadre)) entity.Evenpadre = Convert.ToInt32(dr.GetValue(iEvenpadre));

            int iEvenindispo = dr.GetOrdinal(this.Evenindispo);
            if (!dr.IsDBNull(iEvenindispo)) entity.Evenindispo = dr.GetString(iEvenindispo);

            int iEveninterrup = dr.GetOrdinal(this.Eveninterrup);
            if (!dr.IsDBNull(iEveninterrup)) entity.Eveninterrup = dr.GetString(iEveninterrup);

            int iEventipoprog = dr.GetOrdinal(this.Eventipoprog);
            if (!dr.IsDBNull(iEventipoprog)) entity.Eventipoprog = dr.GetString(iEventipoprog);

            int iEvendescrip = dr.GetOrdinal(this.Evendescrip);
            if (!dr.IsDBNull(iEvendescrip)) entity.Evendescrip = dr.GetString(iEvendescrip);

            int iEvenobsrv = dr.GetOrdinal(this.Evenobsrv);
            if (!dr.IsDBNull(iEvenobsrv)) entity.Evenobsrv = dr.GetString(iEvenobsrv);

            int iEvenestado = dr.GetOrdinal(this.Evenestado);
            if (!dr.IsDBNull(iEvenestado)) entity.Evenestado = dr.GetString(iEvenestado);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iEvenrelevante = dr.GetOrdinal(this.Evenrelevante);
            if (!dr.IsDBNull(iEvenrelevante)) entity.Evenrelevante = Convert.ToInt32(dr.GetValue(iEvenrelevante));

            int iDeleted = dr.GetOrdinal(this.Deleted);
            if (!dr.IsDBNull(iDeleted)) entity.Deleted = Convert.ToInt32(dr.GetValue(iDeleted));

            int iMancodi = dr.GetOrdinal(this.Mancodi);
            if (!dr.IsDBNull(iMancodi)) entity.Mancodi = Convert.ToInt32(dr.GetValue(iMancodi));


            int iEmprnomb = dr.GetOrdinal(this.Emprnomb);
            if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);

            int iEmprabrev = dr.GetOrdinal(this.Emprabrev);
            if (!dr.IsDBNull(iEmprabrev)) entity.Emprabrev = dr.GetString(iEmprabrev);

            int iEmprcodi = dr.GetOrdinal(this.Emprcodi);
            if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

            int iEvenclasedesc = dr.GetOrdinal(this.Evenclasedesc);
            if (!dr.IsDBNull(iEvenclasedesc)) entity.Evenclasedesc = dr.GetString(iEvenclasedesc);

            int iAreanomb = dr.GetOrdinal(this.Areanomb);
            if (!dr.IsDBNull(iAreanomb)) entity.Areanomb = dr.GetString(iAreanomb);

            int iFamcodi = dr.GetOrdinal(this.Famcodi);
            if (!dr.IsDBNull(iFamcodi)) entity.Famcodi = Convert.ToInt32(dr.GetValue(iFamcodi));

            int iFamnomb = dr.GetOrdinal(this.Famnomb);
            if (!dr.IsDBNull(iFamnomb)) entity.Famnomb = dr.GetString(iFamnomb);

            int iEquiabrev = dr.GetOrdinal(this.Equiabrev);
            if (!dr.IsDBNull(iEquiabrev)) entity.Equiabrev = dr.GetString(iEquiabrev);

            int iCausaevenabrev = dr.GetOrdinal(this.Causaevenabrev);
            if (!dr.IsDBNull(iCausaevenabrev)) entity.Causaevenabrev = dr.GetString(iCausaevenabrev);

            int iEquitension = dr.GetOrdinal(this.Equitension);
            if (!dr.IsDBNull(iEquitension)) entity.Equitension = dr.GetDecimal(iEquitension);

            int iTipoevenabrev = dr.GetOrdinal(this.Tipoevenabrev);
            if (!dr.IsDBNull(iTipoevenabrev)) entity.Tipoevenabrev = dr.GetString(iTipoevenabrev);

            int iTipoevendesc = dr.GetOrdinal(this.Tipoevendesc);
            if (!dr.IsDBNull(iTipoevendesc)) entity.Tipoevendesc = dr.GetString(iTipoevendesc);

            int iTipoemprdesc = dr.GetOrdinal(this.Tipoemprdesc);
            if (!dr.IsDBNull(iTipoemprdesc)) entity.Tipoemprdesc = dr.GetString(iTipoemprdesc);

            int iOsigrupocodi = dr.GetOrdinal(this.Osigrupocodi);
            if (!dr.IsDBNull(iOsigrupocodi)) entity.Osigrupocodi = dr.GetString(iOsigrupocodi);

            return entity;
        }


        #region Mapeo de Campos

        public string Manttocodi = "MANTTOCODI";
        public string Equicodi = "EQUICODI";
        public string Evenclasecodi = "EVENCLASECODI";
        public string Tipoevencodi = "TIPOEVENCODI";
        public string Compcode = "COMPCODE";
        public string Evenini = "EVENINI";
        public string Evenpreini = "EVENPREINI";
        public string Evenfin = "EVENFIN";
        public string Subcausacodi = "SUBCAUSACODI";
        public string Evenprefin = "EVENPREFIN";
        public string Evenmwindisp = "EVENMWINDISP";
        public string Evenpadre = "EVENPADRE";
        public string Evenindispo = "EVENINDISPO";
        public string Eveninterrup = "EVENINTERRUP";
        public string Eventipoprog = "EVENTIPOPROG";
        public string Evendescrip = "EVENDESCRIP";
        public string Evenobsrv = "EVENOBSRV";
        public string Evenestado = "EVENESTADO";
        public string Lastuser = "LASTUSER";
        public string Lastdate = "LASTDATE";
        public string Evenrelevante = "EVENRELEVANTE";
        public string Deleted = "DELETED";
        public string Mancodi = "MANCODI";

        public string Emprnomb = "EMPRNOMB";
        public string Emprabrev = "EMPRABREV";
        public string Emprcodi = "EMPRCODI";
        public string Evenclasedesc = "EVENCLASEDESC";
        public string Areanomb = "AREANOMB";
        public string Famcodi = "FAMCODI";
        public string Famnomb = "FAMNOMB";
        public string Equiabrev = "EQUIABREV";
        public string Causaevenabrev = "CAUSAEVENABREV";
        public string Equitension = "EQUITENSION";
        public string Tipoevennomb = "TIPOEVENNOMB";
        public string Tipoevenabrev = "TIPOEVENABREV";
        public string Tipoevendesc = "TIPOEVENDESC";
        public string Tipoemprdesc = "TIPOEMPRDESC";
        public string Osigrupocodi = "OSIGRUPOCODI";


        #endregion

        public string SqlMantEmpresas
        {
            get { return base.GetSqlXml("MantEmpresas"); }
        }

        public string SqlReporteMantto
        {
            get { return base.GetSqlXml("ReporteMantto"); }
        }
        
    }
}
