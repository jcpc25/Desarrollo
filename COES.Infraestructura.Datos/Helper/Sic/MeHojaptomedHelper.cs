using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla ME_HOJAPTOMED
    /// </summary>
    public class MeHojaptomedHelper : HelperBase
    {
        public MeHojaptomedHelper(): base(Consultas.MeHojaptomedSql)
        {
        }

        public MeHojaptomedDTO Create(IDataReader dr)
        {
            MeHojaptomedDTO entity = new MeHojaptomedDTO();

            int iPtomedicodi = dr.GetOrdinal(this.Ptomedicodi);
            if (!dr.IsDBNull(iPtomedicodi)) entity.Ptomedicodi = Convert.ToInt32(dr.GetValue(iPtomedicodi));

            int iHojaptolimsup = dr.GetOrdinal(this.Hojaptolimsup);
            if (!dr.IsDBNull(iHojaptolimsup)) entity.Hojaptolimsup = dr.GetDecimal(iHojaptolimsup);

            int iTipoinfocodi = dr.GetOrdinal(this.Tipoinfocodi);
            if (!dr.IsDBNull(iTipoinfocodi)) entity.Tipoinfocodi = Convert.ToInt32(dr.GetValue(iTipoinfocodi));

            int iFormatcodi = dr.GetOrdinal(this.Formatcodi);
            if (!dr.IsDBNull(iFormatcodi)) entity.Formatcodi = Convert.ToInt32(dr.GetValue(iFormatcodi));

            int iHojanumero = dr.GetOrdinal(this.Hojanumero);
            if (!dr.IsDBNull(iHojanumero)) entity.Hojanumero = Convert.ToInt32(dr.GetValue(iHojanumero));

            int iHojaptoliminf = dr.GetOrdinal(this.Hojaptoliminf);
            if (!dr.IsDBNull(iHojaptoliminf)) entity.Hojaptoliminf = dr.GetDecimal(iHojaptoliminf);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iHojaptoactivo = dr.GetOrdinal(this.Hojaptoactivo);
            if (!dr.IsDBNull(iHojaptoactivo)) entity.Hojaptoactivo = Convert.ToInt32(dr.GetValue(iHojaptoactivo));

            int iHojaptoorden = dr.GetOrdinal(this.Hojaptoorden);
            if (!dr.IsDBNull(iHojaptoorden)) entity.Hojaptoorden = Convert.ToInt32(dr.GetValue(iHojaptoorden));

            int iHojaptosigno = dr.GetOrdinal(this.Hojaptosigno);
            if (!dr.IsDBNull(iHojaptosigno)) entity.Hojaptosigno = Convert.ToInt32(dr.GetValue(iHojaptosigno));

            return entity;
        }


        #region Mapeo de Campos

        public string Ptomedicodi = "PTOMEDICODI";
        public string Hojaptolimsup = "HOJAPTOLIMSUP";
        public string Tipoinfocodi = "TIPOINFOCODI";
        public string Formatcodi = "FORMATCODI";
        public string Hojanumero = "HOJANUMERO";
        public string Hojaptoliminf = "HOJAPTOLIMINF";
        public string Lastuser = "LASTUSER";
        public string Lastdate = "LASTDATE";
        public string Hojaptoactivo = "HOJAPTOACTIVO";
        public string Hojaptoorden = "HOJAPTOORDEN";
        public string Hojaptosigno = "HOJAPTOSIGNO";

        #endregion

        public string SqlGetMaxOrder
        {
            get { return base.GetSqlXml("GetMaxOrder"); }
        }

    }
}
