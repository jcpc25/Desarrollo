using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla PR_GRUPODAT
    /// </summary>
    public class PrGrupodatHelper : HelperBase
    {
        public PrGrupodatHelper(): base(Consultas.PrGrupodatSql)
        {
        }

        public PrGrupodatDTO Create(IDataReader dr)
        {
            PrGrupodatDTO entity = new PrGrupodatDTO();

            int iFechadat = dr.GetOrdinal(this.Fechadat);
            if (!dr.IsDBNull(iFechadat)) entity.Fechadat = dr.GetDateTime(iFechadat);

            int iConcepcodi = dr.GetOrdinal(this.Concepcodi);
            if (!dr.IsDBNull(iConcepcodi)) entity.Concepcodi = Convert.ToInt32(dr.GetValue(iConcepcodi));

            int iGrupocodi = dr.GetOrdinal(this.Grupocodi);
            if (!dr.IsDBNull(iGrupocodi)) entity.Grupocodi = Convert.ToInt32(dr.GetValue(iGrupocodi));

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iFormuladat = dr.GetOrdinal(this.Formuladat);
            if (!dr.IsDBNull(iFormuladat)) entity.Formuladat = dr.GetString(iFormuladat);

            int iDeleted = dr.GetOrdinal(this.Deleted);
            if (!dr.IsDBNull(iDeleted)) entity.Deleted = Convert.ToInt32(dr.GetValue(iDeleted));

            int iFechaact = dr.GetOrdinal(this.Fechaact);
            if (!dr.IsDBNull(iFechaact)) entity.Fechaact = dr.GetDateTime(iFechaact);

            return entity;
        }


        #region Mapeo de Campos

        public string Fechadat = "FECHADAT";
        public string Concepcodi = "CONCEPCODI";
        public string Grupocodi = "GRUPOCODI";
        public string Lastuser = "LASTUSER";
        public string Formuladat = "FORMULADAT";
        public string Deleted = "DELETED";
        public string Fechaact = "FECHAACT";

        #endregion

        public string SqlValoresModoOperacionGrupoDat
        {
            get { return base.GetSqlXml("SqlValoresModoOperacionGrupoDat"); }
        }
    }
}
